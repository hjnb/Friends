Imports System.Data.OleDb

Public Class 収支表会費

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

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
            If e.Control = False Then
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
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .RowHeadersVisible = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 18
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
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

        'データ取得、表示
        'Dim cnn As New ADODB.Connection
        'cnn.Open(TopForm.DB_Friends)
        'Dim rs As New ADODB.Recordset
        'Dim sql As String = "select Cod, Nam, Kana, Diary, Sanato, Nurse, Birth, Sex, Doc, Jyu1, Tel1, KNam, Zok, Jyu2, Tel2, Tel3, KNam2, Zok2, Jyu3, Tel4, Tel5, Com1, Com2 from UsrM order by Kana"
        'rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        'Dim ds As DataSet = New DataSet()
        'da.Fill(ds, rs, "UsrM")
        'Dim dt As DataTable = ds.Tables("UsrM")
        'dgvKZan.DataSource = dt
        'If Not IsNothing(dgvKZan.CurrentRow) Then
        '    dgvKZan.CurrentRow.Selected = False
        'End If

    End Sub

End Class