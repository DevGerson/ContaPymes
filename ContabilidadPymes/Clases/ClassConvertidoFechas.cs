using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadPymes.Clases
{
    class ClassConvertidoFechas
    {

        public string DateString(string date,string formato)
        {
            DateTime dt;
            string convertidor;
            dt = DateTime.Parse(date);
            return convertidor = dt.ToString(formato);
        }

        public DateTime String_DateTime(string date,string formato)
        {
            return DateTime.ParseExact(date, formato, CultureInfo.CurrentCulture);
        }

    }
}
