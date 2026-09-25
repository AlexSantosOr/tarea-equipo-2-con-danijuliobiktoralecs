using System;

namespace MatrizCerosApp
{
    /// <summary>
    /// Clase de lógica y modelo que encapsula la matriz bidimensional de 5x5
    /// y el cálculo de ceros por renglón, aplicando principios de POO y separación de capas.
    /// </summary>
    public class MatrizProcesador
    {
        private const int Dimension = 5;
        private double[,] matriz;

        public MatrizProcesador()
        {
            matriz = new double[Dimension, Dimension];
            CargarMatrizPredefinida();
        }

        public MatrizProcesador(double[,] matrizExterna)
        {
            if (matrizExterna == null || matrizExterna.GetLength(0) != Dimension || matrizExterna.GetLength(1) != Dimension)
            {
                throw new ArgumentException($"La matriz debe ser de {Dimension}x{Dimension}.");
            }
            matriz = (double[,])matrizExterna.Clone();
        }

        /// <summary>
        /// Carga la matriz predefinida del ejercicio:
        /// Fila 0: 0, 2, 5, 7, 6
        /// Fila 1: 0, 0, 0, 3, 8
        /// Fila 2: 2, 9, 6, 3, 4
        /// Fila 3: 1, 5, 6, 1, 4
        /// Fila 4: 0, 9, 2, 5, 0
        /// </summary>
        public void CargarMatrizPredefinida()
        {
            matriz = new double[,]
            {
                { 0, 2, 5, 7, 6 },
                { 0, 0, 0, 3, 8 },
                { 2, 9, 6, 3, 4 },
                { 1, 5, 6, 1, 4 },
                { 0, 9, 2, 5, 0 }
            };
        }

        public void EstablecerValor(int fila, int columna, double valor)
        {
            if (fila < 0 || fila >= Dimension || columna < 0 || columna >= Dimension)
            {
                throw new IndexOutOfRangeException("Índice fuera de los límites de la matriz de 5x5.");
            }
            matriz[fila, columna] = valor;
        }

        public double ObtenerValor(int fila, int columna)
        {
            if (fila < 0 || fila >= Dimension || columna < 0 || columna >= Dimension)
            {
                throw new IndexOutOfRangeException("Índice fuera de los límites de la matriz de 5x5.");
            }
            return matriz[fila, columna];
        }

        public double[,] ObtenerMatriz()
        {
            return (double[,])matriz.Clone();
        }

        /// <summary>
        /// Cuenta cuántos ceros aparecen en un renglón específico.
        /// </summary>
        public int ContarCerosEnRenglon(int renglon)
        {
            if (renglon < 0 || renglon >= Dimension)
            {
                throw new ArgumentOutOfRangeException(nameof(renglon), "El número de renglón debe estar entre 0 y 4.");
            }

            int contador = 0;
            for (int j = 0; j < Dimension; j++)
            {
                // Usamos tolerancia o igualdad directa (0.0) para números decimales
                if (matriz[renglon, j] == 0.0)
                {
                    contador++;
                }
            }
            return contador;
        }

        /// <summary>
        /// Calcula el conteo de ceros para todos los renglones de la matriz.
        /// </summary>
        public int[] ContarCerosTodosRenglones()
        {
            int[] resultados = new int[Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                resultados[i] = ContarCerosEnRenglon(i);
            }
            return resultados;
        }
    }
}
