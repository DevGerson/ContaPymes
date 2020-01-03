using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ContabilidadPymes.Clases
{
    class ClassFacturas
    {
        DataSet ds;
        private string Nit { get; set; }
        private string Tipo { get; set; }
        private string Serie { get; set; }
        private DateTime Creacion { get; set; }

        public ClassFacturas()
        {

        }

        public void Parametros(string nit, string tipo, string serie, DateTime creacion)
        {
            Nit = nit;
            Tipo = tipo;
            Serie = serie;
            Creacion = creacion;
        }

        public void ParametrosBusqueda(string nit,string serie,string tipo)
        {
            Nit = nit;
            Serie = serie;
            Tipo = tipo;
        }

        public void ParametrosVista(string nit)
        {
            Nit = nit;
        }


        public void ParametrosListSeries(string nit,string tipo)
        {
            Nit = nit;
            Tipo = tipo;
        }

        public string nit { get { return Nit; } set { Nit = value; } }
        public string tipo { get { return Tipo; } set { Tipo = value; } }
        public string serie { get { return Serie; } set { Serie = value; } }
        public DateTime creacion { get { return Creacion; } set { Creacion = value; } }

        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarFacturas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@creacion", SqlDbType.Date).Value = creacion;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarFacturas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@creacion", SqlDbType.Date).Value = creacion;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarFacturas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Buscar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarFacturas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            adp.SelectCommand.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            tipo = ds.Tables[0].Rows[0][1].ToString();
            serie = ds.Tables[0].Rows[0][2].ToString();
            creacion = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
        }

        public DataSet Vista()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaFacturas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet ListTipos()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ListFacturas", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public DataSet ListSeries()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ListSeries", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }
    }
}
