using Npgsql;
using System;

public class PostgresConexion
{
    private static string servidor = "localhost";
    private static string puerto = "5433";
    private static string usuario = "postgres";
    private static string contrasena = "didier2001";
    private static string baseDatos = "universidad";

    private NpgsqlConnection conexion;

    public PostgresConexion()
    {
        string cadenaConexion = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                servidor, puerto, usuario, contrasena, baseDatos);
        conexion = new NpgsqlConnection(cadenaConexion);
    }

    public NpgsqlConnection Conectar()
    {
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public void Cerrar()
    {
        conexion.Close();
    }
}