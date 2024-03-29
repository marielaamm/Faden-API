USE [FADEN]
GO
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Rol]
GO
ALTER TABLE [dbo].[TratamientoHistorico] DROP CONSTRAINT [FK_TratamientoHistorico_Paciente]
GO
ALTER TABLE [dbo].[SistemaSoap] DROP CONSTRAINT [FK_SistemaSoap_Paciente]
GO
ALTER TABLE [dbo].[SindromePredominante] DROP CONSTRAINT [FK_SindromePredominante_Paciente]
GO
ALTER TABLE [dbo].[PerfilUsuario] DROP CONSTRAINT [FK_PerfilUsuario_Usuario]
GO
ALTER TABLE [dbo].[Paciente] DROP CONSTRAINT [FK_Paciente_Escolaridad]
GO
ALTER TABLE [dbo].[Medicos] DROP CONSTRAINT [FK_Medicos]
GO
ALTER TABLE [dbo].[ExamenClinico] DROP CONSTRAINT [FK_ExamenClinico_Paciente]
GO
ALTER TABLE [dbo].[Consenso] DROP CONSTRAINT [FK_Consenso_Paciente1]
GO
ALTER TABLE [dbo].[Ciudad] DROP CONSTRAINT [FK_Ciudad_Departamento]
GO
ALTER TABLE [dbo].[AntecendeteQuirurgico] DROP CONSTRAINT [FK_AntecendeteQuirurgico_Paciente]
GO
ALTER TABLE [dbo].[AntecedentePatologico] DROP CONSTRAINT [FK_AntecedentePatologico_Paciente]
GO
ALTER TABLE [dbo].[AntecedenteFamiliar] DROP CONSTRAINT [FK_AntecedenteFamiliar_Paciente]
GO
ALTER TABLE [dbo].[Acompanante] DROP CONSTRAINT [FK_Acompanante_Paciente]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[TratamientoHistorico]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamientoHistorico]') AND type in (N'U'))
DROP TABLE [dbo].[TratamientoHistorico]
GO
/****** Object:  Table [dbo].[SistemaSoap]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SistemaSoap]') AND type in (N'U'))
DROP TABLE [dbo].[SistemaSoap]
GO
/****** Object:  Table [dbo].[SindromePredominante]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SindromePredominante]') AND type in (N'U'))
DROP TABLE [dbo].[SindromePredominante]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol]') AND type in (N'U'))
DROP TABLE [dbo].[Rol]
GO
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PerfilUsuario]') AND type in (N'U'))
DROP TABLE [dbo].[PerfilUsuario]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paciente]') AND type in (N'U'))
DROP TABLE [dbo].[Paciente]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicos]') AND type in (N'U'))
DROP TABLE [dbo].[Medicos]
GO
/****** Object:  Table [dbo].[ExamenClinico]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamenClinico]') AND type in (N'U'))
DROP TABLE [dbo].[ExamenClinico]
GO
/****** Object:  Table [dbo].[Escolaridad]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Escolaridad]') AND type in (N'U'))
DROP TABLE [dbo].[Escolaridad]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departamento]') AND type in (N'U'))
DROP TABLE [dbo].[Departamento]
GO
/****** Object:  Table [dbo].[Consenso]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consenso]') AND type in (N'U'))
DROP TABLE [dbo].[Consenso]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ciudad]') AND type in (N'U'))
DROP TABLE [dbo].[Ciudad]
GO
/****** Object:  Table [dbo].[AntecendeteQuirurgico]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AntecendeteQuirurgico]') AND type in (N'U'))
DROP TABLE [dbo].[AntecendeteQuirurgico]
GO
/****** Object:  Table [dbo].[AntecedentePatologico]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AntecedentePatologico]') AND type in (N'U'))
DROP TABLE [dbo].[AntecedentePatologico]
GO
/****** Object:  Table [dbo].[AntecedenteFamiliar]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AntecedenteFamiliar]') AND type in (N'U'))
DROP TABLE [dbo].[AntecedenteFamiliar]
GO
/****** Object:  Table [dbo].[Acompanante]    Script Date: 7/4/2023 16:48:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Acompanante]') AND type in (N'U'))
DROP TABLE [dbo].[Acompanante]
GO
/****** Object:  Table [dbo].[Acompanante]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[AntecedenteFamiliar]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AntecedenteFamiliar](
	[IdAntecedente] [int] IDENTITY(1,1) NOT NULL,
	[TipoAntecedente] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_AntecedenteFamiliar] PRIMARY KEY CLUSTERED 
(
	[IdAntecedente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AntecedentePatologico]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AntecedentePatologico](
	[IdAntecedentePatologico] [int] IDENTITY(1,1) NOT NULL,
	[Enfermedad] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_AntecedentePatologico] PRIMARY KEY CLUSTERED 
(
	[IdAntecedentePatologico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AntecendeteQuirurgico]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AntecendeteQuirurgico](
	[IdAntQ] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Lugar] [nvarchar](100) NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_AntecendeteQuirurgico] PRIMARY KEY CLUSTERED 
(
	[IdAntQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[Consenso]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consenso](
	[IdConsenso] [int] IDENTITY(1,1) NOT NULL,
	[DetCognitivo] [int] NOT NULL,
	[SospechaDiag] [int] NOT NULL,
	[RefNormal] [nvarchar](200) NOT NULL,
	[RefLeve] [nvarchar](200) NOT NULL,
	[RefMayor] [nvarchar](200) NOT NULL,
	[Depresion] [bit] NOT NULL,
	[RefDepresion] [nvarchar](200) NOT NULL,
	[TrastornoBip] [bit] NOT NULL,
	[RefTrasBip] [nvarchar](200) NOT NULL,
	[Esquizo] [bit] NOT NULL,
	[RefEsquizo] [nvarchar](200) NOT NULL,
	[OtroDiag] [bit] NOT NULL,
	[RefOtroDiag] [nvarchar](200) NOT NULL,
	[RefProbable] [nvarchar](200) NOT NULL,
	[RefConfirmado] [nvarchar](200) NOT NULL,
	[TrataFarma] [nvarchar](max) NOT NULL,
	[TrataNoFarma] [nvarchar](max) NOT NULL,
	[Recomendaciones] [nvarchar](max) NOT NULL,
	[Examenes] [nvarchar](max) NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_Consenso] PRIMARY KEY CLUSTERED 
(
	[IdConsenso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[Escolaridad]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[ExamenClinico]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamenClinico](
	[IdExamenClinico] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[TipoExamen] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_ExamenClinico] PRIMARY KEY CLUSTERED 
(
	[IdExamenClinico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[Paciente]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 7/4/2023 16:48:00 ******/
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
/****** Object:  Table [dbo].[SindromePredominante]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SindromePredominante](
	[IdSindrome] [int] IDENTITY(1,1) NOT NULL,
	[TipoSindrome] [nvarchar](100) NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_SindromePredominante] PRIMARY KEY CLUSTERED 
(
	[IdSindrome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SistemaSoap]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SistemaSoap](
	[IdSoap] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[TipoAcompanante] [int] NOT NULL,
	[NombreAcompanante] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[PropositoVisita] [int] NOT NULL,
	[Subjetivo] [nvarchar](max) NOT NULL,
	[Objetivo] [nvarchar](max) NOT NULL,
	[Avaluo] [nvarchar](max) NOT NULL,
	[Planes] [nvarchar](max) NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_SistemaSoap] PRIMARY KEY CLUSTERED 
(
	[IdSoap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TratamientoHistorico]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamientoHistorico](
	[IdTratamiento] [int] IDENTITY(1,1) NOT NULL,
	[Tratamiento] [nvarchar](50) NOT NULL,
	[Dosis] [nvarchar](50) NOT NULL,
	[IdMedico] [int] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Tipo] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_TratamientoHistorico] PRIMARY KEY CLUSTERED 
(
	[IdTratamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/4/2023 16:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Usuario] [nvarchar](30) NOT NULL,
	[Contrasena] [nvarchar](30) NOT NULL,
	[IdRol] [int] NOT NULL,
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
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1003, N'Modificando el primer acompanante', N'ni idea', N'menos', N'tampoco', 1, 0, 1, 0, 7)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1004, N'lo que sea', N'ni idea', N'menos', N'tampoco', 1, 0, 1, 0, 7)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1005, N'fsdf', N'fadfar', N'aafas', N'jtyiurt', 1, 0, 0, 1, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1006, N'rtqrtq', N'píop', N'fgagj', N'cvbnvbx', 0, 0, 1, 0, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1007, N'fsdf', N'fadfar', N'aafas', N'jtyiurt', 1, 0, 0, 1, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1008, N'rtqrtq', N'píop', N'fgagj', N'cvbnvbx', 0, 0, 1, 0, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1009, N'fsdf', N'fadfar', N'aafas', N'jtyiurt', 1, 0, 0, 1, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1010, N'rtqrtq', N'píop', N'fgagj', N'cvbnvbx', 0, 0, 1, 0, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1011, N'asdfasdf', N'asdfasdf', N'asdfasdfas', N'asdfasdf', 1, 0, 1, 0, 13)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1012, N'asdfasd', N'asdfasd', N'asdfasdf', N'asdfasdf', 1, 0, 1, 0, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1013, N'asdfasd', N'asdfasd', N'asdfasdf', N'asdfasdf', 1, 0, 1, 0, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1014, N'LO QUE SEA', N'LOQUE SEA', N'LOQUESEA', N'LOQUESEA', 1, 0, 1, 0, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1015, N'asdfasd', N'asdfasd', N'asdfasdf', N'asdfasdf', 1, 0, 1, 0, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1016, N'asdfasd', N'asdfasd', N'asdfasdf', N'asdfasdf', 1, 0, 1, 0, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1017, N'LO QUE SEA', N'LOQUE SEA', N'LOQUESEA', N'LOQUESEA', 1, 0, 1, 0, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1018, N'iiiiiiiiiii', N'iiiiiiiiiiiii', N'iiiiiiiiiiiii', N'iiiiiiiiiii', 1, 0, 0, 1, 5)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1019, N'ACOMPANANTE HUMBERTO', N'JJJJJJJJJk', N'k', N'kkkkkkkkkk', 1, 0, 0, 0, 7)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1020, N'segundo acompanante humnerto', N'iiiiii', N'llll', N'ppppp', 1, 0, 0, 0, 7)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1028, N'uno mas', N'55165', N'lkqpoeripeo', N'fdfdf', 0, 0, 0, 1, 1009)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1029, N'tercer intento', N'423534234', N'ttgjdfswge', N'dwe3234', 0, 0, 1, 0, 7)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1030, N'Ma Victoria Perez', N'78451236', N'la misma', N'mavict', 0, 0, 0, 1, 1011)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1031, N'Ninoska Herrera', N'25896314', N'en su casa', N'herreranino', 0, 0, 1, 0, 1011)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1035, N'prueba', N'', N'', N'', 0, 1, 0, 0, 1011)
INSERT [dbo].[Acompanante] ([IdAcpte], [NombreCompleto], [Telefono], [Direccion], [Correo], [EsAcpte], [EsCuidador], [EsPrimario], [EsSecundario], [IdPaciente]) VALUES (1036, N'Julio Ramos', N'56896598', N'lamisma de siempre', N'fadfa', 0, 1, 1, 0, 1016)
SET IDENTITY_INSERT [dbo].[Acompanante] OFF
GO
SET IDENTITY_INSERT [dbo].[AntecedenteFamiliar] ON 

INSERT [dbo].[AntecedenteFamiliar] ([IdAntecedente], [TipoAntecedente], [Descripcion], [IdPaciente]) VALUES (1, N'Antecedente Prueba', N'asdsad', 5)
SET IDENTITY_INSERT [dbo].[AntecedenteFamiliar] OFF
GO
SET IDENTITY_INSERT [dbo].[AntecedentePatologico] ON 

INSERT [dbo].[AntecedentePatologico] ([IdAntecedentePatologico], [Enfermedad], [Descripcion], [IdPaciente]) VALUES (2, N'ENF1', N'DESC2', 5)
SET IDENTITY_INSERT [dbo].[AntecedentePatologico] OFF
GO
SET IDENTITY_INSERT [dbo].[AntecendeteQuirurgico] ON 

INSERT [dbo].[AntecendeteQuirurgico] ([IdAntQ], [Descripcion], [Lugar], [Fecha], [IdPaciente]) VALUES (1, N'PRUEBA TRATAMIENTO Q', N'MANAGUA', CAST(N'2023-03-02' AS Date), 5)
INSERT [dbo].[AntecendeteQuirurgico] ([IdAntQ], [Descripcion], [Lugar], [Fecha], [IdPaciente]) VALUES (2, N'Colelitiasis ', N'Hospital Militar Managua', CAST(N'2002-05-02' AS Date), 5)
SET IDENTITY_INSERT [dbo].[AntecendeteQuirurgico] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudad] ON 

INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (1, N'ciudad1', 1)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (2, N'cuidad2', 1)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (3, N'Veracruz', 21)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (4, N'Prueba', 23)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (5, N'Condega', 28)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (6, N'El Tuma', 23)
INSERT [dbo].[Ciudad] ([IdCiudad], [Nombre], [IdDepto]) VALUES (7, N'Terrabona', 2)
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
GO
SET IDENTITY_INSERT [dbo].[Consenso] ON 

INSERT [dbo].[Consenso] ([IdConsenso], [DetCognitivo], [SospechaDiag], [RefNormal], [RefLeve], [RefMayor], [Depresion], [RefDepresion], [TrastornoBip], [RefTrasBip], [Esquizo], [RefEsquizo], [OtroDiag], [RefOtroDiag], [RefProbable], [RefConfirmado], [TrataFarma], [TrataNoFarma], [Recomendaciones], [Examenes], [IdPaciente]) VALUES (4, 1, 1, N'erqew', N'', N'', 0, N'', 1, N'hgfhsg', 0, N'', 0, N'', N'jkghkj', N'', N'tewrtw', N'klkl', N'kgjk', N'ljklghj', 1011)
INSERT [dbo].[Consenso] ([IdConsenso], [DetCognitivo], [SospechaDiag], [RefNormal], [RefLeve], [RefMayor], [Depresion], [RefDepresion], [TrastornoBip], [RefTrasBip], [Esquizo], [RefEsquizo], [OtroDiag], [RefOtroDiag], [RefProbable], [RefConfirmado], [TrataFarma], [TrataNoFarma], [Recomendaciones], [Examenes], [IdPaciente]) VALUES (19, 1, 1, N'1', N'', N'', 1, N'2', 0, N'', 0, N'', 0, N'', N'3', N'', N'4', N'5', N'6', N'7', 13)
INSERT [dbo].[Consenso] ([IdConsenso], [DetCognitivo], [SospechaDiag], [RefNormal], [RefLeve], [RefMayor], [Depresion], [RefDepresion], [TrastornoBip], [RefTrasBip], [Esquizo], [RefEsquizo], [OtroDiag], [RefOtroDiag], [RefProbable], [RefConfirmado], [TrataFarma], [TrataNoFarma], [Recomendaciones], [Examenes], [IdPaciente]) VALUES (20, 3, 2, N'', N'', N'3', 0, N'', 0, N'', 1, N'4', 0, N'', N'', N'sisisis', N'uno', N'dos', N'tres', N'cuatro', 1011)
INSERT [dbo].[Consenso] ([IdConsenso], [DetCognitivo], [SospechaDiag], [RefNormal], [RefLeve], [RefMayor], [Depresion], [RefDepresion], [TrastornoBip], [RefTrasBip], [Esquizo], [RefEsquizo], [OtroDiag], [RefOtroDiag], [RefProbable], [RefConfirmado], [TrataFarma], [TrataNoFarma], [Recomendaciones], [Examenes], [IdPaciente]) VALUES (21, 2, 1, N'', N'hay presencia de olvidos', N'', 0, N'', 0, N'', 0, N'', 1, N'Demencia senil', N'faltan examenes', N'', N'complejo b', N'terapia coductual', N'dieta y ejercicios', N'bhc', 1016)
SET IDENTITY_INSERT [dbo].[Consenso] OFF
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
SET IDENTITY_INSERT [dbo].[ExamenClinico] ON 

INSERT [dbo].[ExamenClinico] ([IdExamenClinico], [Descripcion], [TipoExamen], [Fecha], [IdPaciente]) VALUES (1, N'PRUEBA', 1, CAST(N'2023-04-07' AS Date), 5)
SET IDENTITY_INSERT [dbo].[ExamenClinico] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 

INSERT [dbo].[Medicos] ([IdMedico], [NoMedico], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [IdDepto], [IdCiudad], [FechaNac], [Identificacion], [Especialidad], [Direccion], [Correo], [Telefono], [Celular]) VALUES (14, N'00003', CAST(N'2022-10-08T15:45:17.7391633' AS DateTime2), N'Mariela', N'De los Angeles', N'opioiop', N'Maltez', 1, 2, CAST(N'2023-03-10' AS Date), N'001-101010', N'Psicologa', N'Lomas de Monserrat', N'mmurillo@hotmail.com', N'4545456', N'82521624')
INSERT [dbo].[Medicos] ([IdMedico], [NoMedico], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [IdDepto], [IdCiudad], [FechaNac], [Identificacion], [Especialidad], [Direccion], [Correo], [Telefono], [Celular]) VALUES (15, N'00004', CAST(N'2022-11-16T21:04:09.6462322' AS DateTime2), N'José', N'Armando', N'González', N'Mora', 1, 2, CAST(N'1990-06-20' AS Date), N'444-200690-0000M', N'Internista', N'su casa', N'jagm90@gmail.com', N'78787878', N'98765432')
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (5, N'0000000001', CAST(N'2023-02-28T22:24:30.6300000' AS DateTime2), N'carol', N'maria', N'flores', N'paz', N'F', 21, 3, CAST(N'1974-04-11' AS Date), N'Docente', N'001-110474-0069q', 8, N'casada', N'la misma', N'22401567', N'78970513', N'carolflorespe', N'evangelica', N'010000', N'1000', N'10000', N'', 1, N'docente', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (7, N'0000000002', CAST(N'2022-12-07T06:00:00.0000000' AS DateTime2), N'Humberto', N'Martín', N'Morales', N'Flores', N'M', 1, 1, CAST(N'1994-02-18' AS Date), N'Trabajador', N'', 1, N'Soltero', N'Managua', N'88641062', N'22401567', N'betomm', N'ninguna', N'010010', N'0000', N'00001', N'', 0, N'', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (13, N'0000000003', CAST(N'2023-03-01T21:58:45.6900000' AS DateTime2), N'reqrqew', N'fafd', N'vzcv', N'lñhl', N'M', 28, 5, CAST(N'2018-02-06' AS Date), N'nihguan', N'001-110474-0069q', 5, N'soltero', N'lkjoiewl  jlkadjfoasjdp', N'789456', N'123456', N'kqjreoiaa ', N'noa', N'010000', N'1000', N'01000', N'', 1, N'docente', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (14, N'0000000004', CAST(N'2022-12-17T11:02:04.4430000' AS DateTime2), N'dfadsf', N'dfas', N'fasdfa', N'adfasdf', N'M', 21, 3, CAST(N'2016-02-03' AS Date), N'fadsf', N'78798', 1, N'adfadf', N'fadfad', N'563456', N'252454', N'jkjkj', N'rgs', N'100000', N'1000', N'10000', N'', 0, N'', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (1009, N'0000000005', CAST(N'2023-01-21T12:40:00.6500000' AS DateTime2), N'José', N'Alejandro', N'Vargas', N'López', N'M', 21, 3, CAST(N'2010-01-03' AS Date), N'Enfermero', N'', 1, N'Soltero', N'Bo Campo Bruce', N'22516565', N'1234568', N'adfadfda', N'ninguna', N'100000', N'0010', N'00001', N'', 0, N'', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (1010, N'0000000006', CAST(N'2023-02-05T11:32:37.7830000' AS DateTime2), N'Juan', N'Ignacio', N'Solano', N'Cruz', N'M', 23, 6, CAST(N'1938-11-10' AS Date), N'carpintero', N'werewrewrw', 3, N'viudo', N'en su casa', N'87986532', N'12345678', N'juansolano@gmail.com', N'Catolica', N'001000', N'1000', N'10000', N'', 1, N'gdgdg', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (1011, N'0000000007', CAST(N'2023-02-05T11:35:07.3470000' AS DateTime2), N'prueba', N'prueba', N'prueba', N'prueba', N'M', 23, 6, CAST(N'1938-11-10' AS Date), N'carpintero', N'werewrewrw', 3, N'viudo', N'en su casa', N'87986532', N'12345678', N'juansolano@gmail.com', N'Catolica', N'001000', N'1000', N'10000', N'', 1, N'gdgdg', 0, N'', 0, 0, N'')
INSERT [dbo].[Paciente] ([IdPaciente], [NoExpediente], [FechaIngreso], [PNombre], [SNombre], [PApellido], [SApellido], [Sexo], [IdDepto], [IdCiudad], [FechaNacim], [Ocupacion], [Identificacion], [IdEscolaridad], [ECivil], [Direccion], [Telefono], [Celular], [Correo], [Religion], [Convive], [Visita], [RefVisita], [Referencia], [Trabaja], [RefTrabajo], [UltimoTrabajo], [RefUltTrabajo], [Jubilado], [Pensionado], [Estado]) VALUES (1016, N'0000000008', CAST(N'2023-03-01T22:15:19.2630000' AS DateTime2), N'Matias', N'Gabriel', N'Ramos', N'Lopez', N'M', 23, 6, CAST(N'1990-06-28' AS Date), N'Comerciante', N'110-280690-1122M', 4, N'Casado', N'en su casa', N'78787878', N'12312345', N'falala', N'budista', N'000100', N'0001', N'10000', N'', 1, N'negocio propio', 0, N'', 0, 0, N'')
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[SindromePredominante] ON 

INSERT [dbo].[SindromePredominante] ([IdSindrome], [TipoSindrome], [IdPaciente]) VALUES (1, N'erew', 1011)
SET IDENTITY_INSERT [dbo].[SindromePredominante] OFF
GO
SET IDENTITY_INSERT [dbo].[SistemaSoap] ON 

INSERT [dbo].[SistemaSoap] ([IdSoap], [Fecha], [FechaRegistro], [TipoAcompanante], [NombreAcompanante], [Direccion], [Telefono], [PropositoVisita], [Subjetivo], [Objetivo], [Avaluo], [Planes], [IdPaciente]) VALUES (1, CAST(N'2023-03-25' AS Date), CAST(N'2023-03-25T15:18:31.2900000' AS DateTime2), 1, N'1', N'2', N'3', 1, N'4', N'5', N'6', N'7', 5)
INSERT [dbo].[SistemaSoap] ([IdSoap], [Fecha], [FechaRegistro], [TipoAcompanante], [NombreAcompanante], [Direccion], [Telefono], [PropositoVisita], [Subjetivo], [Objetivo], [Avaluo], [Planes], [IdPaciente]) VALUES (2, CAST(N'2023-03-25' AS Date), CAST(N'2023-03-25T15:32:33.6823867' AS DateTime2), 1, N'dfadsfads', N'qrqeqwerq', N'lgklkhl', 1, N'hola', N'bat', N'uiiyt', N'fkjkfj', 1009)
SET IDENTITY_INSERT [dbo].[SistemaSoap] OFF
GO
SET IDENTITY_INSERT [dbo].[TratamientoHistorico] ON 

INSERT [dbo].[TratamientoHistorico] ([IdTratamiento], [Tratamiento], [Dosis], [IdMedico], [FechaRegistro], [Tipo], [IdPaciente]) VALUES (7, N'prueba', N'asdasdasd', 14, CAST(N'2023-03-25T17:15:16.6512025' AS DateTime2), 2, 5)
INSERT [dbo].[TratamientoHistorico] ([IdTratamiento], [Tratamiento], [Dosis], [IdMedico], [FechaRegistro], [Tipo], [IdPaciente]) VALUES (8, N'TRATAMIENTI FFFFFFF', N'SDASDASDASDSADASDASD', 14, CAST(N'2023-03-25T17:20:37.5959729' AS DateTime2), 2, 5)
INSERT [dbo].[TratamientoHistorico] ([IdTratamiento], [Tratamiento], [Dosis], [IdMedico], [FechaRegistro], [Tipo], [IdPaciente]) VALUES (11, N'TRATAMIEN TO 1', N'ASDASDASD', 14, CAST(N'2023-03-26T12:48:01.8040139' AS DateTime2), 1, 7)
INSERT [dbo].[TratamientoHistorico] ([IdTratamiento], [Tratamiento], [Dosis], [IdMedico], [FechaRegistro], [Tipo], [IdPaciente]) VALUES (12, N'Quetiapina 25 mg', N'Tomar una tb x la noche', 14, CAST(N'2023-03-27T21:51:19.6465631' AS DateTime2), 1, 5)
INSERT [dbo].[TratamientoHistorico] ([IdTratamiento], [Tratamiento], [Dosis], [IdMedico], [FechaRegistro], [Tipo], [IdPaciente]) VALUES (13, N'Complejo B', N'Inyectar 2cc IM c/3 días  x 5 dosis', 14, CAST(N'2023-03-27T21:57:23.8506402' AS DateTime2), 1, 5)
SET IDENTITY_INSERT [dbo].[TratamientoHistorico] OFF
GO
ALTER TABLE [dbo].[Acompanante]  WITH CHECK ADD  CONSTRAINT [FK_Acompanante_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Acompanante] CHECK CONSTRAINT [FK_Acompanante_Paciente]
GO
ALTER TABLE [dbo].[AntecedenteFamiliar]  WITH CHECK ADD  CONSTRAINT [FK_AntecedenteFamiliar_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AntecedenteFamiliar] CHECK CONSTRAINT [FK_AntecedenteFamiliar_Paciente]
GO
ALTER TABLE [dbo].[AntecedentePatologico]  WITH CHECK ADD  CONSTRAINT [FK_AntecedentePatologico_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AntecedentePatologico] CHECK CONSTRAINT [FK_AntecedentePatologico_Paciente]
GO
ALTER TABLE [dbo].[AntecendeteQuirurgico]  WITH CHECK ADD  CONSTRAINT [FK_AntecendeteQuirurgico_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AntecendeteQuirurgico] CHECK CONSTRAINT [FK_AntecendeteQuirurgico_Paciente]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Departamento] FOREIGN KEY([IdDepto])
REFERENCES [dbo].[Departamento] ([IdDepto])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Departamento]
GO
ALTER TABLE [dbo].[Consenso]  WITH CHECK ADD  CONSTRAINT [FK_Consenso_Paciente1] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Consenso] CHECK CONSTRAINT [FK_Consenso_Paciente1]
GO
ALTER TABLE [dbo].[ExamenClinico]  WITH CHECK ADD  CONSTRAINT [FK_ExamenClinico_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ExamenClinico] CHECK CONSTRAINT [FK_ExamenClinico_Paciente]
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
ALTER TABLE [dbo].[SindromePredominante]  WITH CHECK ADD  CONSTRAINT [FK_SindromePredominante_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[SindromePredominante] CHECK CONSTRAINT [FK_SindromePredominante_Paciente]
GO
ALTER TABLE [dbo].[SistemaSoap]  WITH CHECK ADD  CONSTRAINT [FK_SistemaSoap_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[SistemaSoap] CHECK CONSTRAINT [FK_SistemaSoap_Paciente]
GO
ALTER TABLE [dbo].[TratamientoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_TratamientoHistorico_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[TratamientoHistorico] CHECK CONSTRAINT [FK_TratamientoHistorico_Paciente]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
