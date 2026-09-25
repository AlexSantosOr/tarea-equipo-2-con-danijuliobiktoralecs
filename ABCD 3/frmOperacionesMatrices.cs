using System;
using System.Drawing;
using System.Windows.Forms;
using MatrixApp.Models;

namespace MatrixApp
{
    public class frmOperacionesMatrices : Form
    {
        // Controls according to naming standards
        private Label lblTitulo = null!;
        private Label lblMatriz1 = null!;
        private Label lblMatriz2 = null!;
        private Label lblSuma = null!;
        private Label lblResta = null!;
        private Label lblProducto = null!;
        private Label lblDivision = null!;
        private Label lblImagenLogo = null!;

        // Inputs Matriz 1 (2x2)
        private TextBox txtM1_00 = null!;
        private TextBox txtM1_01 = null!;
        private TextBox txtM1_10 = null!;
        private TextBox txtM1_11 = null!;

        // Inputs Matriz 2 (2x2)
        private TextBox txtM2_00 = null!;
        private TextBox txtM2_01 = null!;
        private TextBox txtM2_10 = null!;
        private TextBox txtM2_11 = null!;

        // Results DataGridViews (2x2)
        private DataGridView dgvResultadoSuma = null!;
        private DataGridView dgvResultadoResta = null!;
        private DataGridView dgvResultadoProducto = null!;
        private DataGridView dgvResultadoDivision = null!;

        // Buttons
        private Button btnCalcular = null!;
        private Button btnLimpiar = null!;
        private Button btnSalir = null!;

        // PictureBox / Logo
        private PictureBox picLogo = null!;
        private PictureBox picOperaciones = null!;

        public frmOperacionesMatrices()
        {
            InitializeComponent();
            CargarValoresEjercicio3();
        }

        private void InitializeComponent()
        {
            this.Text = "Operaciones de Matrices 2x2 - Ejercicio 3 (POO)";
            this.Size = new Size(950, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // lblTitulo
            this.lblTitulo = new Label();
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "RESOLUCIÓN DE OPERACIONES CON MATRICES 2x2";
            this.lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new Point(30, 20);
            this.Controls.Add(this.lblTitulo);

            // lblImagenLogo (etiqueta descriptiva del logotipo)
            this.lblImagenLogo = new Label();
            this.lblImagenLogo.Name = "lblImagenLogo";
            this.lblImagenLogo.Text = "Logotipo / Operaciones";
            this.lblImagenLogo.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            this.lblImagenLogo.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblImagenLogo.AutoSize = true;
            this.lblImagenLogo.Location = new Point(780, 75);
            this.Controls.Add(this.lblImagenLogo);

            // picLogo / picOperaciones
            this.picLogo = new PictureBox();
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(130, 50);
            this.picLogo.Location = new Point(770, 20);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = Color.FromArgb(226, 232, 240);
            this.picLogo.Paint += (s, e) => {
                e.Graphics.DrawString("MATRIZ APP", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.DarkSlateGray, new PointF(25, 16));
            };
            this.Controls.Add(this.picLogo);

            this.picOperaciones = new PictureBox();
            this.picOperaciones.Name = "picOperaciones";
            this.picOperaciones.Visible = false;
            this.Controls.Add(this.picOperaciones);

            // --- Panel Matriz 1 ---
            this.lblMatriz1 = new Label();
            this.lblMatriz1.Name = "lblMatriz1";
            this.lblMatriz1.Text = "Matriz 1 (A)";
            this.lblMatriz1.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblMatriz1.Location = new Point(30, 90);
            this.lblMatriz1.AutoSize = true;
            this.Controls.Add(this.lblMatriz1);

            Panel pnlM1 = CrearPanelMatriz(out txtM1_00, out txtM1_01, out txtM1_10, out txtM1_11, 30, 120);
            this.Controls.Add(pnlM1);

            // --- Panel Matriz 2 ---
            this.lblMatriz2 = new Label();
            this.lblMatriz2.Name = "lblMatriz2";
            this.lblMatriz2.Text = "Matriz 2 (B)";
            this.lblMatriz2.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblMatriz2.Location = new Point(270, 90);
            this.lblMatriz2.AutoSize = true;
            this.Controls.Add(this.lblMatriz2);

            Panel pnlM2 = CrearPanelMatriz(out txtM2_00, out txtM2_01, out txtM2_10, out txtM2_11, 270, 120);
            this.Controls.Add(pnlM2);

            // --- Botones de Control ---
            this.btnCalcular = new Button();
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Text = "Calcular Operaciones";
            this.btnCalcular.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnCalcular.BackColor = Color.FromArgb(37, 99, 235);
            this.btnCalcular.ForeColor = Color.White;
            this.btnCalcular.FlatStyle = FlatStyle.Flat;
            this.btnCalcular.Location = new Point(510, 130);
            this.btnCalcular.Size = new Size(180, 45);
            this.btnCalcular.Cursor = Cursors.Hand;
            this.btnCalcular.Click += new EventHandler(this.btnCalcular_Click);
            this.Controls.Add(this.btnCalcular);

            this.btnLimpiar = new Button();
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Font = new Font("Segoe UI", 10);
            this.btnLimpiar.BackColor = Color.FromArgb(100, 116, 139);
            this.btnLimpiar.ForeColor = Color.White;
            this.btnLimpiar.FlatStyle = FlatStyle.Flat;
            this.btnLimpiar.Location = new Point(510, 185);
            this.btnLimpiar.Size = new Size(85, 35);
            this.btnLimpiar.Cursor = Cursors.Hand;
            this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);
            this.Controls.Add(this.btnLimpiar);

            this.btnSalir = new Button();
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.Font = new Font("Segoe UI", 10);
            this.btnSalir.BackColor = Color.FromArgb(220, 38, 38);
            this.btnSalir.ForeColor = Color.White;
            this.btnSalir.FlatStyle = FlatStyle.Flat;
            this.btnSalir.Location = new Point(605, 185);
            this.btnSalir.Size = new Size(85, 35);
            this.btnSalir.Cursor = Cursors.Hand;
            this.btnSalir.Click += new EventHandler(this.btnSalir_Click);
            this.Controls.Add(this.btnSalir);

            // --- Resultados (4 Secciones) ---
            int startY = 250;
            int col1X = 30;
            int col2X = 500;

            // a) Suma
            this.lblSuma = new Label();
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.Text = "a) Suma (Matriz 1 + Matriz 2)";
            this.lblSuma.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblSuma.Location = new Point(col1X, startY);
            this.lblSuma.AutoSize = true;
            this.Controls.Add(this.lblSuma);

            this.dgvResultadoSuma = CrearDataGridViewResultado("dgvResultadoSuma", col1X, startY + 25);
            this.Controls.Add(this.dgvResultadoSuma);

            // b) Resta
            this.lblResta = new Label();
            this.lblResta.Name = "lblResta";
            this.lblResta.Text = "b) Resta (Matriz 1 - Matriz 2)";
            this.lblResta.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblResta.Location = new Point(col2X, startY);
            this.lblResta.AutoSize = true;
            this.Controls.Add(this.lblResta);

            this.dgvResultadoResta = CrearDataGridViewResultado("dgvResultadoResta", col2X, startY + 25);
            this.Controls.Add(this.dgvResultadoResta);

            // c) Producto Simple
            int startY2 = 450;
            this.lblProducto = new Label();
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Text = "c) Producto Elemento a Elemento";
            this.lblProducto.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblProducto.Location = new Point(col1X, startY2);
            this.lblProducto.AutoSize = true;
            this.Controls.Add(this.lblProducto);

            this.dgvResultadoProducto = CrearDataGridViewResultado("dgvResultadoProducto", col1X, startY2 + 25);
            this.Controls.Add(this.dgvResultadoProducto);

            // d) División Simple
            this.lblDivision = new Label();
            this.lblDivision.Name = "lblDivision";
            this.lblDivision.Text = "d) División Elemento a Elemento (M1 / M2)";
            this.lblDivision.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblDivision.Location = new Point(col2X, startY2);
            this.lblDivision.AutoSize = true;
            this.Controls.Add(this.lblDivision);

            this.dgvResultadoDivision = CrearDataGridViewResultado("dgvResultadoDivision", col2X, startY2 + 25);
            this.Controls.Add(this.dgvResultadoDivision);
        }

        private Panel CrearPanelMatriz(out TextBox t00, out TextBox t01, out TextBox t10, out TextBox t11, int x, int y)
        {
            Panel pnl = new Panel();
            pnl.Location = new Point(x, y);
            pnl.Size = new Size(200, 110);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            t00 = CrearTextBoxMatriz("00");
            t01 = CrearTextBoxMatriz("01");
            t10 = CrearTextBoxMatriz("10");
            t11 = CrearTextBoxMatriz("11");

            t00.Location = new Point(20, 20);
            t01.Location = new Point(110, 20);
            t10.Location = new Point(20, 65);
            t11.Location = new Point(110, 65);

            pnl.Controls.Add(t00);
            pnl.Controls.Add(t01);
            pnl.Controls.Add(t10);
            pnl.Controls.Add(t11);

            return pnl;
        }

        private TextBox CrearTextBoxMatriz(string pos)
        {
            TextBox txt = new TextBox();
            txt.Name = "txtM_" + pos;
            txt.Size = new Size(70, 27);
            txt.Font = new Font("Segoe UI", 11);
            txt.TextAlign = HorizontalAlignment.Center;
            return txt;
        }

        private DataGridView CrearDataGridViewResultado(string name, int x, int y)
        {
            DataGridView dgv = new DataGridView();
            dgv.Name = name;
            dgv.Location = new Point(x, y);
            dgv.Size = new Size(220, 110);
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            dgv.ScrollBars = ScrollBars.None;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.Enabled = false; // Solo lectura

            dgv.ColumnCount = 2;
            dgv.RowCount = 2;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Width = 108;
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Height = 50;
            }

            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);

            return dgv;
        }

        private void CargarValoresEjercicio3()
        {
            // Valores iniciales según el Ejercicio 3
            // Matriz 1: [[10, 5], [8, 2]]
            txtM1_00.Text = "10";
            txtM1_01.Text = "5";
            txtM1_10.Text = "8";
            txtM1_11.Text = "2";

            // Matriz 2: [[2, 4], [6, 8]]
            txtM2_00.Text = "2";
            txtM2_01.Text = "4";
            txtM2_10.Text = "6";
            txtM2_11.Text = "8";

            // Asignar nombres específicos requeridos por la norma
            txtM1_00.Name = "txtM1_00";
            txtM1_01.Name = "txtM1_01";
            txtM1_10.Name = "txtM1_10";
            txtM1_11.Name = "txtM1_11";

            txtM2_00.Name = "txtM2_00";
            txtM2_01.Name = "txtM2_01";
            txtM2_10.Name = "txtM2_10";
            txtM2_11.Name = "txtM2_11";
        }

        private void btnCalcular_Click(object? sender, EventArgs? e)
        {
            try
            {
                // Lectura y validación de Matriz 1
                decimal[,] m1 = new decimal[2, 2];
                m1[0, 0] = ParseDecimal(txtM1_00.Text, "Matriz 1 [0,0]");
                m1[0, 1] = ParseDecimal(txtM1_01.Text, "Matriz 1 [0,1]");
                m1[1, 0] = ParseDecimal(txtM1_10.Text, "Matriz 1 [1,0]");
                m1[1, 1] = ParseDecimal(txtM1_11.Text, "Matriz 1 [1,1]");

                // Lectura y validación de Matriz 2
                decimal[,] m2 = new decimal[2, 2];
                m2[0, 0] = ParseDecimal(txtM2_00.Text, "Matriz 2 [0,0]");
                m2[0, 1] = ParseDecimal(txtM2_01.Text, "Matriz 2 [0,1]");
                m2[1, 0] = ParseDecimal(txtM2_10.Text, "Matriz 2 [1,0]");
                m2[1, 1] = ParseDecimal(txtM2_11.Text, "Matriz 2 [1,1]");

                // Instanciar modelo POO
                OperadorMatrices operador = new OperadorMatrices(m1, m2);

                // Calcular operaciones
                decimal[,] resSuma = operador.Sumar();
                decimal[,] resResta = operador.Restar();
                decimal[,] resProducto = operador.MultiplicarElementoAElemento();
                string[,] resDivision = operador.DividirElementoAElementoConFormato();

                // Mostrar resultados en las DataGridViews
                MostrarMatrizEnDgv(dgvResultadoSuma, resSuma);
                MostrarMatrizEnDgv(dgvResultadoResta, resResta);
                MostrarMatrizEnDgv(dgvResultadoProducto, resProducto);
                MostrarMatrizEnDgvString(dgvResultadoDivision, resDivision);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error de formato numérico: {ex.Message}\nPor favor ingrese valores decimales válidos.",
                    "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Uno de los valores ingresados es demasiado grande o pequeño.",
                    "Desbordamiento Numérico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al calcular las matrices:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal ParseDecimal(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new FormatException($"El campo '{nombreCampo}' está vacío.");
            }

            if (decimal.TryParse(texto.Trim(), out decimal valor))
            {
                return valor;
            }
            else
            {
                throw new FormatException($"El valor '{texto}' en el campo '{nombreCampo}' no es un número decimal válido.");
            }
        }

        private void MostrarMatrizEnDgv(DataGridView dgv, decimal[,] matriz)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matriz[i, j].ToString("0.##");
                }
            }
        }

        private void MostrarMatrizEnDgvString(DataGridView dgv, string[,] matriz)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matriz[i, j];
                }
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs? e)
        {
            txtM1_00.Clear();
            txtM1_01.Clear();
            txtM1_10.Clear();
            txtM1_11.Clear();

            txtM2_00.Clear();
            txtM2_01.Clear();
            txtM2_10.Clear();
            txtM2_11.Clear();

            LimpiarDgv(dgvResultadoSuma);
            LimpiarDgv(dgvResultadoResta);
            LimpiarDgv(dgvResultadoProducto);
            LimpiarDgv(dgvResultadoDivision);

            txtM1_00.Focus();
        }

        private void LimpiarDgv(DataGridView dgv)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dgv.Rows[i].Cells[j].Value = string.Empty;
                }
            }
        }

        private void btnSalir_Click(object? sender, EventArgs? e)
        {
            this.Close();
        }
    }
}
