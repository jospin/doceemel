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

