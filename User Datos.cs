using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;

namespace Acceso_Datos
{
    public class User_Datos : Conexion
    {
        public bool Login(string user, string pass)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_Login";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheInicioSesion.user = reader.GetInt32(0);
                            CacheInicioSesion.pass = reader.GetString(2);
                            CacheInicioSesion.empleadoid = reader.GetInt32(1);
                            CacheInicioSesion.nombre = reader.GetString(3);
                            CacheInicioSesion.apellido = reader.GetString(4);
                            CacheInicioSesion.email = reader.GetString(5);
                            CacheInicioSesion.telefono = reader.GetString(6);
                            CacheInicioSesion.direccion = reader.GetString(7);                           
                            try
                            {
                                CacheInicioSesion.imagen = (byte[])reader.GetSqlBinary(8);
                            }
                            catch
                            {
                                CacheInicioSesion.imagen = null;
                            }
                            CacheInicioSesion.RollID = reader.GetInt32(14);
                        }
                        return true;
                    }
                    return false;
                }
            }
        }


        //// Categorias
        ///
        public DataTable Tb_Categorias()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_Categorias";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public void Pr_NuevaCategoria(string nombre, string descripcion, byte[] imagen)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevaCategoria";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        /////// Articulos/Productos
        ///
        public DataTable Tb_Productos(string modulo)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_Productos";
                    command.Parameters.AddWithValue("@modulo", modulo);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;


                }
            }
        }
        public bool Tb_ProductosDetalles(int productoid)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ProductosDetalles";
                    command.Parameters.AddWithValue("@productoid", productoid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheProductosDetalles.productoid = reader.GetInt32(0);
                            CacheProductosDetalles.nombre = reader.GetString(1);
                            CacheProductosDetalles.und = reader.GetString(2);
                            CacheProductosDetalles.stock = reader.GetDecimal(3);


                        }
                        return true;
                    }
                    return false;
                }
            }
        }
        public DataTable Tb_ListadoProductos()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ListadoProductos";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public void Pr_NuevoProducto(string nombre,string descripcion,int categoria,int unidadmedida, byte[] imagen)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevoProducto";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@categoriaid", categoria);
                    command.Parameters.AddWithValue("@unidadmedidaid", unidadmedida);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_ModificarProducto(int productoid, string nombre, string descripcion, int categoria, int unidadmedida, byte[] imagen)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_ModificarProducto";
                    command.Parameters.AddWithValue("@productoid", productoid);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@categoriaid", categoria);
                    command.Parameters.AddWithValue("@unidadmedidaid", unidadmedida);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable Tb_ReporteMovimientosProductos(int productoid)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReporteMovimientosProductos";
                    command.Parameters.AddWithValue("@productoid", productoid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                  //  command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        ////////// Unidades de Medidas
        ///
        public DataTable Tb_ListadoUnidadesMedidas()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ListadoUnidadesMedidas";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }


        /////// Proveedores
        ///
        public DataTable Tb_Proveedores()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_Proveedores";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public bool Tb_ProveedoresDetalles(int proveedorid)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ProveedoresDetalles";
                    command.Parameters.AddWithValue("@proveedorid", proveedorid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheProveedorDetalles.proveedorid = reader.GetInt32(0);
                            CacheProveedorDetalles.nombre = reader.GetString(1);
                        }
                        return true;
                    }
                    return false;
                }
            }
        }

        public void Pr_NuevoProveedor(string nombre, string nombrecontacto, string rnc,
            string direccion, string ciudad, string codigopostal, string pais, string telefono,
            string email, string url)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevoProveedor";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@nombrecontacto", nombrecontacto);
                    command.Parameters.AddWithValue("@rnc", rnc);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@ciudad", ciudad);
                    command.Parameters.AddWithValue("@codigopostal", codigopostal);
                    command.Parameters.AddWithValue("@pais", pais);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@url", url);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_ModificarProveedor(int proveedorid,string nombre, string nombrecontacto, string rnc,
            string direccion, string ciudad, string codigopostal, string pais, string telefono,
            string email, string url)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_ModificarProveedor";
                    command.Parameters.AddWithValue("@proveedorid", proveedorid);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@nombrecontacto", nombrecontacto);
                    command.Parameters.AddWithValue("@rnc", rnc);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@ciudad", ciudad);
                    command.Parameters.AddWithValue("@codigopostal", codigopostal);
                    command.Parameters.AddWithValue("@pais", pais);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@url", url);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        /////////// Clientes
        ///
        public DataTable Tb_Clientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_Clientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public bool Tb_ClientesDetalles(int clienteid)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ClientesDetalles";
                    command.Parameters.AddWithValue("@clienteid", clienteid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheClientesDetalles.clienteid = reader.GetInt32(0);
                            CacheClientesDetalles.nombre = reader.GetString(1);
                        }
                        return true;
                    }
                    return false;
                }
            }
        }

        public void Pr_NuevoCliente(string departamento, string encargado, string email, 
            string telefono, string ext)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevoCliente";
                    command.Parameters.AddWithValue("@departamento", departamento);
                    command.Parameters.AddWithValue("@encargado", encargado);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@ext", ext);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_ModificarCliente(int clienteid, string departamento, string encargado, string email,
            string telefono, string ext)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_ModificarCliente";
                    command.Parameters.AddWithValue("@clienteid", clienteid);
                    command.Parameters.AddWithValue("@departamento", departamento);
                    command.Parameters.AddWithValue("@encargado", encargado);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@ext", ext);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        /////////// inventario
        ///
        public DataTable Tb_Inventario()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_Inventario";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        ////////// Ingreso a almacen
        ///

        public void Pr_NuevoIngreso(int proveedorid, string nofactura, string noconduce, string tipocomprobante, string nocomprobante,
            DateTime fechafactura, decimal totalcompra, string comentario, List<Comun.CacheIngresoDetalles> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("IngresoID");
            dt.Columns.Add("ProdID");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");

            int i = 1;
            foreach (var Elementos in lista)
            {
                dt.Rows.Add(i, Elementos.ProdID, Elementos.Cantidad, Elementos.Precio);
                i++;
            }

            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevoIngreso";
                    var parametrolista = new SqlParameter("lstDetalles", SqlDbType.Structured);
                    parametrolista.TypeName = "dbo.IngresoDetalles";
                    parametrolista.Value = dt;
                    command.Parameters.Add(parametrolista);
                    command.Parameters.AddWithValue("@proveedorid", proveedorid);
                    command.Parameters.AddWithValue("@nofactura", nofactura);
                    command.Parameters.AddWithValue("@noconduce", noconduce);
                    command.Parameters.AddWithValue("@tipocomprobante", tipocomprobante);
                    command.Parameters.AddWithValue("@nocomprobante", nocomprobante);
                    command.Parameters.AddWithValue("@fechafactura", fechafactura);
                    command.Parameters.AddWithValue("@totalcompra", totalcompra);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                 /*   SqlParameter Ultimo = new SqlParameter("@UltimoRegistro", SqlDbType.Int);
                    Ultimo.Direction = ParameterDirection.Output;
                    command.Parameters.Add(Ultimo);*/
                }
            }
        }
        public void Pr_AnularIngreso(int ingresoid, string comentario, List<Comun.CacheIngresoDetalles> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("IngresoID");
            dt.Columns.Add("ProdID");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");

            int i = 1;
            foreach (var Elementos in lista)
            {
                dt.Rows.Add(i, Elementos.ProdID, Elementos.Cantidad, Elementos.Precio);
                i++;
            }

            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_AnularIngreso";
                    var parametrolista = new SqlParameter("lstDetalles", SqlDbType.Structured);
                    parametrolista.TypeName = "dbo.IngresoDetalles";
                    parametrolista.Value = dt;
                    command.Parameters.Add(parametrolista);
                    command.Parameters.AddWithValue("@ingresoid", ingresoid);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable Tb_EntradasRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_EntradasRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public DataTable Tb_ReporteEntradas(DateTime fechadesde, DateTime fechahasta)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReporteEntradas";
                    command.Parameters.AddWithValue("@fechadesde", fechadesde);
                    command.Parameters.AddWithValue("@fechahasta", fechahasta);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public DataTable Tb_ReportesEntradasDetalles(int ingresoid)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReportesEntradasDetalles";
                    command.Parameters.AddWithValue("@ingresoid", ingresoid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        ///////// Salidas de almacen
        ///
        public void Pr_NuevaOrder(int clienteid, string comentario, List<Comun.CacheOrdersDetalles> lista, DateTime fechasalida)
        {
            var dt = new DataTable();
            dt.Columns.Add("OrderID");
            dt.Columns.Add("ProdID");
            dt.Columns.Add("Cantidad");

            int i = 1;
            foreach (var Elementos in lista)
            {
                dt.Rows.Add(i, Elementos.ProdID, Elementos.Cantidad);
                i++;
            }

            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevaOrder";
                    var parametrolista = new SqlParameter("lstDetalles", SqlDbType.Structured);
                    parametrolista.TypeName = "dbo.OrdersDetalles";
                    parametrolista.Value = dt;
                    command.Parameters.Add(parametrolista);
                    command.Parameters.AddWithValue("@clienteid", clienteid);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.Parameters.AddWithValue("@fechasalida", fechasalida);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Pr_AnularOrder(int orderid, string comentario, List<Comun.CacheOrdersDetalles> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("OrderID");
            dt.Columns.Add("ProdID");
            dt.Columns.Add("Cantidad");

            int i = 1;
            foreach (var Elementos in lista)
            {
                dt.Rows.Add(i, Elementos.ProdID, Elementos.Cantidad);
                i++;
            }

            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_AnularOrder";
                    var parametrolista = new SqlParameter("lstDetalles", SqlDbType.Structured);
                    parametrolista.TypeName = "dbo.OrdersDetalles";
                    parametrolista.Value = dt;
                    command.Parameters.Add(parametrolista);
                    command.Parameters.AddWithValue("@orderid", orderid);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable Tb_SalidasRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_SalidasRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Tb_ReporteSalidas(DateTime fechadesde, DateTime fechahasta)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReporteSalidas";
                    command.Parameters.AddWithValue("@fechadesde", fechadesde);
                    command.Parameters.AddWithValue("@fechahasta", fechahasta);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public DataTable Tb_ReportesSalidasDetalles(int orderid)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReportesSalidasDetalles";
                    command.Parameters.AddWithValue("@orderid", orderid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        /////////// Usuarios
        ///
        public DataTable TB_Usuarios()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "TB_Usuarios";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public void Pr_NuevoUsuario(int empleadoid, string pass, string nombre, string apellido, string email, string telefono,
                                        string direccion, bool activo)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevoUsuario";
                    command.Parameters.AddWithValue("@empleadoid", empleadoid);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@activo", activo);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_ModificarUsuario(int usuarioid,int empleadoid, string pass, string nombre, string apellido, string email, string telefono,
                                        string direccion, bool activo)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_ModificarUsuario";
                    command.Parameters.AddWithValue("@usuarioid", usuarioid);
                    command.Parameters.AddWithValue("@empleadoid", empleadoid);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@activo", activo);
                    command.Parameters.AddWithValue("@userid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_CambiarImagenPerfil(int usuarioid, byte[] imagen)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_CambiarImagenPerfil";
                    command.Parameters.AddWithValue("@usuarioid", usuarioid);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// // Listado de precios
        /// </summary>
        /// <returns></returns>

        public DataTable Tb_ListadePrecio()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ListadePrecio";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public void Pr_ActualizarPrecio(int productoid, decimal precio)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_ActualizarPrecio";
                    command.Parameters.AddWithValue("@productoid", productoid);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        ///// Pedidos
        ///
        public DataTable Tb_ListadoPedidos()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ListadoPedidos";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public DataTable Tb_MisPedidos(int usuarioid)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_MisPedidos";
                    command.Parameters.AddWithValue("@usuarioid", usuarioid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public void Pr_NuevoPedido(string comentario, List<Comun.CachePedidoDetalles> lista)
        {
            var dt = new DataTable();
            dt.Columns.Add("PedidoID");
            dt.Columns.Add("ProdID");
            dt.Columns.Add("Cantidad");

            int i = 1;
            foreach (var Elementos in lista)
            {
                dt.Rows.Add(i, Elementos.ProdID, Elementos.Cantidad);
                i++;
            }

            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_NuevoPedido";
                    var parametrolista = new SqlParameter("lstDetalles", SqlDbType.Structured);
                    parametrolista.TypeName = "dbo.PedidoDetalles";
                    parametrolista.Value = dt;
                    command.Parameters.Add(parametrolista);
                    command.Parameters.AddWithValue("@usuarioid", CacheInicioSesion.user);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@userid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_CancelarPedido(int pedidoid)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_CancelarPedido";
                    command.Parameters.AddWithValue("@pedidoid", pedidoid);
                    command.Parameters.AddWithValue("@userid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Pr_RechazarPedido(int pedidoid, string comentario)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_RechazarPedido";
                    command.Parameters.AddWithValue("@pedidoid", pedidoid);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@userid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Pr_ConfirmarPedido(int pedidoid, string comentario)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_ConfirmarPedido";
                    command.Parameters.AddWithValue("@pedidoid", pedidoid);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@userid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Pr_CompletarPedido(int pedidoid, string comentario)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Pr_CompletarPedido";
                    command.Parameters.AddWithValue("@pedidoid", pedidoid);
                    command.Parameters.AddWithValue("@comentario", comentario);
                    command.Parameters.AddWithValue("@userid", CacheInicioSesion.user);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable Tb_ReportePedidos(DateTime fechadesde, DateTime fechahasta)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReportePedidos";
                    command.Parameters.AddWithValue("@fechadesde", fechadesde);
                    command.Parameters.AddWithValue("@fechahasta", fechahasta);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Tb_ReportesPedidosDetalles(int pedidoid)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_ReportesPedidosDetalles";
                    command.Parameters.AddWithValue("@pedidoid", pedidoid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }

        public DataTable Tb_DashboardPedidos()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_DashboardPedidos";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }


        ///// Dashboard
        ///
        public DataTable Tb_Dashboard()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Tb_Dashboard";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Db_EntradasRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Db_EntradasRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Db_SalidasRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Db_SalidasRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Db_ProveedoresRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Db_ProveedoresRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Db_DepartamentosRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Db_DepartamentosRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Db_ArticulosRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Db_ArticulosRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
        public DataTable Db_UsuariosRecientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conexion;
                    command.CommandText = "Db_UsuariosRecientes";
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    command.CommandType = CommandType.StoredProcedure;
                    return tabla;
                }
            }
        }
    }
}
