CREATE TABLE [dbo].[CatCliente] (
	[codCatCli] [int] IDENTITY (1, 1) NOT NULL ,
	[nomeCatCli] [varchar] (40) COLLATE Latin1_General_CI_AS NOT NULL ,
	[obsCatCli] [varchar] (100) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CategoriaProduto] (
	[codCatProd] [int] IDENTITY (1, 1) NOT NULL ,
	[nomeCatProd] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[preco] [decimal](10, 2) NULL ,
	[obsCatProd] [text] COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Clientes] (
	[codCli] [int] IDENTITY (1, 1) NOT NULL ,
	[codVend] [int] NULL ,
	[codCatCli] [int] NULL ,
	[razaoSocial] [varchar] (70) COLLATE Latin1_General_CI_AS NOT NULL ,
	[nomeFantasia] [varchar] (70) COLLATE Latin1_General_CI_AS NULL ,
	[cnpjCpf] [varchar] (18) COLLATE Latin1_General_CI_AS NOT NULL ,
	[rg] [varchar] (12) COLLATE Latin1_General_CI_AS NULL ,
	[endereco] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[numero] [varchar] (10) COLLATE Latin1_General_CI_AS NULL ,
	[complemento] [varchar] (20) COLLATE Latin1_General_CI_AS NULL ,
	[bairro] [varchar] (30) COLLATE Latin1_General_CI_AS NULL ,
	[cidade] [varchar] (30) COLLATE Latin1_General_CI_AS NULL ,
	[estado] [char] (2) COLLATE Latin1_General_CI_AS NULL ,
	[cep] [char] (9) COLLATE Latin1_General_CI_AS NULL ,
	[dataAbertura] [smalldatetime] NULL ,
	[telefone] [varchar] (14) COLLATE Latin1_General_CI_AS NULL ,
	[site] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[email] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[codUsu] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Contato] (
	[codCont] [int] IDENTITY (1, 1) NOT NULL ,
	[codCli] [int] NULL ,
	[codTipoContato] [int] NULL ,
	[nomeCont] [varchar] (40) COLLATE Latin1_General_CI_AS NOT NULL ,
	[telefone] [varchar] (14) COLLATE Latin1_General_CI_AS NULL ,
	[apelido] [varchar] (20) COLLATE Latin1_General_CI_AS NULL ,
	[email] [varchar] (40) COLLATE Latin1_General_CI_AS NULL ,
	[aniversario] [smalldatetime] NULL ,
	[dayTime] [varchar] (15) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LogSistema] (
	[codLogSis] [int] IDENTITY (1, 1) NOT NULL ,
	[usuario] [varchar] (30) COLLATE Latin1_General_CI_AS NULL ,
	[lugar] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[dataHoraAcao] [smalldatetime] NULL ,
	[acao] [varchar] (500) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MatComodato] (
	[codMatCom] [int] IDENTITY (1, 1) NOT NULL ,
	[nomeMatCom] [varchar] (40) COLLATE Latin1_General_CI_AS NOT NULL ,
	[qtd] [int] NOT NULL ,
	[dataIni] [smalldatetime] NULL ,
	[dataFim] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MatComodatoCliente] (
	[codMatCom] [int] NOT NULL ,
	[codCli] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Pedidos] (
	[codPed] [int] IDENTITY (1, 1) NOT NULL ,
	[codCli] [int] NULL ,
	[dataemissao] [smalldatetime] NULL ,
	[dataliquidacao] [smalldatetime] NULL ,
	[total] [decimal](10, 2) NULL ,
	[status] [int] NULL ,
	[obsPed] [text] COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[PedidosProdutos] (
	[codPed] [int] NOT NULL ,
	[codProd] [int] NOT NULL ,
	[qtdProd] [int] NULL ,
	[valorUnit] [decimal](10, 2) NULL ,
	[totalItem] [decimal](10, 2) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProdClientes] (
	[codCli] [int] NOT NULL ,
	[codCatProd] [int] NOT NULL ,
	[precoSugerido] [decimal](10, 2) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Produtos] (
	[codProd] [int] IDENTITY (1, 1) NOT NULL ,
	[codCatProd] [int] NULL ,
	[nomeProd] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[qtdEstoque] [int] NULL ,
	[obs] [text] COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[TipoContato] (
	[codTipoContato] [int] IDENTITY (1, 1) NOT NULL ,
	[tipo] [varchar] (40) COLLATE Latin1_General_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuarios] (
	[codUsu] [int] IDENTITY (1, 1) NOT NULL ,
	[codVend] [int] NULL ,
	[nomeUsu] [varchar] (40) COLLATE Latin1_General_CI_AS NOT NULL ,
	[login] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL ,
	[senha] [varchar] (10) COLLATE Latin1_General_CI_AS NOT NULL ,
	[nivel] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Vendedores] (
	[codVend] [int] IDENTITY (1, 1) NOT NULL ,
	[nomeVend] [varchar] (40) COLLATE Latin1_General_CI_AS NOT NULL ,
	[comissao1] [float] NOT NULL ,
	[comissao2] [float] NULL ,
	[comissao3] [float] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CatCliente] WITH NOCHECK ADD 
	CONSTRAINT [pkCatCliente] PRIMARY KEY  CLUSTERED 
	(
		[codCatCli]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CategoriaProduto] WITH NOCHECK ADD 
	CONSTRAINT [pkCategoriaProduto] PRIMARY KEY  CLUSTERED 
	(
		[codCatProd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Clientes] WITH NOCHECK ADD 
	CONSTRAINT [pkClientes] PRIMARY KEY  CLUSTERED 
	(
		[codCli]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Contato] WITH NOCHECK ADD 
	CONSTRAINT [pkContato] PRIMARY KEY  CLUSTERED 
	(
		[codCont]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LogSistema] WITH NOCHECK ADD 
	CONSTRAINT [pkLogSistema] PRIMARY KEY  CLUSTERED 
	(
		[codLogSis]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[MatComodato] WITH NOCHECK ADD 
	CONSTRAINT [pkMatComodato] PRIMARY KEY  CLUSTERED 
	(
		[codMatCom]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[MatComodatoCliente] WITH NOCHECK ADD 
	CONSTRAINT [pkMatComodatoCliente1] PRIMARY KEY  CLUSTERED 
	(
		[codMatCom],
		[codCli]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Pedidos] WITH NOCHECK ADD 
	CONSTRAINT [pkPedidos] PRIMARY KEY  CLUSTERED 
	(
		[codPed]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PedidosProdutos] WITH NOCHECK ADD 
	CONSTRAINT [pkPedidosProdutos] PRIMARY KEY  CLUSTERED 
	(
		[codPed],
		[codProd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ProdClientes] WITH NOCHECK ADD 
	CONSTRAINT [pkProdClientes] PRIMARY KEY  CLUSTERED 
	(
		[codCli],
		[codCatProd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Produtos] WITH NOCHECK ADD 
	CONSTRAINT [pkProdutos] PRIMARY KEY  CLUSTERED 
	(
		[codProd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[TipoContato] WITH NOCHECK ADD 
	CONSTRAINT [pkTipoContato] PRIMARY KEY  CLUSTERED 
	(
		[codTipoContato]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Usuarios] WITH NOCHECK ADD 
	CONSTRAINT [pkUsuarios] PRIMARY KEY  CLUSTERED 
	(
		[codUsu]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Vendedores] WITH NOCHECK ADD 
	CONSTRAINT [pkVendedores] PRIMARY KEY  CLUSTERED 
	(
		[codVend]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Clientes] ADD 
	CONSTRAINT [fk1Clientes] FOREIGN KEY 
	(
		[codVend]
	) REFERENCES [dbo].[Vendedores] (
		[codVend]
	),
	CONSTRAINT [fk2Clientes] FOREIGN KEY 
	(
		[codCatCli]
	) REFERENCES [dbo].[CatCliente] (
		[codCatCli]
	),
	CONSTRAINT [fk4Clientes] FOREIGN KEY 
	(
		[codUsu]
	) REFERENCES [dbo].[Usuarios] (
		[codUsu]
	)
GO

ALTER TABLE [dbo].[Contato] ADD 
	CONSTRAINT [fk1Contato] FOREIGN KEY 
	(
		[codCli]
	) REFERENCES [dbo].[Clientes] (
		[codCli]
	),
	CONSTRAINT [fk2Contato] FOREIGN KEY 
	(
		[codTipoContato]
	) REFERENCES [dbo].[TipoContato] (
		[codTipoContato]
	)
GO

ALTER TABLE [dbo].[MatComodatoCliente] ADD 
	CONSTRAINT [fkMatComodatoCliente1] FOREIGN KEY 
	(
		[codMatCom]
	) REFERENCES [dbo].[MatComodato] (
		[codMatCom]
	),
	CONSTRAINT [fkMatComodatoCliente2] FOREIGN KEY 
	(
		[codCli]
	) REFERENCES [dbo].[Clientes] (
		[codCli]
	)
GO

ALTER TABLE [dbo].[Pedidos] ADD 
	CONSTRAINT [fk1Pedidos] FOREIGN KEY 
	(
		[codCli]
	) REFERENCES [dbo].[Clientes] (
		[codCli]
	)
GO

ALTER TABLE [dbo].[PedidosProdutos] ADD 
	CONSTRAINT [fk1PedidosProdutos] FOREIGN KEY 
	(
		[codPed]
	) REFERENCES [dbo].[Pedidos] (
		[codPed]
	),
	CONSTRAINT [fk2PedidosProdutos] FOREIGN KEY 
	(
		[codProd]
	) REFERENCES [dbo].[Produtos] (
		[codProd]
	)
GO

ALTER TABLE [dbo].[ProdClientes] ADD 
	CONSTRAINT [fk1ProdClientes] FOREIGN KEY 
	(
		[codCatProd]
	) REFERENCES [dbo].[CategoriaProduto] (
		[codCatProd]
	),
	CONSTRAINT [fk2ProdClientes] FOREIGN KEY 
	(
		[codCli]
	) REFERENCES [dbo].[Clientes] (
		[codCli]
	)
GO

ALTER TABLE [dbo].[Produtos] ADD 
	CONSTRAINT [fkProdutos] FOREIGN KEY 
	(
		[codCatProd]
	) REFERENCES [dbo].[CategoriaProduto] (
		[codCatProd]
	)
GO

ALTER TABLE [dbo].[Usuarios] ADD 
	CONSTRAINT [fkUsuarios] FOREIGN KEY 
	(
		[codVend]
	) REFERENCES [dbo].[Vendedores] (
		[codVend]
	)
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PraCatCliente
@nomeCatCli   varchar(40),
@obsCatCli    varchar(100),
@codCatCli    int
as
Update CatCliente
Set nomeCatCli = @nomeCatCli,
    obsCatCli = @obsCatCli
Where
    codCatCli = @codCatCli

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PraCategoriaProduto
  @nomeCatProd		varchar(50),
  @preco		decimal(10,2),
  @obsCatProd		text,
  @codCatProd		int
as
  Update CategoriaProduto
  Set
  nomeCatProd = @nomeCatProd,
  preco = @preco,
  obsCatProd = @obsCatProd
  Where 
  codCatProd = @codCatProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PraClientes
@codVend	int,
@codCatCli	int,
@razaoSocial	varchar(70),
@nomeFantasia	varchar(70),
@cnpjCpf	varchar(18),
@rg		varchar(12),
@endereco	varchar(40),
@numero		varchar(10),
@complemento	varchar(20),
@bairro		varchar(30),
@cidade		varchar(30),
@estado		char(2),
@cep		char(9),
@dataAbertura	smalldatetime,
@telefone	varchar(14),
@site		varchar(40),
@email		varchar(40),
@codUsu		int,
@codCli		int
as
Update Clientes
Set codVend = @codVend, 
codCatCli = @codCatCli, 
razaoSocial = @razaoSocial,
nomeFantasia = @nomeFantasia, 
cnpjCpf = @cnpjCpf, 
rg = @rg, 
endereco = @endereco, 
numero = @numero, 
complemento = @complemento,
bairro = @bairro, 
cidade = @cidade, 
estado = @estado, 
cep = @cep, 
dataAbertura = @dataAbertura, 
telefone = @telefone, 
site = @site,
email = @email, 
codUsu = @codUsu
Where codCli = @codCli

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PraContato
@codCli			int,
@codTipoContato		int,
@nomeCont		varchar(40),
@telefone		varchar(14),
@apelido		varchar(20),
@email			varchar(40),
@aniversario		smalldatetime,
@dayTime		varchar(15),
@codCont		int
as
Update Contato
Set codCli = @codCli, 
codTipoContato = @codTipoContato, 
nomeCont = @nomeCont, 
telefone = @telefone, 
apelido = @apelido,
email = @email, 
aniversario = @aniversario, 
daytime = @dayTime
Where codCont = @codCont

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PraLogSistema
@usuario					varchar(30),
@lugar						varchar(50),
@dataHoraAcao		smalldatetime,
@acao						varchar(500),
@codLogSis			int
as
Update LogSistema
set usuario = @usuario, 
    lugar = @lugar, 
    dataHoraAcao = @dataHoraAcao, 
		acao = @acao
where codLogSis = @codLogSis

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PraMatComodato
@nomeMatCom     varchar(40),
@qtd		int,
@dataIni	smalldatetime,
@dataFim	smalldatetime,
@codMatCom	int
as
Update MatComodato
Set nomeMatCom = @nomeMatCom,
    qtd = @qtd,
    dataIni = @dataIni,
    dataFim = @dataFim
Where
    codMatCom = @codMatCom

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PraPedidos
  @codCli		int,
  @dataemissao		smalldatetime,
  @total		decimal(10,2),
  @status		int,
  @obsPed		text,
  @codPed		int
as
  Update Pedidos 
  Set codCli = @codCli,
  dataEmissao = @dataEmissao,
  total = @total,
  status = @status,
  obsPed = @obsPed
  Where codPed = @codPed

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PraPedidosProdutos
  @qtdProd	int,
  @valorUnit	decimal(10,2),
  @totalItem	decimal(10,2),
  @codPed 	int,
  @codProd	int
as
  Update PedidosProdutos
  Set qtdProd = @qtdProd,
  valorUnit = @valorUnit,
  totalItem = @totalItem
  Where codPed = @codPed and
  codProd = @codProd
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PraProdClientes
  @codCli		int,
  @codCatProd		int,
  @precoSugerido	decimal(10,2)
as
  Update ProdClientes
  Set codCli = @codCli,
  codCatProd = @codCatProd,
  precoSugerido = @precoSugerido
  Where codCli = @codCli and
  codCatProd = @codCatProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PraProdutos
  @codCatProd		int,
  @nomeProd		varchar(50),
  @qtdEstoque		int,
  @obs			text,
  @codProd		int
as
  Update Produtos
  Set codCatProd = @codCatProd,
      nomeProd = @nomeProd, 
      qtdEstoque = @qtdEstoque,
      obs = @obs
      Where codProd = @codProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PraTipoContato
@tipo    varchar(40),
@codTipoContato   int
as
Update TipoContato
Set tipo = @tipo
Where codTipoContato = @codTipoContato

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure praUsuarios
@codVend			int,
@nomeUsu			varchar(40),
@login				varchar(20),
@senha				varchar(10),
@nivel				int,
@codUsu				int
as
Update Usuarios
set codVend = @codVend,
    nomeUsu = @nomeUsu,
		login = @login,
 		senha = @senha,
		nivel = @nivel
where codUsu = @codUsu


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcCatCliente
as
Select codCatCli, nomeCatCli
From CatCliente

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcCategoriaProduto
as
  Select codCatProd, nomeCatProd, preco
  From CategoriaProduto

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcClientes
as
Select codCli, razaoSocial, nomeFantasia, cnpjCpf
From Clientes

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcClientesClausula
@clausula   varchar(200)
as
Execute
('Select codCli, razaoSocial, nomeFantasia, cnpjCpf
From Clientes
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcMatComodato
as
Select codMatCom, nomeMatCom, qtd, 
convert(varchar,dataIni,103) as dataIni, 
convert(varchar,dataFim,103) as dataFim
From MatComodato

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcMatComodatoClausula
@clausula varchar(200)
as
Execute
('Select codMatCom, nomeMatCom, qtd, 
convert(varchar,dataIni,103) as dataIni, 
convert(varchar,dataFim,103) as dataFim
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcPedidos
as
  Select codPed, Convert(varchar(11), dataEmissao, 103) as 'dataEmissao', 
  razaoSocial,
  (Case When status = 1 Then
    'Pendente'
  else
  (Case When status = 2 Then
    'Faturado'
  else
  (Case When status = 3 Then
    'Liquidado'
  end)end)end) as 'status', 
  total
  From Pedidos P Inner Join Clientes C on 
  P.codCli = C.codCli
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcPedidosGrid
  @codPed	int
as
  Select codPed, codCli, convert(varchar(11), dataEmissao, 103) as 'dataEmissao', 
  total, status, obsPed
  From Pedidos
  Where codPed = @codPed


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcPedidosProdutos 
@codPed		int
as
  Select nomeProd, qtdProd, valorUnit, totalItem
  From PedidosProdutos PP inner join Produtos P
  On PP.codProd = P.codProd and codPed = @codPed

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PrcPedidosRel
	@codPed		int
As
Select qtdProd, nomeProd, valorUnit, totalItem
From ((Pedidos P Inner Join PedidosProdutos PP
On P.codPed = PP.codPed) Inner Join Produtos Pr
On PP.codProd = Pr.codProd and P.codPed = @codPed)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcPedidosRelCab
@codPed		int
As
Select codPed, razaoSocial, endereco, 
numero, complemento, bairro, cidade, 
estado, cep, cnpjcpf,
convert(varchar(11),dataEmissao,103) as 'DataEmissao', obsPed, status
From Pedidos P inner join Clientes C
On P.codCli = C.codCli and codPed = @codPed

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcProdClientes
  @codCli	int
as
  Select nomeCatProd, precoSugerido, CP.codCatProd, C.codCli
  From ((CategoriaProduto CP Inner Join ProdClientes PC
         on CP.codCatProd = PC.codCatProd) Inner Join
         Clientes C on PC.codCli = C.codCli)
  Where C.codCli = @codCli

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcProdutos
as
  Select codProd, nomeProd, qtdEstoque
  From Produtos

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PrcProdutosClausula
  @clausula	varchar(200)
as
Execute
  ('Select codProd, nomeProd, qtdEstoque
  From Produtos
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcTipoContato
as
Select codTipoContato, tipo
From TipoContato

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcTipoContatoClausula
@clausula varchar(200)
as
execute
('Select codTipoContato, tipo
  From TipoContato
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreCatCliente
@codCatCli   int
as
Delete CatCliente
Where codCatCli = @codCatCli

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreCategoriaProduto
  @codCatProd		int
as
  Delete CategoriaProduto
  Where codCatProd = @codCatProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PreClientes
@codCli		int
as
Delete Clientes
Where codCli = @codCli

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreContato
@codCont   int
as
Delete Contato
Where codCont = @codCont

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PreLogSistema
@codLogSis  int
as
Delete LogSistema
where codLogSis = @codLogSis

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreMatComodato
@codMatCom      int
as
Delete MatComodato
Where codMatCom = @codMatCom

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrePedidosProdutos
  @codPed	int,
  @codProd	int
as
  Delete PedidosProdutos
  Where codPed = @codPed and
  codProd = @codProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreProdClientes
  @codCli		int,
  @codCatProd		int
as
  Delete ProdClientes
  Where codCli = @codCli and
  codCatProd = @codCatProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreProdutos
  @codProd	int
as
  Delete Produtos
  Where codProd = @codProd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreTipoContato
@codTipoContato   int
as
Delete TipoContato
Where codTipoContato = @codTipoContato

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure preUsuarios
@codUsu      int
as
Delete Usuarios
where codUsu = @codUsu

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriCatCliente
@nomeCatCli   varchar(40),
@obsCatCli    varchar(100)
as
Insert Into CatCliente Values (@nomeCatCli, @obsCatCli)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PriCategoriaProduto
  @nomeCatProd		varchar(50),
  @preco		decimal(10,2),
  @obsCatProd		text
as
  Insert CategoriaProduto values (@nomeCatProd, @preco, @obsCatProd)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PriClientes
@codVend	int,
@codCatCli	int,
@razaoSocial	varchar(70),
@nomeFantasia	varchar(70),
@cnpjCpf	varchar(18),
@rg		varchar(12),
@endereco	varchar(40),
@numero		varchar(10),
@complemento	varchar(20),
@bairro		varchar(30),
@cidade		varchar(30),
@estado		char(2),
@cep		char(9),
@dataAbertura	smalldatetime,
@telefone	varchar(14),
@site		varchar(40),
@email		varchar(40),
@codUsu		int
as
Insert Clientes values (@codVend, @codCatCli, @razaoSocial,
@nomeFantasia, @cnpjCpf, @rg, @endereco, @numero, @complemento,
@bairro, @cidade, @estado, @cep, @dataAbertura, @telefone, @site,
@email, @codUsu)

select @@identity as Ultimo

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PriContato
@codCli			int,
@codTipoContato		int,
@nomeCont		varchar(40),
@telefone		varchar(14),
@apelido		varchar(20),
@email			varchar(40),
@aniversario		smalldatetime,
@dayTime		varchar(15)
as
Insert Contato values (@codCli, @codTipoContato, @nomeCont, @telefone, @apelido,
@email, @aniversario, @dayTime)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure PriLogSistema
@usuario					varchar(30),
@lugar						varchar(50),
@dataHoraAcao		smalldatetime,
@acao						varchar(500)
as
insert LogSistema values(@usuario, @lugar, @dataHoraAcao, @acao)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriMatComodato
@nomeMatCom     varchar(40),
@qtd		int,
@dataIni	smalldatetime,
@dataFim	smalldatetime
as
Insert Into MatComodato Values (@nomeMatCom, @qtd, @dataIni, @dataFim)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PriPedidos
  @codCli		int,
  @dataemissao		smalldatetime,
  @total		decimal(10,2) = 0,
  @status		int,
  @obsPed		text
as
  Insert into Pedidos (codCli, dataEmissao, total, status, obsPed) values 
  (@codCli, @dataEmissao, @total, @status, @obsPed)
Select @@identity

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure PriPedidosProdutos
  @codPed	int,
  @codProd	int,
  @qtdProd	int,
  @valorUnit	decimal(10,2),
  @totalItem	decimal(10,2)
as
  Insert PedidosProdutos values (@codPed, @codProd, @qtdProd, @valorUnit, @totalItem)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriProdClientes
  @codCli		int,
  @codCatProd		int,
  @precoSugerido	decimal(10,2)
as
  Insert ProdClientes values (@codCli, @codCatProd, @precoSugerido)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriProdutos
  @codCatProd		int,
  @nomeProd		varchar(50),
  @qtdEstoque		int,
  @obs			text  
as
  Insert Produtos values (@codCatProd, @nomeProd, @qtdEstoque, @obs)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriTipoContato
@tipo    varchar(40)
as
Insert TipoContato values (@tipo)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure priUsuarios
@codVend			int,
@nomeUsu			varchar(40),
@login					varchar(20),
@senha				varchar(10),
@nivel				int
as
Insert Usuarios values (@codVend, @nomeUsu, @login, @senha, @nivel)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure prsUsuariosGrid
as
Select codUsu, nomeUsu, login
from Usuarios

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure praVendedores
@nomeVend				varchar(40),
@comissao1			float,
@comissao2			float,
@comissao3			float,
@codVend				int
as
Update Vendedores
set nomeVend = @nomeVend,
    comissao1 = @comissao1,
		comissao2 = @comissao2,
    comissao3 = @comissao3
where codVend = @codVend

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure prcCatClienteClausula
@clausula  varchar(200)
as
Execute
('Select codCatCli, nomeCatCli
  From CatCliente
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure prcCatProdutoClausula
@clausula  varchar(200)
as
Execute
('Select codCatProd, nomeCatProd, preco
  From CategoriaProduto
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure prcContato
@codCli  int
as
Select codCont, nomeCont, email
From Contato
Where codCli = @codCli

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure prcStatusPedido
as
select -1 as 'Codigo', 'Todos' as 'Status'
union
select 1 as 'Codigo', 'Pendente' as 'Status'
union
select 2 as 'Codigo', 'Faturado' as 'Status'
union
select 3 as 'Codigo', 'Liquidado' as 'Status'


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure prcUsuariosClausula
@clausula varchar(200)
as
Execute
('Select codUsu, nomeUsu, login
  From Usuarios
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure prcVendedoresClausula
@clausula varchar(200)
as
Execute
('Select codVend, nomeVend, comissao1
  from Vendedores
  Where 1=1 ' + @clausula + '')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure preVendedores
@codVend      int
as
delete Vendedores
where codVend = @codVend

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure priVendedores
@nomeVend				varchar(40),
@comissao1			float,
@comissao2			float,
@comissao3			float
as
Insert Vendedores values (@nomeVend, @comissao1, @comissao2, @comissao3)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create procedure prsVendedoresGrid
as
select codVend, nomeVend, comissao1
from Vendedores

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

