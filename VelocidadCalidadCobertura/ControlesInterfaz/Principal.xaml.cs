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
using VelocidadCalidadCobertura.Clases;

namespace VelocidadCalidadCobertura.ControlesInterfaz
{
    public partial class Principal : UserControl
    {
        Singleton sessionManager = Singleton.Instance;
        Usuario usuario;
        public Principal()
        {
            InitializeComponent();
            Loaded += Principal_Loaded;
        }
        private void Principal_Loaded(object sender, RoutedEventArgs e)
        {
            usuario = sessionManager.UsuarioActual;
            lblWelcome.Content = $"Bienvenido que locura \n{usuario.Name}";
            if(usuario.HistorialDeCambios.mementos.Count>0) { 
            lblName.Content = usuario.HistorialDeCambios.mementos.Last().Plan.Nombre;
            }
        }
    }
}