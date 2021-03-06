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
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_id_recorrido = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_id_crucero = new System.Windows.Forms.Label();
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
            this.dgv_cruceros_disponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clicl_crucero_elegido);
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
            this.dgv_recorridos_disponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lbl_click_recorrido);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(495, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Recorrido Seleccionado";
            // 
            // lbl_id_recorrido
            // 
            this.lbl_id_recorrido.AutoSize = true;
            this.lbl_id_recorrido.Location = new System.Drawing.Point(495, 277);
            this.lbl_id_recorrido.Name = "lbl_id_recorrido";
            this.lbl_id_recorrido.Size = new System.Drawing.Size(0, 13);
            this.lbl_id_recorrido.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Crucero Seleccionado";
            // 
            // lbl_id_crucero
            // 
            this.lbl_id_crucero.AutoSize = true;
            this.lbl_id_crucero.Location = new System.Drawing.Point(495, 347);
            this.lbl_id_crucero.Name = "lbl_id_crucero";
            this.lbl_id_crucero.Size = new System.Drawing.Size(0, 13);
            this.lbl_id_crucero.TabIndex = 18;
            // 
            // Form_generar_viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 479);
            this.Controls.Add(this.lbl_id_crucero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_id_recorrido);
            this.Controls.Add(this.label7);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_id_recorrido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_id_crucero;
    }
}