# 🚀 Conferencia Descubriendo el Mundo del Backend con C# y SQLite

¡Bienvenidos al repositorio oficial de la conferencia! En esta sesión exploramos los cimientos del desarrollo Backend utilizando **C#** y la versatilidad de **SQLite** como motor de persistencia.

Este proyecto es una guía práctica diseñada para estudiantes de Ingeniería (USAC) que desean dar sus primeros pasos en la arquitectura de sistemas y la gestión de bases de datos.

---

## 🛠️ Preparando el Entorno de Trabajo

Para ejecutar este proyecto en tu computadora, asegúrate de tener instaladas las siguientes herramientas:

1.  **Visual Studio Code (IDE):** [Descargar aquí](https://code.visualstudio.com/download)
2.  **SDK de .NET 10:** [Descargar aquí](https://dotnet.microsoft.com/es-es/download)
3.  **DB Browser for SQLite:** [Descargar aquí](https://sqlitebrowser.org/dl/) - *Indispensable para visualizar tu base de datos.*

---

## 🏗️ Estructura del Proyecto

El código está diseñado bajo una arquitectura minimalista para facilitar su comprensión:

* **Program.cs:** Contiene la lógica principal del Backend y el manejo de la conexión.
* **AgendaBackend.csproj:** Configuración del proyecto y dependencias de NuGet.
* **agenda_api.db:** El archivo de base de datos que se genera automáticamente al ejecutar el programa.
* **Conferencia_Backend_ECYS.sln:** Solución de Visual Studio que agrupa el proyecto.

---

## 🚀 Cómo empezar

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/AndresPontaza/Conferencia_Backend_ECYS.git
   cd Conferencia_Backend_ECYS
   cd AgendaBackend
   dotnet restore
   dotnet run
   ```

## 🛠️ Guía de Instalación y Configuración Paso a Paso

Sigue estos pasos en tu terminal (CMD, PowerShell o Terminal de VS Code) para replicar el proyecto desde cero:

### 1. Crear el espacio de trabajo
Primero, creamos la carpeta donde vivirá nuestro código:
```bash
# Crear carpeta principal
mkdir ConferenciaBackend
cd ConferenciaBackend

# Crear el proyecto de consola
dotnet new web -n AgendaBackend

# Entrar a la carpeta del proyecto
cd AgendaBackend

# Agregar el paquete de ADO.NET para SQLite
dotnet add package Microsoft.Data.Sqlite

# Agregar el paquete para OpenAPI
dotnet add package Microsoft.AspNetCore.OpenApi

# Verificar que el paquete se ha instalado correctamente (si ves un "Hello World!" en la salida, es que todo está listo)
dotnet run

# Crear el archivo .gitignore para evitar subir archivos innecesarios a GitHub
dotnet new gitignore
```