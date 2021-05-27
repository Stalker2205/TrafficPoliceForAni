using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginF loginF = new LoginF();
            loginF.ShowDialog();
            FormPage.Navigate(new MainInfo());

            //#region Login
            //if (!LoginClass.key) { Close(); }
            //#endregion
            //#region DBSelect
            //using (MyDBconnection bconnection = new MyDBconnection())
            //{
            //    bconnection.Staffs.Load();
            //    bconnection.Ranks.Load();
            //    int RID = 0;
            //    var stf = bconnection.Staffs.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword);
            //    foreach (Staff staff in stf) RID = staff.RankID;
            //    var rnk = bconnection.Ranks.Where(X => X.RankID == RID);
            // //   foreach (Rank rank in rnk) { RankName.Text = rank.RankName; Rank.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"\\Image\\Pagon\\{rank.RankPhoto}",UriKind.Absolute)); }

            //}
            //#endregion 
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                var df = db.Drivers.Local.Where(x => x.DriverID == 1);
                foreach (var da in df)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(da.Photo);
                    bitmap.EndInit();
                    LogoImg.Source = bitmap;
                }

            }
        }

        private void Serchavto_Click(object sender, RoutedEventArgs e)
        {
            FormPage.Navigate(new SerchAvto());
        }

        private void AllAboutTheDriver_Click(object sender, RoutedEventArgs e)
        {
            FormPage.Navigate(new WorkWithTheDriver());
        }

        private void AllAboutTheAvto_Click(object sender, RoutedEventArgs e)
        {
            FormPage.Navigate(new WorkWithTheAvto());
        }

        private void bt_Duty_Click(object sender, RoutedEventArgs e)
        {
            FormPage.Navigate(new MainDuty());
        }
    }
}
