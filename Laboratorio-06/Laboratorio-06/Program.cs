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
                            Console.WriteLine();
                            Console.WriteLine(newemp.rut);
                            Console.WriteLine();
                            foreach (Area area in newemp.divisions)
                            {
                                Console.WriteLine();
                                Console.WriteLine(area.nombre +" "+"Encargado:"+" "+ area.encargado.nombre +" "+ area.encargado.apellido);
                                
                                foreach (Departamento departamento in area.departamentos)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(departamento.nombre + " " + "Encargado:" + " " + departamento.encargado.nombre + " " + departamento.encargado.apellido);
                                    foreach (Seccion seccion in departamento.seccions)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(seccion.nombre + " " + "Encargado:" + " " + seccion.encargado.nombre + " " + seccion.encargado.apellido);
                                        foreach (Bloque bloque in seccion.bloques)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(bloque.nombre);
                                            Console.WriteLine("Personal:");
                                            foreach (Persona persona in bloque.personal)
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine(persona.nombre);
                                                Console.WriteLine(persona.apellido);
                                                Console.WriteLine(persona.rut);                                              
                                                Console.WriteLine(persona.cargo);

                                            }
                                        }
                                    }
                                }
                            }
                            streamp.Close();
                        }


                        catch (FileNotFoundException e)
                        {

                            Console.WriteLine(e.Message);
                            Thread.Sleep(2000);
                            goto case "N";
                                

                        }
                        Console.WriteLine("Archivo cargado");
                        Console.ReadKey();
                        break;
                        

                    case "N":

                        Console.Clear();
                        Console.WriteLine("Ingrese nombre de la empresa:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese rut de la empresa");
                        string rut = Console.ReadLine();
                        Persona p1 = new Persona("Juan", "Perez", "20.162.432-4", "Personal");
                        Persona p5 = new Persona("Rodrigo", "Diaz", "19.156.422-4", "Personal");
                        Persona p6 = new Persona("Albert", "Sans", "19.326.443-4", "Personal");
                        Persona p7 = new Persona("Manue", "Guid", "19.156.422-4", "Personal");
                   
                        Persona p2 = new Persona("Matias", "Eliot", "20.213.234-5", "Encargado de Seccion");
                        Persona p3 = new Persona("Felipe", "toro", "20.166.432-4", "Encargado de Departamento");
                        Persona p4 = new Persona("Francisco", "Rios", "20.146.432-4", "Encargado de Area");
                        List<Persona> personas = new List<Persona>();
                        List<Persona> personas2 = new List<Persona>();

                        List<Bloque> bloques = new List<Bloque>();
                        List<Seccion> seccions = new List<Seccion>();
                        List<Departamento> departamentos = new List<Departamento>();
                        List<Area> areas = new List<Area>();
                        List<Division> divisions = new List<Division>();

                        personas.Add(p1);
                        personas.Add(p5);
                        personas2.Add(p6);
                        personas2.Add(p7);



                        Bloque b1 = new Bloque("bloque1", personas);
                        Bloque b2 = new Bloque("bloque2", personas2);
                        bloques.Add(b1);
                        bloques.Add(b2);

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
                        Console.WriteLine("Archivo creado");
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
