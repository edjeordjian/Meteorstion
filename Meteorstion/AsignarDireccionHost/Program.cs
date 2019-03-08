using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AsignadorDeDireccionHost
{
    class Program
    {
        static void Main(string[] args)
        {
            String direccion = null;
            Console.WriteLine("Ingrese la dirección donde se aloja el servicio");
            direccion = Console.ReadLine();

            if (File.Exists("C:\\Meteorstion\\Direccion_Host.txt"))
            {
                File.Delete("C:\\Meteorstion\\Direccion_Host.txt");
            }

            StreamWriter archivo = new StreamWriter("C:\\Meteorstion\\Direccion_Host.txt", true);
            archivo.Write(direccion);
            archivo.Close();
        }
    }
}
