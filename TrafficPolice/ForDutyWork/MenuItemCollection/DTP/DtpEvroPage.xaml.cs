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
using System.Windows.Navigation;
using System.Data.Entity;
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для DtpEvroPage.xaml
    /// </summary>
    public partial class DtpEvroPage : Page
    {
        private Brush Gray;
        private Brush White;
        private bool Key = false;
        private bool addKey = false;
        private int Carid;
        private int DtpId;
        public DtpEvroPage()
        {
            InitializeComponent();
            Gray = PageDtp.Background;
            White = gr_Pero.Background;
            Key = false;
            addKey = false;
        }

        private void im_Pero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gr_lasso.Background = Gray;
            gr_Pero.Background = White;
            gr_Lastik.Background = Gray;
            Can_Scheme.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void im_Lastik_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gr_lasso.Background = Gray;
            gr_Pero.Background = Gray;
            gr_Lastik.Background = White;
            Can_Scheme.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void im_lasso_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gr_lasso.Background = White;
            gr_Pero.Background = Gray;
            gr_Lastik.Background = Gray;
            Can_Scheme.EditingMode = InkCanvasEditingMode.Select;
        }

        private void bt_SaveScheme_Click(object sender, RoutedEventArgs e)
        {
            if (Key == false) { MessageBox.Show("Необходимо ввести хотя бы 1 тс, участвующие в дтп"); return; }
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)Can_Scheme.ActualWidth, (int)Can_Scheme.ActualHeight, 96, 96, System.Windows.Media.PixelFormats.Default);
            rtb.Render(Can_Scheme);

            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            rtb.Render(Can_Scheme);
            byte[] bitmapBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                ms.Position = 0;
                bitmapBytes = ms.ToArray();
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Dtps.Load();
                var dtp = db.Dtps.Local.Where(x => x.DtpID == DtpId).FirstOrDefault();
                dtp.DtpScheme = bitmapBytes;
                db.SaveChanges();
            }
            MessageBox.Show("Схема приложена");

        }

        private void bt_createDTpAndFirstCar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Adress.Text)) { MessageBox.Show("Введите адрес"); return; }
            if (string.IsNullOrEmpty(tb_Voditel.Text)) { MessageBox.Show("Введите Фио водителя"); return; }
            if (Key == false) { MessageBox.Show("Необходимо ввести данные хотя бы об одном ТС"); return; }
            string text = new TextRange(tb_Obsoiat.Document.ContentStart, tb_Obsoiat.Document.ContentEnd).Text;
            if (string.IsNullOrEmpty(text)) { MessageBox.Show("Введите обстоятельства ДТП"); return; }
            if (addKey)
            {
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.DtpCars.Load();
                    DtpCar dtpCar = new DtpCar();
                    dtpCar.CarID = Carid;
                    dtpCar.Voditel = tb_Voditel.Text;
                    dtpCar.DtpID = DtpId;
                    dtpCar.Conditions = text;
                    db.DtpCars.Add(dtpCar);
                    db.SaveChanges();
                }
            }
            else
            {
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Dtps.Load();
                    db.DtpCars.Load();
                    db.Staffs.Load();
                    Dtp dtp = new Dtp();
                    var staff = db.Staffs.Local.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword).FirstOrDefault();
                    dtp.Addres = tb_Adress.Text;
                    dtp.DateDtp = DateTime.Now;
                    dtp.AccidentWitnesses = tb_People.Text;
                    dtp.StaffID = staff.StaffID;
                    db.Dtps.Add(dtp);
                    db.SaveChanges();
                    var dtp1 = db.Dtps.Local.Where(x => x.Addres == tb_Adress.Text && x.AccidentWitnesses == tb_People.Text).LastOrDefault();
                    DtpId = dtp1.DtpID;
                    DtpCar dtpCar = new DtpCar();
                    dtpCar.CarID = Carid;
                    dtpCar.Voditel = tb_Voditel.Text;
                    dtpCar.DtpID = DtpId;
                    dtpCar.NameOfScheme = tb_NaScheme.Text;
                    dtpCar.Conditions = text;
                    db.DtpCars.Add(dtpCar);
                    db.SaveChanges();
                }
                addKey = false;
            }
                MessageBox.Show("Успешно");
        }

        private void bt_ViewTS_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_vin.Text)) { MessageBox.Show("Введите vin для поиска машины"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                if (db.Cars.Local.Where(x => x.Vin == tb_vin.Text).Count() == 0) { MessageBox.Show("Нет такого ТС"); return; }
                var car = db.Cars.Local.Where(x => x.Vin == tb_vin.Text).FirstOrDefault();
                tb_CarType.DataContext = car;
                Carid = car.CarID;
                Key = true;
            }
        }
    }
}
