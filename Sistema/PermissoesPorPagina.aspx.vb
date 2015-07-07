Public Class PermissoesPorPagina
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents verificaLogin1 As verificaLogin
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents dtgGrupos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents drpPaginaDeAcesso As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpGrupo As System.Web.UI.WebControls.DropDownList
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    'Private Sub exibeMensagem(ByVal sMsg As String)
    '    Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
    '    Try
    '        MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub limparCampos()

    'End Sub

    'Sub carregaDadosGrid()
    '    CarregaDataGrid("Exec PrcPapel", Me.dtgGrupos)
    '    Session("objDataSet1") = Nothing
    '    Session("objDataSet1") = objDataSet
    'End Sub

    'Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
    '    If Not IsPostBack Then
    '        If Request("contexto") <> "" Then
    '            Me.wucLateral1.contextoDeSeguranca = Request("contexto")
    '        End If
    '    End If
    '    Me.lblPagina.Text = "Cadastro de Grupos"
    'End Sub

    'Private Sub RemeterUsuario(ByVal tipo As String)
    '    Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
    '    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    'End Sub

    'Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dtGruposI As DataTable
    '    Dim strSql As String
    '    Try
    '        If Me.txtIdPapel.Text = "" Then
    '            If Me.verificaLogin1.TemPermissao("I") Then
    '                strSql = "Exec PriPapel '" & Me.txtSNomePapel.Text & "'"
    '                dtGruposI = executaQuery(strSql)
    '                exibeMensagem("Inclusão efetuada com sucesso")
    '            Else
    '                RemeterUsuario("Incluir")
    '            End If
    '        Else
    '            If Me.verificaLogin1.TemPermissao("A") Then
    '                strSql = "Exec PraPapel '" & Me.txtSNomePapel.Text & "', " & Me.txtIdPapel.Text
    '                dtGruposI = executaQuery(strSql)
    '                exibeMensagem("Alteração efetuada com sucesso")
    '            Else
    '                RemeterUsuario("Alterar")
    '            End If
    '        End If
    '        Me.carregaDadosGrid()
    '        Me.limparCampos()
    '    Catch ex As Exception
    '        exibeMensagem(ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.limparCampos()
    'End Sub

    'Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dtUsuarioE As DataTable
    '    Try
    '        If Me.verificaLogin1.TemPermissao("E") Then
    '            If Me.txtIdPapel.Text = "" Then
    '                exibeMensagem("Selecione um registro para exclusão")
    '                Exit Sub
    '            Else
    '                dtUsuarioE = executaQuery("Exec PrePapel " & Me.txtIdPapel.Text)
    '                exibeMensagem("Exclusão efetuada com sucesso")
    '            End If
    '        Else
    '            RemeterUsuario("Excluir")
    '        End If
    '        Me.carregaDadosGrid()
    '        Me.limparCampos()
    '    Catch ex As Exception
    '        exibeMensagem(ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strSql As String = "Exec PrcPapelClausula ' "
    '    If Me.verificaLogin1.TemPermissao("C") Then
    '        If Me.txtSNomePapel.Text <> "" Then
    '            strSql = strSql & " and sNomePapel like  ''%" & Me.txtSNomePapel.Text & "%''"
    '        End If

    '        strSql = strSql & "'"
    '        Me.dtgGrupos.CurrentPageIndex = 0
    '        CarregaDataGrid(strSql, Me.dtgGrupos)
    '    Else
    '        RemeterUsuario("Consultar")
    '    End If
    'End Sub

    'Private Sub dtgUsuarios_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
    '    Me.dtgGrupos.CurrentPageIndex = e.NewPageIndex
    '    Me.dtgGrupos.DataSource = objDataSet
    '    Me.dtgGrupos.DataBind()
    '    Me.dtgGrupos.SelectedIndex = -1
    'End Sub

    'Private Sub dtgGrupos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txtIdPapel.Text = IIf(Me.dtgGrupos.Items(Me.dtgGrupos.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgGrupos.Items(Me.dtgGrupos.SelectedIndex).Cells(1).Text)
    '    Me.txtSNomePapel.Text = IIf(Me.dtgGrupos.Items(Me.dtgGrupos.SelectedIndex).Cells(2).Text = "&nbsp;", "", Me.dtgGrupos.Items(Me.dtgGrupos.SelectedIndex).Cells(2).Text)
    'End Sub
End Class
