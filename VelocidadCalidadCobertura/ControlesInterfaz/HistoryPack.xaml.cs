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
    /// <summary>
    /// Lógica de interacción para HistoryPack.xaml
    /// </summary>
    public partial class HistoryPack : UserControl
    {
        Singleton sessionManager = Singleton.Instance;
        Usuario usuario;
        public HistoryPack()
        {
            InitializeComponent();
            usuario = sessionManager.UsuarioActual;
            myListView.ItemsSource = usuario.HistorialDeCambios.mementos;
        }
    }
}
