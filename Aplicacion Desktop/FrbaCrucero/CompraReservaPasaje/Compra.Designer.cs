namespace FrbaCrucero.CompraReservaPasaje
{
    partial class Compra
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
            this.comboBoxPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Confirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPago
            // 
            this.comboBoxPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPago.FormattingEnabled = true;
            this.comboBoxPago.Location = new System.Drawing.Point(82, 58);
            this.comboBoxPago.Name = "comboBoxPago";
            this.comboBoxPago.Size = new System.Drawing.Size(174, 21);
            this.comboBoxPago.TabIndex = 0;
            this.comboBoxPago.SelectedIndexChanged += new System.EventHandler(this.comboBoxPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Medio de pago";
            // 
            // Confirmar
            // 
            this.Confirmar.Location = new System.Drawing.Point(112, 116);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(75, 23);
            this.Confirmar.TabIndex = 2;
            this.Confirmar.Text = "Aceptar";
            this.Confirmar.UseVisualStyleBackColor = true;
            this.Confirmar.Click += new System.EventHandler(this.Confirmar_Click);
            // 
            // Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 176);
            this.Controls.Add(this.Confirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPago);
            this.Name = "Compra";
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.Compra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Confirmar;
    }
}