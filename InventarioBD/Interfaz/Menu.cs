using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioBD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            Equipos eq = new Equipos();
            eq.Show();
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            Departamentos de = new Departamentos();
            de.Show();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            Consulta con = new Consulta();
            con.Show();
        }
    }
}
