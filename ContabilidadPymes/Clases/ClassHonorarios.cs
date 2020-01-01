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
    public class ClassHonorarios
    {
        DataSet ds;
        private int Nit { get; set; }
        private decimal Honorario { get; set; }


        public ClassHonorarios()
        {

        }

        public void ParametrosHonorarios(int nit, decimal honorario)
        {
            Nit = nit;
            Honorario = honorario;
        }

        public void ParametrosVista(int nit)
        {
            Nit = nit;
        }

        public int nit { get { return Nit; } set { Nit = value; } }
        public decimal honorario { get { return Honorario; } set { Honorario = value; } }
        public string contribuyente { get; set; }

        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarHonorarios", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@honorarioS", SqlDbType.Decimal).Value = honorario;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarHonorarios", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.Parameters.Add("@honorarioS", SqlDbType.Decimal).Value = honorario;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarHonorarios", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Buscar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarHonorarios", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count==0)
            {
                MessageBox.Show("No se encontro registro");
            }
            else
            {
                contribuyente = ds.Tables[0].Rows[0][1].ToString();
                honorario = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());                
            }
            cnn.Close();
        }

        public DataSet Vista()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaHonorarios", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);           
            cnn.Close();
            return ds;
        }

        public bool VerificarHonorario()
        {
            bool Verificar;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarHonorarios", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.Int).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Verificar = false;
            }
            else
            {
                Verificar = true;
            }
            cnn.Close();
            return Verificar;
        }



    }
}
