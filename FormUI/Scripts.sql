-- =============================================
-- Author:		<Enmanuelle Acuña>
-- Create date: <15/09/2019>
-- Description:	<Obtener personas por apellido>
-- =============================================
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Personas_ObtenerPorApellido
	-- Add the parameters for the stored procedure here
	@Apellido NVARCHAR (50)
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM dbo.Personas
	WHERE Apellido = @Apellido
END
GO

-- =============================================
-- Author:		<Enmanuelle Acuña>
-- Create date: <15/09/2019>
-- Description:	<Insertar persona en la tabla dbo.Personas>
-- =============================================
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Personas_Insertar
	-- Add the parameters for the stored procedure here
	@Nombre NVARCHAR (50),
	@Apellido NVARCHAR (50),
	@CorreoElectronico NVARCHAR (100),
	@Telefono NVARCHAR (20)
AS
BEGIN
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Personas
	VALUES (@Nombre, @Apellido, @CorreoElectronico, @Telefono)
END
GO

SELECT * FROM dbo.Personas