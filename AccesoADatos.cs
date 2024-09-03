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


public abstract class AccesoADatos
{
    public abstract List<Cadete> GetListCadetes(string rutaArchivo);
    public abstract List<Pedido> GetListPedidos(string rutaArchivo);
        
    public abstract void EscribirCadetesArchivo(string rutaArchivo , List<Cadete> cadetes);
    public abstract void EscribirPedidosArchivo(string rutaArchivo , List<Pedido> pedidos);
}
