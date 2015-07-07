Sub ApresentarMensagem()
'Rotina que apresenta a mensagem, no rodapé, armazenada em txtMensagem 
if form1.txtMensagem.value <> "" then 
	window.status = form1.txtMensagem.value
	Dim resposta
	resposta = MsgBox(form1.txtMensagem.value,0,"SIG-Contrata")
	form1.txtMensagem.value = ""
	form1.submit()
End if
End Sub



Sub Confirmar()
'Rotina que apresenta a mensagem, no rodapé, armazenada em txtMensagem 
if form1.txtMensagem.value <> "" then 
	window.status = form1.txtMensagem.value
	Dim resposta
	Dim botao
	Botao = 3
	resposta = MsgBox( form1.txtMensagem.value, botao )
	form1.txtMensagem.value = ""
	form1.txtResposta.Value = resposta
	form1.submit()	
End if
End Sub



Sub SolicitaConfirmacao()
'Rotina que apresenta a mensagem, no rodapé, armazenada em txtMensagem 
if form1.txtMensagem.value <> "" then 
	window.status = form1.txtMensagem.value
	Dim resposta
	resposta = MsgBox( form1.txtMensagem.value )
	form1.txtMensagem.value = ""
	MsgBox "A resposta foi [" & resposta & "]"
end if
End Sub