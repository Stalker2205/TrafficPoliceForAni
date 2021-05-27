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
    public partial class CreateStatements : Window
    {
        Dictionary<int, string> list = new Dictionary<int, string>();
        static List<string> act = new List<string>();
        static List<string> registr = new List<string>();
        static List<string> Izmen = new List<string>();
        static List<string> Snit = new List<string>();
        public static void Zapoln()
        {
            act.Clear();
            registr.Clear();
            Izmen.Clear();
            Snit.Clear();
            act.Add("Зарегистрировать");
            act.Add("Внести изменения");
            act.Add("Снять с учета");

            registr.Add("Приобретенное в РФ");
            registr.Add("Ввезенное в РФ");
            registr.Add("Высвобождаемое военное имущество");
            registr.Add("Изготовленное в индивидуальном порядке");
            registr.Add("Временно ввезенное на срок более 6 месяцев");

            Izmen.Add("Изменение собственника");
            Izmen.Add("Изменение данных о собственнике");
            Izmen.Add("Заменой или получение регистрационных знаков");
            Izmen.Add("Получением или свидетельства о регистрации ТС и ПТС взамен утраченных");
            Izmen.Add("Изменением регистрационных данных, не связанных с изменением конструкции");
            Izmen.Add("Изменением конструкции");

            Snit.Add("Вывоз за пределы РФ");
            Snit.Add("Утилизацией");
            Snit.Add("Утратой");
            Snit.Add("Хищением");
            Snit.Add("Продажей/передачей другому лицу");
        }
        public CreateStatements()
        {

            Zapoln();
            InitializeComponent();
            list.Clear();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                var driver = db.Drivers.Local;
                foreach (var item in driver)
                {
                    list.Add(item.DriverID, $"{item.FirstName} {item.LastName} {item.Patronymic}");
                }
                cb_Aplicant.ItemsSource = list;
            }
            cb_Act.ItemsSource = act;
            if (StatementsClass.Code == 0)
            {
                cb_Aplicant.Text = DriverClass.DriverDictinary;
                cb_Act.Text = "Зарегистрировать";
                cb_Cause.IsEnabled = true;
                cb_Cause.ItemsSource = registr;
                tb_car.Text = CarClass.ID.ToString();
            }
            else if (StatementsClass.Code == 1)
            {
                cb_Aplicant.IsEnabled = false;
                cb_Aplicant.Text = DriverClass.DriverDictinary;
                cb_Cause.IsEnabled = true;
                cb_Cause.ItemsSource = registr;
                tb_car.Text = CarClass.ID.ToString();
                tb_car.IsEnabled = false;
            }
        }

        private void cb_Act_DropDownClosed(object sender, EventArgs e)
        {
            if (cb_Act.Text == "Зарегистрировать")
            {
                cb_Cause.ItemsSource = registr;
                cb_Cause.IsEnabled = true;
            }
            else if (cb_Act.Text == "Внести изменения")
            {
                cb_Cause.ItemsSource = Izmen;
                cb_Cause.IsEnabled = true;
            }
            else
            {
                cb_Cause.ItemsSource = Snit;
            }
        }

        private void bt_CreateStatement_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cb_Act.Text))
            {
                MessageBox.Show("Выберите действие"); return;
            }
            else if (string.IsNullOrEmpty(cb_Cause.Text))
            {
                MessageBox.Show("Выберите причину"); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Statements.Load();
                Statement st = new Statement();
                st.Act = cb_Act.Text;
                st.Applicant = cb_Aplicant.Text;
                st.Cause = cb_Cause.Text;
                st.CarID = int.Parse(tb_car.Text);
                db.Statements.Add(st);
                db.SaveChanges();
            }
        }
    }
}
