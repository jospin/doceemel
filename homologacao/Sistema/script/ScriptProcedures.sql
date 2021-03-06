SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create Procedure PraEMail
	@endereco					varchar(40),
	@senha						varchar(40),
	@tamanho					varchar(10),
	@limiteRecebimento		varchar(10),
	@limiteEnvio				varchar(10),
	@codEMail					int
As
	Update EMail
	Set endereco = @endereco,
		 senha = @senha,
		 tamanho = @tamanho,
		 limiteRecebimento = @limiteRecebimento,
		 limiteEnvio = @limiteEnvio
	Where codEMail = @codEMail

/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PraIp
	@numIp						varchar(15),
	@mascara					varchar(15),
	@gateway					varchar(15),
	@acessoRemoto			int,
	@codIp						int
As
   Update Ip
	Set numIp = @numIp,
		 mascara = @mascara,
		 gateway = @gateway,
		 acessoRemoto = @acessoRemoto
   Where codIp = @codIp

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****************************************************/

Create Procedure PraPlacaMae
	@modelo						varchar(40),
	@imagem						varchar(100),
	@codPlacaMae				int
As
	Update PlacaMae
	Set modelo = @modelo,
		 imagem = @imagem
	Where codPlacaMae = @codPlacaMae

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure PraRede
	@codUsu						int,
	@senha							varchar(30),
	@unidadeOrganizacional	varchar(20),
	@status						int,
	@codRede						int
As
	Update Rede
	Set codUsu = @codUsu,
		 senha = @senha,
		 unidadeOrganizacional = @unidadeOrganizacional,
		 status = @status
	Where codRede = @codRede
/****************************************************/
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcEMail
As
	Select codEMail, endereco, tamanho
	From EMail
/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create Procedure PrcEMailClausula
	@clausula	varchar(200)
As
Execute
	('Select codEMail, endereco, tamanho
 	From EMail
 	Where 1=1 ' + @clausula + ' Order by codEMail')

/****************************************************/
--Final E-Mail
/****************************************************/



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****************************************************/

Create Procedure PrcEMailUsuarios
	@codUsu				int
As
	Select E.codEMail, EU.codUsu, endereco
	From EMail E Inner Join EMailUsuarios EU on
	E.codEMail = EU.codEMail and
	EU.codUsu = @codUsu


/****************************************************/
--Final E-MailUsuarios
/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcIp
As
  Select codIp, numIp
  From Ip

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PrcIpClausula
@clausula	varchar(200)
as
Execute
('Select codIp, numIp
 From Ip
 Where 1=1 ' + @clausula + ' Order by codIp')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create Procedure PrcPlacaMae
As
	Select codPlacaMae, modelo
	From PlacaMae

/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create Procedure PrcPlacaMaeClausula
	@clausula	varchar(200)
As
Execute
	('Select codPlacaMae, modelo
 	From PlacaMae
 	Where 1=1 ' + @clausula + ' Order by codPlacaMae')

/****************************************************/
--Final PlacaMae
/****************************************************/

/****************************************************/
--Inicio Rede
/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure PrcRede
As
	Select codRede, nomeUsu, unidadeOrganizacional
	From Rede Inner Join Usuarios on Rede.codUsu = Usuarios.codUsu
/****************************************************/
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure PrcRedeClausula
	@clausula	varchar(200)
As
Execute
	('Select codRede, nomeUsu, unidadeOrganizacional
 	From Rede Inner Join Usuarios on Rede.codUsu = Usuarios.codUsu
 	Where 1=1 ' + @clausula + ' Order by codRede')


/****************************************************/
--Final Rede
/****************************************************/


/****************************************************/
--Inicio E-Mail
/****************************************************/
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreEMail
	@codEMail			int
As
	Delete EMail
	Where codEMail = @codEMail

/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****************************************************/

Create Procedure PreEMailUsuarios
	@codEmail			int,
	@codUsu				int
As
 	Delete EMailUsuarios
	Where codEMail = @codEMail and
			codUsu = @codUsu

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PreIp
	@codIp		int
As
	Delete Ip
	Where codIp = @codIp

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****************************************************/

Create Procedure PrePlacaMae
	@codPlacaMae				int
As
	Delete PlacaMae
	Where codPlacaMae = @codPlacaMae

/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create Procedure PreRede
	@codRede				int
As
	Delete Rede
	Where codRede = @codRede

/****************************************************/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriEMail
	@endereco					varchar(40),
	@senha						varchar(40),
	@tamanho					varchar(10),
	@limiteRecebimento		varchar(10),
	@limiteEnvio				varchar(10)
As
	Insert EMail values (@endereco, @senha, @tamanho, @limiteRecebimento, @limiteEnvio)

/****************************************************/
select * from email

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--26/02/2007
/****************************************************/
--Inicio E-MailUsuarios
/****************************************************/

Create Procedure PriEmailUsuarios
	@codEMail			int,
	@codUsu				int
As
	Insert EMailUsuarios Values (@codEMail, @codUsu)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriIp
	@numIp						varchar(15),
	@mascara					varchar(15),
	@gateway					varchar(15),
	@acessoRemoto			int
As
   Insert Ip Values (@numIp, @mascara, @gateway, @acessoRemoto)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure PriLogAcesso
	@codUsu					int,
	@dataHora					smalldatetime,
	@tabela					varchar(30),
	@acao						varchar(50),
	@texto						text
As
	Insert LogAcesso Values (@codUsu, @dataHora, @tabela, @acao, @texto)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/****************************************************/
--Inicio PlacaMae
/****************************************************/

Create Procedure PriPlacaMae
	@modelo						varchar(40),
	@imagem						varchar(100)
As
	Insert PlacaMae Values (@modelo, @imagem)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure PriRede
	@codUsu						int,
	@senha							varchar(30),
	@unidadeOrganizacional	varchar(20),
	@status						int
As
	Insert Rede Values (@codUsu, @senha, @unidadeOrganizacional, @status)
/****************************************************/
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

