Public Class GruposUsuarios
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucSuperior1 As wucSuperior
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents verificaLogin1 As verificaLogin
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents drpUsuario As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpGrupo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvUsuario As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvGrupo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents dtgGruposUsuarios As System.Web.UI.WebControls.DataGrid
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
        Me.drpGrupo.SelectedIndex = -1
        Me.drpUsuario.SelectedIndex = -1
        Me.dtgGruposUsuarios.SelectedIndex = -1
    End Sub

    Sub carregaDadosGrid()
        CarregaDataGrid("Exec PrcPapelUsuario", Me.dtgGruposUsuarios)
        Session("objDataSet1") = Nothing
        Session("objDataSet1") = objDataSet
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If
            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If
            CarregaCombo(Me.drpGrupo, "Select idPapel, sNomePapel From Papel", "idPapel", "sNomePapel", True)
            CarregaCombo(Me.drpUsuario, "Select idUsuario, sLoginUsuario From Usuario", "idUsuario", "sLoginUsuario", True)
        End If
        Me.lblPagina.Text = "Cadastro de Grupos x Usuários"
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtGruposUsuariosI As DataTable
        Dim strSql As String
        Try
            If Me.verificaLogin1.TemPermissao("I") Then
                strSql = "Exec PriPapelUsuario " & Me.drpGrupo.SelectedValue & ", " & Me.drpUsuario.SelectedValue
                dtGruposUsuariosI = executaQuery(strSql)
                exibeMensagem("Inclusão efetuada com sucesso")
            Else
                RemeterUsuario("Incluir")
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

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim strSql As String = "Exec PrcPapelUsuarioClausula ' "
        If Me.verificaLogin1.TemPermissao("C") Then
            If Me.drpGrupo.SelectedIndex < 0 Then
                strSql = strSql & " and P.idPapel = ''%" & Me.drpGrupo.SelectedValue & "%''"
            End If

            If Me.drpUsuario.SelectedIndex < 0 Then
                strSql = strSql & " and U.idUsuario = ''%" & Me.drpUsuario.SelectedValue & "%''"
            End If
            strSql = strSql & "'"
            Me.dtgGruposUsuarios.CurrentPageIndex = 0
            CarregaDataGrid(strSql, Me.dtgGruposUsuarios)
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgUsuarios_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Me.dtgGruposUsuarios.CurrentPageIndex = e.NewPageIndex
        Me.dtgGruposUsuarios.DataSource = objDataSet
        Me.dtgGruposUsuarios.DataBind()
        Me.dtgGruposUsuarios.SelectedIndex = -1
    End Sub

    Private Sub dtgGruposUsuarios_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgGruposUsuarios.ItemDataBound
        If e.Item.ItemIndex >= 0 Then
            Dim btnauxiliar As ImageButton = e.Item.Cells(3).FindControl("imgExcluir")
            btnauxiliar.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        End If
    End Sub

    Private Sub dtgGruposUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgGruposUsuarios.SelectedIndexChanged
        exibeMensagem(Me.dtgGruposUsuarios.SelectedItem.Cells(4).Text & " " & Me.dtgGruposUsuarios.SelectedItem.Cells(5).Text)
    End Sub

    Private Sub dtgGruposUsuarios_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgGruposUsuarios.DeleteCommand
        Dim dtGruposUsuariosE As DataTable
        Try
            If Me.verificaLogin1.TemPermissao("E") Then
                Dim idPapel As Integer = Me.dtgGruposUsuarios.Items(e.Item.ItemIndex).Cells(4).Text
                Dim idUsuario As Integer = Me.dtgGruposUsuarios.Items(e.Item.ItemIndex).Cells(5).Text
                dtGruposUsuariosE = executaQuery("Exec PrePapelUsuario " & idPapel & ", " & idUsuario)
            Else
                RemeterUsuario("Excluir")
            End If
        Catch ex As Exception
            exibeMensagem(ex.Message)
        End Try
        Me.carregaDadosGrid()
        Me.limparCampos()
    End Sub
End Class
