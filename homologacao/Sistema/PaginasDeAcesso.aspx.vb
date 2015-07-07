Public Class PaginasDeAcesso
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucSuperior1 As wucSuperior
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents verificaLogin1 As verificaLogin
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents rfvNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCdContexto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSNomeContexto As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvCodigo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents dtgPaginasDeAcesso As System.Web.UI.WebControls.DataGrid
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected novo As Boolean

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
        Me.txtCdContexto.Text = ""
        Me.txtSNomeContexto.Text = ""
        Me.txtCdContexto.Enabled = True
        Me.dtgPaginasDeAcesso.SelectedIndex = -1
        Me.novo = True
    End Sub

    Sub carregaDadosGrid()
        CarregaDataGrid("Exec PrcContextoDeSeguranca", Me.dtgPaginasDeAcesso)
        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnExcluir.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If

            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If
        End If
        Me.lblPagina.Text = "Páginas de Acesso"
        Me.novo = True
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtPaginasDeAcessoI As DataTable
        Dim strSql As String
        Dim strSql1 As String
        Dim i As Integer = 0
        Try
            If Me.novo Then
                If Me.verificaLogin1.TemPermissao("I") Then
                    strSql = "Exec PriContextoDeSeguranca '" & Me.txtCdContexto.Text & "', '" & Me.txtSNomeContexto.Text & "'"
                    dtPaginasDeAcessoI = executaQuery(strSql)
                    Dim tipoPermissao(3) As String
                    tipoPermissao(0) = "A"
                    tipoPermissao(1) = "E"
                    tipoPermissao(2) = "C"
                    tipoPermissao(3) = "I"
                    Dim nomePermissao(3) As String
                    nomePermissao(0) = "Alterar"
                    nomePermissao(1) = "Excluir"
                    nomePermissao(2) = "Consultar"
                    nomePermissao(3) = "Inserir"
                    For i = 0 To 3 Step 1
                        strSql1 = "Exec PriPermissoesDoContexto '" & tipoPermissao(i) & "', '" & Me.txtCdContexto.Text & "', '" & nomePermissao(i) & "'"
                        Dim dtPermissoesDoContexto As DataTable = executaQuery(strSql1)
                    Next i

                    Dim dtPermissoesContexto As DataTable '= 'executaQuery()
                    exibeMensagem("Inclusão efetuada com sucesso")
                Else
                    RemeterUsuario("Incluir")
                End If
            Else
                If Me.verificaLogin1.TemPermissao("A") Then
                    strSql = "Exec PraContextoDeSeguranca '" & Me.txtSNomeContexto.Text & "', '" & Me.txtCdContexto.Text & "'"
                    dtPaginasDeAcessoI = executaQuery(strSql)
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
        Dim dtPaginasDeAcessoE As DataTable
        Try
            If Me.verificaLogin1.TemPermissao("E") Then
                If Me.txtCdContexto.Text = "" Then
                    exibeMensagem("Selecione um registro para exclusão")
                    Exit Sub
                Else
                    dtPaginasDeAcessoE = executaQuery("Exec PreContextoDeSeguranca " & Me.txtCdContexto.Text)
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
        Dim strSql As String = "Exec PrcContextoDeSegurancaClausula ' "
        If Me.verificaLogin1.TemPermissao("C") Then
            If Me.txtSNomeContexto.Text <> "" Then
                strSql = strSql & " and sNomePapel like  ''%" & Me.txtSNomeContexto.Text & "%''"
            End If

            strSql = strSql & "'"
            Me.dtgPaginasDeAcesso.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.dtgPaginasDeAcesso)
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgPaginasDeAcesso_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgPaginasDeAcesso.SelectedIndexChanged
        Me.txtCdContexto.Text = IIf(Me.dtgPaginasDeAcesso.Items(Me.dtgPaginasDeAcesso.SelectedIndex).Cells(2).Text = "&nbsp;", "", Me.dtgPaginasDeAcesso.Items(Me.dtgPaginasDeAcesso.SelectedIndex).Cells(2).Text)
        Me.txtSNomeContexto.Text = IIf(Me.dtgPaginasDeAcesso.Items(Me.dtgPaginasDeAcesso.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgPaginasDeAcesso.Items(Me.dtgPaginasDeAcesso.SelectedIndex).Cells(1).Text)
        Me.txtCdContexto.Enabled = False
        Me.novo = False
    End Sub

    Private Sub dtgPaginasDeAcesso_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgPaginasDeAcesso.PageIndexChanged
        Me.dtgPaginasDeAcesso.CurrentPageIndex = e.NewPageIndex
        Me.dtgPaginasDeAcesso.DataSource = objDataSet
        Me.dtgPaginasDeAcesso.DataBind()
        Me.dtgPaginasDeAcesso.SelectedIndex = -1
    End Sub
End Class
