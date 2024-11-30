Imports System.IO
Imports System.Text.RegularExpressions

Public Class Main
    Private currentFilePaths As New Dictionary(Of TabPage, String)


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Helx Code Editor"
        Dim defaultTab = CreateNewTab()
        TabControl1.TabPages.Add(defaultTab)

        Dim contextMenu As New ContextMenuStrip()
        Dim closeTabItem As New ToolStripMenuItem("Close Tab", Nothing, AddressOf CloseTab)
        contextMenu.Items.Add(closeTabItem)
        TabControl1.ContextMenuStrip = contextMenu

        ' Add keyboard shortcuts
        NewFileMenuItem.ShortcutKeys = Keys.Control Or Keys.N
        OpenFileMenuItem.ShortcutKeys = Keys.Control Or Keys.O
        SaveFileMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        SaveAsMenuItem.ShortcutKeys = Keys.Control Or Keys.Shift Or Keys.S
        UndoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Z
        RedoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Y
        CutToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.X
        CopyToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.C
        PasteToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.V
    End Sub

    ' Undo action
    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        UndoAction()
    End Sub

    ' Redo action
    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        RedoAction()
    End Sub

    ' Cut text
    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        CutText()
    End Sub

    ' Copy text
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        CopyText()
    End Sub

    ' Paste text
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        PasteText()
    End Sub



    Private Sub UndoAction()
        Dim editorBox = GetCurrentEditorBox()
        If editorBox IsNot Nothing AndAlso editorBox.CanUndo Then
            editorBox.Undo()
        End If
    End Sub

    ' Redo action
    Private Sub RedoAction()
        Dim editorBox = GetCurrentEditorBox()
        If editorBox IsNot Nothing AndAlso editorBox.CanRedo Then
            editorBox.Redo()
        End If
    End Sub

    ' Cut text
    Private Sub CutText()
        Dim editorBox = GetCurrentEditorBox()
        If editorBox IsNot Nothing Then
            editorBox.Cut()
        End If
    End Sub

    ' Copy text
    Private Sub CopyText()
        Dim editorBox = GetCurrentEditorBox()
        If editorBox IsNot Nothing Then
            editorBox.Copy()
        End If
    End Sub

    ' Paste text
    Private Sub PasteText()
        Dim editorBox = GetCurrentEditorBox()
        If editorBox IsNot Nothing Then
            editorBox.Paste()
        End If
    End Sub

    ' New file
    Private Sub NewMenuItem_Click(sender As Object, e As EventArgs) Handles NewFileMenuItem.Click
        Dim newTab = CreateNewTab()
        TabControl1.TabPages.Add(newTab)
        TabControl1.SelectedTab = newTab
        UpdateFormTitle()
    End Sub

    Private Sub TabControl1_Close(sender As Object, e As EventArgs)
        Dim selectedTab = TabControl1.SelectedTab
        If selectedTab IsNot Nothing Then
            If selectedTab.Text.EndsWith("*") Then
                Dim result As DialogResult = MessageBox.Show("You have unsaved changes. Do you want to close this tab?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.No Then Return
            End If

            TabControl1.TabPages.Remove(selectedTab)
        End If
    End Sub

    Private Sub TabControl1_TabPagesRemoved(sender As Object, e As EventArgs) Handles TabControl1.ControlRemoved
        If TabControl1.TabPages.Count = 0 Then
            TabControl1.TabPages.Add(CreateNewTab("Untitled"))
        End If
    End Sub

    Private Function CreateNewTab(Optional title As String = "Untitled") As TabPage
        Dim tabPage As New TabPage(title)
        Dim editorBox As New RichTextBox With {
        .Dock = DockStyle.Fill,
        .Font = New Font("Courier New", 10),
        .Name = "PythonEditorBox",
        .AcceptsTab = True
    }

        AddHandler editorBox.TextChanged, AddressOf PythonEditorBox_TextChanged
        AddHandler editorBox.KeyPress, AddressOf PythonEditorBox_KeyPress
        tabPage.Controls.Add(editorBox)
        currentFilePaths(tabPage) = String.Empty

        Return tabPage
    End Function

    Private Sub PythonEditorBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim editorBox = CType(sender, RichTextBox)
        Dim closingChar As String = String.Empty
        Dim openingChar As Char = e.KeyChar

        Select Case e.KeyChar
            Case """"c
                closingChar = """"
            Case "'"c
                closingChar = "'"
            Case "("c
                closingChar = ")"
            Case "{"c
                closingChar = "}"
            Case "["c
                closingChar = "]"
        End Select

        If Not String.IsNullOrEmpty(closingChar) Then
            Dim currentPos As Integer = editorBox.SelectionStart

            If e.KeyChar = """"c OrElse e.KeyChar = "'"c Then
                If currentPos > 0 AndAlso (editorBox.Text(currentPos - 1) = "("c OrElse editorBox.Text(currentPos - 1) = "["c OrElse editorBox.Text(currentPos - 1) = "{"c) Then
                    editorBox.Text = editorBox.Text.Insert(currentPos, openingChar & closingChar)
                    editorBox.SelectionStart = currentPos + 1
                    e.Handled = True
                    Return
                End If

                If currentPos < editorBox.Text.Length AndAlso editorBox.Text(currentPos) = closingChar Then
                    editorBox.SelectionStart += 1
                    e.Handled = True
                    Return
                End If
            End If

            If e.KeyChar = "("c OrElse e.KeyChar = "{"c OrElse e.KeyChar = "["c Then
                editorBox.Text = editorBox.Text.Insert(currentPos, openingChar & closingChar)
                editorBox.SelectionStart = currentPos + 1
                e.Handled = True
                Return
            End If
        End If
    End Sub




    Private Sub CloseTab(sender As Object, e As EventArgs)
        Dim selectedTab = TabControl1.SelectedTab
        If selectedTab IsNot Nothing Then
            If selectedTab.Text.EndsWith("*") Then
                Dim result As DialogResult = MessageBox.Show($"Tab '{selectedTab.Text.TrimEnd("*"c)}' has unsaved changes. Do you want to close it?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then Return
                If result = DialogResult.No Then TabControl1.TabPages.Remove(selectedTab) : Return
            End If
            TabControl1.TabPages.Remove(selectedTab)
        End If
    End Sub

    Private Function GetCurrentEditorBox() As RichTextBox
        If TabControl1.SelectedTab Is Nothing Then Return Nothing
        Return CType(TabControl1.SelectedTab.Controls(0), RichTextBox)
    End Function
    Private Sub PythonEditorBox_TextChanged(sender As Object, e As EventArgs)
        Dim editorBox = CType(sender, RichTextBox)
        Dim currentPos As Integer = editorBox.SelectionStart
        Dim currentLength As Integer = editorBox.SelectionLength

        editorBox.SuspendLayout()
        HighlightPythonSyntax(editorBox)
        editorBox.SelectionStart = currentPos
        editorBox.SelectionLength = currentLength
        editorBox.ResumeLayout()

        Dim currentTab = TabControl1.SelectedTab
        If currentTab IsNot Nothing AndAlso Not currentTab.Text.EndsWith("*") Then
            currentTab.Text &= "*"
        End If
    End Sub

    Private Sub HighlightPythonSyntax(editorBox As RichTextBox)
        Dim text As String = editorBox.Text

        editorBox.SelectAll()
        editorBox.SelectionColor = Color.Black
        editorBox.DeselectAll()

        Dim keywords As String() = {
        "and", "as", "assert", "break", "class", "continue", "def", "del", "elif", "else",
        "except", "False", "finally", "for", "from", "global", "if", "import", "in", "is",
        "lambda", "None", "nonlocal", "not", "or", "pass", "raise", "return", "True", "try",
        "while", "with", "yield"
    }
        Dim stringPattern As String = """[^""\\]*(?:\\.[^""\\]*)*""|'[^'\\]*(?:\\.[^'\\]*)*'" ' Matches strings
        Dim commentPattern As String = "#[^\r\n]*"
        Dim numberPattern As String = "\b\d+(\.\d+)?\b"

        For Each keyword In keywords
            HighlightWord(editorBox, keyword, Color.Blue)
        Next
        HighlightPattern(editorBox, stringPattern, Color.Brown)
        HighlightPattern(editorBox, commentPattern, Color.Green)
        HighlightPattern(editorBox, numberPattern, Color.Magenta)
    End Sub

    Private Sub HighlightWord(editorBox As RichTextBox, word As String, color As Color)
        Dim matches As MatchCollection = Regex.Matches(editorBox.Text, $"\b{Regex.Escape(word)}\b")
        For Each match As Match In matches
            editorBox.Select(match.Index, match.Length)
            editorBox.SelectionColor = color
        Next
    End Sub

    Private Sub HighlightPattern(editorBox As RichTextBox, pattern As String, color As Color)
        Dim matches As MatchCollection = Regex.Matches(editorBox.Text, pattern)
        For Each match As Match In matches
            editorBox.Select(match.Index, match.Length)
            editorBox.SelectionColor = color
        Next
    End Sub


    Private Sub UpdateFormTitle()
        If TabControl1.SelectedTab Is Nothing Then Return
        Dim filePath = currentFilePaths(TabControl1.SelectedTab)
        Dim title = If(String.IsNullOrEmpty(filePath), "Untitled", Path.GetFileName(filePath))
        If TabControl1.SelectedTab.Text.StartsWith("*") Then title = "*" & title
        Me.Text = $"{title} - Helx Code Editor"
    End Sub

    Private Sub OpenFileMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileMenuItem.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Python Files (*.py)|*.py|Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            openFileDialog.Title = "Open File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath = openFileDialog.FileName
                Dim fileName = Path.GetFileName(filePath)

                For Each tab As TabPage In Me.TabControl1.TabPages
                    If currentFilePaths(tab) = filePath Then
                        Me.TabControl1.SelectedTab = tab
                        Return
                    End If
                Next

                ' New Tab
                Dim newTab = CreateNewTab(fileName)
                Dim editorBox = CType(newTab.Controls(0), RichTextBox)
                editorBox.Text = File.ReadAllText(filePath)
                currentFilePaths(newTab) = filePath
                TabControl1.TabPages.Add(newTab)
                TabControl1.SelectedTab = newTab
                UpdateFormTitle()
            End If
        End Using
    End Sub

    ' Save File
    Private Sub SaveFileMenuItem_Click(sender As Object, e As EventArgs) Handles SaveFileMenuItem.Click
        If TabControl1.SelectedTab Is Nothing Then Return
        Dim currentTab = TabControl1.SelectedTab
        Dim filePath = currentFilePaths(currentTab)
        If String.IsNullOrEmpty(filePath) Then
            SaveFileAs()
        Else
            File.WriteAllText(filePath, GetCurrentEditorBox().Text)
            currentTab.Text = currentTab.Text.TrimStart("*"c) ' Remove asterisk
            UpdateFormTitle()
        End If
    End Sub

    ' Save As
    Private Sub SaveAsMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsMenuItem.Click
        SaveFileAs()
    End Sub

    ' Save As helper
    Private Sub SaveFileAs()
        If TabControl1.SelectedTab Is Nothing Then Return
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Python Files (*.py)|*.py|Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            saveFileDialog.Title = "Save File As"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath = saveFileDialog.FileName
                File.WriteAllText(filePath, GetCurrentEditorBox().Text)
                Dim currentTab = TabControl1.SelectedTab
                currentFilePaths(currentTab) = filePath
                currentTab.Text = Path.GetFileName(filePath)
                UpdateFormTitle()
            End If
        End Using
    End Sub

    ' Exit w/ unsaved change alert
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If CheckUnsavedChanges() Then
            Me.Close()
        End If
    End Sub

    ' Handle Form Closing
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not CheckUnsavedChanges() Then
            e.Cancel = True
        End If
    End Sub

    Private Function CheckUnsavedChanges() As Boolean
        For Each tab As TabPage In TabControl1.TabPages
            If tab.Text.EndsWith("*") Then
                Dim result As DialogResult = MessageBox.Show($"Tab '{tab.Text.TrimEnd("*"c)}' has unsaved changes. Do you want to exit?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then
                    Return False ' Cancel
                ElseIf result = DialogResult.Yes Then
                    Return True ' Exit without saving
                ElseIf result = DialogResult.No Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub EULAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EULAToolStripMenuItem.Click
        EULA.Show()
    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.Click

    End Sub
End Class
