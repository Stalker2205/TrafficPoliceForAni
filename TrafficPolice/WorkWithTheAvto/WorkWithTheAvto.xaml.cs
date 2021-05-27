using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для WorkWithTheDriver.xaml
    /// </summary>
    public partial class WorkWithTheAvto : Page
    {
        private string _id;
        public WorkWithTheAvto()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                dgCar.ItemsSource = db.Cars.Local;
            }
        }

        private void MenuItem_SubmenuOpened_1(object sender, RoutedEventArgs e)
        {
            _id = ((MenuItem)sender).Header.ToString();
            CarClass.ID = Convert.ToInt32(_id);
        }

        private void bt_registredCar_Click(object sender, RoutedEventArgs e)
        {
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateCar());
            dgCar.Visibility = Visibility.Hidden;
        }

        private void bt_WiewAllCars_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                dgCar.ItemsSource = db.Cars.Local;
            }
        }

        private void bt_openInfoWithAvto_Click(object sender, RoutedEventArgs e)
        {
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new OpenCarInfo());
            dgCar.Visibility = Visibility.Hidden;
        }

        private void bt_OpenCTC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenCTC ct = new OpenCTC();
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

        private void tb_OpenInspections_Click(object sender, RoutedEventArgs e)
        {
            OpenInspections op = new OpenInspections();
            try
            {
                op.ShowDialog();
            }
            catch { }
        }

        private void bt_OpenStatement_Click(object sender, RoutedEventArgs e)
        {
            OpenStatements st = new OpenStatements();
            try
            {
                st.ShowDialog();
            }
            catch { }
        }

        private void bt_OpenInsurance_Click(object sender, RoutedEventArgs e)
        {
            OpenInsurances op = new OpenInsurances();
            try
            {
                op.ShowDialog();
            }
            catch { }
        }
    }
}

