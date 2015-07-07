use doceemel

Create Table ProdClientes
(
  codCli			int,
  codCatProd			int,
  precoSugerido			decimal(10,2)

  Constraint pkProdClientes primary key (codCli, codCatProd),
  Constraint fk1ProdClientes foreign key (codCatProd) references CategoriaProduto (codCatProd),
  Constraint fk2ProdClientes foreign key (codCli) references Clientes (codCli)
)

Create Procedure PriProdClientes
  @codCli		int,
  @codCatProd		int,
  @precoSugerido	decimal(10,2)
as
  Insert ProdClientes values (@codCli, @codCatProd, @precoSugerido)

Alter Procedure PraProdClientes
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

Create Procedure PreProdClientes
  @codCli		int,
  @codCatProd		int
as
  Delete ProdClientes
  Where codCli = @codCli and
  codCatProd = @codCatProd

Alter Procedure PrcProdClientes
  @codCli	int
as
  Select nomeCatProd, precoSugerido, CP.codCatProd, C.codCli
  From ((CategoriaProduto CP Inner Join ProdClientes PC
         on CP.codCatProd = PC.codCatProd) Inner Join
         Clientes C on PC.codCli = C.codCli)
  Where C.codCli = @codCli
 

priProdClientes 14, 1, 1.13
prcprodclientes 14


select * from categoriaproduto


select * from prodclientes

Select * from ProdClientes where codCli = 13 and codCatProd = 1

sp_helptext priPedidos

priPedidos 13, '2006-12-14', '500.00', '1', 'a'

Alter Procedure PriPedidos
  @codCli		int,
  @dataemissao		smalldatetime,
  @total		decimal(10,2) = 0,
  @status		int,
  @obsPed		text
as
  Insert into Pedidos (codCli, dataEmissao, total, status, obsPed) values 
  (@codCli, @dataEmissao, @total, @status, @obsPed)
Select @@identity

sp_helptext praPedidos

Alter Procedure PraPedidos
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


Create Procedure PrcPedidos
as
  Select codPed, Convert(varchar(11), dataEmissao, 103) as 'dataEmissao', 
  razaoSocial,
  (Case When status = 1 Then
    'Pendente'
  else
  (Case When status = 2 Then
    'Liquidado'
  else
  (Case When status = 3 Then
    'Faturado'
  end)end)end) as 'status', 
  total
  From Pedidos P Inner Join Clientes C on 
  P.codCli = C.codCli

sp_helptext priPedidosProdutos

select * from pedidosprodutos
select * from produtos

Alter Procedure PrcPedidosProdutos 1
@codPed		int
as
  Select nomeProd, qtdProd, valorUnit, totalItem
  From PedidosProdutos PP inner join Produtos P
  On PP.codProd = P.codProd and codPed = @codPed

PrcPedidosProdutos 1

sp_helpText praPedidosProdutos

Alter Procedure PrcPedidosGrid 1
  @codPed	int
as
  Select codPed, codCli, convert(varchar(11), dataEmissao, 103) as 'dataEmissao', 
  total, status, obsPed
  From Pedidos
  Where codPed = @codPed

sp_helptext priPedidosProdutos

Exec priPedidosProdutos 1, 2, 4, 1.20, 4,8

select * from PedidosProdutos
where codPed = 1

select * from pedidos

Create Table TipoTelefones
(
  codTipoTel		int identity,
  nomeTipo		varchar(30)

  Constraint pkTipoTelefones primary key (codTipoTel)
)

Create Procedure PriTipoTelefones
  @nomeTipo		varchar(30)
as
  insert TipoTelefones Values (@nomeTipo)

Create Procedure PraTipoTelefones
  @nomeTipo		varchar(30),
  @codTipoTel		int
as
  Update TipoTelefones
  Set nomeTipo = @nomeTipo
  Where codTipoTel = @codTipoTel

Create Procedure PreTipoTelefones
  @codTipoTel	int
as
  Delete TipoTelefones
  Where codTipoTel = @codTipoTel

Create Procedure PrcTipoTelefones
as
  Select codTipoTel, nomeTipo
  From TipoTelefones


Create Table TelefonesClientes
(
  codTelCli		int identity,
  codTipoTel		int,
  codCli		int,
  numero		varchar(14)

  Constraint pkTelefonesClientes primary key (codTelCli),
  Constraint fk1TelefonesClientes foreign key (codTipoTel) references TipoTelefones (codTipoTel),
  Constraint fk2TelefonesClientes foreign key (codCli) references Clientes (codCli)
)

Create Procedure PriTelefonesClientes
  @codTipoTel		int,
  @codCli		int,
  @numero		varchar(14)
as
  Insert TelefonesClientes values
  (@codTipoTel,@codCli,@numero)


Create Procedure PraTelefonesClientes
  @codTipoTel		int,
  @codCli		int,
  @numero		varchar(14),
  @codTelCli		int
as
  Update TelefonesClientes
  Set codCli = @codCli,
  numero = @numero,
  codTelCli = @codTelCli
  Where codTipoTel = @codTipoTel

Create Procedure PreTelefonesClientes
  @codTelCli		int
as
  Delete TelefonesClientes
  Where codTelCli = @codTelCli

Alter Procedure PrcTelefonesClientes
@codCli int
as
Select codTelCli, nomeTipo, numero 
From TipoTelefones TT Inner Join TelefonesClientes TC 
on TT.codTipoTel = TC.codTipoTel
Where codCli = @codCli



sp_helptext prcTipoContatoClausula

Alter Procedure PrcTipoTelefonesClausula
@clausula varchar(200)
as
execute
('Select codTipoTel, nomeTipo
  From TipoTelefones
  Where 1=1 ' + @clausula + '')

select * from tipotelefones


Select * From Clientes


delete clientes
where codcli = 18


sp_helptext pricontato


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

Exec PriContato 13, 5, 'Sizuo', '(11) 7856-9199', 'Sizuo', 'aaa', NULL,''

select * from telefonesclientes

select * from pedidos

select status from Pedidos
Where codPed = 4

update pedidos
set status = 1
where codped = 2


select * from pedidosprodutos


Create Procedure PrcPedidosProdutos1
@codPed		int,
@codProd	int
as
  Select codPed, codProd, qtdProd, valorUnit, totalItem
  From PedidosProdutos
  Where codPed = @codPed and
  codProd = @codProd

sp_helptext PrcPedidosProdutos

Alter Procedure PrcPedidosProdutos 
@codPed		int
as
  Select codPed, P.codProd, nomeProd, qtdProd, valorUnit, totalItem
  From PedidosProdutos PP inner join Produtos P
  On PP.codProd = P.codProd and codPed = @codPed

select * from pedidosprodutos

Exec PrePedidosProdutos 2, 1

Exec PriPedidos 17, '2007-1-5', '0', 1, , ''

select * from pedidos