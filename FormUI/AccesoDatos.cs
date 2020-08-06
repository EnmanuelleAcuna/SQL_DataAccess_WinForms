using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccesoDatosSQL {
    public class AccesoDatos {
        private static string connectionString = Helper.ConVal("Prueba");

        public List<Persona> ObtenerPersonas(string apellido) {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                List<Persona> personas = connection.Query<Persona>("dbo.Personas_ObtenerPorApellido @Apellido", new { Apellido = apellido }).ToList();
                //List<Persona> personas = connection.Query<Persona>($"select * from Personas where apellido = '{ apellido}'").ToList();
                return personas;
            }
        }

        public void InsertarPersona(Persona persona) {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString)) {
                List<Persona> personas = new List<Persona>();
                personas.Add(persona);
                connection.Execute("dbo.Personas_Insertar @Nombre, @Apellido, @Correo, @Telefono", personas);
            }
        }
    }
}