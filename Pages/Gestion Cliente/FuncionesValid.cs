using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public static class FuncionesValid
    {
        

        public static bool CedulaValida(string cedu)
        {
            string fallo = "";
            bool valido = false;
            int ver = 0;
            int dig = 0;
            int digver = 0;
            int digImpar = 0;
            int par = 0;
            int impar = 0;
            int cantidad = Convert.ToInt32(cedu.Length);

            try
            {

                if (cantidad == 11)
                {
                    digver = Convert.ToInt32(cedu.Substring(10, 1));

                    for (int i = 9; i >= 0; i--)
                    {

                        dig = Convert.ToInt32(cedu.Substring(i, 1));
                        if ((i % 2) != 0)
                        {
                            digImpar = dig * 2;

                            if (digImpar >= 10)
                            {
                                digImpar = digImpar - 9;
                            }
                            impar = impar + digImpar;
                        }

                        else
                        {
                            par = par + dig;
                        }
                    }

                    ver = 10 - ((par + impar) % 10);

                    if (((ver == 10) && (digver == 0))
                         || (ver == digver))
                    {
                        return  true;
                    }
                    else
                    {
                        fallo = "Invalida";
                    }
                }
                else
                {
                    fallo = "La cedula debe contener once digitos";
                }
            }
            catch
            {
                fallo += "No se pudo validar la cédula";
            }
            return false;
        }
    }
}
