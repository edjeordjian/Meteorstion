using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Meteorstion
{
    public class HostGestor
    {
        static void Main(string[] args)
        {
            ServiceHost gestor = null;
            bool exito = false;

            try
            {
                Uri urlServicio = new Uri(new Direccion().getDireccion()); //define la direccion donde se aloja el servicio definido 
                //en la clase Gestor

                gestor = new ServiceHost(typeof(Gestor), urlServicio); // define el tipo de host y la dirección del servicio

                BasicHttpBinding binding = new BasicHttpBinding(); // define el binding HTTP (algo necesario para que ande)
                /*binding.MaxReceivedMessageSize = 65536;// longitud de los mensajes por defecto */

                gestor.AddServiceEndpoint(typeof(IGestor), binding, ""); //agregar un extremo de servicio al host

                ServiceMetadataBehavior metadatos = new ServiceMetadataBehavior(); //inicializa los metadatos (algo necesario para que ande)
                metadatos.HttpGetEnabled = true; // permite el uso el HTTP para recuperar los metadatos
                gestor.Description.Behaviors.Add(metadatos); // agrega los metadatos al servicio

                gestor.Open(); // abre el host del servicio para exponer este último

                exito = true;

                Console.WriteLine("Servicio alojado en " + urlServicio.AbsoluteUri + 
                    "\n\nPresione cualquier tecla para cerrar el servicio."); // muestra un mensaje de donde se aloja el servicio 
                // que se esta exponiendo
                Console.ReadKey();
            }

            catch
            {
                Console.WriteLine("Hubo un error al iniciar el serivicio.\n\nRecuerde que"
                + "debe ejecutar este programa con privilegios de administrador" + 
                "\n\nPresione cualquier tecla para salir");
                Console.ReadKey();
            }

            finally
            {
                if(exito)
                gestor.Close(); // cierra el host, dejando de exponer el servicio
            }
        }
    }
}
