using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioBD.Clases;

namespace InventarioBD
{
    public partial class Equipos : Form
    {
        Validaciones va;
        Conexion cn;
        public Equipos()
        {
            InitializeComponent();
            va = new Validaciones();
            cn = new Conexion();
            cn.cargarDepa(cbDepa);
            cbDepa.SelectedItem = null;
            cbDepa.Text = "SELECCIONAR";
            cn.cargarEquipos(dgvEquipos);
            cn.cargarUsuario(cbPersona);
            cbPersona.SelectedItem = null;
            cbPersona.Text = "SELECCIONAR";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            registroEquipo("Registro");
        }


        //Desactiva la escritura en el combobox
        private void cbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //valida para aparecer el textbox adicional
        private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNombre.SelectedItem != null && cbNombre.SelectedItem.Equals("Otro"))
            {
                txtOtro.Visible = true;
            }
            else
            {
                txtOtro1.Visible = false;
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedItem != null && cbEstado.SelectedItem.Equals("Otro"))
            {
                txtOtro1.Visible = true;
            }
            else
            {
                txtOtro1.Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cn.eliminarEquipo(dgvEquipos);
            limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            registroEquipo("Modificar");
        }

        private void registroEquipo(string caso)
        {

            if (va.validarEntradas(txtPlaca, cbNombre, txtModelo, txtSerie, cbDepa, cbEstado, cbPersona, caso))
            {
                string placa = txtPlaca.Text.ToUpper();
                string nombre = cbNombre.SelectedItem.ToString().ToUpper();
                string modelo = txtModelo.Text.ToUpper();
                string serie = txtSerie.Text.ToUpper();
                string depa = ((DataRowView)cbDepa.SelectedItem)["nombre"].ToString();
                string estado = cbEstado.SelectedItem.ToString().ToUpper();
                string persona = ((DataRowView)cbPersona.SelectedItem)["nombre"].ToString();

                //En caso de seleccionar Otro aparece un textbox
                if (cbNombre.SelectedItem.Equals("Otro"))
                {
                    if (!va.entradaOtro(txtOtro).Equals(""))
                    {
                        nombre = va.entradaOtro(txtOtro);
                    }
                    else
                    {
                        return;
                    }

                }

                if (cbEstado.SelectedItem.Equals("Otro"))
                {
                    if (!va.entradaOtro(txtOtro1).Equals(""))
                    {
                        estado = va.entradaOtro(txtOtro1);
                    }
                    else
                    {
                        return;
                    }

                }

                if(caso == "Registro")
                {
                    cn.registrarEquipo(placa, nombre, modelo, serie, depa, estado, persona, dgvEquipos);
                } else if (caso == "Modificar")
                {
                    
                    if (cn.modificarEquipo(nombre, modelo, serie, depa, estado, persona, dgvEquipos))
                    {
                        limpiar();
                        txtPlaca.Enabled = true;
                        txtSerie.Enabled = true;
                    }
                }
            }
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dgvEquipos.Rows[e.RowIndex];

                // Llenar los controles con los datos de la fila seleccionada
                txtPlaca.Text = row.Cells["id_equipo"].Value.ToString();
                txtPlaca.Enabled = false;
                cbNombre.Text = row.Cells["nombre"].Value.ToString();
                txtModelo.Text = row.Cells["modelo"].Value.ToString();
                txtSerie.Text = row.Cells["serie"].Value.ToString();
                txtSerie.Enabled = false;
                cbDepa.Text = row.Cells["id_departamento"].Value.ToString();
                cbEstado.Text = row.Cells["estado"].Value.ToString();
                cbPersona.Text = row.Cells["id_usuario"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtPlaca.Clear();
            txtPlaca.Enabled = true;
            txtModelo.Clear();
            txtSerie.Clear();
            txtSerie.Enabled = true;
            cbNombre.SelectedItem = null;
            cbNombre.Text = "SELECCIONAR";
            cbDepa.SelectedItem = null;
            cbDepa.Text = "SELECCIONAR";
            cbEstado.SelectedItem = null;
            cbEstado.Text = "SELECCIONAR";
            cbPersona.SelectedItem = null;
            cbPersona.Text = "SELECCIONAR";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != String.Empty)
            {
                if (cn.validarUnicidadPlaca(txtPlaca.Text))
                {
                    MessageBox.Show("El equipo está registrado.", "Registro encontrado");
                }
                else
                {
                    MessageBox.Show("El equipo no fue encontrado.", "Registro encontrado");
                    txtPlaca.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar la placa del equipo para realizar la búsqueda.", "Error de entrada");
                txtPlaca.Focus();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
