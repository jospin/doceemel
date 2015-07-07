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
	) REFERENCES [dbo].[Usuarios] (
		[codUsu]
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






CREATE TABLE [dbo].[Usuario] (
	[idUsuario] [int] IDENTITY (1, 1) NOT NULL ,
	[sNomeDeUsuario] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL ,
	[sLoginUsuario] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL ,
	[senha] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[Ou] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[status] [char] (1) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario] ADD 
	CONSTRAINT [PK_Usuario] PRIMARY KEY  CLUSTERED 
	(
		[idUsuario]
	)  ON [PRIMARY] 
GO

CREATE TABLE [dbo].[SubMenu] (
	[codSubMenu] [int] IDENTITY (1, 1) NOT NULL ,
	[codMenuSup] [int] NULL ,
	[nomeSubMenu] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[pagina] [varchar] (40) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubMenu] ADD 
	CONSTRAINT [pkSubMenu] PRIMARY KEY  CLUSTERED 
	(
		[codSubMenu]
	)  ON [PRIMARY] 
GO


--aqui


Create Procedure PrcContextoDeSegurancaClausula
	@clausula	varchar(400)
As
Execute
	('	Select cdContexto, sNomeContexto
	From ContextoDeSeguranca
	 Where 1=1' + @clausula + '')	

GO


CREATE PROCEDURE Dbo.prs_Papeis
@clausula varchar(500)
as
 Execute
   (
      'select 
	idPapel,
	nNivelAcess,
	sNomePapel
       from [dbo].[Papel] ' + @clausula + ''
    )


GO


CREATE PROCEDURE pri_Papeis
@nome varchar(100)
as
  Insert into dbo.Papel (sNomePapel) values (@nome)


GO


CREATE PROCEDURE dbo.pre_Papeis
@codigo int
as
  Delete from dbo.Papel where idPapel = @codigo


GO




CREATE PROCEDURE dbo.pra_Papeis
@codigo int,
@nome varchar(100)
as
  Update dbo.Papel set sNomePapel = @nome where idPapel = @codigo


GO


CREATE Procedure PrcUsuario
As
	Select idUsuario, sNOmeDeUsuario, sLoginUsuario
	From Usuario

GO

Create Procedure PriContextoDeSeguranca
	@cdContexto			varchar(30),
	@sNomeContexto		varchar(50)
As
	Insert ContextoDeSeguranca Values (@cdContexto, @sNomeContexto)


GO

CREATE Procedure PraContextoDeSeguranca
	@sNomeContexto		varchar(50),
	@cdContexto			varchar(30)

As
	Update ContextoDeSeguranca
	Set sNomeContexto = @sNomeContexto
	Where cdContexto = @cdContexto

GO


Create Procedure PrcContextoDeSeguranca
As
	Select cdContexto, sNomeContexto
	From ContextoDeSeguranca


GO


Create Procedure PreContextoDeSeguranca
	@cdContexto 		varchar(30)
As
	Delete ContextoDeSeguranca
	Where cdContexto = @cdContexto


GO

CREATE Procedure PrcUsuarioClausula
	@clausula		varchar(400)
As
Execute
	('	Select idUsuario, sNOmeDeUsuario, sLoginUsuario
    	From Usuario 
	 Where 1=1' + @clausula + '')

GO

CREATE Procedure PriUsuario
	@sNomeDeUsuario		varchar(100),
	@sLoginUsuario			varchar(50),
	@senha					varchar(40),
	@oU						varchar(40),
	@status					char(1)
As
	Insert Usuario Values (@sNomeDeUsuario, @sLoginUsuario, @senha, @oU, @status)

GO

CREATE Procedure PraUsuario
	@sNomeDeUsuario		varchar(100),
	@sLoginUsuario			varchar(50),
	@senha					varchar(40),
	@oU						varchar(40),
	@status					char(1),
	@idUsuario				int
As
	Update Usuario Set
	       sNomeDeUsuario = @sNomeDeUsuario, 
          sLoginUsuario = @sLoginUsuario, 
			 senha = @senha,
			 oU = @oU,
		    status = @status
	Where idUsuario = @idUsuario

GO


Create Procedure PreUsuario
	@idUsuario				int
As
	Delete Usuario
	Where idUsuario = @idUsuario
GO


CREATE Procedure PrcPapelUsuarioClausula
	@clausula		varchar(400)
As
Execute
	('	Select sLoginUsuario, sNomeDeUsuario, sNomePapel, P.idPapel, U.idUsuario
	From Usuario U
	Inner Join PapelUsuario PU on U.idUsuario = PU.idUsuario
	Inner Join Papel P on P.idPapel = PU.idPapel
	Where 1=1 ' + @clausula + '')

GO

CREATE Procedure PrcPapelUsuario
As
	Select sLoginUsuario, sNomeDeUsuario, sNomePapel, P.idPapel, U.idUsuario
	From Usuario U
	Inner Join PapelUsuario PU on U.idUsuario = PU.idUsuario
	Inner Join Papel P on P.idPapel = PU.idPapel


GO

Create Procedure PriPapelUsuario
	@idPapel			int,
	@idUsuario		int
As
	Insert PapelUsuario Values (@idPapel, @idUsuario)


GO


Create Procedure PrePapelUsuario
	@idPapel			int,
	@idUsuario		int
As
	Delete PapelUsuario
	Where idPapel = @idPapel and
	idUsuario = @idUsuario


GO


Create Procedure PriPermissoesDoContexto
	@cdPermissao	varchar(20),
	@cdContexto	varchar(30),
	@sNomePermissao	varchar(20)
As
	Insert PermissoesDoContexto Values (@cdPermissao, @cdContexto, @sNomePermissao)

GO

CREATE TABLE [dbo].[TipoTelefone] (
	[codTipoTel] [int] IDENTITY (1, 1) NOT NULL ,
	[tipoTel] [varchar] (10) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TipoTelefone] ADD 
	CONSTRAINT [pkTipoTelefone] PRIMARY KEY  CLUSTERED 
	(
		[codTipoTel]
	)  ON [PRIMARY] 
GO

Create Procedure PriTipoTelefone
	@tipoTel			varchar(10)
as
	Insert TipoTelefone Values (@tipoTel)

GO

Create Procedure PraTipoTelefone
	@tipoTel			varchar(10),
	@codTipoTel		int
As
	Update TipoTelefone Set
	tipoTel = @tipoTel
	Where codTipoTel = @codTipoTel

GO

Create Procedure PreTipoTelefone
	@codTipoTel			int
As	
	Delete TipoTelefone
	Where codTipoTel = @codTipoTel

GO

Create Procedure PrcTipoTelefone
As
	Select codTipoTel, tipoTel From TipoTelefone

GO

Create Procedure PrcTipoTelefoneClausula
	@clausula		varchar(400)
As
Execute 
	('Select codTipoTel, tipoTel From TipoTelefone
	Where 1=1 ' + @clausula)

GO



























use doceemel

