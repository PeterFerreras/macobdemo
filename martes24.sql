USE [macomb]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarConductor]    Script Date: 10/24/2023 11:04:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarConductor]
    @ConductorID INT,
    @NumeroLicencia VARCHAR(20),
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Correo VARCHAR(100),
    @Telefono VARCHAR(20),
    @Direccion VARCHAR(200),
    @CategoriaLicencia VARCHAR(20),
    @VehiculoAsignadoID NVARCHAR(20)
AS
BEGIN
    UPDATE dbo.Conductores
    SET
        NumeroLicencia = @NumeroLicencia,
        Nombre = @Nombre,
        Apellido = @Apellido,
        Correo = @Correo,
        Telefono = @Telefono,
        Direccion = @Direccion,
        CategoriaLicencia = @CategoriaLicencia,
        VehiculoAsignadoID = ISNULL(@VehiculoAsignadoID, NULL) -- Valor nulo si es nulo
    WHERE ConductorID = @ConductorID;
END
GO
