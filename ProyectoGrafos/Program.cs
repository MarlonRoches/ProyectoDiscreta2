using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrafos
{
    class Program
    {
        static void Main(string[] args)
        {
            var ReaderG1 = new StreamReader("C:\\Users\\roche\\Desktop\\ProyectoDiscreta2\\Bateria De Pruebas\\Star.txt");
            var ReaderG2 = new StreamReader("C:\\Users\\roche\\Desktop\\ProyectoDiscreta2\\Bateria De Pruebas\\Pentagono.txt");
            var Grafo1 = Clasificar(ReaderG1.ReadToEnd().Split('-'), new Dictionary<string, string>());
            var Grafo2 = Clasificar(ReaderG2.ReadToEnd().Split('-'), new Dictionary<string, string>());

            Console.ReadLine();

            Dictionary<string, string> Clasificar(string[] array, Dictionary<string, string> Diccionario)
            {
                foreach (var item in array)
                {
                    var aux = item.Split(',');
                    if (item.Split(',').Length!=1)
                    {
                        if (!Diccionario.ContainsKey(aux[0]))
                        {
                            Diccionario.Add(aux[0],aux[1]);
                        }
                        else
                        {
                            Diccionario[aux[0]]+=$",{aux[1]}";
                        }
                    }
                }

                return Diccionario;
            }
        }
    }
}
