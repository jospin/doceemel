Public Class Maquinas
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucSuperior1 As wucSuperior
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents verificaLogin1 As verificaLogin
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents tblFornecedores As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents hidCodEnd As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodMaq As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtIdentificador As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeMaq As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvIdentificador As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvNomeMaq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtSenhaBios As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkDesSenBios As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkDesSenTela As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtSenhaTela As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpIp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpUsuario As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvIp As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpPlacaMae As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvPlacaMae As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpProcessador As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpMemoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvMemoria As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHd As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvHd As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents drpWindows As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvWindows As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvSerialWin As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtSerialWin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSerialOffice As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpOffice As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvSerialOffice As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents dtgSoftware As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgMaquinas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents drpAntiVirus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpAntiSpyware As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnLimparSoft As System.Web.UI.WebControls.Button
    Protected WithEvents btnRemoveSoft As System.Web.UI.WebControls.Button
    Protected WithEvents btnAddSoft As System.Web.UI.WebControls.Button
    Protected WithEvents drpSoftware As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvAntiVirus As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvAntiSpyware As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lnkVisualizarImagem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents dtgHistUsuario As System.Web.UI.WebControls.DataGrid
    Protected WithEvents drpHubSw As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNotaFiscal As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpPorta As System.Web.UI.WebControls.DropDownList
    Protected codForn As String

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub limparCampos()
        Me.drpIp.SelectedIndex = -1
        Me.drpUsuario.SelectedIndex = -1
        Me.drpPlacaMae.SelectedIndex = -1
        Me.drpProcessador.SelectedIndex = -1
        Me.drpMemoria.SelectedIndex = -1
        Me.drpSoftware.SelectedIndex = -1
        Me.drpAntiVirus.SelectedIndex = -1
        Me.drpAntiSpyware.SelectedIndex = -1
        Me.drpWindows.SelectedIndex = -1
        Me.drpOffice.SelectedIndex = -1
        Me.txtHd.Text = ""
        Me.txtIdentificador.Text = ""
        Me.txtNomeMaq.Text = ""
        Me.txtSenhaBios.Text = ""
        Me.txtSenhaTela.Text = ""
        Me.txtNotaFiscal.Text = ""
        Me.txtSerialOffice.Text = ""
        Me.txtSerialWin.Text = ""
        Me.hidCodMaq.Value = ""
        Me.drpPorta.SelectedIndex = -1
        Me.drpHubSw.SelectedIndex = -1
        Me.dtgHistUsuario.DataBind()
        Me.dtgMaquinas.SelectedIndex = -1
        Me.dtgSoftware.SelectedIndex = -1
    End Sub

    Sub carregaDadosGrid()
        CarregaDataGrid("Exec PrcMaquinas", Me.dtgMaquinas)
        'Session("objDataSet1") = Nothing
        'Session("objDataSet1") = objDataSet
    End Sub

    Sub carregaDadosGridHistUsuarios()
        CarregaDataGrid("Exec PrcHistoricoUsuarios " & Me.hidCodMaq.Value, Me.dtgHistUsuario)
        Session("objDataSetHistUsu") = Nothing
        Session("objDataSetHistUsu") = objDataSet
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If
            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If
            CarregaCombo(Me.drpIp, "Select codIp, numIp From Ip Order by numIp", "codIp", "numIp", True)
            CarregaCombo(Me.drpUsuario, "Select idUsuario, sNomeDeUsuario From Usuario Order By sNomeDeUsuario", "idUsuario", "sNomeDeUsuario", True)
            CarregaCombo(Me.drpPlacaMae, "Select codPlacaMae, modelo From PlacaMae Order By modelo", "codPlacaMae", "modelo", True)
            CarregaCombo(Me.drpProcessador, "Select codProc, (nomeProc + ' ' + clock) as nomeProc From Processadores Order By nomeProc", "codProc", "nomeProc", True)
            CarregaCombo(Me.drpMemoria, "Select codMem, qtd From Memoria Order By Qtd", "codMem", "qtd", True)
            CarregaCombo(Me.drpSoftware, "Select codSoft, nomeSoft From Softwares Order by nomeSoft", "codSoft", "nomeSoft", True)
            CarregaCombo(Me.drpAntiVirus, "Select codAntiVirus, nomeAntiVirus From AntiVirus Order By nomeAntiVirus", "codAntiVirus", "nomeAntiVirus", True)
            CarregaCombo(Me.drpAntiSpyware, "Select codAntiSpyware, nomeAntiSpyware From AntiSpyware Order By nomeAntiSpyware", "codAntiSpyware", "nomeAntiSpyware", True)
            CarregaCombo(Me.drpWindows, "Select codWin, modeloWin From Windows Order By modeloWin", "codWin", "modeloWin", True)
            CarregaCombo(Me.drpOffice, "Select codOffice, modeloOffice From Office Order By modeloOffice", "codOffice", "modeloOffice", True)
            CarregaCombo(Me.drpHubSw, "Select codHubSw, nome From HubSw Order By nome", "codHubSw", "nome", True)
        End If
        Me.lblPagina.Text = "Cadastro de Máquinas"
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtMaquinasI As DataTable
        Dim dtPortasI As DataTable
        Dim strSql As String
        Dim codMaq As Integer
        Try
            Dim senhaBios As String
            Dim senhaTela As String
            Dim codUsu As String
            Dim notaFiscal As String

            If Me.txtSenhaBios.Text <> "" Then senhaBios = "'" & Crypt(Me.txtSenhaBios.Text) & "'" Else senhaBios = "NULL"
            If Me.txtSenhaTela.Text <> "" Then senhaTela = "'" & Crypt(Me.txtSenhaTela.Text) & "'" Else senhaTela = "NULL"
            If Me.drpUsuario.SelectedIndex > 0 Then codUsu = Me.drpUsuario.SelectedValue Else codUsu = "NULL"
            If Me.txtNotaFiscal.Text <> "" Then notaFiscal = "'" & Me.txtNotaFiscal.Text & "'" Else notaFiscal = "NULL"

            Dim dataHora As String = convDataHora(Now())

            Dim i As Integer = 0
            Dim strMsg As String = "Este IP já está alocado na máquina: "
            Dim dtMaquinasC As DataTable = executaQuery("Select identificador, codMaq From Maquinas Where codIp <> 75 and codIp = " & Me.drpIp.SelectedValue)

            If dtMaquinasC.Rows.Count <> 0 Then
                If Me.hidCodMaq.Value <> "" Then
                    If Me.hidCodMaq.Value <> dtMaquinasC.Rows(0).Item(1) And Me.drpIp.SelectedItem.Text <> "DHCP" Then
                        For i = 0 To dtMaquinasC.Rows.Count - 1 Step 1
                            strMsg = strMsg & " \n " & dtMaquinasC.Rows(i).Item(0)
                        Next
                        strMsg = strMsg & "\n Favor selecionar outro IP!"
                        exibeMensagem(strMsg)
                        Exit Sub
                    End If
                End If
                End If
            '5End If

            If Me.hidCodMaq.Value = "" Then
                If Me.verificaLogin1.TemPermissao("I") Then
                    strSql = "Exec PriMaquinas " & Me.drpIp.SelectedValue & ", " & Me.drpPlacaMae.SelectedValue & ", " & _
                    Me.drpOffice.SelectedValue & ", " & Me.drpProcessador.SelectedValue & ", " & Me.drpAntiVirus.SelectedValue & ", " & _
                    Me.drpAntiSpyware.SelectedValue & ", " & codUsu & ", " & Me.drpWindows.SelectedValue & ", " & _
                    Me.drpMemoria.SelectedValue & ", '" & Me.txtIdentificador.Text & "', '" & Me.txtNomeMaq.Text & "', '" & _
                    Crypt(Me.txtSerialWin.Text) & "', '" & Crypt(Me.txtSerialOffice.Text) & "', '" & Me.txtHd.Text & "', " & senhaBios & _
                    ", " & senhaTela & ", " & notaFiscal '  & ", '" & Me.drpHubSw.SelectedValue & "', '" & Me.txtPorta.Text & "'"
                    dtMaquinasI = executaQuery(strSql)
                    codMaq = dtMaquinasI.Rows(0).Item(0)

                    dtMaquinasI = executaQuery("Exec PriHistoricoUsuarios " & codUsu & ", " & codMaq & ", '" & dataHora & "', NULL")
                    exibeMensagem("Inclusão efetuada com sucesso")
                Else
                    RemeterUsuario("Incluir")
                End If
            Else
                If Me.verificaLogin1.TemPermissao("A") Then
                    Dim dtMaquinasCo As DataTable = executaQuery("Select codUsu From Maquinas Where codMaq = " & Me.hidCodMaq.Value)
                    strSql = "Exec PraMaquinas " & Me.drpIp.SelectedValue & ", " & Me.drpPlacaMae.SelectedValue & ", " & _
                    Me.drpOffice.SelectedValue & ", " & Me.drpProcessador.SelectedValue & ", " & Me.drpAntiVirus.SelectedValue & ", " & _
                    Me.drpAntiSpyware.SelectedValue & ", " & codUsu & ", " & Me.drpWindows.SelectedValue & ", " & _
                    Me.drpMemoria.SelectedValue & ", '" & Me.txtIdentificador.Text & "', '" & Me.txtNomeMaq.Text & "', '" & _
                    Crypt(Me.txtSerialWin.Text) & "', '" & Crypt(Me.txtSerialOffice.Text) & "', '" & Me.txtHd.Text & "', " & senhaBios & _
                    ", " & senhaTela & ", " & notaFiscal & ", " & Me.hidCodMaq.Value

                    dtMaquinasI = executaQuery(strSql)

                    dtPortasI = executaQuery("Update Portas Set codMaq = " & Me.hidCodMaq.Value & " Where idPorta = " & Me.drpPorta.SelectedValue)

                    If IsDBNull(dtMaquinasCo.Rows(0).Item(0)) = False Then
                        If dtMaquinasCo.Rows(0).Item(0) <> Me.drpUsuario.SelectedValue Then
                            dtMaquinasI = executaQuery("Exec PraHistoricoUsuarios '" & dataHora & "', " & Me.hidCodMaq.Value)
                            dtMaquinasI = executaQuery("Exec PriHistoricoUsuarios " & codUsu & ", " & Me.hidCodMaq.Value & ", '" & dataHora & "', NULL")
                        End If
                    End If
                    exibeMensagem("Alteração efetuada com sucesso")
                Else
                    RemeterUsuario("Alterar")
                End If
            End If
            Me.carregaDadosGrid()
            Me.limparCampos()
        Catch ex As Exception
            exibeMensagem(ex.Message)
        End Try
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Dim dtMaquinasE As DataTable
        Try
            If Me.verificaLogin1.TemPermissao("E") Then
                If Me.hidCodMaq.Value = "" Then
                    exibeMensagem("Selecione um registro para exclusão")
                    Exit Sub
                Else
                    dtMaquinasE = executaQuery("Exec PreMaquinas " & Me.hidCodMaq.Value)
                    exibeMensagem("Exclusão efetuada com sucesso")
                End If
            Else
                RemeterUsuario("Excluir")
            End If
            Me.carregaDadosGrid()
            Me.limparCampos()
        Catch ex As Exception
            exibeMensagem(ex.Message)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim strSql As String = "Exec PrcMaquinasClausula ' "
        If Me.verificaLogin1.TemPermissao("C") Then
            If Me.drpIp.SelectedIndex > 0 Then
                strSql = strSql & " and codIp = ''" & Me.drpIp.SelectedValue & "''"
            End If

            If Me.drpUsuario.SelectedIndex > 0 Then
                strSql = strSql & " and codUsu = ''" & Me.drpUsuario.SelectedValue & "''"
            End If

            If Me.drpWindows.SelectedIndex > 0 Then
                strSql = strSql & " and codWin = ''" & Me.drpWindows.SelectedValue & "''"
            End If

            If Me.drpOffice.SelectedIndex > 0 Then
                strSql = strSql & " and codOffice = ''" & Me.drpOffice.SelectedValue & "''"
            End If

            If Me.txtIdentificador.Text <> "" Then
                strSql = strSql & " and identificador like ''%" & Me.txtIdentificador.Text & "%''"
            End If

            If Me.txtNomeMaq.Text <> "" Then
                strSql = strSql & " and nomeMaq like ''%" & Me.txtNomeMaq.Text & "%''"
            End If


            strSql = strSql & "'"
            Me.dtgMaquinas.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.dtgMaquinas)
            Session("objDataSet1") = Nothing
            Session("objDataSet1") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgMaquinas_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgMaquinas.PageIndexChanged
        Me.dtgMaquinas.CurrentPageIndex = e.NewPageIndex
        Me.dtgMaquinas.DataSource = Session("objDataSet1")
        Me.dtgMaquinas.DataBind()
        Me.dtgMaquinas.SelectedIndex = -1
    End Sub

    Private Sub dtgMaquinas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgMaquinas.SelectedIndexChanged
        Dim codigo As Integer = IIf(Me.dtgMaquinas.Items(Me.dtgMaquinas.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgMaquinas.Items(Me.dtgMaquinas.SelectedIndex).Cells(1).Text)
        Me.hidCodMaq.Value = codigo
        Dim dtMaquinasC As DataTable = executaQuery("Select * from Maquinas Where codMaq = " & codigo)
        Me.drpIp.SelectedValue = dtMaquinasC.Rows(0).Item("codIp")
        Me.drpUsuario.SelectedValue = IIf(IsDBNull(dtMaquinasC.Rows(0).Item("codUsu")), "", dtMaquinasC.Rows(0).Item("codUsu"))
        Me.drpPlacaMae.SelectedValue = dtMaquinasC.Rows(0).Item("codPlacaMae")
        Me.drpProcessador.SelectedValue = dtMaquinasC.Rows(0).Item("codProc")
        Me.drpMemoria.SelectedValue = dtMaquinasC.Rows(0).Item("codMem")
        Me.txtHd.Text = dtMaquinasC.Rows(0).Item("hd")
        Me.drpAntiVirus.SelectedValue = dtMaquinasC.Rows(0).Item("codAntiVirus")
        Me.drpAntiSpyware.SelectedValue = dtMaquinasC.Rows(0).Item("codAntiVirus")
        Me.drpWindows.SelectedValue = dtMaquinasC.Rows(0).Item("codWin")
        Me.txtSerialWin.Text = Crypt(dtMaquinasC.Rows(0).Item("serialWindows"))
        Me.drpOffice.SelectedValue = dtMaquinasC.Rows(0).Item("codOffice")
        Me.txtSerialOffice.Text = Crypt(dtMaquinasC.Rows(0).Item("serialOffice"))
        Me.txtIdentificador.Text = dtMaquinasC.Rows(0).Item("identificador")
        Me.txtNomeMaq.Text = dtMaquinasC.Rows(0).Item("nomeMaq")
        Me.txtNotaFiscal.Text = IIf(IsDBNull(dtMaquinasC.Rows(0).Item("notaFiscal")), "", dtMaquinasC.Rows(0).Item("notaFiscal"))
        'Me.drpHubSw.SelectedValue = IIf(IsDBNull(dtMaquinasC.Rows(0).Item("codHubSw")), "", dtMaquinasC.Rows(0).Item("codHubSw"))
        'Me.drpPorta.SelectedValue = IIf(IsDBNull(dtMaquinasC.Rows(0).Item("portaHubSw")), "", dtMaquinasC.Rows(0).Item("portaHubSw"))
        Me.carregaDadosGridHistUsuarios()
        Dim dtPortasC As DataTable = executaQuery("Select codHubSw, idporta From Portas Where codMaq = " & Me.hidCodMaq.Value)
        If dtPortasC.Rows.Count > 0 Then
            CarregaCombo(Me.drpPorta, "Select idPorta, porta From Portas Where codHubSw = " & dtPortasC.Rows(0).Item(0), "idPorta", "porta", True)
            Me.drpHubSw.SelectedValue = dtPortasC.Rows(0).Item(0)
            drpHubSw_SelectedIndexChanged(sender, e)
            Me.drpPorta.SelectedValue = dtPortasC.Rows(0).Item(1)
        End If
    End Sub

    Private Sub lnkDesSenBios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkDesSenBios.Click
        If Me.verificaLogin1.TemPermissao("D") Then
            Dim dtMaquinasC As DataTable = executaQuery("Select senhaBios From Maquinas Where codMaq = " & Me.hidCodMaq.Value)
            'If dtMaquinasC.Rows.Count > 0 Or IsDBNull(dtMaquinasC.Rows(0).Item(0)) = False Then exibeMensagem(Crypt(dtMaquinasC.Rows(0).Item(0)))
            If IsDBNull(dtMaquinasC.Rows(0).Item(0)) = False Then exibeMensagem(Crypt(dtMaquinasC.Rows(0).Item(0)))
        Else
            RemeterUsuario("Desvendar senha")
        End If
    End Sub

    Private Sub lnkDesSenTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkDesSenTela.Click
        If Me.verificaLogin1.TemPermissao("D") Then
            Dim dtMaquinasC As DataTable = executaQuery("Select senhaTela From Maquinas Where codMaq = " & Me.hidCodMaq.Value)
            If IsDBNull(dtMaquinasC.Rows(0).Item(0)) = False Then exibeMensagem(Crypt(dtMaquinasC.Rows(0).Item(0)))
        Else
            RemeterUsuario("Desvendar senha")
        End If
    End Sub

    Private Sub drpIp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpIp.SelectedIndexChanged
        Dim i As Integer = 0
        Dim strMsg As String = "Este IP já está alocado na máquina: "
        Dim dtMaquinasC As DataTable = executaQuery("Select identificador From Maquinas Where codIp = " & Me.drpIp.SelectedValue)
        If dtMaquinasC.Rows.Count <> 0 And Me.drpIp.SelectedItem.Text <> "DHCP" Then
            If Me.txtIdentificador.Text <> dtMaquinasC.Rows(0).Item(0) Then
                For i = 0 To dtMaquinasC.Rows.Count - 1 Step 1
                    strMsg = strMsg & " \n " & dtMaquinasC.Rows(i).Item(0)
                Next
                strMsg = strMsg & "\n Favor selecionar outro IP!"
                exibeMensagem(strMsg)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub lnkVisualizarImagem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkVisualizarImagem.Click
        If Me.drpPlacaMae.SelectedIndex > 0 Then
            Dim dtMaquinasC As DataTable = executaQuery("Select imagem From PlacaMae Where codPlacaMae = " & Me.drpPlacaMae.SelectedValue)
            If dtMaquinasC.Rows.Count > 0 Then

                Response.Write("<script languague=javascript>window.open('PlacaMaeAbrirImagem.aspx?pProduto=','retorno','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,fullscreen=no,resizable=no,menubar=no,width=500,height=500');</script>")
                Session("linkImagem") = dtMaquinasC.Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub dtgHistUsuario_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgHistUsuario.PageIndexChanged
        Me.dtgHistUsuario.CurrentPageIndex = e.NewPageIndex
        Me.dtgHistUsuario.DataSource = Session("objDataSetHistUsu")
        Me.dtgHistUsuario.DataBind()
        Me.dtgHistUsuario.SelectedIndex = -1
    End Sub

    Private Sub btnAddSoft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSoft.Click

    End Sub

    Private Sub drpHubSw_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpHubSw.SelectedIndexChanged
        Dim strSql As String = "Select idPorta, porta From Portas Where status = 'A' and codHubSw = " & Me.drpHubSw.SelectedValue
        CarregaCombo(Me.drpPorta, strSql, "idPorta", "porta", True)
    End Sub
End Class
