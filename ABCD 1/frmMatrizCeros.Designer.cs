namespace MatrizCerosApp
{
    partial class frmMatrizCeros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblInstrucciones = new Label();
            dgvMatriz = new DataGridView();
            btnCalcular = new Button();
            btnLimpiar = new Button();
            lstResultados = new ListBox();
            lblResultadoTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(24, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(428, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Calculadora de Ceros en Matriz 5x5";
            // 
            // lblInstrucciones
            // 
            lblInstrucciones.AutoSize = true;
            lblInstrucciones.Font = new Font("Segoe UI", 10F);
            lblInstrucciones.Location = new Point(24, 65);
            lblInstrucciones.Name = "lblInstrucciones";
            lblInstrucciones.Size = new Size(520, 23);
            lblInstrucciones.TabIndex = 1;
            lblInstrucciones.Text = "Modifique los valores de la matriz 5x5 si lo desea y presione \"Calcular\".";
            // 
            // dgvMatriz
            // 
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AllowUserToDeleteRows = false;
            dgvMatriz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriz.Location = new Point(24, 105);
            dgvMatriz.Name = "dgvMatriz";
            dgvMatriz.RowHeadersWidth = 51;
            dgvMatriz.Size = new Size(450, 220);
            dgvMatriz.TabIndex = 2;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(0, 122, 204);
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(24, 345);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(130, 45);
            btnCalcular.TabIndex = 3;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(169, 345);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(130, 45);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Restaurar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lstResultados
            // 
            lstResultados.Font = new Font("Segoe UI", 10F);
            lstResultados.FormattingEnabled = true;
            lstResultados.ItemHeight = 23;
            lstResultados.Location = new Point(495, 135);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(270, 188);
            lstResultados.TabIndex = 5;
            // 
            // lblResultadoTitulo
            // 
            lblResultadoTitulo.AutoSize = true;
            lblResultadoTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblResultadoTitulo.Location = new Point(495, 105);
            lblResultadoTitulo.Name = "lblResultadoTitulo";
            lblResultadoTitulo.Size = new Size(204, 25);
            lblResultadoTitulo.TabIndex = 6;
            lblResultadoTitulo.Text = "Conteo de Ceros por Fila:";
            // 
            // frmMatrizCeros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(795, 420);
            Controls.Add(lblResultadoTitulo);
            Controls.Add(lstResultados);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCalcular);
            Controls.Add(dgvMatriz);
            Controls.Add(lblInstrucciones);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmMatrizCeros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMatrizCeros - Análisis de Matriz de Ceros";
            Load += frmMatrizCeros_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInstrucciones;
        private DataGridView dgvMatriz;
        private Button btnCalcular;
        private Button btnLimpiar;
        private ListBox lstResultados;
        private Label lblResultadoTitulo;
    }
}
