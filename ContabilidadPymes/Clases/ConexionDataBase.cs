using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ContabilidadPymes.Clases
{
    class ConexionDataBase
    {
        public string StringConexion = "Data Source = (local); Initial Catalog = BaseDatosPyme; Integrated Security = True";
        private static ConexionDataBase instacianConexion = null;

        public ConexionDataBase()
        {

        }

        public static ConexionDataBase InstacianConexion
        {
            get
            {
                if (instacianConexion == null)
                {
                    instacianConexion = new ConexionDataBase();

                }
                return instacianConexion;
            }
        }

    }
}
