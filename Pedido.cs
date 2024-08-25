public class Pedido
{
    private int nro;
    private string observacion;
    private Cliente cliente;
    private bool estado;

    public int Nro { get => nro; set => nro = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public bool Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; }

    public Pedido(int nro, string observacion, bool estado, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferentesDireccion)
    {
        this.nro = nro;
        this.observacion = observacion;
        this.estado = estado;
        cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferentesDireccion);
    }

    public string VerDatosDelCliente()
    {
        string information = $"\tCliente nombre : {cliente.Nombre} \n Telefono: {cliente.Telefono} \n \tPedido : {Nro} Observacion: {observacion} \n Estado: {estado}";
        return information;
    }

    public string VerDireccionDelCliente()
    {
        string datos = $"Cliente: {cliente.Direccion}";
        return datos;
    }
}