using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Meteorstion
{
    public class Calculo
    {
        int operando1;
        int operando2;
        int resultado;
        int resultadoM1;
        int resultadoM2;
        char simbolo;
        string cuenta;

        public Calculo()
        {
            Random variableAzar = new Random();

            operando1 = variableAzar.Next(1, 11);
            operando2 = variableAzar.Next(1, 11);

            simbolo = 'x';
            resultado = operando2 * operando1;

            resultadoM1 = resultado - 3;

            try
            {
                resultadoM2 = variableAzar.Next(resultado - 3, resultadoM1 * 2);
            }

            catch
            {
                resultadoM2 = resultadoM1 + 1;
            }

            while (resultadoM2 == resultado || resultadoM1 == resultadoM2)
            {
                resultadoM2 = variableAzar.Next(resultadoM1, resultado + 1);
            }

            cuenta = operando1.ToString() + " " + simbolo.ToString() + " " + operando2.ToString();

        }

        // getters y setters
        public int getResultado()
        {
            return resultado;
        }

        public int getResultadoM1()
        {
            return resultadoM1;
        }

        public int getResultadoM2()
        {
            return resultadoM2;
        }

        public string getCuenta()
        {
            return cuenta;
        }
    }

}
