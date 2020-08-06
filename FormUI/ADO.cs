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
    }
}
