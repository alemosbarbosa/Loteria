USE [master]
GO
/****** Object:  Database [Loteria]    Script Date: 03/09/2016 21:00:41 ******/
CREATE DATABASE [Loteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Loteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Loteria.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Loteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Loteria_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Loteria] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Loteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Loteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Loteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Loteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Loteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Loteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Loteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Loteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Loteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Loteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Loteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Loteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Loteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Loteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Loteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Loteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Loteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Loteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Loteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Loteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Loteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Loteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Loteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Loteria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Loteria] SET  MULTI_USER 
GO
ALTER DATABASE [Loteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Loteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Loteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Loteria] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Loteria] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Loteria]
GO
/****** Object:  User [loteria]    Script Date: 03/09/2016 21:00:41 ******/
CREATE USER [loteria] FOR LOGIN [loteria] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [loteria]
GO
/****** Object:  Table [dbo].[Acerto]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acerto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSorteio] [int] NOT NULL,
	[IdAposta] [int] NOT NULL,
 CONSTRAINT [PK_Acerto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Aposta]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aposta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdApostador] [int] NOT NULL,
	[IdSorteio] [int] NOT NULL,
	[DhAposta] [datetime2](7) NOT NULL CONSTRAINT [DF_Aposta_DhAposta]  DEFAULT (getdate()),
	[IdTipoAcerto] [int] NULL,
 CONSTRAINT [PK_Aposta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Apostador]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apostador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[DhCadastro] [datetime2](7) NOT NULL CONSTRAINT [DF_Apostador_DhCadastro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Apostador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemAposta]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemAposta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAposta] [int] NOT NULL,
	[Numero] [int] NOT NULL,
 CONSTRAINT [PK_ItemAposta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemSorteio]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSorteio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSorteio] [int] NOT NULL,
	[Numero] [int] NOT NULL,
 CONSTRAINT [PK_ItemSorteio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sorteio]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sorteio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo] [int] NOT NULL,
	[NumSorteio] [int] NOT NULL,
	[DhCriacao] [datetime2](7) NOT NULL CONSTRAINT [DF_Sorteio_DhCriacao]  DEFAULT (getdate()),
	[DhSorteio] [datetime2](7) NULL,
	[CodStatus] [int] NOT NULL CONSTRAINT [DF_Sorteio_CodStatus]  DEFAULT ((1)),
	[QtdApostas] [int] NOT NULL CONSTRAINT [DF_Sorteio_QtdApostas]  DEFAULT ((0)),
 CONSTRAINT [PK_Sorteio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusSorteio]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusSorteio](
	[CodStatus] [int] NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StatusSorteio] PRIMARY KEY CLUSTERED 
(
	[CodStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoAcerto]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAcerto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
	[QtdNumerosAcertados] [int] NOT NULL,
 CONSTRAINT [PK_TipoAcerto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoSorteio]    Script Date: 03/09/2016 21:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSorteio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[NumSorteioCorrente] [int] NOT NULL CONSTRAINT [DF_TipoSorteio_NumSorteioCorrente]  DEFAULT ((0)),
	[MinNumerosPorJogo] [int] NOT NULL,
	[MaxNumerosPorJogo] [int] NOT NULL,
	[MinValorNumero] [int] NOT NULL,
	[MaxValorNumero] [int] NOT NULL,
 CONSTRAINT [PK_TipoSorteio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Acerto]    Script Date: 03/09/2016 21:00:41 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Acerto] ON [dbo].[Acerto]
(
	[IdSorteio] ASC,
	[IdAposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoSorteio]    Script Date: 03/09/2016 21:00:41 ******/
CREATE NONCLUSTERED INDEX [IX_TipoSorteio] ON [dbo].[TipoSorteio]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Acerto]  WITH CHECK ADD  CONSTRAINT [FK_Acerto_Aposta] FOREIGN KEY([IdAposta])
REFERENCES [dbo].[Aposta] ([Id])
GO
ALTER TABLE [dbo].[Acerto] CHECK CONSTRAINT [FK_Acerto_Aposta]
GO
ALTER TABLE [dbo].[Acerto]  WITH CHECK ADD  CONSTRAINT [FK_Acerto_Sorteio] FOREIGN KEY([IdSorteio])
REFERENCES [dbo].[Sorteio] ([Id])
GO
ALTER TABLE [dbo].[Acerto] CHECK CONSTRAINT [FK_Acerto_Sorteio]
GO
ALTER TABLE [dbo].[Aposta]  WITH CHECK ADD  CONSTRAINT [FK_Aposta_Apostador] FOREIGN KEY([IdApostador])
REFERENCES [dbo].[Apostador] ([Id])
GO
ALTER TABLE [dbo].[Aposta] CHECK CONSTRAINT [FK_Aposta_Apostador]
GO
ALTER TABLE [dbo].[Aposta]  WITH CHECK ADD  CONSTRAINT [FK_Aposta_Sorteio] FOREIGN KEY([IdSorteio])
REFERENCES [dbo].[Sorteio] ([Id])
GO
ALTER TABLE [dbo].[Aposta] CHECK CONSTRAINT [FK_Aposta_Sorteio]
GO
ALTER TABLE [dbo].[Aposta]  WITH CHECK ADD  CONSTRAINT [FK_Aposta_TipoAcerto] FOREIGN KEY([IdTipoAcerto])
REFERENCES [dbo].[TipoAcerto] ([Id])
GO
ALTER TABLE [dbo].[Aposta] CHECK CONSTRAINT [FK_Aposta_TipoAcerto]
GO
ALTER TABLE [dbo].[ItemAposta]  WITH CHECK ADD  CONSTRAINT [FK_ItemAposta_Aposta] FOREIGN KEY([IdAposta])
REFERENCES [dbo].[Aposta] ([Id])
GO
ALTER TABLE [dbo].[ItemAposta] CHECK CONSTRAINT [FK_ItemAposta_Aposta]
GO
ALTER TABLE [dbo].[ItemSorteio]  WITH CHECK ADD  CONSTRAINT [FK_ItemSorteio_Sorteio] FOREIGN KEY([IdSorteio])
REFERENCES [dbo].[Sorteio] ([Id])
GO
ALTER TABLE [dbo].[ItemSorteio] CHECK CONSTRAINT [FK_ItemSorteio_Sorteio]
GO
ALTER TABLE [dbo].[Sorteio]  WITH CHECK ADD  CONSTRAINT [FK_Sorteio_StatusSorteio] FOREIGN KEY([CodStatus])
REFERENCES [dbo].[StatusSorteio] ([CodStatus])
GO
ALTER TABLE [dbo].[Sorteio] CHECK CONSTRAINT [FK_Sorteio_StatusSorteio]
GO
ALTER TABLE [dbo].[Sorteio]  WITH CHECK ADD  CONSTRAINT [FK_Sorteio_TipoSorteio] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TipoSorteio] ([Id])
GO
ALTER TABLE [dbo].[Sorteio] CHECK CONSTRAINT [FK_Sorteio_TipoSorteio]
GO
ALTER TABLE [dbo].[TipoAcerto]  WITH CHECK ADD  CONSTRAINT [FK_TipoAcerto_TipoSorteio] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TipoSorteio] ([Id])
GO
ALTER TABLE [dbo].[TipoAcerto] CHECK CONSTRAINT [FK_TipoAcerto_TipoSorteio]
GO
USE [master]
GO
ALTER DATABASE [Loteria] SET  READ_WRITE 
GO
