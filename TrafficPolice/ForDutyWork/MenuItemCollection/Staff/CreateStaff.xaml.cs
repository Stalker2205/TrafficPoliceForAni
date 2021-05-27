using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Data.Entity;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для CreateStaff.xaml
    /// </summary>
    public partial class CreateStaff : Page
    {
        public CreateStaff()
        {
            InitializeComponent();
            List<string> lis = new List<string>();
            lis.Clear();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ranks.Load();
                var rank = db.Ranks.Local;
                foreach (var item in rank)
                {
                    lis.Add(item.RankName);
                }
                cb_Rank.ItemsSource = lis;
            }
            key = false;
        }
        byte[] ImageByte;
        bool key;
        private void bt_serchPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image (*.png;*.jpg;*.BMP)|*.png;*.jpg;*.BMP";
            if (dialog.ShowDialog() == true)
            {
                im_Photo.Source = new BitmapImage(new Uri(dialog.FileName));
                ImageByte = File.ReadAllBytes(dialog.FileName);
                key = true;
            }
        }

        public bool login(string login)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                if (db.Staffs.Local.Where(x => x.Login == login).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void bt_SaveStaff_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_FirstName.Text)) { MessageBox.Show("Введите Имя"); return; }
            if (string.IsNullOrEmpty(tb_LastName.Text)) { MessageBox.Show("Введите Фамилию"); return; }
            if (!key) { MessageBox.Show("Выберите фото"); return; }
            if (string.IsNullOrEmpty(tb_Education.Text)) { MessageBox.Show("Введите Образование"); return; }
            if (string.IsNullOrEmpty(tb_login.Text)) { MessageBox.Show("Введите Логин"); return; }
            if (string.IsNullOrEmpty(pb_Password.Password)) { MessageBox.Show("Введите Пароль"); return; }
            if (string.IsNullOrEmpty(cb_Rank.Text)) { MessageBox.Show("Введите Звание"); return; }
            if (login(tb_login.Text)) { MessageBox.Show("Такой логин уже существует"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                db.Ranks.Load();
                Staff st = new Staff();
                st.FirstName = tb_FirstName.Text;
                st.Lastname = tb_LastName.Text;
                st.Photo = ImageByte;
                st.Education = tb_Education.Text;
                st.Login = tb_login.Text;
                st.Password = pb_Password.Password;
                st.RankID = db.Ranks.Local.Where(x => x.RankName == cb_Rank.Text).First().RankID;
                st.Status = "Работает";
                db.Staffs.Add(st);
                db.SaveChanges();
            }
            NewStaffClass.serchID(tb_login.Text, pb_Password.Password);
            bt_CreateYdost.IsEnabled = true;
            MessageBox.Show("Создано");
            bt_SaveStaff.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatwSerificateWindow dd = new CreatwSerificateWindow();
            dd.ShowDialog();
        }
    }
}
