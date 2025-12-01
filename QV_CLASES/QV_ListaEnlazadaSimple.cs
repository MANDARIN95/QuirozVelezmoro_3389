using QV_Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QV_Clases
{
    public class QV_ListaEnlazadaSimple
    {
        public NodoLista Cabeza;

        public QV_ListaEnlazadaSimple()
        {
            Cabeza = null;
        }

        public void Agregar(QV_Arista a)
        {
            NodoLista nuevo = new NodoLista(a);

            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                NodoLista temp = Cabeza;
                while (temp.Siguiente != null)
                {
                    temp = temp.Siguiente;
                }
                temp.Siguiente = nuevo;
            }
        }
    }

    public class NodoLista
    {
        public QV_Arista Dato;
        public NodoLista Siguiente;

        public NodoLista(QV_Arista a)
        {
            Dato = a;
            Siguiente = null;
        }
    }
}
