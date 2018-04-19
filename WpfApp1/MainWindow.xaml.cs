using System;
using System.Collections.Generic;
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
using JAMK.IT;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string imagePath = @"D:\K2705\";
        private List<Auto> autot = new List<Auto>();
        public MainWindow()
        {
            InitializeComponent();
            //aloituskuva
            NaytaKuva("autotalli.png");
            //ladataan autot muistiin
            autot = Autotalli.HaeAutot();
            //täytetään combobox automerkeillä
            //List<string> merkit = new List<string>();
            //merkit.Add("Audi");
            //merkit.Add("Saab");
            //merkit.Add("Volvo");
            //cmbMerkit.ItemsSource = merkit;
            var result = autot.Select(x => x.Merkki).Distinct();
            cmbMerkit.ItemsSource = result;
        }

        private void NaytaKuva(string url)
        {
            if (url == "" || url == null) url = "puuttuu.png";
            try
            {
                url = imagePath + url;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(url);
                bi.EndInit();
                imgAuto.Stretch = Stretch.Fill;
                imgAuto.Source = bi;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void btnHaeAutot_Click(object sender, RoutedEventArgs e)
        {
            dgAutot.ItemsSource = autot;
        }

        private void btnHaeAudit_Click(object sender, RoutedEventArgs e)
        {
            //näytä vain audit
            dgAutot.ItemsSource = autot.Where(x => x.Merkki.Equals("Audi")).ToList();
        }

        private void dgAutot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Auto valittu = dgAutot.SelectedItem as Auto;
            if (valittu != null)
            {
                NaytaKuva(valittu.URL);
            }
        }

        private void cmbMerkit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgAutot.ItemsSource = autot.Where(x => x.Merkki.Equals(cmbMerkit.SelectedItem.ToString())).ToList();
        }
    }
}
