Sistema de Gestión de Productos en C# (.NET Console)

¡Hola! Soy Héctor Gianmarco Arrasco Juarez, estudiante de Ingeniería de Sistemas. Este es mi primer proyecto completo en C# y .NET, desarrollado como parte de mi portafolio.


¿De qué trata?

Este sistema de consola simula un pequeño gestor de productos para una empresa. Permite:

- Agregar productos nuevos
- Buscar productos por nombre o por rango de precios
- Actualizar stock con validación
- Eliminar productos del inventario
- Guardar y cargar el inventario desde un archivo JSON
- Aplicar buenas prácticas de programación orientada a objetos (POO)


Tecnologías utilizadas

| Tecnología        | Uso principal                                   |
|-------------------|-------------------------------------------------|
| C# / .NET 9       | Lenguaje y plataforma de desarrollo del sistema |
| Newtonsoft.Json   | Serialización y deserialización de objetos      |
| System.IO         | Lectura y escritura de archivos JSON            |
| LINQ              | Búsqueda avanzada en colecciones                |
| async / await     | Operaciones asincrónicas                        |
| POO               | Herencia, interfaces, validaciones, excepciones |


Estructura del proyecto

SistemaGestionProductos/
├── Clases/
│   ├── Producto.cs
│   ├── ProductoSimple.cs
│   ├── IProducto.cs
│   └── ProductoNoEncontradoException.cs
│   └── Inventario.cs
├── Program.cs
├── inventario.json
├── SistemaGestionProductos.csproj
├── README.md
└── .gitignore


¿Por qué hice este proyecto?

Lo desarrollé para practicar y demostrar mi dominio de los fundamentos de .NET y C#, no solo desde lo técnico, sino desde una perspectiva organizacional y profesional.  
Este sistema usa una arquitectura modular, validaciones de entrada, operaciones asincrónicas, manejo de errores personalizados y estructura clara, como si fuera parte de un sistema real.


Próximas mejoras

- Interfaz gráfica (Windows Forms o WPF)
- Sistema de autenticación por roles
- Generación de reportes (PDF, Excel)
- 🗃Uso de base de datos en vez de archivo JSON


Sobre mí

Me interesa especialmente la rama de software y sistemas de información, con foco en backend y lógica de negocio.  
Este proyecto forma parte de mi portafolio para mostrar mi evolución como Ingeniero de Sistemas.

LinkedIn: https://www.linkedin.com/in/hector-a-3b1200304)

¡Gracias por visitar este proyecto!
