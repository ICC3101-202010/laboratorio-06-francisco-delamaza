using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_06
{
    class Area: Division
    {
        public Persona encargado;
        List<Departamento> departamentos = new List<Departamento>();

        public Area(string nombre,Persona encargado, List<Departamento> departamentos)
        {
            this.nombre = nombre;
            this.encargado = encargado;
            this.departamentos = departamentos;
        }
    }
}
