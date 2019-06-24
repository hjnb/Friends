Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class 収支表会費

    '選択データのAutono
    Private selectedAutono As Integer = -1

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.KeyPreview = True
    End Sub

    ''' <summary>
    ''' KeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 収支表会費_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False AndAlso Not dgvKZan.Focused Then
                Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 収支表会費_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '現在日付設定
        dateBox.setADStr(DateTime.Now.ToString("yyyy/MM/dd"))

        'データグリッドビュー初期設定
        initDgvKZan()

        'データ表示
        displayDgvKZan()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvKZan()
        Util.EnableDoubleBuffering(dgvKZan)

        With dgvKZan
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .RowHeadersVisible = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 16
            .RowTemplate.Height = 16
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = True
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            '.Font = New Font("ＭＳ Ｐゴシック", 9)
        End With
    End Sub

    ''' <summary>
    ''' データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvKZan()
        'クリア
        dgvKZan.Columns.Clear()
        clearInput()

        'データ取得、表示
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Friends)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Autono, Ymd, Txt, Nin, [In], Out from KZan order by Autono"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "KZan")
        Dim dt As DataTable = ds.Tables("KZan")

        '残高列追加
        dt.Columns.Add("Zan", GetType(Integer))
        Dim zan As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim inStr As String = row("In")
            Dim outStr As String = row("Out")
            If System.Text.RegularExpressions.Regex.IsMatch(inStr, "^\d+$") Then
                zan += CInt(inStr)
            End If
            If System.Text.RegularExpressions.Regex.IsMatch(outStr, "^\d+$") Then
                zan -= CInt(outStr)
            End If
            row("Zan") = zan
        Next

        '表示
        dgvKZan.DataSource = dt
        If Not IsNothing(dgvKZan.CurrentRow) Then
            dgvKZan.CurrentRow.Selected = False
        End If
        If dgvKZan.Rows.Count > 0 Then '最下段へスクロール
            dgvKZan.FirstDisplayedScrollingRowIndex = dgvKZan.Rows.Count - 1
        End If
        'フォーカス
        dateBox.Focus()

        '幅設定等
        With dgvKZan
            '非表示
            .Columns("Autono").Visible = False

            With .Columns("Ymd")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "日付"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Txt")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "摘要"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 123
            End With
            With .Columns("Nin")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderText = "丁数"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 35
            End With
            With .Columns("In")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .HeaderText = "収入"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Out")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .HeaderText = "支出"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Zan")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .HeaderText = "残高"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With

        End With

    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        '摘要
        txtBox.Text = ""
        '丁数
        ninBox.Text = ""
        '収入
        inBox.Text = ""
        '支出
        outBox.Text = ""

        '選択Autono
        selectedAutono = -1

        '日付は当日に
        dateBox.setADStr(DateTime.Now.ToString("yyyy/MM/dd"))
    End Sub

    ''' <summary>
    ''' CellFormatting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvKZan_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvKZan.CellFormatting
        If e.RowIndex >= 0 Then
            '列名
            Dim columnName As String = dgvKZan.Columns(e.ColumnIndex).Name

            '日付
            If columnName = "Ymd" Then
                e.Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(e.Value))
                e.FormattingApplied = True
            End If

            '丁数
            If columnName = "Nin" OrElse columnName = "In" OrElse columnName = "Out" Then
                If e.Value = 0 Then
                    e.Value = ""
                    e.FormattingApplied = True
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvKZan_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvKZan.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim ymd As String = Util.checkDBNullValue(dgvKZan("Ymd", e.RowIndex).Value)
            Dim txt As String = Util.checkDBNullValue(dgvKZan("Txt", e.RowIndex).Value)
            Dim ninStr As String = Util.checkDBNullValue(dgvKZan("Nin", e.RowIndex).Value)
            Dim inStr As String = Util.checkDBNullValue(dgvKZan("In", e.RowIndex).Value)
            Dim outStr As String = Util.checkDBNullValue(dgvKZan("Out", e.RowIndex).Value)
            selectedAutono = dgvKZan("Autono", e.RowIndex).Value

            '各ボックスへ
            dateBox.setADStr(ymd)
            txtBox.Text = txt
            ninBox.Text = ninStr
            inBox.Text = inStr
            outBox.Text = outStr

            'フォーカス
            dateBox.Focus()
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvKZan_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvKZan.CellPainting
        '行ヘッダーかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                (e.RowIndex + 1).ToString(), _
                e.CellStyle.Font, _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '日付
        Dim ymd As String = dateBox.getADStr()
        '摘要
        Dim txt As String = txtBox.Text
        If txt = "" Then
            MsgBox("摘要を入力して下さい。", MsgBoxStyle.Exclamation)
            txtBox.Focus()
            Return
        End If
        '丁数
        Dim ninStr As String = ninBox.Text
        ninStr = If(ninStr = "", "0", ninStr)
        If Not System.Text.RegularExpressions.Regex.IsMatch(ninStr, "^\d+$") Then
            MsgBox("丁数は数値を入力して下さい。", MsgBoxStyle.Exclamation)
            ninBox.Focus()
            Return
        End If
        '収入
        Dim inStr As String = inBox.Text
        inStr = If(inStr = "", "0", inStr)
        If Not System.Text.RegularExpressions.Regex.IsMatch(inStr, "^\d+$") Then
            MsgBox("収入は数値を入力して下さい。", MsgBoxStyle.Exclamation)
            inBox.Focus()
            Return
        End If
        '支出
        Dim outStr As String = outBox.Text
        outStr = If(outStr = "", "0", outStr)
        If Not System.Text.RegularExpressions.Regex.IsMatch(outStr, "^\d+$") Then
            MsgBox("支出は数値を入力して下さい。", MsgBoxStyle.Exclamation)
            outBox.Focus()
            Return
        End If

        '登録
        Dim addFlg As Boolean = False
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Friends)
        Dim sql As String = "select * from KZan where Autono = " & selectedAutono
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        addFlg = If(rs.RecordCount <= 0, True, False)
        Dim result As DialogResult = MessageBox.Show(If(addFlg, "新規登録", "変更") & "してよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.Yes Then
            If addFlg Then
                rs.AddNew()
            End If
            rs.Fields("Ymd").Value = ymd
            rs.Fields("Txt").Value = txt
            rs.Fields("Nin").Value = CInt(ninStr)
            rs.Fields("In").Value = CInt(inStr)
            rs.Fields("Out").Value = CInt(outStr)
            rs.Update()
            rs.Close()
            cn.Close()

            '再表示
            displayDgvKZan()
        Else
            rs.Close()
            cn.Close()
            Return
        End If
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '行未選択時
        If selectedAutono = -1 Then
            MsgBox("選択されていません。", MsgBoxStyle.Exclamation)
            Return
        End If

        '削除
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Friends)
        Dim sql As String = "select * from KZan where Autono = " & selectedAutono
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("登録されていません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                rs.Delete()
                rs.Update()
                rs.Close()
                cn.Close()

                '再表示
                displayDgvKZan()
            Else
                rs.Close()
                cn.Close()
                Return
            End If
        End If

    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        '件数
        Dim rowsCount As Integer = dgvKZan.Rows.Count

        '最新、最古の日付
        Dim fromYmd As String = ""
        Dim toYmd As String = ""
        If rowsCount >= 1 Then
            fromYmd = Util.checkDBNullValue(dgvKZan("Ymd", 0).FormattedValue)
            toYmd = Util.checkDBNullValue(dgvKZan("Ymd", rowsCount - 1).FormattedValue)
        End If

        '貼り付けデータ作成
        Dim dataList As New List(Of String(,))
        Dim dataArray(49, 5) As String
        Dim arrayRowIndex As Integer = 0
        For i As Integer = 0 To rowsCount - 1
            If arrayRowIndex = 50 Then
                dataList.Add(dataArray.Clone())
                Array.Clear(dataArray, 0, dataArray.Length)
                arrayRowIndex = 0
            End If

            '日付
            dataArray(arrayRowIndex, 0) = Util.checkDBNullValue(dgvKZan("Ymd", i).FormattedValue)
            '摘要
            dataArray(arrayRowIndex, 1) = Util.checkDBNullValue(dgvKZan("Txt", i).Value)
            '丁数
            dataArray(arrayRowIndex, 2) = If(Util.checkDBNullValue(dgvKZan("Nin", i).Value) = 0, "", Util.checkDBNullValue(dgvKZan("Nin", i).Value))
            '収入
            dataArray(arrayRowIndex, 3) = Util.checkDBNullValue(dgvKZan("In", i).FormattedValue)
            '支出
            dataArray(arrayRowIndex, 4) = Util.checkDBNullValue(dgvKZan("Out", i).FormattedValue)
            '残高
            dataArray(arrayRowIndex, 5) = Util.checkDBNullValue(dgvKZan("Zan", i).FormattedValue)

            arrayRowIndex += 1
        Next
        dataList.Add(dataArray.Clone())

        'エクセル
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(TopForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("収支表改")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '区分
        oSheet.Range("B2").Value = "(会費)"
        '期間
        oSheet.Range("D2").Value = fromYmd & " ～ " & toYmd

        '必要枚数コピペ
        For i As Integer = 0 To dataList.Count - 2
            Dim xlPasteRange As Excel.Range = oSheet.Range("A" & (55 + (54 * i))) 'ペースト先
            oSheet.Rows("1:54").copy(xlPasteRange)
            oSheet.HPageBreaks.Add(oSheet.Range("A" & (55 + (54 * i)))) '改ページ
        Next

        'データ貼り付け
        For i As Integer = 0 To dataList.Count - 1
            oSheet.Range("G" & (2 + 54 * i)).Value = (i + 1) & " 頁"
            oSheet.Range("B" & (4 + 54 * i), "G" & (53 + 54 * i)).Value = dataList(i)
        Next

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        Dim state As String = Util.getIniString("System", "Printer", TopForm.iniFilePath)
        If state = "Y" Then
            oSheet.PrintOut()
        ElseIf state = "N" Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing

    End Sub
End Class