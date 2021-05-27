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
    /// Логика взаимодействия для ReportStaffRankPage.xaml
    /// </summary>
    public partial class ReportStaffRankPage : Page
    {
        public ReportStaffRankPage()
        {
            List<string> rank = new List<string>();
            rank.Clear();
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ranks.Load();
                var ra = db.Ranks.Local;
                foreach (var item in ra)
                {
                    rank.Add(item.RankName);
                }
                cb_ranks.ItemsSource = rank;
            }
        }

        private void cb_ranks_DropDownClosed(object sender, EventArgs e)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ranks.Load();
                db.Staffs.Load();
                int rankId = db.Ranks.Local.Where(x => x.RankName == cb_ranks.Text).FirstOrDefault().RankID;
                var staffs = db.Staffs.Local.Where(x => x.RankID == rankId);
                dg_staff.ItemsSource = staffs;
            }
        }
    }
}
