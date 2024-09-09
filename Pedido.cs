using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

public class Pedido
{
    private int nro ;
    private string observacion ;
    private bool estado ;
    private Cliente cliente;
    private Cadete cadeteAsignado ;

    public int Nro { get => nro; set => nro = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public bool Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

    public Pedido() { }

    public Pedido(int nro, string observacion, bool estado, string nombreCliente , string direccionCliente , string telefonoCliente , string datosReferentesDireccion)
    {
        this.nro = nro;
        this.observacion = observacion;
        this.estado = estado;
        Cliente = new Cliente(nombreCliente , direccionCliente , telefonoCliente , datosReferentesDireccion);
    }

}