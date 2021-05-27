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
    public partial class ViewDriverLicence : Page
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
        public ViewDriverLicence()
        {
            Kategoryes.Clear();
            DriverLicenceClass._Date.Clear();
            InitializeComponent();
            DriverLicenceClass._Date.Clear();
            AddCategories();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                db.DriversLicenses.Load();
                db.DriverKategoryLicences.Load();
                grPassport.DataContext = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID).First();
                var driverLic = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID).Last();
                gbDriverLicence.DataContext = driverLic;
                dpDateofIssue.Text = driverLic.DateEnd.Date.ToString();
                var Kateg = db.DriverKategoryLicences.Local.Where(x => x.DriversLicenseID == driverLic.DriversLicenseID);
                grDriver.DataContext = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID).First();
                foreach (var item in Kateg)
                {
                    Kategoryes[item.Kategory] = true;
                    ((CheckBox)gbCategory.FindName($"cb{item.Kategory}")).IsChecked = true;
                    ((DatePicker)gbCategory.FindName($"dp{item.Kategory}")).Text = item.DateExpiration.ToString();
                    DriverLicenceClass._Date.Add(item.Kategory, item.DateExpiration);
                }
                #region Photo
                byte[] by = DriverLicenceClass._photo = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID).First().Photo;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(by);
                bitmap.EndInit();
                imPhoto.Source = bitmap;
                #endregion
            }
        }
        static Dictionary<string, bool> Kategoryes = new Dictionary<string, bool>();

        string kategorii = string.Empty;

        private void SaveAsDocument_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Kategoryes)
            {
                if (((CheckBox)gbCategory.FindName($"cb{item.Key}")).IsChecked == true)
                {
                    kategorii += $"{item.Key} - {((DatePicker)gbCategory.FindName($"dp{item.Key}")).Text}\r\n";

                }
            }
            string fileinfo =
                $"ID {DriverClass.DriverID.ToString()}\r\n" +
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

        private void btPrintDialog_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                db.DriversLicenses.Load();
                var Lic = db.DriversLicenses.Local.Where(x => x.DriversLicenseNumber == Convert.ToInt32(tbLicNumber.Text)
                && x.DriversLicenseSeries == Convert.ToInt32(tbLicSeries.Text)).FirstOrDefault();
                var driver = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID).FirstOrDefault();
                DriverLicenceClass._datestart = Lic.DateStart.ToString();
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
    }
}
