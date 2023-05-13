using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BibliotecaApp
{
    public partial class Form1 : Form
    {
        PostgresConexion postgresConexion = new PostgresConexion();
        NpgsqlConnection cnn;
        public Form1()
        {
            InitializeComponent();
            inputPaginas.KeyPress += new KeyPressEventHandler(inputPaginas_KeyPress);
        }

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
        private void Form1_Load(object sender, EventArgs e)
        {
            panelHome.Visible = true;

            btn_home.FlatStyle = FlatStyle.Flat;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.FlatAppearance.MouseOverBackColor = btn_home.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panel1.Visible = false;
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            string nombre = inputNombre.Text.ToUpper();
            string autor = inputAutor.Text.ToUpper();
            int paginas;

            if (inputPaginas.Text == "")
            {
                msm_ingresar.Text = "Ingrese el Numero de Paginas";
            }
            else
            {
                paginas = int.Parse(inputPaginas.Text);

                if (nombre.Length > 5)
                {
                    if (autor.Length > 4)
                    {
                        if (paginas > 10)
                        {
                            bool ingreso = InsertarLibro(nombre, autor, paginas);
                            if (ingreso)
                            {
                                msm_ingresar.Text = "Se Ingreso de Forma Correcta el Libro";
                                inputNombre.Text = ""; inputPaginas.Text = ""; inputAutor.Text = "";
                            }
                            else
                            {
                                msm_ingresar.Text = "NO Se Ingreso el Libro";
                            }

                        }
                        else
                        {
                            msm_ingresar.Text = "El número de páginas debe ser mayor a 10";
                        }
                    }
                    else
                    {
                        msm_ingresar.Text = "Ingrese el Autor del Libro";
                    }
                }
                else
                {
                    msm_ingresar.Text = "Ingrese el Nombre del Libro";
                }
            }
        }

        private void inputPaginas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter presionado es un dígito o un carácter de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni un carácter de control, no permitir la entrada
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
