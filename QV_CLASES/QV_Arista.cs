using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QV_Clases
{
    public class QV_Arista
    {
        public QV_Vertice Destino;
        public int Peso;
        public QV_Arista Siguiente;

        public QV_Arista(QV_Vertice destino, int peso)
        {
            Destino = destino;
            Peso = peso;
            Siguiente = null;
        }
    }
}
