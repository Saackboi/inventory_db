using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioBD.Clases
{
    internal class Conexion
    {
        string cnString = @"Server=LAPTOP-5PR20G61; Database=inventario; Integrated Security=True;";

        public Conexion()
        {
        }

        //--------------------------------------------CONSULTAS PARA GESTION EQUIPO-------------------------------------------

        //Registra los equipos
        public void registrarEquipo(string placa, string nombre, string modelo, string serie, string depa, string estado, string persona, DataGridView equipo)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO equipo (id_equipo, nombre, modelo, serie, id_departamento, estado, id_usuario) VALUES(@id_equipo, @nombre, @modelo, @serie, @id_departamento, @estado , @id_usuario)", connection);

                command.Parameters.AddWithValue("@id_equipo", placa);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@modelo", modelo);
                command.Parameters.AddWithValue("@serie", serie);
                command.Parameters.AddWithValue("@id_departamento", obtenerIdDepa(depa));
                command.Parameters.AddWithValue("@estado", estado);
                command.Parameters.AddWithValue("@id_usuario", obtenerIdUsuario(persona));
                command.ExecuteNonQuery();
                MessageBox.Show("Registro agregado.");
                cargarEquipos(equipo);
            }
        }

        //Eliminar un registro de equipo
        public void eliminarEquipo(DataGridView equipos)
        {
            if (equipos.SelectedRows.Count > 0)
            {
                string id = equipos.SelectedRows[0].Cells[0].Value.ToString();
                using (SqlConnection connection = new SqlConnection(cnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM equipo WHERE id_equipo = @Id", connection);

                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Registro eliminado.");
                    cargarEquipos(equipos);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        //Modificar un registro de equipo
        public bool modificarEquipo(string nombre, string modelo, string serie, string depa, string estado, string persona, DataGridView equipos)
        {
            if (equipos.SelectedRows.Count > 0)
            {
                // Obtener el id del equipo seleccionado (placa)
                string id = equipos.SelectedRows[0].Cells[0].Value.ToString();

                using (SqlConnection connection = new SqlConnection(cnString))
                {
                    connection.Open();

                    // Consulta SQL para actualizar los detalles del equipo
                    SqlCommand command = new SqlCommand("UPDATE equipo SET nombre = @nombre, modelo = @modelo, serie = @serie, id_departamento = @id_depto, estado = @estado, persona_usuario = @persona WHERE id_equipo = @id_equipo", connection);

                    // Asignar los parámetros de la consulta
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@modelo", modelo);
                    command.Parameters.AddWithValue("@serie", serie);
                    command.Parameters.AddWithValue("@id_depto", obtenerIdDepa(depa));
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@persona", persona);
                    command.Parameters.AddWithValue("@id_equipo", id);

                    // Ejecutar la consulta para modificar el registro
                    command.ExecuteNonQuery();

                    MessageBox.Show("Registro modificado exitosamente.");
                    cargarEquipos(equipos);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar.");
                return false;
            }
        }

        //valida que la serie ingresada no exista en la bd
        public bool validarUnicidadSerie(string serie)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo where serie = @serie", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@serie", serie);

                object result = adapter.SelectCommand.ExecuteScalar();

                return result != null;
            }
        }

        //valida que la placa ingresada no exista en la bd
        public bool validarUnicidadPlaca(string placa)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo where id_equipo = @placa", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@placa", placa);

                object result = adapter.SelectCommand.ExecuteScalar();

                return result != null;
            }
        }

        //recarga los equipos registrados en la bd
        public void cargarEquipos(DataGridView equipos)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo", connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                equipos.DataSource = dt;
            }
        }

        //--------------------------------------------CONSULTAS PARA GESTION DEPARTAMENTO-------------------------------------------

        //Registra los departamentos
        public void registrarDepa(string nombre, DataGridView depas)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO departamento (nombre) VALUES(@nombre)", connection);

                command.Parameters.AddWithValue("@nombre", nombre);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro agregado.");
                cargarDepa(depas);
            }
        }

        //Eliminar un registro de departamento
        public void eliminarDepa(DataGridView depas)
        {
            if (depas.SelectedRows.Count > 0)
            {
                string id = depas.SelectedRows[0].Cells[0].Value.ToString();

                if (validarDepa(id))
                {
                    MessageBox.Show("No se puede eliminar este departamento, mantiene relación con registros de otra tabla.");
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(cnString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("DELETE FROM departamento WHERE id_departamento = @Id", connection);

                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Registro eliminado.");
                        cargarDepa(depas);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        //Modificar un registro de departamento
        public bool modificarDepa(string nombre, DataGridView depas)
        {
            if (depas.SelectedRows.Count > 0)
            {
                // Obtener el id del equipo seleccionado (placa)
                string id = depas.SelectedRows[0].Cells[0].Value.ToString();

                using (SqlConnection connection = new SqlConnection(cnString))
                {
                    connection.Open();

                    // Consulta SQL para actualizar los detalles del departamento
                    SqlCommand command = new SqlCommand("UPDATE departamento SET nombre = @nombre WHERE id_departamento = @id", connection);

                    // Asignar los parámetros de la consulta
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@id", id);

                    // Ejecutar la consulta para modificar el registro
                    command.ExecuteNonQuery();

                    MessageBox.Show("Registro modificado exitosamente.");
                    cargarDepa(depas);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar.");
                return false;
            }
        }

            //consigue id del departamento seleccionado
            private int obtenerIdDepa(string depa)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT id_departamento FROM departamento where nombre = @nombre", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@nombre", depa);

                object result = adapter.SelectCommand.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }

        //Recarga los departamentos en el combobox
        public void cargarDepa(ComboBox cbDepa)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT nombre FROM departamento", connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbDepa.DataSource = dt;
                cbDepa.DisplayMember = "nombre";
            }
        }


        //Recarga los departamentos en el combobox
        public void cargarDepa(DataGridView depas)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM departamento", connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                depas.DataSource = dt;
            }
        }

        //valida si un departamento tiene alguna conexión a otra tabla
        public bool validarDepa(string id)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo where id_departamento = @id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                object result = adapter.SelectCommand.ExecuteScalar();

                return result != null;
            }
        }


        //Busca departamento
        public bool buscarDepa(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM departamento where nombre = @nombre", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@nombre", nombre);

                object result = adapter.SelectCommand.ExecuteScalar();

                return result != null;
            }
        }


        //--------------------------------------------CONSULTAS PARA BUSQUEDAS-------------------------------------------
        public void busquedaPorDepa(string nombre, DataGridView depas)
        {
            int id = obtenerIdDepa(nombre);

            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo where id_departamento = @id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                depas.DataSource = dt;
            }
        }

        public void busquedaPorPlaca(string placa, DataGridView equipos)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo where id_equipo = @id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", placa);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                equipos.DataSource = dt;
            }
        }


        //--------------------------------------------CONSULTAS PARA GESTION USUARIO-------------------------------------------

        //Recarga los usuarios en el combobox
        public void cargarUsuario(ComboBox cbPersona)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT nombre FROM usuario", connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbPersona.DataSource = dt;
                cbPersona.DisplayMember = "nombre";
            }
        }
        public void cargarUsuario(DataGridView usuario)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT nombre FROM usuario", connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                usuario.DataSource = dt;
            }
        }

        //consigue id del usuario seleccionado
        private int obtenerIdUsuario(string persona)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT id_usuario FROM usuario where nombre = @nombre", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@nombre", persona);

                object result = adapter.SelectCommand.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }

        //Registra usuario
        public void registrarUsuario(string nombre, DataGridView usuario)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO departamento (nombre) VALUES(@nombre)", connection);

                command.Parameters.AddWithValue("@nombre", nombre);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro agregado.");
                cargarDepa(usuario);
            }
        }

        //Eliminar un registro de usuario
        public void eliminarUsuario(DataGridView usuario)
        {
            if (usuario.SelectedRows.Count > 0)
            {
                string id = usuario.SelectedRows[0].Cells[0].Value.ToString();

                if (validarUsuario(id))
                {
                    MessageBox.Show("No se puede eliminar este usuarioo, mantiene relación con registros de otra tabla.");
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(cnString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("DELETE FROM usuario WHERE id_usuario = @Id", connection);

                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Registro eliminado.");
                        cargarUsuario(usuario);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        //Modificar un registro de usuario
        public bool modificarUsuario(string nombre, DataGridView usuario)
        {
            if (usuario.SelectedRows.Count > 0)
            {
                // Obtener el id del equipo seleccionado (placa)
                string id = usuario.SelectedRows[0].Cells[0].Value.ToString();

                using (SqlConnection connection = new SqlConnection(cnString))
                {
                    connection.Open();

                    // Consulta SQL para actualizar los detalles del departamento
                    SqlCommand command = new SqlCommand("UPDATE usuario SET nombre = @nombre WHERE id_usuario = @id", connection);

                    // Asignar los parámetros de la consulta
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@id", id);

                    // Ejecutar la consulta para modificar el registro
                    command.ExecuteNonQuery();

                    MessageBox.Show("Registro modificado exitosamente.");
                    cargarUsuario(usuario);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar.");
                return false;
            }
        }

        //valida si un departamento tiene alguna conexión a otra tabla
        public bool validarUsuario(string id)
        {
            using (SqlConnection connection = new SqlConnection(cnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM equipo where id_usuario = @id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                object result = adapter.SelectCommand.ExecuteScalar();

                return result != null;
            }
        }
    }

    //--------------------------------------------CONSULTAS PARA GESTION EQUIPO MOVIMIENTOS-------------------------------------------

}
