using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Inventario inventario = new();
        string ruta = "inventario.json";
        await inventario.CargarInventarioAsync(ruta);

        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Gestor de Inventario");
            Console.WriteLine("1. Mostrar Inventario");
            Console.WriteLine("2. Buscar Producto");
            Console.WriteLine("3. Agregar Producto");
            Console.WriteLine("4. Actualizar Stock");
            Console.WriteLine("5. Eliminar Producto");
            Console.WriteLine("6. Buscar por Rango de Precio");
            Console.WriteLine("7. Guardar Cambios");
            Console.WriteLine("8. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    inventario.MostrarInventario();
                    break;

                case "2":
                    Console.Write("Nombre del producto: ");
                    string nombreBuscar = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombreBuscar))
                    {
                        Console.WriteLine("Debes ingresar un nombre de producto.");
                        break;
                    }

                    try
                    {
                        var p = inventario.BuscarProducto(nombreBuscar);
                        p.MostrarInfo();
                    }
                    catch (ProductoNoEncontradoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "3":
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre no puede estar vacío.");
                        break;
                    }

                    Console.Write("Precio: ");
                    if (!double.TryParse(Console.ReadLine(), out double precio))
                    {
                        Console.WriteLine("Precio inválido.");
                        break;
                    }

                    Console.Write("Stock: ");
                    if (!int.TryParse(Console.ReadLine(), out int stock))
                    {
                        Console.WriteLine("Stock inválido.");
                        break;
                    }

                    Console.Write("Categoría: ");
                    string categoria = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(categoria))
                    {
                        Console.WriteLine("La categoría no puede estar vacía.");
                        break;
                    }

                    var nuevo = new ProductoSimple(nombre, precio, stock, categoria);

                    if (!nuevo.ValidarPrecio(precio))
                    {
                        Console.WriteLine("El precio debe ser mayor que 0.");
                        break;
                    }

                    if (!nuevo.ValidarStock(stock))
                    {
                        Console.WriteLine("El stock no puede ser negativo.");
                        break;
                    }

                    inventario.AgregarProducto(nuevo);
                    Console.WriteLine("Producto agregado.");
                    break;

                case "4":
                    Console.Write("Nombre del producto: ");
                    string nombreActualizar = Console.ReadLine();

                    Console.Write("Cantidad a agregar (puede ser negativa): ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad))
                    {
                        Console.WriteLine("Cantidad inválida.");
                        break;
                    }

                    try
                    {
                        var producto = inventario.BuscarProducto(nombreActualizar);
                        int nuevoStock = producto.Stock + cantidad;

                        if (!producto.ValidarStock(nuevoStock))
                        {
                            Console.WriteLine("El stock total no puede ser negativo.");
                            break;
                        }

                        producto.Stock = nuevoStock;
                        Console.WriteLine($"Stock actualizado para {producto.Nombre}. Nuevo stock: {producto.Stock}");
                    }
                    catch (ProductoNoEncontradoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "5":
                    Console.Write("Nombre del producto a eliminar: ");
                    string nombreEliminar = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombreEliminar))
                    {
                        Console.WriteLine("Debes ingresar un nombre de producto.");
                        break;
                    }

                    try
                    {
                        inventario.EliminarProducto(nombreEliminar);
                        Console.WriteLine("Producto eliminado.");
                    }
                    catch (ProductoNoEncontradoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "6":
                    Console.Write("Precio mínimo: ");
                    if (!double.TryParse(Console.ReadLine(), out double min))
                    {
                        Console.WriteLine("Precio mínimo inválido.");
                        break;
                    }

                    Console.Write("Precio máximo: ");
                    if (!double.TryParse(Console.ReadLine(), out double max))
                    {
                        Console.WriteLine("Precio máximo inválido.");
                        break;
                    }

                    var lista = inventario.BuscarPorPrecio(min, max);
                    if (lista.Count == 0)
                        Console.WriteLine("No se encontraron productos.");
                    else
                        lista.ForEach(p => p.MostrarInfo());
                    break;

                case "7":
                    await inventario.GuardarInventarioAsync(ruta);
                    Console.WriteLine("Cambios guardados.");
                    break;

                case "8":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }
    }
}