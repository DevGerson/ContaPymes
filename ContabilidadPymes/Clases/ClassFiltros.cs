using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ContabilidadPymes.Clases;

namespace ContabilidadPymes.Clases
{
    class ClassFiltros
    {
        DataSet ds;
        string QuerySinParametros, QueryFinal;
        public DataSet FiltrosCompras(string QueryConParametros)
        {            
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select c.fecha as Fecha, c.Tipo_Doc as TipoDocumento, c.serie as Serie, c.factura as Factura, " +
                "c.proveedor as Nit, p.proveedor as Proveedor,c.monto as Monto, c.iva as IVA, c.fechaCreacion as [FechaCreacion], c.fechaModificacion as FechaModificacion " +
                "from Compras as c inner join Proveedor as p on c.proveedor = p.nit";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltroVentas(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select v.fecha as Fecha, v.Tipo_Doc as TipoDocumento, v.serie as Serie, v.factura as Factura, v.cliente as NIT, c.cliente as Cliente,v.monto as Monto, v.exento as Exento, v.iva as IVA, " + 
                "v.fechaCreacion as FechaCreacion,v.fechaModificacion as FechaModificacion from Ventas as v inner join Cliente as c on v.cliente = c.nit ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltroClientes(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from Cliente ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltroProveedor(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from Proveedor ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltroFacturas(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from Facturas ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltrosFacturaDetalle(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from FacturasDetalles ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltrosLibros(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from Libros ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltrosPagos(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from Pagos ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltrosHonorarios(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select h.nit, c.razon_social, h.honorarios from Honorarios as h inner join Contribuyente as c on h.nit=c.nit ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet FiltrosImpuesto(string QueryConParametros)
        {
            ds = new DataSet();
            QueryFinal = "";
            QuerySinParametros = "select * from Impuestos ";

            if (QueryConParametros == "")
            {
                QueryFinal = QuerySinParametros;
            }
            else
            {
                QueryFinal += QuerySinParametros + " where " + QueryConParametros;
            }
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(QueryFinal, cnn);
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }
    }
}
