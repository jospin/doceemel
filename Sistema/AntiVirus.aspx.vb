Public Class AntiVirus
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
    Protected WithEvents txtCodAntiVirus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeAntiVirus As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgAntiVirus As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rfvAntiVirus As System.Web.UI.WebControls.RequiredFieldValidator
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

    Private Sub limparCampos()
        Me.txtCodAntiVirus.Text = ""
        Me.txtNomeAntiVirus.Text = ""
        Me.dtgAntiVirus.SelectedIndex = -1
    End Sub

    Sub carregaDadosGrid()
        CarregaDataGrid("Exec PrcAntiVirus", Me.dtgAntiVirus)
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
        Me.lblPagina.Text = "Cadastro de Anti-Vírus"
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtAntiVirusI As DataTable
        Dim strSql As String
        Try
            If Me.txtCodAntiVirus.Text = "" Then
                If Me.verificaLogin1.TemPermissao("I") Then
                    strSql = "Exec PriAntiVirus '" & Me.txtNomeAntiVirus.Text & "'"
                    dtAntiVirusI = executaQuery(strSql)
                    If dtAntiVirusI.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtAntiVirusI.Rows(0).Item(0), "'", ""))
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
                    strSql = "Exec PraAntiVirus '" & Me.txtNomeAntiVirus.Text & "', " & Me.txtCodAntiVirus.Text
                    dtAntiVirusI = executaQuery(strSql)
                    If dtAntiVirusI.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtAntiVirusI.Rows(0).Item(0), "'", ""))
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
        Dim dtAntiVirusE As DataTable
        Try
            If Me.verificaLogin1.TemPermissao("E") Then
                If Me.txtCodAntiVirus.Text = "" Then
                    exibeMensagem("Selecione um registro para exclusão")
                    Exit Sub
                Else
                    dtAntiVirusE = executaQuery("Exec PreAntiVirus " & Me.txtCodAntiVirus.Text)
                    If dtAntiVirusE.Rows.Count > 0 Then
                        exibeMensagem(Replace(dtAntiVirusE.Rows(0).Item(0), "'", ""))
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
        Dim strSql As String = "Exec PrcAntiVirusClausula ' "
        If Me.verificaLogin1.TemPermissao("C") Then
            If Me.txtNomeAntiVirus.Text <> "" Then
                strSql = strSql & " and nomeAntiVirus like  ''%" & Me.txtNomeAntiVirus.Text & "%''"
            End If

            strSql = strSql & "'"
            Me.dtgAntiVirus.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.dtgAntiVirus)
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgAntiVirus_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgAntiVirus.PageIndexChanged
        Me.dtgAntiVirus.CurrentPageIndex = e.NewPageIndex
        Me.dtgAntiVirus.DataSource = objDataSet
        Me.dtgAntiVirus.DataBind()
        Me.dtgAntiVirus.SelectedIndex = -1
    End Sub

    Private Sub dtgAntiVirus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAntiVirus.SelectedIndexChanged
        Me.txtCodAntiVirus.Text = IIf(Me.dtgAntiVirus.Items(Me.dtgAntiVirus.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgAntiVirus.Items(Me.dtgAntiVirus.SelectedIndex).Cells(1).Text)
        Me.txtNomeAntiVirus.Text = IIf(Me.dtgAntiVirus.Items(Me.dtgAntiVirus.SelectedIndex).Cells(2).Text = "&nbsp;", "", Me.dtgAntiVirus.Items(Me.dtgAntiVirus.SelectedIndex).Cells(2).Text)
    End Sub
End Class
