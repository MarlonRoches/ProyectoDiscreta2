using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoGrafos
{

    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Coloque sobre la consola el primer grafo");

                //leemos ruta del primer grafo
                string ruta = Console.ReadLine();

                //Accedemos al archivo y lo leemos completo
                var File1 = new StreamReader(ruta);
                //
                var aux1 = File1.ReadLine();
                var stringgrafo = string.Empty;
                while (aux1!=null)
                {
                    stringgrafo += aux1 +"-";
                    aux1 = File1.ReadLine();
                }
                File1.Close();
                Console.Clear();

                Console.WriteLine("Coloque sobre la consola el segundo grafo");
                //leemos ruta del primer grafo
                ruta = Console.ReadLine();
                //Accedemos al archivo y lo leemos completo
                var File2 = new StreamReader(ruta);
                var aux2 = File2.ReadLine();
                var stringgraf2 = string.Empty;
                while (aux2 != null)
                {
                    stringgraf2 += aux2 + "-";
                    aux2 = File2.ReadLine();
                }
                
                File2.Close();
                Console.Clear();
                //separar por saltos de linea
                //Le enviamos un diccionario Vacio
               
                var Grafo1 = Clasificar(stringgrafo.Substring(0, stringgrafo.Length - 1).Split('-'), new Dictionary<string, string>());
                var Grafo2 = Clasificar(stringgraf2.Substring(0, stringgraf2.Length - 1).Split('-'), new Dictionary<string, string>());
                //si tiene los mismo vertices
                var monitor1 = MismosVertices(stringgrafo.Substring(0, stringgrafo.Length - 1).Split('-')[0], stringgraf2.Substring(0, stringgraf2.Length - 1).Split('-')[0]);
                var monitor2 = MismasAristas(Grafo1, Grafo2);
                var monitor3= MismoGrado(Grafo1, Grafo2);

                if (monitor1 &&  monitor2&& monitor3)
                {
                    //si son isomorfos
                }
                else
                {
                    //no lo son
                }

                Console.WriteLine("Desea Continuar? \n No = N \n Si = S");
                var romperciclo = Console.ReadLine();
                if (true)
                {

                }

            }
            Console.ReadLine();

            bool MismosVertices(string VerticesGRafo1, string VerticesGRafo2)
            {
                if (int.Parse(VerticesGRafo1 )!= int.Parse(VerticesGRafo2))
                {

                return false;
                }
                else
                
{
                    return true;
                }
            }

            bool MismasAristas(Dictionary<string, string> Grafo1, Dictionary<string, string> Grafo2)
            {
                bool monitor = true;
                //comparamos Vactores
                
                foreach (var item in Grafo1)
                {
                    var comparador1 = Grafo1[item.Key].Split(',').Length;
                    var comparador2 = Grafo2[item.Key].Split(',').Length;
                    if ( comparador1 != comparador2)
                    {
                        monitor = false;
                        break;
                    }
                }
                return monitor;
            }


            bool MismoGrado(Dictionary<string, string> Grafo1, Dictionary<string, string> Grafo2)
            {
                bool monitor = true;
                foreach (var item in Grafo1)
                {
                    //comparamos longitud 
                    if (Grafo1[item.Key].Split(',').Length != Grafo1[item.Key].Split(',').Length)
                    {
                        monitor = false;
                        break;
                    }
                }
                return monitor;
            }

            Dictionary<string, string> Clasificar(string[] array, Dictionary<string, string> Diccionario)
            {
                //para cada arreglo (valor en el array extraido del txt)
                foreach (var item in array)
                {
                                //Separacion por ","
                    var aux = item.Split(',');
                    if (item.Split(',').Length != 1)
                    {
                        //si el diccionario no contiene el vertice al cual agregar 
                        if (!Diccionario.ContainsKey(aux[0]))
                        {
                            //agrega el nuevo indice con la aarista correspondiente
                            Diccionario.Add(aux[0],aux[1]);
                        }
                        else
                        {
                            //agrega la arista al vertice correspondiente
                            Diccionario[aux[0]]+=$",{aux[1]}";
                        }
                    }
                }

                return Diccionario;
            }
        }
    }
}
