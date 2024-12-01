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

namespace InventarioBD
{
    public partial class Usuarios : Form
    {
        Validaciones va;
        Conexion cn;
        public Usuarios()
        {
            InitializeComponent();
            va = new Validaciones();
            cn = new Conexion();
            cn.cargarUsuario(dgvUsuario);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre en el campo.", "Error de entrada");
                return;
            }
            else if (!Regex.IsMatch(txtNombre.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Debe ingresar un nombre válido.", "Error de entrada");
                return;
            }
            else
            {
                cn.registrarUsuario(txtNombre.Text, dgvUsuario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cn.eliminarUsuario(dgvUsuario);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != String.Empty)
            {
                cn.modificarUsuario(txtNombre.Text, dgvUsuario);
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre.", "Error de entrada");
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != String.Empty)
            {
                if (cn.buscarUsuario(txtNombre.Text))
                {
                    MessageBox.Show("El usuario se encuentra registrado.", "Registro encontrado");
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el registro.", "Registro no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre.", "Error de entrada");
            }
        }
    }
}
