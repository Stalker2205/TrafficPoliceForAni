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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
            FrameFromReports.Visibility = Visibility.Hidden;
        }

        private void bt_FromStaffRanks_Click(object sender, RoutedEventArgs e)
        {
            FrameFromReports.Visibility = Visibility.Visible;
            FrameFromReports.Navigate(new ReportStaffRankPage()) ;
        }

        private void bt_Yvolennie_Click(object sender, RoutedEventArgs e)
        {
            FrameFromReports.Visibility = Visibility.Visible;
            FrameFromReports.Navigate(new ReportYvolennPage());
        }
    }
}
