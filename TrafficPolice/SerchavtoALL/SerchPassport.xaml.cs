using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для SerchInCars.xaml
    /// </summary>
    public partial class SerchPassport : Page
    {
        public SerchPassport()
        {
            InitializeComponent();
            RequestsClass.keySerch = false;
            RequestsClass.Driver = null;
            RequestsClass.PackageDocuments = null;
        }

        private void SerchDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckPassport(PassportSeriesTbox.Text.ToString(), PassportNumberTbox.Text.ToString()); return;
            }
            if (RequestsClass.Driver == null) { MessageBox.Show("Нет такого водителя"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                DatagridFirst.ItemsSource = db.DriversLicenses.Local.Where(x => x.DriverID == RequestsClass.Driver);
            }
        }

        private void PtcSerch_Click(object sender, RoutedEventArgs e)
        {
            int car;
            if (CarID.Text.Length == 0) { MessageBox.Show("Введите ID машины"); return; }
            try
            {
                car = Convert.ToInt32(CarID.Text);
            }
            catch { MessageBox.Show("ID машины должно быть числом!"); return; }


            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckPassport(PassportSeriesTbox.Text.ToString(), PassportNumberTbox.Text.ToString()); return;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                var cra = db.Cars.Local.Where(x => x.CarID == car);
                foreach (Car car1 in cra) { RequestsClass.PackageDocuments = car1.CarID; }
                if (RequestsClass.PackageDocuments == null) { MessageBox.Show("Нет такого ТС"); return; }
                //  db.Ptcs.Load();
                //  DatagridFirst.ItemsSource = db.Ptcs.Local.Where(x => x.PtcID == RequestsClass.PackageDocuments);
            }

        }

        private void SetchInsurance_Click(object sender, RoutedEventArgs e)
        {
            int car;
            if (CarID.Text.Length == 0) { MessageBox.Show("Введите ID машины"); return; }
            try
            {
                car = Convert.ToInt32(CarID.Text);
            }
            catch { MessageBox.Show("ID машины должно быть числом!"); return; }
            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckPassport(PassportSeriesTbox.Text.ToString(), PassportNumberTbox.Text.ToString()); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                // db.Insurances.Load();

                var cra = db.Cars.Local.Where(x => x.CarID == car);
                foreach (Car car1 in cra) { RequestsClass.PackageDocuments = car1.CarID; }
                if (RequestsClass.PackageDocuments == null) { MessageBox.Show("Нет такого ТС"); return; }

                //DatagridFirst.ItemsSource = db.Insurances.Local.Where(x => x.InsuranceID == RequestsClass.PackageDocuments);
            }
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {

            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckPassport(PassportSeriesTbox.Text.ToString(), PassportNumberTbox.Text.ToString()); return;
            }
            if (RequestsClass.Driver == null) { MessageBox.Show("Нет такого водителя"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                DatagridFirst.ItemsSource = db.Drivers.Local.Where(x => x.DriverID == RequestsClass.Driver);
            }
        }

        private void SerchAvto_Click(object sender, RoutedEventArgs e)
        {

            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckPassport(PassportSeriesTbox.Text.ToString(), PassportNumberTbox.Text.ToString()); return;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                DatagridFirst.ItemsSource = db.Cars.Local.Where(x => x.DriverID == RequestsClass.Driver);
            }
        }

        private void DriverLicenceSeriesTbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RequestsClass.keySerch = false;
            RequestsClass.Driver = null;
            RequestsClass.PackageDocuments = null;
        }
    }
}
