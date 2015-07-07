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

