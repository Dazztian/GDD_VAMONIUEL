namespace FrbaCrucero.AbmRecorrido
{
    partial class ModificarRecorrido
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
            this.dataGridViewTramos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOrigen = new System.Windows.Forms.Button();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.btnDestino = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDescartar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTramos
            // 
            this.dataGridViewTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTramos.Location = new System.Drawing.Point(15, 46);
            this.dataGridViewTramos.Name = "dataGridViewTramos";
            this.dataGridViewTramos.ReadOnly = true;
            this.dataGridViewTramos.Size = new System.Drawing.Size(498, 150);
            this.dataGridViewTramos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tramos";
            // 
            // btnOrigen
            // 
            this.btnOrigen.Location = new System.Drawing.Point(12, 202);
            this.btnOrigen.Name = "btnOrigen";
            this.btnOrigen.Size = new System.Drawing.Size(95, 23);
            this.btnOrigen.TabIndex = 2;
            this.btnOrigen.Text = "Modificar origen";
            this.btnOrigen.UseVisualStyleBackColor = true;
            this.btnOrigen.Click += new System.EventHandler(this.btnOrigen_Click);
            // 
            // btnPrecio
            // 
            this.btnPrecio.Location = new System.Drawing.Point(418, 202);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(95, 23);
            this.btnPrecio.TabIndex = 3;
            this.btnPrecio.Text = "Modificar precio";
            this.btnPrecio.UseVisualStyleBackColor = true;
            this.btnPrecio.Click += new System.EventHandler(this.btnPrecio_Click);
            // 
            // btnDestino
            // 
            this.btnDestino.Location = new System.Drawing.Point(217, 202);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(95, 23);
            this.btnDestino.TabIndex = 4;
            this.btnDestino.Text = "Modificar destino";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(116, 231);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDescartar
            // 
            this.btnDescartar.Location = new System.Drawing.Point(318, 231);
            this.btnDescartar.Name = "btnDescartar";
            this.btnDescartar.Size = new System.Drawing.Size(95, 23);
            this.btnDescartar.TabIndex = 6;
            this.btnDescartar.Text = "Descartar";
            this.btnDescartar.UseVisualStyleBackColor = true;
            this.btnDescartar.Click += new System.EventHandler(this.btnDescartar_Click);
            // 
            // ModificarRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 261);
            this.Controls.Add(this.btnDescartar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnDestino);
            this.Controls.Add(this.btnPrecio);
            this.Controls.Add(this.btnOrigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTramos);
            this.Name = "ModificarRecorrido";
            this.Text = "ModificarRecorrido";
            this.Load += new System.EventHandler(this.ModificarRecorrido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTramos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrigen;
        private System.Windows.Forms.Button btnPrecio;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDescartar;
    }
}