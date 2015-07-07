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

Function MontaMsg(nome, mail, cidade, estado, conheceu, mensagem)

	txt = txt & "<html>" 
	txt = txt & "<head>" 
	txt = txt & "<meta http-equive=""Content-Type"
	txt = txt & "txt = txt & ""content=""text/html; charset=iso-8859-1"">"
	txt = txt & "<body>" 
	txt = txt & "***** E-mail de Contato enviado pelo site *****" 
	txt = txt & "<br><br>"  
	txt = txt & "Nome: " & request.form("nome") & "<br>"
	txt = txt & "E-mail: " & request.form("mail") & "<br>"
	txt = txt & "Cidade: " & request.form("cidade") & "<br>"
	txt = txt & "Estado: " & request.form("estado") & "<br>"
	txt = txt & "Como conheceu a Doce&Mel: " & request.form("conheceu") & "<br>"
	txt = txt & "Mensagem: " & request.form("mensagem")
	txt = txt & "</body>"
	txt = txt & "</html>"

		MontaMsg = txt
End Function
%>