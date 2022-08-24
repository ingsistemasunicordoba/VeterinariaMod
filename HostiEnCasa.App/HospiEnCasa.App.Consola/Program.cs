using HostiEnCasa.App.Dominio;
using HostiEnCasa.App.Persistencia;
using System;

namespace HostiEnCasa.App.Consola
{
    public class Program
    {
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Persistencia.AppContext()); 
        private static IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Persistencia.AppContext()); 

        public static void Main(string[] args)
        {            
            Console.WriteLine("Registrando una persona");
            //addPersona();
            addPaciente();
        }        

        public static void addPersona(){
            var persona = new Persona{
                Nombre = "Juan Carlos",
                Apellidos = "Zambrano Montealegre",
                NumeroTelefono = "317123456",
                Genero = Genero.Masculino,
                Discriminator = "Sr"
            };

            _repositorioPersona.AddPersona(persona);
        }

        public static void addPaciente(){
            var paciente = new Paciente{
                Nombre = "Marisol",
                Apellidos = "Ramirez",
                NumeroTelefono = "313123456",
                Genero = Genero.Femenino,
                Discriminator = "Sra",
                Direccion = "Calle falsa 123",
                Longitud = 5.075114F,
                Latitud = -75.52990F,
                Ciudad = "Yumbo",
                FechaNacimiento = new DateTime(1990, 06, 28)
            };
            _repositorioPaciente.AddPaciente(paciente);
        }

    }
}