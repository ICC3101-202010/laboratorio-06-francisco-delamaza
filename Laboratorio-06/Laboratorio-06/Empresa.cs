using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_06
{
    [Serializable]
    class Empresa
    {
        public string nombre;
        public string rut;

        public Empresa(string nombre, string rut)
        {
            this.nombre = nombre;
            this.rut = rut;
        }
    }
}
