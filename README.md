# WebApp_EFCMySql

## Información general
***
Ejemplo de API Rest usando Entity Framework Core con MySql 

## Tecnologias
***
Uso del las siguientes tecnologías:
* .NET 6
* Microsoft.EntityFrameworkCore Version="6.0.7"
* Microsoft.EntityFrameworkCore.Design Version="6.0.7"
* Microsoft.EntityFrameworkCore.Tools Version="6.0.7"
* Pomelo.EntityFrameworkCore.MySql Version="6.0.2"
* Visual Studio 2022 - Visual Studio Code

## Installation
***
* Configurar una base de datos MySql
* Crear la Base de Datos
* Clonar el proyecto
* Abrir la solucion y ejecutar los siguientes comandos:

###.NET CLI:
Generar directorio Migrations con las respectivas clases:
* dotnet ef migrations add InitialCreate -p Persistencia/ -s WebApp_ConMySql/

Generar tablas en la base de datos:
* dotnet ef database update -p Persistencia/ -s WebApp_ConMySql/

### Visual Studio:
* Add-Migration "Initial Migration" -Context MySQLDBContext
* Update-Database -Context MySQLDBContext

Finalmente, ejecutar el proyecto para probar mediante Swagger.