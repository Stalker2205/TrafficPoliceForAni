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
    /// Логика взаимодействия для CreateCar.xaml
    /// </summary>
    public partial class OpenCarInfo : Page
    {
        Dictionary<int, string> list1 = new Dictionary<int, string>();
        public OpenCarInfo()
        {
            list1.Clear();
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Cars.Load();
                #region хрень какая-то
                gr_car.DataContext = db.Cars.Local.Where(x => x.CarID == CarClass.ID);
                var car = db.Cars.Local.Where(x => x.CarID == CarClass.ID).FirstOrDefault();
                var driv = db.Drivers.Local.Where(x => x.DriverID == car.DriverID).FirstOrDefault();
                list1.Add(driv.DriverID, $"{driv.FirstName} {driv.LastName} {driv.Patronymic}");
                cb_Driver.Text = list1.First().ToString();
                #endregion
            }
        }

        private void bt_createCTC_Click(object sender, RoutedEventArgs e)
        {
            OpenCTC ct = new OpenCTC();
            ct.ShowDialog();
        }

        private void bt_OpenCTC_Click(object sender, RoutedEventArgs e)
        {
            OpenCTC ct = new OpenCTC();
            try
            {
                ct.ShowDialog();
            }
            catch { }
        }

        private void tb_OpenPTC_Click(object sender, RoutedEventArgs e)
        {
            OpenPTC pt = new OpenPTC();
            try
            {
                pt.ShowDialog();
            }
            catch { }
        }

        private void bt_OpenInsurance_Click(object sender, RoutedEventArgs e)
        {
            OpenInsurances ins = new OpenInsurances();
            try
            {
                ins.ShowDialog();
            }
            catch { }
        }

        private void bt_OpenInspection_Click(object sender, RoutedEventArgs e)
        {
            OpenInspections insp = new OpenInspections();
            try
            {
                insp.ShowDialog();
            }
            catch { }
        }

        private void bt_OpenSatatements_Click(object sender, RoutedEventArgs e)
        {
            OpenStatements stat = new OpenStatements();
            try
            {
                stat.ShowDialog();
            }
            catch { }
        }

        private void bt_CreateInsurance_Click(object sender, RoutedEventArgs e)
        {
            CreateInsurances cr = new CreateInsurances();
            cr.ShowDialog();
        }

        private void bt_CreateInspection_Click(object sender, RoutedEventArgs e)
        {
            DriverClass.DriverDictinary = cb_Driver.Text;
            CarClass.Vin = tb_Vin.Text;
            CarClass.BodyNumber = int.Parse(tb_bodyNomber.Text);
            CarClass.ChossisNumber = int.Parse(tb_ChossingNumber.Text);
            StatementsClass.Code = 1;
            CreateInspections cr = new CreateInspections();
            cr.ShowDialog();
        }

        private void bt_createStatements_Click(object sender, RoutedEventArgs e)
        {
            DriverClass.DriverDictinary = cb_Driver.Text;
            CreateStatements cr = new CreateStatements();
            cr.ShowDialog();
        }
    }

}
