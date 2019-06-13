namespace FrbaCrucero.PagoReserva
{
    partial class pagoReserva
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
            this.btn_pago_de_reserva = new System.Windows.Forms.Button();
            this.txt_codigo_reserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_mostrar_datos = new System.Windows.Forms.Button();
            this.dgv_viaje = new System.Windows.Forms.DataGridView();
            this.dgv_crucero = new System.Windows.Forms.DataGridView();
            this.dgv_pasaje = new System.Windows.Forms.DataGridView();
            this.dgv_cliente = new System.Windows.Forms.DataGridView();
            this.dgv_reserva = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_viaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_crucero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pasaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reserva)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pago_de_reserva
            // 
            this.btn_pago_de_reserva.Location = new System.Drawing.Point(120, 407);
            this.btn_pago_de_reserva.Name = "btn_pago_de_reserva";
            this.btn_pago_de_reserva.Size = new System.Drawing.Size(109, 69);
            this.btn_pago_de_reserva.TabIndex = 0;
            this.btn_pago_de_reserva.Text = "Pagar  Reserva";
            this.btn_pago_de_reserva.UseVisualStyleBackColor = true;
            this.btn_pago_de_reserva.Click += new System.EventHandler(this.btn_pago_de_reserva_Click);
            // 
            // txt_codigo_reserva
            // 
            this.txt_codigo_reserva.Location = new System.Drawing.Point(53, 116);
            this.txt_codigo_reserva.Name = "txt_codigo_reserva";
            this.txt_codigo_reserva.Size = new System.Drawing.Size(214, 20);
            this.txt_codigo_reserva.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese codigo de reserva a confirmar/pagar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Datos asociados a la reserva";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Viaje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Crucero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Pasaje";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Cliente";
            // 
            // btn_mostrar_datos
            // 
            this.btn_mostrar_datos.Location = new System.Drawing.Point(53, 175);
            this.btn_mostrar_datos.Name = "btn_mostrar_datos";
            this.btn_mostrar_datos.Size = new System.Drawing.Size(214, 52);
            this.btn_mostrar_datos.TabIndex = 8;
            this.btn_mostrar_datos.Text = "Mostrar datos asociadas a la reserva";
            this.btn_mostrar_datos.UseVisualStyleBackColor = true;
            this.btn_mostrar_datos.Click += new System.EventHandler(this.mostrar_datos_reserva);
            // 
            // dgv_viaje
            // 
            this.dgv_viaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_viaje.Location = new System.Drawing.Point(360, 43);
            this.dgv_viaje.Name = "dgv_viaje";
            this.dgv_viaje.Size = new System.Drawing.Size(383, 84);
            this.dgv_viaje.TabIndex = 9;
            // 
            // dgv_crucero
            // 
            this.dgv_crucero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_crucero.Location = new System.Drawing.Point(360, 160);
            this.dgv_crucero.Name = "dgv_crucero";
            this.dgv_crucero.Size = new System.Drawing.Size(383, 84);
            this.dgv_crucero.TabIndex = 10;
            // 
            // dgv_pasaje
            // 
            this.dgv_pasaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pasaje.Location = new System.Drawing.Point(360, 276);
            this.dgv_pasaje.Name = "dgv_pasaje";
            this.dgv_pasaje.Size = new System.Drawing.Size(383, 84);
            this.dgv_pasaje.TabIndex = 11;
            // 
            // dgv_cliente
            // 
            this.dgv_cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cliente.Location = new System.Drawing.Point(360, 392);
            this.dgv_cliente.Name = "dgv_cliente";
            this.dgv_cliente.Size = new System.Drawing.Size(383, 84);
            this.dgv_cliente.TabIndex = 12;
            // 
            // dgv_reserva
            // 
            this.dgv_reserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_reserva.Location = new System.Drawing.Point(12, 276);
            this.dgv_reserva.Name = "dgv_reserva";
            this.dgv_reserva.Size = new System.Drawing.Size(307, 84);
            this.dgv_reserva.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Datos de la reserva";
            // 
            // pagoReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 508);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgv_reserva);
            this.Controls.Add(this.dgv_cliente);
            this.Controls.Add(this.dgv_pasaje);
            this.Controls.Add(this.dgv_crucero);
            this.Controls.Add(this.dgv_viaje);
            this.Controls.Add(this.btn_mostrar_datos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_codigo_reserva);
            this.Controls.Add(this.btn_pago_de_reserva);
            this.Name = "pagoReserva";
            this.Text = "Pago de reservas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_viaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_crucero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pasaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pago_de_reserva;
        private System.Windows.Forms.TextBox txt_codigo_reserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_mostrar_datos;
        private System.Windows.Forms.DataGridView dgv_viaje;
        private System.Windows.Forms.DataGridView dgv_crucero;
        private System.Windows.Forms.DataGridView dgv_pasaje;
        private System.Windows.Forms.DataGridView dgv_cliente;
        private System.Windows.Forms.DataGridView dgv_reserva;
        private System.Windows.Forms.Label label7;
    }
}