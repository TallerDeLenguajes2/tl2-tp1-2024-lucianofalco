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

    public string VerDatosDelCliente()
    {
        string information = $"\tCliente nombre : {Cliente.Nombre} \n Telefono: {Cliente.Telefono} \n \tPedido : {Nro} Observacion: {Observacion} \n Estado: {Estado}";
        return information;
    }

    public string VerDireccionDelCliente()
    {
        string datos = $"Direccion: {Cliente.Direccion}";
        return datos;
    }

    public static List<Pedido> CargarPedidosDesdeCsv(string rutaArchivo)
    {
        List<Pedido> pedidos = new List<Pedido>();

        using (var reader = new StreamReader(rutaArchivo))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        }))
        {
            pedidos = csv.GetRecords<Pedido>().ToList();
        }

        return pedidos;
    }
}