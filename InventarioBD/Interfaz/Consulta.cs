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
    }
}
