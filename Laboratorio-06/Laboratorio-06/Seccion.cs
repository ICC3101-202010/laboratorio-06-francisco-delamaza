using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_06
{
    class Seccion:Division
    {
        public Persona encargado;
        List<Bloque> bloques = new List<Bloque>();
        public Seccion(string nombre,Persona encargado, List<Bloque> bloques)
        {
            this.nombre = nombre;
            this.encargado = encargado;
            this.bloques = bloques;
        }
    }
}
