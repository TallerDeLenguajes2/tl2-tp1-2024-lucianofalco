
        Pedido pedido1 = new Pedido(1, "Entrega urgente", false, "Juan Pérez", "Calle Falsa 123", "123456789", "Entre A y B");
        Pedido pedido2 = new Pedido(2, "Entrega estándar", false, "María García", "Avenida Siempreviva 742", "987654321", "casa esquiba");
        Pedido pedido3 = new Pedido(3, "Entrega estándar", false, "fabri lencina", "matheu 1793", "987654321", "Frente al super");
        Pedido pedido4 = new Pedido(4, "Entrega estándar", false, "favio leguina", "Avellaneda 222", "987654321", "Frente a canal sur");
        Pedido pedido5 = new Pedido(5, "Entrega estándar", false, "mario marito", "San juan 1813", "987654321", "Planta baja");
        Pedido pedido6 = new Pedido(6, "Entrega estándar", false, "luciano falco", "Calle verdadera 321", "987654321", "depto 3");
        Pedido pedido7 = new Pedido(7, "Entrega estándar", false, "sheyla astorga", "pasaje ponja 9115", "987654321", "piso 4 oficina 6");

        Cadete cadete1 = new Cadete(1, "Pedro", "Calle Ejemplo 1", "5551111", new List<Pedido>());
        Cadete cadete2 = new Cadete(2, "Ana", "Calle Ejemplo 2", "5552222", new List<Pedido>());
        cadete1.ListadPedidos.Add(pedido1);
        cadete1.ListadPedidos.Add(pedido2);
        cadete1.ListadPedidos.Add(pedido3);
        cadete1.ListadPedidos.Add(pedido4);
        cadete2.ListadPedidos.Add(pedido5);
        cadete2.ListadPedidos.Add(pedido6);
        cadete2.ListadPedidos.Add(pedido7);

        Cadeteria cadeteria = new Cadeteria("Cadetería Rápida", "5551234", new List<Cadete> { cadete1, cadete2 });


        cadete1.ListadPedidos.Add(pedido2);

        Console.WriteLine($"Cadete: {cadete1.Nombre} $"+cadete1.JornalCobrar());
        Console.WriteLine($"Cadete: {cadete2.Nombre} $"+cadete2.JornalCobrar());

    
