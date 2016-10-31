using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace algoritmosdebusquedaui
{

    public partial class Grafos : Form
    {
        //objeto de la clase busqueda
        Busquedas busqueda = new Busquedas();
        GrafoRobot robot = new GrafoRobot(); //se instancia para mostrar el grid
        int programa = 1;
        int NUM = 0;
        public Grafos()
        {

            InitializeComponent();

            //seteando configuraciones
            programa = Convert.ToInt16(ConfigurationManager.AppSettings["programa"]);
            NUM = Convert.ToInt16(ConfigurationManager.AppSettings["num"]);

            //seteando valor en la clase busqueda          
            busqueda.Programa = programa;
            busqueda.Num = NUM;

            if (programa == 1)
            {
                //ocultando grid 
                dg_robot.Visible = false;

                //creando instancia de clase GrafoCiudades
                GrafoCiudades ciudades = new GrafoCiudades();

                //inicializando el mapa en Madrid con zoom
                gm_ciudades.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                gm_ciudades.SetPositionByKeywords("Madrid,España");

                //llenando drop downs
                //ciudades de origen
                ArrayList ciudadList = new ArrayList();
                ciudadList.AddRange(ciudades.getCiudades());
                cb_origen.DataSource = ciudadList;

                //ciudades de destino
                ArrayList destinoList = new ArrayList();
                destinoList.AddRange(ciudades.getCiudades());
                cb_destino.DataSource = destinoList;


            }
            else if (programa == 2)
            {
                //ocultar mapa
                gm_ciudades.Visible = false;
                //llena el gridpanel la primera vez
                llenarGrafo();

                //llenando drop downs
                //nodos de origen
                ArrayList origen = new ArrayList();
                origen.Add("Selecciona");
                for (int i = 1;i<= NUM; i++)
                {
                    origen.Add(i);
                }
                cb_origen.DataSource = origen;

                //nodos de destino
                ArrayList destino = new ArrayList();
                destino.Add("Selecciona");
                for (int i = 1; i <= NUM; i++)
                {
                    destino.Add(i);
                }
                cb_destino.DataSource = destino;
            }

            //algoritmos de busqueda
            ArrayList algoritmos = new ArrayList();
            algoritmos.Add("Busqueda Profundidad");
            algoritmos.Add("Busqueda Amplitud");
            cb_algoritmo.DataSource = algoritmos;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            //obteniendo selecciones
            busqueda.NodoInicio = cb_origen.SelectedIndex;
            busqueda.NodoFinal = cb_destino.SelectedIndex;
            int algoritmo = cb_algoritmo.SelectedIndex;


            if (busqueda.NodoInicio != 0 && busqueda.NodoFinal != 0 )
            {
                busqueda.TextResult = "";
                if (algoritmo == 1)
                {
                    busqueda.busquedaAmplitud();
                }
                else if (algoritmo == 0)
                {
                    busqueda.busquedaProfundidad();
                }
                
            }

            //mostrar resultados en la UI
            IList<string> caminos = new List<string>();
            caminos = busqueda.Camino;
            switch (programa)
            {
                case 1:
                    llenarMapa(caminos);
                    break;
                case 2:
                    llenarGrid(caminos);
                    break;
            }
            txt_resultados.Text = busqueda.TextResult;
           
        }
        public void llenarMapa(IList<string> caminos) {
            caminos.Reverse(); //la clase lo mando Destino-Origen

            //GMap.Net
            //limpiar marcas previas en el mapa
            gm_ciudades.Overlays.Clear();

            //instancia para marcas de globo
            GMarkerGoogle m;

            //instancia para recolectar marcas
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            markersOverlay.Clear();

            //instancia para recolectar rutas
            GMapOverlay routesOverlay = new GMapOverlay("routes");
            routesOverlay.Clear();

            //lista para guardar puntos de ciudades
            List<PointLatLng> points = new List<PointLatLng>();

            //recorrer el camino
            foreach (string camino in caminos)
            {
                //posicionarse en el mapa
                gm_ciudades.SetPositionByKeywords(camino);
                //obtener tipo y la marca
                m = new GMarkerGoogle(gm_ciudades.Position, GMarkerGoogleType.purple_dot);
                //ponerle un texto
                m.ToolTipText = camino;
                //unir todos en marcas
                markersOverlay.Markers.Add(m);


                //agregar una ciudad a la lista para unir los puntos
                points.Add(new PointLatLng(gm_ciudades.Position.Lat, gm_ciudades.Position.Lng));
            }
            //mostrar el paquete de marcas de globo
            gm_ciudades.Overlays.Add(markersOverlay);

            //instancia para empaquetar ruta agregando la lista
            GMapRoute route = new GMapRoute(points, "mypolygon");
            //unir los puntos
            route.Stroke = new Pen(Color.Purple, 1);
            //empaquetarlo
            routesOverlay.Routes.Add(route);
            //mostrarlo en el mapa
            gm_ciudades.Overlays.Add(routesOverlay);
            gm_ciudades.Refresh();
        }
        
        public void llenarGrafo()
        {//genera el grafo en el grid por primera ves
            int i, j;
            int[,] grafo = robot.getGrafo();
            DataTable dt = new DataTable();
            // crea columnas
            for ( i = 0; i < 14; i++)
            {
                dt.Columns.Add();
            }

            for ( j = 0; j < 6; j++)
            {
                //agrega filas
                DataRow row = dt.NewRow();

                // recorrer para agregarle el valor
                for ( i = 0; i < 14; i++)
                {
                    row[i] = grafo[j, i].ToString();
                }

                //una ves lista la fila se aagrega a la tabla
                dt.Rows.Add(row);
            }
            //se asigna al grid
            dg_robot.DataSource=dt;


            //dando formato
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 14; j++)
                {
                    if (dg_robot.Rows[i].Cells[j].Value.ToString() == "0")
                    {
                        //colorea de negro las celdas que tienen un cero como valor
                        dg_robot.Rows[i].Cells[j].Style.BackColor = Color.Black;

                    }
                    //le pone tamaño a las celdas       
                    dg_robot.Columns[j].Width = 30;
                }
            }
        }

        public void llenarGrid(IList<string> caminos)
        {
            int[,] grafo = robot.getGrafo();
            
            for (int i = 0; i < 6; i++)
            {

                for (int j = 0; j < 14; j++)
                {   //si la lista camino contiene ese nodo colorealo sino limpialo
                    if (caminos.Contains(dg_robot.Rows[i].Cells[j].Value.ToString()))
                        dg_robot.Rows[i].Cells[j].Style.BackColor = Color.Violet;
                    else
                        dg_robot.Rows[i].Cells[j].Style.BackColor = Color.White;
                    //si es 0 ponlo negro
                    if (dg_robot.Rows[i].Cells[j].Value.ToString() == "0")
                        dg_robot.Rows[i].Cells[j].Style.BackColor = Color.Black;

                }
            }
        }
    }
}
