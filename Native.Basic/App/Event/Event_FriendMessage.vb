Imports Native.Basic.App.[Interface]
Imports Native.Basic.App.Model
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.[Event]
	Public Class Event_FriendMessage
		Implements IEvent_FriendMessage

		''' <summary>
		''' Type=201 好友已添加<para/>
		''' 处理好友已经添加事件
		''' </summary>
		''' <param name="sender">事件的触发对象</param>
		''' <param name="e">事件的附加参数</param>
		Public Sub ReceiveFriendIncrease(ByVal sender As Object, ByVal e As FriendIncreaseEventArgs) Implements IEvent_FriendMessage.ReceiveFriendIncrease
			' 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			' 这里处理消息


			e.Handled = False   ' 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		End Sub

		''' <summary>
		''' Type=301 收到好友添加请求<para/>
		''' 处理收到的好友添加请求
		''' </summary>
		''' <param name="sender">事件的触发对象</param>
		''' <param name="e">事件的附加参数</param>
		Public Sub ReceiveFriendAddRequest(ByVal sender As Object, ByVal e As FriendAddRequestEventArgs) Implements IEvent_FriendMessage.ReceiveFriendAddRequest
			' 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			' 这里处理消息


			e.Handled = False   ' 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		End Sub

		''' <summary>
		''' Type=21 好友消息<para/>
		''' 处理收到的好友消息
		''' </summary>
		''' <param name="sender">事件的触发对象</param>
		''' <param name="e">事件的附加参数</param>
		Public Sub ReceiveFriendMessage(ByVal sender As Object, ByVal e As PrivateMessageEventArgs) Implements IEvent_FriendMessage.ReceiveFriendMessage
			' 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			' 这里处理消息

			CqApi.SendPrivateMessage(e.FromQQ, CqApi.CqCode_At(e.FromQQ) & "你发送了这样的消息:" & e.Msg)


			e.Handled = True
			' e.Handled 相当于 原酷Q事件的返回值
			' 如果要回复消息，请调用api发送，并且置 true - 截断本条消息，不再继续处理 //注意：应用优先级设置为"最高"(10000)时， 不得置 true
			' 如果不回复消息，交由之后的应用/过滤器处理，这里置 false  - 忽略本条消息
		End Sub
	End Class
End Namespace
