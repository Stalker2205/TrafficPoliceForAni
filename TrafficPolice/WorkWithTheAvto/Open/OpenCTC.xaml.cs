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
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для CreateCTC.xaml
    /// </summary>
    public partial class OpenCTC : Window
    {
        Dictionary<int, string> list = new Dictionary<int, string>();
        public OpenCTC()
        {
            list.Clear();
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                try
                {
                    db.Cars.Load();
                    db.Drivers.Load();
                    db.Ctcs.Load();
                    var car = db.Cars.Local.Where(x => x.DriverID == CarClass.ID).FirstOrDefault();
                    var driver = db.Drivers.Local.Where(x => x.DriverID == (db.Cars.Local.Where(y => y.CarID == CarClass.ID).FirstOrDefault()).DriverID).FirstOrDefault();
                    list.Add(driver.DriverID, $"{driver.FirstName} {driver.LastName} {driver.Patronymic}");
                    cb_Owner.Text = list.First().ToString();
                    gr_Ctc.DataContext = db.Ctcs.Local;
                }
                catch { MessageBox.Show("У авто нет СТС"); Close(); }
            }
        }
    }
}
