using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioBD.Clases;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace InventarioBD
{
    public partial class Consulta : Form
    {
        Conexion cn;
        public Consulta()
        {
            InitializeComponent();
            cn = new Conexion();
            cn.cargarDepa(cbDepa);
            cbDepa.SelectedItem = null;
            cbDepa.Text = "SELECCIONAR";
        }

        private void cbDepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepa.SelectedItem  != null)
            {
                cn.busquedaPorDepa(((DataRowView)cbDepa.SelectedItem)["nombre"].ToString(), dgvBusca);
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            cn.cargarEquipos(dgvBusca);
        }

        private void btnPlaca_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar el campo de la placa.", "Error de entrada");
                txtPlaca.Focus();
                return;
            }
            else
            {
               cn.busquedaPorPlaca(txtPlaca.Text, dgvBusca);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvBusca.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Información");
                return;
            }

            // Ruta donde se guardará el PDF
            string rutaPDF = @"C:\Users\clash\OneDrive\Documentos\BNE\MODULOS\Software\IV Semestre\Programas\InventarioBD\Reporte.pdf";

            try
            {
                // Crear un documento PDF
                using (PdfWriter writer = new PdfWriter(rutaPDF))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        // Título del PDF
                        document.Add(new Paragraph("Reporte de Equipos").SetFontSize(18).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));

                        // Tabla en el PDF
                        Table table = new Table(dgvBusca.Columns.Count, true);

                        // Agregar encabezados de la tabla
                        foreach (DataGridViewColumn column in dgvBusca.Columns)
                        {
                            table.AddHeaderCell(column.HeaderText);
                        }

                        // Agregar filas con datos
                        foreach (DataGridViewRow row in dgvBusca.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }

                        document.Add(table);
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
    }
}
