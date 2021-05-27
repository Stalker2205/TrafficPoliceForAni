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
    public partial class CreateInspections : Window
    {
        public CreateInspections()
        {
            InitializeComponent();
            tb_Vin.Text = CarClass.Vin;
            tb_Vin.IsEnabled = false;
            tb_BodyNumber.Text = CarClass.BodyNumber.ToString();
            tb_BodyNumber.IsEnabled = false;
            tb_ChossisNumber.Text = CarClass.ChossisNumber.ToString();
            tb_ChossisNumber.IsEnabled = false;
        }
        public static bool Proveroki(Grid grid)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_RegistrationNumber")).Text) || ((TextBox)grid.FindName("tb_RegistrationNumber")).Text.Length != 15)
            {
                MessageBox.Show("Регистрационный номер состоит из 15 знаков"); return false;
            }
            if (!((DatePicker)grid.FindName("tb_EndDate")).SelectedDate.HasValue)
            {
                MessageBox.Show("Дата окончания не может быть пустой"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Vin")).Text) || ((TextBox)grid.FindName("tb_Vin")).Text.Length != 17)
            {
                MessageBox.Show("Vin состоит из 17 знаков"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_ChossisNumber")).Text) || ((TextBox)grid.FindName("tb_ChossisNumber")).Text.Length != 6)
            {
                MessageBox.Show("Регистрационный номер состоит из 6 символов"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_ChossisNumber")).Text);
                }
                catch { MessageBox.Show("Регистрационный номер состоит из цифр"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_BodyNumber")).Text))
            {

                MessageBox.Show("Номер кузова состоит от 6 до 9 цифр"); return false;
            }
            else
            {
                if (((TextBox)grid.FindName("tb_BodyNumber")).Text.Length >= 6 && ((TextBox)grid.FindName("tb_BodyNumber")).Text.Length <= 9)
                {
                    try
                    {
                        int.Parse(((TextBox)grid.FindName("tb_BodyNumber")).Text);
                    }
                    catch { MessageBox.Show("Номер кузова состоит из цифр"); return false; }
                }
                else
                {
                    MessageBox.Show("Номер кузова состоит от 6 до 9 цифр"); return false;
                }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Model")).Text))
            {
                MessageBox.Show("Модель не может быть пустой"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_PlaceOfInspaction")).Text))
            {
                MessageBox.Show("Место осмотра не может быть пустым"); return false;
            }
            return true;
        }
        public static void CreateInsp(Grid grid)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Inspections.Load();
                Inspection ins = new Inspection();
                ins.RegistrationNumber = ((TextBox)grid.FindName("tb_RegistrationNumber")).Text;
                ins.EndDate = ((DatePicker)grid.FindName("tb_EndDate")).SelectedDate.Value;
                ins.PlaceOfInspaction = ((TextBox)grid.FindName("tb_PlaceOfInspaction")).Text;
                ins.Vin = ((TextBox)grid.FindName("tb_Vin")).Text;
                ins.ChossisNumber = int.Parse(((TextBox)grid.FindName("tb_ChossisNumber")).Text);
                ins.BodyNumber = int.Parse(((TextBox)grid.FindName("tb_BodyNumber")).Text);
                ins.Model = ((TextBox)grid.FindName("tb_Model")).Text;
                ins.Malfunctions = ((TextBox)grid.FindName("tb_Malfunctions")).Text;
                ins.UsingCar = ((CheckBox)grid.FindName("cb_Expl")).IsEnabled;
                ins.CarID = CarClass.ID;
                db.Inspections.Add(ins);
                db.SaveChanges();

            }
        }

        private void bt_CreateINspection_Click(object sender, RoutedEventArgs e)
        {
            if (Proveroki(grid_main))
            {
                CreateInsp(grid_main);
                MessageBox.Show("Успешно!");
                Close();
            }
        }
    }
}
