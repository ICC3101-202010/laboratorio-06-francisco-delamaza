using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Laboratorio_06
{
    class Program
    {
        static void Main(string[] args)
        {
            bool x = true;
            IFormatter formatter = new BinaryFormatter();
            Console.WriteLine("Bienvenido");
            while (x == true)
            {
                
                Console.WriteLine("Desea utilizar archivo para cargar?(Y/N)");
                string respuesta = Console.ReadLine();
                switch (respuesta)
                {
                    case "Y":
                        Console.Clear();
                        try
                        {
                            Stream streamp = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read);
                            Empresa newemp = (Empresa)formatter.Deserialize(streamp);
                            Console.WriteLine(newemp.nombre);
                            Console.WriteLine(newemp.rut);
                            streamp.Close();
                        }


                        catch (FileNotFoundException e)
                        {

                            Console.WriteLine(e.Message);
                            Thread.Sleep(2000);
                            goto case "N";
                                

                        }

                        break;
                        

                    case "N":

                        Console.Clear();
                        Console.WriteLine("Ingrese nombre de la empresa:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese rut de la empresa");
                        string rut = Console.ReadLine();
                        Persona p1 = new Persona("Juan", "Perez", "20.162.432-4", "Encargado de bloque");
                        Persona p2 = new Persona("Matias", "Eliot", "20.213.234-5", "Encargado de Seccion");
                        Persona p3 = new Persona("Felipe", "toro", "20.166.432-4", "Encargado de Departamento");
                        Persona p4 = new Persona("Francisco", "Rios", "20.146.432-4", "Encargado de Area");
                        List<Persona> personas = new List<Persona>();
                        List<Bloque> bloques = new List<Bloque>();
                        List<Seccion> seccions = new List<Seccion>();
                        List<Departamento> departamentos = new List<Departamento>();
                        List<Area> areas = new List<Area>();
                        List<Division> divisions = new List<Division>();

                        personas.Add(p1);
                        
                        
                        Bloque b1 = new Bloque("bloque1", p1, personas);
                        bloques.Add(b1);
                        Seccion s1 = new Seccion("seccion1", p2, bloques);
                        seccions.Add(s1);
                        Departamento d1 = new Departamento("departamento1", p3, seccions);
                        departamentos.Add(d1);
                        Area a1 = new Area("area1", p4, departamentos);
                        divisions.Add(a1);
                        
                        
                        
                        Empresa emp = new Empresa(nombre, rut,divisions);

                        

                        Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write);
                        formatter.Serialize(stream, emp);
                        stream.Close();
                        Thread.Sleep(1000);

                        break;

                    default:
                        Console.WriteLine("Respuesta no valida");
                        break;




                } 
                    
            

            }

        }
    }
}
