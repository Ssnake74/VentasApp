using MySql.Data.MySqlClient;
using VentasApp.Models;
using System.Collections.Generic;

namespace VentasApp.Datos
{
    public class Database
    {
        private readonly string connectionString = "server=localhost;user=root;password=CONTRASEÑA;database=VentasDB";

        public List<Categoria> ObtenerCategoriasConVentas2019()
        {
            var categorias = new List<Categoria>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var query = @"
                SELECT DISTINCT c.CodigoCategoria, c.Nombre
                FROM Categoria c
                JOIN Producto p ON c.CodigoCategoria = p.CodigoCategoria
                JOIN Venta v ON p.CodigoProducto = v.CodigoProducto
                WHERE YEAR(v.Fecha) = 2019";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    CodigoCategoria = reader.GetInt32("CodigoCategoria"),
                    Nombre = reader.GetString("Nombre")
                });
            }

            return categorias;
        }

        public List<Producto> ObtenerProductosVendidosEn2019PorCategoria(int codigoCategoria)
        {
            var productos = new List<Producto>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var query = @"
                SELECT DISTINCT p.Nombre
                FROM Producto p
                JOIN Venta v ON p.CodigoProducto = v.CodigoProducto
                WHERE p.CodigoCategoria = @CodigoCategoria AND YEAR(v.Fecha) = 2019";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CodigoCategoria", codigoCategoria);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    Nombre = reader.GetString("Nombre")
                });
            }

            return productos;
        }
    }
}