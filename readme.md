
# Api Rest MovieLand

La API MovieLand es diseñada para proporcionar servicios de gestión de películas, géneros, actores, salas de cine y usuarios que deseen realizar reseñas de películas. Esta API permite a los usuarios acceder a información detallada sobre películas, incluyendo detalles de género, actores y salas de cine, así como la capacidad de dejar y consultar reseñas y calificaciones de películas.

Elaborada con el framework Asp .NET Core 6, SQL Server 2022 y Visual Studio 2022.



## Instalación
- Clonar el repositorio
- Crear un User Secret con la siguiente llave y valor:

```json
  {
    "DefaultConnection": "Data Source=YOUR-SERVER;Initial Catalog=MovieLand;User=YOUR-USER;Password=YOUR-PASSWORD;"
  }
```

- Una vez configurada la cadena de conexión ejecutar el siguiente comando en el Package Manager Console.

```bash
  Update-Database
```

- Corre el proyecto.

    