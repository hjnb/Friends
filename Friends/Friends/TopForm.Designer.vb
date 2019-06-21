<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
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
        Me.menuItem = New System.Windows.Forms.MenuStrip()
        Me.収支表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.会費ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.積立金ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuItem
        '
        Me.menuItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.収支表ToolStripMenuItem, Me.終了ToolStripMenuItem})
        Me.menuItem.Location = New System.Drawing.Point(0, 0)
        Me.menuItem.Name = "menuItem"
        Me.menuItem.Size = New System.Drawing.Size(691, 24)
        Me.menuItem.TabIndex = 0
        Me.menuItem.Text = "MenuStrip1"
        '
        '収支表ToolStripMenuItem
        '
        Me.収支表ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.積立金ToolStripMenuItem, Me.会費ToolStripMenuItem})
        Me.収支表ToolStripMenuItem.Name = "収支表ToolStripMenuItem"
        Me.収支表ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.収支表ToolStripMenuItem.Text = "収支表"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '会費ToolStripMenuItem
        '
        Me.会費ToolStripMenuItem.Name = "会費ToolStripMenuItem"
        Me.会費ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.会費ToolStripMenuItem.Text = "会費"
        '
        '積立金ToolStripMenuItem
        '
        Me.積立金ToolStripMenuItem.Name = "積立金ToolStripMenuItem"
        Me.積立金ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.積立金ToolStripMenuItem.Text = "積立金"
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(691, 596)
        Me.Controls.Add(Me.menuItem)
        Me.MainMenuStrip = Me.menuItem
        Me.Name = "TopForm"
        Me.Text = "互助会"
        Me.menuItem.ResumeLayout(False)
        Me.menuItem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuItem As System.Windows.Forms.MenuStrip
    Friend WithEvents 収支表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 終了ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 会費ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 積立金ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
