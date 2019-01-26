Imports Native.Basic.App.[Interface]
Imports Native.Basic.App.Model
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.[Event]
	Public Class Event_DiscussMessage
		Implements IEvent_DiscussMessage

		Public Sub ReceiveDiscussMessage(ByVal sender As Object, ByVal e As DiscussMessageEventArgs) Implements IEvent_DiscussMessage.ReceiveDiscussMessage
			e.Handled = False
		End Sub

		Public Sub ReceiveDiscussPrivateMessage(ByVal sender As Object, ByVal e As PrivateMessageEventArgs) Implements IEvent_DiscussMessage.ReceiveDiscussPrivateMessage
			e.Handled = False
		End Sub
	End Class
End Namespace
