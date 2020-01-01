using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadPymes.Clases
{
    class ClassProveedor
    {
        DataSet ds;

        public DataSet Reporte()
        {
            SqlConnection cnn = new SqlConnection(ConexionDataBase.InstacianConexion.StringConexion);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("ReporteProveedores", cnn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

    }
}
