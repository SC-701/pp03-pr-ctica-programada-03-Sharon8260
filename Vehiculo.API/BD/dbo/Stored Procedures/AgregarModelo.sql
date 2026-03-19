CREATE PROCEDURE AgregarModelo
    @Id UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(100),
    @IdMarca UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO Modelos (Id, Nombre, IdMarca)
    VALUES (@Id, @Nombre, @IdMarca)

    SELECT @Id
END