namespace FrbaCrucero.AbmCrucero
{
    partial class BajaDefinitiva
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
            this.btnBaja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerBaja = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnBaja
            // 
            this.btnBaja.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBaja.Location = new System.Drawing.Point(167, 131);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 0;
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione fecha de baja definitiva";
            // 
            // dateTimePickerBaja
            // 
            this.dateTimePickerBaja.Location = new System.Drawing.Point(42, 78);
            this.dateTimePickerBaja.Name = "dateTimePickerBaja";
            this.dateTimePickerBaja.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBaja.TabIndex = 2;
            // 
            // BajaDefinitiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 183);
            this.Controls.Add(this.dateTimePickerBaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBaja);
            this.Name = "BajaDefinitiva";
            this.Text = "BajaDefinitiva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaja;
    }
}