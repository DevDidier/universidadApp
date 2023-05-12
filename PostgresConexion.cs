using Npgsql;
using System;

namespace BibliotecaApp
{
    public class PostgresConexion
    {
        private NpgsqlConnection cnn;

        public NpgsqlConnection Conectar()
        {
            try
            {
                cnn = new NpgsqlConnection("Server=localhost;Port=5433;User Id=postgres;Password=didier2001;Database=universidad;");
                cnn.Open();
                return cnn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Desconectar()
        {
            cnn.Close();
        }
    }
}