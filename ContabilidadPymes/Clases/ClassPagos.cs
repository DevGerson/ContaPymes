using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace ContabilidadPymes.Clases
{
    public class ClassPagos
    {
        DataSet ds;
        private string Nit { get; set; }
        private int Año { get; set; }
        private string Mes { get; set; }
        private decimal Ventas { get; set; }
        private decimal Impuesto { get; set; }
        private decimal Multa { get; set; }
        private decimal Honorarios { get; set; }
        private decimal Total { get; set; }
        private string Recibo { get; set; }
        private DateTime Fecha { get; set; }


        public ClassPagos()
        {

        }

        public void ParametrosPagos(string nit, int año, string mes, decimal ventas, decimal impuesto, decimal multa, decimal honorarios, decimal total, string recibo, DateTime fecha)
        {
            Nit = nit;
            Año = año;
            Mes = mes;
            Ventas = ventas;
            Impuesto = impuesto;
            Multa = multa;
            Honorarios = honorarios;
            Total = total;
            Recibo = recibo;
            Fecha = fecha;
        }

        public void ParametrosBusqueda(string nit, string recibo)
        {
            Nit = nit;
            Recibo = recibo;
        }

        public void ParametrosVista(string nit)
        {
            Nit = nit;
        }

        public string nit { get { return Nit; } set { Nit = value; } }
        public int año { get { return Año; } set { Año = value; } }
        public string mes { get { return Mes; } set { Mes = value; } }
        public decimal ventas { get { return Ventas; } set { Ventas = value; } }
        public decimal impuesto { get { return Impuesto; } set { Impuesto = value; } }
        public decimal multa { get { return Multa; } set { Multa = value; } }
        public decimal honorarios { get { return Honorarios; } set { Honorarios = value; } }
        public decimal total { get { return Total; } set { Total = value; } }
        public string recibo { get { return Recibo; } set { Recibo = value; } }
        public DateTime fecha { get { return Fecha; } set { Fecha = value; } }


        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarPagos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@año", SqlDbType.Int).Value = año;
            cmd.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
            cmd.Parameters.Add("@ventas", SqlDbType.Decimal).Value = ventas;
            cmd.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = impuesto;
            cmd.Parameters.Add("@multa", SqlDbType.Decimal).Value = multa;
            cmd.Parameters.Add("@honorarios", SqlDbType.Decimal).Value = honorarios;
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;
            cmd.Parameters.Add("@recibo", SqlDbType.VarChar).Value = recibo;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarPagos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@año", SqlDbType.Int).Value = año;
            cmd.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
            cmd.Parameters.Add("@ventas", SqlDbType.Decimal).Value = ventas;
            cmd.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = impuesto;
            cmd.Parameters.Add("@multa", SqlDbType.Decimal).Value = multa;
            cmd.Parameters.Add("@honorarios", SqlDbType.Decimal).Value = honorarios;
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;
            cmd.Parameters.Add("@recibo", SqlDbType.VarChar).Value = recibo;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarPagos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@recibo", SqlDbType.VarChar).Value = recibo;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Buscar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarPagos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@recibo", SqlDbType.VarChar).Value = recibo;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            año = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            mes = ds.Tables[0].Rows[0][2].ToString();
            ventas = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
            impuesto = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
            multa = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
            honorarios = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString());
            total = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
            recibo = ds.Tables[0].Rows[0][8].ToString();
            fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][9].ToString());            
        }

        public bool RegistroEncontrado()
        {
            bool buscar;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarPagos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@recibo", SqlDbType.VarChar).Value = recibo;
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

        public bool ValidacionDuplicadosPagos()
        {
            bool duplicado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ValidacionDuplicadosPagos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@recibo", SqlDbType.VarChar).Value = recibo; 
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

        public DataSet Vista()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaPagos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }



    }
}
