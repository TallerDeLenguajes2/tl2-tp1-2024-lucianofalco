using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadPedidos { get => listadPedidos; set => listadPedidos = value; }

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public double JornalCobrar()
    {
        int contador = 0;
        foreach (var pedido in ListadPedidos)
        {
            if (pedido.Estado)
            {
                contador++;
            }
        }
        return Convert.ToDouble(contador * 500);
    }

    public void EliminarPedido(Pedido pedido)
    {
        listadPedidos.RemoveAll(p => p.Nro == pedido.Nro);
    }

    public void AgregarPedido(Pedido pedido)
    {
        if (pedido != null)
        {
            ListadPedidos.Add(pedido);
        }
    }

    public List<Pedido> ListarPedidos()
    {
        return listadPedidos;
    }

    public static List<Cadete> CargarDesdeCsv(string rutaArchivo)
    {
        List<Cadete> cadetes = new List<Cadete>();

        using (var reader = new StreamReader(rutaArchivo))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,  // Desactivar validación de cabeceras
            MissingFieldFound = null // Desactivar validación de campos faltantes
        }))
        {
            // Leer los registros de Cadete sin validar las cabeceras
            cadetes = csv.GetRecords<Cadete>().ToList();
        }

        return cadetes;
    }
}