using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для ViewSertificateWindow.xaml
    /// </summary>
    public partial class ViewSertificateWindow : Window
    {
        public ViewSertificateWindow()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                db.Sertifications.Load();
                var staf = db.Staffs.Local.Where(x => x.StaffID == NewStaffClass.id).First();
                var sert = db.Sertifications.Local.Where(x => x.StaffID == NewStaffClass.id).Last();
                tb_DateOfEnd.Text = sert.ValidUnit.Date.ToString();
                tb_SertificateNumber.Text = sert.SertificationNumber.ToString();
                tb_Fio.Text = $"{staf.FirstName}\r\n{staf.Lastname}";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(staf.Photo);
                bitmap.EndInit();
                im_photo.Source = bitmap;
            }
        }
    }
}
