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

