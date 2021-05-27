using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для AllDriverLicense.xaml
    /// </summary>
    public partial class AllDriverLicense : Window
    {
        static Dictionary<string, bool> Kategoryes = new Dictionary<string, bool>();
        static void AddCategories()
        {
            Kategoryes.Clear();
            Kategoryes.Add("A", false); Kategoryes.Add("A1", false);
            Kategoryes.Add("B", false); Kategoryes.Add("B1", false);
            Kategoryes.Add("C", false); Kategoryes.Add("C1", false);
            Kategoryes.Add("D", false); Kategoryes.Add("D1", false);
            Kategoryes.Add("BE", false); Kategoryes.Add("CE", false);
            Kategoryes.Add("C1E", false); Kategoryes.Add("DE", false);
            Kategoryes.Add("D1E", false); Kategoryes.Add("M", false);
            Kategoryes.Add("Tm", false); Kategoryes.Add("Tb", false);
        }
        public AllDriverLicense()
        {
            InitializeComponent();
            
            AddCategories();
            foreach (var item in Kategoryes)
            {
                ((CheckBox)gbCategory.FindName($"cb{item.Key}")).IsChecked = false;
                ((TextBlock)gbCategory.FindName($"dp{item.Key}")).Text = "Не присвоена";
            }
            using (MyDBconnection db = new MyDBconnection())
            {

                db.DriversLicenses.Load();
                dgDriverLicence.ItemsSource = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID);
                var DrivLic = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID).Last() ;

                gbDriverLicence.Header = $"Водительское удостоверение {DrivLic.DriversLicenseSeries}/{DrivLic.DriversLicenseNumber}";
                tbLicSeries.Text = DrivLic.DriversLicenseSeries.ToString();
                tbLicNumber.Text = DrivLic.DriversLicenseNumber.ToString();
                tbDateStart.Text = DrivLic.DateStart.Date.ToString();
                tbDateEnd.Text = DrivLic.DateEnd.Date.ToString();

                db.DriverKategoryLicences.Load();
                var kateg = db.DriverKategoryLicences.Local.Where(x => x.DriversLicenseID == DrivLic.DriversLicenseID);
                foreach (var item in kateg)
                {
                    ((CheckBox)gbCategory.FindName($"cb{item.Kategory}")).IsChecked = true;
                    ((TextBlock)gbCategory.FindName($"dp{item.Kategory}")).Text = item.DateExpiration.ToShortDateString();
                }
            }
        }

        private void dtViewDriverLIcence_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Kategoryes)
            {
                ((CheckBox)gbCategory.FindName($"cb{item.Key}")).IsChecked = false;
                ((TextBlock)gbCategory.FindName($"dp{item.Key}")).Text = "Не присвоена";
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                var DrivLic = db.DriversLicenses.Local.Where(x => x.DriversLicenseID == (int)((Button)sender).Content).First();

                gbDriverLicence.Header = $"Водительское удостоверение {DrivLic.DriversLicenseSeries}/{DrivLic.DriversLicenseNumber}";
                tbLicSeries.Text = DrivLic.DriversLicenseSeries.ToString();
                tbLicNumber.Text = DrivLic.DriversLicenseNumber.ToString();
                tbDateStart.Text = DrivLic.DateStart.Date.ToString();
                tbDateEnd.Text = DrivLic.DateEnd.Date.ToString();

                db.DriverKategoryLicences.Load();
                var kateg = db.DriverKategoryLicences.Local.Where(x => x.DriversLicenseID == (int)((Button)sender).Content);
                foreach (var item in kateg)
                {
                    ((CheckBox)gbCategory.FindName($"cb{item.Kategory}")).IsChecked = true;
                    ((TextBlock)gbCategory.FindName($"dp{item.Kategory}")).Text = item.DateExpiration.ToShortDateString();
                }
            }
        }
    }
}
