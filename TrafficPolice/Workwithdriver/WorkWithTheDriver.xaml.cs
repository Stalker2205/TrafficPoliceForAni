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
    public partial class WorkWithTheDriver : Page
    {
        private string _id;
        public WorkWithTheDriver()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                DriverGrid.ItemsSource = db.Drivers.Local;
            }
        }

        private void CreateDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateDriver());
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Visible;
            FrameFromNavigation.Visibility = Visibility.Hidden;
            SerchDriverID serchDriverID = new SerchDriverID();
            serchDriverID.ShowDialog();
            if (RequestsClass.Driver == null) return;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                DriverGrid.ItemsSource = db.Drivers.Local.Where(x => x.DriverID == RequestsClass.Driver);
            }

        }

        private void OpenPeopleInfo_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new OpenDriverInfo());
        }

        private void UpdateDriverInfo_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new UpdateDriverfirst());
        }

        private void mcCreateDriverLIcence(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateDriverLicence());
        }



        private void MenuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            _id = ((MenuItem)sender).Header.ToString();
            DriverClass.DriverID = Convert.ToInt32(_id);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Visible;
            FrameFromNavigation.Visibility = Visibility.Hidden;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                DriverGrid.ItemsSource = db.Drivers.Local;
            }
        }
        private void View_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new ViewDriverLicence());
        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
            AllDriverLicense all = new AllDriverLicense();
            all.ShowDialog();
        }
    }
}

