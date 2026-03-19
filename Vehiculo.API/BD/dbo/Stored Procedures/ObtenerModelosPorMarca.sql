CREATE PROCEDURE ObtenerModelosPorMarca
    @IdMarca UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        m.Id,
        m.Nombre,
        m.IdMarca,
        ma.Nombre AS Marca
    FROM Modelos m
    INNER JOIN Marcas ma ON m.IdMarca = ma.Id
    WHERE m.IdMarca = @IdMarca
END