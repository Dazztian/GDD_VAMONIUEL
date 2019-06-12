namespace FrbaCrucero.AbmCrucero
{
    partial class CrearCrucero
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCabinas = new System.Windows.Forms.Button();
            this.dataGridViewCabinas = new System.Windows.Forms.DataGridView();
            this.btnCabina = new System.Windows.Forms.Button();
            this.txtRecargoCabina = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPisoCabina = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidadCabinas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTipoCabina = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo";
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(294, 23);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMarca.TabIndex = 2;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(294, 55);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(121, 20);
            this.txtModelo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiarCabinas);
            this.groupBox1.Controls.Add(this.dataGridViewCabinas);
            this.groupBox1.Controls.Add(this.btnCabina);
            this.groupBox1.Controls.Add(this.txtRecargoCabina);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPisoCabina);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCantidadCabinas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxTipoCabina);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 188);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabinas";
            // 
            // btnLimpiarCabinas
            // 
            this.btnLimpiarCabinas.Location = new System.Drawing.Point(611, 152);
            this.btnLimpiarCabinas.Name = "btnLimpiarCabinas";
            this.btnLimpiarCabinas.Size = new System.Drawing.Size(94, 23);
            this.btnLimpiarCabinas.TabIndex = 10;
            this.btnLimpiarCabinas.Text = "Limpiar cabinas";
            this.btnLimpiarCabinas.UseVisualStyleBackColor = true;
            this.btnLimpiarCabinas.Click += new System.EventHandler(this.btnLimpiarCabinas_Click);
            // 
            // dataGridViewCabinas
            // 
            this.dataGridViewCabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCabinas.Location = new System.Drawing.Point(269, 26);
            this.dataGridViewCabinas.Name = "dataGridViewCabinas";
            this.dataGridViewCabinas.ReadOnly = true;
            this.dataGridViewCabinas.Size = new System.Drawing.Size(436, 111);
            this.dataGridViewCabinas.TabIndex = 9;
            // 
            // btnCabina
            // 
            this.btnCabina.Location = new System.Drawing.Point(151, 152);
            this.btnCabina.Name = "btnCabina";
            this.btnCabina.Size = new System.Drawing.Size(75, 23);
            this.btnCabina.TabIndex = 8;
            this.btnCabina.Text = "Agregar cabinas";
            this.btnCabina.UseVisualStyleBackColor = true;
            this.btnCabina.Click += new System.EventHandler(this.btnCabina_Click);
            // 
            // txtRecargoCabina
            // 
            this.txtRecargoCabina.Location = new System.Drawing.Point(105, 117);
            this.txtRecargoCabina.Name = "txtRecargoCabina";
            this.txtRecargoCabina.Size = new System.Drawing.Size(121, 20);
            this.txtRecargoCabina.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Reacargo(%)";
            // 
            // txtPisoCabina
            // 
            this.txtPisoCabina.Location = new System.Drawing.Point(105, 85);
            this.txtPisoCabina.Name = "txtPisoCabina";
            this.txtPisoCabina.Size = new System.Drawing.Size(121, 20);
            this.txtPisoCabina.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Piso";
            // 
            // txtCantidadCabinas
            // 
            this.txtCantidadCabinas.Location = new System.Drawing.Point(105, 55);
            this.txtCantidadCabinas.Name = "txtCantidadCabinas";
            this.txtCantidadCabinas.Size = new System.Drawing.Size(121, 20);
            this.txtCantidadCabinas.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cantidad";
            // 
            // comboBoxTipoCabina
            // 
            this.comboBoxTipoCabina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCabina.FormattingEnabled = true;
            this.comboBoxTipoCabina.Location = new System.Drawing.Point(105, 26);
            this.comboBoxTipoCabina.Name = "comboBoxTipoCabina";
            this.comboBoxTipoCabina.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoCabina.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(566, 309);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CrearCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 344);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.comboBoxMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrearCrucero";
            this.Text = "CrearCrucero";
            this.Load += new System.EventHandler(this.CrearCrucero_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewCabinas;
        private System.Windows.Forms.Button btnCabina;
        private System.Windows.Forms.TextBox txtRecargoCabina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPisoCabina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidadCabinas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTipoCabina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiarCabinas;
    }
}