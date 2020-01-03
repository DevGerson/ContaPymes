using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContabilidadPymes.Clases
{
    class ClassVentas
    {
        DataSet ds;
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoDoc { get; set; }
        public string Serie { get; set; }
        public int Factura { get; set; }
        public string NitCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal Monto { get; set; }
        public decimal Exento { get; set; }
        public decimal Iva { get; set; }

        public ClassVentas()
        {

        }

        public void NuevaVentas(string nit, DateTime fecha, string tipoDoc, string serie, int factura, string nitCliente, decimal monto, decimal exento, 
            decimal iva)
        {
            Nit = nit;
            Fecha = fecha;
            TipoDoc = tipoDoc;
            Serie = serie;
            Factura = factura;
            NitCliente = nitCliente;
            Monto = monto;
            Exento = exento;
            Iva = iva;
        }

        public void BuscarVentas(string nit, string serie,int factura)
        {
            Nit = nit;
            Serie = serie;
            Factura = factura;
        }

        public void ParametroVistaVentas(string nit)
        {
            Nit = nit;
        }


        public string nit { get { return Nit; } set { Nit = value; } }
        public DateTime fecha { get { return Fecha; } set { Fecha = value; } }
        public string tipoDoc { get { return TipoDoc; } set { TipoDoc = value; } }
        public string serie { get { return Serie; } set { Serie = value; } }
        public int factura { get { return Factura; } set { Factura = value; } }
        public string nitCliente { get { return NitCliente; } set { NitCliente = value; } }
        public string nombreCliente { get { return NombreCliente; } set { NombreCliente = value; } }
        public decimal monto { get { return Monto; } set { Monto = value; } }
        public decimal exento { get { return Exento; } set { Exento = value; } }
        public decimal iva { get { return Iva; } set { Iva = value; } }


        #region Funciones
        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarFacturaVentas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipoDoc;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            cmd.Parameters.Add("@cliente", SqlDbType.BigInt).Value = nitCliente;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
            cmd.Parameters.Add("@exento", SqlDbType.Decimal).Value = exento;
            cmd.Parameters.Add("@iva", SqlDbType.Decimal).Value = iva;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarFacturaVentas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipoDoc;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            cmd.Parameters.Add("@cliente", SqlDbType.BigInt).Value = nitCliente;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
            cmd.Parameters.Add("@exento", SqlDbType.Decimal).Value = exento;
            cmd.Parameters.Add("@iva", SqlDbType.Decimal).Value = iva;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarFacturaVentas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Buscar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarFacturaVentas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
            tipoDoc = ds.Tables[0].Rows[0][2].ToString();
            serie = ds.Tables[0].Rows[0][3].ToString();
            factura = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            nitCliente = ds.Tables[0].Rows[0][5].ToString();
            nombreCliente = ds.Tables[0].Rows[0][6].ToString();
            monto = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
            exento = Convert.ToDecimal(ds.Tables[0].Rows[0][8].ToString());
            iva = Convert.ToDecimal(ds.Tables[0].Rows[0][9].ToString());                      
            cnn.Close();
        }

        public DataSet VistaFacturaVentas()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaFacturaVentas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public bool ExisteFactura()
        {
            bool buscar;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarFacturaVentas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
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

        public bool ValidacionDuplicadosVentas()
        {
            bool duplicado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ValidacionDuplicadosVentas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@factura", SqlDbType.Int).Value = factura;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);

            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) >= 1)
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
        #endregion


    }
}
