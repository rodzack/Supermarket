CREATE DATABASE Supermercado
GO
USE Supermercado
GO
CREATE TABLE TblProductos(
Prod_IdProducto INT IDENTITY,
Prod_NombreProducto NVARCHAR(30) NOT NULL,
Prod_Precio DECIMAL NOT NULL,
Prod_Existencias INT NOT NULL,
CONSTRAINT Pk_Prod_IdProducto PRIMARY KEY (Prod_IdProducto))
GO
CREATE PROCEDURE [dbo].[SpListarProductos] 
AS
BEGIN
	SELECT Prod_IdProducto,Prod_NombreProducto,Prod_Precio,Prod_Existencias FROM TblProductos
END
GO
CREATE PROCEDURE [dbo].[SpListarProductoEditar] 
@Prod_IdProducto int
AS
BEGIN
	SELECT Prod_IdProducto,Prod_NombreProducto,Prod_Precio,Prod_Existencias FROM TblProductos
	WHERE Prod_IdProducto = @Prod_IdProducto
END
GO
CREATE PROCEDURE dbo.SpEditarProductos
@Prod_IdProducto INT,
@Prod_NombreProducto VARCHAR(30),
@Prod_Precio MONEY,
@Prod_Existencias INT
AS
BEGIN
	UPDATE tblProductos SET Prod_NombreProducto = @Prod_NombreProducto,Prod_Precio = @Prod_Precio,Prod_Existencias = @Prod_Existencias
	WHERE Prod_IdProducto = @Prod_IdProducto
END
GO
CREATE PROCEDURE dbo.SpEliminarProductos
@Prod_IdProducto INT
AS
BEGIN
	DELETE tblProductos WHERE Prod_IdProducto = @Prod_IdProducto
END
GO
CREATE PROCEDURE dbo.SpCrearProductos
@Prod_NombreProducto VARCHAR(30),
@Prod_Precio MONEY,
@Prod_Existencias INT
AS
BEGIN
	INSERT INTO tblProductos (Prod_NombreProducto,Prod_Precio,Prod_Existencias)
	VALUES (@Prod_NombreProducto,@Prod_Precio,@Prod_Existencias)

	SELECT Prod_IdProducto,Prod_NombreProducto,Prod_Precio,Prod_Existencias FROM TblProductos
END