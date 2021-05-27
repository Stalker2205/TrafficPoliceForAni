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
    public partial class CreateDriver : Page
    {
        public CreateDriver()
        {
            InitializeComponent();
            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Additionally\\Photo.png", UriKind.Absolute)); ;
            Photo.Source = bitmapImage;
            Kategoryes.Clear();
            AddCategories();

        }
        Dictionary<string, bool> Cat = DriverClass.LoadCategory();

        bool key = false;
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
            if ((DatePicker_FinishDate.SelectedDate.Value.Date.Year - DatePicker_StartDate.SelectedDate.Value.Date.Year) < 0) { MessageBox.Show("Дата окончания должна быть больше даты выдачи"); return; }
            #endregion
            #region add Driver,Passport,DriverLicence,LicenceKategory
            if (!key) { MessageBox.Show("Необходимо выбрать фото!"); return; }
            int driverId = 0;
            int? passID = null;
            int? LicenceID = null;
            using (MyDBconnection db = new MyDBconnection())
            {
                #region load Table
                db.Passports.Load();
                db.DriversLicenses.Load();
                db.DriverKategoryLicences.Load();
                db.DriverKategoryLicences.Load();
                #endregion
                #region Serch passport and Driver licence 
                var pas1 = db.Passports.Local.Where(x => x.PassportNumber == Convert.ToInt32(TextBox_PassportNumber.Text) && x.PassportSeries == Convert.ToInt32(TextBox_PassportSeries.Text));
                foreach (Passport passport in pas1) { passID = passport.PassportID; }
                if (passID != null) { MessageBox.Show("Такой паспорт уже есть в системе"); return; }
                var drad = db.DriversLicenses.Local.Where(x => x.DriversLicenseNumber == Convert.ToInt32(TextBox_DriverLicenseNumber.Text) && x.DriversLicenseSeries == Convert.ToInt32(TextBox_DriverLicenseSeries.Text));
                foreach (DriversLicense dl in drad) { LicenceID = dl.DriversLicenseID; }
                if (LicenceID != null) { MessageBox.Show("Такие права уже существуют"); return; }
                #endregion
                #region create Driver
                Driver driver = new Driver();
                driver.FirstName = TextBox_FirstName.Text;
                driver.LastName = TextBox_LastName.Text;
                driver.Patronymic = TextBox_Patronimic.Text;
                driver.Photo = ImageByte;
                db.Drivers.Add(driver);
                db.SaveChanges();
                db.Drivers.Load();
                #endregion
                #region Create Passport
                var driv = db.Drivers.Local.Where(x => x.Photo == ImageByte);
                foreach (Driver dr in driv) { driverId = dr.DriverID; }
                Passport pass = new Passport();
                pass.PassportID = driverId;
                pass.PassportNumber = Convert.ToInt32(TextBox_PassportNumber.Text);
                pass.PassportSeries = Convert.ToInt32(TextBox_PassportSeries.Text);
                pass.PassportAdress = TextBox_Adress.Text;
                pass.DateOfIssue = DatePicker_DateOfIssue.DisplayDate.Date;
                db.Passports.Add(pass);
                #endregion
                #region Create Driver Licence
                DriversLicense driversLicense = new DriversLicense();
                driversLicense.DriverID = driverId;
                driversLicense.DriversLicenseNumber = Convert.ToInt32(TextBox_DriverLicenseNumber.Text);
                driversLicense.DriversLicenseSeries = Convert.ToInt32(TextBox_DriverLicenseSeries.Text);
                driversLicense.DateStart = DatePicker_StartDate.DisplayDate.Date;
                driversLicense.DateEnd = DatePicker_FinishDate.DisplayDate.Date;
                db.DriversLicenses.Add(driversLicense);
                db.SaveChanges();
                #endregion
                #region Add Licences Category
                int driverLicenceID = 0;
                var Licence = db.DriversLicenses.Local.Where(x => x.DriversLicenseNumber == Convert.ToInt32(TextBox_DriverLicenseNumber.Text) &&
                x.DriversLicenseSeries == Convert.ToInt32(TextBox_DriverLicenseSeries.Text));
                foreach (var item1 in Licence) { driverLicenceID = item1.DriversLicenseID; }
                foreach (var item in Kategoryes)
                {
                    if (item.Value)
                    {
                        DatePicker dp = (DatePicker)gbCategory.FindName($"dp{item.Key}");
                        DriverKategoryLicence driverKategory = new DriverKategoryLicence();
                        driverKategory.DateExpiration = dp.DisplayDate.Date;
                        driverKategory.Kategory = item.Key;
                        driverKategory.DateOfAssignment = dp.DisplayDate.Date;
                        driverKategory.DriversLicenseID = driverLicenceID;
                        db.DriverKategoryLicences.Add(driverKategory);
                        db.SaveChanges();
                    }
                }
                #endregion
            }
            #endregion
            MessageBox.Show("Водитель успешно создан!"); return;
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

