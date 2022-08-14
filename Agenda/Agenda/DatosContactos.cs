using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class DatosContactos
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public DatosContactos(){ }

        public DatosContactos(int ID_Contacto, string CNombre, string CTelefono, string CCorreo, string CDireccion)
        {
            this.IdContacto = ID_Contacto;
            this.Nombre = CNombre;
            this.Telefono = CTelefono;
            this.Correo = CCorreo;
            this.Direccion = CDireccion;
        }
    }
}
