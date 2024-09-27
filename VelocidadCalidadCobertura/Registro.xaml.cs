using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        SessionProxy Proxy;
        public Registro(SessionProxy pr)
        {
            InitializeComponent();
            this.Proxy = pr;
        }

        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text != "" && txtEmail.Text != "" && txtPass.Password != "")
            {
                Usuario usuario = new Usuario(new Paquete("", 0, 0, 0, new List<CompService>()))
                {
                    Name = txtUser.Text,
                    Correo = txtEmail.Text,
                    Password = txtPass.Password,
                    HistorialDeCambios = new Historial()
                };
                Proxy.ListUser.Add(usuario);
                MessageBox.Show(Proxy.ListUser.Last().Name);
                if (Proxy.Login(txtUser.Text, txtPass.Password))
                {
                    Interfaz ventana = new Interfaz();
                    ventana.Show();
                    this.Close();
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
