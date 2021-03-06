USE [EstacionamientoDB]
GO
/****** Object:  Table [dbo].[Cajero]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cajero](
	[id_pAtencion] [int] NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Turno] [varchar](15) NOT NULL,
	[id_cajero] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cajero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobante](
	[id_boleta] [int] NOT NULL,
	[cod_Registro] [int] NOT NULL,
	[Fecha_Inicio] [datetime] NOT NULL,
	[Monto] [money] NOT NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[id_boleta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Espacio]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Espacio](
	[id_estacionamiento] [int] NOT NULL,
	[Disponibilidad] [bit] NULL,
	[id_Espacio] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Espacio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estacionamiento]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estacionamiento](
	[cod_local] [int] NOT NULL,
	[Nombre_Estacionamiento] [varchar](20) NOT NULL,
	[nro_Espacios] [int] NOT NULL,
	[Direccion] [varchar](50) NULL,
	[id_estacionamiento] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estacionamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ingreso]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingreso](
	[cod_registro] [int] IDENTITY(1,1) NOT NULL,
	[id_Tarifa] [int] NOT NULL,
	[id_Cajero] [int] NOT NULL,
	[Placa] [char](7) NOT NULL,
	[Fecha_reg] [datetime] NOT NULL,
	[id_Espacio] [int] NULL,
 CONSTRAINT [PK_Ingreso] PRIMARY KEY CLUSTERED 
(
	[cod_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localizacion]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localizacion](
	[cod_local] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Localizacion] PRIMARY KEY CLUSTERED 
(
	[cod_local] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PuntoAtencion]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PuntoAtencion](
	[ubicacion] [varchar](20) NULL,
	[id_pAtencion] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pAtencion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tarifa]    Script Date: 14/4/2019 23:11:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarifa](
	[Tarifa] [money] NULL,
	[Tipo_Veh] [varchar](20) NULL,
	[id_Tarifa] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Tarifa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cajero]  WITH CHECK ADD  CONSTRAINT [FK_Cajero_PAtencion] FOREIGN KEY([id_pAtencion])
REFERENCES [dbo].[PuntoAtencion] ([id_pAtencion])
GO
ALTER TABLE [dbo].[Cajero] CHECK CONSTRAINT [FK_Cajero_PAtencion]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_COMPROBANTE_REGISTRO] FOREIGN KEY([cod_Registro])
REFERENCES [dbo].[Ingreso] ([cod_registro])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_COMPROBANTE_REGISTRO]
GO
ALTER TABLE [dbo].[Espacio]  WITH CHECK ADD  CONSTRAINT [FK_Espacio_Estacionamiento] FOREIGN KEY([id_estacionamiento])
REFERENCES [dbo].[Estacionamiento] ([id_estacionamiento])
GO
ALTER TABLE [dbo].[Espacio] CHECK CONSTRAINT [FK_Espacio_Estacionamiento]
GO
ALTER TABLE [dbo].[Estacionamiento]  WITH CHECK ADD  CONSTRAINT [FK_Estacionamiento_codLocal] FOREIGN KEY([cod_local])
REFERENCES [dbo].[Localizacion] ([cod_local])
GO
ALTER TABLE [dbo].[Estacionamiento] CHECK CONSTRAINT [FK_Estacionamiento_codLocal]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Cajero_Ingreso] FOREIGN KEY([id_Cajero])
REFERENCES [dbo].[Cajero] ([id_cajero])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [FK_Cajero_Ingreso]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Espacio_Ingreso] FOREIGN KEY([id_Espacio])
REFERENCES [dbo].[Espacio] ([id_Espacio])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [FK_Espacio_Ingreso]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Tarifa] FOREIGN KEY([id_Tarifa])
REFERENCES [dbo].[Tarifa] ([id_Tarifa])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [FK_Tarifa]
GO
