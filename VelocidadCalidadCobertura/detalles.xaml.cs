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

namespace VelocidadCalidadCobertura
{
    /// <summary>
    /// Lógica de interacción para detalles.xaml
    /// </summary>
    public partial class detalles : Window
    {
        public detalles(Paquete pac)
        {
            InitializeComponent();
            lblcosto.Content = pac.Costo+" Bs";
            lblName.Content = pac.Nombre ;
            lblTv.Content = pac.Canales + " Canales";
            lblInter.Content = pac.Internet + " Mbs";
        }
    }
}
