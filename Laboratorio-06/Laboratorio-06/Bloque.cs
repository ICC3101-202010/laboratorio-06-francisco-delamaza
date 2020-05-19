using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_06
{
    [Serializable]
    class Bloque: Division
    {
        
        public List<Persona> personal = new List<Persona>();
        public Bloque(string nombre, List<Persona> personal)
        {
            this.nombre = nombre;
            
            this.personal = personal;
        }
    }
}
