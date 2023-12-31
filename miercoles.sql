USE [master]
GO
/****** Object:  Database [macomb]    Script Date: 10/18/2023 11:55:32 AM ******/
CREATE DATABASE [macomb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'macomb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\macomb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'macomb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\macomb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [macomb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [macomb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [macomb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [macomb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [macomb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [macomb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [macomb] SET ARITHABORT OFF 
GO
ALTER DATABASE [macomb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [macomb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [macomb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [macomb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [macomb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [macomb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [macomb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [macomb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [macomb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [macomb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [macomb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [macomb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [macomb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [macomb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [macomb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [macomb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [macomb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [macomb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [macomb] SET  MULTI_USER 
GO
ALTER DATABASE [macomb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [macomb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [macomb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [macomb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [macomb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [macomb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [macomb] SET QUERY_STORE = OFF
GO
USE [macomb]
GO
/****** Object:  Table [dbo].[AbastecimientoVehiculos]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbastecimientoVehiculos](
	[AbastecimientoID] [int] IDENTITY(1,1) NOT NULL,
	[VehiculoID] [nvarchar](20) NULL,
	[CantidadCombustible] [decimal](10, 2) NULL,
	[FechaAbastecimiento] [datetime] NULL,
	[CostoCombustible] [decimal](10, 2) NULL,
	[Kilometraje] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AbastecimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[asignacioncombustible]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacioncombustible](
	[Fecha] [datetime] NULL,
	[LimiteMensual] [decimal](10, 2) NOT NULL,
	[VehiculoMatricula] [nvarchar](20) NOT NULL,
	[direccionID] [int] NULL,
	[AsignacionID] [int] IDENTITY(1,1) NOT NULL,
	[FichaID] [nvarchar](70) NULL,
	[UltimaAsignacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AsignacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIRECCIONES]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIRECCIONES](
	[direccionID] [int] NOT NULL,
	[direccion] [nvarchar](70) NULL,
	[director] [nvarchar](70) NULL,
PRIMARY KEY CLUSTERED 
(
	[direccionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[Matricula] [nvarchar](20) NOT NULL,
	[Chasis] [nvarchar](50) NULL,
	[Marca] [nvarchar](50) NULL,
	[Tipo] [nvarchar](50) NULL,
	[ChoferAsignadoID] [int] NULL,
	[Modelo] [nvarchar](50) NULL,
	[Ano] [int] NULL,
	[Color] [nvarchar](50) NULL,
	[ConsumoCombustible] [decimal](5, 2) NULL,
	[CapacidadTanque] [int] NULL,
	[ficha] [nvarchar](70) NULL,
PRIMARY KEY CLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaAsignacionCombustible]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaAsignacionCombustible] AS
SELECT A.AsignacionID, V.Matricula AS VehiculoMatricula, D.direccion, A.LimiteMensual, V.ficha, AV.FechaAbastecimiento
FROM asignacioncombustible A
INNER JOIN DIRECCIONES D ON A.DireccionID = D.direccionID
INNER JOIN Vehiculos V ON A.VehiculoMatricula = V.Matricula
INNER JOIN AbastecimientoVehiculos AV ON A.AsignacionID = AV.AbastecimientoID;
GO
/****** Object:  Table [dbo].[ClavesGeneradas]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClavesGeneradas](
	[ClaveID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
	[ClaveGenerada] [nvarchar](50) NULL,
	[FechaGeneracion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClaveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[EmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](35) NOT NULL,
	[Apellido] [nvarchar](35) NOT NULL,
	[Correo] [nvarchar](70) NOT NULL,
	[Telefono] [nvarchar](15) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Foto] [varbinary](max) NULL,
	[CodigoCambioContrasena] [nvarchar](50) NULL,
	[Contrasena] [nvarchar](50) NOT NULL,
	[Fechacreacion] [datetime] NULL,
	[UltimoAcceso] [datetime] NULL,
	[Estado] [bit] NULL,
	[Usuario] [nchar](50) NULL,
	[Tipo_Usuario] [nvarchar](255) NULL,
	[EmpladoID] [nvarchar](55) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsuarioClavesGeneradas]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE VIEW [dbo].[UsuarioClavesGeneradas] AS
SELECT
    u.EmpleadoID,
    u.Nombre,
    u.Apellido,
    u.Correo,
    u.Telefono,
    u.Direccion,
    u.CodigoCambioContrasena,
    cg.ClaveID AS ClaveGeneradaID, -- Cambiamos el nombre de la columna para reflejar la relación con ClavesGeneradas
    cg.ClaveGenerada AS ClaveGenerada, -- Esta columna muestra la clave de cambio de contraseña generada
    cg.FechaGeneracion
FROM
    Usuarios u
LEFT JOIN
    ClavesGeneradas cg ON u.EmpleadoID = cg.UsuarioID;
GO
/****** Object:  Table [dbo].[AbastecimientoCombustible]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbastecimientoCombustible](
	[AbastecimientoID] [int] IDENTITY(1,1) NOT NULL,
	[Fechaderecepcion] [datetime] NULL,
	[Proveedor] [nvarchar](100) NULL,
	[TipoCombustible] [nvarchar](50) NULL,
	[CantidadRecibida] [decimal](10, 2) NULL,
	[CostoTotal] [decimal](10, 2) NULL,
	[NumeroFactura] [nvarchar](50) NULL,
	[UsuarioResponsable] [nvarchar](100) NULL,
	[Notas] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AbastecimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conductores]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conductores](
	[ConductorID] [int] IDENTITY(1,1) NOT NULL,
	[NumeroLicencia] [nvarchar](50) NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[Correo] [nvarchar](100) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Direccion] [nvarchar](200) NULL,
	[CategoriaLicencia] [nvarchar](20) NULL,
	[VehiculoAsignadoID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConductorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[asignacioncombustible]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Asignacion] FOREIGN KEY([direccionID])
REFERENCES [dbo].[DIRECCIONES] ([direccionID])
GO
ALTER TABLE [dbo].[asignacioncombustible] CHECK CONSTRAINT [FK_Direccion_Asignacion]
GO
ALTER TABLE [dbo].[asignacioncombustible]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Asignacion] FOREIGN KEY([VehiculoMatricula])
REFERENCES [dbo].[Vehiculos] ([Matricula])
GO
ALTER TABLE [dbo].[asignacioncombustible] CHECK CONSTRAINT [FK_Vehiculo_Asignacion]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Conductores] FOREIGN KEY([ChoferAsignadoID])
REFERENCES [dbo].[Conductores] ([ConductorID])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Conductores]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUltimoAcceso]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarUltimoAcceso]
    @usuarioId INT
AS
BEGIN
    UPDATE usuarios
    SET UltimoAcceso = GETDATE()
    WHERE EmpleadoID = @usuarioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[CalcularConsumoSemanal]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[CalcularConsumoSemanal]
    @vehiculoID NVARCHAR(50),
    @domingoEstaSemana DATETIME
AS
BEGIN
    SELECT SUM(CantidadCombustible) AS ConsumoSemanal
    FROM AbastecimientoVehiculos
    WHERE vehiculoID = @vehiculoID
    AND FechaAbastecimiento >= @domingoEstaSemana
END
GO
/****** Object:  StoredProcedure [dbo].[CambiarContrasenaUsuario]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create procedure [dbo].[CambiarContrasenaUsuario]
		@UsuarioID Int,
		@nuevacontrasena nvarchar(50)
	as
	Begin 
		UPDATE Usuarios
		SET Contrasena = @nuevacontrasena
		WHERE EmpleadoID = @UsuarioID;
	END;
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuarios]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------EDITAR
CREATE proc [dbo].[EditarUsuarios]
@idUser int,
@usuario nvarchar (50),
@nombre nvarchar (50),
@apellido nvarchar (50),
@correo nvarchar (60),
@direccion nvarchar (60),
@telefono nvarchar(35),
@contrasena nvarchar (60),
@foto image
as
update Usuarios set Usuario=@usuario,Nombre=@nombre,Apellido=@apellido,Correo=@correo,Direccion=@direccion,Telefono=@telefono,Contrasena=@contrasena,Foto=@foto where EmpleadoID=@idUser
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------ELIMINAR
create proc [dbo].[EliminarUsuario]
@idUser int
as
delete from Usuarios where EmpleadoID=@idUser
GO
/****** Object:  StoredProcedure [dbo].[HistoricoCombustible]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HistoricoCombustible]
AS
BEGIN
    -- Seleccionar los datos necesarios
    SELECt *
    FROM
        AbastecimientoVehiculos
    ORDER BY
        FechaAbastecimiento;
END;
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[IniciarSesion]
    @usuario NVARCHAR(50),
    @contrasena NVARCHAR(50),
    @usuarioId INT OUTPUT,
    @nombre NVARCHAR(50) OUTPUT,
    @apellido NVARCHAR(50) OUTPUT,
    @correo NVARCHAR(100) OUTPUT,
    @imagen VARBINARY(MAX) OUTPUT,
    @tipoUsuario NVARCHAR(50) OUTPUT,
    @direccion NVARCHAR(100) OUTPUT,
    @telefono NVARCHAR(20) OUTPUT
AS
BEGIN
    -- Inicializa las variables de salida
    SET @usuarioId = NULL;
    SET @nombre = NULL;
    SET @apellido = NULL;
    SET @correo = NULL;
    SET @imagen = NULL;
    SET @tipoUsuario = NULL;
    SET @direccion = NULL;
    SET @telefono = NULL;

    -- Intenta autenticar al usuario
    IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena)
    BEGIN
        -- Obtén los datos del usuario
        SELECT @usuarioId = EmpleadoID, @nombre = Nombre, @apellido = Apellido,
            @correo = Correo, @imagen = Foto, @tipoUsuario = Tipo_Usuario,
            @direccion = Direccion, @telefono = Telefono
        FROM Usuarios
        WHERE Usuario = @usuario;

        -- Si algún campo es NULL, asigna valores predeterminados
        IF @nombre IS NULL SET @nombre = '';
        IF @apellido IS NULL SET @apellido = '';
        IF @correo IS NULL SET @correo = '';
        IF @tipoUsuario IS NULL SET @tipoUsuario = '';
        IF @direccion IS NULL SET @direccion = '';
        IF @telefono IS NULL SET @telefono = '';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarAbastecimiento]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarAbastecimiento]
    @vehiculoID NVARCHAR(50),
    @cantidadCombustible DECIMAL,
    @fechaAbastecimiento DATETIME,
    @costoCombustible DECIMAL,
    @kilometraje DECIMAL
AS
BEGIN
    INSERT INTO AbastecimientoVehiculos (VehiculoID, CantidadCombustible, FechaAbastecimiento, CostoCombustible, Kilometraje)
    VALUES (@vehiculoID, @cantidadCombustible, @fechaAbastecimiento, @costoCombustible, @kilometraje)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuarios]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarUsuarios]
@usuario nvarchar(35),
@nombre nvarchar(35),
@apellido nvarchar(35),
@correo nvarchar(70),
@direccion nvarchar(60),
@telefono nvarchar(35),
@contrasena nvarchar(60),
@foto image
AS
BEGIN
    INSERT INTO Usuarios (Usuario, Nombre, Apellido, Correo, Direccion, Telefono, Contrasena,Fechacreacion,Foto)
    VALUES (@usuario, @nombre, @apellido, @correo, @direccion, @telefono, @contrasena,GETDATE(),@foto)
END
GO
/****** Object:  StoredProcedure [dbo].[MostrarUsuarios]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---PROCEDIMIENTOS ALMACENADOS 
--------------------------MOSTRAR 
create proc [dbo].[MostrarUsuarios]
as
select *from Usuarios
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAbastecimientosSemana]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerAbastecimientosSemana]
    @vehiculoID NVARCHAR(50),
    @domingoEstaSemana DATE
AS
BEGIN
    SELECT SUM(CantidadCombustible) AS ConsumoSemanal
    FROM AbastecimientoVehiculos
    WHERE vehiculoID = @vehiculoID
    AND FechaAbastecimiento >= @domingoEstaSemana
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAsignacionSemanal]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerAsignacionSemanal]
    @VehiculoMatricula NVARCHAR(50)
AS
BEGIN
    SELECT LimiteMensual, MAX(Fecha) AS UltimaAsignacion
    FROM AsignacionCombustible
    WHERE VehiculoMatricula = @VehiculoMatricula
    GROUP BY LimiteMensual, VehiculoMatricula
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioIdPorClaveAutorizacion]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[ObtenerUsuarioIdPorClaveAutorizacion]
    @ClaveAutorizacion NVARCHAR(MAX)
AS
BEGIN
    SELECT UsuarioID
    FROM ClavesGeneradas
    WHERE ClaveGenerada = @ClaveAutorizacion;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioIdPorNombre]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUsuarioIdPorNombre]
    @Usuario NVARCHAR(MAX)
AS
BEGIN
    SELECT EmpleadoID
    FROM Usuarios
    WHERE Usuario = @Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[Pr_CambiarImagenPerfil]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[Pr_CambiarImagenPerfil]
@usuarioid int,
@imagen varbinary(max)
as
begin
	update Usuarios
	set Foto = @imagen
	where EmpleadoID = @usuarioid
end
GO
/****** Object:  StoredProcedure [dbo].[TB_AbstcimientoComb]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Peter>
-- Create date: <Create Date,GETDATE(),>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TB_AbstcimientoComb]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from AbastecimientoCombustible order by Fechaderecepcion desc
END
GO
/****** Object:  StoredProcedure [dbo].[TB_AbstcimientoVehi]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Peter>
-- Create date: <Create Date,GETDATE(),>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TB_AbstcimientoVehi]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT * from AbastecimientoVehiculos order by FechaAbastecimiento desc
END
GO
/****** Object:  StoredProcedure [dbo].[TB_Conductores]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Peter>
-- Create date: <Create Date,GETDATE(),>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TB_Conductores]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Conductores order by ConductorID 
END
GO
/****** Object:  StoredProcedure [dbo].[TB_Vehiculos]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Peter>
-- Create date: <Create Date,GETDATE(),>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TB_Vehiculos]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Conductores order by ConductorID 
END
GO
/****** Object:  StoredProcedure [dbo].[VerificarLimiteMensual]    Script Date: 10/18/2023 11:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- En tu procedimiento VerificarLimiteMensual
CREATE PROCEDURE [dbo].[VerificarLimiteMensual]
    @vehiculoID NVARCHAR(50),
    @fecha DATETIME
AS
BEGIN
    -- Registro de valores de entrada
    PRINT 'VerificarLimiteMensual - VehiculoID: ' + @vehiculoID
    PRINT 'VerificarLimiteMensual - Fecha: ' + CONVERT(NVARCHAR, @fecha, 120)

    SELECT SUM(CantidadCombustible)
    FROM AbastecimientoVehiculos
    WHERE VehiculoID = @vehiculoID
        AND YEAR(FechaAbastecimiento) = YEAR(@fecha)
        AND MONTH(FechaAbastecimiento) = MONTH(@fecha)
END
GO
USE [master]
GO
ALTER DATABASE [macomb] SET  READ_WRITE 
GO
