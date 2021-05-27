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
    public partial class CreateInsurances : Window
    {
        public CreateInsurances()
        {
            InitializeComponent();
        }
        public static bool proverk(Grid grid)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Number")).Text) || ((TextBox)grid.FindName("tb_Number")).Text.Length != 4)
            {
                MessageBox.Show("Номер страховки состоит из 4-х цифр!"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_Number")).Text);
                }
                catch { MessageBox.Show("Номер страховки состоит из 4-х цифр!"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Series")).Text) || ((TextBox)grid.FindName("tb_Series")).Text.Length != 6)
            {
                MessageBox.Show("Серия страховки состоит из 6 цифр!"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_Series")).Text);
                }
                catch { MessageBox.Show("Номер страховки состоит из 6 цифр!"); return false; }
            }
            if (!((DatePicker)grid.FindName("dp_DateStart")).SelectedDate.HasValue || ((DatePicker)grid.FindName("dp_DateStart")).SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Дата начала должна быть выбрана и не может быть в будущем"); return false;

            }
            if (!((DatePicker)grid.FindName("db_DateEnd")).SelectedDate.HasValue || ((DatePicker)grid.FindName("dp_DateStart")).SelectedDate > ((DatePicker)grid.FindName("db_DateEnd")).SelectedDate)
            {
                MessageBox.Show("Дата конца должна быть выбрана и не может быть раньше даты начала"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("cb_Insurant")).Text))
            {
                MessageBox.Show("Страхователь не может быть Null"); return false;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Insurances.Load();
                Insurance ins = new Insurance();
                ins.InsuranceID = CarClass.ID;
                ins.InsuranceNumber = int.Parse(((TextBox)grid.FindName("tb_Number")).Text);
                ins.InsuranceSeries = int.Parse(((TextBox)grid.FindName("tb_Series")).Text);
                ins.StartDate = ((DatePicker)grid.FindName("dp_DateStart")).SelectedDate.Value;
                ins.EndDate = ((DatePicker)grid.FindName("db_DateEnd")).SelectedDate.Value;
                ins.Insurant = ((TextBox)grid.FindName("cb_Insurant")).Text;
                db.Insurances.Add(ins);
                db.SaveChanges();
            }
            return true;
        }

        private void bt_createInsurants_Click(object sender, RoutedEventArgs e)
        {
            if (proverk(InsurancesGrid))
            {
                MessageBox.Show("Успешно!");
                Close();
            }
        }
    }
}
