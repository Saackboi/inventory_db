﻿namespace InventarioBD
{
    partial class Consulta
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
            this.dgvBusca = new System.Windows.Forms.DataGridView();
            this.cbDepa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusca)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBusca
            // 
            this.dgvBusca.AllowUserToAddRows = false;
            this.dgvBusca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusca.Location = new System.Drawing.Point(249, 12);
            this.dgvBusca.Name = "dgvBusca";
            this.dgvBusca.Size = new System.Drawing.Size(375, 358);
            this.dgvBusca.TabIndex = 0;
            // 
            // cbDepa
            // 
            this.cbDepa.FormattingEnabled = true;
            this.cbDepa.Location = new System.Drawing.Point(112, 26);
            this.cbDepa.Name = "cbDepa";
            this.cbDepa.Size = new System.Drawing.Size(121, 21);
            this.cbDepa.TabIndex = 1;
            this.cbDepa.Text = "SELECCIONAR";
            this.cbDepa.SelectedIndexChanged += new System.EventHandler(this.cbDepa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Por departamento:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(112, 73);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Por usuario:";
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(36, 182);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(176, 61);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "TODOS LOS EQUIPOS";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(36, 115);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(176, 61);
            this.btnUsuario.TabIndex = 6;
            this.btnUsuario.Text = "POR USUARIO";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(36, 249);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(176, 61);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "IMPRIMIR INFORME";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(71, 332);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(109, 47);
            this.btnRegresar.TabIndex = 24;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 391);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDepa);
            this.Controls.Add(this.dgvBusca);
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBusca;
        private System.Windows.Forms.ComboBox cbDepa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRegresar;
    }
}