using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosSQL {
    class ADO {
        public void ObtenerConADO() {
            for (int i = 0; i < 1000000; i++) {
                Console.WriteLine(i.ToString());
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
                EjecutarSQL();
            }
            Console.ReadLine();
        }

        public static async Task EjecutarSQL() {
            await Task.Run(
                () => {
                    string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

                    // Provide the query string with a parameter placeholder.
                    string queryString = "SELECT * FROM dbo.tblTenencia";

                    // Create and open the connection in a using block.
                    // This ensures that all resources will be closed and disposed when the code exits.
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        // Create the Command and Parameter objects.
                        SqlCommand command = new SqlCommand(queryString, connection);

                        // Open the connection in a try/catch block.
                        // Create and execute the DataReader, writing the result set to the console window.
                        try {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            for (int i = 0; i < 100; i++) {
                                while (reader.Read()) {
                                    //Console.WriteLine("\t{0}\t{1}",
                                    //    reader[0], reader[1]);
                                }
                            }
                            reader.Close();
                            connection.Close();
                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            );
        }

        public List<Usuario> Listar() {
            var usuarios = new List<Usuario>();

            try {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString())) {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM usuario", con);
                    using (var dr = query.ExecuteReader()) {
                        while (dr.Read()) {
                            // Usuario
                            var usuario = new Usuario {
                                id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Rol_id = Convert.ToInt32(dr["Rol_id"]),
                            };

                            // Agregamos el usuario a la lista genreica
                            usuarios.Add(usuario);
                        }
                    }

                    // Agregamos el ROL
                    foreach (var u in usuarios) {
                        query = new SqlCommand("SELECT * FROM rol WHERE id = @id", con);
                        query.Parameters.AddWithValue("@id", u.Rol_id);

                        using (var dr = query.ExecuteReader()) {
                            dr.Read();
                            if (dr.HasRows) {
                                u.Rol.id = Convert.ToInt32(dr["id"]);
                                u.Rol.Nombre = dr["Nombre"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw;
            }

            return usuarios;
        }

        public Usuario Obtener(int id) {
            var usuario = new Usuario();

            try {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString())) {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM usuario WHERE id = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader()) {
                        dr.Read();
                        if (dr.HasRows) {
                            usuario.id = Convert.ToInt32(dr["id"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido = dr["Apellido"].ToString();
                            usuario.Rol_id = Convert.ToInt32(dr["Rol_id"]);
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw;
            }

            return usuario;
        }

        public bool Actualizar(Usuario usuario) {
            bool respuesta = false;

            try {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString())) {
                    con.Open();

                    var query = new SqlCommand("UPDATE Usuario SET Nombre = @p0, Apellido = @p1, Rol_id = @p2 WHERE id = @p3", con);

                    query.Parameters.AddWithValue("@p0", usuario.Nombre);
                    query.Parameters.AddWithValue("@p1", usuario.Apellido);
                    query.Parameters.AddWithValue("@p2", usuario.Rol_id);
                    query.Parameters.AddWithValue("@p3", usuario.id);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex) {
                throw;
            }

            return respuesta;
        }

        public bool Registrar(Usuario usuario) {
            bool respuesta = false;

            try {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString())) {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Usuario(Nombre, Apellido, Rol_id) VALUES (@p0, @p1, @p2)", con);

                    query.Parameters.AddWithValue("@p0", usuario.Nombre);
                    query.Parameters.AddWithValue("@p1", usuario.Apellido);
                    query.Parameters.AddWithValue("@p2", usuario.Rol_id);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex) {
                throw;
            }

            return respuesta;
        }

        public bool Eliminar(int id) {
            bool respuesta = false;

            try {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString())) {
                    con.Open();

                    var query = new SqlCommand("DELETE FROM usuario WHERE id = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex) {
                throw;
            }

            return respuesta;
        }
    }
}
