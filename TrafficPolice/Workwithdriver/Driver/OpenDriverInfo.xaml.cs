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
    public partial class OpenDriverInfo : Page
    {
        int drivID = 0;
        int licId = 0;
        public OpenDriverInfo()
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
                gbDriverLicence.DataContext = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID).LastOrDefault();
                DriversLicense dv = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID).LastOrDefault();

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

#pragma warning disable CS0169 // Поле "OpenDriverInfo.ImageByte" никогда не используется.
        byte[] ImageByte;
#pragma warning restore CS0169 // Поле "OpenDriverInfo.ImageByte" никогда не используется.
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

        private void btOpenAllDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            AllDriverLicense all = new AllDriverLicense();
            all.ShowDialog();
        }
    }
}

