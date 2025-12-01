using QV_Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QV_Ejecucion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            QV_Grafo g = new QV_Grafo();


            g.AgregarVertice("A");
            g.AgregarVertice("B");
            g.AgregarVertice("C");
            g.AgregarVertice("D");
            g.AgregarVertice("E");
            g.AgregarVertice("F");
            g.AgregarVertice("T");
            g.AgregarVertice("I");


            g.AgregarArista("A", "B", 1);
            g.AgregarArista("A", "D", 1);
            g.AgregarArista("B", "C", 1);
            g.AgregarArista("B", "D", 7);
            g.AgregarArista("B", "F", 6);
            g.AgregarArista("C", "F", 10);
            g.AgregarArista("C", "B", 1);
            g.AgregarArista("D", "E", 2);
            g.AgregarArista("D", "T", 18);
            g.AgregarArista("E", "T", 9);
            g.AgregarArista("F", "T", 2);
            g.AgregarArista("I", "A", 9);
            g.AgregarArista("I", "C", 2);


            g.MostrarMatrices();

            Console.WriteLine("\n DIJKSTRA");
            Console.Write("Ingrese origen: ");
            string origen = Console.ReadLine().ToUpper();
            Console.Write("Ingrese destino: ");
            string destino = Console.ReadLine().ToUpper();


            g.Dijkstra(origen, destino);

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
