﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.269
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("GameLauncher.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        Friend ReadOnly Property icon() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("icon", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property icon_32() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("icon_32", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {\rtf1\ansi\deff1\adeflang1025
        '''{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\fswiss\fprq0\fcharset0 Calibri;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\fswiss\fprq0\fcharset0 Calibri;}{\f4\fmodern\fprq1\fcharset0 Courier New;}{\f5\fmodern\fprq1\fcharset0 NSimSun;}{\f6\fnil\fprq2\fcharset0 Microsoft YaHei;}{\f7\fnil\fprq0\fcharset0 Mangal;}}
        '''{\colortbl;\red0\green0\blue0;\red0\green0\blue128;\red128\green128\blue128;}
        '''{\stylesheet{\s1\rtlch\afs24\lang1081\ltrch\dbch\langfe2057\hich\fs24\lang2057 [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property rtfInfo() As String
            Get
                Return ResourceManager.GetString("rtfInfo", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
