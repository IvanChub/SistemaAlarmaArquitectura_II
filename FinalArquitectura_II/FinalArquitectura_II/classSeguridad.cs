using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalArquitectura_II
{
    public static class classSeguridad
    {
        //encriptamos la cadena o la clave de 4 digitos
        public static string Encriptar(this string _cadenaE)
        {
            string result = string.Empty;
            byte[] encriptacion = System.Text.Encoding.Unicode.GetBytes(_cadenaE);
            result = Convert.ToBase64String(encriptacion);
            return result;
        }

        //desencriptamos la clave de 4 digitos
        public static string Desencriptar(this string _cadenaD)
        {
            string result = string.Empty;
            byte[] desen = Convert.FromBase64String(_cadenaD);
            result = System.Text.Encoding.Unicode.GetString(desen);
            return result;
        }
    }
}
