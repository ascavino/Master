using System;
using System.Data.SqlClient;

namespace PreEntrega_trabajo_final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string cadenaConexion = "Data Source=DESKTOP-45ILBEJ\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection conn = new SqlConnection(cadenaConexion);

            //List<Producto> producto = ManejadorProducto.ObtenerProductosVendidos(1);


            //foreach (var item in producto)
            //{
            //    Console.WriteLine(item.Descripciones);
            //}

            //ManejadorUsuario.TraerUsuario(1);

            ManejadorUsuario.login("eperez", "NuevaPass");


        }
    }
}