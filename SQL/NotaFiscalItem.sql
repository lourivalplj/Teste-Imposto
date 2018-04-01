USE [Teste]
GO

/****** Object:  Table [dbo].[NotaFiscalItem]    Script Date: 01/04/2018 18:38:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotaFiscalItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdNotaFiscal] [int] NULL,
	[Cfop] [varchar](5) NULL,
	[TipoIcms] [varchar](20) NULL,
	[BaseIcms] [decimal](18, 5) NULL,
	[AliquotaIcms] [decimal](18, 5) NULL,
	[ValorIcms] [decimal](18, 5) NULL,
	[BaseIPI] [decimal](18, 5) NULL,
	[AliquotaIPI] [decimal](18, 5) NULL,
	[ValorIPI] [decimal](18, 5) NULL,
	[NomeProduto] [varchar](50) NULL,
	[CodigoProduto] [varchar](20) NULL,
 CONSTRAINT [PK_NotaFiscalItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

