Imports Native.Csharp.Sdk.Cqp.Api
Imports Native.Csharp.Sdk.Cqp.Model
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Native.Basic.App.Model
Imports Native.Basic.App.[Interface]

Namespace App.[Event]
	Public Class Event_GroupMessage
		Implements IEvent_GroupMessage

		Public Sub ReceiveGroupMessage(ByVal sender As Object, ByVal e As GroupMessageEventArgs) Implements IEvent_GroupMessage.ReceiveGroupMessage
			If e.FromAnonymous IsNot Nothing Then
				Common.CqApi.SendGroupMessage(e.FromGroup, e.FromAnonymous.CodeName & " 你发送了这样的消息: " & e.Msg)
				e.Handled = True
				Return
			End If

			Common.CqApi.SendGroupMessage(e.FromGroup, Common.CqApi.CqCode_At(e.FromQQ) & "你发送了这样的消息: " & e.Msg)
			e.Handled = True
		End Sub

		Public Sub ReceiveGroupPrivateMessage(ByVal sender As Object, ByVal e As PrivateMessageEventArgs) Implements IEvent_GroupMessage.ReceiveGroupPrivateMessage
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupFileUpload(ByVal sender As Object, ByVal e As FileUploadMessageEventArgs) Implements IEvent_GroupMessage.ReceiveGroupFileUpload
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupManageIncrease(ByVal sender As Object, ByVal e As GroupManageAlterEventArgs) Implements IEvent_GroupMessage.ReceiveGroupManageIncrease
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupManageDecrease(ByVal sender As Object, ByVal e As GroupManageAlterEventArgs) Implements IEvent_GroupMessage.ReceiveGroupManageDecrease
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupMemberJoin(ByVal sender As Object, ByVal e As GroupMemberAlterEventArgs) Implements IEvent_GroupMessage.ReceiveGroupMemberJoin
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupMemberInvitee(ByVal sender As Object, ByVal e As GroupMemberAlterEventArgs) Implements IEvent_GroupMessage.ReceiveGroupMemberInvitee
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupMemberLeave(ByVal sender As Object, ByVal e As GroupMemberAlterEventArgs) Implements IEvent_GroupMessage.ReceiveGroupMemberLeave
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupMemberRemove(ByVal sender As Object, ByVal e As GroupMemberAlterEventArgs) Implements IEvent_GroupMessage.ReceiveGroupMemberRemove
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupAddApply(ByVal sender As Object, ByVal e As GroupAddRequestEventArgs) Implements IEvent_GroupMessage.ReceiveGroupAddApply
			e.Handled = False
		End Sub

		Public Sub ReceiveGroupAddInvitee(ByVal sender As Object, ByVal e As GroupAddRequestEventArgs) Implements IEvent_GroupMessage.ReceiveGroupAddInvitee
			e.Handled = False
		End Sub
	End Class
End Namespace
