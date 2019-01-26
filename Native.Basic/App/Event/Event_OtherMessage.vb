Imports Native.Csharp.Sdk.Cqp.Api
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Native.Basic.App.Model
Imports Native.Basic.App.[Interface]

Namespace App.[Event]
	Public Class Event_OtherMessage
		Implements IEvent_OtherMessage

		Public Sub ReceiveOnlineStatusMessage(ByVal sender As Object, ByVal e As PrivateMessageEventArgs) Implements IEvent_OtherMessage.ReceiveOnlineStatusMessage
			e.Handled = False
		End Sub
	End Class
End Namespace
