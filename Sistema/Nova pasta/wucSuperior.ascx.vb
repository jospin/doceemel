Public Class wucSuperior
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents wucLateral As System.Web.UI.UserControl = wucLateral
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lnkSeguranca As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkMovimentos As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkRelatorios As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkCadastros As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkSistema As System.Web.UI.WebControls.LinkButton
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Property limnparUnderlines() As String
        Get

        End Get
        Set(ByVal Value As String)
            Me.limparUnderlines()
            Me.grifar(Value)
            '            txtPermissao.Text = ObtemPermissoes(Me.txtContextoDeSeguranca.Text, Session("usuario")).ToString
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSql As String = "Select sNomeDeUsuario From Usuario Where sLoginUsuario = '" & LCase(Session("usuario")) & "'"
        Dim dtUsu As DataTable = executaQuery(strSql)
        If dtUsu.Rows.Count <> 0 Then
            Me.Label1.Text = dtUsu.Rows(0).Item(0)
        End If
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');</script>"
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub limparUnderlines()
        Me.lnkSistema.Font.Bold = False
        Me.lnkCadastros.Font.Bold = False
        Me.lnkRelatorios.Font.Bold = False
        Me.lnkMovimentos.Font.Bold = False
        Me.lnkSeguranca.Font.Bold = False
    End Sub

    Private Sub lnkSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSistema.Click
        Response.Redirect("inicial.aspx?contexto=1")

    End Sub

    Private Sub lnkCadastros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCadastros.Click
        Response.Redirect("inicial.aspx?contexto=2")

    End Sub

    Private Sub lnkMovimentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkMovimentos.Click
        Response.Redirect("inicial.aspx?contexto=3")

    End Sub

    Private Sub lnkSeguranca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSeguranca.Click
        Response.Redirect("inicial.aspx?contexto=4")

    End Sub

    Private Sub grifar(ByVal contexto As String)
        Select Case contexto
            Case Is = 1
                Me.lnkSistema.Font.Bold = True
            Case Is = 2
                Me.lnkCadastros.Font.Bold = True
            Case Is = 3
                Me.lnkMovimentos.Font.Bold = True
            Case Is = 4
                Me.lnkSeguranca.Font.Bold = True
            Case Else

        End Select
    End Sub
End Class
