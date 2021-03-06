USE [master]
GO
/****** Object:  Database [C:\USERS\RLUCIANO.CDEEE\SOURCE\REPOS\RLUCIANOTEST\RLUCIANOTEST\APP_DATA\TESTDB.MDF]    Script Date: 20/11/2020 9:56:44 AM ******/
CREATE DATABASE [DbTest]
USE [DbTest]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 21/11/2020 11:50:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [varchar](150) NOT NULL,
	[ApellidosEmpleado] [varchar](150) NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 21/11/2020 11:50:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 
GO
INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (4, N'RUBEN ', N'LUCIANO ZARZUELA', 3, CAST(N'2020-12-04' AS Date))
GO
INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (5, N'RUBEN ', N'LUCIANO ZARZUELA', 3, CAST(N'2020-12-04' AS Date))
GO
INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (6, N'RUBEN ', N'LUCIANO ZARZUELA', 2, CAST(N'2020-12-04' AS Date))
GO
INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (7, N'RUBEN ', N'LUCIANO ZARZUELA', 1, CAST(N'2020-12-04' AS Date))
GO
INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (8, N'JOHN', N'RAEL', 1, CAST(N'2020-11-18' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] ON 
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (1, N'Enfermedad')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (2, N'Diligencia Personal')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (3, N'Otros')
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] OFF
GO
ALTER TABLE [dbo].[Permiso]  WITH NOCHECK ADD  CONSTRAINT [FK_Permiso_TipoPermiso] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[TipoPermiso] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Permiso] NOCHECK CONSTRAINT [FK_Permiso_TipoPermiso]
GO
