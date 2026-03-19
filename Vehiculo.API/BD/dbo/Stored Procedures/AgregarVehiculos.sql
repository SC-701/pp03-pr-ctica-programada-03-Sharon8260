CREATE PROCEDURE AgregarVehiculos
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
	    INSERT INTO [dbo].[Vehiculo]
               ([Id]
               ,[IdModelo]
               ,[Placa]
               ,[Color]
               ,[Anio]
               ,[Precio]
               ,[CorreoPropietario]
               ,[TelefonoPropietario])
         VALUES
               ( @Id
               ,@IdModelo
               ,@Placa
               ,@Color
               ,@Anio
               ,@Precio
               ,@CorreoPropietario
               ,@TelefonoPropietario)
        SELECT @Id
    COMMIT TRANSACTION 
END