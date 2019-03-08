using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Meteorstion
{
    [ServiceContract]
    interface IGestor
    {
        [OperationContract]
        int asignarNumeroJugador();

        [OperationContract]
        int getPuntajeJ1();

        [OperationContract]
        int getPuntajeJ2();

        [OperationContract]
        bool getVictoriaJ1();

        [OperationContract(IsOneWay=true)]
        void setVictoriaJ1(bool valor);

        [OperationContract]
        bool getVictoriaJ2();

        [OperationContract(IsOneWay = true)]
        void setVictoriaJ2(bool valor);

        [OperationContract]
        int getvidapj1();

        [OperationContract]
        int getvidapj2();

        [OperationContract(IsOneWay = true)]
        void setvidapj1(int vida);

        [OperationContract(IsOneWay = true)]
        void setvidapj2(int vida);

        [OperationContract(IsOneWay = true)]
        void setControl1(bool valor);

        [OperationContract]
        bool getControl1();

    }
}
