using System;
using System.Windows.Forms;

namespace MatrizCerosApp
{
    public partial class frmMatrizCeros : Form
    {
        private MatrizProcesador procesador;
        private const int Dimension = 5;

        public frmMatrizCeros()
        {
            InitializeComponent();
            procesador = new MatrizProcesador();
        }

        private void frmMatrizCeros_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarMatrizEnUI();
            CalcularYMostrarResultados();
        }

        private void ConfigurarDataGridView()
        {
            dgvMatriz.ColumnCount = Dimension;
            dgvMatriz.RowCount = Dimension;
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AllowUserToDeleteRows = false;
            dgvMatriz.RowHeadersWidth = 60;

            for (int j = 0; j < Dimension; j++)
            {
                dgvMatriz.Columns[j].Name = $"Col{j}";
                dgvMatriz.Columns[j].HeaderText = $"Col {j}";
                dgvMatriz.Columns[j].Width = 70;
            }

            for (int i = 0; i < Dimension; i++)
            {
                dgvMatriz.Rows[i].HeaderCell.Value = $"Fila {i}";
            }
        }

        private void CargarMatrizEnUI()
        {
            double[,] matriz = procesador.ObtenerMatriz();
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    dgvMatriz.Rows[i].Cells[j].Value = matriz[i, j];
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Leer datos del DataGridView y actualizar el modelo (separación de capas)
                for (int i = 0; i < Dimension; i++)
                {
                    for (int j = 0; j < Dimension; j++)
                    {
                        var valorCelda = dgvMatriz.Rows[i].Cells[j].Value;
                        if (valorCelda == null || string.IsNullOrWhiteSpace(valorCelda.ToString()))
                        {
                            throw new FormatException($"La celda en [Fila {i}, Columna {j}] está vacía.");
                        }

                        if (!double.TryParse(valorCelda.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out double valor) &&
                            !double.TryParse(valorCelda.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out valor))
                        {
                            throw new FormatException($"El valor '{valorCelda}' en [Fila {i}, Columna {j}] no es un número válido.");
                        }

                        procesador.EstablecerValor(i, j, valor);
                    }
                }

                CalcularYMostrarResultados();
                MessageBox.Show("¡Cálculo realizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de validación o entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                procesador.CargarMatrizPredefinida();
                CargarMatrizEnUI();
                CalcularYMostrarResultados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularYMostrarResultados()
        {
            lstResultados.Items.Clear();
            int[] cerosPorRenglon = procesador.ContarCerosTodosRenglones();

            for (int i = 0; i < Dimension; i++)
            {
                lstResultados.Items.Add($"Fila {i}: {cerosPorRenglon[i]} cero(s)");
            }
        }
    }
}
