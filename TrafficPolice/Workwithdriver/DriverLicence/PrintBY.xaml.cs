using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для PrintBY.xaml
    /// </summary>
    public partial class PrintBY : Window
    {
        public PrintBY()
        {
            InitializeComponent();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(DriverLicenceClass._photo);
            bitmap.EndInit();
            Photo.Source = bitmap;
            tb_LastName.Text = DriverLicenceClass._lastname;
            tb_Name.Text = DriverLicenceClass._name;
            tb_Patronimyc.Text = DriverLicenceClass._patronimyc;
            tb_DateOfIssue.Text = DriverLicenceClass._dateofIssue.Substring(0, 10);
            tb_DateStart.Text = DriverLicenceClass._datestart.Substring(0, 10);
            tb_DateEnd.Text = DriverLicenceClass._dateEnd.Substring(0, 10);
            tb_numberSeries.Text = $"{DriverLicenceClass._number}  {DriverLicenceClass._series}";
            foreach (var item in DriverLicenceClass._Date)
            {
                if (item.Key.Length == 1)//1 - A B C D M
                {
                    if (item.Key == "M")
                    {
                        tbOrgA.Text += item.Key;
                        if (tbDateStartA.Text.Length == 0)
                        {
                            tbDateStartA.Text = DriverLicenceClass._datestart.Substring(0, 10);
                            tbDateEndA.Text = item.Value.ToString().Substring(0, 10);
                        }

                    }
                    else
                    {
                        ((TextBlock)grCategory.FindName($"tbDateStart{item.Key}")).Text = DriverLicenceClass._datestart.Substring(0, 10);
                        ((TextBlock)grCategory.FindName($"tbDateEnd{item.Key}")).Text = item.Value.ToString().Substring(0, 10);

                    }
                }
                else if (item.Key.Length == 2)//(BE CE DE) 2 A1 B1 C1 D1  Tm Tb
                {
                    if (item.Key == "Tm" || item.Key == "Tb")
                    {
                        ((TextBlock)grCategory.FindName($"tbDateStart{item.Key}")).Text = DriverLicenceClass._datestart.Substring(0, 10);
                        ((TextBlock)grCategory.FindName($"tbDateEnd{item.Key}")).Text = item.Value.ToString().Substring(0, 10);
                    }
                    else
                    {
                        ((TextBlock)grCategory.FindName($"tbOrg{item.Key[0].ToString()}")).Text += item.Key;
                        if (((TextBlock)grCategory.FindName($"tbDateStart{item.Key[0].ToString()}")).Text.Length == 0)
                        {
                            ((TextBlock)grCategory.FindName($"tbDateEnd{item.Key[0].ToString()}")).Text = item.Value.ToString().Substring(0, 10);
                        }
                    }
                }
                else//3 C1E D1E 
                {
                    ((TextBlock)grCategory.FindName($"tbOrg{item.Key[0].ToString()}{item.Key[2].ToString()}")).Text = item.Key;
                    ((TextBlock)grCategory.FindName($"tbDateStart{item.Key[0].ToString()}{item.Key[2].ToString()}")).Text = DriverLicenceClass._datestart.Substring(0, 10);
                    ((TextBlock)grCategory.FindName($"tbDateEnd{item.Key[0].ToString()}{item.Key[2].ToString()}")).Text = item.Value.ToString().Substring(0, 10);
                }
            }

        }
        private void bt_Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(PrintGrid, "печатаем грид");
            }
        }

    }


}

