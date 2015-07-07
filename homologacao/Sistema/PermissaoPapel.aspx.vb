Imports System.Data
Imports System.Data.SqlClient

Public Class PermissaoPapel
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents wucSuperior1 As wucSuperior
    Protected WithEvents wucLateral1 As wucLateral
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.Button
    Protected WithEvents btnGravar As System.Web.UI.WebControls.Button
    Protected WithEvents Label39 As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents dtgPermissoesContexto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents drpPapel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMensagem As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtresposta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtcontrole As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents VerificaLogin1 As verificaLogin
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblPagina As System.Web.UI.WebControls.Label
    Protected WithEvents drpContexto As System.Web.UI.WebControls.DropDownList
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
            CarregaCombo(Me.drpPapel, "Select idPapel, sNomePapel From Papel", "idPapel", "sNomePapel", True)
            CarregaCombo(Me.drpContexto, "Select cdContexto, sNomeContexto From ContextoDeSeguranca", "cdContexto", "sNomeContexto", True)
            'CarregaGrid("-1", "-1")
            If Request("contexto") <> "" Then
                Me.wucLateral1.contextoDeSeguranca = Request("contexto")
                Me.wucSuperior1.limnparUnderlines = Request("contexto")
            End If

            If Request("item") <> "" Then
                Me.wucLateral1.selecionarItemLateral = Request("item")
            End If

        End If

        If txtresposta.Value = "6" Then 'SIM
            Dim TemPermissao As Boolean = VerificaLogin1.TemPermissao(Incluir)
            If TemPermissao = True Then
                Gravar()
                If Me.txtcontrole.Value = "btnLimpar" Then
                    LimparCampos()
                    CarregaGrid("-1", "-1")
                Else
                    If Me.drpContexto.SelectedIndex > 0 And Me.drpPapel.SelectedIndex > 0 Then
                        CarregaGrid(Me.drpContexto.SelectedItem.Value, Me.drpPapel.SelectedItem.Value)
                    Else
                        CarregaGrid("-1", "-1")
                    End If
                End If
            Else
                RemeterUsuario("Incluir/Alterar")
                If Me.drpContexto.SelectedIndex > 0 And Me.drpPapel.SelectedIndex > 0 Then
                    CarregaGrid(Me.drpContexto.SelectedItem.Value, Me.drpPapel.SelectedItem.Value)
                Else
                    CarregaGrid("-1", "-1")
                End If
            End If
            txtresposta.Value = ""
            txtcontrole.Value = ""
        ElseIf Me.txtresposta.Value = "7" Then 'NAO            
            CarregaGrid(Me.drpContexto.SelectedItem.Value, Me.drpPapel.SelectedItem.Value)
            If Me.txtcontrole.Value = "btnLimpar" Then
                LimparCampos()
                CarregaGrid("-1", "-1")
            Else
                If Me.drpContexto.SelectedIndex > 0 And Me.drpPapel.SelectedIndex > 0 Then
                    CarregaGrid(Me.drpContexto.SelectedItem.Value, Me.drpPapel.SelectedItem.Value)
                Else
                    CarregaGrid("-1", "-1")
                End If
            End If
            txtresposta.Value = ""
            txtcontrole.Value = ""
        End If
        Me.lblPagina.Text = "Permissão por Grupo"
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        AtualizarDataSet()
        If Session("ExisteAlteracao") = True Then
            txtMensagem.Value = "Deseja salvar as alterações?"
            txtcontrole.Value = "btnLimpar"
        Else
            LimparCampos()
            CarregaGrid("-1", "-1")
        End If        
    End Sub
    Private Sub LimparCampos()
        Me.drpContexto.SelectedIndex = -1
        Me.drpPapel.SelectedIndex = -1
    End Sub

    Sub CarregaGrid(ByVal cdContexto As String, ByVal idPapel As Integer)
        Dim TemPermissao As Boolean = VerificaLogin1.TemPermissao(Consultar)
        If TemPermissao = True Then
            Label2.Visible = True
            CarregaDataGrid("prs_PermissaoPapel '" & cdContexto & "', " & idPapel & "", dtgPermissoesContexto)
            Session("objDataSetPermissaoPapel") = Nothing
            Session("objDataSetPermissaoPapel") = objDataSet
        Else
            RemeterUsuario("Consultar")
        End If
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        AtualizarDataSet()
        If Session("ExisteAlteracao") = True Then
            txtMensagem.Value = "Deseja salvar as alterações?"
            txtcontrole.Value = "btnGravar"
        End If
    End Sub

    Private Sub drpContexto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AtualizarDataSet()
        If Session("ExisteAlteracao") = True Then
            txtMensagem.Value = "Deseja salvar as alterações?"
            txtcontrole.Value = "drpContexto"
        Else
            If Me.drpContexto.SelectedIndex > 0 And Me.drpPapel.SelectedIndex > 0 Then
                CarregaGrid(Me.drpContexto.SelectedItem.Value, Me.drpPapel.SelectedItem.Value)
            Else
                CarregaGrid("-1", "-1")
            End If
        End If
    End Sub

    Private Sub drpPapel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpPapel.SelectedIndexChanged
        AtualizarDataSet()
        If Session("ExisteAlteracao") = True Then
            txtMensagem.Value = "Deseja salvar as alterações?"
            txtcontrole.Value = "drpPapel"
        Else
            If Me.drpContexto.SelectedIndex > 0 And Me.drpPapel.SelectedIndex > 0 Then
                CarregaGrid(Me.drpContexto.SelectedItem.Value, Me.drpPapel.SelectedItem.Value)
            Else
                CarregaGrid("-1", "-1")
            End If
        End If
    End Sub

    Private Sub dtgPermissoesContexto_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgPermissoesContexto.PageIndexChanged
        AtualizarDataSet()
        Me.dtgPermissoesContexto.CurrentPageIndex = e.NewPageIndex
        Me.dtgPermissoesContexto.DataSource = Session("objDataSetPermissaoPapel")
        Me.dtgPermissoesContexto.DataBind()
    End Sub

    Sub AtualizarDataSet()
        Dim valor As String
        Dim objDataSetAuxiliar As DataSet
        Dim ExisteAlteracao As Boolean
        objDataSetAuxiliar = New DataSet
        objDataSetAuxiliar = Session("objDataSetPermissaoPapel")

        Dim valor_original As Integer
        ExisteAlteracao = False
        Dim x As Integer = 0
        Do While x < Me.dtgPermissoesContexto.Items.Count
            Dim idat = 0
            Do While idat < objDataSetAuxiliar.Tables(0).Rows.Count
                If (objDataSetAuxiliar.Tables(0).Rows(idat).Item(0) = Me.dtgPermissoesContexto.Items(x).Cells(0).Text) And (objDataSetAuxiliar.Tables(0).Rows(idat).Item(1) = Me.dtgPermissoesContexto.Items(x).Cells(1).Text) And (objDataSetAuxiliar.Tables(0).Rows(idat).Item(2) = Me.dtgPermissoesContexto.Items(x).Cells(2).Text) Then
                    Dim TipoPermissao As New RadioButtonList
                    TipoPermissao = Me.dtgPermissoesContexto.Items(x).Cells(7).FindControl("RbPermissao")
                    If TipoPermissao.Items(0).Selected = True Then
                        valor = 0
                    Else
                        valor = 1
                    End If

                    valor_original = Me.dtgPermissoesContexto.Items(x).Cells(5).Text
                    If valor <> valor_original Then
                        objDataSetAuxiliar.Tables(0).Rows(idat).Item(7) = 1
                        objDataSetAuxiliar.Tables(0).Rows(idat).Item(4) = valor
                        ExisteAlteracao = True
                    End If
                End If
                idat = idat + 1
            Loop
            x = x + 1
        Loop
        Session("objDataSetPermissaoPapel") = Nothing
        Session("objDataSetPermissaoPapel") = objDataSetAuxiliar
        Session("ExisteAlteracao") = Nothing
        Session("ExisteAlteracao") = ExisteAlteracao
    End Sub

    Sub Gravar()
        Dim cnPrivateConnection As SqlConnection = createConnection()
        Dim objDataSetAuxiliar As New DataSet
        objDataSetAuxiliar = Session("objDataSetPermissaoPapel")
        Dim i As Integer = objDataSetAuxiliar.Tables(0).Rows.Count ' dtgNaturezaOperacao.Items.Count
        Dim j As Integer
        'Dim TipoNota As RadioButtonList
        Dim cdContexto As String
        Dim cdPermissao As String
        Dim idPapel As Integer
        Dim TipoPermissao As String

        For j = 1 To i
            If objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(7) = 1 Then
                TipoPermissao = objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(4)  'Me.dtgNaturezaOperacao.Items(j - 1).Cells(4).FindControl("RbCdTipoNF")

                cdContexto = objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(0)
                cdPermissao = objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(1)
                idPapel = objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(2)


                If (objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(6) = "I") And (TipoPermissao = 0) Then
                    cnPrivateConnection.Open()
                    strSQL = "exec pri_PermissaoPapel '" & cdContexto & "', '" & cdPermissao & "', " & idPapel
                    ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                    ObjCommand.ExecuteNonQuery()
                    cnPrivateConnection.Close()
                End If

                If (objDataSetAuxiliar.Tables(0).Rows(j - 1).Item(6) = "A") And (TipoPermissao = 1) Then
                    cnPrivateConnection.Open()
                    strSQL = "exec pre_PermissaoPapel '" & cdContexto & "', '" & cdPermissao & "', " & idPapel
                    ObjCommand = New SqlCommand(strSQL, cnPrivateConnection)
                    ObjCommand.ExecuteNonQuery()
                    cnPrivateConnection.Close()
                End If
            End If
        Next
    End Sub

    Private Sub RemeterUsuario(ByVal tipo As String)
        Dim StrMsg = "Usuário sem Permissão para " & tipo & " neste Módulo"
        Response.Write("<script languague=javascript>alert('" & StrMsg & "')</script>")
    End Sub

    Private Sub dtgPermissoesContexto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgPermissoesContexto.SelectedIndexChanged

    End Sub
End Class
