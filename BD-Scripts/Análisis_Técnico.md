### Análisis Técnico y Decisiones Tomadas

#### 🔹 Modelo de Datos

El diseño de la base de datos se realizó a partir del diagrama proporcionado en la prueba técnica, respetando nombres exactos de tablas y campos:

* **Categoria(CodigoCategoria, Nombre)**
* **Producto(CodigoProducto, Nombre, CodigoCategoria)**
* **Venta(CodigoVenta, Fecha, CodigoProducto)**

Las relaciones establecen:

* Cada producto pertenece a una **única categoría** (`FOREIGN KEY`).
* Cada venta corresponde a **un solo producto**.

Este esquema permite consultar fácilmente tanto productos como sus ventas y categorías.

---

#### 🔹 Datos de prueba

Se agregaron múltiples categorías, productos y ventas, enfocándose especialmente en registros del año 2019, ya que son requeridos para el filtro en la aplicación web.

También se agregaron ventas en otros años para verificar que el filtro por año funcione correctamente.

---

#### 🔹 Consulta SQL (Inciso A)

La consulta solicitada consiste en obtener el nombre de la categoría del producto vendido en la venta más reciente.

```sql
SELECT c.Nombre
FROM Venta v
JOIN Producto p ON v.CodigoProducto = p.CodigoProducto
JOIN Categoria c ON p.CodigoCategoria = c.CodigoCategoria
ORDER BY v.Fecha DESC
LIMIT 1;
```

Esta consulta aprovecha la estructura relacional entre las tablas y ordena las ventas por fecha para obtener la más reciente.

---

#### 🔹 Justificación técnica

* Se usó MySQL por ser el sistema mencionado en la prueba.
* Se aplicaron llaves foráneas para asegurar integridad referencial.
* Se evitaron campos innecesarios y se mantuvo la estructura fiel al diagrama.
* Se organizó el archivo SQL para que sirva tanto para pruebas como para producción.