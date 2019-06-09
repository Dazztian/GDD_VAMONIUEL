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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTramos
            // 
            this.dataGridViewTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTramos.Location = new System.Drawing.Point(12, 46);
            this.dataGridViewTramos.Name = "dataGridViewTramos";
            this.dataGridViewTramos.Size = new System.Drawing.Size(366, 150);
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
            // ModificarRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 261);
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
    }
}