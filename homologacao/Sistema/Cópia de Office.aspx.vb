Public Class Office
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
    Protected WithEvents hidCodEnd As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodForn As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtCodOffice As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtModeOffice As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgOffice As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rfvModelo As System.Web.UI.WebControls.RequiredFieldValidator
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
        Me.txtCodOffice.Text = ""
        Me.txtModeOffice.Text = ""
        Me.dtgOffice.SelectedIndex = -1
    End Sub

    Sub carregaDadosGrid()
        CarregaDataGrid("Exec PrcOffice", Me.dtgOffice)
        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
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
        End If
        Me.lblPagina.Text = "Cadastro de Modelo de Office"
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtOfficeI As DataTable
        Dim strSql As String
        Try
            If Me.txtCodOffice.Text = "" Then
                If Me.verificaLogin1.TemPermissao("I") Then
                    strSql = "Exec PriOffice '" & Me.txtModeOffice.Text & "'"
                    dtOfficeI = executaQuery(strSql)
                    If dtOfficeI.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtOfficeI.Rows(0).Item(0), "'", ""))
                    Else
                        exibeMensagem("Inclusão efetuada com sucesso")
                        Me.carregaDadosGrid()
                        Me.limparCampos()
                    End If
                Else
                    RemeterUsuario("Incluir")
                End If
            Else
                If Me.verificaLogin1.TemPermissao("A") Then
                    strSql = "Exec PraOffice '" & Me.txtModeOffice.Text & "', " & Me.txtCodOffice.Text
                    dtOfficeI = executaQuery(strSql)
                    If dtOfficeI.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtOfficeI.Rows(0).Item(0), "'", ""))
                    Else
                        exibeMensagem("Alteração efetuada com sucesso")
                        Me.carregaDadosGrid()
                        Me.limparCampos()
                    End If
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
        Dim dtOfficeE As DataTable
        Try
            If Me.verificaLogin1.TemPermissao("E") Then
                If Me.txtCodOffice.Text = "" Then
                    exibeMensagem("Selecione um registro para exclusão")
                    Exit Sub
                Else
                    dtOfficeE = executaQuery("Exec PreOffice " & Me.txtCodOffice.Text)
                    If dtOfficeE.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtOfficeE.Rows(0).Item(0), "'", ""))
                    Else
                        exibeMensagem("Exclusão efetuada com sucesso")
                        Me.carregaDadosGrid()
                        Me.limparCampos()
                    End If
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
        Dim strSql As String = "Exec PrcOfficeClausula ' "
        If Me.verificaLogin1.TemPermissao("C") Then
            If Me.txtModeOffice.Text <> "" Then
                strSql = strSql & " and modeloOffice like  ''%" & Me.txtModeOffice.Text & "%''"
            End If

            strSql = strSql & "'"
            Me.dtgOffice.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.dtgOffice)
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgOffice_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgOffice.PageIndexChanged
        Me.dtgOffice.CurrentPageIndex = e.NewPageIndex
        Me.dtgOffice.DataSource = objDataSet
        Me.dtgOffice.DataBind()
        Me.dtgOffice.SelectedIndex = -1
    End Sub

    Private Sub dtgOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgOffice.SelectedIndexChanged
        Me.txtCodOffice.Text = IIf(Me.dtgOffice.Items(Me.dtgOffice.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgOffice.Items(Me.dtgOffice.SelectedIndex).Cells(1).Text)
        Me.txtModeOffice.Text = IIf(Me.dtgOffice.Items(Me.dtgOffice.SelectedIndex).Cells(2).Text = "&nbsp;", "", Me.dtgOffice.Items(Me.dtgOffice.SelectedIndex).Cells(2).Text)
    End Sub
End Class
