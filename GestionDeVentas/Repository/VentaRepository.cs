using GestionDeVentas.Models;
using System.Data.SqlClient;

namespace GestionDeVentas.Repository
{
    public class VentaRepository
    {
        private SqlConnection conexion;
        private String ConSrt = "Data Source=MaestroPeludo;Initial Catalog=GestionVentas;Integrated Security=True";

        public VentaRepository()
        {
            try
            {
                conexion = new SqlConnection(ConSrt);
            }
            catch (Exception ex)
            {

            }
        }

        public List<Venta> listarVenta()
        {
            List<Venta> lista = new List<Venta>();
            if (conexion == null)
            {
                throw new Exception("Conexion no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM venta", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = long.Parse(reader["Id"].ToString());
                                venta.IdUsuario = long.Parse(reader["IdUsuario"].ToString());
                                venta.Comentarios = reader["Comentarios"].ToString();

                                lista.Add(venta);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;
        }
    }
}
