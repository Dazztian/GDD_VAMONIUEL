﻿namespace FrbaCrucero.GeneracionViaje
{
    partial class Form_generar_viaje
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
            this.dgv_cruceros_disponibles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_recorridos_disponibles = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_cruceros = new System.Windows.Forms.ComboBox();
            this.cmb_recorridos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cruceros_disponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_recorridos_disponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cruceros_disponibles
            // 
            this.dgv_cruceros_disponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cruceros_disponibles.Location = new System.Drawing.Point(35, 68);
            this.dgv_cruceros_disponibles.Name = "dgv_cruceros_disponibles";
            this.dgv_cruceros_disponibles.Size = new System.Drawing.Size(328, 150);
            this.dgv_cruceros_disponibles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cruceros disponibles";
            // 
            // dtp_fecha_inicio
            // 
            this.dtp_fecha_inicio.Location = new System.Drawing.Point(75, 270);
            this.dtp_fecha_inicio.Name = "dtp_fecha_inicio";
            this.dtp_fecha_inicio.Size = new System.Drawing.Size(240, 20);
            this.dtp_fecha_inicio.TabIndex = 2;
            this.dtp_fecha_inicio.ValueChanged += new System.EventHandler(this.dtp_actualizarCrucerosDisponibles);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccionar fecha inicio";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Recorridos  disponibles";
            // 
            // dgv_recorridos_disponibles
            // 
            this.dgv_recorridos_disponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_recorridos_disponibles.Location = new System.Drawing.Point(412, 68);
            this.dgv_recorridos_disponibles.Name = "dgv_recorridos_disponibles";
            this.dgv_recorridos_disponibles.Size = new System.Drawing.Size(314, 150);
            this.dgv_recorridos_disponibles.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Generar Viaje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_generar_viaje);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seleccionar fecha fin";
            // 
            // dtp_fecha_fin
            // 
            this.dtp_fecha_fin.Location = new System.Drawing.Point(75, 352);
            this.dtp_fecha_fin.Name = "dtp_fecha_fin";
            this.dtp_fecha_fin.Size = new System.Drawing.Size(240, 20);
            this.dtp_fecha_fin.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seleccionar id recorrido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Seleccionar id crucero";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cmb_cruceros
            // 
            this.cmb_cruceros.FormattingEnabled = true;
            this.cmb_cruceros.Location = new System.Drawing.Point(498, 351);
            this.cmb_cruceros.Name = "cmb_cruceros";
            this.cmb_cruceros.Size = new System.Drawing.Size(121, 21);
            this.cmb_cruceros.TabIndex = 13;
            // 
            // cmb_recorridos
            // 
            this.cmb_recorridos.FormattingEnabled = true;
            this.cmb_recorridos.Location = new System.Drawing.Point(498, 273);
            this.cmb_recorridos.Name = "cmb_recorridos";
            this.cmb_recorridos.Size = new System.Drawing.Size(121, 21);
            this.cmb_recorridos.TabIndex = 14;
            this.cmb_recorridos.SelectedValueChanged += new System.EventHandler(this.cmb_seleccionar_recorrido);
            // 
            // Form_generar_viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 479);
            this.Controls.Add(this.cmb_recorridos);
            this.Controls.Add(this.cmb_cruceros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp_fecha_fin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_recorridos_disponibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_fecha_inicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_cruceros_disponibles);
            this.Name = "Form_generar_viaje";
            this.Text = "Generar Viaje";
            this.Load += new System.EventHandler(this.FormGenerarViajes);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cruceros_disponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_recorridos_disponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cruceros_disponibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_fecha_inicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_recorridos_disponibles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_cruceros;
        private System.Windows.Forms.ComboBox cmb_recorridos;
    }
}