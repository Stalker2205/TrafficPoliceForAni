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
    /// Логика взаимодействия для CreateDriver.xaml
    /// </summary>
    public partial class UpdateDriverfirst : Page
    {
        int drivID = 0;
        int licId = 0;
        public UpdateDriverfirst()
        {
            InitializeComponent();
            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Additionally\\Photo.png", UriKind.Absolute)); ;
            Photo.Source = bitmapImage;
            Kategoryes.Clear();
            AddCategories();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriverKategoryLicences.Load();
                db.Drivers.Load();
                db.DriversLicenses.Load();
                db.Passports.Load();
                gbPassport.DataContext = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID);
                var driver = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID);
                drivID = Convert.ToInt32(DriverClass.DriverID);
                foreach (var item in driver)
                {
                    TextBox_FirstName.Text = item.FirstName;
                    TextBox_LastName.Text = item.LastName;
                    TextBox_Patronimic.Text = item.Patronymic;
                    byte[] by = item.Photo;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(by);
                    bitmap.EndInit();
                    Photo.Source = bitmap;
                }
                gbDriverLicence.DataContext = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID).First();
                DriversLicense dv = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID).Last();

                var Licences = db.DriversLicenses.Local.Where(x => x.DriversLicenseID == dv.DriversLicenseID);
                int LicenseID = 0;
                foreach (var item in Licences)
                {
                    licId = LicenseID = item.DriversLicenseID;
                }
                var Kategory = db.DriverKategoryLicences.Local.Where(x => x.DriversLicenseID == LicenseID);
                foreach (var item in Kategory)
                {
                    CheckBox cb = (CheckBox)gbCategory.FindName($"cb{item.Kategory}");
                    DatePicker dp = (DatePicker)gbCategory.FindName($"dp{item.Kategory}");
                    cb.IsChecked = true;
                    dp.Text = item.DateOfAssignment.ToString();
                }
            }

        }
        Dictionary<string, bool> Cat = DriverClass.LoadCategory();

#pragma warning disable CS0414 // Полю "UpdateDriverfirst.key" присвоено значение, но оно ни разу не использовано.
        bool key = false;
#pragma warning restore CS0414 // Полю "UpdateDriverfirst.key" присвоено значение, но оно ни разу не использовано.
        byte[] ImageByte;
        private void CreateDriverButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Kategoryes)
            {
                if (item.Value)
                {
                    DatePicker dp = (DatePicker)gbCategory.FindName($"dp{item.Key}");
                    if (dp.SelectedDate.HasValue == false)
                    {
                        MessageBox.Show($"Выберите дату для категории{item.Key}"); return;
                    }
                }
            }
            #region Check number and Series
#pragma warning disable CS0168 // Переменная "LicNum" объявлена, но ни разу не использована.
            int PasSer, PasNum, LicSer, LicNum;
#pragma warning restore CS0168 // Переменная "LicNum" объявлена, но ни разу не использована.
            if (TextBox_PassportSeries.Text.Length == 0 || TextBox_PassportSeries.Text.Length != 4) { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; }
            else { try { PasSer = Convert.ToInt32(TextBox_PassportSeries.Text); } catch { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; } }

            if (TextBox_DriverLicenseSeries.Text.Length == 0 || TextBox_DriverLicenseSeries.Text.Length != 4) { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; }
            else { try { LicSer = Convert.ToInt32(TextBox_DriverLicenseSeries.Text); } catch { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; } }

            if (TextBox_PassportNumber.Text.Length == 0 || TextBox_PassportNumber.Text.Length != 6) { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(TextBox_PassportNumber.Text); } catch { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; } }

            if (TextBox_DriverLicenseNumber.Text.Length == 0 || TextBox_DriverLicenseNumber.Text.Length != 6) { MessageBox.Show("Номер прав состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(TextBox_DriverLicenseNumber.Text); } catch { MessageBox.Show("Номер прав состоит из 6 цифр"); return; } }
            #endregion
            #region Check datetime
            if (DatePicker_DateOfIssue.SelectedDate.Value.Date.Year < 1900) { MessageBox.Show($"Человеку не может быть {DateTime.Now.Date.Year - DatePicker_DateOfIssue.SelectedDate.Value.Date.Year} лет"); return; }
            //   if ((DatePicker_FinishDate.SelectedDate.Value.Date.Year - DatePicker_StartDate.SelectedDate.Value.Date.Year) < 0) { MessageBox.Show("Дата окончания должна быть больше даты выдачи"); return; }
            #endregion

            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.DriversLicenses.Load();
                db.Passports.Load();
                db.DriverKategoryLicences.Load();
                var driver = db.Drivers.Local.Where(x => x.DriverID == drivID).FirstOrDefault();
                driver.FirstName = TextBox_FirstName.Text;
                driver.LastName = TextBox_LastName.Text;
                driver.Patronymic = TextBox_Patronimic.Text;
                driver.Photo = ImageByte;
                db.SaveChanges();

            }
            MessageBox.Show("Водитель успешно Обновлен!"); return;
        }



        private void PhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image (*.png;*.jpg;*.BMP)|*.png;*.jpg;*.BMP";
            if (dialog.ShowDialog() == true)
            {
                Photo.Source = new BitmapImage(new Uri(dialog.FileName));
                key = true;
                ImageByte = File.ReadAllBytes(dialog.FileName);
            }

        }
        static Dictionary<string, bool> Kategoryes = new Dictionary<string, bool>();

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
    }
}

