using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ArcosJordan_MaestroDetalle_SQLITE
{
    public class MarcaModelo
    {
        private string conexion;
        private SqliteConnection sqlconeccion;

        public MarcaModelo()
        {
            var ruta = Path.Combine(FileSystem.AppDataDirectory, "vehiculos.db");
            conexion = $"Data Source={ruta};";
            sqlconeccion = new SqliteConnection(conexion);
            sqlconeccion.Open();

            sqlconeccion.Execute(@"
                CREATE TABLE IF NOT EXISTS marcas (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nombre VARCHAR(50) NOT NULL UNIQUE
                );
                CREATE TABLE IF NOT EXISTS modelos (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    id_marca INTEGER NOT NULL,
                    nombre_modelo VARCHAR(50) NOT NULL,
                    año INTEGER NOT NULL,
                    FOREIGN KEY (id_marca) REFERENCES marcas(id) ON DELETE CASCADE
                );
            ");
        }
        // CREATE: 
        public Modelo Create(Modelo nuevo)
        {
            using (var transaccion = sqlconeccion.BeginTransaction())
            {
                try
                {
                    var sqlBuscarMarca = "SELECT id FROM marcas WHERE nombre = @nombre_marca";
                    int? marcaId = sqlconeccion.QueryFirstOrDefault<int?>(sqlBuscarMarca, new { nombre_marca = nuevo.nombre_marca }, transaccion);

                    if (marcaId == null)
                    {
                        var sqlInsertarMarca = "INSERT INTO marcas (nombre) VALUES (@nombre_marca); SELECT last_insert_rowid();";
                        marcaId = sqlconeccion.ExecuteScalar<int>(sqlInsertarMarca, new { nombre_marca = nuevo.nombre_marca }, transaccion);
                    }

                    nuevo.id_marca = marcaId.Value;

                    var sqlInsertarModelo = "INSERT INTO modelos (id_marca, nombre_modelo, año) VALUES (@id_marca, @nombre_modelo, @año); SELECT last_insert_rowid();";
                    nuevo.id = sqlconeccion.ExecuteScalar<int>(sqlInsertarModelo, nuevo, transaccion);

                    transaccion.Commit();
                    return nuevo;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al guardar: " + ex.Message);
                }
            }
        }
        // READ ALL: 
        public List<Modelo> GetAll()
        {
            var consulta = @"
                SELECT m.id, m.id_marca, m.nombre_modelo, m.año, ma.nombre AS nombre_marca 
                FROM modelos m 
                JOIN marcas ma ON m.id_marca = ma.id";

            return sqlconeccion.Query<Modelo>(consulta).ToList();
        }
        // READ BY ID
        public Modelo GetById(int id)
        {
            var consulta = @"
                SELECT m.id, m.id_marca, m.nombre_modelo, m.año, ma.nombre AS nombre_marca 
                FROM modelos m 
                JOIN marcas ma ON m.id_marca = ma.id 
                WHERE m.id = @id";

            return sqlconeccion.QueryFirstOrDefault<Modelo>(consulta, new { id = id });
        }
        // UPDATE
        public void Update(Modelo actualizado)
        {
            using (var transaccion = sqlconeccion.BeginTransaction())
            {
                try
                {
                    var sqlMarca = "UPDATE marcas SET nombre = @nombre_marca WHERE id = @id_marca";
                    sqlconeccion.Execute(sqlMarca, actualizado, transaccion);

                    var sqlModelo = "UPDATE modelos SET nombre_modelo = @nombre_modelo, año = @año WHERE id = @id";
                    sqlconeccion.Execute(sqlModelo, actualizado, transaccion);

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al actualizar: " + ex.Message);
                }
            }
        }
        // DELETE: 
        public void Delete(int id)
        {
            var sql = "DELETE FROM modelos WHERE id = @id";
            sqlconeccion.Execute(sql, new { id = id });
        }
    }
}