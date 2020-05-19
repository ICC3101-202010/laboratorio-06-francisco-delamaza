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
                        Empresa emp = new Empresa(nombre, rut);

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
