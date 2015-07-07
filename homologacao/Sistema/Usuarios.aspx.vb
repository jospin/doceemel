Public Class Usuarios
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents wucSuperior1 As wucSuperior
    Protected WithEvents verificaLogin1 As verificaLogin
    Protected WithEvents txtIdUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSNomeUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSLoginUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents dtgUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents rfvNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvLogin As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents tblUsuarios As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtConfSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtOu As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdoStatus As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lnkDesSenha As System.Web.UI.WebControls.LinkButton
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

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

    Private Sub setFocus(ByVal ctrl As System.Web.UI.Control)
        Dim sScriptCode As String = "<script>document.forms(0)." & ctrl.ClientID & ".focus()</script>"
        MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
    End Sub

    Private Sub limparCampos()
        Me.txtIdUsuario.Text = ""
        Me.txtSLoginUsuario.Text = ""
        Me.txtSNomeUsuario.Text = ""
        Me.txtSenha.Text = ""
        Me.txtConfSenha.Text = ""
        Me.txtOu.Text = ""
        Me.rdoStatus.SelectedIndex = -1
        Me.dtgUsuarios.SelectedIndex = -1
    End Sub

    Sub carregaDadosGrid()
        CarregaDataGrid("Exec PrcUsuario", Me.dtgUsuarios)
        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
                If Request("item") <> "" Then
                    Me.wucLateral1.selecionarItemLateral = Request("item")
                End If
            End If
        End If
        Me.lblPagina.Text = "Cadastro de Usuários"
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtUsuarioI As DataTable
        Dim strSql As String

        If Me.txtSenha.Text <> Me.txtConfSenha.Text Then
            exibeMensagem("As senhas não conferem! Redigite!")
            setFocus(Me.txtSenha)
            Exit Sub
        End If

        Try
            If Me.txtIdUsuario.Text = "" Then
                If Me.verificaLogin1.TemPermissao("I") Then
                    strSql = "Exec PriUsuario '" & Me.txtSNomeUsuario.Text & "', '" & Me.txtSLoginUsuario.Text & "', '" & _
                    Crypt(Me.txtSenha.Text) & "', '" & Me.txtOu.Text & "', '" & Me.rdoStatus.SelectedValue & "'"
                    dtUsuarioI = executaQuery(strSql)
                    If dtUsuarioI.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtUsuarioI.Rows(0).Item(0), "'", ""))
                    Else
                        exibeMensagem("Inclusão efetuada com sucesso")
                        Me.carregaDadosGrid()
                        Me.limparCampos()
                    End If
                    Me.tblUsuarios.Rows(3).Visible = True
                    Me.tblUsuarios.Rows(1).Visible = False
                Else
                    RemeterUsuario("Incluir")
                End If
            Else
                If Me.verificaLogin1.TemPermissao("A") Then
                    strSql = "Exec PraUsuario '" & Me.txtSNomeUsuario.Text & "', '" & Me.txtSLoginUsuario.Text & "', '" & _
                    Crypt(Me.txtSenha.Text) & "', '" & Me.txtOu.Text & "', '" & Me.rdoStatus.SelectedValue & "', " & Me.txtIdUsuario.Text
                    dtUsuarioI = executaQuery(strSql)
                    If dtUsuarioI.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtUsuarioI.Rows(0).Item(0), "'", ""))
                    Else
                        exibeMensagem("Alteração efetuada com sucesso")
                        Me.carregaDadosGrid()
                        Me.limparCampos()
                    End If
                Else
                    RemeterUsuario("Alterar")
                End If
            End If
        Catch ex As Exception
            exibeMensagem(ex.Message)
        End Try
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Me.limparCampos()
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Dim dtUsuarioE As DataTable
        Try
            If Me.verificaLogin1.TemPermissao("E") Then
                If Me.txtIdUsuario.Text = "" Then
                    exibeMensagem("Selecione um registro para exclusão")
                    Exit Sub
                Else
                    dtUsuarioE = executaQuery("Exec PreUsuario1 " & Me.txtIdUsuario.Text)
                    If dtUsuarioE.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtUsuarioE.Rows(0).Item(0), "'", ""))
                    Else
                        exibeMensagem("Exclusão efetuada com sucesso")
                        Me.carregaDadosGrid()
                        Me.limparCampos()
                    End If
                End If
            Else
                RemeterUsuario("Excluir")
            End If
        Catch ex As Exception
            exibeMensagem(ex.Message)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim strSql As String = "Exec prcUsuarioClausula ' "
        If Me.verificaLogin1.TemPermissao("C") Then
            If Me.txtSNomeUsuario.Text <> "" Then
                strSql = strSql & " and sNomeDeUsuario like  ''%" & Me.txtSNomeUsuario.Text & "%''"
            End If

            If Me.txtSLoginUsuario.Text <> "" Then
                strSql = strSql & " and sLoginUsuario like  ''%" & Me.txtSLoginUsuario.Text & "%''"
            End If

            'If Me.drpCCusto.SelectedValue <> "" Then
            '    strSql = strSql & " and codCCusto = ''" & Me.drpCCusto.SelectedValue & "''"
            'End If
            strSql = strSql & "'"
            Me.dtgUsuarios.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.dtgUsuarios)
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgUsuarios_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgUsuarios.PageIndexChanged
        Me.dtgUsuarios.CurrentPageIndex = e.NewPageIndex
        Me.dtgUsuarios.DataSource = objDataSet
        Me.dtgUsuarios.DataBind()
        Me.dtgUsuarios.SelectedIndex = -1
    End Sub

    Private Sub dtgUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgUsuarios.SelectedIndexChanged
        Me.txtIdUsuario.Text = IIf(Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(1).Text)
        Me.txtSNomeUsuario.Text = IIf(Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(3).Text = "&nbsp;", "", Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(3).Text)
        Me.txtSLoginUsuario.Text = IIf(Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(2).Text = "&nbsp;", "", Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(2).Text)
        'Me.drpCCusto.SelectedValue = IIf(Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(4).Text = "&nbsp;", "", Me.dtgUsuarios.Items(Me.dtgUsuarios.SelectedIndex).Cells(4).Text)
        Dim dtUsuariosC As DataTable = executaQuery("Select status From Usuario Where idUsuario = " & Me.txtIdUsuario.Text)
        If IsDBNull(dtUsuariosC.Rows(0).Item(0)) Then
            Me.rdoStatus.SelectedIndex = -1
        Else
            Me.rdoStatus.SelectedValue = dtUsuariosC.Rows(0).Item(0)
        End If
        'Me.rdoStatus.SelectedValue = IIf(IsDBNull(dtUsuariosC.Rows(0).Item(0)), Me.rdoStatus.SelectedIndex = -1, dtUsuariosC.Rows(0).Item(0))
    End Sub

    Private Sub lnkDesSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkDesSenha.Click
        If Me.verificaLogin1.TemPermissao("D") Then
            Dim dtUsuariosC As DataTable = executaQuery("Select senha From Usuario Where idUsuario = " & Me.txtIdUsuario.Text)
            If IsDBNull(dtUsuariosC.Rows(0).Item(0)) = False Then exibeMensagem(Crypt(dtUsuariosC.Rows(0).Item(0)))
        Else
            RemeterUsuario("Desvendar senha")
        End If
    End Sub
End Class
