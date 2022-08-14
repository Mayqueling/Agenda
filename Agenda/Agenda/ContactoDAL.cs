using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Agenda
{
     class ContactoDAL
     {
        public static int AgregarContacto(DatosContactos contacto)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format(" Insert into contactos (Nombre,Telefono,Correo,Direccion) values ('{0}','{1}','{2}','{3}')",
             contacto.Nombre, contacto.Telefono, contacto.Correo, contacto.Direccion), BD.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }


        public static List<DatosContactos> Buscar(string Nombre)
        {
            List<DatosContactos> Lista = new List<DatosContactos>();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT Id_Contacto,Nombre,Telefono,Correo,Direccion FROM contactos where Nombre = '{0}'", Nombre), BD.ObtenerConexion());           
             MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                DatosContactos contacto = new DatosContactos();
                contacto.IdContacto = _reader.GetInt32(0);
                contacto.Nombre = _reader.GetString(1);
                contacto.Telefono = _reader.GetString(2);
                contacto.Correo = _reader.GetString(3);
                contacto.Direccion = _reader.GetString(4);

                Lista.Add(contacto);
            }
            return Lista;
        }


        public static DatosContactos ObtenerContactos(int Id_Contacto)
        {
            DatosContactos contacto = new DatosContactos();
            MySqlConnection conexion = BD.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT Id_Contacto,Nombre,Telefono,Correo,Direccion  FROM contactos where Id_Contacto = {0}", Id_Contacto), conexion);
             MySqlDataReader _reader = comando.ExecuteReader();
               while (_reader.Read())
               {
                   contacto.IdContacto = _reader.GetInt32(0);
                   contacto.Nombre = _reader.GetString(1);
                   contacto.Telefono = _reader.GetString(2);
                   contacto.Correo = _reader.GetString(3);
                   contacto.Direccion = _reader.GetString(4);                 
               }

           conexion.Close();
           return contacto;           
        }

        public static int ActualizarContacto(DatosContactos contactos)
        {
            int retorno = 0;

            MySqlConnection conexion = BD.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Update contactos set Nombre='{0}',Telefono='{1}'," +
                "Correo='{2}', Direccion='{3}' where ID_Contacto={4}", contactos.Nombre, contactos.Telefono,
                contactos.Direccion, contactos.Correo, contactos.IdContacto), conexion);
                
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int Eliminar(int Pid)
        {
            int retorno = 0;
            MySqlConnection conexion = BD.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete from contactos " +
                "where ID_Contacto={0}", Pid), conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
