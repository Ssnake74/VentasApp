# Manual Técnico – Evaluación .NET/C# Jr.

## Descripción del Proyecto

Este proyecto es una aplicación web ASP.NET (Razor Pages) que permite consultar productos vendidos en el año **2019**, filtrando por categorías que también tuvieron ventas en ese año.

La base de datos está en **MySQL**, y la aplicación fue desarrollada en **Visual Studio Code** usando C# y el SDK de .NET.

---

## Requisitos del sistema

* **Windows 10 o superior**
* **.NET SDK 7.0 o superior**
  [Descargar aquí](https://dotnet.microsoft.com/en-us/download)
* **MySQL Server / Workbench**
* **Visual Studio Code**
* Extensiones recomendadas para VS Code:

  * C# (by Microsoft)
  * .NET Install Tool

---

## Estructura del Proyecto

* `Models/`: Clases para entidades `Categoria` y `Producto`.
* `Data/Database.cs`: Clase encargada de la conexión y ejecución de consultas SQL.
* `Pages/Index.cshtml`: Vista principal (interfaz).
* `Pages/Index.cshtml.cs`: Lógica del filtro y resultado.
* `appsettings.json`: No se utiliza (la cadena de conexión está en `Database.cs`).

---

## 🔗 Conexión a la Base de Datos

Edita la clase `Data/Database.cs` para colocar la contraseña correcta de tu usuario `root` de MySQL:

```csharp
private readonly string connectionString = "server=localhost;user=root;password=AQUÍ_TU_PASSWORD;database=VentasDB";
```

---

## Instrucciones de instalación y ejecución

### 1. Clonar el repositorio o descomprimir `.zip`

Si usas GitHub:

```bash
git clone https://github.com/tu-usuario/ventas-app.git
cd ventas-app
```

O si es archivo `.zip`, simplemente extrae y abre la carpeta en Visual Studio Code.

---

### 2. Crear la base de datos en MySQL

Ejecuta el siguiente script en MySQL Workbench para crear la base de datos y poblarla:

<details>
<summary>Haz clic aquí para ver el script SQL</summary>

```sql
CREATE DATABASE IF NOT EXISTS VentasDB;
USE VentasDB;

CREATE TABLE Categoria (
    CodigoCategoria INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Producto (
    CodigoProducto INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CodigoCategoria INT NOT NULL,
    FOREIGN KEY (CodigoCategoria) REFERENCES Categoria(CodigoCategoria)
);

CREATE TABLE Venta (
    CodigoVenta INT PRIMARY KEY,
    Fecha DATE NOT NULL,
    CodigoProducto INT NOT NULL,
    FOREIGN KEY (CodigoProducto) REFERENCES Producto(CodigoProducto)
);

-- Datos de prueba
INSERT INTO Categoria VALUES (1, 'Limpieza'), (2, 'Electrónica'), (3, 'Alimentos'), (4, 'Bebidas'), (5, 'Papelería'), (6, 'Ropa');
INSERT INTO Producto VALUES
(1, 'Detergente', 1), (2, 'Televisor', 2), (3, 'Arroz', 3),
(4, 'Jugo Natural', 4), (5, 'Refresco Cola', 4),
(6, 'Cuaderno', 5), (7, 'Bolígrafo', 5),
(8, 'Camisa', 6), (9, 'Pantalón', 6);

INSERT INTO Venta VALUES
(1, '2019-06-01', 1), (2, '2020-07-10', 2), (3, '2023-03-20', 3),
(4, '2019-01-15', 4), (5, '2019-07-10', 5),
(6, '2019-03-21', 6), (7, '2019-11-11', 7),
(8, '2019-06-06', 8), (9, '2020-02-14', 9);
```

</details>

---

### 3. Ejecutar la aplicación

En la terminal de Visual Studio Code:

```bash
dotnet restore
dotnet run
```

Luego abre tu navegador en:

```
http://localhost:5250
```

---

## Pruebas esperadas

1. Por defecto, la página carga con el select de categorías.
2. Solo se muestran **categorías con ventas en 2019**.
3. Al seleccionar una categoría, se listan los **productos vendidos en ese año**.
4. Si no hay productos, aparece un mensaje indicando que no hubo ventas.

---
