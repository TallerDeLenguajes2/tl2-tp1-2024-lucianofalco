/*
Se desea migrar además la carga de datos inicial a un archivo Json, sin perder la posibilidad
de seguir accediendo a los datos guardados en el archivo csv. Para ello se propone un nuevo
diseño de acceso a datos basado en los principios de herencia y polimorfismo.
Este nuevo diseño consta de una clase base llamada AccesoADatos y dos clases derivadas
llamadas AccesoCSV y AccesoJSON, donde se implementaran.
Refactorizar la clase AccesoADatos (que implementó en el práctico anterior) para que ésta
cumpla con lo solicitado.
Modifique la interfaz de usuario para que al inicio del sistema se pida que tipo de acceso usar
(CSV o JSON). y en función de esto instanciar el objeto a datos adecuado.
*/


public class AccesoCSV : AccesoADatos
{
    public override void EscribirCadetesArchivo(string rutaArchivo , List<Cadete> cadetes)
    {
        using (var writter = new StreamWriter(rutaArchivo))
        {
            foreach (var cadete in cadetes)
            {
                writter.WriteLine($"{cadete.Id},{cadete.Nombre},{cadete.Direccion},{cadete.Telefono}");
            }
        }
    }

    public override void EscribirPedidosArchivo(string rutaArchivo ,  List<Pedido> pedidos)
    {
        using (var writter = new StreamWriter(rutaArchivo))
        {
            foreach (var pedido in pedidos)
            {
                writter.WriteLine($"{pedido.Nro},{pedido.Observacion},{pedido.Estado},{pedido.Cliente.Nombre},{pedido.Cliente.Direccion},{pedido.Cliente.Telefono},{pedido.Cliente.DatosReferentesDireccion}");
            }
        }
    }

    public override List<Cadete> GetListCadetes(string rutaArchivo)
    {
        List<Cadete> cadetes = new List<Cadete>();
        string [] lineas = File.ReadAllLines(rutaArchivo);
        foreach (var linea in lineas)
        {
            var separador = linea.Split(',');
            int id = Convert.ToInt32(separador[0]);
            string nombre = separador[1];
            string direccion = separador[2];
            string telefono = separador[3];
            cadetes.Add(new Cadete(id , nombre , direccion , telefono));
        }
        return cadetes;
    }

    public override List<Pedido> GetListPedidos(string rutaArchivo)
    {
        List<Pedido> pedidos = new List<Pedido>();
        string [] lineas = File.ReadAllLines(rutaArchivo);
        foreach (var linea in lineas)
        {
            var separador = linea.Split(',');
            int nro = Convert.ToInt32(separador[0]);
            string observacion = separador[1];
            bool estado = Convert.ToBoolean(separador[2]);
            string nombreCliente = separador[3];
            string direccionCliente = separador[4];
            string telefonoCliente = separador[5];
            string datosReferentesDireccion = separador[6];
            pedidos.Add(new Pedido(nro , observacion , estado , nombreCliente , direccionCliente , telefonoCliente , datosReferentesDireccion));
        }
        return pedidos;
    }
}