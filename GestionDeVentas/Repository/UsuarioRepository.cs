﻿using GestionDeVentas.Models;
using System.Data.SqlClient;

namespace GestionDeVentas.Repository
{
    public class UsuarioRepository
    {
        private SqlConnection conexion;
        private String ConSrt = "Data Source=MaestroPeludo;Initial Catalog=GestionVentas;Integrated Security=True";

        public UsuarioRepository()
        {
            try
            {
                conexion = new SqlConnection(ConSrt);
            }
            catch (Exception ex)
            {

            }
        }

        public List<Usuario> listarUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            if (conexion == null)
            {
                throw new Exception("Conexion no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = long.Parse(reader["Id"].ToString());                               
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Mail = reader["Mail"].ToString();

                                lista.Add(usuario);
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
