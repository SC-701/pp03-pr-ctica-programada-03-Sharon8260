CREATE PROCEDURE EditarVehiculos
	-- Add the parameters for the stored procedure here
	 @Id AS UNIQUEIDENTIFIER
     ,@IdModelo AS UNIQUEIDENTIFIER
     ,@Placa AS VARCHAR(MAX)
     ,@Color AS VARCHAR(MAX)
     ,@Anio AS INT
     ,@Precio AS DECIMAL(18,0)
     ,@CorreoPropietario AS VARCHAR(MAX)
     ,@TelefonoPropietario AS VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN TRANSACTION
	UPDATE [dbo].[Vehiculo]
       SET [IdModelo] = @IdModelo
          ,[Placa] = @Placa
          ,[Color] = @Color
          ,[Anio] = @Anio
          ,[Precio] = @Precio
          ,[CorreoPropietario] = @CorreoPropietario
          ,[TelefonoPropietario] = @TelefonoPropietario
    WHERE Id=@Id
    SELECT @Id
    COMMIT TRANSACTION
END