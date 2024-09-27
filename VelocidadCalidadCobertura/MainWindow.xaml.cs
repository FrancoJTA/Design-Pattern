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

namespace VelocidadCalidadCobertura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            /*Login ventana = new Login();
            ventana.Show();
            this.Close();*/
            InitializeComponent();

            //mediaPlayer.Source = new Uri("C:\\Users\\Asus\\source\\repos\\VelocidadCalidadCobertura\\VelocidadCalidadCobertura\\VelocidadCalidadCobertura.mp4", UriKind.Absolute);
            mediaPlayer.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login ventana = new Login();
            ventana.Show();
            this.Close();
        }

        private void mediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            Login ventana = new Login();
            ventana.Show();
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

    }



}
