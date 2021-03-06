CREATE DATABASE [Estoque]  ON (NAME = N'Estoque', FILENAME = N'C:\Arquivos de programas\Microsoft SQL Server\MSSQL\data\Estoque.mdf' , SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'Estoque_log', FILENAME = N'C:\Arquivos de programas\Microsoft SQL Server\MSSQL\data\Estoque_log.LDF' , SIZE = 4, FILEGROWTH = 10%)
 COLLATE Latin1_General_CI_AS
GO

exec sp_dboption N'Estoque', N'autoclose', N'false'
GO

exec sp_dboption N'Estoque', N'bulkcopy', N'false'
GO

exec sp_dboption N'Estoque', N'trunc. log', N'false'
GO

exec sp_dboption N'Estoque', N'torn page detection', N'true'
GO

exec sp_dboption N'Estoque', N'read only', N'false'
GO

exec sp_dboption N'Estoque', N'dbo use', N'false'
GO

exec sp_dboption N'Estoque', N'single', N'false'
GO

exec sp_dboption N'Estoque', N'autoshrink', N'false'
GO

exec sp_dboption N'Estoque', N'ANSI null default', N'false'
GO

exec sp_dboption N'Estoque', N'recursive triggers', N'false'
GO

exec sp_dboption N'Estoque', N'ANSI nulls', N'false'
GO

exec sp_dboption N'Estoque', N'concat null yields null', N'false'
GO

exec sp_dboption N'Estoque', N'cursor close on commit', N'false'
GO

exec sp_dboption N'Estoque', N'default to local cursor', N'false'
GO

exec sp_dboption N'Estoque', N'quoted identifier', N'false'
GO

exec sp_dboption N'Estoque', N'ANSI warnings', N'false'
GO

exec sp_dboption N'Estoque', N'auto create statistics', N'true'
GO

exec sp_dboption N'Estoque', N'auto update statistics', N'true'
GO

if( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) )
	exec sp_dboption N'Estoque', N'db chaining', N'false'
GO

use [Estoque]
GO

CREATE TABLE [dbo].[CCusto] (
	[codCCusto] [int] IDENTITY (1, 1) NOT NULL ,
	[nomeCCusto] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[status] [varchar] (10) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuario] (
	[idUsuario] [int] IDENTITY (1, 1) NOT NULL ,
	[sNomeDeUsuario] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL ,
	[sLoginUsuario] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL ,
	[codCCusto] [int] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CCusto] ADD 
	CONSTRAINT [pkCCusto] PRIMARY KEY  CLUSTERED 
	(
		[codCCusto]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Usuario] ADD 
	CONSTRAINT [PK_Usuario] PRIMARY KEY  CLUSTERED 
	(
		[idUsuario]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Usuario] ADD 
	CONSTRAINT [FK_Usuario_CCusto] FOREIGN KEY 
	(
		[codCCusto]
	) REFERENCES [dbo].[CCusto] (
		[codCCusto]
	)
GO

