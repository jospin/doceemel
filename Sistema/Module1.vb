Imports System.Data.SqlClient
Imports System.Data
'Imports System.Web.UI.Page

Public Module Module1
    Public tentativas As Integer = 0
    Public i As Integer
    Public Nivel As Integer
    Public v(255) As String
    Public teste As String
    Public codUser As String
    Public ObjCommand As SqlCommand
    Public objAdapter As SqlDataAdapter
    Public objDataSet As DataSet
    Public strSQL As String
    Public objDataReader As SqlDataReader
    Public objDataTable As DataTable
    Private _strCnn As String
    Private Cnn As SqlConnection
    Public logado As Boolean = False
    Public StrMsg As String
    Public codM As Integer
    Public codOs As Integer
    Public hist As Boolean
    Public codUsuLogado As Integer
    Public novoUser As Boolean
    Public novoVend As Boolean
    Public UsuLog As String

    Public Property strCnn() As String
        Get
            Return _strCnn
        End Get
        Set(ByVal Value As String)
            'do nothing
        End Set
    End Property

    Public Function createConnection() As SqlConnection
        createConnection = New SqlConnection(strCnn)
    End Function

    Sub New()
        _strCnn = ConfigurationSettings.AppSettings("Siscli")
        Cnn = New SqlConnection(_strCnn)
    End Sub

    Public Sub Carrega_Grid(ByVal ssql As String, ByVal dtgrid As DataGrid)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        'Dim objDataRow As DataRow
        Dim conn As SqlConnection = createConnection()
        conn.Open()
        'cria um objeto command e o passa a consulta sql para executar
        objCommand = New SqlCommand(ssql, conn)
        'obtem o dataset
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)
        dtgrid.DataSource = objDataSet
        dtgrid.DataBind()
    End Sub

    Public Sub CarregaCombo(ByVal pCombo As DropDownList, ByVal pSQL As String, ByVal ValorCombo As String, ByVal TextoCombo As String, ByVal Linha As Boolean)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        'Dim objDataRow As DataRow
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()

        ' Cria um objeto Command e o passa a consulta SQL para executar
        objCommand = New SqlCommand(pSQL, cnPrivateConnection)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)
        pCombo.DataTextField = UCase(TextoCombo)
        pCombo.DataValueField = UCase(ValorCombo)

        'Inicio Teste Sort

        objDataSet.Tables(0).DefaultView.Sort = TextoCombo
        pCombo.DataSource = objDataSet.Tables(0).DefaultView()

        'Fim Teste Sort

        ' Vincula o datagrid ao dataset
        'pCombo.DataSource = objDataSet
        pCombo.DataBind()
        If Linha = True Then pCombo.Items.Insert(0, "")
        'objConnection.Close()
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Sub

    Public Sub CarregaComboSort(ByVal pCombo As DropDownList, ByVal pSQL As String, ByVal ValorCombo As String, ByVal TextoCombo As String, ByVal Linha As Boolean, ByVal sort As Boolean)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        'Dim objDataRow As DataRow
        Dim cnPrivateConnection As SqlConnection = createConnection()
        cnPrivateConnection.Open()

        ' Cria um objeto Command e o passa a consulta SQL para executar
        objCommand = New SqlCommand(pSQL, cnPrivateConnection)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)
        pCombo.DataTextField = UCase(TextoCombo)
        pCombo.DataValueField = UCase(ValorCombo)

        'Inicio Teste Sort
        If sort = True Then
            objDataSet.Tables(0).DefaultView.Sort = TextoCombo
        End If
        pCombo.DataSource = objDataSet.Tables(0).DefaultView()

        'Fim Teste Sort

        ' Vincula o datagrid ao dataset
        'pCombo.DataSource = objDataSet
        pCombo.DataBind()
        If Linha = True Then pCombo.Items.Insert(0, "")
        'objConnection.Close()
        cnPrivateConnection.Close()
        cnPrivateConnection = Nothing
    End Sub

    Public Function executaQuery_1(ByVal sSQL As String, ByRef DT As DataTable)
        Try

            Dim cnPrivateConnection As SqlConnection = createConnection()
            cnPrivateConnection.Open()
            Dim cmd As SqlCommand = cnPrivateConnection.CreateCommand
            cmd.CommandText = sSQL
            Dim DA As New SqlDataAdapter
            DA.SelectCommand = cmd
            DA.Fill(DT)
            cnPrivateConnection.Close()
            cnPrivateConnection = Nothing
            Return DT
        Catch ex As Exception
            StrMsg = Replace(ex.Message, "'", "")
            Return StrMsg
        End Try
    End Function

    Public Function executaQuery(ByVal sSQL As String) As DataTable
        Dim DT As New DataTable
        executaQuery_1(sSQL, DT)
        Return DT
    End Function

    'Function criptografar(ByVal texto As String) As String
    '    Dim i As Integer
    '    Dim crip As String = ""
    '    module1.teste = Len(texto)
    '    For i = 1 To module1.teste Step 1
    '        module1.v(i) = Asc(Mid$(texto, i, 1)) + 1
    '        If module1.v(i) = 33 Then
    '            v(i) = 32
    '        End If
    '        If module1.v(i) = 47 Then
    '            v(i) = 46
    '        End If
    '        crip = crip & Chr(module1.v(i))
    '    Next i
    '    Return crip
    'End Function

    'Function decriptografar(ByVal texto As String) As String
    '    Dim i As Integer
    '    Dim decrip As String = ""
    '    module1.teste = Len(texto)
    '    For i = 1 To module1.teste Step 1
    '        module1.v(i) = Asc(Mid$(texto, i, 1)) - 1
    '        If module1.v(i) = 31 Then
    '            v(i) = 32
    '        End If
    '        If module1.v(i) = 45 Then
    '            v(i) = 46
    '        End If
    '        decrip = decrip & Chr(module1.v(i))
    '    Next i
    '    Return decrip
    'End Function

    Function converte_data(ByVal data As String) As String
        Dim dia As Integer
        Dim mes As Integer
        Dim ano As Integer
        'On Error GoTo erro
        If IsDate(data) Then
            dia = Microsoft.VisualBasic.Day(data)
            mes = Microsoft.VisualBasic.Month(data)
            ano = Microsoft.VisualBasic.Year(data)
            Return mes & "/" & dia & "/" & ano
        Else
            Return "0"
        End If
    End Function

    Public Function conv_data(ByVal data As Date) As String
        Dim dia As Integer
        Dim mes As Integer
        Dim ano As Integer

        'dia = Microsoft.VisualBasic.Day(data)
        'mes = Microsoft.VisualBasic.Month(data)
        'ano = Microsoft.VisualBasic.Year(data)

        dia = data.Day
        mes = data.Month
        ano = data.Year

        Return ano & "-" & mes & "-" & dia
    End Function

    Public Function conv_data_hora(ByVal data As Date) As String
        Dim dia As Integer
        Dim mes As Integer
        Dim ano As Integer
        Dim hora As String

        dia = data.Day
        mes = data.Month
        ano = data.Year
        hora = data.Hour & ":" & data.Minute & ":" & data.Second

        conv_data_hora = ano & "-" & mes & "-" & dia & " " & hora
    End Function

    Public Function Crypt(ByVal Text As String) As String

        Dim strTempChar As String

        For i = 1 To Len(Text)

            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) + 128
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) - 128
            End If

            Mid$(Text, i, 1) = Chr(strTempChar)

        Next i

        Crypt = Text
    End Function
End Module

