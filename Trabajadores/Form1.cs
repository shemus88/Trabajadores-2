using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajadores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Conexion
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PR6P5E2M-MSSQLSERVER02;Initial Catalog=Trabajadores;User ID=ELKEVIN;Password=Shemus88");
        }
        private void label8_Click(object sender, EventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id_trabajadores = int.Parse(this.textBox1.Text);
            string nombre = textBox2.Text;
            string ap_paterno = textBox4.Text;
            string ap_materno = textBox10.Text;
            double edad = double.Parse(textBox9.Text);
            string sexo = comboBox1.Text;
            string telefono = textBox6.Text;
            DateTime fecha = DateTime.Parse(dateTimePicker1.Text);
            string area = textBox11.Text;
            TimeSpan hora_entrada = TimeSpan.Parse(textBox3.Text);
            TimeSpan hora_salida = TimeSpan.Parse(textBox5.Text);
            using (TrabajadoresEntities contexto=new TrabajadoresEntities())
            {
                Trabajadores c = new Trabajadores
                {
                    id_Trabajadores = id_trabajadores,
                    Nombre = nombre,
                    Ap_Paterno = ap_paterno,
                    Ap_Materno = ap_materno,
                    Edad = edad,
                    Sexo=sexo,
                    Telefono = telefono,
                    Fecha = fecha,
                    Area = area,
                    Hora_Entrada = hora_entrada,
                    Hora_Salida=hora_salida,


                };
                contexto.Trabajadores.Add(c);
                contexto.SaveChanges();
            }
            MessageBox.Show(" El Usuario esta Guardado");
            GetTrabajadores();
        }
        void GetTrabajadores()
        {
            
        }
 
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TrabajadoresEntities context = new TrabajadoresEntities();
            dataGridView1.DataSource= context.Trabajadores.ToList();
        }

        private void llenar()
        {
            this.textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            this.textBox10.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            this.textBox9.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            
            this.textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            this.dateTimePicker1.Text =dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            this.textBox11.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            this.textBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            this.textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id_Trabajadores = Convert.ToInt32(this.textBox1.Text);
            string nombre = textBox2.Text;
            string ap_paterno = textBox4.Text;
            string ap_materno = textBox10.Text;
            double edad = double.Parse(textBox9.Text);
            string sexo = comboBox1.Text;
            string telefono = textBox6.Text;
            DateTime fecha = DateTime.Parse(dateTimePicker1.Text);
            string area = textBox11.Text;
            TimeSpan hora_entrada = TimeSpan.Parse(textBox3.Text);
            TimeSpan hora_salida = TimeSpan.Parse(textBox5.Text);

            using (TrabajadoresEntities contexto=new TrabajadoresEntities())
            {
                Trabajadores c = contexto.Trabajadores.FirstOrDefault(x=>x.id_Trabajadores==id_Trabajadores);
                c.Nombre = nombre;
                c.Ap_Paterno = ap_paterno;
                c.Ap_Materno = ap_materno;
                c.Edad = edad;
                c.Sexo = sexo;
                c.Telefono = telefono;
                c.Fecha = fecha;
                c.Area = area;
                c.Hora_Entrada = hora_entrada;
                c.Hora_Salida = hora_salida;
                contexto.SaveChanges();
                MessageBox.Show(" El Usuario esta Actualizado");
                GetTrabajadores();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void grid_Clic(object sender, EventArgs e)
        {
            llenar();
        }

        private void btnEliminar(object sender, EventArgs e)
        {
            int id_Trabajadores = Convert.ToInt32(this.textBox1.Text);
            using (TrabajadoresEntities contexto = new TrabajadoresEntities())
            {
                Trabajadores c = contexto.Trabajadores.FirstOrDefault(x => x.id_Trabajadores == id_Trabajadores);
                contexto.Trabajadores.Remove(c);
                contexto.SaveChanges();
                MessageBox.Show(" El Usuario esta Eliminado");
            } 
        }
    }
}
