using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmosdebusquedaui
{

    class Busquedas
    {
        //propiedades
        const int MAX = 192;
        const long Infinito = 888888;

        //propiedades con sus metodos de lectura y escritura

        //camino final para obtenerlo en el formulario y mostrarlo en el mapa
        IList<string> lcamino = new List<string>();
        public IList<string> Camino
        {
            get { return lcamino; }
        }

        //Numero de nodos
        int NUM = 0;
        public int Num
        {
            get { return NUM; }
            set { NUM = value; }
        }

        //concatena el resultado
        protected string textResult = "";
        public string TextResult
        {
            get { return textResult; }
            set { textResult = value; }
        }

        //nodo origen
        protected int nodoInicio;
        public int NodoInicio
        {
            get { return nodoInicio; }
            set { nodoInicio = value; }
        }

        //nodo destino
        protected int nodoFinal;
        public int NodoFinal
        {
            get { return nodoFinal; }
            set { nodoFinal = value; }
        }

        //cual programa estamos usando
        // 1= ciudades mapa
        // 2= Robot 
        protected int programa = 1;
        public int Programa
        {
            get { return programa; }
            set { programa = value; }
        }


        //________________________________________Busqueda por amplitud ________________________________________________________-
        public void busquedaAmplitud()
        {
            int nodoActual;
            List<int> cerrados = new List<int>();
            List<int> nodosSeleccionados = new List<int>(); 
                       
            Dictionary<int, int> camino = new Dictionary<int, int>();
            List<int> abiertos = new List<int>();
            

            //creando instancias de grafos
            GrafoCiudades ciudades = new GrafoCiudades();
            GrafoRobot robot = new GrafoRobot();


            //abierto tiene el primer nodo que es el nodo origen
            abiertos.Add(nodoInicio);


            //este arreglo va guardando todos los nodos que se han ido agregando a abiertos
            //evita que se agreguen repetidos
            // se agrega el nodo origen
            nodosSeleccionados.Add(nodoInicio);
            

            //mientras haya nodos en abiertos haz el ciclo
            while (abiertos.Count() != 0)
            {
                //nodo actual sera ahora el primer nodo en el vector de la cola
                //es una cola first in first out
                nodoActual = abiertos.First();
                abiertos.Remove(abiertos.First());

                //--------------------si encontro el destino obten resultados --------------------------
                if (nodoActual == nodoFinal)
                {

                    textResult += "Algoritmo de Busqueda por Amplitud";
                   
                    //obtener cerrados y camino para imprimir
                    obtenerResultados(nodoActual, abiertos, cerrados, camino);
                    break;
                }
                //--------------------si no ah encontrado el destino sigue buscando --------------------------
                else
                {
                    //el nodo abierto ahora pasa a cerrado
                    cerrados.Add(nodoActual);
                   
                    //agregando adyacencias a abiertos
                    switch (programa)
                    {
                        case 1:
                            ciudades.GenerarSucesores(nodoActual, ref abiertos,ref nodosSeleccionados,ref camino);
                            break;
                        case 2:
                            robot.GenerarSucesores(nodoActual, ref abiertos, ref nodosSeleccionados, ref camino);
                            break;
                    }
                }
            }
        }

        //________________________________________Busqueda por profundidad ________________________________________________________-
        public void busquedaProfundidad()
        {
            int nodoActual;
            List<int> cerrados = new List<int>();
            List<int> nodosSeleccionados = new List<int>();

            Dictionary<int, int> camino = new Dictionary<int, int>();
            List<int> abiertos = new List<int>();


            //creando instancias de grafos
            GrafoCiudades ciudades = new GrafoCiudades();
            GrafoRobot robot = new GrafoRobot();


            //abierto tiene el primer nodo que es el nodo origen
            abiertos.Add(nodoInicio);


            //este arreglo va guardando todos los nodos que se han ido agregando a abiertos
            //evita que se agreguen repetidos
            // se agrega el nodo origen
            nodosSeleccionados.Add(nodoInicio);


            //mientras haya nodos en abiertos haz el ciclo
            while (abiertos.Count() != 0)
            {
                //nodo actual sera ahora el primer nodo en el vector de la cola
                //es una cola first in first out
                nodoActual = abiertos.Last();
                abiertos.Remove(abiertos.Last());

                //--------------------si encontro el destino obten resultados --------------------------
                if (nodoActual == nodoFinal)
                {

                    textResult += "Algoritmo de Busqueda por Profundidad";

                    //obtener cerrados y camino para imprimir
                    obtenerResultados(nodoActual, abiertos, cerrados, camino);
                    break;
                }
                //--------------------si no ah encontrado el destino sigue buscando --------------------------
                else
                {
                    //el nodo abierto ahora pasa a cerrado
                    cerrados.Add(nodoActual);

                    switch (programa)
                    {
                        case 1:
                            ciudades.GenerarSucesores(nodoActual, ref abiertos, ref nodosSeleccionados, ref camino);
                            break;
                        case 2:
                            robot.GenerarSucesores(nodoActual, ref abiertos, ref nodosSeleccionados, ref camino);
                            break;
                    }
                }
            }
        }
        //_______________________________________ Imprimir resultados para profundidad y amplitud ________________________________

        public void obtenerResultados(int nodoActual, List<int> abiertos, List<int> cerrados, Dictionary<int, int> camino)
        {
            int iNodoInicial = nodoFinal;
            string sNodoFinal = "";
            string sCamino = "";
            GrafoCiudades ciudades = new GrafoCiudades();
            GrafoRobot robot = new GrafoRobot();
            lcamino.Clear();

            //recorriendo la lista de abiertos
            textResult += "\r\n\r\nnodos en abiertos:\r\n\r\n";
            foreach (int nodoA in abiertos)
            {
                nodoActual = nodoA;
                switch (programa)
                {
                    case 1:
                        textResult += ciudades.getCiudad(nodoActual) + ", ";
                        break;
                    case 2:
                        textResult += nodoA.ToString() + ", ";
                        break;
                }

            }
            textResult += "\r\n\r\nnodos en cerrados : \r\n\r\n";
            //recorriendo la lista de cerrados
            foreach (int cerrado in cerrados)
            {
                switch (programa)
                {
                    case 1:
                        textResult += ciudades.getCiudad(cerrado) + ", ";
                        break;
                    case 2:
                        textResult += cerrado.ToString() + ", ";
                        break;
                }

            }
            //guardando el valor del nodo final
            switch (programa)
            {
                case 1:
                    sNodoFinal = ciudades.getCiudad(nodoFinal);
                    break;
                case 2:
                    sNodoFinal = nodoFinal.ToString();
                    break;
            }
            textResult += sNodoFinal;


            //camino
            textResult += "\r\n\r\nCamino : \r\n\r\n";
            sCamino = sNodoFinal;
            lcamino.Add(sCamino);
            //recorriendo el diccionario para obtener el camino destino-origen
            while (iNodoInicial != nodoInicio)
            {
                switch (programa)
                {
                    case 1:
                        sCamino = ciudades.getCiudad(camino[iNodoInicial]) + ", " + sCamino;
                        lcamino.Add(ciudades.getCiudad(camino[iNodoInicial])); //agregando a la lista para la UI 
                        break;
                    case 2:
                        sCamino = camino[iNodoInicial].ToString() + ", " + sCamino;
                        lcamino.Add(camino[iNodoInicial].ToString());    
                        break;
                }
                iNodoInicial = camino[iNodoInicial];
            }

            textResult += sCamino;

        }
    }
    
}


