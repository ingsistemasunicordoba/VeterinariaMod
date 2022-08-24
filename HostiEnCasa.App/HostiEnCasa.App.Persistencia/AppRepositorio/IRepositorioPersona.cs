using System;
using System.Collections.Generic;
using System.Linq;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> GetAllPersonas();
        Persona AddPersona(Persona Persona);
        Persona UpdatePersona(Persona Persona);
        void DeletePersona(int idPersona);    
        Persona GetPersona(int idPersona);        

    }

}