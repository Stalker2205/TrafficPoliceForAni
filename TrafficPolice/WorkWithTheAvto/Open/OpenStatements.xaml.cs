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
    /// Логика взаимодействия для CreateStatements.xaml
    /// </summary>
    public partial class OpenStatements : Window
    {

        public OpenStatements()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Statements.Load();
                try
                {
                    gr_Satements.DataContext = db.Statements.Local.Where(x => x.CarID == CarClass.ID && x.Act == "Зарегистрировать").First();
                }
                catch { MessageBox.Show("Нет заявления для регистрации"); Close(); }

            }
        }
    }
}
