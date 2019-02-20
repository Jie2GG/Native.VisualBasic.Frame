Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.ExceptionServices
Imports System.Text
Imports Unity
Imports Native.Basic.App.Core
Imports Native.Basic.App.[Interface]
Imports Native.Basic.App.Model
Imports Native.Csharp.Sdk.Cqp.Api

Namespace App.[Event]

	Public Class Event_AppMain

		''' <summary>
		''' 回调注册
		''' </summary>
		''' <param name="container"></param>
		Public Shared Sub Registbackcall(ByVal container As IUnityContainer)

#Region "--回调注入--"
			container.RegisterType(Of IEvent_AppStatus, Event_AppStatus)()
			container.RegisterType(Of IEvent_DiscussMessage, Event_DiscussMessage)()
			container.RegisterType(Of IEvent_FriendMessage, Event_FriendMessage)()
			container.RegisterType(Of IEvent_GroupMessage, Event_GroupMessage)()
			container.RegisterType(Of IEvent_OtherMessage, Event_OtherMessage)()
#End Region

			' 当需要新注册回调类型时
			' 在此写上需要注册的回调类型, 以 <接口, 实现类> 的方式进行注册
			container.RegisterType(Of IEvent_UserExpand, Event_UserExpand)()
		End Sub

		''' <summary>
		''' 回调分发
		''' </summary>
		''' <param name="container"></param>
		Public Shared Sub Resolvebackcall(ByVal container As IUnityContainer)

#Region "--IEvent_AppStatus--"
			Dim appStatuses As IEnumerable(Of IEvent_AppStatus) = container.ResolveAll(Of IEvent_AppStatus)()

			For Each appStatus As IEvent_AppStatus In appStatuses
				AddHandler LibExport.CqStartup, AddressOf appStatus.CqStartup
				AddHandler LibExport.CqExit, AddressOf appStatus.CqExit
				AddHandler LibExport.AppEnable, AddressOf appStatus.AppEnable
				AddHandler LibExport.AppDisable, AddressOf appStatus.AppDisable
			Next
#End Region

#Region "--IEvent_DiscussMessage--"
			Dim discussMessages As IEnumerable(Of IEvent_DiscussMessage) = container.ResolveAll(Of IEvent_DiscussMessage)()

			For Each discussMessage As IEvent_DiscussMessage In discussMessages
				AddHandler LibExport.ReceiveDiscussMessage, AddressOf discussMessage.ReceiveDiscussMessage
				AddHandler LibExport.ReceiveDiscussPrivateMessage, AddressOf discussMessage.ReceiveDiscussPrivateMessage
			Next
#End Region

#Region "--IEvent_FriendMessage--"
			Dim friendMessages As IEnumerable(Of IEvent_FriendMessage) = container.ResolveAll(Of IEvent_FriendMessage)()

			For Each friendMessage As IEvent_FriendMessage In friendMessages
				AddHandler LibExport.ReceiveFriendAdd, AddressOf friendMessage.ReceiveFriednAddRequest
				AddHandler LibExport.ReceiveFriendIncrease, AddressOf friendMessage.ReceiveFriendIncrease
				AddHandler LibExport.ReceiveFriendMessage, AddressOf friendMessage.ReceiveFriendMessage
			Next
#End Region

#Region "--IEvent_GroupMessage--"
			Dim groupMessages As IEnumerable(Of IEvent_GroupMessage) = container.ResolveAll(Of IEvent_GroupMessage)()

			For Each groupMessage As IEvent_GroupMessage In groupMessages
				AddHandler LibExport.ReceiveGroupMessage, AddressOf groupMessage.ReceiveGroupMessage
				AddHandler LibExport.ReceiveGroupPrivateMessage, AddressOf groupMessage.ReceiveGroupPrivateMessage
				AddHandler LibExport.ReceiveFileUploadMessage, AddressOf groupMessage.ReceiveGroupFileUpload
				AddHandler LibExport.ReceiveManageIncrease, AddressOf groupMessage.ReceiveGroupManageIncrease
				AddHandler LibExport.ReceiveManageDecrease, AddressOf groupMessage.ReceiveGroupManageDecrease
				AddHandler LibExport.ReceiveMemberJoin, AddressOf groupMessage.ReceiveGroupMemberJoin
				AddHandler LibExport.ReceiveMemberInvitee, AddressOf groupMessage.ReceiveGroupMemberInvitee
				AddHandler LibExport.ReceiveMemberLeave, AddressOf groupMessage.ReceiveGroupMemberLeave
				AddHandler LibExport.ReceiveMemberRemove, AddressOf groupMessage.ReceiveGroupMemberRemove
				AddHandler LibExport.ReceiveGroupAddApply, AddressOf groupMessage.ReceiveGroupAddApply
				AddHandler LibExport.ReceiveGroupAddInvitee, AddressOf groupMessage.ReceiveGroupAddInvitee
			Next
#End Region

#Region "--IEvent_OtherMessage--"
			Dim otherMessages As IEnumerable(Of IEvent_OtherMessage) = container.ResolveAll(Of IEvent_OtherMessage)()

			For Each otherMessage As IEvent_OtherMessage In otherMessages
				AddHandler LibExport.ReceiveQnlineStatusMessage, AddressOf otherMessage.ReceiveOnlineStatusMessage
			Next
#End Region

			' 当已经注入了新的回调类型时
			' 在此分发已经注册的回调类型, 解析完毕后分发到导出的事件进行注册
			Dim userExpand As IEvent_UserExpand = container.Resolve(Of IEvent_UserExpand)()
			AddHandler UserExport.UserOpenConsole, AddressOf userExpand.OpenConsoleWindow
		End Sub

		''' <summary>
		''' 当前回调事件的注册和分发完成之后将调用此方法
		''' </summary>
		Public Shared Sub Initialize()

		End Sub
	End Class
End Namespace
