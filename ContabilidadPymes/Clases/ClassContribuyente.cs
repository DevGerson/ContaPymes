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
    class ClassContribuyente
    {
        DataSet ds;
        public string Nit { get; set; }
        public string Razon_social { get; set; }
        public string Cui { get; set; }
        public string Nombre_Comercial { get; set; }
        public int Telefono { get; set; }
        public int Estado_Contable { get; set; }
        public string Direccion { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Sat_Usuario { get; set; }
        public string Sat_Password { get; set; }

        public ClassContribuyente()
        {

        }

        public void NuevoContribuyente(string nit, string razon_Social, string cui, string nombre_Comercial, int telefono, int estado_Contable, string direccion,
            string municipio, string departamento, string sat_Usuario, string sat_Password)
        {
            Nit = nit;
            Razon_social = razon_Social;
            Cui = cui;
            Nombre_Comercial = nombre_Comercial;
            Telefono = telefono;
            Estado_Contable = estado_Contable;
            Direccion = direccion;
            Municipio = municipio;
            Departamento = departamento;
            Sat_Usuario = sat_Usuario;
            Sat_Password = sat_Password;
        }

        public void ParametrosBusqueda(string nit)
        {
            Nit = nit;
        }

        public string nit { get { return Nit; } set { Nit = value; } }
        public string razon_social { get { return Razon_social; } set { Razon_social = value; } }
        public string cui { get { return Cui; } set { Cui = value; } }
        public string nombre_Comercial { get { return Nombre_Comercial; } set { Nombre_Comercial = value; } }
        public int telefono { get { return Telefono; } set { Telefono = value; } }
        public int estado_Contable { get { return Estado_Contable; } set { Estado_Contable = value; } }
        public string direccion { get { return Direccion; } set { Direccion = value; } }
        public string municipio { get { return Municipio; } set { Municipio = value; } }
        public string departamento { get { return Departamento; } set { Departamento = value; } }
        public string sat_Usuario { get { return Sat_Usuario; } set { Sat_Usuario = value; } }
        public string sat_Password { get { return Sat_Password; } set { Sat_Password = value; } }


        public void Ingresar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("IngresarContribuyente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@razon", SqlDbType.VarChar).Value = razon_social;
            cmd.Parameters.Add("@cui", SqlDbType.BigInt).Value = cui;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre_Comercial;
            cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = telefono;
            cmd.Parameters.Add("@estado_contable", SqlDbType.Int).Value = estado_Contable;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
            cmd.Parameters.Add("@municipio", SqlDbType.VarChar).Value = municipio;
            cmd.Parameters.Add("@departamento", SqlDbType.VarChar).Value = departamento;
            cmd.Parameters.Add("@sat_usuario", SqlDbType.BigInt).Value = sat_Usuario;
            cmd.Parameters.Add("@sat_password", SqlDbType.VarChar).Value = sat_Password;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Modificar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ModificarContribuyente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.Parameters.Add("@razon", SqlDbType.VarChar).Value = razon_social;
            cmd.Parameters.Add("@cui", SqlDbType.BigInt).Value = cui;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre_Comercial;
            cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = telefono;
            cmd.Parameters.Add("@estado_contable", SqlDbType.Int).Value = estado_Contable;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
            cmd.Parameters.Add("@municipio", SqlDbType.VarChar).Value = municipio;
            cmd.Parameters.Add("@departamento", SqlDbType.VarChar).Value = departamento;
            cmd.Parameters.Add("@sat_usuario", SqlDbType.BigInt).Value = sat_Usuario;
            cmd.Parameters.Add("@sat_password", SqlDbType.VarChar).Value = sat_Password;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Eliminar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("EliminarContribuyente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void Buscar()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarContribuyente", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);            
            razon_social = ds.Tables[0].Rows[0][1].ToString();
            cui = ds.Tables[0].Rows[0][2].ToString();
            nombre_Comercial = ds.Tables[0].Rows[0][3].ToString();
            telefono = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            estado_Contable = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            direccion = ds.Tables[0].Rows[0][6].ToString();
            municipio = ds.Tables[0].Rows[0][7].ToString();
            departamento = ds.Tables[0].Rows[0][8].ToString();
            sat_Usuario = ds.Tables[0].Rows[0][9].ToString();
            sat_Password = ds.Tables[0].Rows[0][10].ToString();                           
            cnn.Close();
        }

        public bool ValidacionDuplicadosContribuyentes()
        {
            bool duplicado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ValidacionDuplicadosContribuyentes", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
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

        public bool SiExiste()
        {
            bool encontrado;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarContribuyente", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count>=1)
            {
                encontrado = true;
            }
            else
            {
                encontrado = false;
            }
            cnn.Close();
            return encontrado;
        }

        public string BuscarContribuyentes()
        {
            string nombre;
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("BuscarContribuyente", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@nit", SqlDbType.BigInt).Value = nit;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                nombre = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                nombre = "No se encontro contribuyente";
            }
            cnn.Close();
            return nombre;
        }

        public DataSet Reporte()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("VistaContribuyente", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

    }
}
