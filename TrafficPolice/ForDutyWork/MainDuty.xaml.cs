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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для MainDuty.xaml
    /// </summary>
    public partial class MainDuty : Page
    {
        public MainDuty()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Hidden;
            WorkFrame.Visibility = Visibility.Visible;
            WorkFrame.Navigate(new RaportPage());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Hidden;
            WorkFrame.Visibility = Visibility.Visible;
            WorkFrame.Navigate(new CreateStaff());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Visible;
            WorkFrame.Visibility = Visibility.Hidden;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                dg_MainGrid.ItemsSource = db.Staffs.Local.Where(x=>x.Status == "Работает");
            }
        }

        private string _id;
        private void MenuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            _id = ((System.Windows.Controls.MenuItem)sender).Header.ToString();
            NewStaffClass.id = int.Parse(_id);
        }

        private void bt_viewSertification_Click(object sender, RoutedEventArgs e)
        {
            ViewSertificateWindow dd = new ViewSertificateWindow();
            dd.ShowDialog();
        }

        private void Bt_YvolStaff_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Вы уверены что хотите уволить сотрудника?","Увольнение",MessageBoxButtons.YesNo);
            if (dialogResult.ToString() == "Yes")
            {
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Staffs.Load();
                    var staf = db.Staffs.Local.Where(x => x.StaffID == NewStaffClass.id).First();
                    staf.Status = "Уволен";
                    db.SaveChanges();
                }
            }

        }

        private void bt_Reports_Click(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Hidden;
            WorkFrame.Visibility = Visibility.Visible;
            WorkFrame.Navigate(new ReportsPage());
        }

        private void CreateDtp_Click(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Hidden;
            WorkFrame.Visibility = Visibility.Visible;
            WorkFrame.Navigate(new DtpEvroPage());
        }
    }
}
