Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Native.Basic.App.[Interface]
Imports Native.Csharp.Sdk.Cqp.Api

Namespace App.[Event]
	Public Class Event_AppStatus
		Implements IEvent_AppStatus

		Public Sub CqStartup(ByVal sender As Object, ByVal e As EventArgs) Implements IEvent_AppStatus.CqStartup
			Common.AppDirectory = Common.CqApi.GetAppDirectory()
		End Sub

		Public Sub CqExit(ByVal sender As Object, ByVal e As EventArgs) Implements IEvent_AppStatus.CqExit
		End Sub

		Public Sub AppEnable(ByVal sender As Object, ByVal e As EventArgs) Implements IEvent_AppStatus.AppEnable
			Common.IsRunning = True
		End Sub

		Public Sub AppDisable(ByVal sender As Object, ByVal e As EventArgs) Implements IEvent_AppStatus.AppDisable
			Common.IsRunning = False
		End Sub
	End Class
End Namespace
