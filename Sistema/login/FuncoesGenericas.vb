
Imports System.Data
Imports System.Data.SqlClient
Module FuncoesGenericas
    Public ObjCommand As SqlCommand
    Public objAdapter As SqlDataAdapter
    Public objDataSet As DataSet
    Public strSQL As String
    Public objDataReader As SqlDataReader
    Public objDataTable As DataTable
    Public strCnn As String
    Public Cnn As SqlConnection
    Public StrMsg As String


    Public Function AbrirDB()
        Cnn = New SqlConnection(strCnn)
        Cnn.Open()
    End Function

    Public Function FecharBD()
        Cnn.Close()
    End Function
    Sub New()
        strCnn = ConfigurationSettings.AppSettings("dbPcpArtfix")
    End Sub
    Public Sub CarregaCombo(ByVal pCombo As DropDownList, ByVal pSQL As String, ByVal ValorCombo As String, ByVal TextoCombo As String, ByVal Linha As Boolean)
        Dim objCommand As SqlCommand
        Dim objAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        Dim objDataRow As DataRow
        AbrirDB()
        ' Cria um objeto Command e o passa a consulta SQL para executar
        objCommand = New SqlCommand(pSQL, Cnn)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(objCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)
        pCombo.DataTextField = TextoCombo
        pCombo.DataValueField = ValorCombo

        ' Vincula o datagrid ao dataset
        pCombo.DataSource = objDataSet
        pCombo.DataBind()
        If Linha = True Then pCombo.Items.Insert(0, "")
        'objConnection.Close()
        FecharBD()
    End Sub

    Public Sub CarregaDataGrid(ByVal pStrSql As String, ByVal pDataGrid As DataGrid)
        AbrirDB()
        ' Cria um objeto Command e o passa a consulta SQL para executar
        ObjCommand = New SqlCommand(pStrSql, Cnn)
        ' Obtem um DataSet
        objAdapter = New SqlDataAdapter(ObjCommand)
        objDataSet = New DataSet
        objAdapter.Fill(objDataSet)

        ' Vincula o datagr
        pDataGrid.DataSource = objDataSet
        pDataGrid.DataBind()

        'objConnection.Close()
        FecharBD()
    End Sub
End Module
