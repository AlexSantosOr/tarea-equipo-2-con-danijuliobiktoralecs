using System;
using System.Drawing;
using System.Windows.Forms;

namespace CuadroMagicoApp
{
    partial class frmCuadroMagico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblTamanio = new Label();
            txtTamanio = new TextBox();
            btnGenerarMatriz = new Button();
            dgvMatriz = new DataGridView();
            btnValidar = new Button();
            btnLimpiar = new Button();
            lblResultado = new Label();
            lblConstante = new Label();
            picLogo = new PictureBox();
            lblImagenLogo = new Label();
            panelControles = new Panel();
            panelResultados = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelControles.SuspendLayout();
            panelResultados.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(0, 51, 102);
            lblTitulo.Location = new Point(120, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(381, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resolución de Cuadro Mágico";
            // 
            // lblTamanio
            // 
            lblTamanio.AutoSize = true;
            lblTamanio.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblTamanio.Location = new Point(15, 18);
            lblTamanio.Name = "lblTamanio";
            lblTamanio.Size = new Size(130, 20);
            lblTamanio.TabIndex = 1;
            lblTamanio.Text = "Tamaño de matriz (n):";
            // 
            // txtTamanio
            // 
            txtTamanio.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtTamanio.Location = new Point(151, 15);
            txtTamanio.Name = "txtTamanio";
            txtTamanio.Size = new Size(80, 27);
            txtTamanio.TabIndex = 2;
            txtTamanio.Text = "3";
            // 
            // btnGenerarMatriz
            // 
            btnGenerarMatriz.BackColor = Color.FromArgb(0, 102, 204);
            btnGenerarMatriz.Cursor = Cursors.Hand;
            btnGenerarMatriz.FlatAppearance.BorderSize = 0;
            btnGenerarMatriz.FlatStyle = FlatStyle.Flat;
            btnGenerarMatriz.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarMatriz.ForeColor = Color.White;
            btnGenerarMatriz.Location = new Point(245, 12);
            btnGenerarMatriz.Name = "btnGenerarMatriz";
            btnGenerarMatriz.Size = new Size(140, 32);
            btnGenerarMatriz.TabIndex = 3;
            btnGenerarMatriz.Text = "Generar Matriz";
            btnGenerarMatriz.UseVisualStyleBackColor = false;
            btnGenerarMatriz.Click += btnGenerarMatriz_Click;
            // 
            // dgvMatriz
            // 
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AllowUserToDeleteRows = false;
            dgvMatriz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatriz.BackgroundColor = Color.White;
            dgvMatriz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriz.Location = new Point(20, 150);
            dgvMatriz.Name = "dgvMatriz";
            dgvMatriz.RowHeadersVisible = false;
            dgvMatriz.RowTemplate.Height = 30;
            dgvMatriz.Size = new Size(540, 280);
            dgvMatriz.TabIndex = 4;
            // 
            // btnValidar
            // 
            btnValidar.BackColor = Color.FromArgb(40, 167, 69);
            btnValidar.Cursor = Cursors.Hand;
            btnValidar.Enabled = false;
            btnValidar.FlatAppearance.BorderSize = 0;
            btnValidar.FlatStyle = FlatStyle.Flat;
            btnValidar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnValidar.ForeColor = Color.White;
            btnValidar.Location = new Point(20, 445);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(255, 40);
            btnValidar.TabIndex = 5;
            btnValidar.Text = "Validar Cuadro Mágico";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(305, 445);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(255, 40);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblResultado
            // 
            lblResultado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblResultado.ForeColor = Color.FromArgb(50, 50, 50);
            lblResultado.Location = new Point(10, 15);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(340, 30);
            lblResultado.TabIndex = 7;
            lblResultado.Text = "Resultado: Pendiente de análisis";
            // 
            // lblConstante
            // 
            lblConstante.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblConstante.ForeColor = Color.FromArgb(80, 80, 80);
            lblConstante.Location = new Point(10, 50);
            lblConstante.Name = "lblConstante";
            lblConstante.Size = new Size(340, 25);
            lblConstante.TabIndex = 8;
            lblConstante.Text = "Constante Mágica: N/A";
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(20, 15);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(80, 80);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            // 
            // lblImagenLogo
            // 
            lblImagenLogo.AutoSize = true;
            lblImagenLogo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblImagenLogo.ForeColor = Color.Gray;
            lblImagenLogo.Location = new Point(120, 55);
            lblImagenLogo.Name = "lblImagenLogo";
            lblImagenLogo.Size = new Size(203, 15);
            lblImagenLogo.TabIndex = 10;
            lblImagenLogo.Text = "Ejercicio 2 - Estructuras Matriciales";
            // 
            // panelControles
            // 
            panelControles.BackColor = Color.FromArgb(245, 247, 250);
            panelControles.BorderStyle = BorderStyle.FixedSingle;
            panelControles.Controls.Add(lblTamanio);
            panelControles.Controls.Add(txtTamanio);
            panelControles.Controls.Add(btnGenerarMatriz);
            panelControles.Location = new Point(20, 95);
            panelControles.Name = "panelControles";
            panelControles.Size = new Size(540, 55);
            panelControles.TabIndex = 11;
            // 
            // panelResultados
            // 
            panelResultados.BackColor = Color.FromArgb(245, 247, 250);
            panelResultados.BorderStyle = BorderStyle.FixedSingle;
            panelResultados.Controls.Add(lblResultado);
            panelResultados.Controls.Add(lblConstante);
            panelResultados.Location = new Point(575, 150);
            panelResultados.Name = "panelResultados";
            panelResultados.Size = new Size(365, 280);
            panelResultados.TabIndex = 12;
            // 
            // frmCuadroMagico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(955, 510);
            Controls.Add(panelResultados);
            Controls.Add(panelControles);
            Controls.Add(lblImagenLogo);
            Controls.Add(picLogo);
            Controls.Add(btnLimpiar);
            Controls.Add(btnValidar);
            Controls.Add(dgvMatriz);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCuadroMagico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Verificador de Cuadro Mágico - POO";
            Load += frmCuadroMagico_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            panelResultados.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblTamanio;
        private TextBox txtTamanio;
        private Button btnGenerarMatriz;
        private DataGridView dgvMatriz;
        private Button btnValidar;
        private Button btnLimpiar;
        private Label lblResultado;
        private Label lblConstante;
        private PictureBox picLogo;
        private Label lblImagenLogo;
        private Panel panelControles;
        private Panel panelResultados;
    }
}
