Imports System.Data.OleDb

Public Class 会員マスタ

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 会員マスタ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        '位置設定
        Me.Left = DirectCast(Me.Owner, TopForm).Left + 5
        Me.Top = DirectCast(Me.Owner, TopForm).Top + 60

        'データグリッドビュー初期設定
        initDgvM()

        'データ表示
        displayDgvM()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvM()
        Util.EnableDoubleBuffering(dgvM)

        With dgvM
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
            .RowHeadersWidth = 31
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 16
            .RowTemplate.Height = 16
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            '.Font = New Font("ＭＳ Ｐゴシック", 9)
        End With
    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        namBox.Text = ""
    End Sub

    ''' <summary>
    ''' データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvM()
        'クリア
        dgvM.Columns.Clear()
        clearInput()

        'データ取得、表示
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Friends)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Seq, Nam, Bgn from KMst order by Seq"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "KMst")
        Dim dt As DataTable = ds.Tables("KMst")
        dgvM.DataSource = dt
        If Not IsNothing(dgvM.CurrentRow) Then
            dgvM.CurrentRow.Selected = False
        End If

        '幅設定等
        With dgvM
            '非表示
            .Columns("Seq").Visible = False

            With .Columns("Nam")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "会員名"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("Bgn")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "入会日"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 60
            End With
        End With

        'フォーカス
        namBox.Focus()
    End Sub

    ''' <summary>
    ''' セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvM_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvM.CellMouseClick
        If e.RowIndex >= 0 Then
            namBox.Text = Util.checkDBNullValue(dgvM("Nam", e.RowIndex).Value)
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvM_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvM.CellPainting
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
        '氏名
        Dim nam As String = namBox.Text
        If nam = "" Then
            MsgBox("氏名を入力して下さい。", MsgBoxStyle.Exclamation)
            namBox.Focus()
            Return
        End If

        'Seqの最大値取得
        Dim maxSeq As Integer = 0
        Dim rowsCount As Integer = dgvM.Rows.Count
        If rowsCount > 0 Then
            maxSeq = dgvM("Seq", rowsCount - 1).Value
        End If

        '登録
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Friends)
        Dim sql As String = "select * from KMst where Nam = '" & nam & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            MsgBox("既に登録されています。（同姓同名は不可）", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        End If
        rs.AddNew()
        rs.Fields("Seq").Value = maxSeq + 1
        rs.Fields("Nam").Value = nam
        rs.Fields("Bgn").Value = DateTime.Now.ToString("yyyy/MM")
        rs.Update()
        rs.Close()
        cn.Close()

        '再表示
        displayDgvM()
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '氏名
        Dim nam As String = namBox.Text
        If nam = "" Then
            MsgBox("選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        '削除
        Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(TopForm.DB_Friends)
            Dim cmd As New ADODB.Command()
            cmd.ActiveConnection = cnn
            cmd.CommandText = "delete from KMst where Nam = '" & nam & "'"
            cmd.Execute()
            cnn.Close()

            '再表示
            displayDgvM()
        End If
    End Sub

    ''' <summary>
    ''' 氏名ボックスKeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub namBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles namBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnRegist.Focus()
        End If
    End Sub
End Class