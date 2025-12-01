using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QV_Clases
{
    public class QV_Vertice
    {
        public string Dato;
        public QV_ListaEnlazadaSimple ListaAristas;

        public bool Visitado;
        public int Distancia;
        public QV_Vertice Anterior;

        public QV_Vertice siguiente;

        public QV_Vertice(string dato)
        {
            Dato = dato;
            ListaAristas = new QV_ListaEnlazadaSimple();

            Visitado = false;
            Distancia = int.MaxValue;
            Anterior = null;
        }
    }
}

