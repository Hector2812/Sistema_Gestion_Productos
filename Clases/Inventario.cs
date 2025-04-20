using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class Inventario
{
    private List<Producto> productos = new();

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public Producto BuscarProducto(string nombre)
    {
        var producto = productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto == null)
            throw new ProductoNoEncontradoException("Producto no encontrado.");
        return producto;
    }

    public void EliminarProducto(string nombre)
    {
        var producto = BuscarProducto(nombre);
        productos.Remove(producto);
    }

    public List<Producto> BuscarPorPrecio(double precioMin, double precioMax)
    {
        return productos.Where(p => p.Precio >= precioMin && p.Precio <= precioMax).ToList();
    }

    public void MostrarInventario()
    {
        if (!productos.Any())
        {
            Console.WriteLine("El inventario está vacío.");
            return;
        }

        foreach (var producto in productos)
        {
            producto.MostrarInfo();
        }
    }

    public async Task GuardarInventarioAsync(string archivo)
    {
        string json = JsonConvert.SerializeObject(productos, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        await File.WriteAllTextAsync(archivo, json);
    }

    public async Task CargarInventarioAsync(string archivo)
    {
        if (!File.Exists(archivo))
        {
            productos = new List<Producto>();
            await GuardarInventarioAsync(archivo);
        }
        else
        {
            string contenido = await File.ReadAllTextAsync(archivo);
            productos = string.IsNullOrWhiteSpace(contenido)
                ? new List<Producto>()
                : JsonConvert.DeserializeObject<List<Producto>>(contenido, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }) ?? new List<Producto>();
        }
    }
}
