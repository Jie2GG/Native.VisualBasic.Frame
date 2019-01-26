Imports Native.Basic.App.[Interface]
Imports Native.Csharp.Sdk.Cqp.Api
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.[Event]
	Public Class Event_UserExpand
		Implements IEvent_UserExpand

		Public Sub OpenConsoleWindow(ByVal sender As Object, ByVal e As EventArgs) Implements IEvent_UserExpand.OpenConsoleWindow
		End Sub
	End Class
End Namespace
