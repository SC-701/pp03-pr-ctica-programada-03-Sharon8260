CREATE PROCEDURE EditarModelo
    @Id UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(100),
    @IdMarca UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE Modelos
    SET Nombre = @Nombre,
        IdMarca = @IdMarca
    WHERE Id = @Id

    SELECT @Id
END