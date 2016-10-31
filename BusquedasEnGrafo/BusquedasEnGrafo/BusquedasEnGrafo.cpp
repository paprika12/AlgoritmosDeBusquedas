// ConsoleApplication5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <iostream>    
#include <string.h>
#include <string>
#include <sstream>
#include <queue>
#include <map>
using namespace std;



const long Infinito = 8888;  //peso inicial de los nodos
const int MAX = 50;   //numero max de vertices que tienen los arrreglos
int salida[MAX], ind = 0;
const int NUM = 6;//Nero de nodos del grafo 
int matrizCostos[MAX][MAX], distancia[MAX], recorridoFinal[MAX], vistos[MAX];

FILE *fin, *fout; //FILE I/O  Escribir y leer un archivo

int inicio, nodoFinal;
string text = "";

typedef struct Arista {
	int p, c, w;
}Arista;

//prototipos
void leerArchivo(const char *);
void escribirArchivo(const char *);
void busquedaAmplitud();
void busquedaProfundidad();
void dijkstra();
void resultado(int);//Dijkstra
void obtenerNodos(int);//Dijkstra
void prim();
void Kruskals();

int main() {

	printf("Nodo de inicio=");
	scanf_s("%d", &inicio);
	printf("Nodo de visita=");
	scanf_s("%d", &nodoFinal);

	//se obtienen los vectores del archivo para formar la matriz
	leerArchivo("vectores.txt");
	//se llama al agoritmo
	dijkstra();

	resultado(nodoFinal);

	escribirArchivo("dijkstra.out");
	prim();
	Kruskals();
	busquedaAmplitud();
	busquedaProfundidad();
	//imprimiendo resultados
	cout << text << endl;
	system("PAUSE");
	return(0);
}

void leerArchivo(const char* nombreTxt) {

	int i, j, x, y;
	float c;

	fopen_s(&fin, nombreTxt, "r"); //abre el archivo

								   //armado de la matriz con 0 e infinitos , 0 cuando es el mismo nodo
	for (i = 1; i <= NUM; i++) {

		for (j = 1; j <= NUM; j++) {

			if (i == j) {
				//si es el mismo nodo de lectura poner 0
				matrizCostos[i][j] = 0;

			}
			else {
				//sino tiende al infinito
				matrizCostos[i][j] = Infinito;
			}
		}
	}
	//remplazar el valor o coste si se encuentra en el archivo
	while (!feof(fin)) {    //feof funcion de file para determinar el fina lde un archivo
							//stream, tipos de datos que leera , variables donde se asignaran
		fscanf_s(fin, "%d %d %f", &x, &y, &c); //leer linea por linea
		matrizCostos[x][y] = c; // c es el coste
	}
	//imprime la matriz de costos
	for (i = 1; i <= NUM; i++) {

		for (j = 1; j <= NUM; j++) {

			printf("%5d ", matrizCostos[i][j]);   //5d para darle formato ala matriz impresa
		}
		printf("\n");
	}

}
void dijkstra() {
	int i, j, k,
		min,
		pos = 0;

	//obtener la primer Columna de costes para el nodo de inicio 
	for (i = 1; i <= NUM; i++) {
		//obtiene la columna del nodo donde inicia
		distancia[i] = matrizCostos[inicio][i];
		//si el nodo es diferente al inicial
		if (i != inicio)
			//y si el coste no es < infinito (por eso infinito es un numero mayor)
			if (distancia[i] < Infinito)
				recorridoFinal[i] = inicio;
	}
	//inicializamos el vector de vistos
	vistos[inicio] = 1;

	//hacer n-1 veces (el numero de adyacencias)
	for (i = 1; i <= NUM - 1; i++) {
		//el minimo coste lo inicializamos con infinito
		min = Infinito;

		for (j = 1; j <= NUM; j++) {
			//si no ah sido visitado
			if (vistos[j] == 0)
				// y si el coste es menor al minimo
				if (distancia[j]<min) {
					//ahora el minimo es este coste
					min = distancia[j];
					//guardamos la posicion
					pos = j;
				}
		}
		//guardamos en la posicion del minimo 
		vistos[pos] = 1;

		for (j = 1; j <= NUM; j++) {
			// si no ah sido visto
			if (vistos[j] == 0)
				//y el coste nuevo es mayor al coste guardado como minimo + el coste del nuevo nodo
				if (distancia[j] > distancia[pos] + matrizCostos[pos][j]) {
					//se guarda la suma del coste anterior mas el nuevo del nuevo nodo
					distancia[j] = distancia[pos] + matrizCostos[pos][j];
					//se guarda la posicion
					recorridoFinal[j] = pos;
				}
		}
	}
}

void resultado(int nodo) {

	int i;

	obtenerNodos(nodo);

	printf("El costo desde el nodo %d al %d = %d\nel recorrido mas corto es -> ", inicio, nodoFinal, distancia[nodoFinal]);

	for (i = 0; i<NUM; i++) {

		if (salida[i]) printf("%d ", salida[i]);
	}
}

void obtenerNodos(int nodo) {
	//recursividad para obtener los nodos finales
	if (recorridoFinal[nodo]) obtenerNodos(recorridoFinal[nodo]);
	//recuperar la salida en el orden correcto
	salida[ind++] = nodo;
}

void escribirArchivo(const char *nombreTxt) {

	int i;

	fopen_s(&fout, nombreTxt, "w");

	fprintf(fout, "El costo del nodo %d al %d es %d\n el recorrido mas corto es -> \n", inicio, nodoFinal, distancia[nodoFinal]);

	for (i = 0; i<NUM; i++) {

		if (salida[i]) fprintf(fout, "%d ", salida[i]);
	}

	fclose(fout);

}

void prim()
{
	int dist[MAX], previous[MAX], selected[MAX] = { 0 };
	int i, c, x;
	int sum = 0, d, m, min;
	int start = 0;
	x = 0;

	for (i = 0; i < NUM; i++)
		dist[i] = Infinito;

	dist[start] = 0;
	selected[start] = 1;

	for (c = 1; c < NUM; c++) {
		for (i = 0; i < NUM; i++) {
			d = matrizCostos[start + 1][i + 1];

			if (!selected[i] && d < dist[i]) {
				dist[i] = d;
				previous[i] = start;
			}
		}

		min = Infinito;
		m = start;

		for (i = 0; i < NUM; i++) {
			if (!selected[i] && dist[i] < min) {
				min = dist[i];
				m = i;
			}
		}

		start = m;
		selected[start] = 1;
	}

	printf("\n Prims \nnodos seleccionados : \n");
	for (i = 0; i < NUM; i++) {
		if (i != x) {
			printf("%d\t%d\n", previous[i] + 1, i + 1);
		}

		sum += dist[i];
	}

	printf("Costo : %d\n", sum);

}


void Kruskals() {
	int i, j, sum = 0;
	int previous[MAX];
	int edgecount = 0;

	Arista e[MAX], t;

	for (i = 0; i < NUM; i++) {
		for (j = i + 1; j < NUM; j++) {
			if (matrizCostos[i + 1][j + 1] != Infinito) {
				e[edgecount].p = i;
				e[edgecount].c = j;
				e[edgecount].w = matrizCostos[i + 1][j + 1];
				edgecount++;
			}
		}
	}

	for (i = 1; i < edgecount; i++) {
		for (j = 0; j < edgecount - i; j++) {
			if (e[j].w > e[j + 1].w) {
				t = e[j];
				e[j] = e[j + 1];
				e[j + 1] = t;
			}
		}
	}

	for (i = 0; i < NUM; i++)
		previous[i] = -1;

	int ec = 0;

	for (i = 0; i < edgecount && ec < NUM - 1; i++) {
		int p, c;
		p = e[i].p;
		c = e[i].c;

		while (previous[p] != -1)
			p = previous[p];

		while (previous[c] != -1)
			c = previous[c];

		if (p != c) {
			printf("%d\t%d\n", e[i].p + 1, e[i].c + 1);

			sum += e[i].w;

			previous[c] = p;
			ec++;
		}

	}

	printf("\n Kruskal\n costo : %d", sum);

}

void busquedaAmplitud() {
	int nodoActual;
	int cerrados[NUM], suce[NUM], nodosSelec[NUM];
	int contCerrado, contAdya, contSelec = 0;
	int aux, i, j, band = 0;
	std::map<int, int> camino;

	//abierto tiene el primer nodo que es el nodo origen
	std::deque<int> abiertos;
	abiertos.push_back(inicio);

	//se guardan para evitar agregar a abiertos y cerrados nodos ya seleccionados
	nodosSelec[contSelec] = inicio;
	contSelec++;

	contCerrado = 0; //contador de cerrados
	while (!abiertos.empty()) {
		//nodo actual sera el primer nodo en el vector de la cola
		nodoActual = abiertos.front();
		abiertos.pop_front();

		if (nodoActual == nodoFinal) {
			//guardar string para imprimir resultados
			int numero,iNodo = nodoFinal;
			string sNodo;
			text += "\n\nAlgoritmo de Busqueda por Amplitud\n\nNodos Abiertos:\n\n";
			while (!abiertos.empty()) {
				
				//convirtiendo entero total a string
				stringstream stream;
				numero = abiertos.front();
				stream << numero;
				sNodo = stream.str();

				text += sNodo + ", ";
				abiertos.pop_front();
			}
			text += "\n\nNodos Cerrados : \n\n";
			
			for (i = 0; i < contCerrado; i++)
			{
				//convirtiendo entero total a string
				stringstream stream;
				numero = cerrados[i];
				stream << numero;
				sNodo = stream.str();

				text += sNodo + ", ";
			}
			//convirtiendo entero nodo final a string
			stringstream stream;
			numero = nodoFinal;
			stream << numero;
			sNodo = stream.str();

			text += sNodo;

			//camino
			text += "\n\nCamino : \n\n";
			
			while (iNodo != inicio) {
				//convirtiendo nodo a string
				stringstream stream;
				numero = camino[iNodo];
				stream << numero;
				sNodo = stream.str() + ", " + sNodo;
				iNodo = camino[numero];
			}
			//convirtiendo entero total a string
			stringstream stream2;
			numero = inicio;
			stream2 << numero;
			text += stream2.str() + ", " +sNodo;
			break;
		}
		else {
			cerrados[contCerrado] = nodoActual;
			contCerrado++;

			//obtener adyacencias
			contAdya = 0;
			for (i = 0; i <= NUM; i++) {
				if (matrizCostos[nodoActual][i] != 0 && matrizCostos[nodoActual][i] != Infinito) {
					suce[contAdya] = i; //guarda el nodo (posicion)
					contAdya++; // arreglo de adyacencias
				}
			}

			
			//inserta sucesion en abiertos si no estuvo antes visitado
			for (i = 0; i < contAdya; i++) {
				for (j = 0; j < contSelec; j++) {
					if (suce[i] == nodosSelec[j])
						band = 1;
				}
				if (band == 1) {
					band = 0;
				}
				else {
					//evitar repeticiones de nodos
					nodosSelec[contSelec] = suce[i];
					contSelec++;
					camino[suce[i]] = nodoActual;
					abiertos.push_back(suce[i]);
				}

			}

		}

	}

}
void busquedaProfundidad() {
	int nodoActual;
	int cerrados[NUM], suce[NUM], nodosSelec[NUM];
	int contCerrado, contAdya, contSelec = 0;
	int aux, i, j, band = 0;
	std::map<int, int> camino;

	//abierto tiene el primer nodo que es el nodo origen
	std::deque<int> abiertos;
	abiertos.push_back(inicio);

	//se guardan para evitar agregar a abiertos y cerrados nodos ya seleccionados
	nodosSelec[contSelec] = inicio;
	contSelec++;

	contCerrado = 0; //contador de cerrados
	while (!abiertos.empty()) {
		//nodo actual sera el primer nodo en el vector de la cola
		nodoActual = abiertos.back();
		abiertos.pop_back();

		if (nodoActual == nodoFinal) {
			int numero,iNodo=nodoFinal;
			string sNodo;
			//guardar string para imprimir resultados
			text += "\n\nAlgoritmo de Busqueda por Profundidad";
			text += "\n\nnodos en abiertos:\n\n";
			while (!abiertos.empty()) {
				nodoActual = abiertos.back();
				abiertos.pop_back();

				//convirtiendo entero total a string
				stringstream stream;
				numero = nodoActual;
				stream << numero;
				sNodo = stream.str();
				text += sNodo + ", ";

			}
			text += "\n\nnodos cerrados : \n\n";

			for (i = 0; i < contCerrado; i++)
			{
				//convirtiendo entero total a string
				stringstream stream;
				numero = cerrados[i];
				stream << numero;
				sNodo = stream.str();

				text += sNodo + ", ";
			}
			//convirtiendo entero total a string
			stringstream stream;
			numero = nodoFinal;
			stream << numero;
			sNodo = stream.str();

			text += sNodo;

			//camino
			text += "\n\nCamino : \n\n";
			while (iNodo != inicio) {
				//convirtiendo entero total a string
				stringstream stream;
				numero = camino[iNodo];
				stream << numero;
				sNodo = stream.str() + ", " + sNodo;
				iNodo = camino[numero];
			}
			//convirtiendo entero total a string
			stringstream stream2;
			numero = inicio;
			stream2 << numero;
			text += stream2.str() + ", " + sNodo;

			break;
		}
		else {
			cerrados[contCerrado] = nodoActual;
			contCerrado++;

			//obtener adyacencias
			contAdya = 0;
			for (i = 0; i <= NUM; i++) {
				if (matrizCostos[nodoActual][i] != 0 && matrizCostos[nodoActual][i] != Infinito) {
					suce[contAdya] = i; //guarda el nodo (posicion)
					contAdya++; // arreglo de adyacencias
				}
			}

			//inserta sucesion en abiertos si no estuvo antes visitado
			for (i = 0; i < contAdya; i++) {
				for (j = 0; j < contSelec; j++) {
					if (suce[i] == nodosSelec[j])
						band = 1;
				}
				if (band == 1) {
					band = 0;
				}
				else {
					//evitar repeticiones de nodos
					nodosSelec[contSelec] = suce[i];
					contSelec++;
					camino[suce[i]] = nodoActual;
					abiertos.push_back(suce[i]);
				}

			}

		}

	}

}
