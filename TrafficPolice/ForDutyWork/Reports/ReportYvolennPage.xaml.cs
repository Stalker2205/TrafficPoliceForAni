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
using System.Data.Entity;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для ReportYvolennPage.xaml
    /// </summary>
    public partial class ReportYvolennPage : Page
    {
        public ReportYvolennPage()
        {
            InitializeComponent();
            using(MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                dg_staff.ItemsSource = db.Staffs.Local.Where(x => x.Status == "Уволен");
            }
        }
    }
}
