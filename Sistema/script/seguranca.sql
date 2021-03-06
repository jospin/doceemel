if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PermissoesDoContexto_ContextoDeSeguranca]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PermissoesDoContexto] DROP CONSTRAINT FK_PermissoesDoContexto_ContextoDeSeguranca
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PapelUsuario_Papel]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PapelUsuario] DROP CONSTRAINT FK_PapelUsuario_Papel
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PermissaoPapel_Papel]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PermissaoPapel] DROP CONSTRAINT FK_PermissaoPapel_Papel
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PermissaoPapel_PermissoesDoContexto]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PermissaoPapel] DROP CONSTRAINT FK_PermissaoPapel_PermissoesDoContexto
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContextoDeSeguranca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ContextoDeSeguranca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Papel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Papel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PapelUsuario]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PapelUsuario]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PermissaoPapel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PermissaoPapel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PermissoesDoContexto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PermissoesDoContexto]
GO

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

CREATE TABLE [dbo].[PermissoesDoContexto] (
	[cdPermissao] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL ,
	[cdContexto] [varchar] (30) COLLATE Latin1_General_CI_AS NOT NULL ,
	[sNomePermissao] [varchar] (20) COLLATE Latin1_General_CI_AS NULL 
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

ALTER TABLE [dbo].[PapelUsuario] ADD 
	CONSTRAINT [PK_PapelUsuario] PRIMARY KEY  CLUSTERED 
	(
		[idPapel],
		[idUsuario]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PermissoesDoContexto] ADD 
	CONSTRAINT [PK_PermissoesDoContexto] PRIMARY KEY  CLUSTERED 
	(
		[cdPermissao],
		[cdContexto]
	)  ON [PRIMARY] 
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

ALTER TABLE [dbo].[PermissoesDoContexto] ADD 
	CONSTRAINT [FK_PermissoesDoContexto_ContextoDeSeguranca] FOREIGN KEY 
	(
		[cdContexto]
	) REFERENCES [dbo].[ContextoDeSeguranca] (
		[cdContexto]
	)
GO

