Public Class TopForm

    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\Friends.mdb"
    Public DB_Friends As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\Friends.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\Friends.ini"

    '各フォーム
    Private kaihiForm As 収支表会費
    Private kaiMFrom As 会員マスタ

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '管理者パスワードフォーム表示
        Dim passForm As Form = New passwordForm(iniFilePath, 1)
        If passForm.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            Me.Close()
            Return
        End If

        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        Me.WindowState = FormWindowState.Maximized
    End Sub

    ''' <summary>
    ''' 終了メニュー選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 終了ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 収支表会費メニュー選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 会費ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 会費ToolStripMenuItem.Click
        If IsNothing(kaihiForm) OrElse kaihiForm.IsDisposed Then
            kaihiForm = New 収支表会費()
            kaihiForm.Owner = Me
            kaihiForm.Show()
        Else
            kaihiForm.Focus()
        End If
    End Sub

    ''' <summary>
    ''' 会員マスタメニュー選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 会員マスタToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 会員マスタToolStripMenuItem.Click
        If IsNothing(kaiMFrom) OrElse kaiMFrom.IsDisposed Then
            kaiMFrom = New 会員マスタ()
            kaiMFrom.Owner = Me
            kaiMFrom.Show()
        Else
            kaiMFrom.Focus()
        End If
    End Sub
End Class
