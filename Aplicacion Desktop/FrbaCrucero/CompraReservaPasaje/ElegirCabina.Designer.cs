namespace FrbaCrucero.CompraPasaje
{
    partial class ElegirCabina
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
            this.dgvCab = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnElegir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvReco = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReco)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCab
            // 
            this.dgvCab.AllowUserToAddRows = false;
            this.dgvCab.AllowUserToDeleteRows = false;
            this.dgvCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCab.Location = new System.Drawing.Point(31, 38);
            this.dgvCab.Name = "dgvCab";
            this.dgvCab.ReadOnly = true;
            this.dgvCab.Size = new System.Drawing.Size(604, 388);
            this.dgvCab.TabIndex = 0;
            this.dgvCab.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCab_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID de la cabina";
            // 
            // btnElegir
            // 
            this.btnElegir.Location = new System.Drawing.Point(525, 504);
            this.btnElegir.Name = "btnElegir";
            this.btnElegir.Size = new System.Drawing.Size(110, 23);
            this.btnElegir.TabIndex = 3;
            this.btnElegir.Text = "Elegir cabina";
            this.btnElegir.UseVisualStyleBackColor = true;
            this.btnElegir.Click += new System.EventHandler(this.btnElegir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cabinas disponibles";
            // 
            // dgvReco
            // 
            this.dgvReco.AllowUserToAddRows = false;
            this.dgvReco.AllowUserToDeleteRows = false;
            this.dgvReco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReco.Location = new System.Drawing.Point(668, 38);
            this.dgvReco.Name = "dgvReco";
            this.dgvReco.ReadOnly = true;
            this.dgvReco.Size = new System.Drawing.Size(421, 388);
            this.dgvReco.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Recorrido del viaje elegido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 7;
            // 
            // ElegirCabina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 562);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvReco);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnElegir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCab);
            this.Name = "ElegirCabina";
            this.Text = "ElegirCabina";
            this.Load += new System.EventHandler(this.ElegirCabina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnElegir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvReco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}