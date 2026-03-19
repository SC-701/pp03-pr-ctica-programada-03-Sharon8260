CREATE PROCEDURE EditarMarca
    @Id UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(100)
AS
BEGIN
    UPDATE Marcas
    SET Nombre = @Nombre
    WHERE Id = @Id

    SELECT @Id
END