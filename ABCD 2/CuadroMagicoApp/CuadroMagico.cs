using System;

namespace CuadroMagicoApp
{
    /// <summary>
    /// Modelo de lógica de negocio para la gestión y validación de un Cuadro Mágico.
    /// Cumple con estrictos principios de Programación Orientada a Objetos (POO).
    /// </summary>
    public class CuadroMagico
    {
        private decimal[,] matriz;

        /// <summary>
        /// Constructor que inicializa el cuadro mágico con un tamaño n x n.
        /// </summary>
        /// <param name="n">Tamaño de la matriz (filas y columnas). Debe ser mayor o igual a 2.</param>
        public CuadroMagico(int n)
        {
            if (n < 2)
            {
                throw new ArgumentException("El tamaño del cuadro mágico debe ser de al menos 2x2.");
            }
            matriz = new decimal[n, n];
            ConstanteMagica = 0;
        }

        /// <summary>
        /// Constructor que inicializa el cuadro mágico a partir de una matriz existente.
        /// </summary>
        /// <param name="valores">Matriz bidimensional de valores decimales.</param>
        public CuadroMagico(decimal[,] valores)
        {
            if (valores == null)
            {
                throw new ArgumentNullException(nameof(valores), "La matriz no puede ser nula.");
            }

            int filas = valores.GetLength(0);
            int columnas = valores.GetLength(1);

            if (filas < 2 || columnas < 2)
            {
                throw new ArgumentException("El tamaño de la matriz debe ser de al menos 2x2.");
            }

            if (filas != columnas)
            {
                throw new ArgumentException("El cuadro mágico debe ser una matriz cuadrada (n x n).");
            }

            matriz = (decimal[,])valores.Clone();
            ConstanteMagica = 0;
        }

        /// <summary>
        /// Obtiene o establece el valor en una posición específica de la matriz.
        /// </summary>
        public decimal this[int fila, int columna]
        {
            get => matriz[fila, columna];
            set => matriz[fila, columna] = value;
        }

        /// <summary>
        /// Obtiene el tamaño (n) de la matriz cuadrada.
        /// </summary>
        public int Tamanio => matriz.GetLength(0);

        /// <summary>
        /// Obtiene la matriz completa.
        /// </summary>
        public decimal[,] ObtenerMatriz()
        {
            return (decimal[,])matriz.Clone();
        }

        /// <summary>
        /// Establece todos los valores de la matriz.
        /// </summary>
        public void EstablecerMatriz(decimal[,] nuevaMatriz)
        {
            if (nuevaMatriz == null)
                throw new ArgumentNullException(nameof(nuevaMatriz));
            
            int n = nuevaMatriz.GetLength(0);
            if (n < 2 || n != nuevaMatriz.GetLength(1))
                throw new ArgumentException("La matriz debe ser cuadrada y de al menos 2x2.");

            matriz = (decimal[,])nuevaMatriz.Clone();
        }

        /// <summary>
        /// Propiedad que devuelve la Constante Mágica calculada si el cuadro es válido.
        /// </summary>
        public decimal ConstanteMagica { get; private set; }

        /// <summary>
        /// Valida si la matriz actual cumple con la condición de Cuadro Mágico:
        /// La suma de cada fila, cada columna y ambas diagonales debe ser idéntica.
        /// </summary>
        /// <returns>True si es un cuadro mágico, False en caso contrario.</returns>
        public bool EsCuadroMagico()
        {
            int n = Tamanio;
            decimal sumaReferencia = 0;

            // 1. Calcular la suma de la primera fila como referencia
            for (int j = 0; j < n; j++)
            {
                sumaReferencia += matriz[0, j];
            }

            // 2. Verificar las demás filas
            for (int i = 1; i < n; i++)
            {
                decimal sumaFila = 0;
                for (int j = 0; j < n; j++)
                {
                    sumaFila += matriz[i, j];
                }
                if (sumaFila != sumaReferencia)
                {
                    return false;
                }
            }

            // 3. Verificar cada columna
            for (int j = 0; j < n; j++)
            {
                decimal sumaColumna = 0;
                for (int i = 0; i < n; i++)
                {
                    sumaColumna += matriz[i, j];
                }
                if (sumaColumna != sumaReferencia)
                {
                    return false;
                }
            }

            // 4. Verificar diagonal principal (i == j)
            decimal sumaDiagPrincipal = 0;
            for (int i = 0; i < n; i++)
            {
                sumaDiagPrincipal += matriz[i, i];
            }
            if (sumaDiagPrincipal != sumaReferencia)
            {
                return false;
            }

            // 5. Verificar diagonal secundaria (i + j == n - 1)
            decimal sumaDiagSecundaria = 0;
            for (int i = 0; i < n; i++)
            {
                sumaDiagSecundaria += matriz[i, n - 1 - i];
            }
            if (sumaDiagSecundaria != sumaReferencia)
            {
                return false;
            }

            // Si todas las sumas coinciden, guardamos la constante mágica y retornamos true
            ConstanteMagica = sumaReferencia;
            return true;
        }
    }
}
