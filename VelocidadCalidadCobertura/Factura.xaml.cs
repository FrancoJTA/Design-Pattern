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
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        public Factura(Paquete pack)
        {
            InitializeComponent();
            double tot = 0;
            String algo = pack.Nombre + "\n\t\t\t\t" + pack.Costo+" Bs";
            lblPack.Content= algo;
            tot += pack.Costo;
            String coso = "";
            foreach (CompService a in pack.Adds) {
                coso += a.Nombre + "\n\t\t\t\t" + a.Costo + " Bs" + "\n";
                tot+= a.Costo;
            }

            lblService.Content= coso;
            lblTotal.Content= "TOTAL "+tot+" Bs";
        }
    }
}
