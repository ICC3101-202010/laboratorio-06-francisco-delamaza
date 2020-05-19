using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_06
{
    class Bloque: Division
    {
        public Persona encargado;
        List<Persona> personal = new List<Persona>();
        public Bloque(string nombre, Persona encargado, List<Persona> personal)
        {
            this.nombre = nombre;
            this.encargado = encargado;
            this.personal = personal;
        }
    }
}
