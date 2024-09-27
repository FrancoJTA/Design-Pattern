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
    /// Lógica de interacción para Package.xaml
    /// </summary>
    public partial class Package : UserControl
    {
        Paquete Default=new Paquete("",0,0,0,new List<CompService>());
        Paquete Inicial = new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>());
        Paquete Intermedio = new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>());
        Paquete Avanzado = new Paquete("PLAN TIGO ILIMITADO", 699, 269, 130, new List<CompService>());
        Singleton sessionManager = Singleton.Instance;
        Usuario usuario;
        RadioButton radioButton;
        CompService hboMax=new CompService() { Nombre="HBO MAX", Costo=43};
        CompService paramount=new CompService() { Nombre="Paramount+", Costo=35};
        CompService hotpack=new CompService() { Nombre="Hot Pack", Costo=70};
        CompService primevideo=new CompService() { Nombre="Prime Video", Costo=45};
        CompService Golden=new CompService() { Nombre= "Golden", Costo=21};
        CompService Adrenalina=new CompService() { Nombre="Adrenalina", Costo=35};
        List<CompService> listado=new List<CompService>();
        public Package()
        {
            InitializeComponent();
            Loaded += Principal_Loaded;
        }
        private void Principal_Loaded(object sender, RoutedEventArgs e)
        {
            double total = 0;
            usuario = sessionManager.UsuarioActual;
            lbl1name.Content =usuario.PaqueteActual.Nombre;
            lblcanales.Content = usuario.PaqueteActual.Canales+" Canales" ;
            lblInternet.Content = usuario.PaqueteActual.Internet + " Mbs";
            total += usuario.PaqueteActual.Costo;
            string queso = "";
            foreach (CompService a in usuario.PaqueteActual.Adds) {
                total += a.Costo;
                queso +=a.Nombre+" - ";
            }
            lblService.Content = queso;
            lblToto.Content = total+" Bs";
        }
        private void PlanCheck(object sender, RoutedEventArgs e)
        {
            radioButton = sender as RadioButton;
        }

        private void Complemento(object sender, RoutedEventArgs e)
        {
            CompService serv=new CompService();
            CheckBox checkBox = sender as CheckBox;
            switch (checkBox.Content) {
                case "HBO MAX":
                    serv=hboMax;
                    break;
                case "Paramount+":
                    serv = paramount;
                    break;
                case "Hot Pack":
                    serv = hotpack;
                    break;
                case "Prime Video":
                    serv = primevideo;
                    break;
                case "Golden Pack":
                    serv = Golden;
                    break;
                case "Adrenalina":
                    serv = Adrenalina;
                    break;
                default: 
                    break;
            }
            listado.Add(serv);
        }

        private void Descomp(object sender, RoutedEventArgs e)
        {
            CompService serv = new CompService();
            CheckBox checkBox = sender as CheckBox;
            switch (checkBox.Content)
            {
                case "HBO MAX":
                    serv = hboMax;
                    break;
                case "Paramount+":
                    serv = paramount;
                    break;
                case "Hot Pack":
                    serv = hotpack;
                    break;
                case "Prime Video":
                    serv = primevideo;
                    break;
                case "Golden Pack":
                    serv = Golden;
                    break;
                case "Adrenalina":
                    serv = Adrenalina;
                    break;
                default:
                    break;
            }
            listado.Remove(serv);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            Paquete pq= new Paquete();
            switch (radioButton.Content) {
                case "Inicial":
                    pq = Inicial;
                    break;
                case "Intermedia":
                    pq = Intermedio;
                    break;
                case "Ilimitado":
                    pq = Avanzado;
                    break;
                default:
                    break;
            }
            pq.Adds = listado;
            usuario.CambiarPaquete(pq);
            Factura fuck=new Factura(pq);
            fuck.Show();
            double total = 0;
            usuario = sessionManager.UsuarioActual;
            lbl1name.Content = usuario.PaqueteActual.Nombre;
            lblcanales.Content = usuario.PaqueteActual.Canales;
            lblInternet.Content = usuario.PaqueteActual.Internet;
            total += usuario.PaqueteActual.Costo;
            string queso = "";
            foreach (CompService a in usuario.PaqueteActual.Adds)
            {
                total += a.Costo;
                queso += a.Nombre + " - ";
            }
            lblService.Content = queso;
            lblToto.Content = total;
        }

        private void Detalles_Click(object sender, RoutedEventArgs e)
        {
            Button a=sender as Button;
            Paquete pq = new Paquete();
            switch (a.Content)
            {
                case "Inicial":
                    pq = Inicial;
                    break;
                case "Intermedia":
                    pq = Intermedio;
                    break;
                case "Ilimitado":
                    pq = Avanzado;
                    break;
                default:
                    break;
            }
            detalles de = new detalles(pq);
            de.Show();  
        }
    }
}
