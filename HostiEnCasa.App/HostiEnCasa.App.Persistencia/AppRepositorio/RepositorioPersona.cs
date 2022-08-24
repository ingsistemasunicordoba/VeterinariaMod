using System.Collections.Generic;
using System.Linq;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia
{

    public class RepositorioPersona : IRepositorioPersona
    {
        /// <summary>
        /// Referencia al contexto de Persona
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }


        Persona IRepositorioPersona.AddPersona(Persona Persona)
        {
            var PersonaAdicionado = _appContext.Personas.Add(Persona);
            _appContext.SaveChanges();
            return PersonaAdicionado.Entity;

        }

        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var PersonaEncontrado = _appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
            if (PersonaEncontrado == null)
                return;
            _appContext.Personas.Remove(PersonaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas()
        {
            return _appContext.Personas;
        }

        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
            return _appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
        }

        Persona IRepositorioPersona.UpdatePersona(Persona Persona)
        {
            var PersonaEncontrado = _appContext.Personas.FirstOrDefault(p => p.Id == Persona.Id);
            if (PersonaEncontrado != null)
            {
                PersonaEncontrado.Nombre = Persona.Nombre;
                PersonaEncontrado.Apellidos = Persona.Apellidos;
                PersonaEncontrado.NumeroTelefono = Persona.NumeroTelefono;
                PersonaEncontrado.Genero = Persona.Genero;
                PersonaEncontrado.Discriminator = Persona.Discriminator;
                
                _appContext.SaveChanges();
            }
            return PersonaEncontrado;
        }
        
    }
}