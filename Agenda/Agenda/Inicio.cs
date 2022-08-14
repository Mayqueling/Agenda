using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agenda
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        public DatosContactos ActualContacto{ get; set; }

        public void Limpiar()
        {
            textBoxNombre.Text = "";
            maskedTextNumero.Text = "";
            textBoxCorreo.Text = "";
            textBoxDireccion.Text = "";
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (textBoxNombre.Text == "" || maskedTextNumero.Text == "" || textBoxCorreo.Text == "" || textBoxDireccion.Text == "")
            {
                MessageBox.Show("Debe llenar los espacios vacios con los datos solicitados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DatosContactos NContacto = new DatosContactos();
                NContacto.Nombre = textBoxNombre.Text.Trim();
                NContacto.Telefono = maskedTextNumero.Text.Trim();
                NContacto.Correo = textBoxCorreo.Text.Trim();
                NContacto.Direccion = textBoxDireccion.Text.Trim();

                int resultado = ContactoDAL.AgregarContacto(NContacto);

                if (resultado > 0)
                {
                    MessageBox.Show("El Contacto se ha registrado con exito!!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("El Contacto No se guardó", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            Limpiar();

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            buttonGuardar.Visible = true;
            buttonGuardar.Enabled = true;
            button3.Visible = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarContacto buscar = new BuscarContacto();
            buscar.ShowDialog();
            if (buscar.ContactoSeleccionado != null)
            {
                groupBox1.Visible = true;
                ActualContacto = buscar.ContactoSeleccionado;
                textBoxNombre.Text = buscar.ContactoSeleccionado.Nombre;
                maskedTextNumero.Text = buscar.ContactoSeleccionado.Telefono;
                textBoxCorreo.Text = buscar.ContactoSeleccionado.Correo;
                textBoxDireccion.Text = buscar.ContactoSeleccionado.Direccion;
               
                buttonGuardar.Visible = false;
                buttonGuardar.Enabled = false;
                button3.Visible = true;
                button3.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            BuscarContacto buscar = new BuscarContacto();
            buscar.ShowDialog();
            if (buscar.ContactoSeleccionado != null)
            {
                groupBox1.Visible = true;
                ActualContacto = buscar.ContactoSeleccionado;
                textBoxNombre.Text = buscar.ContactoSeleccionado.Nombre;
                maskedTextNumero.Text = buscar.ContactoSeleccionado.Telefono;
                textBoxCorreo.Text = buscar.ContactoSeleccionado.Correo;
                textBoxDireccion.Text = buscar.ContactoSeleccionado.Direccion;
                buttonGuardar.Visible = false;
                buttonGuardar.Enabled = false;
                button3.Visible = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text == "" || maskedTextNumero.Text == "" || textBoxCorreo.Text == "" || textBoxDireccion.Text == "")
            {
                MessageBox.Show("Primero debe de buscar el contacto para porder actualizarlo");
            }
            else
            {
                DatosContactos Contacto = new DatosContactos();
                Contacto.Nombre = textBoxNombre.Text.Trim();
                Contacto.Telefono = maskedTextNumero.Text.Trim();
                Contacto.Correo = textBoxCorreo.Text.Trim();
                Contacto.Direccion = textBoxDireccion.Text.Trim();
                Contacto.IdContacto = ActualContacto.IdContacto;


                if (ContactoDAL.ActualizarContacto(Contacto) > 0)
                {
                    MessageBox.Show("El contacto se actualizo correctamente");
                    groupBox1.Visible = false;
                    button3.Visible = false;
                }
                else
                {
                    MessageBox.Show("Error, no se pudo actualizar el contacto");
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            BuscarContacto buscar = new BuscarContacto();
            buscar.ShowDialog();

            if (buscar.ContactoSeleccionado != null)
            {
                groupBox1.Visible = true;
                ActualContacto = buscar.ContactoSeleccionado;
                textBoxNombre.Text = buscar.ContactoSeleccionado.Nombre;
                maskedTextNumero.Text = buscar.ContactoSeleccionado.Telefono;
                textBoxCorreo.Text = buscar.ContactoSeleccionado.Correo;
                textBoxDireccion.Text = buscar.ContactoSeleccionado.Direccion;
                buttonGuardar.Visible = false;
                buttonGuardar.Enabled = false;
                button3.Visible = true;
                button3.Enabled = true;
            }

            if (textBoxNombre.Text == "" || maskedTextNumero.Text == "" || textBoxCorreo.Text == "" || textBoxDireccion.Text == "")
            {
                MessageBox.Show("Debe de buscar primero el contacto a eliminar.");
            }
            else
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el contacto", "Eliminacion"
                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ContactoDAL.Eliminar(ActualContacto.IdContacto) > 0)
                    {
                        MessageBox.Show("Contacto eliminado correctamente", "Contacto eliminado",
                            MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el contacto", "Contacto no eliminado",
                            MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Se cancelo la eliminacion del contacto", "Eliminacion cancelada",
                        MessageBoxButtons.OK);
                }
            }
            Limpiar();
            groupBox1.Visible = false;
            button3.Visible = false;
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("´Los números on están permitidos en el especio de Nombre");
                e.Handled = true;
                return;
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
