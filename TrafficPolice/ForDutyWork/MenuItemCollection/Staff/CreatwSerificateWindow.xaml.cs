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
    /// Логика взаимодействия для CreatwSerificatePAge.xaml
    /// </summary>
    public partial class CreatwSerificateWindow : Window
    {
        public CreatwSerificateWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            bool key = false;
            while (key == false)
            {
                string ser = string.Empty;
                string num = string.Empty;
                for (int i = 0; i < 4; i++)
                {
                    ser += rnd.Next(0, 9).ToString();
                }
                for (int i = 0; i < 6; i++)
                {
                    num += rnd.Next(0, 9).ToString();
                }
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Sertifications.Load();
                    if (db.Sertifications.Local.Where(x => x.SertificationSeries == int.Parse(ser) && x.SertificationNumber == int.Parse(num)).Count() == 0)
                    {
                        key = true;
                        tb_number.Text = num;
                        tb_series.Text = ser;
                    }
                }
            }
        }

        private void bt_CreateSertification_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Position.Text)) { MessageBox.Show("Введите место службы"); return; }
            if (dp_ValidUnit.SelectedDate.HasValue == false) { MessageBox.Show("Введите дату окончания действия удостоверения");return; }
            using(MyDBconnection db = new MyDBconnection())
            {
                db.Sertifications.Load();
                Sertification sr = new Sertification();
                sr.SertificationNumber =int.Parse( tb_number.Text);
                sr.SertificationSeries = int.Parse(tb_series.Text);
                sr.SertificationPosition = tb_Position.Text;
                sr.ValidUnit = dp_ValidUnit.DisplayDate;
                sr.StaffID = NewStaffClass.id;
                db.Sertifications.Add(sr);
                db.SaveChanges();
            }
            Close();
        }
    }
}
