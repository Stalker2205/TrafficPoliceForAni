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
    /// Логика взаимодействия для CreatePTC.xaml
    /// </summary>
    public partial class OpenPTC : Window
    {
        public OpenPTC()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                try
                {
                    db.Ptcs.Load();
                    var ptc = db.Ptcs.Local.Where(x => x.PtcID == CarClass.ID).First();
                    gr_Ptc.DataContext = ptc;
                }
                catch { MessageBox.Show("У авто нет ПТС");Close(); }
            }
        }
    }
}
