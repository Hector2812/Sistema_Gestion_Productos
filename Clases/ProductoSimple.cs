using System;

public class ProductoSimple : Producto
{
    public ProductoSimple(string nombre, double precio, int stock, string categoria)
        : base(nombre, precio, stock, categoria)
    {
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Producto: {Nombre}, Precio: {Precio:C}, Stock: {Stock}, Categoría: {Categoria}");
    }
}
