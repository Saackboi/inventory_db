using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using InventarioBD.Clases;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

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
            rdbPrestamo.CheckedChanged += rdbPrestamo_CheckedChanged;
            rdbReparacion.CheckedChanged += rdbReparacion_CheckedChanged;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rdbReparacion.Checked || rdbPrestamo.Checked)
            {
                // Obtener los datos del formulario
                string motivo = rdbReparacion.Checked ? "Reparacion" : "Prestamo";
                string lugar = txtLugar.Text;
                string observacion = txtObservacion.Text;

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
            // Ruta donde se guardará el PDF
            string rutaPDF= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReporteMovimiento.pdf"); ;

            // Obtener los datos de la tabla movimiento_equipo
            DataTable movimientoEquipoDataTable = cn.ObtenerMovimientoEquipo(); // Asegúrate de implementar este método en tu clase Conexion

            try
            {
                // Crear un documento PDF
                using (PdfWriter writer = new PdfWriter(rutaPDF))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        iText.Layout.Document document = new iText.Layout.Document(pdf);

                        // Título del PDF
                        document.Add(new Paragraph("Reporte de Equipos")
                            .SetFontSize(18)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                            .SetFontSize(12)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                        document.Add(new Paragraph(" ").SetFontSize(12)); // Espacio adicional

                        // Agregar el párrafo proporcionado
                        string contenido = "Este reporte detalla los movimientos de equipos en el sistema de control de inventarios durante el período solicitado, " +
                                           "incluyendo información sobre equipos en reparación y préstamos. Los datos presentados reflejan el estado actual de " +
                                           "los equipos, sus ubicaciones, y las razones de los movimientos, con el fin de mantener un registro actualizado y " +
                                           "organizado para la gestión y supervisión de los recursos tecnológicos. El seguimiento adecuado de estos movimientos " +
                                           "es fundamental para asegurar el correcto uso y mantenimiento de los equipos, así como para facilitar la auditoría " +
                                           "interna de los mismos. Cualquier observación adicional sobre el estado o situación de los equipos ha sido registrada " +
                                           "en el campo correspondiente de cada movimiento.";

                        document.Add(new Paragraph(contenido));

                        // Tabla en el PDF
                        Table table = new Table(movimientoEquipoDataTable.Columns.Count, true);

                        // Agregar encabezados de la tabla
                        foreach (DataColumn column in movimientoEquipoDataTable.Columns)
                        {
                            table.AddHeaderCell(column.ColumnName);
                        }

                        // Agregar filas con datos
                        foreach (DataRow row in movimientoEquipoDataTable.Rows)
                        {
                            foreach (DataColumn column in movimientoEquipoDataTable.Columns)
                            {
                                table.AddCell(row[column].ToString());
                            }
                        }

                        document.Add(table);

                        // Espacio para firmar
                        document.Add(new Paragraph(" ").SetFontSize(12)); // Espacio adicional
                        document.Add(new Paragraph("Firma: ____________________").SetFontSize(12));
                        document.Add(new Paragraph(" ").SetFontSize(12)); // Espacio adicional

                        // Nombre y fecha
                        document.Add(new Paragraph($"Nombre: ____________________").SetFontSize(12));
                        document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}").SetFontSize(12));

                        document.Close();
                    }
                }

                MessageBox.Show($"PDF generado exitosamente en: {rutaPDF}", "Éxito");
                // Abrir el PDF después de generarlo (opcional)
                System.Diagnostics.Process.Start("explorer.exe", rutaPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF: {ex.Message}", "Error");
                Console.WriteLine(ex.ToString());
            }
    }


        // Validaciones para el radiobutton
        private void rdbReparacion_CheckedChanged(object sender, EventArgs e)
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
        private void rdbPrestamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPrestamo.Checked)
            {
                txtObservacion.Enabled = false;
                txtObservacion.Clear();
            }
            else
            {
                txtObservacion.Enabled = true;
                txtObservacion.Clear();
            }
        }

    }
}