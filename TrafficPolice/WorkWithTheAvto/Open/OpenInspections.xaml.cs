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
    /// Логика взаимодействия для CreateInspections.xaml
    /// </summary>
    public partial class OpenInspections : Window
    {
        public OpenInspections()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Inspections.Load();
                try
                {
                    grid_main.DataContext = db.Inspections.Local.Where(x => x.CarID == CarClass.ID).Last();
                }
                catch { MessageBox.Show("У авто нет тех.осмотров"); Close(); }
            }
        }

    }
}
