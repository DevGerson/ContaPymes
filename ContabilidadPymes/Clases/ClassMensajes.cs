using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContabilidadPymes.Ventanas;

namespace ContabilidadPymes.Clases
{
    class ClassMensajes
    {
        vtnMensajes vtnMensajes;

        public void MensajesCortos(string titulo, string mensaje)
        {
            vtnMensajes = new vtnMensajes();
            vtnMensajes.Mensajes(titulo,mensaje);
            vtnMensajes.Show();
        }


    }
}
