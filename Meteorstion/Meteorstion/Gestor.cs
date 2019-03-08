using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace Meteorstion
{
    public class Gestor : IGestor
    {
        private static int vidapj1;
        private static int vidapj2;
        private static bool control1 = false;
        private static int puntajej1 = 0;
        private static int puntajej2 = 0;
        private static bool victoriaJ1=false;
        private static bool victoriaJ2=false;

        public void setvidapj1(int vida)
        {
            vidapj1 = vida;
        }

        public void setvidapj2(int vida)
        {
            vidapj2 = vida;
        }

        public int getvidapj1()
        {
            return vidapj1;
        }

        public int getvidapj2()
        {
            return vidapj2;
        }

        public int asignarNumeroJugador()
        {
            int numeroJugador = 0;

            if (File.Exists("C:\\Meteorstion\\referenciaJugadores.txt"))
            {
                File.Delete("C:\\Meteorstion\\referenciaJugadores.txt");
                numeroJugador = 2;
            }

            else
            {
                StreamWriter archivo = new StreamWriter("C:\\Meteorstion\\referenciaJugadores.txt", true);
                archivo.Close();
                numeroJugador = 1;
            }

            return numeroJugador;

        }
   
        public void setControl1(bool valor)
        {
            control1 = valor;
        }

        public bool getControl1()
        {
            return control1;
        }

        public int getPuntajeJ1()
        {
            return puntajej1;
        }

        public int getPuntajeJ2()
        {
            return puntajej2;
        }

        public bool getVictoriaJ1()
        {
            return victoriaJ1;
        }

        public void setVictoriaJ1(bool valor)
        {
            victoriaJ1 = valor;
        }

        public bool getVictoriaJ2()
        {
            return victoriaJ2;
        }

        public void setVictoriaJ2(bool valor)
        {
            victoriaJ2 = valor;
        }

    }
}