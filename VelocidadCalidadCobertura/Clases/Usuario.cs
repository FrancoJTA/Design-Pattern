using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VelocidadCalidadCobertura.Clases;

namespace VelocidadCalidadCobertura
{
    public class Usuario
    {
        public string Name { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public Paquete PaqueteActual { get { return _PaqueteActual; } set { _PaqueteActual = value.Clone(); } }
        private Paquete _PaqueteActual;
        public Historial HistorialDeCambios = new Historial();
        public Usuario(Paquete pack)
        {
            this.PaqueteActual = pack;
            this.HistorialDeCambios.CambiarPlan(pack);
        }

        public void CambiarPaquete(Paquete nuevoPaquete)
        {
            if (PaqueteActual != null)
            {
                HistorialDeCambios.CambiarPlan(nuevoPaquete);
            }
            PaqueteActual = nuevoPaquete;
        }
    }
}