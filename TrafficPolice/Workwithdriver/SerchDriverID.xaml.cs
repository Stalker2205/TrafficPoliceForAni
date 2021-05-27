using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для SerchDriverID.xaml
    /// </summary>
    public partial class SerchDriverID : Window
    {
        public SerchDriverID()
        {
            InitializeComponent();
            List<string> List = new List<string>();
            List.Add("Паспорт");
            List.Add("Права");
            DocumentComboBox.ItemsSource = List;
            DocumentComboBox.Text = "Паспорт";
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            if (DocumentComboBox.Text.ToString() == "Паспорт")
            {
                RequestsClass.CheckPassport(SeriesTbox.Text.ToString(), NumberTbox.Text.ToString());
                if (RequestsClass.Driver == null) { MessageBox.Show("Нет такого паспорта"); return; }
                Close();
            }
            else
            {
                RequestsClass.CheckDriverLicence(SeriesTbox.Text.ToString(), NumberTbox.Text.ToString());
                if (RequestsClass.Driver == null) { MessageBox.Show("Нет таких прав"); return; }
                Close();
            }
        }
    }
}
