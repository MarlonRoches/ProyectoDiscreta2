using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProyectoGrafos
{
  
    
    public struct sDatos
    {
        public int Orden { get; set; }
        public int Id { get; set; }
        public int Numero { get; set; }
        public char Letra { get; set; }
        public bool Buscar { get; set; }
        public bool Encontrado { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //raiz
                var GrafoI1 = new Dictionary<string, string>();
                var GrafoI2 = new Dictionary<string, string>();

            string Grado1 = "";
            string Grado2 = "";

            bool menu = true;
            while (menu)
            {
                try
                {
                    Console.WriteLine("Coloque sobre la consola el primer grafo");

                    //leemos ruta del primer grafo
                    string Ruta_Primer_Grafo = Console.ReadLine();
                    //Accedemos al archivo y lo leemos completo
                    var File1 = new StreamReader(Ruta_Primer_Grafo);
                    //
                    var aux1 = File1.ReadLine();
                    var PrimerGrafoEnSetring = string.Empty;
                    while (aux1 != null)
                    {
                        PrimerGrafoEnSetring += aux1 + "-";
                        aux1 = File1.ReadLine();
                    }
                    File1.Close();
                    Console.Clear();

                    Console.WriteLine("Coloque sobre la consola el segundo grafo");
                    //leemos ruta del primer grafo
                    var ruta2 = Console.ReadLine();
                    //Accedemos al archivo y lo leemos completo
                    var File2 = new StreamReader(ruta2);
                    var aux2 = File2.ReadLine();
                    var SegundoGrafoEnSetring = string.Empty;
                    while (aux2 != null)
                    {
                        SegundoGrafoEnSetring += aux2 + "-";
                        aux2 = File2.ReadLine();
                    }

                    File2.Close();
                    var Nombre1 = Path.GetFileName(Ruta_Primer_Grafo);
                    var Nombre2 = Path.GetFileName(ruta2);
                    Console.Clear();
                    //separar por saltos de linea
                    //Le enviamos un diccionario Vacio
                    PrimerGrafoEnSetring = PrimerGrafoEnSetring.ToUpper();
                    SegundoGrafoEnSetring = SegundoGrafoEnSetring.ToUpper();
                    GrafoI1 = Clasificar(PrimerGrafoEnSetring.Substring(0, PrimerGrafoEnSetring.Length - 1).Split('-'), new Dictionary<string, string>());
                    GrafoI2 = Clasificar(SegundoGrafoEnSetring.Substring(0, SegundoGrafoEnSetring.Length - 1).Split('-'), new Dictionary<string, string>());
                    //si tiene los mismo vertices
                    Grado1 = PrimerGrafoEnSetring.Substring(0, PrimerGrafoEnSetring.Length - 1).Split('-')[0];
                    Grado2 = SegundoGrafoEnSetring.Substring(0, SegundoGrafoEnSetring.Length - 1).Split('-')[0];
                    //var Tiene_MismasAristas = MismasAristas(Grafo1, Grafo2);
                    var Tiene_MismosVertices = MismosVertices(Grado1, Grado2);
                    var TieneMismoGrado = MismoGradoYAristas(GrafoI1, GrafoI2);

                    if (Tiene_MismosVertices && TieneMismoGrado)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Son isomorfos");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{Nombre1} VS. {Nombre2}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;

                        //si son isomorfos   

                        FuncionDeIsomorfismo(GrafoI1, GrafoI2);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("No son isomorfos");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine("-------------------------------------------------");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Desea Continuar? \n No = N \n Si = S");
                    Console.ForegroundColor = ConsoleColor.White;
                    var romperciclo = Console.ReadLine();
                    if (romperciclo.ToLower() == "n")
                    {
                        break;
                    }
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Error, Intente De Nuevo");
                }
            }

            void FuncionDeIsomorfismo(Dictionary<string, string> Grafo1, Dictionary<string, string> Grafo2)
            {


                
                    bool monitor = true;
                    var ArrayOrdenado1 = new KeyValuePair<string, string[]>[Grafo1.Count];
                    var ArrayOrdenado2 = new KeyValuePair<string, string[]>[Grafo1.Count];
                    //LinQ
                    var Grafo1Ordenado = from Nodo in Grafo1
                                         orderby Nodo.Value.Split(',').Length
                                         select Nodo;
                    //LinQ
                    var Grafo2Ordenado = from Nodo in Grafo2
                                         orderby Nodo.Value.Split(',').Length
                                         select Nodo;

                    int contador = 0;
                    foreach (var item in Grafo1Ordenado)
                    {
                        ArrayOrdenado1[contador] = new KeyValuePair<string, string[]>(item.Key, item.Value.Split(','));
                        contador++;
                    }
                    contador = 0;
                    foreach (var item in Grafo2Ordenado)
                    {
                        ArrayOrdenado2[contador] = new KeyValuePair<string, string[]>(item.Key, item.Value.Split(','));
                        contador++;
                    }

                    Console.WriteLine("Funciones De Isomorfismo");
                
                for (int i = 0; i < ArrayOrdenado1.Length; i++)
                {
                    for (int j = 0; j < ArrayOrdenado2.Length; j++)
                    {
                        if (ArrayOrdenado2[j].Value != null)
                        {

                            if (ArrayOrdenado1[i].Value.Length == ArrayOrdenado2[j].Value.Length)
                            {
                                Console.Write("El Vertice del Grafo1 no: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(ArrayOrdenado1[i].Key);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("es equivalente al vertice no:");

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(ArrayOrdenado2[j].Key);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("del Grafo2.");
                                Console.WriteLine("----------------------------------------------------------------");
                                ArrayOrdenado2[j] = new KeyValuePair<string, string[]>();
                                break;
                            }
                        }
                    }
                }
            }
           
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
            bool MismoGradoYAristas(Dictionary<string, string> Grafo1, Dictionary<string, string> Grafo2)
            {
                bool monitor = true;
                var ArrayOrdenado1 = new KeyValuePair<string, int>[Grafo1.Count];
                var ArrayOrdenado2 = new KeyValuePair<string, int>[Grafo1.Count];
                
                //LinQ
                var Grafo1Ordenado = from Nodo in Grafo1
                                     orderby Nodo.Value.Split(',').Length
                                     select Nodo;

                //LinQ
                var Grafo2Ordenado = from Nodo in Grafo2
                                     orderby Nodo.Value.Split(',').Length
                                     select Nodo;

                int contador = 0;
                foreach (var item in Grafo1Ordenado)
                {
                    ArrayOrdenado1[contador] = new KeyValuePair<string, int>(item.Key, item.Value.Split(',').Length);
                    contador++;
                }
                contador = 0;
                foreach (var item in Grafo2Ordenado)
                {
                    ArrayOrdenado2[contador] = new KeyValuePair<string, int>(item.Key, item.Value.Split(',').Length);
                    contador++;
                }
                for (int i = 0; i < Grafo1.Count; i++)
                {
                    if (ArrayOrdenado1[i].Value != ArrayOrdenado2[i].Value)
                    {
                        return false;
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
                            if (Diccionario.ContainsKey(aux[1]))
                            {
                                //agrega el nuevo indice con la aarista correspondiente
                            Diccionario[aux[1]]+=$",{aux[0]}";
                            }
                            else
                            {

                                //Crea el que no esta
                            Diccionario.Add(aux[1],aux[0]);
                            }
                        }
                        else
                        {
                            //Si La Tiene y agregga
                                
                            Diccionario[aux[0]]+=$",{aux[1]}";
                            if (!Diccionario.ContainsKey(aux[1]))
                            {
                            //Crea si no existe ,a pareja
                                Diccionario.Add(aux[1], aux[0]);
                            }
                            else
                            {
                            //Si existe, agrega la pareja correpondiente
                                Diccionario[aux[1]] += $",{aux[0]}";

                            }

                        }
                    }
                }

                return Diccionario;
            }
            bool[,] LlenarMatriz(Dictionary<string, string> keyValuePair)
            {
                var Matriz = new bool[int.Parse(Grado1), int.Parse(Grado2)];
                foreach (var Y in keyValuePair)
                {
                    foreach (var X in Y.Value.Split(','))
                    {
                        var PosY = int.Parse(Y.Key);
                        var PosX = int.Parse(X);
                        Matriz[PosY,PosX]= true;
                        Matriz[PosY,PosX]= true;
                    }
                }

                return Matriz;
            }

        }
    }
}
