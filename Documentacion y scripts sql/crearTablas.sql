USE [retoBackendOrenes]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 24/09/2022 1:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[clienteId] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[correo] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[clienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblConductor]    Script Date: 24/09/2022 1:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConductor](
	[conductorId] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
	[carnetCirculacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblConductor] PRIMARY KEY CLUSTERED 
(
	[conductorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLogCambiosUbicacion]    Script Date: 24/09/2022 1:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogCambiosUbicacion](
	[logId] [uniqueidentifier] NOT NULL,
	[vehiculoId] [uniqueidentifier] NOT NULL,
	[fechaCambio] [datetime2](7) NOT NULL,
	[ubicacionAnterior] [nvarchar](max) NULL,
	[ubicacionNueva] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblLogCambiosUbicacion] PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPedido]    Script Date: 24/09/2022 1:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPedido](
	[numeroPedido] [uniqueidentifier] NOT NULL,
	[clienteId] [uniqueidentifier] NOT NULL,
	[direccionEnvio] [nvarchar](max) NULL,
	[bultos] [int] NOT NULL,
	[importeTotal] [decimal](18, 2) NOT NULL,
	[vehiculoId] [uniqueidentifier] NOT NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
	[entregado] [bit] NOT NULL,
 CONSTRAINT [PK_tblPedido] PRIMARY KEY CLUSTERED 
(
	[numeroPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVehiculo]    Script Date: 24/09/2022 1:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVehiculo](
	[vehiculoId] [uniqueidentifier] NOT NULL,
	[conductorId] [uniqueidentifier] NOT NULL,
	[pedidosPendientes] [int] NOT NULL,
	[ubicacionActual] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblVehiculo] PRIMARY KEY CLUSTERED 
(
	[vehiculoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblLogCambiosUbicacion]  WITH CHECK ADD  CONSTRAINT [FK_tblLogCambiosUbicacion_tblVehiculo_vehiculoId] FOREIGN KEY([vehiculoId])
REFERENCES [dbo].[tblVehiculo] ([vehiculoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLogCambiosUbicacion] CHECK CONSTRAINT [FK_tblLogCambiosUbicacion_tblVehiculo_vehiculoId]
GO
ALTER TABLE [dbo].[tblPedido]  WITH CHECK ADD  CONSTRAINT [FK_tblPedido_tblCliente_clienteId] FOREIGN KEY([clienteId])
REFERENCES [dbo].[tblCliente] ([clienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblPedido] CHECK CONSTRAINT [FK_tblPedido_tblCliente_clienteId]
GO
ALTER TABLE [dbo].[tblPedido]  WITH CHECK ADD  CONSTRAINT [FK_tblPedido_tblVehiculo_vehiculoId] FOREIGN KEY([vehiculoId])
REFERENCES [dbo].[tblVehiculo] ([vehiculoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblPedido] CHECK CONSTRAINT [FK_tblPedido_tblVehiculo_vehiculoId]
GO
ALTER TABLE [dbo].[tblVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblVehiculo_tblConductor_conductorId] FOREIGN KEY([conductorId])
REFERENCES [dbo].[tblConductor] ([conductorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblVehiculo] CHECK CONSTRAINT [FK_tblVehiculo_tblConductor_conductorId]
GO
