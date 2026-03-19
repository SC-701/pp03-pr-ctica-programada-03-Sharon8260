-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerVehiculos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Vehiculo.Id,
        Vehiculo.IdModelo,
        Vehiculo.Placa,
        Vehiculo.Color,
        Vehiculo.Anio,
        Vehiculo.Precio,
        Vehiculo.CorreoPropietario,
        Vehiculo.TelefonoPropietario,
        Modelos.Nombre AS Modelo,
        Marcas.Nombre AS Marca
    FROM Vehiculo 
    INNER JOIN Modelos ON Vehiculo.IdModelo = Modelos.Id 
    INNER JOIN Marcas ON Modelos.IdMarca = Marcas.Id;
END