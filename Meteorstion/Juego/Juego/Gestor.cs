﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IGestor")]
public interface IGestor
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/asignarNumeroJugador", ReplyAction="http://tempuri.org/IGestor/asignarNumeroJugadorResponse")]
    int asignarNumeroJugador();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/asignarNumeroJugador", ReplyAction="http://tempuri.org/IGestor/asignarNumeroJugadorResponse")]
    System.Threading.Tasks.Task<int> asignarNumeroJugadorAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getPuntajeJ1", ReplyAction="http://tempuri.org/IGestor/getPuntajeJ1Response")]
    int getPuntajeJ1();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getPuntajeJ1", ReplyAction="http://tempuri.org/IGestor/getPuntajeJ1Response")]
    System.Threading.Tasks.Task<int> getPuntajeJ1Async();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getPuntajeJ2", ReplyAction="http://tempuri.org/IGestor/getPuntajeJ2Response")]
    int getPuntajeJ2();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getPuntajeJ2", ReplyAction="http://tempuri.org/IGestor/getPuntajeJ2Response")]
    System.Threading.Tasks.Task<int> getPuntajeJ2Async();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getVictoriaJ1", ReplyAction="http://tempuri.org/IGestor/getVictoriaJ1Response")]
    bool getVictoriaJ1();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getVictoriaJ1", ReplyAction="http://tempuri.org/IGestor/getVictoriaJ1Response")]
    System.Threading.Tasks.Task<bool> getVictoriaJ1Async();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setVictoriaJ1")]
    void setVictoriaJ1(bool valor);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setVictoriaJ1")]
    System.Threading.Tasks.Task setVictoriaJ1Async(bool valor);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getVictoriaJ2", ReplyAction="http://tempuri.org/IGestor/getVictoriaJ2Response")]
    bool getVictoriaJ2();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getVictoriaJ2", ReplyAction="http://tempuri.org/IGestor/getVictoriaJ2Response")]
    System.Threading.Tasks.Task<bool> getVictoriaJ2Async();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setVictoriaJ2")]
    void setVictoriaJ2(bool valor);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setVictoriaJ2")]
    System.Threading.Tasks.Task setVictoriaJ2Async(bool valor);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getvidapj1", ReplyAction="http://tempuri.org/IGestor/getvidapj1Response")]
    int getvidapj1();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getvidapj1", ReplyAction="http://tempuri.org/IGestor/getvidapj1Response")]
    System.Threading.Tasks.Task<int> getvidapj1Async();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getvidapj2", ReplyAction="http://tempuri.org/IGestor/getvidapj2Response")]
    int getvidapj2();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getvidapj2", ReplyAction="http://tempuri.org/IGestor/getvidapj2Response")]
    System.Threading.Tasks.Task<int> getvidapj2Async();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setvidapj1")]
    void setvidapj1(int vida);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setvidapj1")]
    System.Threading.Tasks.Task setvidapj1Async(int vida);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setvidapj2")]
    void setvidapj2(int vida);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setvidapj2")]
    System.Threading.Tasks.Task setvidapj2Async(int vida);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setControl1")]
    void setControl1(bool valor);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGestor/setControl1")]
    System.Threading.Tasks.Task setControl1Async(bool valor);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getControl1", ReplyAction="http://tempuri.org/IGestor/getControl1Response")]
    bool getControl1();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGestor/getControl1", ReplyAction="http://tempuri.org/IGestor/getControl1Response")]
    System.Threading.Tasks.Task<bool> getControl1Async();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IGestorChannel : IGestor, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class GestorClient : System.ServiceModel.ClientBase<IGestor>, IGestor
{
    
    public GestorClient()
    {
    }
    
    public GestorClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public GestorClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public GestorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public GestorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int asignarNumeroJugador()
    {
        return base.Channel.asignarNumeroJugador();
    }
    
    public System.Threading.Tasks.Task<int> asignarNumeroJugadorAsync()
    {
        return base.Channel.asignarNumeroJugadorAsync();
    }
    
    public int getPuntajeJ1()
    {
        return base.Channel.getPuntajeJ1();
    }
    
    public System.Threading.Tasks.Task<int> getPuntajeJ1Async()
    {
        return base.Channel.getPuntajeJ1Async();
    }
    
    public int getPuntajeJ2()
    {
        return base.Channel.getPuntajeJ2();
    }
    
    public System.Threading.Tasks.Task<int> getPuntajeJ2Async()
    {
        return base.Channel.getPuntajeJ2Async();
    }
    
    public bool getVictoriaJ1()
    {
        return base.Channel.getVictoriaJ1();
    }
    
    public System.Threading.Tasks.Task<bool> getVictoriaJ1Async()
    {
        return base.Channel.getVictoriaJ1Async();
    }
    
    public void setVictoriaJ1(bool valor)
    {
        base.Channel.setVictoriaJ1(valor);
    }
    
    public System.Threading.Tasks.Task setVictoriaJ1Async(bool valor)
    {
        return base.Channel.setVictoriaJ1Async(valor);
    }
    
    public bool getVictoriaJ2()
    {
        return base.Channel.getVictoriaJ2();
    }
    
    public System.Threading.Tasks.Task<bool> getVictoriaJ2Async()
    {
        return base.Channel.getVictoriaJ2Async();
    }
    
    public void setVictoriaJ2(bool valor)
    {
        base.Channel.setVictoriaJ2(valor);
    }
    
    public System.Threading.Tasks.Task setVictoriaJ2Async(bool valor)
    {
        return base.Channel.setVictoriaJ2Async(valor);
    }
    
    public int getvidapj1()
    {
        return base.Channel.getvidapj1();
    }
    
    public System.Threading.Tasks.Task<int> getvidapj1Async()
    {
        return base.Channel.getvidapj1Async();
    }
    
    public int getvidapj2()
    {
        return base.Channel.getvidapj2();
    }
    
    public System.Threading.Tasks.Task<int> getvidapj2Async()
    {
        return base.Channel.getvidapj2Async();
    }
    
    public void setvidapj1(int vida)
    {
        base.Channel.setvidapj1(vida);
    }
    
    public System.Threading.Tasks.Task setvidapj1Async(int vida)
    {
        return base.Channel.setvidapj1Async(vida);
    }
    
    public void setvidapj2(int vida)
    {
        base.Channel.setvidapj2(vida);
    }
    
    public System.Threading.Tasks.Task setvidapj2Async(int vida)
    {
        return base.Channel.setvidapj2Async(vida);
    }
    
    public void setControl1(bool valor)
    {
        base.Channel.setControl1(valor);
    }
    
    public System.Threading.Tasks.Task setControl1Async(bool valor)
    {
        return base.Channel.setControl1Async(valor);
    }
    
    public bool getControl1()
    {
        return base.Channel.getControl1();
    }
    
    public System.Threading.Tasks.Task<bool> getControl1Async()
    {
        return base.Channel.getControl1Async();
    }
}