using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_4___Guía3_MM200149
{
    public partial class Form1 : Form
    {


        private List<Persona> Personas = new List<Persona>();
        private int editar_indice = -1;

        private void ActualizarGrid()
        {
            dtgvcontactos.DataSource = null;
            dtgvcontactos.DataSource = Personas;
        }

        private void Limpiar()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txttelefono.Clear();
            txtcorreo.Clear();
        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dtgvcontactos_DoubleClick(object sender, EventArgs e)
        {

            DataGridViewRow seleccion = dtgvcontactos.SelectedRows[0];
            int pos = dtgvcontactos.Rows.IndexOf(seleccion);
            editar_indice = pos;

            Persona per = Personas[pos];

            txtnombre.Text = per.Nombre;
            txtapellido.Text = per.Apellido;
            txttelefono.Text = per.Telefono;
            txtcorreo.Text = per.Correo;

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            Persona per = new Persona();
            per.Nombre = txtnombre.Text;
            per.Apellido = txtapellido.Text;
            per.Telefono = txttelefono.Text;
            per.Correo = txtcorreo.Text;

            if(editar_indice > -1)
            {
                Personas[editar_indice] = per;
                editar_indice = -1;
            }

            else
            {
                Personas.Add(per);
            }
            ActualizarGrid();
            Limpiar();

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            if(editar_indice > -1)
            {
                Personas.RemoveAt(editar_indice);
                editar_indice = -1;
                Limpiar();
                ActualizarGrid();

            }

            else
            {
                MessageBox.Show("Debe dar doble click primero sobre contacto");
            }


        }
    }
}
