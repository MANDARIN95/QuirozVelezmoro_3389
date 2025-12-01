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

            // === 5 VÉRTICES ===
            g.AgregarVertice("A");
            g.AgregarVertice("B");
            g.AgregarVertice("C");
            g.AgregarVertice("D");
            g.AgregarVertice("E");

            // === 6 ARISTAS ===
            g.AgregarArista("A", "B", 2);
            g.AgregarArista("A", "C", 4);
            g.AgregarArista("B", "D", 3);
            g.AgregarArista("C", "D", 1);
            g.AgregarArista("D", "E", 5);
            g.AgregarArista("C", "E", 7);

            // Mostrar matriz
            g.MostrarMatrices();

            Console.WriteLine("\n DIJKSTRA");

            Console.Write("Ingrese origen (A, B, C, D, E): ");
            string origen = Console.ReadLine().ToUpper();

            Console.Write("Ingrese destino (A, B, C, D, E): ");
            string destino = Console.ReadLine().ToUpper();

            g.Dijkstra(origen, destino);

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
