using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class BuscarContacto : Form
    {
        public BuscarContacto()
        {
            InitializeComponent();
        }

        public DatosContactos ContactoSeleccionado{ get; set; }
        //public int cont = 0;
        private void button1_Click(object sender, EventArgs e)
         {
            if (dgvBuscar.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
                ContactoSeleccionado = ContactoDAL.ObtenerContactos(id);
                this.Close();
            }
            else
            {
                MessageBox.Show("Denbe selecionar una Fila...");
            }
           
        }
    
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {       
            if (textBox1.Text == "")
            {
                MessageBox.Show("Debe erscribir un nombre primero.");
            }
            else
            {
                dgvBuscar.DataSource = ContactoDAL.Buscar(textBox1.Text);
            }
            textBox1.Text = "";
        }

        private void BuscarContacto_Load(object sender, EventArgs e)
        {

        }
    }
}
