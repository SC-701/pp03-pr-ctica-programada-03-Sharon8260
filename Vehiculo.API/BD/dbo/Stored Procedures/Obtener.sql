CREATE PROCEDURE Obtener
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        V.Id,
        V.IdModelo,
        V.Placa,
        V.Color,
        V.Anio,
        V.Precio,
        V.CorreoPropietario,
        V.TelefonoPropietario,
        M.Nombre AS Modelo,
        MA.Nombre AS Marca
    FROM Vehiculo V
    INNER JOIN Modelos M ON V.IdModelo = M.Id
    INNER JOIN Marcas MA ON M.IdMarca = MA.Id
    WHERE V.Id = @Id
END