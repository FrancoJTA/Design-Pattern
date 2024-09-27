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
using System.Windows.Shapes;
using VelocidadCalidadCobertura.Clases;
using VelocidadCalidadCobertura.ControlesInterfaz;

namespace VelocidadCalidadCobertura
{
    /// <summary>
    /// Lógica de interacción para Interfaz.xaml
    /// </summary>
    public partial class Interfaz : Window
    {
        Principal principal;
        Package package;
        HistoryPack historypack;
        Singleton sessionManager = Singleton.Instance;
        Usuario usuario;
        public Interfaz()
        {

            InitializeComponent();
            usuario = sessionManager.UsuarioActual;
            principal = new Principal();
            package = new Package();
            historypack=new HistoryPack();
            MainContent.Content = principal;
            lblUser.Content = usuario.Name;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = principal;
        }

        private void btnPackage_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = package;
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content= historypack;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Singleton sessionManager = Singleton.Instance;
            sessionManager.Logout();
            MainWindow quelocura= new MainWindow();
            quelocura.Show();
            this.Close();
        }
    }
}