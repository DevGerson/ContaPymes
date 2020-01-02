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
    class ClassLibros
    {
        DataSet ds;
        public int Nit { get; set; }
        public DateTime Fecha { get; set; }
        public int Hojas { get; set; }
        public string TipoDoc { get; set; }
        public string Resolucion { get; set; }

        public ClassLibros()
        {

        }

        public void NuevoLibro(int nit, DateTime fecha, int hojas, string tipoDoc, string resolucion)
        {
            Nit = nit;
            Fecha = fecha;
            Hojas = hojas;
            TipoDoc = tipoDoc;
            Resolucion = resolucion;
        }

        public void BuscarLibro(int nit, string resolucion)
        {
            Nit = nit;
            Resolucion = resolucion;
        }

        public void ParametrosVistaLibro(int nit)
        {
            Nit = nit;
        }

        public int nit { get { return Nit; } set { Nit = value; } }
        public DateTime fecha { get { return Fecha; } set { Fecha = value; } }
        public int hojas { get { return Hojas; } set { Hojas = value; } }
        public string tipoDoc { get { return TipoDoc; } set { TipoDoc = value; } }
        public string resolucion { get { return Resolucion; } set { Resolucion = value; } }

        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarLibros", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@hojas", SqlDbType.VarChar).Value = hojas;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipoDoc;
            cmd.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarLibros", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
            cmd.Parameters.Add("@hojas", SqlDbType.VarChar).Value = hojas;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipoDoc;
            cmd.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarLibros", cnn);
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
            SqlDataAdapter adp = new SqlDataAdapter("BuscarLibros", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            nit = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
            hojas = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            tipoDoc = ds.Tables[0].Rows[0][3].ToString();
            resolucion = ds.Tables[0].Rows[0][4].ToString();
            cnn.Close();
        }

        public bool FacturaEncontrada()
        {
            bool buscar;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarLibros", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
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

        public bool ValidacionDuplicadosLibros()
        {
            bool duplicado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ValidacionDuplicadosLibros", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.Parameters.Add("@resolucion", SqlDbType.VarChar).Value = resolucion;
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
            SqlDataAdapter adp = new SqlDataAdapter("VistaLibros", cnn);
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
