using InventarioBD.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioBD.Interfaz
{
    public partial class Movimiento : Form
    {
        Conexion cn;
        Validaciones validaciones;

        public Movimiento()
        {
            InitializeComponent();
            cn = new Conexion();
            validaciones = new Validaciones();
            btnImpr.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rdbReparacion.Checked || rdbPrestamo.Checked)
            {
                // Obtener los datos del formulario
                string motivo = rdbReparacion.Checked ? "Reparacion" : "Prestamo";
                string lugar = txtLugar.Text;
                string observacion = txtObservacion.Text;

                // Validaciones para el textbox de observacion
                if (rdbReparacion.Checked && !validaciones.validarEntradaString(txtObservacion))
                {
                    return;
                }

                if (validaciones.ValidacionPlaca(txtPlaca))
                {
                    // Insertar los datos en la base de datos
                    cn.registrarMovimiento(txtPlaca.Text, motivo, lugar, observacion);
                    MessageBox.Show("Movimiento registrado exitosamente");

                    // Limpiar los campos del formulario
                    txtLugar.Clear();
                    txtObservacion.Clear();
                    rdbReparacion.Checked = false;
                    rdbPrestamo.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un motivo.", "Error de validación");
            }
        }

        private void btnImpr_Click(object sender, EventArgs e)
        {
            // Implementar la lógica para generar el PDF
            // Ejemplo:
            // using iTextSharp;
            // ...
            // Crear el PDF
            // Guardar el PDF
        }

        // Validaciones para el textbox de observacion
        private void rbReparacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReparacion.Checked)
            {
                txtObservacion.Enabled = true;
            }
            else
            {
                txtObservacion.Enabled = false;
                txtObservacion.Clear();
            }
        }

        // Valida para aparecer el textbox de observacion
        private void rbPrestamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPrestamo.Checked)
            {
                txtObservacion.Enabled = false;
                txtObservacion.Clear();
            }
        }
    }
}