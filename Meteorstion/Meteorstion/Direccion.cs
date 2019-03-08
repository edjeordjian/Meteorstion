using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Meteorstion
{
    public class Direccion
    {
        private String direccion;

        public Direccion()
        {
            direccion = "";
            String direccionHost = "";

            if (File.Exists("C:\\Meteorstion\\Direccion_Host.txt"))
            {
                StreamReader lectura = new StreamReader("C:\\Meteorstion\\Direccion_Host.txt");
                direccionHost = lectura.ReadLine();
            }

            direccion = direccionHost;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String direccionNueva)
        {
            direccion = direccionNueva;
        }
    }
}
