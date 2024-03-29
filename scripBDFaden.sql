USE [master]
GO
/****** Object:  Database [FADEN]    Script Date: 25/01/2023 19:20:48 ******/
CREATE DATABASE [FADEN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FADEN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FADEN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FADEN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FADEN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FADEN] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FADEN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FADEN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FADEN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FADEN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FADEN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FADEN] SET ARITHABORT OFF 
GO
ALTER DATABASE [FADEN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FADEN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FADEN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FADEN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FADEN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FADEN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FADEN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FADEN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FADEN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FADEN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FADEN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FADEN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FADEN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FADEN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FADEN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FADEN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FADEN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FADEN] SET RECOVERY FULL 
GO
ALTER DATABASE [FADEN] SET  MULTI_USER 
GO
ALTER DATABASE [FADEN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FADEN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FADEN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FADEN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FADEN] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FADEN] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FADEN', N'ON'
GO
ALTER DATABASE [FADEN] SET QUERY_STORE = OFF
GO
USE [FADEN]
GO
/****** Object:  Schema [CAT]    Script Date: 25/01/2023 19:20:48 ******/
CREATE SCHEMA [CAT]
GO
/****** Object:  Table [dbo].[Acompanante]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acompanante](
	[IdAcpte] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[EsAcpte] [bit] NOT NULL,
	[EsCuidador] [bit] NOT NULL,
	[EsPrimario] [bit] NOT NULL,
	[EsSecundario] [bit] NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_Acompanante] PRIMARY KEY CLUSTERED 
(
	[IdAcpte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[IdCiudad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdDepto] [int] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[IdCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDepto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](4) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[IdDepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escolaridad]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escolaridad](
	[IdEscolaridad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Escolaridad] PRIMARY KEY CLUSTERED 
(
	[IdEscolaridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IdMedico] [int] IDENTITY(1,1) NOT NULL,
	[NoMedico] [nvarchar](5) NOT NULL,
	[FechaIngreso] [datetime2](7) NOT NULL,
	[PNombre] [nvarchar](50) NOT NULL,
	[SNombre] [nvarchar](50) NOT NULL,
	[PApellido] [nvarchar](50) NOT NULL,
	[SApellido] [nvarchar](50) NOT NULL,
	[NombreCompleto]  AS (concat([PNombre],' ',[SNombre],' ',[PApellido],' ',[SApellido])),
	[IdDepto] [int] NOT NULL,
	[IdCiudad] [int] NOT NULL,
	[FechaNac] [date] NOT NULL,
	[Identificacion] [nvarchar](50) NOT NULL,
	[Especialidad] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](8) NOT NULL,
	[Celular] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[IdPaciente] [int] IDENTITY(1,1) NOT NULL,
	[NoExpediente] [nvarchar](50) NOT NULL,
	[FechaIngreso] [datetime2](7) NOT NULL,
	[PNombre] [nvarchar](50) NOT NULL,
	[SNombre] [nvarchar](50) NOT NULL,
	[PApellido] [nvarchar](50) NOT NULL,
	[SApellido] [nvarchar](50) NOT NULL,
	[Sexo] [nvarchar](1) NOT NULL,
	[IdDepto] [int] NOT NULL,
	[IdCiudad] [int] NOT NULL,
	[FechaNacim] [date] NOT NULL,
	[Ocupacion] [nvarchar](100) NOT NULL,
	[Identificacion] [nvarchar](50) NOT NULL,
	[IdEscolaridad] [int] NOT NULL,
	[ECivil] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Celular] [nvarchar](20) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Religion] [nvarchar](50) NOT NULL,
	[Convive] [nvarchar](10) NOT NULL,
	[Visita] [nvarchar](10) NOT NULL,
	[RefVisita] [nvarchar](50) NOT NULL,
	[Referencia] [nvarchar](50) NOT NULL,
	[Trabaja] [bit] NOT NULL,
	[RefTrabajo] [nvarchar](100) NOT NULL,
	[UltimoTrabajo] [bit] NOT NULL,
	[RefUltTrabajo] [nvarchar](100) NOT NULL,
	[Jubilado] [bit] NOT NULL,
	[Pensionado] [bit] NOT NULL,
	[Estado] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilUsuario](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Acceso] [nvarchar](30) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/01/2023 19:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Usuario] [nvarchar](30) NOT NULL,
	[Contrasena] [nvarchar](30) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Acompanante] ON 

INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (3, N'fsdf', N'fadfar', N'aafas', N'jtyiurt', 1, 0, 0, 1, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (4, N'rtqrtq', N'píop', N'fgagj', N'cvbnvbx', 0, 0, 1, 0, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (5, N'ytyt', N'1532', N'jkjk', N'gsdfg', 0, 0, 1, 0, 14)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1002, N'Daniela Morales', N'85979774', N'col tenderi', N'danimoflo', 0, 0, 1, 0, 1009)
SET IDENTITY_INSERT [dbo].[Acompanante] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudad] ON 

INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (1, N'ciudad1', 1)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (2, N'cuidad2', 1)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (3, N'Veracruz', 21)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (4, N'Prueba', 23)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (5, N'Condega', 28)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (6, N'El Tuma', 23)
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (1, N'CO-1', N'MANAGUA')
INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (2, N'CO-2', N'MATAGALPA')
INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (3, N'CO-3', N'BOACO')
INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (20, N'CO-4', N'JINOTEGA')
INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (21, N'CO-5', N'Chinandega')
INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (23, N'CO-6', N'JINOTEGA')
INSERT [dbo].[Departamento] ([IdDepto], [Codigo], [Nombre]) VALUES (28, N'CO-7', N'ESTELI')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Escolaridad] ON 

INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (1, N'prueba', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (2, N'Primaria Completa', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (3, N'Primaria Incompleta', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (4, N'Secundaria Completa', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (5, N'Secundaria Incompleta', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (6, N'Técnico Medio', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (7, N'Técnico Superior', 1)
INSERT [dbo].[Escolaridad] ([IdEscolaridad], [Nombre], [Activo]) VALUES (8, N'Universidad ', 1)
SET IDENTITY_INSERT [dbo].[Escolaridad] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 

INSERT [dbo].[Medicos] ([IdMedico], [NoMedico], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [IdDepto], [IdCiudad], [FechaNac], [Identificacion], [Especialidad], [Direccion], [Correo], [Telefono], [Celular]) VALUES (14, N'00003', CAST(N'2022-10-08T15:45:17.7391633' AS DateTime2), N'Mariela', N'De los Angeles', N'opioiop', N'Maltez', 1, 2, CAST(N'2023-03-10' AS Date), N'001-101010', N'Psicologa', N'Lomas de Monserrat', N'mmurillo@hotmail.com', N'4545456', N'82521624')
INSERT [dbo].[Medicos] ([IdMedico], [NoMedico], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [IdDepto], [IdCiudad], [FechaNac], [Identificacion], [Especialidad], [Direccion], [Correo], [Telefono], [Celular]) VALUES (15, N'00004', CAST(N'2022-11-16T21:04:09.6462322' AS DateTime2), N'José', N'Armando', N'González', N'Mora', 1, 2, CAST(N'1990-06-20' AS Date), N'444-200690-0000M', N'Internista', N'su casa', N'jagm90@gmail.com', N'78787878', N'98765432')
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (5, N'0000000001', CAST(N'2022-11-02T06:00:00.0000000' AS DateTime2), N'carol', N'maria', N'flores', N'paz', N'F', 28, 5, CAST(N'1974-04-11' AS Date), N'Docente', N'001-110474-0069Q', 1, N'casada', N'la misma', N'22401567', N'78970513', N'carolflorespe', N'evangelica', N'010000', N'1000', N'10000', N'', 1, N'docente', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (7, N'0000000002', CAST(N'2022-12-07T06:00:00.0000000' AS DateTime2), N'Humberto', N'Martín', N'Morales', N'Flores', N'M', 1, 1, CAST(N'1994-02-18' AS Date), N'Trabajador', N'001-180294-0000S', 1, N'Soltero', N'Managua', N'88641062', N'22401567', N'betomm', N'ninguna', N'000010', N'0001', N'00001', N'', 1, N'Juega', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (13, N'0000000003', CAST(N'2016-06-07T06:00:00.0000000' AS DateTime2), N'reqrqew', N'fafd', N'vzcv', N'lñhl', N'M', 23, 4, CAST(N'2018-02-06' AS Date), N'nihguan', N'002 5454987', 1, N'soltero', N'lkjoiewl  jlkadjfoasjdp', N'789456', N'123456', N'kqjreoiaa ', N'noa', N'010000', N'1000', N'01000', N'', 0, N'', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (14, N'0000000004', CAST(N'2022-12-17T11:02:04.4430000' AS DateTime2), N'dfadsf', N'dfas', N'fasdfa', N'adfasdf', N'M', 21, 3, CAST(N'2016-02-03' AS Date), N'fadsf', N'78798', 1, N'adfadf', N'fadfad', N'563456', N'252454', N'jkjkj', N'rgs', N'100000', N'1000', N'10000', N'', 0, N'', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (1009, N'0000000005', CAST(N'2023-01-21T12:40:00.6500000' AS DateTime2), N'José', N'Alejandro', N'Vargas', N'López', N'M', 21, 3, CAST(N'2010-01-03' AS Date), N'Enfermero', N'003-030110-0000S', 1, N'Soltero', N'Bo Campo Bruce', N'22516565', N'1234568', N'adfadfda', N'ninguna', N'100000', N'0010', N'00001', N'', 0, N'', 0, N'', 0, 0, N'')
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
ALTER TABLE [dbo].[Acompanante]  WITH CHECK ADD  CONSTRAINT [FK_Acompanante_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Acompanante] CHECK CONSTRAINT [FK_Acompanante_Paciente]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Departamento] FOREIGN KEY([IdDepto])
REFERENCES [dbo].[Departamento] ([IdDepto])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Departamento]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([IdCiudad])
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_Medicos]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Escolaridad] FOREIGN KEY([IdEscolaridad])
REFERENCES [dbo].[Escolaridad] ([IdEscolaridad])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Escolaridad]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Usuario]
GO
USE [master]
GO
ALTER DATABASE [FADEN] SET  READ_WRITE 
GO
