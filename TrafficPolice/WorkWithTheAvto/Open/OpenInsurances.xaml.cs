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
    /// Логика взаимодействия для CreateInsurances.xaml
    /// </summary>
    public partial class OpenInsurances : Window
    {
        public OpenInsurances()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Insurances.Load();
                try
                {
                    InsurancesGrid.DataContext = db.Insurances.Local.Where(x => x.InsuranceID == CarClass.ID).Last();
                }
                catch { MessageBox.Show("У авто нет страховки"); Close(); }
            }
        }
    }
}
