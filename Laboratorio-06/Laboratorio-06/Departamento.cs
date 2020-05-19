using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_06
{
    class Departamento: Division
    {
        public Persona encargado;
        List<Seccion> seccions = new List<Seccion>();
        
        public Departamento(string nombre, Persona encargado, List<Seccion> seccions)
        {
            this.seccions = seccions;
            this.nombre = nombre;
            this.encargado = encargado;
        }
    }
}
