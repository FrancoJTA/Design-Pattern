using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace VelocidadCalidadCobertura.Clases
{
    public class Singleton
    {
        private Singleton() { }
        private static readonly object _lock = new object();
        private static Singleton _instance;
        public bool IsAuthenticated { get; private set; }
        private Usuario usuario;

        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }

        public Usuario UsuarioActual
        {
            get { return usuario; } 
        }

        public void Login(Usuario user)
        {
            usuario = user;
            IsAuthenticated = true;
        }

        public void Logout()
        {
            usuario = null;
            IsAuthenticated = false;
        }
    }
    public class SessionProxy
    {
        private readonly Singleton _sessionManager;
        public List<Usuario> ListUser = new List<Usuario>
    {
        new Usuario(new Paquete("PLAN TIGO ILIMITADO", 699, 269, 130, new List<CompService>()))
        {
            Name="Flenttudo",
            Correo="franco@gmail.com",
            Password="12345",
            HistorialDeCambios = 
            {
                mementos = new ObservableCollection<Memento>
                {
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=new DateTime(2021, 7, 21, 14, 32, 45) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=new DateTime(2022, 3, 15, 10, 45, 30) },
                    new Memento(new Paquete("PLAN TIGO ILIMITADO", 699, 269, 130, new List<CompService>())) { FechaCambio=new DateTime(2022, 8, 5, 12, 22, 10) },
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=new DateTime(2023, 1, 19, 8, 30, 45) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=new DateTime(2023, 4, 21, 15, 12, 55) },
                    new Memento(new Paquete("PLAN TIGO ILIMITADO", 699, 269, 130, new List<CompService>())) { FechaCambio=DateTime.Now}
                }
            }
        },
        new Usuario(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>()))
        {
            Name="DriaMT",
            Correo="PenesitoRico@gmail.com",
            Password="54321",
            HistorialDeCambios = 
            {
                mementos = new ObservableCollection<Memento>
                {
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=new DateTime(2021, 6, 12, 14, 12, 45) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=new DateTime(2022, 2, 19, 10, 45, 30) },
                    new Memento(new Paquete("PLAN TIGO ILIMITADO", 699, 269, 130, new List<CompService>())) { FechaCambio=new DateTime(2022, 9, 8, 12, 22, 10) },
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=new DateTime(2023, 1, 30, 8, 30, 45) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=new DateTime(2023, 4, 18, 15, 12, 55) },
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=DateTime.Now}
                }
            }
        },
        new Usuario(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>()))
        {
            Name="McCocha",
            Correo="XxSolitarioGamerxX@outlook.com",
            Password="mipan",
            HistorialDeCambios = new Historial()
            {
                mementos = new ObservableCollection<Memento>
                {
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=new DateTime(2021, 5, 20, 14, 32, 45) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=new DateTime(2022, 1, 22, 10, 45, 30) },
                    new Memento(new Paquete("PLAN TIGO ILIMITADO", 699, 269, 130, new List<CompService>())) { FechaCambio=new DateTime(2022, 7, 15, 12, 22, 10) },
                    new Memento(new Paquete("PLAN TIGO INICIAL", 425, 214, 80, new List<CompService>())) { FechaCambio=new DateTime(2023, 2, 12, 8, 30, 45) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=new DateTime(2023, 3, 24, 15, 12, 55) },
                    new Memento(new Paquete("PLAN TIGO INTERMEDIO", 515, 270, 120, new List<CompService>())) { FechaCambio=DateTime.Now}
                }
            }
        }
    };
        public SessionProxy()
        {
            _sessionManager = Singleton.Instance;
        }
        public static void addUser() { 
        
        }
        public bool Login(string username, string password)
        {
            var user = ListUser.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                _sessionManager.Login(user);
            }
            return _sessionManager.IsAuthenticated;
        }

        public void Logout()
        {
            _sessionManager.Logout();
        }
    }
}
