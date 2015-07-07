Public Class MenuPadrao
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents rdoSuperior As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblSuperior As System.Web.UI.WebControls.Label
    Protected WithEvents rdoLateral As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image

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
            Me.rdoSuperior.SelectedIndex = -1
            Me.rdoSuperior.Items.Add("Sistema")
            Me.rdoSuperior.Items.Add("Cadastros")
            Me.rdoSuperior.Items.Add("Vendas")
            Me.rdoSuperior.Items.Add("Estoque")
            Me.rdoSuperior.Items.Add("Relat�rios")
        End If
    End Sub

    Private Sub rdoSuperior_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSuperior.SelectedIndexChanged
        If Session("logado") = False Then
            Response.Redirect("inicial.aspx")
            Exit Sub
        End If
        Session("menuClicado") = Me.rdoSuperior.SelectedValue
        Select Case Session("menuClicado")
            Case Is = "Sistema"
                Me.rdoLateral.Items.Clear()
                Me.rdoLateral.Items.Add("P�gina Inicial")
                Me.rdoLateral.Items.Add("Logout")
            Case Is = "Cadastros"
                Me.rdoLateral.Items.Clear()
                Me.rdoLateral.Items.Add("Vendedores")
                Me.rdoLateral.Items.Add("Usu�rios")
                Me.rdoLateral.Items.Add("Categoria de Clientes")
                Me.rdoLateral.Items.Add("Materiais em Comodato")
                Me.rdoLateral.Items.Add("Tipo de Contato")
                Me.rdoLateral.Items.Add("Clientes")
                Me.rdoLateral.Items.Add("Categoria de Produto")
                Me.rdoLateral.Items.Add("Produtos")
                Me.rdoLateral.Items.Add("Tipos de Telefones")
            Case Is = "Vendas"
                Me.rdoLateral.Items.Clear()
                Me.rdoLateral.Items.Add("Pedidos")
                'Me.rdoLateral.Items.Add("Or�amentos")
                'Me.rdoLateral.Items.Add("Faturamento")
            Case Is = "Relat�rios"
                Me.rdoLateral.Items.Clear()
                Response.Redirect("Relatorios.aspx?")
        End Select
    End Sub

    Private Sub rdoLateral_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLateral.SelectedIndexChanged
        If Session("logado") = False Then
            Response.Redirect("inicial.aspx")
            Exit Sub
        End If
        Select Case Me.rdoLateral.SelectedValue
            Case Is = "Logout"
                Response.Redirect("inicial.aspx?")
                Session("logado") = False
            Case Is = "P�gina Inicial"
                Response.Redirect("Main.aspx?")
            Case Is = "Vendedores"
                If Session("nivel") = 1 Then
                    Response.Redirect("Vendedores.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Usu�rios"
                If Session("nivel") = 1 Then
                    Response.Redirect("Usuarios.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If

            Case Is = "Categoria de Clientes"
                If Session("nivel") = 1 Then
                    Response.Redirect("CatCliente.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Materiais em Comodato"
                If Session("nivel") = 1 Then
                    Response.Redirect("MatComodato.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Tipo de Contato"
                If Session("nivel") = 1 Then
                    Response.Redirect("TipoDeContato.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Clientes"
                Response.Redirect("Clientes.aspx?")
            Case Is = "Categoria de Produto"
                If Session("nivel") = 1 Then
                    Response.Redirect("CatProduto.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If

            Case Is = "Produtos"
                If Session("nivel") = 1 Then
                    Response.Redirect("Produtos.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If

            Case Is = "Pedidos"
                Response.Redirect("Pedidos.aspx?")

            Case Is = "Periodos"
                If Session("nivel") = 0 Then
                    Response.Redirect("Periodos.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Metas"
                If Session("nivel") = 0 Then
                    Response.Redirect("Metas.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Log Acesso"
                If Session("nivel") = 0 Then
                    Response.Redirect("LogAcesso.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
            Case Is = "Tipos de Telefones"
                If Session("nivel") = 1 Then
                    Response.Redirect("TelClientes.aspx?")
                Else
                    exibeMensagem("Usu�rio sem permiss�o para acesso")
                End If
        End Select
        Me.rdoLateral.SelectedIndex = -1
    End Sub

    Private Sub exibeMensagem(ByVal sMsg As String)
        Dim barraInicio As String = "</"
        Dim scr As String = "script"
        Dim barraFim As String = ">"
        Dim sScriptCode As String = "<script>alert('" & sMsg & "');" & barraInicio & scr & barraFim
        Try
            MyBase.Page.RegisterStartupScript(Guid.NewGuid().ToString(), sScriptCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
