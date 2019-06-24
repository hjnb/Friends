<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 収支表会費
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dateBox = New ymdBox.ymdBox()
        Me.txtBox = New System.Windows.Forms.TextBox()
        Me.ninBox = New System.Windows.Forms.TextBox()
        Me.inBox = New System.Windows.Forms.TextBox()
        Me.outBox = New System.Windows.Forms.TextBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvKZan = New System.Windows.Forms.DataGridView()
        CType(Me.dgvKZan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dateBox
        '
        Me.dateBox.boxType = 1
        Me.dateBox.DateText = ""
        Me.dateBox.EraLabelText = "R01"
        Me.dateBox.EraText = ""
        Me.dateBox.Location = New System.Drawing.Point(18, 21)
        Me.dateBox.MonthLabelText = "06"
        Me.dateBox.MonthText = ""
        Me.dateBox.Name = "dateBox"
        Me.dateBox.Size = New System.Drawing.Size(112, 30)
        Me.dateBox.TabIndex = 0
        Me.dateBox.textReadOnly = False
        '
        'txtBox
        '
        Me.txtBox.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBox.Location = New System.Drawing.Point(55, 72)
        Me.txtBox.Name = "txtBox"
        Me.txtBox.Size = New System.Drawing.Size(174, 21)
        Me.txtBox.TabIndex = 1
        '
        'ninBox
        '
        Me.ninBox.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ninBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ninBox.Location = New System.Drawing.Point(272, 72)
        Me.ninBox.Name = "ninBox"
        Me.ninBox.Size = New System.Drawing.Size(34, 21)
        Me.ninBox.TabIndex = 2
        Me.ninBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'inBox
        '
        Me.inBox.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.inBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.inBox.Location = New System.Drawing.Point(352, 72)
        Me.inBox.Name = "inBox"
        Me.inBox.Size = New System.Drawing.Size(71, 21)
        Me.inBox.TabIndex = 3
        Me.inBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'outBox
        '
        Me.outBox.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.outBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.outBox.Location = New System.Drawing.Point(466, 72)
        Me.outBox.Name = "outBox"
        Me.outBox.Size = New System.Drawing.Size(71, 21)
        Me.outBox.TabIndex = 4
        Me.outBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(310, 113)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(66, 30)
        Me.btnRegist.TabIndex = 5
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(375, 113)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 30)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(440, 113)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(66, 30)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "摘要"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "丁数"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(317, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "収入"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(432, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "支出"
        '
        'dgvKZan
        '
        Me.dgvKZan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKZan.Location = New System.Drawing.Point(19, 156)
        Me.dgvKZan.Name = "dgvKZan"
        Me.dgvKZan.RowTemplate.Height = 21
        Me.dgvKZan.Size = New System.Drawing.Size(518, 242)
        Me.dgvKZan.TabIndex = 12
        '
        '収支表会費
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 411)
        Me.Controls.Add(Me.dgvKZan)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.outBox)
        Me.Controls.Add(Me.inBox)
        Me.Controls.Add(Me.ninBox)
        Me.Controls.Add(Me.txtBox)
        Me.Controls.Add(Me.dateBox)
        Me.Name = "収支表会費"
        Me.Text = "収支表(会費)"
        CType(Me.dgvKZan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dateBox As ymdBox.ymdBox
    Friend WithEvents txtBox As System.Windows.Forms.TextBox
    Friend WithEvents ninBox As System.Windows.Forms.TextBox
    Friend WithEvents inBox As System.Windows.Forms.TextBox
    Friend WithEvents outBox As System.Windows.Forms.TextBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvKZan As System.Windows.Forms.DataGridView
End Class
