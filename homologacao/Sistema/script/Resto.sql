CREATE TABLE [dbo].[ContextoDeSeguranca] (
	[cdContexto] [varchar] (30) COLLATE Latin1_General_CI_AS NOT NULL ,
	[sNomeContexto] [varchar] (50) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Papel] (
	[idPapel] [int] IDENTITY (1, 1) NOT NULL ,
	[sNomePapel] [varchar] (50) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CCusto] (
	[codCCusto] [int] IDENTITY (1, 1) NOT NULL ,
	[nomeCCusto] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[status] [varchar] (10) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PermissoesDoContexto] (
	[cdPermissao] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL ,
	[cdContexto] [varchar] (30) COLLATE Latin1_General_CI_AS NOT NULL ,
	[sNomePermissao] [varchar] (20) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuario] (
	[idUsuario] [int] IDENTITY (1, 1) NOT NULL ,
	[sNomeDeUsuario] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL ,
	[sLoginUsuario] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL ,
	[codCCusto] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PapelUsuario] (
	[idPapel] [int] NOT NULL ,
	[idUsuario] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PermissaoPapel] (
	[cdContexto] [varchar] (30) COLLATE Latin1_General_CI_AS NOT NULL ,
	[cdPermissao] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL ,
	[idPapel] [int] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContextoDeSeguranca] ADD 
	CONSTRAINT [PK_ContextoDeSeguranca] PRIMARY KEY  CLUSTERED 
	(
		[cdContexto]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Papel] ADD 
	CONSTRAINT [PK_Papel] PRIMARY KEY  CLUSTERED 
	(
		[idPapel]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CCusto] ADD 
	CONSTRAINT [pkCCusto] PRIMARY KEY  CLUSTERED 
	(
		[codCCusto]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PermissoesDoContexto] ADD 
	CONSTRAINT [PK_PermissoesDoContexto] PRIMARY KEY  CLUSTERED 
	(
		[cdPermissao],
		[cdContexto]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Usuario] ADD 
	CONSTRAINT [PK_Usuario] PRIMARY KEY  CLUSTERED 
	(
		[idUsuario]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PapelUsuario] ADD 
	CONSTRAINT [PK_PapelUsuario] PRIMARY KEY  CLUSTERED 
	(
		[idPapel],
		[idUsuario]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PermissoesDoContexto] ADD 
	CONSTRAINT [FK_PermissoesDoContexto_ContextoDeSeguranca] FOREIGN KEY 
	(
		[cdContexto]
	) REFERENCES [dbo].[ContextoDeSeguranca] (
		[cdContexto]
	)
GO

ALTER TABLE [dbo].[Usuario] ADD 
	CONSTRAINT [FK_Usuario_CCusto] FOREIGN KEY 
	(
		[codCCusto]
	) REFERENCES [dbo].[CCusto] (
		[codCCusto]
	)
GO

ALTER TABLE [dbo].[PapelUsuario] ADD 
	CONSTRAINT [FK_PapelUsuario_Papel] FOREIGN KEY 
	(
		[idPapel]
	) REFERENCES [dbo].[Papel] (
		[idPapel]
	),
	CONSTRAINT [FK_PapelUsuario_Usuario] FOREIGN KEY 
	(
		[idUsuario]
	) REFERENCES [dbo].[Usuario] (
		[idUsuario]
	)
GO

ALTER TABLE [dbo].[PermissaoPapel] ADD 
	CONSTRAINT [FK_PermissaoPapel_Papel] FOREIGN KEY 
	(
		[idPapel]
	) REFERENCES [dbo].[Papel] (
		[idPapel]
	),
	CONSTRAINT [FK_PermissaoPapel_PermissoesDoContexto] FOREIGN KEY 
	(
		[cdPermissao],
		[cdContexto]
	) REFERENCES [dbo].[PermissoesDoContexto] (
		[cdPermissao],
		[cdContexto]
	)
GO

