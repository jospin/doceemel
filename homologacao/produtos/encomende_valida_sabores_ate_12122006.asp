<!--#include file="mail_encomende.asp"-->
<HTML>
<HEAD>
<meta http-equiv=Content-Type content="text/html; charset=iso-8859-1">
<TITLE>:: Doce &amp; Mel - Doces Caseiros ::</TITLE>
<link rel="STYLESHEET" type="text/css" href="../css/default.css">
 <script>
  function email_valido(email) {
        var formato_errado = "(@.*@)|(\\.\\.)|(@\\.)|(\\.@)|(^\\.)";
        var formato_certo = "^.+\\@(\\[?)[a-zA-Z0-9\\-\\.]+\\.([a-zA-Z]{2,3}|[0-9]{1,3})(\\]?)$";
        var errado = new RegExp(formato_errado);
        var certo = new RegExp(formato_certo);
        return (!errado.test(email) && certo.test(email))
  }

function valida(){

     var erro = '';

     var cab = '';

     var n = 0;

     if (document.forms[0].nome.value == '') {

        erro = erro + 'O campo (nome) tem que ser preenchido.\n';

     }

     if (document.forms[0].mail.value == '') {

        erro = erro + 'O campo (e-mail) tem que ser preenchido.\n';

     }

     else{

        if (!email_valido(document.forms[0].mail.value)){

            erro = erro + 'O campo (e-mail) está inválido.\n';

        }

     } 

      if(!document.forms[0].prod_desej[0].checked && !document.forms[0].prod_desej[1].checked && !document.forms[0].prod_desej[2].checked ){

        erro = erro + 'O campo (produto desejado) tem que ser preenchido.\n';

    }

     if (document.forms[0].un_trad.value == '') {

        erro = erro + 'O campo (sabor/quantidade) tem que ser preenchido.\n';

     }

     if (document.forms[0].mensagem.value == '') {

        erro = erro + 'O campo (mensagem) tem que ser preenchido.\n';

     }

     if (erro != ''){
         cab = 'Ocorreram erros:\n\n'
         alert(cab + erro);
         return false;
     }
  }

	function checa(nform) {
		//validacao de radio buttons sem saber quantos sao
		marcado = -1
		for (i=0; i<nform.prod_desej.length; i++) {
			if (nform.prod_desej[i].checked) {
				marcado = i
				resposta = nform.prod_desej[i].value
			}
		}
		
		if (marcado == -1) {
			alert("Selecione uma opção de produto.");
			nform.prod_desej[0].focus();
			return false;
		} else { //esse else so foi colocado para evitar que o form desse o submit
			//alert("Você selecionou que é " + resposta); 
			return true; 
		} 
			return true;
	}
 </script>
</HEAD>
<BODY background="../imgs/bg_diagonal.gif" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td><table width="770" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
        <tr> 
          <td valign="top"> <table width="770" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td colspan="2"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="770" height="121">
                    <param name="movie" value="../topo.swf">
					<param name="quality" value="transparent">
                    <param name="quality" value="high">
                    <embed src="../topo.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="770" height="121"></embed></object></td>
              </tr>
              <tr> 
                <td width="20" valign="top">&nbsp;</td>
                <td valign="top"> 
                  <p><img src="imgs/tl_encomende.gif" width="192" height="17"></p>
                  <p class="font_cinza"> 
                    <%
         If Request.ServerVariables("Content_Length") = 0 Then
%>
                    Gostou de nossos produtos? Aposto que ficou com vontade de 
                    experiment&aacute;-los n&atilde;o?<br>
                    Ent&atilde;o prencha o formul&aacute;rio abaixo que retornaremos 
                    o mais breve poss&iacute;vel seu pedido.</p>
                  <form name="" method="post" action="<%=Request.ServerVariables("../contatos/Script_Name")%>">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td><table width="98%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                              <td colspan="2"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284">nome</font><br>
                                <input type="text" name="nome" class="input" size="50">
                                </b><br> </td>
                              <td width="52%"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284">e-mail</font><br>
                                <input type="text" name="mail" class="input" size="50"></b></td>
                            </tr>
                            <tr> 
                              <td width="37%"> <b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284">cidade</font><br>
                                <input type="text" name="cidade" class="input" size="35">
                                </b> </td>
                              <td width="19%"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284">estado</font><br>
                                <input type="text" name="estado" class="input" size="4" maxlength="2">
                                </b></td>
                              <td><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284">telefone</font><br>
                                <input name="ddd_telefone" type="text" class="input" id="ddd_telefone" size="2" maxlength="2">
                                <input name="telefone" type="text" class="input" id="telefone" size="9" maxlength="9">
                                </b></td>
                            </tr>
                            <tr> 
                              <td colspan="3"><br>
                                <table width="100%" border="0" cellpadding="1" cellspacing="3" bgcolor="FAF2D9">
                                  <tr> 
                                    <td width="45%" valign="top"><span class="font_marrom2"><strong>Obs:</strong> 
                                      </span><br>
                                      <span class="font_marron_claropq"> P&atilde;es 
                                      de Mel:</span><span class="font_cinza"><br>
                                      </span><span class="font_marrom2">*</span><span class="font_cinza"> 
                                      Doce de Leite c/ C&ocirc;co, Doce de Leite 
                                      c/ Ameixa, Doce de C&ocirc;co c/ Ameixa, 
                                      Choc&ocirc;co e Tradicional - m&iacute;nimo 
                                      de 20 unids/cada.<br>
                                      Demais sabores: o pedido pode ser misto, 
                                      tendo como<br>
                                      m&iacute;nimo 20 unids.<br>
                                      <br>
                                      </span><span class="font_marron_claropq">Mini 
                                      P&atilde;es de Mel:</span><span class="font_marrom2">*</span><span class="font_cinza"><br>
                                      Todos os sabores: pedido m&iacute;nimo de 
                                      100 unids <br>
                                      (m&aacute;ximo 4 sabores)</span></td>
                                    <td width="2%" valign="top">&nbsp;</td>
                                    <td width="45%" valign="top" class="font_cinza"><span class="font_marron_claropq"><br>
                                      Bombons:</span><span class="font_marrom2">*</span> 
                                      <br>
                                      Todos os sabores: pedido m&iacute;nimo de 
                                      50 unids <br>
                                      (m&aacute;ximo 4 sabores)<br> <br>
                                      <span class="font_marron_claropq">Ovos de 
                                      P&aacute;scoa:</span><span class="font_marrom2">*</span><br>
                                      Todos os sabores: pedido m&iacute;nimo de 
                                      1 Kg <br>
                                      (2 unids de 500g ou 1 unid de 1 kg)<br>
                                      <br>
                                      <span class="font_marrom2">*</span> <strong><span class="font_marrom2">N&atilde;o 
                                      h&aacute; pronta entrega</span></strong>, 
                                      apenas encomendas com prazo de 01 semana.</td>
                                  </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr> 
                                    <td colspan="3"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"><br>
                                      produto desejado</font></b></td>
                                  </tr>
                                  <tr> 
                                    <td width="15%"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <input name="prod_desej" type="radio" value="P&atilde;o de Mel">
                                      </font><span class="font_marrom2">P&atilde;o 
                                      de Mel</span></b> </td>
                                    <td width="15%"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <input name="prod_desej" type="radio" value="Bombom">
                                      </font><span class="font_marrom2">Bombom</span></b></td>
                                    <td width="62%"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <input name="prod_desej" type="radio" value="Ovo de P&aacute;scoa">
                                      </font><span class="font_marrom2">Ovo de 
                                      P&aacute;scoa </span></b></td>
                                  </tr>
                                </table>
                                <b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"><br>
                                </font></b> <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr> 
                                    <td colspan="8"><font color="848284" size="1" face="Verdana, Arial, Helvetica, sans-serif"><b>sabor 
                                      / quantidade</b></font></td>
                                  </tr>
                                  <tr> 
                                    <td class="font_marron_claropq"><b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b>Tradicional</b></td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_trad" type="text" class="input" id="un_trad" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Trufa de Chocolate</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_trufa" type="text" class="input" id="un_trufa" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Doce de Leite</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_dl" type="text" class="input" id="un_dl" size="3" maxlength="3">
                                      </b>unidades</td>
                                  </tr>
                                  <tr> 
                                    <td class="font_marron_claropq"><b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b>Brigadeiro</b></td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_brig" type="text" class="input" id="un_brig" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Doce de C&ocirc;co</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_dccoco" type="text" class="input" id="un_dccoco" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Doce de Leite 
                                      c/ Ameixa</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_dlam" type="text" class="input" id="un_dlam" size="3" maxlength="3">
                                      </b>unidades</td>
                                  </tr>
                                  <tr> 
                                    <td class="font_marron_claropq"><b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b>Brigadeiro Branco</b></td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_brigbco" type="text" class="input" id="un_brigbco" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Doce de C&ocirc;co 
                                      c/ Ameixa</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_dcocoam" type="text" class="input" id="un_dcocoam" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Doce de Leite 
                                      c/ C&ocirc;co</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_dlcoco" type="text" class="input" id="un_dlcoco" size="3" maxlength="3">
                                      </b>unidades</td>
                                  </tr>
                                  <tr> 
                                    <td class="font_marron_claropq"><b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b>Amarula</b></td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_ama" type="text" class="input" id="un_ama" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20" class="font_marron_claropq">&nbsp;</td>
                                    <td class="font_marron_claropq"><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      <b><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"> 
                                      </font></b></b> </font></b>Choc&ocirc;co</td>
                                    <td width="12%" class="font_cinza"><b> 
                                      <input name="un_chococo" type="text" class="input" id="un_chococo" size="3" maxlength="3">
                                      </b>unidades</td>
                                    <td width="20">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td width="12%">&nbsp;</td>
                                  </tr>
                                </table>
                                <b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284"><br>
                                </font></b></td>
                            </tr>
                            <tr> 
                              <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr> 
                                    <td><b><font face="Verdana, Arial, Helvetica, sans-serif" size="1" color="848284">mensagem</font><br>
                                      <textarea name="mensagem" cols="90" class="input" rows="4"></textarea>
                                      </b></td>
                                    <td valign="bottom"><input name="Image" type="Image" onclick="return valida();" src="../contatos/imgs/bt_enviar.gif" width="79" height="39" border="0">
                                    </td>
                                  </tr>
                                </table></td>
                            </tr>
                            <tr> 
                              <td colspan="3"></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                  </form></td>
              </tr>
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr> 
          <td><!--#include file="../rodape.asp" --></td>
        </tr>
    </table>
            </table>
            <%
Else
     nome = Request.Form("nome")
     mail = Request.Form("mail")
     cidade = Request.Form("cidade")
     estado = Request.Form("estado")
     produto = Request.Form("prod_desej")
     mensagem = Request.Form("mensagem")

     If (EnviarMail(mail, "sac@doceemel.com.br", "Encomenda de produtos - Doce & Mel", MontaMsg(nome, mail, cidade, estado, prod_desej, mensagem))) Then
      Response.write "<b>Erro ao enviar solicitação de encomenda.</b>"
     Else
      Response.write "<font color=#848284 size=1 face=Verdana><b>Obrigado!</b><br><br>Sua solicitação foi enviada com sucesso.<br>Os preços dos produtos serão informados na resposta à sua solicitação de encomenda.<br>Em breve retornaremos seu pedido.</font><br><br><br><br><br><font color=#603913 size=1 face=Verdana, Arial, Helvetica, sans-serif><a href=encomende.asp><font color=#848284 size=1 face=Verdana>&laquo; voltar</font></a></font><br><br><br><br><br><br><br><br><br><br><br><br><br>"
     End If
End If
%> </td>
        </tr>
      </table></td>
  </tr>
  <tr> 
    <td colspan="2">
	</td>
  </tr>
</table>
</td>
        </tr>
      </table></td>
  </tr>
</table>
</BODY>
</HTML>