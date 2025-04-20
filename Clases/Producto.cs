public abstract class Producto : IProducto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; }

    public Producto(string nombre, double precio, int stock, string categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
        Categoria = categoria;
    }

    public abstract void MostrarInfo();

    public bool ValidarPrecio(double precio)
    {
        return precio > 0;
    }

    public bool ValidarStock(int stock)
    {
        return stock >= 0;
    }
}
