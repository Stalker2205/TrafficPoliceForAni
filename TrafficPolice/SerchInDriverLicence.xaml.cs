using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для SerchInCars.xaml
    /// </summary>
    public partial class SerchInDriverLicence : Page
    {
        public SerchInDriverLicence()
        {
            InitializeComponent();
        }
        int PackageDocuments = 0;
        int Driver = 0;
        bool keySerch = false;

        private void CheckVIn()
        {
            int NumberPss;
            int SeriesPass;
            if (PassportNumberTbox.Text.Length != 6 || PassportNumberTbox.Text.Length ==0 || PassportSeriesTbox.Text.Length == 0 || PassportSeriesTbox.Text.Length == 4)
            {
                MessageBox.Show("Длина серии = 4 цифры, длина номера = 6 цифр"); return; 
            }
            try
            {
                NumberPss = Convert.ToInt32( PassportNumberTbox.Text);
                SeriesPass = Convert.ToInt32(PassportSeriesTbox.Text);
            }
            catch { MessageBox.Show("Серия и номер должны быть цифрами");return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
          //      db.Cars.Local.Where(x => x.Vin == VinTbox.Text.ToString());
           //     var ur = db.Cars.Where(x => x.Vin == VinTbox.Text.ToString());
            //    foreach (Car car in ur) { PackageDocuments = car.CarID; ; Driver = car.DriverID; }
            }
            keySerch = true;
        }

        private void SerchDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            if (!keySerch)
            {
               CheckVIn(); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                DataGrid data = (DataGrid)db.DriversLicenses.Local.Where(x => x.DriverID == Driver);
                DatagridFirst.ItemsSource = data.ItemsSource;
            }
        }

        private void PtcSerch_Click(object sender, RoutedEventArgs e)
        {
            if(!keySerch)
            {
                CheckVIn(); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ptcs.Load();
                DatagridFirst.ItemsSource = db.Ptcs.Local.Where(x => x.PtcID == PackageDocuments);
            }
        }

        private void SetchInsurance_Click(object sender, RoutedEventArgs e)
        {
            if (!keySerch)
            {
                CheckVIn(); return;
            }
            using(MyDBconnection db = new MyDBconnection())
            {
                db.Insurances.Load();
                DatagridFirst.ItemsSource = db.Insurances.Local.Where(x=>x.InsuranceID == PackageDocuments);
            }
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            if (!keySerch)
            {
                CheckVIn(); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                DatagridFirst.ItemsSource = db.Drivers.Local.Where(x => x.DriverID == Driver);
            }
        }

        private void SerchAvto_Click(object sender, RoutedEventArgs e)
        {
          //  if (VinTbox.Text.Length != 17) { MessageBox.Show("Длина vin - 17 символов"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
              //  DatagridFirst.ItemsSource = db.Cars.Local.Where(x => x.Vin == VinTbox.Text.ToString());
               // var ur = db.Cars.Where(x => x.Vin == VinTbox.Text.ToString());
                foreach (Car car in ur) { PackageDocuments = car.CarID; ; Driver = car.DriverID; }
            }
            keySerch = true;
        }
    }
}
