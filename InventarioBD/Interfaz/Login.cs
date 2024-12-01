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

namespace InventarioBD.Interfaz
{
    public partial class Login : Form
    {
        String [] us1;
        public Login()
        {
            InitializeComponent();
            us1 = new String[2];
            us1[0] = "user"; us1[1] = "1234";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty || txtContra.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos.");
                return;
            }
            else if (txtUsuario.Text != us1[0] && txtUsuario.Text != us1[1])
            {
                MessageBox.Show("Usuario o contraseña incorrecta.");
                return;
            } 
            else 
            {
                Menu me = new Menu();
                me.Show();
            }
        }
    }
}
