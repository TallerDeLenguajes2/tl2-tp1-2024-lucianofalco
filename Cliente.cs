public class Cliente{
    private string nombre ;
    private string direccion ; 
    private string telefono ; 
    private string datosReferentesDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosReferentesDireccion { get => datosReferentesDireccion; set => datosReferentesDireccion = value; }

    public Cliente(string nombre, string direccion, string telefono, string datosReferentesDireccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosReferentesDireccion = datosReferentesDireccion;
    }

    
}