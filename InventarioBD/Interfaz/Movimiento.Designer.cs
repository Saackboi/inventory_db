namespace InventarioBD.Interfaz
{
    partial class Movimiento
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
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnImpr = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdbPrestamo = new System.Windows.Forms.RadioButton();
            this.rdbReparacion = new System.Windows.Forms.RadioButton();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblPlaceMovement = new System.Windows.Forms.Label();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.gpbMotivo = new System.Windows.Forms.GroupBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.gpbMotivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(18, 226);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(192, 55);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnImpr
            // 
            this.btnImpr.Location = new System.Drawing.Point(239, 226);
            this.btnImpr.Name = "btnImpr";
            this.btnImpr.Size = new System.Drawing.Size(192, 55);
            this.btnImpr.TabIndex = 1;
            this.btnImpr.Text = "Imprimir Reporte";
            this.btnImpr.UseVisualStyleBackColor = true;
            this.btnImpr.Click += new System.EventHandler(this.btnImpr_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(14, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(218, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Movimiento de equipo";
            // 
            // rdbPrestamo
            // 
            this.rdbPrestamo.AutoSize = true;
            this.rdbPrestamo.Location = new System.Drawing.Point(6, 42);
            this.rdbPrestamo.Name = "rdbPrestamo";
            this.rdbPrestamo.Size = new System.Drawing.Size(69, 17);
            this.rdbPrestamo.TabIndex = 3;
            this.rdbPrestamo.TabStop = true;
            this.rdbPrestamo.Text = "Prestamo";
            this.rdbPrestamo.UseVisualStyleBackColor = true;
            // 
            // rdbReparacion
            // 
            this.rdbReparacion.AutoSize = true;
            this.rdbReparacion.Location = new System.Drawing.Point(6, 19);
            this.rdbReparacion.Name = "rdbReparacion";
            this.rdbReparacion.Size = new System.Drawing.Size(80, 17);
            this.rdbReparacion.TabIndex = 4;
            this.rdbReparacion.TabStop = true;
            this.rdbReparacion.Text = "Reparacion";
            this.rdbReparacion.UseVisualStyleBackColor = true;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(15, 82);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 5;
            this.lblMotivo.Text = "Motivo:";
            // 
            // lblPlaceMovement
            // 
            this.lblPlaceMovement.AutoSize = true;
            this.lblPlaceMovement.Location = new System.Drawing.Point(31, 203);
            this.lblPlaceMovement.Name = "lblPlaceMovement";
            this.lblPlaceMovement.Size = new System.Drawing.Size(105, 13);
            this.lblPlaceMovement.TabIndex = 6;
            this.lblPlaceMovement.Text = "Lugar de movimiento";
            // 
            // txtLugar
            // 
            this.txtLugar.Location = new System.Drawing.Point(153, 200);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(173, 20);
            this.txtLugar.TabIndex = 7;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Location = new System.Drawing.Point(186, 70);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(67, 13);
            this.lblObservacion.TabIndex = 8;
            this.lblObservacion.Text = "Observacion";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Enabled = false;
            this.txtObservacion.Location = new System.Drawing.Point(172, 93);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(220, 89);
            this.txtObservacion.TabIndex = 9;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(172, 47);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(100, 20);
            this.txtPlaca.TabIndex = 10;
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(31, 47);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(137, 13);
            this.lblEquipo.TabIndex = 11;
            this.lblEquipo.Text = "Ingrese la placa del equipo:";
            // 
            // gpbMotivo
            // 
            this.gpbMotivo.Controls.Add(this.rdbPrestamo);
            this.gpbMotivo.Controls.Add(this.rdbReparacion);
            this.gpbMotivo.Location = new System.Drawing.Point(12, 82);
            this.gpbMotivo.Name = "gpbMotivo";
            this.gpbMotivo.Size = new System.Drawing.Size(116, 71);
            this.gpbMotivo.TabIndex = 12;
            this.gpbMotivo.TabStop = false;
            this.gpbMotivo.Text = "Motivo";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(322, 20);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(109, 47);
            this.btnRegresar.TabIndex = 24;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Movimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 303);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.gpbMotivo);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.txtLugar);
            this.Controls.Add(this.lblPlaceMovement);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnImpr);
            this.Controls.Add(this.btnRegistrar);
            this.Name = "Movimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento";
            this.gpbMotivo.ResumeLayout(false);
            this.gpbMotivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnImpr;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdbPrestamo;
        private System.Windows.Forms.RadioButton rdbReparacion;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblPlaceMovement;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.GroupBox gpbMotivo;
        private System.Windows.Forms.Button btnRegresar;
    }
}