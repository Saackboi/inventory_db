﻿namespace InventarioBD
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEquipos = new System.Windows.Forms.Button();
            this.btnDepartamentos = new System.Windows.Forms.Button();
            this.btnConsultas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEquipos
            // 
            this.btnEquipos.Location = new System.Drawing.Point(120, 39);
            this.btnEquipos.Name = "btnEquipos";
            this.btnEquipos.Size = new System.Drawing.Size(164, 23);
            this.btnEquipos.TabIndex = 0;
            this.btnEquipos.Text = "GESTIÓN DE EQUIPOS";
            this.btnEquipos.UseVisualStyleBackColor = true;
            this.btnEquipos.Click += new System.EventHandler(this.btnEquipos_Click);
            // 
            // btnDepartamentos
            // 
            this.btnDepartamentos.Location = new System.Drawing.Point(111, 108);
            this.btnDepartamentos.Name = "btnDepartamentos";
            this.btnDepartamentos.Size = new System.Drawing.Size(183, 23);
            this.btnDepartamentos.TabIndex = 1;
            this.btnDepartamentos.Text = "GESTIÓN DE DEPARTAMENTOS";
            this.btnDepartamentos.UseVisualStyleBackColor = true;
            this.btnDepartamentos.Click += new System.EventHandler(this.btnDepartamentos_Click);
            // 
            // btnConsultas
            // 
            this.btnConsultas.Location = new System.Drawing.Point(120, 213);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(164, 23);
            this.btnConsultas.TabIndex = 2;
            this.btnConsultas.Text = "CONSULTAS DE EQUIPOS";
            this.btnConsultas.UseVisualStyleBackColor = true;
            this.btnConsultas.Click += new System.EventHandler(this.btnConsultas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(108, 161);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(183, 23);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "GESTIÓN DE USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Location = new System.Drawing.Point(108, 258);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(183, 23);
            this.btnMovimientos.TabIndex = 4;
            this.btnMovimientos.Text = "GESTION MOVIMIENTOS";
            this.btnMovimientos.UseVisualStyleBackColor = true;
            this.btnMovimientos.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 344);
            this.Controls.Add(this.btnMovimientos);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnConsultas);
            this.Controls.Add(this.btnDepartamentos);
            this.Controls.Add(this.btnEquipos);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEquipos;
        private System.Windows.Forms.Button btnDepartamentos;
        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnMovimientos;
    }
}

