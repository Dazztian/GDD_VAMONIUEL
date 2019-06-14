namespace FrbaCrucero.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.btnTop5Pasajes = new System.Windows.Forms.Button();
            this.btnTop5CabinasLibres = new System.Windows.Forms.Button();
            this.btnTop5CrucerosDeshabilitados = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblPiola = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTop5Pasajes
            // 
            this.btnTop5Pasajes.Location = new System.Drawing.Point(84, 82);
            this.btnTop5Pasajes.Name = "btnTop5Pasajes";
            this.btnTop5Pasajes.Size = new System.Drawing.Size(90, 63);
            this.btnTop5Pasajes.TabIndex = 0;
            this.btnTop5Pasajes.Text = "Top 5 recorridos con mas pasajes comprados";
            this.btnTop5Pasajes.UseVisualStyleBackColor = true;
            this.btnTop5Pasajes.Click += new System.EventHandler(this.btnTop5Pasajes_Click);
            // 
            // btnTop5CabinasLibres
            // 
            this.btnTop5CabinasLibres.Location = new System.Drawing.Point(339, 82);
            this.btnTop5CabinasLibres.Name = "btnTop5CabinasLibres";
            this.btnTop5CabinasLibres.Size = new System.Drawing.Size(89, 63);
            this.btnTop5CabinasLibres.TabIndex = 1;
            this.btnTop5CabinasLibres.Text = "Top 5 recorridos con mas cabinas libres";
            this.btnTop5CabinasLibres.UseVisualStyleBackColor = true;
            this.btnTop5CabinasLibres.Click += new System.EventHandler(this.btnTop5CabinasLibres_Click);
            // 
            // btnTop5CrucerosDeshabilitados
            // 
            this.btnTop5CrucerosDeshabilitados.Location = new System.Drawing.Point(660, 72);
            this.btnTop5CrucerosDeshabilitados.Name = "btnTop5CrucerosDeshabilitados";
            this.btnTop5CrucerosDeshabilitados.Size = new System.Drawing.Size(82, 73);
            this.btnTop5CrucerosDeshabilitados.TabIndex = 2;
            this.btnTop5CrucerosDeshabilitados.Text = "Top 5 cruceros con mas dias fueras de servicio";
            this.btnTop5CrucerosDeshabilitados.UseVisualStyleBackColor = true;
            this.btnTop5CrucerosDeshabilitados.Click += new System.EventHandler(this.btnTop5CrucerosDeshabilitados_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(47, 196);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(710, 173);
            this.dgv.TabIndex = 3;
            // 
            // lblPiola
            // 
            this.lblPiola.AutoSize = true;
            this.lblPiola.Location = new System.Drawing.Point(47, 177);
            this.lblPiola.Name = "lblPiola";
            this.lblPiola.Size = new System.Drawing.Size(0, 13);
            this.lblPiola.TabIndex = 4;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 466);
            this.Controls.Add(this.lblPiola);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnTop5CrucerosDeshabilitados);
            this.Controls.Add(this.btnTop5CabinasLibres);
            this.Controls.Add(this.btnTop5Pasajes);
            this.Name = "ListadoEstadistico";
            this.Text = "Listados estadísticos";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTop5Pasajes;
        private System.Windows.Forms.Button btnTop5CabinasLibres;
        private System.Windows.Forms.Button btnTop5CrucerosDeshabilitados;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblPiola;
    }
}