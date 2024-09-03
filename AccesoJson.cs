

using System.Text.Json;

public class AccesoJson : AccesoADatos
{
    public override void EscribirCadetesArchivo(string rutaArchivo, List<Cadete> cadetes)
    {
        try
        {
            string cadetesJson = JsonSerializer.Serialize(cadetes);
            File.WriteAllText(rutaArchivo,cadetesJson);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error al guardar los cadetes en el archivo JSON: {ex.Message}");
            throw;
        }
    }

    public override void EscribirPedidosArchivo(string rutaArchivo, List<Pedido> pedidos)
    {
        try
        {
            string pedidosJson = JsonSerializer.Serialize(pedidos);
            File.WriteAllText(rutaArchivo , pedidosJson);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error al serialisar pedidos {ex.Message}");
            throw;
        }
    }

    public override List<Cadete> GetListCadetes(string rutaArchivo)
    {
        List<Cadete> cadetes = new List<Cadete>();

        try
        {
            if (File.Exists(rutaArchivo))
            {
                string jsonATxt = File.ReadAllText(rutaArchivo);
                if (!string.IsNullOrEmpty(jsonATxt))
                {
                    cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonATxt);
                }
                else
                {
                    Console.WriteLine("El archivo json esta vacio");
                }
            }
            else
            {
                Console.WriteLine("El archivo json no existe");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }

        return cadetes;
    }

    public override List<Pedido> GetListPedidos(string rutaArchivo)
    {
        List<Pedido> pedidos = new List<Pedido>();

        try
        {
            
        if (File.Exists(rutaArchivo))
        {
            if (!string.IsNullOrEmpty(rutaArchivo))
            {
                pedidos = JsonSerializer.Deserialize<List<Pedido>>(rutaArchivo);
            }
            else
            {
                Console.WriteLine("El archivo json esta vacio");
            }
        }
        else
        {
            Console.WriteLine("La ruta de la arcchivo no existe");
        }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }
        return pedidos;
    }
}