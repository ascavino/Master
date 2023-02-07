using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega_trabajo_final
{
    internal class ManejadorUsuario
    {
        public static string cadenaConexion = "Data Source=DESKTOP-45ILBEJ\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Usuario TraerUsuario (long id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Usuario.Id = @Usuario.Id ", conn);

                comando.Parameters.AddWithValue("@Usuario.Id", id);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre= reader.GetString(1);
                    usuario.Apellido= reader.GetString(2);
                    usuario.NombreUsuario= reader.GetString(3);
                    usuario.Contraseña= reader.GetString(4);
                    usuario.Mail= reader.GetString(5);
                }
                return usuario;

                conn.Close();
                    



            }
        }

        public static bool login (String nombreUsuario, String passw)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @passw", conn);
                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@passw", passw);
                
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();




            }

        }




    }
}
