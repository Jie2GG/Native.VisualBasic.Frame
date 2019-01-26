Imports Native.Basic.App.[Interface]
Imports Native.Basic.App.Model
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.[Event]
	Public Class Event_FriendMessage
		Implements IEvent_FriendMessage

		Public Sub ReceiveFriendIncrease(ByVal sender As Object, ByVal e As FriendIncreaseEventArgs) Implements IEvent_FriendMessage.ReceiveFriendIncrease
			e.Handled = False
		End Sub

		Public Sub ReceiveFriednAddRequest(ByVal sender As Object, ByVal e As FriendAddRequestEventArgs) Implements IEvent_FriendMessage.ReceiveFriednAddRequest
			e.Handled = False
		End Sub

		Public Sub ReceiveFriendMessage(ByVal sender As Object, ByVal e As PrivateMessageEventArgs) Implements IEvent_FriendMessage.ReceiveFriendMessage
			Common.CqApi.SendPrivateMessage(e.FromQQ, Common.CqApi.CqCode_At(e.FromQQ) & "你发送了这样的消息:" & e.Msg)
			e.Handled = True
		End Sub
	End Class
End Namespace
