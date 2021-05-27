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
    /// Логика взаимодействия для RaportPage.xaml
    /// </summary>
    public partial class RaportPage : Page
    {
        public RaportPage()
        {
            InitializeComponent();
        }

        private void bt_CreateRaports_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Raports.Load();
                db.Staffs.Load();
                Raports rp = new Raports();
                rp.StaffID = db.Staffs.Local.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword).First().StaffID;
                rp.RaportText = new TextRange(rtb_raportText.Document.ContentStart, rtb_raportText.Document.ContentEnd).Text;
                db.Raports.Add(rp);
                db.SaveChanges();
            }
            rtb_raportText.Document.Blocks.Clear();
        }
    }
}
