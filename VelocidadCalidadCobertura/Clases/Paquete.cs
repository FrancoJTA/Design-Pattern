using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VelocidadCalidadCobertura.Clases
{
    public class Memento
    {
        public Paquete Plan { get { return _Plan; } set { _Plan=value.Clone(); } }
        private Paquete _Plan;
        public DateTime FechaCambio { get; set; }

        public Memento(Paquete plan)
        {
            this.Plan = new Paquete(plan.Nombre, plan.Costo, plan.Canales, plan.Internet, plan.Adds);
            this.FechaCambio = DateTime.Now;
        }
    }
    public class Paquete
    {
        public string Nombre { get; set; }
        public double Costo { get; set; }
        public int Canales { get; set; }
        public int Internet { get; set; }
        public List<CompService> Adds { get; set; }
        public Paquete() { }

        public Paquete(string nombre, double costo, int canales, int internet, List<CompService> adds)
        {
            this.Internet = internet;
            this.Nombre = nombre;
            this.Costo = costo;
            this.Canales = canales;
            this.Internet = internet;
            this.Adds = new List<CompService>(adds);
        }
        public Paquete Clone()
        {
            return new Paquete(Nombre, Costo, Canales, Internet, new List<CompService>(Adds));
        }
        public Memento GuardarMemento()
        {
            return new Memento(this);
        }
    }
    public class Historial
    {
        public ObservableCollection<Memento> mementos = new ObservableCollection<Memento>();
        public Paquete paquete;
        public Historial() { }

        public void CambiarPlan(Paquete nuevoPlan)
        {
            paquete= nuevoPlan;
            if (paquete != null && mementos != null)
            {
                mementos.Add(nuevoPlan.GuardarMemento());
            }
            paquete = nuevoPlan;
        }
    }
    public class CompService
    {
        public string Nombre { get; set; }
        public double Costo { get; set; }
        public CompService() { }
    }
}