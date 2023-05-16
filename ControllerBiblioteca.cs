using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp
{
    internal class ControllerBiblioteca
    {
        PostgresConexion postgresConexion = new PostgresConexion();
        NpgsqlConnection cnn;

        public bool InsertarLibro(string nombre, string autor, int paginas)
        {
            try
            {
                using (var cnn = postgresConexion.Conectar())
                {
                    if (cnn != null)
                    {
                        var sql = "INSERT INTO catalogo_biblioteca (nombre, autor, paginas, fecha_ingreso) " +
                                  "VALUES (@nombre, @autor, @paginas, @fecha)";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, cnn))
                        {
                            cmd.Parameters.AddWithValue("nombre", nombre);
                            cmd.Parameters.AddWithValue("autor", autor);
                            cmd.Parameters.AddWithValue("paginas", paginas);
                            cmd.Parameters.AddWithValue("fecha", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se pudo establecer la conexión con la base de datos");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar el libro: {ex.Message}");
                return false;
            }
        }
    }
}
