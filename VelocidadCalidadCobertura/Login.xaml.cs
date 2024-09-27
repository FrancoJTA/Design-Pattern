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
    public partial class Login : Window
    {
        SessionProxy proxy=new SessionProxy();
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (proxy.Login(txtUser.Text, txtPass.Password))
            {
                Interfaz interfaz = new Interfaz();
                interfaz.Show();
                this.Close();
            }
        }

        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            Registro reg = new Registro(proxy);
            reg.Show();
            this.Close();
        }
    }
}
