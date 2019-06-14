namespace FrbaCrucero
{
    partial class PantallaInicial
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_login_admin = new System.Windows.Forms.Button();
            this.btn_compra_reserva_pasaje = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_pago_reserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar modo de acceso al sistema";
            // 
            // btn_login_admin
            // 
            this.btn_login_admin.Location = new System.Drawing.Point(55, 107);
            this.btn_login_admin.Name = "btn_login_admin";
            this.btn_login_admin.Size = new System.Drawing.Size(119, 23);
            this.btn_login_admin.TabIndex = 1;
            this.btn_login_admin.Text = "Login del admin";
            this.btn_login_admin.UseVisualStyleBackColor = true;
            this.btn_login_admin.Click += new System.EventHandler(this.btn_login_admin_Click);
            // 
            // btn_compra_reserva_pasaje
            // 
            this.btn_compra_reserva_pasaje.Location = new System.Drawing.Point(254, 97);
            this.btn_compra_reserva_pasaje.Name = "btn_compra_reserva_pasaje";
            this.btn_compra_reserva_pasaje.Size = new System.Drawing.Size(149, 23);
            this.btn_compra_reserva_pasaje.TabIndex = 2;
            this.btn_compra_reserva_pasaje.Text = "compra/reserva de pasaje";
            this.btn_compra_reserva_pasaje.UseVisualStyleBackColor = true;
            this.btn_compra_reserva_pasaje.Click += new System.EventHandler(this.btn_compra_reserva_pasaje_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades del admin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Funcionalidades del cliente";
            // 
            // btn_pago_reserva
            // 
            this.btn_pago_reserva.Location = new System.Drawing.Point(254, 126);
            this.btn_pago_reserva.Name = "btn_pago_reserva";
            this.btn_pago_reserva.Size = new System.Drawing.Size(149, 23);
            this.btn_pago_reserva.TabIndex = 5;
            this.btn_pago_reserva.Text = "pago de reserva de pasaje";
            this.btn_pago_reserva.UseVisualStyleBackColor = true;
            this.btn_pago_reserva.Click += new System.EventHandler(this.btn_pago_reserva_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 193);
            this.Controls.Add(this.btn_pago_reserva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_compra_reserva_pasaje);
            this.Controls.Add(this.btn_login_admin);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_login_admin;
        private System.Windows.Forms.Button btn_compra_reserva_pasaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_pago_reserva;
    }
}

