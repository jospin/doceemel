Imports System.Data.SqlClient

Public Class CondicaoPagamento
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
    Protected WithEvents btnGravar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents bntPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNomePapel As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumPapel As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgPapeis As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents IdPapel As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
                If Request("item") <> "" Then
                    Me.wucLateral1.selecionarItemLateral = Request("item")
                End If
            End If
            Session("opPapel") = 1
        End If
    End Sub

    Private Sub dtgPapeis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgPapeis.SelectedIndexChanged
        Me.txtNomePapel.Text = IIf(Me.dtgPapeis.Items(Me.dtgPapeis.SelectedIndex).Cells(2).Text = "&nbsp;", "", Me.dtgPapeis.Items(Me.dtgPapeis.SelectedIndex).Cells(2).Text)
        Me.txtNumPapel.Text = IIf(Me.dtgPapeis.Items(Me.dtgPapeis.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgPapeis.Items(Me.dtgPapeis.SelectedIndex).Cells(1).Text)
        Me.IdPapel.Value = IIf(Me.dtgPapeis.Items(Me.dtgPapeis.SelectedIndex).Cells(1).Text = "&nbsp;", "", Me.dtgPapeis.Items(Me.dtgPapeis.SelectedIndex).Cells(1).Text)
        'Session("opPapel") = 2
        Me.txtNumPapel.Enabled = False
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        LimparCampos()
        Me.txtNumPapel.Enabled = True
        'CarregaGrid()
    End Sub
    Private Sub LimparCampos()
        Me.dtgPapeis.SelectedIndex = -1
        Me.txtNomePapel.Text = ""
        Me.txtNumPapel.Text = ""
        Me.IdPapel.Value = ""
    End Sub

    Sub CarregaGrid()
        CarregaDataGrid("exec Dbo.prs_Papeis ''", Me.dtgPapeis)
        Session("objDataSetPapeis") = Nothing
        Session("objDataSetPapeis") = objDataSet
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim cnPrivateConnection As SqlConnection = createConnection()
        If Me.IdPapel.Value = "" Then
            Dim TemPermissao As Boolean = verificaLogin1.TemPermissao(Incluir)
            If TemPermissao = True Then
                cnPrivateConnection.Open()
                strSQL = "pri_Papeis '" & Replace(Trim(Me.txtNomePapel.Text), "'", "''") & "'"
                ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                Try
                    ObjCommand.ExecuteReader()
                    Dim StrMsg = "Inclusão Realizada"
                    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                    cnPrivateConnection.Close()
                    CarregaGrid()
                    LimparCampos()
                Catch ex As Exception
                    cnPrivateConnection.Close()
                    Dim StrMsg = Replace(ex.Message, "'", "")
                    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                End Try
            Else
                RemeterUsuario("Incluir")
            End If
        Else
            Dim TemPermissao As Boolean = verificaLogin1.TemPermissao(Alterar)
            If TemPermissao = True Then
                cnPrivateConnection.Open()
                strSQL = "exec dbo.pra_Papeis " & Me.IdPapel.Value & ", '" & Replace(Trim(Me.txtNomePapel.Text), "'", "''") & "'"
                ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                Try
                    ObjCommand.ExecuteReader()
                    Dim StrMsg = "Alteração Realizada"
                    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                    cnPrivateConnection.Close()
                    Pesquisar()
                Catch ex As Exception
                    cnPrivateConnection.Close()
                    Dim StrMsg = Replace(ex.Message, "'", "")
                    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                End Try
            Else
                RemeterUsuario("Alterar")
            End If
        End If
    End Sub

    Private Sub bntPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntPesquisa.Click
        Pesquisar()
    End Sub


    Private Sub Pesquisar()
        Dim TemPermissao As Boolean = verificaLogin1.TemPermissao(Consultar)
        If TemPermissao = True Then
            Label1.Visible = True
            strSQL = "exec Dbo.prs_Papeis 'where 1 = 1 "
            If Me.txtNomePapel.Text <> "" Then
                strSQL = strSQL & " and sNomePapel like ''%" & Replace(Trim(Me.txtNomePapel.Text), "'", "''") & "%''"
            End If
            strSQL = strSQL & "'"
            Me.dtgPapeis.CurrentPageIndex = 0
            CarregaDataGrid(strSQL, Me.dtgPapeis)
            Session("objDataSetPapeis") = Nothing
            Session("objDataSetPapeis") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub dtgPapeis_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgPapeis.PageIndexChanged
        Me.dtgPapeis.CurrentPageIndex = e.NewPageIndex
        Me.dtgPapeis.DataSource = Session("objDataSetPapeis")
        Me.dtgPapeis.DataBind()
        LimparCampos()
    End Sub

    Private Sub dtgPapeis_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgPapeis.ItemDataBound
        If e.Item.ItemIndex >= 0 Then
            Dim btnauxiliar As ImageButton = e.Item.Cells(2).FindControl("imgExcluir")
            btnauxiliar.Attributes.Add("onclick", "return confirm('Deseja realmente excluir o registro?');")
        End If
    End Sub

    Private Sub dtgPapeis_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgPapeis.DeleteCommand
        Dim cnPrivateConnection As SqlConnection = createConnection()
        Dim TemPermissao As Boolean = verificaLogin1.TemPermissao(Excluir)
        If TemPermissao = True Then
            Dim codigo As String
            codigo = Me.dtgPapeis.Items(e.Item.ItemIndex).Cells(1).Text
            strSQL = "exec dbo.pre_Papeis " & codigo
            cnPrivateConnection.Open()
            ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
            Try
                ObjCommand.ExecuteReader()
                StrMsg = "Exclusão Realizada"
                Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                Session("opPapel") = 1
            Catch ex As Exception
                Dim i As Integer = CType(ex, System.Data.SqlClient.SqlException).Number
                If i = 547 Then
                    Dim StrMsg As String
                    StrMsg = "Impossivel a Exclusão. Este papel está vinculado a outras tarefas no sistema"
                    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                Else
                    Dim StrMsg = Replace(ex.Message, "'", "")
                    Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
                End If

            End Try
            cnPrivateConnection.Close()
            Pesquisar()
        Else
            RemeterUsuario("Excluir")
        End If
    End Sub
    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub
End Class
