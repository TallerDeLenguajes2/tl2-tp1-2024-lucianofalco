public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

    public void GenerarInformeActividad()
    {
        Console.WriteLine($"Informe de Actividad de {Nombre}:");
        foreach (var cadete in listadoCadetes)
        {
            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"Jornal a cobrar: ${cadete.JornalCobrar()}");
            Console.WriteLine("Pedidos:");
            foreach (var pedido in cadete.ListarPedidos())
            {
                Console.WriteLine(pedido.VerDatosDelCliente);
            }
            Console.WriteLine();
        }
    }
    public void agregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }
    public void EliminarCadete(Cadete cadete)
    {
        foreach (var p in ListadoCadetes)
        {
            if (p.Id == cadete.Id)
            {
                listadoCadetes.Remove(cadete);
            }
        }
    }

    public Cadete BuscarCadetePorId(int id)
    {
        foreach (var cadete in listadoCadetes)
        {
            if (cadete.Id == id)
            {
                return cadete;
            }
        }
        return null;
    }
    public void ActualizarCadete(Cadete cadeteActualizado)
    {
        var cadete = BuscarCadetePorId(cadeteActualizado.Id);
        if (cadete != null)
        {
            cadete.Nombre = cadeteActualizado.Nombre;
            cadete.Direccion = cadeteActualizado.Direccion;
            cadete.Telefono = cadeteActualizado.Telefono;
        }
    }




}