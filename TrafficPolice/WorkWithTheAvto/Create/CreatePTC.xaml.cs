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
    public partial class CreatePTC : Window
    {
        public CreatePTC()
        {
            InitializeComponent();
        }
        public static bool Proverki(Grid grid)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Number")).Text) || ((TextBox)grid.FindName("tb_Number")).Text.Length != 6)
            {
                MessageBox.Show("Номер состоит из 6 цифр"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_Number")).Text);
                }
                catch { MessageBox.Show("Номер состоит из 6 цифр"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Series")).Text) || ((TextBox)grid.FindName("tb_Series")).Text.Length != 4)
            {
                MessageBox.Show("Серия состоит из 2-х цифр и 2-х букв"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_Series")).Text[0].ToString());
                    int.Parse(((TextBox)grid.FindName("tb_Series")).Text[1].ToString());
                }
                catch { MessageBox.Show("Серия состоит из 2-х цифр и 2-х букв"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_YearOfManufacture")).Text) || ((TextBox)grid.FindName("tb_YearOfManufacture")).Text.Length != 4)
            {
                MessageBox.Show("Год состоит из 4-х цифр"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_YearOfManufacture")).Text);
                }
                catch { MessageBox.Show("Год состоит из 4-х цифр"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_EngineVolume")).Text))
            {
                MessageBox.Show("Объем двигателя не может быть null"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_EngineVolume")).Text);
                }
                catch { MessageBox.Show("Объем двигателя должен быть числом"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_EngineType")).Text))
            {
                MessageBox.Show("Тип двигателя не может быть Null"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_EcoClass")).Text))
            {
                MessageBox.Show("Эко класс не может быть Null"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Manufacture")).Text))
            {
                MessageBox.Show("Производитель не может быть Null"); return false;
            }
            if (!((DatePicker)grid.FindName("tb_DateOut")).SelectedDate.HasValue)
            {
                MessageBox.Show("Дата выдачи не может быть Null"); return false;
            }
            return true;
        }

        public static void CreatePtc(Grid grid)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ptcs.Load();
                Ptc pt = new Ptc();
                pt.PtcID = CarClass.ID;
                pt.PtcNumber = int.Parse(((TextBox)grid.FindName("tb_Number")).Text);
                pt.PtcSeries = ((TextBox)grid.FindName("tb_Series")).Text;
                pt.YearOfManufacture = int.Parse(((TextBox)grid.FindName("tb_YearOfManufacture")).Text);
                pt.EngineVolume = int.Parse(((TextBox)grid.FindName("tb_EngineVolume")).Text);
                pt.EngineType = ((TextBox)grid.FindName("tb_EngineType")).Text;
                pt.EcoClass = ((TextBox)grid.FindName("tb_EcoClass")).Text;
                pt.Manufacture = ((TextBox)grid.FindName("tb_Manufacture")).Text;
                pt.CustomsRestrictions = ((TextBox)grid.FindName("tb_CustomsRestrictions")).Text;
                pt.DateOut = ((DatePicker)grid.FindName("tb_DateOut")).SelectedDate.Value.ToString();
                db.Ptcs.Add(pt);
                db.SaveChanges();
            }
        }

        private void bt_CreatePTC_Click(object sender, RoutedEventArgs e)
        {
            if (Proverki(grid_Maingrid))
            {
                CreatePtc(grid_Maingrid);
                MessageBox.Show("Успешно");
                Close();
            }
        }
    }
}
