using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для CreateDriverLicence.xaml
    /// </summary>
    public partial class CreateDriverLicence : Page
    {
        static void AddCategories()
        {
            Kategoryes.Add("A", false); Kategoryes.Add("A1", false);
            Kategoryes.Add("B", false); Kategoryes.Add("B1", false);
            Kategoryes.Add("C", false); Kategoryes.Add("C1", false);
            Kategoryes.Add("D", false); Kategoryes.Add("D1", false);
            Kategoryes.Add("BE", false); Kategoryes.Add("CE", false);
            Kategoryes.Add("C1E", false); Kategoryes.Add("DE", false);
            Kategoryes.Add("D1E", false); Kategoryes.Add("M", false);
            Kategoryes.Add("Tm", false); Kategoryes.Add("Tb", false);
        }
        public CreateDriverLicence()
        {
            DriverLicenceClass._Date.Clear();
            InitializeComponent();
            DriverLicenceClass._Date.Clear();
            AddCategories();
            Kategoryes.Clear();
            List<int> DriverList = new List<int>();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                db.DriversLicenses.Load();
                db.DriverKategoryLicences.Load();
                var driver = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID).FirstOrDefault();
                db.Drivers.Load();
                db.Passports.Load();
                grDriver.DataContext = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID);
                grPassport.DataContext = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID);
                byte[] by = DriverLicenceClass._photo = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID).First().Photo;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(by);
                bitmap.EndInit();
                imPhoto.Source = bitmap;
            }
        }
        static Dictionary<string, bool> Kategoryes = new Dictionary<string, bool>();
        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string kat = check.Name;
            Kategoryes[kat.Remove(0, 2)] = true;
        }
        private void cbA_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string kat = check.Name;
            Kategoryes[kat.Remove(0, 2)] = false;
        }
        string kategorii = string.Empty;
        private void btGeneratSeries_Click(object sender, RoutedEventArgs e)
        {
            int key = 0;
            int ser = 0;
            int num = 0;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                do
                {
                    string number = string.Empty;
                    string series = string.Empty;
                    Random random = new Random();
                    for (int i = 0; i != 4; i++)
                    {
                        series += random.Next(1, 9).ToString();
                    }
                    ser = Convert.ToInt32(series);
                    for (int j = 0; j < 6; j++)
                    {
                        number += random.Next(1, 9).ToString();
                    }
                    num = Convert.ToInt32(number);
                    key = db.DriversLicenses.Local.Where(x => x.DriversLicenseSeries == ser && x.DriversLicenseNumber == num).Count();
                } while (key != 0);
                tbLicSeries.Text = ser.ToString();
                tbLicNumber.Text = num.ToString();
            }
        }
        bool key = false;
        private void btCreateDriverLicence_Click(object sender, RoutedEventArgs e)
        {

            if (tbLicSeries.Text.Length == 0 | tbLicNumber.Text.Length == 0)
            {
                MessageBox.Show("Необходимо сгенерировать серию и номер ВУ!"); return;
            }
            foreach (var item in Kategoryes)
            {
                if (item.Value == true)
                {
                    key = true;
                    if (((DatePicker)gbCategory.FindName($"dp{item.Key}")).SelectedDate.HasValue == false)
                    {
                        MessageBox.Show($"Необходимо выбрать дату завершения для категории {item.Key}"); return;
                    }
                    kategorii += $"{item.Key} - {((DatePicker)gbCategory.FindName($"dp{item.Key}")).SelectedDate.Value.Date.ToString()}\r\n";
                    DriverLicenceClass._Date.Add(item.Key, ((DatePicker)gbCategory.FindName($"dp{item.Key}")).SelectedDate.Value.Date);
                }
            }
            if (!key) { MessageBox.Show("Необходимо выбрать хотя бы 1 категорию для прав"); return; }
            if (dpDateofIssue.SelectedDate.Value.Date.Year < DateTime.Now.Date.Year) { MessageBox.Show("ВУ дествует как минимум год!"); return; }
            key = false;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                db.DriverKategoryLicences.Load();
                DriversLicense driversLicense = new DriversLicense();
                driversLicense.DriversLicenseNumber = Convert.ToInt32(tbLicNumber.Text);
                driversLicense.DriversLicenseSeries = Convert.ToInt32(tbLicSeries.Text);
                driversLicense.DriverID = Convert.ToInt32(DriverClass.DriverID);
                driversLicense.DateStart = DateTime.Now.Date;
                driversLicense.DateEnd = dpDateofIssue.SelectedDate.Value.Date;
                db.DriversLicenses.Add(driversLicense);
                db.SaveChanges();
                var Document = db.DriversLicenses.Local.Where(x => x.DriversLicenseNumber == Convert.ToInt32(tbLicNumber.Text) & x.DriversLicenseSeries == Convert.ToInt32(tbLicSeries.Text)).FirstOrDefault();
                foreach (var item in Kategoryes)
                {
                    if (item.Value == true)
                    {
                        DriverKategoryLicence kat = new DriverKategoryLicence();
                        kat.Kategory = item.Key;
                        kat.DateOfAssignment = DateTime.Now.Date;
                        DriverLicenceClass._datestart = DateTime.Now.Date.ToString(); ;
                        kat.DateExpiration = ((DatePicker)gbCategory.FindName($"dp{item.Key}")).SelectedDate.Value.Date;
                        kat.DriversLicenseID = Document.DriversLicenseID;
                        db.DriverKategoryLicences.Add(kat);
                    }
                }
                db.SaveChanges();
            }
            key = true;
            MessageBox.Show("Права выданы!"); return;
        }

        private void SaveAsDocument_Click(object sender, RoutedEventArgs e)
        {
            if (key)
            {
                string fileinfo =
                    $"ID {DriverClass.DriverID.ToString()}" +
                    $"Паспортные данные:\r\n" +
                    $"{tb_LastName.Text} {tb_Name.Text} {tb_Patronimyc.Text}\r\n" +
                    $"{tb_PasNumber.Text}|{tb_PasSeries.Text}\r\n" +
                    $"{tb_PasAdress.Text}\r\n" +
                    $"{tb_PasDateOfIssue.Text}\r\n" +
                    $"Водительское удостоверение:\r\n" +
                    $"{tbLicNumber.Text}|{tbLicSeries.Text}\r\n" +
                    $"{kategorii}";
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Word Documents| *.doc";
                if (Convert.ToBoolean(fileDialog.ShowDialog()))
                {
                    File.WriteAllText(fileDialog.FileName, fileinfo);
                }
            }
            else
            {
                MessageBox.Show("Для вывода в файл, необхходимо выдать права!"); return;
            }

        }

        private void btPrintDialog_Click(object sender, RoutedEventArgs e)
        {
            if (key)
            {
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Drivers.Load();
                    db.Passports.Load();
                    var driver = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID).FirstOrDefault();
                    DriverLicenceClass._name = tb_Name.Text;
                    DriverLicenceClass._lastname = tb_LastName.Text;
                    DriverLicenceClass._patronimyc = tb_Patronimyc.Text;
                    DriverLicenceClass._dateofIssue = driver.DateOfIssue.ToString();
                    DriverLicenceClass._dateEnd = tb_PasDateOfIssue.Text;
                    DriverLicenceClass._series = Convert.ToInt32(tbLicSeries.Text);
                    DriverLicenceClass._number = Convert.ToInt32(tbLicNumber.Text);
                }
                PrintBY pr = new PrintBY();
                pr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Для печати, необхходимо выдать права!"); return;
            }

        }
    }
}
