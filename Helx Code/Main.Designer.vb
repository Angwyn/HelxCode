<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        NewFileMenuItem = New ToolStripMenuItem()
        OpenFileMenuItem = New ToolStripMenuItem()
        SaveFileMenuItem = New ToolStripMenuItem()
        SaveAsMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        EditToolStripMenuItem = New ToolStripMenuItem()
        UndoToolStripMenuItem = New ToolStripMenuItem()
        RedoToolStripMenuItem = New ToolStripMenuItem()
        CutToolStripMenuItem = New ToolStripMenuItem()
        CopyToolStripMenuItem = New ToolStripMenuItem()
        PasteToolStripMenuItem = New ToolStripMenuItem()
        ExperimentalFeaturesToolStripMenuItem = New ToolStripMenuItem()
        AIToolStripMenuItem = New ToolStripMenuItem()
        ColorHighlightToolStripMenuItem = New ToolStripMenuItem()
        TestToolStripMenuItem = New ToolStripMenuItem()
        RunToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem1 = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        EULAToolStripMenuItem = New ToolStripMenuItem()
        CheckForUpdateToolStripMenuItem = New ToolStripMenuItem()
        ReportBugToolStripMenuItem = New ToolStripMenuItem()
        TabControl1 = New TabControl()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem, ExperimentalFeaturesToolStripMenuItem, TestToolStripMenuItem, HelpToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1055, 33)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewFileMenuItem, OpenFileMenuItem, SaveFileMenuItem, SaveAsMenuItem, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(54, 29)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' NewFileMenuItem
        ' 
        NewFileMenuItem.Name = "NewFileMenuItem"
        NewFileMenuItem.Size = New Size(176, 34)
        NewFileMenuItem.Text = "New"
        ' 
        ' OpenFileMenuItem
        ' 
        OpenFileMenuItem.Name = "OpenFileMenuItem"
        OpenFileMenuItem.Size = New Size(176, 34)
        OpenFileMenuItem.Text = "Open"
        ' 
        ' SaveFileMenuItem
        ' 
        SaveFileMenuItem.Name = "SaveFileMenuItem"
        SaveFileMenuItem.Size = New Size(176, 34)
        SaveFileMenuItem.Text = "Save"
        ' 
        ' SaveAsMenuItem
        ' 
        SaveAsMenuItem.Name = "SaveAsMenuItem"
        SaveAsMenuItem.Size = New Size(176, 34)
        SaveAsMenuItem.Text = "Save As"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(176, 34)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UndoToolStripMenuItem, RedoToolStripMenuItem, CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem})
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New Size(58, 29)
        EditToolStripMenuItem.Text = "Edit"
        ' 
        ' UndoToolStripMenuItem
        ' 
        UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        UndoToolStripMenuItem.Size = New Size(270, 34)
        UndoToolStripMenuItem.Text = "Undo"
        ' 
        ' RedoToolStripMenuItem
        ' 
        RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        RedoToolStripMenuItem.Size = New Size(270, 34)
        RedoToolStripMenuItem.Text = "Redo"
        ' 
        ' CutToolStripMenuItem
        ' 
        CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        CutToolStripMenuItem.Size = New Size(270, 34)
        CutToolStripMenuItem.Text = "Cut"
        ' 
        ' CopyToolStripMenuItem
        ' 
        CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        CopyToolStripMenuItem.Size = New Size(270, 34)
        CopyToolStripMenuItem.Text = "Copy"
        ' 
        ' PasteToolStripMenuItem
        ' 
        PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        PasteToolStripMenuItem.Size = New Size(270, 34)
        PasteToolStripMenuItem.Text = "Paste"
        ' 
        ' ExperimentalFeaturesToolStripMenuItem
        ' 
        ExperimentalFeaturesToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AIToolStripMenuItem, ColorHighlightToolStripMenuItem})
        ExperimentalFeaturesToolStripMenuItem.Name = "ExperimentalFeaturesToolStripMenuItem"
        ExperimentalFeaturesToolStripMenuItem.Size = New Size(200, 29)
        ExperimentalFeaturesToolStripMenuItem.Text = "Experimental Features"
        ' 
        ' AIToolStripMenuItem
        ' 
        AIToolStripMenuItem.Name = "AIToolStripMenuItem"
        AIToolStripMenuItem.Size = New Size(235, 34)
        AIToolStripMenuItem.Text = "AI"
        ' 
        ' ColorHighlightToolStripMenuItem
        ' 
        ColorHighlightToolStripMenuItem.Name = "ColorHighlightToolStripMenuItem"
        ColorHighlightToolStripMenuItem.Size = New Size(235, 34)
        ColorHighlightToolStripMenuItem.Text = "Color Highlight"
        ' 
        ' TestToolStripMenuItem
        ' 
        TestToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RunToolStripMenuItem})
        TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        TestToolStripMenuItem.Size = New Size(58, 29)
        TestToolStripMenuItem.Text = "Test"
        ' 
        ' RunToolStripMenuItem
        ' 
        RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        RunToolStripMenuItem.Size = New Size(145, 34)
        RunToolStripMenuItem.Text = "Run"
        ' 
        ' HelpToolStripMenuItem
        ' 
        HelpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {HelpToolStripMenuItem1, AboutToolStripMenuItem, EULAToolStripMenuItem, CheckForUpdateToolStripMenuItem, ReportBugToolStripMenuItem})
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        HelpToolStripMenuItem.Size = New Size(65, 29)
        HelpToolStripMenuItem.Text = "Help"
        ' 
        ' HelpToolStripMenuItem1
        ' 
        HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        HelpToolStripMenuItem1.Size = New Size(255, 34)
        HelpToolStripMenuItem1.Text = "Help"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(255, 34)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' EULAToolStripMenuItem
        ' 
        EULAToolStripMenuItem.Name = "EULAToolStripMenuItem"
        EULAToolStripMenuItem.Size = New Size(255, 34)
        EULAToolStripMenuItem.Text = "EULA"
        ' 
        ' CheckForUpdateToolStripMenuItem
        ' 
        CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem"
        CheckForUpdateToolStripMenuItem.Size = New Size(255, 34)
        CheckForUpdateToolStripMenuItem.Text = "Check For Update"
        ' 
        ' ReportBugToolStripMenuItem
        ' 
        ReportBugToolStripMenuItem.Name = "ReportBugToolStripMenuItem"
        ReportBugToolStripMenuItem.Size = New Size(255, 34)
        ReportBugToolStripMenuItem.Text = "Report Bug"
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Location = New Point(0, 36)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1055, 650)
        TabControl1.TabIndex = 2
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1055, 683)
        Controls.Add(TabControl1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Main"
        Text = "Form2"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewFileMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsMenuItem As ToolStripMenuItem
    Friend WithEvents ExperimentalFeaturesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EULAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents CheckForUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorHighlightToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportBugToolStripMenuItem As ToolStripMenuItem
End Class
