-- Crear base de datos
CREATE DATABASE IF NOT EXISTS VentasDB;
USE VentasDB;

-- Crear tabla Categoria
CREATE TABLE Categoria (
    CodigoCategoria INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

-- Crear tabla Producto
CREATE TABLE Producto (
    CodigoProducto INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CodigoCategoria INT NOT NULL,
    FOREIGN KEY (CodigoCategoria) REFERENCES Categoria(CodigoCategoria)
);

-- Crear tabla Venta
CREATE TABLE Venta (
    CodigoVenta INT PRIMARY KEY,
    Fecha DATE NOT NULL,
    CodigoProducto INT NOT NULL,
    FOREIGN KEY (CodigoProducto) REFERENCES Producto(CodigoProducto)
);

-- Insertar datos de prueba
INSERT INTO Categoria VALUES 
(1, 'Limpieza'), (2, 'Electrónica'), (3, 'Alimentos'),
(4, 'Bebidas'), (5, 'Papelería'), (6, 'Ropa');

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

-- CONSULTA DEL INCISO A
-- Obtener el nombre de la categoría del producto de la última venta
SELECT c.Nombre
FROM Venta v
JOIN Producto p ON v.CodigoProducto = p.CodigoProducto
JOIN Categoria c ON p.CodigoCategoria = c.CodigoCategoria
ORDER BY v.Fecha DESC
LIMIT 1;