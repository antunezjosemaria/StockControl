USE [master]
GO
/****** Object:  Database [STOCKDB]    Script Date: 4/24/2018 8:59:41 PM ******/
CREATE DATABASE [STOCKDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STOCKDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\STOCKDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'STOCKDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\STOCKDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [STOCKDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STOCKDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STOCKDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STOCKDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STOCKDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STOCKDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STOCKDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [STOCKDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STOCKDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STOCKDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STOCKDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STOCKDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STOCKDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STOCKDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STOCKDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STOCKDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STOCKDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STOCKDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STOCKDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STOCKDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STOCKDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STOCKDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STOCKDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STOCKDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STOCKDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [STOCKDB] SET  MULTI_USER 
GO
ALTER DATABASE [STOCKDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STOCKDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STOCKDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STOCKDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [STOCKDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [STOCKDB]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 4/24/2018 8:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 4/24/2018 8:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoName] [nvarchar](50) NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (1, N'Gaseosas')
INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (2, N'Lacteos')
INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (3, N'Limpieza')
INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (4, N'Perfumeria')
INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (5, N'Fiambres')
INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (6, N'Frutas')
INSERT [dbo].[Categoria] ([CategoriaId], [CategoriaName]) VALUES (7, N'Verduras ')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ProductoId], [ProductoName], [Precio], [Cantidad], [CategoriaId]) VALUES (1, N'Pepsi', CAST(10 AS Decimal(18, 0)), 20, 1)
INSERT [dbo].[Producto] ([ProductoId], [ProductoName], [Precio], [Cantidad], [CategoriaId]) VALUES (2, N'Coca-Cola', CAST(12 AS Decimal(18, 0)), 30, 1)
INSERT [dbo].[Producto] ([ProductoId], [ProductoName], [Precio], [Cantidad], [CategoriaId]) VALUES (3, N'Sprite ', CAST(11 AS Decimal(18, 0)), 49, 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
USE [master]
GO
ALTER DATABASE [STOCKDB] SET  READ_WRITE 
GO
