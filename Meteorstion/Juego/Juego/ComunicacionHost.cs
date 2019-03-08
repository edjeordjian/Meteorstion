using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using System.IO;

namespace Meteorstion
{
    public class ComunicacionHost
    {
        private EndpointAddress direccion;
        private BasicHttpBinding binding;
        private GestorClient llamada;

        public ComunicacionHost()
        {
            String direccionHost = "";

            if (File.Exists("C:\\Meteorstion\\Direccion_Host.txt"))
            {
                StreamReader lectura = new StreamReader("C:\\Meteorstion\\Direccion_Host.txt");
                direccionHost = lectura.ReadLine();

                direccion = new EndpointAddress(direccionHost);
                binding = new BasicHttpBinding();
                /*binding.MaxReceivedMessageSize = 65536;// longitud de los mensajes por defecto */
                llamada = new GestorClient(binding, direccion);
            }

        }

        public int getvidapj1()
        {
            int vida = llamada.getvidapj1();

            return vida;
        }
        public int getvidapj2()
        {
            int vida = llamada.getvidapj2();

            return vida;
        }
        public void transferirVidaJugador1(int vida)
        {
            llamada.setvidapj1Async(vida);
        }

        public void transferirVidaJugador2(int vida)
        {
            llamada.setvidapj2Async(vida);
        }

        public int pedidoDeNumeroDeJugador()
        {
            int devolucion = 0;

            try
            {
                devolucion = llamada.asignarNumeroJugador();
            }

            catch
            {
                MessageBox.Show("No se ha iniciado el servicio de Meteorstion.", "Aviso de Meteorstion", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation);
            }

            return devolucion;
        }

        public void setControl1(bool valor)
        {
            llamada.setControl1(valor);
        }

        public bool getControl1()
        {
            return llamada.getControl1();
        }

        public void setVidasj1(int valor)
        {
            llamada.setvidapj1(valor);
        }

        public void setVidasj2(int valor)
        {
            llamada.setvidapj2(valor);
        }

        public int getPuntajeJ1()
        {
            return llamada.getPuntajeJ1();
        }

        public int getPuntajeJ2()
        {
            return llamada.getPuntajeJ2();
        }

        public bool getVictoriaJ1()
        {
            return llamada.getVictoriaJ1();
        }

        public void setVictoriaJ1(bool valor)
        {
            llamada.setVictoriaJ1(valor);
        }

        public bool getVictoriaJ2()
        {
            return llamada.getVictoriaJ2();
        }

        public void setVictoriaJ2(bool valor)
        {
            llamada.setVictoriaJ2(valor);
        }
    }
}
