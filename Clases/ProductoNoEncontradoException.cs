using System;

public class ProductoNoEncontradoException : Exception
{
    public ProductoNoEncontradoException(string mensaje) : base(mensaje) { }
}
