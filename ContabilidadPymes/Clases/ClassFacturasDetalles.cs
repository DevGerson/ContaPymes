using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadPymes.Clases
{
    public class ClassFacturasDetalles
    {
        DataSet ds;
        private int Nit { get; set; }
        private string Tipo { get; set; }
        private int Cantidad { get; set; }
        private string Serie { get; set; }
        private int Del { get; set; }
        private int Al { get; set; }
        private string Resolucion { get; set; }
        private DateTime Creacion { get; set; }
        private DateTime Vigencia { get; set; }
        private int Imprenta { get; set; }

        public ClassFacturasDetalles()
        {

        }

        public void ParametrosFacturas(int nit, string tipo, int cantidad, string serie, int del, int al, string resolucion, DateTime creacion, DateTime vigencia, int imprenta)
        {
            Nit = nit;
            Tipo = tipo;
            Cantidad = cantidad;
            Serie = serie;
            Del = del;
            Al = al;
            Resolucion = resolucion;
            Creacion = creacion;
            Vigencia = vigencia;
            Imprenta = imprenta;
        }

        public void ParametrosBusqueda(int nit, string resolucion)
        {
            Nit = nit;
            Resolucion = resolucion;
        }

        public void ParametrosListSeries(int nit, string tipo)
        {
            Nit = nit;
            Tipo = tipo;
        }

        public void ParametrosVista(int nit)
        {
            Nit = nit;
        }

        public int nit { get { return Nit; } set { Nit = value; } }
        public string tipo { get { return Tipo; } set { Tipo = value; } }
        public string serie { get { return Serie; } set { Serie = value; } }
        public int cantidad { get { return Cantidad; } set { Cantidad = value; } }
        public int del { get { return Del; } set { Del = value; } }
        public int al { get { return Al; } set { Al = value; } }
        public string resolucion { get { return Resolucion; } set { Resolucion = value; } }
        public DateTime creacion { get { return Creacion; } set { Creacion = value; } }
        public DateTime vigencia { get { return Vigencia; } set { Vigencia = value; } }
        public int imprenta { get { return Imprenta; } set { Imprenta = value; } }

        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarFacturasDetalles", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@del", SqlDbType.Int).Value = del;
            cmd.Parameters.Add("@al", SqlDbType.Int).Value = al;
            cmd.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            cmd.Parameters.Add("@creacion", SqlDbType.Date).Value = creacion;
            cmd.Parameters.Add("@vigencia", SqlDbType.Date).Value = vigencia;
            cmd.Parameters.Add("@imprenta", SqlDbType.Int).Value = imprenta;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarFacturasDetalles", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            cmd.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
            cmd.Parameters.Add("@del", SqlDbType.Int).Value = del;
            cmd.Parameters.Add("@al", SqlDbType.Int).Value = al;
            cmd.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            cmd.Parameters.Add("@creacion", SqlDbType.Date).Value = creacion;
            cmd.Parameters.Add("@vigencia", SqlDbType.Date).Value = vigencia;
            cmd.Parameters.Add("@imprenta", SqlDbType.Int).Value = imprenta;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarFacturasDetalles", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        public void Buscar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarFacturasDetalles", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            tipo = ds.Tables[0].Rows[0][1].ToString();
            serie = ds.Tables[0].Rows[0][2].ToString();
            cantidad = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            del = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            al = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            resolucion = ds.Tables[0].Rows[0][6].ToString();
            vigencia = Convert.ToDateTime(ds.Tables[0].Rows[0][7].ToString());
            creacion = Convert.ToDateTime(ds.Tables[0].Rows[0][8].ToString());
            imprenta = Convert.ToInt32(ds.Tables[0].Rows[0][9].ToString());
        }

        public DataSet Vista()
        {                    
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaFacturasDetalles", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
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
            SqlDataAdapter adp = new SqlDataAdapter("ListTiposFacturaDetalles", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
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
            SqlDataAdapter adp = new SqlDataAdapter("ListSeriesFacturaDetalles", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@tipo_doc", SqlDbType.VarChar).Value = tipo;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }
            
    }
}
