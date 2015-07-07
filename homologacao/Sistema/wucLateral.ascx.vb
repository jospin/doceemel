Public Class wucLateral
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtContextoDeSeguranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected WithEvents wucLateral1 As wucLateral
    Public Property contextoDeSeguranca() As String
        Get
            Return Me.txtContextoDeSeguranca.Text
        End Get
        Set(ByVal Value As String)
            Me.txtContextoDeSeguranca.Text = Value
            strSQL = "select codSubMenu, nomeSubMenu, pagina, codMenuSup From SubMenu Where codMenuSup = " & Value & " Order by nomeSubMenu"
            CarregaDataGrid(strSQL, Me.DataGrid1)
            'txtPermissao.Text = ObtemPermissoes(Me.txtContextoDeSeguranca.Text, Session("usuario")).ToString
        End Set
    End Property

    Public Property selecionarItemLateral() As String
        Get

        End Get
        Set(ByVal Value As String)
            Try
                Me.DataGrid1.SelectedIndex = Value
                Me.DataGrid1.Items(Value).Font.Underline = True
            Catch ex As Exception

            End Try
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CarregaDataGrid("Select nomeSubMenu From SubMenu Where codMenuSup = ", Me.DataGrid1)

    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim pagina As String = Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(2).Text
        Response.Redirect(pagina & "?contexto=" & Me.DataGrid1.Items(Me.DataGrid1.SelectedIndex).Cells(3).Text & "&item=" & Me.DataGrid1.SelectedIndex)
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim barraInicio As String = "</"
        Dim scr As String = "script"
        Dim barraFim As String = ">"
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
