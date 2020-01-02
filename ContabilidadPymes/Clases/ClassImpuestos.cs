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
    class ClassImpuestos
    {
        DataSet ds;
        private int Nit { get; set; }
        private decimal Ventas { get; set; }
        private decimal Impuesto { get; set; }
        private decimal Multas { get; set; }
        private string Formulario { get; set; }
        private string Acceso { get; set; }

        public ClassImpuestos()
        {

        }


        public void ParametrosImpuestos(int nit, decimal ventas, decimal impuestos, decimal multas, string formulario, string acceso)
        {
            Nit = nit;
            Ventas = ventas;
            Impuesto = impuestos;
            Multas = multas;
            Formulario = formulario;
            Acceso = acceso;
        }

        public void ParametrosBusqueda(int nit, string formulario)
        {
            Nit = nit;
            Formulario = formulario;
        }

        public void ParametrosVista(int nit)
        {
            Nit = nit;
        }

        public int nit { get { return Nit; } set { Nit = value; } }
        public decimal ventas { get { return Ventas; } set { Ventas = value; } }
        public decimal impuesto { get { return Impuesto; } set { Impuesto = value; } }
        public decimal multas { get { return Multas; } set { Multas = value; } }
        public string formulario { get { return Formulario; } set { Formulario = value; } }
        public string acceso { get { return Acceso; } set { Acceso = value; } }

        public void IngresarImpuesto()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarImpuestos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@ventas", SqlDbType.Decimal).Value = ventas;
            cmd.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = impuesto;
            cmd.Parameters.Add("@multa", SqlDbType.Decimal).Value = multas;
            cmd.Parameters.Add("@formulario", SqlDbType.BigInt).Value = formulario;
            cmd.Parameters.Add("@acceso", SqlDbType.BigInt).Value = acceso;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void ModificarImpuesto()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarImpuestos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@ventas", SqlDbType.Decimal).Value = ventas;
            cmd.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = impuesto;
            cmd.Parameters.Add("@multa", SqlDbType.Decimal).Value = multas;
            cmd.Parameters.Add("@formulario", SqlDbType.BigInt).Value = formulario;
            cmd.Parameters.Add("@acceso", SqlDbType.BigInt).Value = acceso;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void EliminarImpuesto()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarImpuestos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@formulario", SqlDbType.BigInt).Value = formulario;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void BuscarImpuesto()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarImpuestos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@formulario", SqlDbType.BigInt).Value = formulario;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            ventas = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString());
            impuesto = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
            multas = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
            formulario = ds.Tables[0].Rows[0][4].ToString();
            acceso = ds.Tables[0].Rows[0][5].ToString();            
            cnn.Close();
        }

        public bool RegistroEncontrado()
        {
            bool buscar;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarImpuestos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@formulario", SqlDbType.BigInt).Value = formulario;
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

        public bool ValidacionDuplicadosImpuestos()
        {
            bool duplicado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ValidacionDuplicadosImpuesto", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@formulario", SqlDbType.BigInt).Value = formulario;
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
            SqlDataAdapter adp = new SqlDataAdapter("VistaImpuestos", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }




    }
}
