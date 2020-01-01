using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ContabilidadPymes.Clases
{
    public class Validaciones
    {
        public void SoloLetrasOpcional(KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = true;
            else
                e.Handled = false;
        }

        public void SoloLetas(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 239)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }                
        }

        public void ValidacionMontos(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void ValidacionSeries(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci >= 164 && ascci <= 165)
            {
                e.Handled = false;
            }
            else if (ascci == 32)
            {                
                e.Handled = true;
            }            
        }

        public void ValidacionNumeroDeFacturas(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void SinEspacios(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci == 32)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void ValidacionFechas(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 47 && ascci <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


    }
}
