using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using InventarioBD.Clases;

namespace InventarioBD
{
    public class Validaciones
    {
        Conexion cn;
        public Validaciones()
        {
            cn = new Conexion();
        }

        //Esto valida que las entradas esten todas ingresadas, valida que el modelo, serie y persona esten ingresados en un formato válido
        public bool validarEntradas(TextBox txtPlaca, ComboBox cbNombre, TextBox txtModelo, TextBox txtSerie, ComboBox cbDepa, ComboBox cbEstado, ComboBox cbPersona, string caso)
        {
            if (txtPlaca.Text == String.Empty || cbNombre.SelectedItem == null || txtModelo.Text == String.Empty || txtSerie.Text == String.Empty || cbDepa.SelectedItem == null || cbEstado.SelectedItem == null || cbPersona.SelectedItem == null)
            {
                MessageBox.Show("Es obligatorio llenar todos los campos.", "Campos Obligatorios");
                return false;
            //Validaciones para la placa
            } else if (!Regex.IsMatch(txtPlaca.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("No se aceptan carácteres especiales en la placa", "Error de entrada");
                return false;

            } else if (txtPlaca.Text.Length < 5)
            {
                MessageBox.Show("Placa no puede ser tan corta", "Error de entrada");
                return false;

            } else if (cn.validarUnicidadPlaca(txtPlaca.Text.ToUpper()) && caso == "Registro")
            {
                MessageBox.Show("La placa ingresada ya se encuentra registrada", "Error de entrada");
                return false;
                //Validaciones para el modelo
            } else if (!Regex.IsMatch(txtModelo.Text, "^[a-zA-Z0-9]+$"))
            {
               MessageBox.Show("No se aceptan carácteres especiales en el modelo", "Error de entrada");
                txtModelo.Focus();
                return false;

            }  else if (txtModelo.Text.Length < 5)
            {
                MessageBox.Show("Modelo no puede ser tan corto", "Error de entrada");
                txtModelo.Focus();
                return false;
             //Validaciones para la serie
            } else if (!Regex.IsMatch(txtSerie.Text, "^[a-zA-Z0-9]+$"))
            {
               MessageBox.Show("No se aceptan carácteres especiales en la serie", "Error de entrada");
                txtSerie.Focus();
                return false;

            } else if (txtSerie.Text.Length < 5)
            {
                MessageBox.Show("Serie no puede ser tan corta", "Error de entrada");
                txtSerie.Focus();
                return false;

            } else if (cn.validarUnicidadSerie(txtSerie.Text.ToUpper()) && caso == "Registro")
            {
                MessageBox.Show("La serie ingresada ya se encuentra registrada.", "Error de duplicidad");
                txtSerie.Focus();
                return false;
            }

            return true;
        }


        //Utilizados para validad los textbox de "Otros"
        private bool validarEntradaString(TextBox txt)
        {
            if (txt.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar el campo.", "Error de validación");
                txt.Focus();
                return false;
            } else if (!Regex.IsMatch(txt.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Por favor, ingrese solo letras.", "Error de validación");
                txt.Focus();
                return false;
            }

            return true;
        }

        public string entradaOtro(TextBox txt)
        {
            //En caso de seleccionar Otro aparece un textbox
                if (validarEntradaString(txt))
                {
                    return txt.Text;
                }

            return "";
        }

    }
}
