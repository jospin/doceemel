<%
Dim host
host = ""

Function EnviarMail(from, para, subject, corpo)
  On Error Resume Next
  Set objCDO = Server.CreateObject("CDONTS.NewMail")
      With objCDO
        .From       = from
        .To         = para
        .Subject    = subject
        .BodyFormat = 0
        .MailFormat = 0
        .Body       = corpo
        .Send
      End With
  Set objCDO = Nothing

  If Err.Number <> 0 Then
     EnviaMail = False
  Else
     EnviaMail = True
  End If
End Function

Function MontaMsg(nome, mail, cidade, estado, prod_desej, mensagem)

	txt = txt & "<html>" 
	txt = txt & "<head>" 
	txt = txt & "<meta http-equive=""Content-Type"
	txt = txt & "txt = txt & ""content=""text/html; charset=iso-8859-1"">"
	txt = txt & "<body>" 
	txt = txt & "***  Encomenda de produtos - Doce & Mel  ***" 
	txt = txt & "<br><br>"  
	txt = txt & "<b>Nome:</b> " & request.form("nome") & "<br><br>"
	txt = txt & "<b>E-mail:</b> " & request.form("mail") & "<br><br>"
	txt = txt & "<b>Cidade:</b> " & request.form("cidade") & "<br><br>"
	txt = txt & "<b>Estado:</b> " & request.form("estado") & "<br><br>"
	txt = txt & "<b>Telefone:</b> " & request.form("ddd_telefone") & "&nbsp;&nbsp;" & request.form("telefone") & "<br><br>"
	
	txt = txt & "<b>Produto desejado:</b> " & request.form("prod_desej") & "<br><br>"

	txt = txt & "<b>Sabor / Quantidade:</b> " & "<br>"
		If request.form("un_trad") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Tradicional " &  "&nbsp;&nbsp; Qtde. " & request.form("un_trad") & "<br>"
		End If
		If request.form("un_brig") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Brigadeiro " &  "&nbsp;&nbsp; Qtde. " & request.form("un_brig") & "<br>"
		End If
		If request.form("un_brigbco") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Brigadeiro Branco " &  "&nbsp;&nbsp; Qtde. " & request.form("un_brigbco") & "<br>"
		End If
		If request.form("un_ama") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Amarula " &  "&nbsp;&nbsp; Qtde. " & request.form("un_ama") & "<br>"
		End If
		If request.form("un_trufa") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Trufa de Chocolate " &  "&nbsp;&nbsp; Qtde. " & request.form("un_trufa") & "<br>"
		End If
		If request.form("un_dccoco") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Doce de Côco " &  "&nbsp;&nbsp; Qtde. " & request.form("un_dccoco") & "<br>"
		End If
		If request.form("un_dcocoam") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Doce de Côco c/ Ameixa " &  "&nbsp;&nbsp; Qtde. " & request.form("un_dcocoam") & "<br>"
		End If
		If request.form("un_chococo") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Chocôco " &  "&nbsp;&nbsp; Qtde. " & request.form("un_chococo") & "<br>"
		End If
		If request.form("un_dl") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Doce de Leite " &  "&nbsp;&nbsp; Qtde. " & request.form("un_dl") & "<br>"
		End If
		If request.form("un_dlam") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Doce de Leite c/ Ameixa " &  "&nbsp;&nbsp; Qtde. " & request.form("un_dlam") & "<br>"
		End If
		If request.form("un_dlcoco") <> "" Then
		 txt = txt & "&nbsp;&nbsp; Doce de Leite c/ Côco " &  "&nbsp;&nbsp; Qtde. " & request.form("un_dlcoco") & "<br>"
		End If
		
	txt = txt & "<br>" 
	txt = txt & "<b>Mensagem:</b> " & "<br>" & request.form("mensagem")
	txt = txt & "</head>" 
	txt = txt & "</body>"
	txt = txt & "</html>"

		MontaMsg = txt
End Function
%>