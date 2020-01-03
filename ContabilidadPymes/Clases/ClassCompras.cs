using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ContabilidadPymes.Clases
{
    class ClassCompras
    {
        DataSet ds;
        private string Nit { get; set; }
        private DateTime Fecha { get; set; }
        private string Tipo_Doc { get; set; }
        private string Serie { get; set; }
        private int Factura { get; set; }
        private string Proveedor { get; set; }
        private decimal Monto { get; set; }
        private decimal Iva { get; set; }
        private string NombreProveedor { get; set; }

        public ClassCompras()
        {
            
        }

        public void NuevaFacturaCompra(string nit, DateTime fecha, string tipo_doc, string serie, int factura, string proveedor, decimal monto, decimal iva)
        {
            Nit = nit;
            Fecha = fecha;
            Tipo_Doc = tipo_doc;
            Serie = serie;
            Factura = factura;
            Proveedor = proveedor;
            Monto = monto;
            Iva = iva;
        }

        public void Busqueda(string nit, string proveedor, string serie, int factura)
        {
            Nit = nit;
            Proveedor = proveedor;
            Serie = serie;
            Factura = factura;
        }

        public void ParametrosDuplicados(string nit, string proveedor, string serie, int factura, string tipo_doc)
        {
            Nit = nit;
            Proveedor = proveedor;
            Serie = serie;
            Factura = factura;
            Tipo_Doc = tipo_doc;
        }

        public void ParametrosVista(string nit)
        {
            Nit = nit;
        }


        public string nit { get { return Nit; } set { Nit = value; } }
        public DateTime fecha { get { return Fecha; } set { Fecha = value; } }
        public string tipo_Doc { get { return Tipo_Doc; } set { Tipo_Doc = value; } }
        public string serie { get { return Serie; } set { Serie = value; } }
        public int factura { get { return Factura; } set { Factura = value; } }
        public string proveedor { get { return Proveedor; } set { Proveedor = value; } }
        public decimal monto { get { return Monto; } set { Monto = value; } }
        public decimal iva { get { return Iva; } set { Iva = value; } }
        public string nombreProveedor { get { return NombreProveedor; } set { NombreProveedor = value; } }


        public void IngresarFacturaCompras()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresoFacturaCompras", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo_Doc;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            cmd.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = proveedor;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
            cmd.Parameters.Add("@iva", SqlDbType.Decimal).Value = iva;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void ModificarFacturaCompras()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarFacturaCompras", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo_Doc;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            cmd.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = proveedor;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
            cmd.Parameters.Add("@iva", SqlDbType.Decimal).Value = iva;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void EliminarFacturaCompras()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarFacturaCompras", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = proveedor;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public DataSet VistaCompras()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaFacturaCompras", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public void BuscarFacturaCompras()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarCuentasCompras", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit",SqlDbType.BigInt).Value=nit;
            adp.SelectCommand.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = proveedor;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());
            tipo_Doc = ds.Tables[0].Rows[0][1].ToString();
            serie = ds.Tables[0].Rows[0][2].ToString();
            factura = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            proveedor = ds.Tables[0].Rows[0][4].ToString();
            nombreProveedor = ds.Tables[0].Rows[0][5].ToString();
            monto = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString());
            iva = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
            cnn.Close();            
        }

        public bool FacturaEncontrado()
        {
            bool buscar;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarCuentasCompras", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = proveedor;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count==0)
            {
                buscar = false;
            }
            else
            {
                buscar = true;
            }
            cnn.Close();
            return buscar;
        }

        public bool ValidacionDuplicadosCompras()
        {
            bool duplicado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ValidacionDuplicadosCompras", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = proveedor;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            adp.SelectCommand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo_Doc;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);

            if (int.Parse(ds.Tables[0].Rows[0][0].ToString())>=1)
            {
                duplicado = true;
            }
            else
            {
                duplicado = false;
            }
            cnn.Close();
            return duplicado;            
        }





    }
}
