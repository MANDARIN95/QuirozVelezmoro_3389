using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QV_Clases.QV_ListaEnlazadaSimple;

namespace QV_Clases
{
    public class QV_Grafo
    {
        private const int MAX = 10;
        private const int INF = int.MaxValue;

        public QV_Vertice Cabeza;
        private int[,] matrizCostos;

        public QV_Grafo()
        {
            Cabeza = null;
            matrizCostos = new int[MAX, MAX];

            for (int i = 0; i < MAX; i++)
            {
                for (int j = 0; j < MAX; j++)
                {
                    matrizCostos[i, j] = (i == j) ? 0 : INF;
                }
            }
        }

        public QV_Vertice AgregarVertice(string dato)
        {
            QV_Vertice nuevo = new QV_Vertice(dato);

            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                QV_Vertice temp = Cabeza;
                while (temp.siguiente != null)
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = nuevo;
            }

            return nuevo;
        }

        public QV_Vertice BuscarVertice(string dato)
        {
            QV_Vertice temp = Cabeza;
            while (temp != null)
            {
                if (temp.Dato == dato)
                    return temp;
                temp = temp.siguiente;
            }
            return null;
        }

        private int ObtenerIndice(QV_Vertice v)
        {
            int index = 0;
            QV_Vertice temp = Cabeza;

            while (temp != null)
            {
                if (temp == v)
                    return index;

                temp = temp.siguiente;
                index++;
            }

            return -1;
        }


        public void AgregarArista(QV_Vertice origen, QV_Vertice destino, int peso)
        {
            QV_Arista nueva = new QV_Arista(destino, peso);
            origen.ListaAristas.Agregar(nueva);

            int i = ObtenerIndice(origen);
            int j = ObtenerIndice(destino);

            if (i != -1 && j != -1)
            {
                matrizCostos[i, j] = peso;
            }
        }


        public void AgregarArista(string origen, string destino, int peso)
        {
            QV_Vertice vO = BuscarVertice(origen);
            QV_Vertice vD = BuscarVertice(destino);

            if (vO == null || vD == null)
            {
                Console.WriteLine("Error: Uno de los vértices no existe.");
                return;
            }

            AgregarArista(vO, vD, peso);
        }



        private void InicializarDijkstra()
        {
            QV_Vertice v = Cabeza;
            while (v != null)
            {
                v.Visitado = false;
                v.Distancia = INF;
                v.Anterior = null;
                v = v.siguiente;
            }
        }

        private QV_Vertice ObtenerVerticeMenor()
        {
            QV_Vertice temp = Cabeza;
            QV_Vertice menor = null;

            while (temp != null)
            {
                if (!temp.Visitado &&
                   (menor == null || temp.Distancia < menor.Distancia))
                {
                    menor = temp;
                }

                temp = temp.siguiente;
            }

            return menor;
        }



        public void Dijkstra(QV_Vertice inicio)
        {
            InicializarDijkstra();
            inicio.Distancia = 0;

            while (true)
            {
                QV_Vertice actual = ObtenerVerticeMenor();
                if (actual == null)
                    break;


                if (actual.Distancia == INF)
                    break;

                actual.Visitado = true;

                NodoLista nodo = actual.ListaAristas.Cabeza;

                while (nodo != null)
                {
                    QV_Arista arista = nodo.Dato;

                    if (actual.Distancia == INF)
                    {
                        nodo = nodo.Siguiente;
                        continue;
                    }

                    int nuevo = actual.Distancia + arista.Peso;

                    if (nuevo < arista.Destino.Distancia)
                    {
                        arista.Destino.Distancia = nuevo;
                        arista.Destino.Anterior = actual;
                    }

                    nodo = nodo.Siguiente;
                }
            }
        }



        public void Dijkstra(string inicio, string fin)
        {
            QV_Vertice origen = BuscarVertice(inicio);
            QV_Vertice destino = BuscarVertice(fin);

            if (origen == null || destino == null)
            {
                Console.WriteLine("Error: Uno de los vértices no existe.");
                return;
            }

            Dijkstra(origen);

            if (destino.Distancia == INF)
            {
                Console.WriteLine("No existe un camino de " + origen.Dato + " a " + destino.Dato);
                return;
            }

            Console.WriteLine("\nRESULTADO DIJKSTRA:");
            Console.WriteLine("Costo mínimo de " + origen.Dato + " a " + destino.Dato + " = " + destino.Distancia);
            Console.WriteLine("Ruta mínima encontrada:");
            ImprimirRuta(destino);
            Console.WriteLine();
        }


        public void MostrarRuta(QV_Vertice destino)
        {
            if (destino.Distancia == INF)
            {
                Console.WriteLine("NO EXISTE RUTA.");
                return;
            }

            Console.Write("Ruta: ");
            ImprimirRuta(destino);
            Console.WriteLine();
            Console.WriteLine("Costo total: " + destino.Distancia);
        }

        private void ImprimirRuta(QV_Vertice v)
        {
            if (v.Anterior != null)
            {
                ImprimirRuta(v.Anterior);
                Console.Write(" -> ");
            }
            Console.Write(v.Dato);
        }

        public void MostrarRutas()
        {
            QV_Vertice v = Cabeza;
            while (v != null)
            {
                Console.Write("Vertice " + v.Dato + " - Ruta: ");
                ImprimirRuta(v);

                if (v.Distancia == INF)
                {
                    Console.WriteLine(" (Costo: ∞)");
                }
                else
                {
                    Console.WriteLine(" (Costo: " + v.Distancia + ")");
                }

                v = v.siguiente;
            }
        }



        public void MostrarMatrices()
        {
            Console.WriteLine("\nMATRIZ DE COSTOS:");
            ImprimirMatriz(matrizCostos);
        }

        private int ContarVertices()
        {
            int count = 0;
            QV_Vertice v = Cabeza;

            while (v != null)
            {
                count++;
                v = v.siguiente;
            }

            return count;
        }

        private QV_Vertice[] ObtenerVertices()
        {
            int n = ContarVertices();
            QV_Vertice[] lista = new QV_Vertice[n];

            QV_Vertice temp = Cabeza;
            int i = 0;

            while (temp != null)
            {
                lista[i++] = temp;
                temp = temp.siguiente;
            }
            return lista;
        }

        private void ImprimirMatriz(int[,] m)
        {
            int n = ContarVertices();
            QV_Vertice[] vs = ObtenerVertices();
            Console.Write("    ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(vs[i].Dato + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(vs[i].Dato + " | ");

                for (int j = 0; j < n; j++)
                {
                    int val = m[i, j];

                    if (val == INF)
                    {
                        Console.Write("∞\t");
                    }
                    else
                    {
                        Console.Write(val + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
