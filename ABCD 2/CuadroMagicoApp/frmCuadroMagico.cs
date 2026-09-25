using System;
using System.Drawing;
using System.Windows.Forms;

namespace CuadroMagicoApp
{
    public partial class frmCuadroMagico : Form
    {
        private CuadroMagico cuadroMagico;

        public frmCuadroMagico()
        {
            InitializeComponent();
        }

        private void frmCuadroMagico_Load(object sender, EventArgs e)
        {
            GenerarLogoPlaceholder();
            // Generar matriz por defecto de 3x3 al iniciar
            txtTamanio.Text = "3";
            GenerarMatrizDinamica(3);
        }

        /// <summary>
        /// Genera una imagen representativa para el PictureBox picLogo.
        /// </summary>
        private void GenerarLogoPlaceholder()
        {
            Bitmap bmp = new Bitmap(80, 80);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(0, 51, 102));
                using (Brush brush = new SolidBrush(Color.White))
                {
                    using (Font font = new Font("Segoe UI", 24, FontStyle.Bold))
                    {
                        g.DrawString("3x3", font, brush, new PointF(5, 20));
                    }
                }
            }
            picLogo.Image = bmp;
        }

        private void btnGenerarMatriz_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtTamanio.Text.Trim(), out int n))
                {
                    throw new FormatException("El tamaño ingresado no tiene un formato numérico válido.");
                }

                if (n < 2)
                {
                    MessageBox.Show("El tamaño de la matriz debe ser de al menos 2x2.", "Tamaño No Válido", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTamanio.Focus();
                    return;
                }

                if (n > 10)
                {
                    MessageBox.Show("Por razones de visualización, el tamaño máximo recomendado es 10x10.", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                GenerarMatrizDinamica(n);
                btnValidar.Enabled = true;
                lblResultado.Text = "Resultado: Pendiente de análisis";
                lblResultado.ForeColor = Color.FromArgb(50, 50, 50);
                lblConstante.Text = "Constante Mágica: N/A";
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error de formato: {ex.Message}\nPor favor ingrese un número entero válido.", 
                    "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTamanio.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarMatrizDinamica(int n)
        {
            dgvMatriz.Columns.Clear();
            dgvMatriz.Rows.Clear();

            // Configurar columnas
            for (int j = 0; j < n; j++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
                {
                    Name = $"col_{j}",
                    HeaderText = $"Col {j + 1}",
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                dgvMatriz.Columns.Add(col);
            }

            // Configurar filas
            dgvMatriz.Rows.Add(n);

            // Inicializar celdas con ceros por defecto
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dgvMatriz.Rows[i].Cells[j].Value = "0";
                }
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dgvMatriz.ColumnCount;
                if (n < 2)
                {
                    throw new InvalidOperationException("Primero debe generar una matriz válida.");
                }

                decimal[,] valores = new decimal[n, n];

                // Leer y validar valores del DataGridView
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var cellValue = dgvMatriz.Rows[i].Cells[j].Value;
                        
                        if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                        {
                            throw new FormatException($"La celda en la fila {i + 1}, columna {j + 1} está vacía.");
                        }

                        if (!decimal.TryParse(cellValue.ToString().Trim(), out decimal numero))
                        {
                            throw new FormatException($"El valor '{cellValue}' en la fila {i + 1}, columna {j + 1} no es un número decimal válido.");
                        }

                        valores[i, j] = numero;
                    }
                }

                // Instanciar el modelo de lógica de negocio (POO)
                cuadroMagico = new CuadroMagico(valores);

                bool esMagico = cuadroMagico.EsCuadroMagico();

                if (esMagico)
                {
                    lblResultado.Text = "¡Es un Cuadro Mágico!";
                    lblResultado.ForeColor = Color.FromArgb(40, 167, 69); // Verde éxito
                    lblConstante.Text = $"Constante Mágica: {cuadroMagico.ConstanteMagica}";

                    MessageBox.Show($"¡Felicidades! La matriz ingresada es un Cuadro Mágico.\n\nConstante Mágica: {cuadroMagico.ConstanteMagica}", 
                        "Resultado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblResultado.Text = "No es un Cuadro Mágico";
                    lblResultado.ForeColor = Color.FromArgb(220, 53, 69); // Rojo error
                    lblConstante.Text = "Constante Mágica: N/A";

                    MessageBox.Show("La matriz ingresada NO es un cuadro mágico.\nLas sumas de filas, columnas o diagonales no coinciden.", 
                        "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error en los datos de la matriz:\n{ex.Message}", 
                    "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al validar el cuadro mágico:\n{ex.Message}", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTamanio.Text = "3";
            GenerarMatrizDinamica(3);
            btnValidar.Enabled = true;
            lblResultado.Text = "Resultado: Pendiente de análisis";
            lblResultado.ForeColor = Color.FromArgb(50, 50, 50);
            lblConstante.Text = "Constante Mágica: N/A";
            txtTamanio.Focus();
        }
    }
}
