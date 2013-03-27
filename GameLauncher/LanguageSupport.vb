Imports Microsoft.Win32
Imports IniFile.IniFile
Imports System.IO

Public Class LanguageSupport

#Region "Language Strings"
    Private GameLauncherIsLoading As String
#End Region

    Private pCurrentLanguage As String = Nothing

    Public ReadOnly Property GetCurrentLanguage() As String
        Get
            Return pCurrentLanguage
        End Get
    End Property
    Public Sub InitializeLanguage()
        Dim languageKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim currentLanguage As String = CStr(languageKey.GetValue("language", Nothing))

        If String.IsNullOrWhiteSpace(currentLanguage) Then
            languageKey.SetValue("language", "English", RegistryValueKind.String)
            pCurrentLanguage = "English"
        Else
            pCurrentLanguage = currentLanguage
        End If


    End Sub

    Private Sub PopulateStrings()
        If pCurrentLanguage = "English" Then
            GameLauncherIsLoading = "Game Launcher is loading, please wait..."
        Else
            'Read from external file
        End If
    End Sub

    Public Function GetString(ByRef name As String) As String

    End Function
End Class
