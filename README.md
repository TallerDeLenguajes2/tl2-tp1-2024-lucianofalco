
## Relaciones entre Clases

### Composición
- **Pedido y Cliente**: La relación entre `Pedido` y `Cliente` se realiza por composición. Un `Pedido` crea y gestiona un `Cliente` internamente. El ciclo de vida del `Cliente` está completamente controlado por el `Pedido`, y cuando se elimina un `Pedido`, el `Cliente` también se elimina.

### Agregación
- **Cadetería y Cadete**: La relación entre `Cadetería` y `Cadete` se realiza por agregación. Una `Cadetería` puede tener varios `Cadetes`, pero un `Cadete` puede existir independientemente de una `Cadetería`. Los `Cadetes` pueden ser asignados o reasignados a diferentes `Cadeterías`.

## Métodos Recomendados

### Clase Cadetería
- `GenerarInformeActividad()`: Genera un informe detallado sobre la actividad de todos los cadetes y pedidos.
- `AgregarCadete(Cadete cadete)`: Añade un nuevo cadete a la cadetería.
- `EliminarCadete(Cadete cadete)`: Elimina un cadete de la cadetería.
- `BuscarCadetePorId(int id)`: Busca un cadete por su ID.
- `ActualizarCadete(Cadete cadete)`: Actualiza la información de un cadete existente.

### Clase Cadete
- `EliminarPedido(Pedido pedido)`: Elimina un pedido de la lista de pedidos del cadete.
- `JornalCobrar()`: Calcula el jornal total a cobrar por el cadete basado en el número de pedidos entregados.
- `AgregarPedido(Pedido pedido)`: Añade un nuevo pedido a la lista de pedidos del cadete.
- `ListarPedidos()`: Devuelve una lista de todos los pedidos asignados al cadete.

## Principios de Abstracción y Ocultamiento

### Atributos y Propiedades

- **Públicos**: Deben ser accesibles desde fuera de la clase si se necesita leer o modificar estos valores.
  - `Cadete.Id`
  - `Cadete.Nombre`
  - `Cadete.Direccion`
  - `Cadete.Telefono`
  - `Pedido.Nro`
  - `Pedido.Observacion`
  - `Pedido.Estado`
  - `Cliente.Nombre`
  - `Cliente.Direccion`
  - `Cliente.Telefono`
  - `Cliente.DatosReferentesDireccion`

- **Privados**: Deben ser ocultos y accesibles solo dentro de la clase para proteger la integridad de los datos.
  - `Cadete.listadPedidos`
  - `Pedido.cliente`
  - `Cliente.direccion`
  - `Cliente.telefono`
  - `Cliente.datosReferentesDireccion`

### Métodos

- **Públicos**: Métodos que se deben exponer para que otras partes del sistema puedan interactuar con la clase.
  - `Cadete.JornalCobrar()`
  - `Cadete.ListarPedidos()`
  - `Cadetería.GenerarInformeActividad()`
  - `Cadetería.AgregarCadete()`
  - `Pedido.VerDatosDelCliente()`
  - `Pedido.VerDireccionDelCliente()`

- **Privados**: Métodos que deben ser utilizados solo dentro de la clase para mantener la encapsulación.
  - `Cadete.EliminarPedido(Pedido pedido)`
  - `Cadetería.BuscarCadetePorId(int id)`