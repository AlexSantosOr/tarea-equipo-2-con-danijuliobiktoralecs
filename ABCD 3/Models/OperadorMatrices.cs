using System;

namespace MatrixApp.Models
{
    /// <summary>
    /// Modelo que encapsula dos matrices 2x2 de tipo decimal y realiza operaciones (Suma, Resta, Producto simple, División simple).
    /// </summary>
    public class OperadorMatrices
    {
        public decimal[,] Matriz1 { get; set; }
        public decimal[,] Matriz2 { get; set; }

        public OperadorMatrices(decimal[,] matriz1, decimal[,] matriz2)
        {
            if (matriz1 == null || matriz1.GetLength(0) != 2 || matriz1.GetLength(1) != 2)
                throw new ArgumentException("Matriz 1 debe ser de tamaño 2x2.", nameof(matriz1));
            if (matriz2 == null || matriz2.GetLength(0) != 2 || matriz2.GetLength(1) != 2)
                throw new ArgumentException("Matriz 2 debe ser de tamaño 2x2.", nameof(matriz2));

            Matriz1 = matriz1;
            Matriz2 = matriz2;
        }

        /// <summary>
        /// a) Suma de ambas matrices.
        /// </summary>
        public decimal[,] Sumar()
        {
            decimal[,] resultado = new decimal[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultado[i, j] = Matriz1[i, j] + Matriz2[i, j];
                }
            }
            return resultado;
        }

        /// <summary>
        /// b) Resta de la primera matriz menos la segunda.
        /// </summary>
        public decimal[,] Restar()
        {
            decimal[,] resultado = new decimal[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultado[i, j] = Matriz1[i, j] - Matriz2[i, j];
                }
            }
            return resultado;
        }

        /// <summary>
        /// c) Producto elemento a elemento (producto simple).
        /// </summary>
        public decimal[,] MultiplicarElementoAElemento()
        {
            decimal[,] resultado = new decimal[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultado[i, j] = Matriz1[i, j] * Matriz2[i, j];
                }
            }
            return resultado;
        }

        /// <summary>
        /// d) División elemento a elemento (división simple), retornando string[,] con 'N/A' en caso de división por cero.
        /// </summary>
        public string[,] DividirElementoAElementoConFormato()
        {
            string[,] resultado = new string[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Matriz2[i, j] == 0)
                    {
                        resultado[i, j] = "N/A";
                    }
                    else
                    {
                        decimal div = Matriz1[i, j] / Matriz2[i, j];
                        resultado[i, j] = div.ToString("0.####");
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// d) División elemento a elemento (división simple) numérica que lanza excepción si hay división por cero.
        /// </summary>
        public decimal[,] DividirElementoAElemento()
        {
            decimal[,] resultado = new decimal[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Matriz2[i, j] == 0)
                    {
                        throw new DivideByZeroException($"División por cero detectada en la posición [{i},{j}].");
                    }
                    resultado[i, j] = Matriz1[i, j] / Matriz2[i, j];
                }
            }
            return resultado;
        }
    }
}
