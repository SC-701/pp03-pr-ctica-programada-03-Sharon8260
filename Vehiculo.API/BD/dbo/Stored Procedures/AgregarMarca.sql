CREATE PROCEDURE AgregarMarca
    @Id UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(100)
AS
BEGIN
    INSERT INTO Marcas (Id, Nombre)
    VALUES (@Id, @Nombre)

    SELECT @Id
END