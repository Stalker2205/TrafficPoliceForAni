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
    /// Логика взаимодействия для CreateCar.xaml
    /// </summary>
    public partial class CreateCar : Page
    {
        Dictionary<int, string> list = new Dictionary<int, string>();
        public CreateCar()
        {
            list.Clear();
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                var driver = db.Drivers.Local;
                foreach (var item in driver)
                {
                    list.Add(item.DriverID, $"{item.FirstName} {item.LastName} {item.Patronymic}");
                }
            }
            cb_Driver.ItemsSource = list;
        }
        public static bool Proverka(Grid group)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_Vin")).Text) || ((TextBox)group.FindName("tb_Vin")).Text.Length != 17)
            {
                MessageBox.Show($"Vin состоит из 17 символов, вы ввели {((TextBox)group.FindName("tb_Vin")).Text.Length} "); return false;
            }

            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_CarType")).Text))
            {
                MessageBox.Show("Введите тип машин!"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_EngineNumber")).Text) || ((TextBox)group.FindName("tb_EngineNumber")).Text.Length != 6)
            {
                MessageBox.Show("Введите номер двигателя"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)group.FindName("tb_EngineNumber")).Text);
                }
                catch { MessageBox.Show("Номер двигателя состоит из цифр"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_ChossingNumber")).Text) || ((TextBox)group.FindName("tb_ChossingNumber")).Text.Length != 6)
            {
                MessageBox.Show("Регистрационный номер состоит из 6 символов"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)group.FindName("tb_ChossingNumber")).Text);
                }
                catch
                {
                    MessageBox.Show("Регистрационный номер состоит из 6 символов"); return false;
                }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_bodyNomber")).Text))
            {

                MessageBox.Show("Номер кузова состоит от 6 до 9 цифр"); return false;
            }
            else
            {
                if (((TextBox)group.FindName("tb_bodyNomber")).Text.Length >= 6 && ((TextBox)group.FindName("tb_bodyNomber")).Text.Length <= 9)
                {
                    try
                    {
                        int.Parse(((TextBox)group.FindName("tb_bodyNomber")).Text);
                    }
                    catch { MessageBox.Show("Номер кузова состоит из цифр"); return false; }
                }
                else
                {
                    MessageBox.Show("Номер кузова состоит из цифр"); return false;
                }
            }

            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_Color")).Text))
            {
                MessageBox.Show("Цвет не может быть Null"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_MaxWeight")).Text))
            {
                MessageBox.Show("Максимальный веш не может быть Null"); return false;
            }
            if (((ComboBox)group.FindName("cb_Driver")).SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать водителя!"); return false;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                if (db.Cars.Local.Where(x => x.Vin == ((TextBox)group.FindName("tb_Vin")).Text).Count() != 0)
                {
                    MessageBox.Show("Такой Vin уже существует"); return false;
                }
                if (db.Cars.Local.Where(x => x.EngineNumber == int.Parse(((TextBox)group.FindName("tb_EngineNumber")).Text)).Count() != 0)
                {
                    MessageBox.Show("Такой Номер двигателя уже существует"); return false;
                }
                if (db.Cars.Local.Where(x => x.ChossisNumber == int.Parse(((TextBox)group.FindName("tb_ChossingNumber")).Text)).Count() != 0)
                {
                    MessageBox.Show("Такой Регистрационный номер уже существует"); return false;
                }

                if (db.Cars.Local.Where(x => x.BodyNumber == int.Parse(((TextBox)group.FindName("tb_bodyNomber")).Text)).Count() != 0)
                {
                    MessageBox.Show("Такой номер кузова уже существует"); return false;
                }

                #region Creating
                object di = ((ComboBox)group.FindName("cb_Driver")).SelectedItem;
                KeyValuePair<int, string> valuePair = (KeyValuePair<int, string>)di;
                int id = valuePair.Key;
                Car car = new Car();
                car.Vin = ((TextBox)group.FindName("tb_Vin")).Text;
                car.VenhicleType = ((TextBox)group.FindName("tb_CarType")).Text;
                car.EngineNumber = int.Parse(((TextBox)group.FindName("tb_EngineNumber")).Text);
                car.BodyNumber = int.Parse(((TextBox)group.FindName("tb_bodyNomber")).Text);
                car.ChossisNumber = int.Parse(((TextBox)group.FindName("tb_ChossingNumber")).Text);
                car.Color = ((TextBox)group.FindName("tb_Color")).Text;
                car.MaxVeigh = int.Parse(((TextBox)group.FindName("tb_MaxWeight")).Text);
                car.Status = "Не зарегестрированно";
                car.DriverID = id;
                db.Cars.Add(car);
                db.SaveChanges();
                var car1 = db.Cars.Local.Where(x => x.Vin == ((TextBox)group.FindName("tb_Vin")).Text).First();
                CarClass.ID = car.CarID;
                CarClass.ChossisNumber = int.Parse(((TextBox)group.FindName("tb_ChossingNumber")).Text);
                CarClass.BodyNumber =int.Parse( ((TextBox)group.FindName("tb_bodyNomber")).Text);
                CarClass.Vin = ((TextBox)group.FindName("tb_Vin")).Text;
                DriverClass.DriverID = id;
                #endregion
            }
            return true;
        }
        public static bool ProvDoc(int CarID)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                db.Ctcs.Load();
                db.Ptcs.Load();
                db.Insurances.Load();
                db.Inspections.Load();
                db.Statements.Load();

                try
                {
                    db.Ctcs.Local.Where(x => x.CtcID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Ptcs.Local.Where(x => x.PtcID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Insurances.Local.Where(x => x.InsuranceID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Inspections.Local.Where(x => x.CarID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Statements.Local.Where(x => x.CarID == CarID).First();
                }
                catch { return false; }
                db.Cars.Local.Where(x => x.CarID == CarID).First().Status = "Зарегестрированно";
                db.SaveChanges();

            }
            return true;
        }
        private void bt_CreateCar_Click(object sender, RoutedEventArgs e)
        {
            if (Proverka(gr_car))
            {
                gb_Documents.IsEnabled = true;
                MessageBox.Show("Создано, для окончания регистрации внесите все необходимые документы");
            }
        }

        private void bt_createCTC_Click(object sender, RoutedEventArgs e)
        {
            DriverClass.DriverDictinary = cb_Driver.Text;
            CreateCTC cr = new CreateCTC();
            cr.ShowDialog();
            ProvDoc(CarClass.ID);
        }

        private void bt_insurance_Click(object sender, RoutedEventArgs e)
        {
            CreateInsurances cr = new CreateInsurances();
            cr.ShowDialog();
            ProvDoc(CarClass.ID);
        }

        private void bt_Statements_Click(object sender, RoutedEventArgs e)
        {
            DriverClass.DriverDictinary = cb_Driver.Text;
            StatementsClass.Code = 0;
            CreateStatements cr = new CreateStatements();
            cr.ShowDialog();
            ProvDoc(CarClass.ID);
        }

        private void tb_createPTC_Click(object sender, RoutedEventArgs e)
        {
            CreatePTC pt = new CreatePTC();
            pt.ShowDialog();
            ProvDoc(CarClass.ID);
        }

        private void bt_createInspections_Click(object sender, RoutedEventArgs e)
        {
            CreateInspections cr = new CreateInspections();
            cr.ShowDialog();
            ProvDoc(CarClass.ID);
        }
    }

}
