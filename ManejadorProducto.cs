using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega_trabajo_final
{
    internal static class ManejadorProducto
    {
        public static string cadenaConexion = "Data Source=DESKTOP-45ILBEJ\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto ObtenerProductos(long id)
        {
            Producto producto= new Producto();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
               
                SqlCommand comando2 = new SqlCommand("SELECT * FROM Producto WHERE Id=@id", conn);

                comando2.Parameters.AddWithValue("@id", id);

                conn.Open();

                SqlDataReader reader = comando2.ExecuteReader(); 
                if(reader.HasRows)
                {
                                   
                        reader.Read();
                        producto.Id = reader.GetInt64(0);
                        producto.Descripciones = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario = reader.GetInt64(5);
                                                               
                }
                return producto;
                conn.Close();
            }
        }

        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {
            List<long> ListaIdProductos = new List<long>();
            
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando2 = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido" +
                    " ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = @idUsuario", conn);

                comando2.Parameters.AddWithValue("@idUsuario", idUsuario);

                conn.Open();

                SqlDataReader reader = comando2.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListaIdProductos.Add(reader.GetInt64(0));
                    }
                    
                }

                List<Producto> productos = new List<Producto>();
                foreach (var id in ListaIdProductos)
                {
                    Producto prodTemp = ObtenerProductos(id);
                    productos.Add(prodTemp);                    
                }
                return productos;
            }

        }

        public static int DeleteProducto(long id)
        {
            //Ejemplo del delete y como usar try catch
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("DELETE FROM Producto WHERE id=@id", conn);
                    comando.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return comando.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    Console.WriteLine(""+ex.Message);
                    return-1;
                }
            }
        }
        
    }
}
