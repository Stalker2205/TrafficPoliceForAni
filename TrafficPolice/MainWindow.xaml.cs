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

            #region Login
            if (LoginClass.key)
            {
                #endregion
                #region DBSelect
                using (MyDBconnection bconnection = new MyDBconnection())
                {
                    bconnection.Staffs.Load();
                    bconnection.Ranks.Load();
                    var stf = bconnection.Staffs.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword).First();
                    var rnk = bconnection.Ranks.Where(X => X.RankID == stf.RankID).First();
                    FIO.Text = $"{stf.FirstName} {stf.Lastname}";
                    RankName.Text = rnk.RankName;
                }
                #endregion
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Staffs.Load();
                    
                    var df = db.Staffs.Local.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword).First(); ;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(df.Photo);
                    bitmap.EndInit();
                    LogoImg.Source = bitmap;
                }
            }
            else
            {
                Close();
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

        private void LogoImg_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                Staff staf = db.Staffs.Local.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword).First();
                NewStaffClass.id = staf.StaffID;
            }
            ViewSertificateWindow dd = new ViewSertificateWindow();
            dd.ShowDialog();
        }
    }
}
