USE [BrzaKuharicaDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[Lozinka] [varchar](50) NOT NULL,
	[KorisnickoIme] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KorakPripreme]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KorakPripreme](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRecept] [int] NOT NULL,
	[Naziv] [nvarchar](255) NOT NULL,
	[DetaljanOpis] [nvarchar](max) NOT NULL,
	[Trajanje] [float] NOT NULL,
	[Redoslijed] [int] NOT NULL,
 CONSTRAINT [PK_KorakPripreme] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MjernaJedinica]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MjernaJedinica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MjernaJedinica] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recept]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recept](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NazivJela] [nvarchar](255) NOT NULL,
	[IdAdmin] [int] NOT NULL,
	[DatumRecepta] [nchar](10) NOT NULL,
	[PutanjaSlike] [nvarchar](max) NULL,
 CONSTRAINT [PK_Recept] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sastojak]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sastojak](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Sastojak] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SastojakKorakaPripreme]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SastojakKorakaPripreme](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KorakPripremeId] [int] NULL,
	[SastojakId] [int] NULL,
	[Kolicina] [float] NULL,
	[MjernaJedinicaId] [int] NOT NULL,
 CONSTRAINT [PK_SastojakKorakaPripreme] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zacin]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zacin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Zacin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ZacinKorakaPripreme]    Script Date: 20.6.2015. 15:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZacinKorakaPripreme](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KorakPripremeId] [int] NULL,
	[ZacinId] [int] NULL,
	[Kolicina] [float] NULL,
	[MjernaJedinicaId] [int] NOT NULL,
 CONSTRAINT [PK_ZacinKorakaPripreme] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[KorakPripreme]  WITH CHECK ADD  CONSTRAINT [FK_KorakPripreme_Recept] FOREIGN KEY([IdRecept])
REFERENCES [dbo].[Recept] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KorakPripreme] CHECK CONSTRAINT [FK_KorakPripreme_Recept]
GO
ALTER TABLE [dbo].[Recept]  WITH CHECK ADD  CONSTRAINT [FK_Recept_Korisnik] FOREIGN KEY([IdAdmin])
REFERENCES [dbo].[Admin] ([Id])
GO
ALTER TABLE [dbo].[Recept] CHECK CONSTRAINT [FK_Recept_Korisnik]
GO
ALTER TABLE [dbo].[SastojakKorakaPripreme]  WITH CHECK ADD  CONSTRAINT [FK_SastojakKorakaPripreme_KorakPripreme] FOREIGN KEY([KorakPripremeId])
REFERENCES [dbo].[KorakPripreme] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SastojakKorakaPripreme] CHECK CONSTRAINT [FK_SastojakKorakaPripreme_KorakPripreme]
GO
ALTER TABLE [dbo].[SastojakKorakaPripreme]  WITH CHECK ADD  CONSTRAINT [FK_SastojakKorakaPripreme_MjernaJedinica] FOREIGN KEY([MjernaJedinicaId])
REFERENCES [dbo].[MjernaJedinica] ([Id])
GO
ALTER TABLE [dbo].[SastojakKorakaPripreme] CHECK CONSTRAINT [FK_SastojakKorakaPripreme_MjernaJedinica]
GO
ALTER TABLE [dbo].[SastojakKorakaPripreme]  WITH CHECK ADD  CONSTRAINT [FK_SastojakKorakaPripreme_Sastojak] FOREIGN KEY([SastojakId])
REFERENCES [dbo].[Sastojak] ([Id])
GO
ALTER TABLE [dbo].[SastojakKorakaPripreme] CHECK CONSTRAINT [FK_SastojakKorakaPripreme_Sastojak]
GO
ALTER TABLE [dbo].[ZacinKorakaPripreme]  WITH CHECK ADD  CONSTRAINT [FK_ZacinKorakaPripreme_KorakPripreme] FOREIGN KEY([KorakPripremeId])
REFERENCES [dbo].[KorakPripreme] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZacinKorakaPripreme] CHECK CONSTRAINT [FK_ZacinKorakaPripreme_KorakPripreme]
GO
ALTER TABLE [dbo].[ZacinKorakaPripreme]  WITH CHECK ADD  CONSTRAINT [FK_ZacinKorakaPripreme_MjernaJedinica] FOREIGN KEY([MjernaJedinicaId])
REFERENCES [dbo].[MjernaJedinica] ([Id])
GO
ALTER TABLE [dbo].[ZacinKorakaPripreme] CHECK CONSTRAINT [FK_ZacinKorakaPripreme_MjernaJedinica]
GO
ALTER TABLE [dbo].[ZacinKorakaPripreme]  WITH CHECK ADD  CONSTRAINT [FK_ZacinKorakaPripreme_Zacin] FOREIGN KEY([ZacinId])
REFERENCES [dbo].[Zacin] ([Id])
GO
ALTER TABLE [dbo].[ZacinKorakaPripreme] CHECK CONSTRAINT [FK_ZacinKorakaPripreme_Zacin]
GO
