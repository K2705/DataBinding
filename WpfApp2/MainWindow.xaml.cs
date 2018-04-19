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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bird> linnut = new List<Bird>();
        public MainWindow()
        {
            InitializeComponent();
            linnut = BirdViewModel.Get3TestBirds();
            lstData.DataContext = linnut;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image kuva = sender as Image;
            Bird lintu = kuva.DataContext as Bird;
            tbName.Text = lintu.Name;
            tbPrice.Text = lintu.Value.ToString();

            imgBird.Source = new BitmapImage(new Uri("pack://application:,,,/" + lintu.ImgFile));
        }
    }
}
