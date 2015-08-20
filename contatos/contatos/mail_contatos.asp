<%
Dim host, emailRemetente, nomeDestinatario
    host = "localhost"
    emailDestinatario="contato@doceemel.provisorio.ws"
    nomeDestinatario = "Contato Doce e Mel"

Function EnviarMail(from, para, subject, corpo)
    On Error Resume Next

    SET AspEmail = Server.CreateObject("Persits.MailSender")

    AspEmail.Host = host
    AspEmail.FromName = "Contato Doce e Mel"
    AspEmail.From = from
    AspEmail.MailFrom = emailRemetente
    AspEmail.AddReplyTo from
    AspEmail.AddAddress para, nomeDestinatario
    AspEmail.Subject = subject
    AspEmail.IsHTML = True
    AspEmail.Body = corpo
    AspEmail.Port = 465
    AspEmail.Send

   If Err.Number <> 0 Then
      EnviaMail = False
   Else
      EnviaMail = True
   End If

 End Function
SET AspEmail = Nothing

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