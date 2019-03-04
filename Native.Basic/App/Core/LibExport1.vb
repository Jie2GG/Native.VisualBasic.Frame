﻿'	此代码由模板生成, 请勿随意改动此源码, 防止出现错误
'	需要更新 AppID 请右击模板文件, 点击运行自定义工具
Imports System.Runtime.InteropServices
Imports System.Text
Imports Native.Basic.App.Event
Imports Native.Basic.App.Model
Imports Native.Csharp.Sdk.Cqp.Api
Imports Native.Csharp.Sdk.Cqp.Enum
Imports Native.Csharp.Tool
Imports Unity

Namespace App.Core
	Public Class LibExport

#Region "--构造函数--"
		''' <summary>
		''' 静态构造函数, 注册依赖注入回调
		''' </summary>
		Shared Sub New()
			' 初始化依赖注入容器
			Common.UnityContainer = New UnityContainer()

			' 程序开始调用方法进行注册
			Event_AppMain.Registbackcall(Common.UnityContainer)

			' 注册完毕调用方法进行分发
			Event_AppMain.Resolvebackcall(Common.UnityContainer)

			' 完成操作调用初始化函数
			Event_AppMain.Initialize()
		End Sub
#End Region

#Region "--核心方法--"
		''' <summary>
		''' 返回 AppID 与 ApiVer, 本方法在模板运行后会根据项目名称自动填写 AppID 与 ApiVer
		''' </summary>
		''' <returns></returns>
		<DllExport(ExportName:="AppInfo", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function AppInfo() As String
			' 请勿随意修改
			'
			' 当前项目名称: Native.Basic
			' Api版本: 9
			Return String.Format("{0},{1}", 9, "Native.Basic")
		End Function

		''' <summary>
		''' 接收插件 AutoCode, 注册异常
		''' </summary>
		''' <param name="authCode"></param>
		''' <returns></returns>
		<DllExport(ExportName:="Initialize", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function Initialize(ByVal authCode As Int32) As Int32
			' 酷Q获取应用信息后，如果接受该应用，将会调用这个函数并传递AuthCode。
			Common.CqApi = New CqApi(authCode)

			' 注册插件全局异常捕获回调, 用于捕获未处理的异常, 回弹给 酷Q 做处理
			AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

			' 本函数【禁止】处理其他任何代码，以免发生异常情况。如需执行初始化代码请在Startup事件中执行（Type=1001）。
			Return 0
		End Function
#End Region

#Region "--私有方法--"
		''' <summary>
		''' 全局异常捕获, 用于捕获开发者未处理的异常, 此异常将回弹至酷Q进行处理
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Shared Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
			Dim ex As Exception = TryCast(e.ExceptionObject, Exception)

			If ex IsNot Nothing Then
				Dim innerLog As StringBuilder = New StringBuilder()
				innerLog.AppendLine("NativeSDK 异常")
				innerLog.AppendFormat("[异常名称]: {0}{1}", ex.Source.ToString(), Environment.NewLine)
				innerLog.AppendFormat("[异常消息]: {0}{1}", ex.Message, Environment.NewLine)
				innerLog.AppendFormat("[异常堆栈]: {0}{1}", ex.StackTrace)

				If e.IsTerminating Then
					Common.CqApi.AddFatalError(innerLog.ToString())
				Else
					Common.CqApi.AddLoger(LogerLevel.[Error], "Native 异常捕捉", innerLog.ToString())
				End If
			End If
		End Sub
#End Region

#Region "--回调事件--"
		''' <summary>
		''' 酷Q事件: _eventStartup 回调
		''' <para>Type=1001 酷Q启动</para>
		''' </summary>
		Public Shared Event CqStartup As EventHandler(Of EventArgs)

		''' <summary>
		''' 酷Q事件: _eventExit
		''' <para>Type=1002 酷Q退出</para>
		''' </summary>
		Public Shared Event CqExit As EventHandler(Of EventArgs)

		''' <summary>
		''' 酷Q事件: _eventEnable
		''' <para>Type=1003 应用已被启用</para>
		''' </summary>
		Public Shared Event AppEnable As EventHandler(Of EventArgs)

		''' <summary>
		''' 酷Q事件: _eventDisable
		''' <para>Type=1004 应用将被停用</para>
		''' </summary>
		Public Shared Event AppDisable As EventHandler(Of EventArgs)

		''' <summary>
		''' 酷Q事件: _eventPrivateMsg
		''' <para>Type=21 私聊消息 - 好友</para>
		''' </summary>
		Public Shared Event ReceiveFriendMessage As EventHandler(Of PrivateMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventPrivateMsg
		''' <para>Type=21 私聊消息 - 在线状态</para>
		''' </summary>
		Public Shared Event ReceiveQnlineStatusMessage As EventHandler(Of PrivateMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventPrivateMsg
		''' <para>Type=21 私聊消息 - 群私聊</para>
		''' </summary>
		Public Shared Event ReceiveGroupPrivateMessage As EventHandler(Of PrivateMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventPrivateMsg
		''' <para>Type=21 私聊消息 - 讨论组私聊</para>
		''' </summary>
		Public Shared Event ReceiveDiscussPrivateMessage As EventHandler(Of PrivateMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventGroupMsg
		''' <para>Type=2 群消息</para>
		''' </summary>
		Public Shared Event ReceiveGroupMessage As EventHandler(Of GroupMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventDiscussMsg
		''' <para>Type=4 讨论组消息</para>
		''' </summary>
		Public Shared Event ReceiveDiscussMessage As EventHandler(Of DiscussMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventGroupUpload
		''' <para>Type=11 群文件上传事件</para>
		''' </summary>
		Public Shared Event ReceiveFileUploadMessage As EventHandler(Of FileUploadMessageEventArgs)

		''' <summary>
		''' 酷Q事件: _eventSystem_GroupAdmin
		''' <para>Type=101 群事件-管理员变动 - 群管理增加</para>
		''' </summary>
		Public Shared Event ReceiveManageIncrease As EventHandler(Of GroupManageAlterEventArgs)

		''' <summary>
		''' 酷Q事件: _eventSystem_GroupAdmin
		''' <para>Type=101 群事件-管理员变动 - 群管理减少</para>
		''' </summary>
		Public Shared Event ReceiveManageDecrease As EventHandler(Of GroupManageAlterEventArgs)

		''' <summary>
		''' 酷Q事件: _eventSystem_GroupMemberIncrease
		''' <para>Type=103 群事件-群成员增加 - 主动离开</para>
		''' </summary>
		Public Shared Event ReceiveMemberLeave As EventHandler(Of GroupMemberAlterEventArgs)

		''' <summary>
		''' 酷Q事件: _eventSystem_GroupMemberIncrease
		''' <para>Type=103 群事件-群成员增加 - 成员移除</para>
		''' </summary>
		Public Shared Event ReceiveMemberRemove As EventHandler(Of GroupMemberAlterEventArgs)

		''' <summary>
		''' 酷Q事件: _eventSystem_GroupMemberIncrease
		''' <para>Type=103 群事件-群成员增加 - 主动加群</para>
		''' </summary>
		Public Shared Event ReceiveMemberJoin As EventHandler(Of GroupMemberAlterEventArgs)

		''' <summary>
		''' 酷Q事件: _eventSystem_GroupMemberIncrease
		''' <para>Type=103 群事件-群成员增加 - 邀请入群</para>
		''' </summary>
		Public Shared Event ReceiveMemberInvitee As EventHandler(Of GroupMemberAlterEventArgs)

		''' <summary>
		''' 酷Q事件: _eventFriend_Add
		''' <para>Type=201 好友事件-好友已添加</para>
		''' </summary>
		Public Shared Event ReceiveFriendIncrease As EventHandler(Of FriendIncreaseEventArgs)

		''' <summary>
		''' 酷Q事件: _eventRequest_AddFriend
		''' <para>Type=301 请求-好友添加</para>
		''' </summary>
		Public Shared Event ReceiveFriendAdd As EventHandler(Of FriendAddRequestEventArgs)

		''' <summary>
		''' 酷Q事件: _eventRequest_AddGroup
		''' <para>Type=302 请求-群添加 - 申请入群</para>
		''' </summary>
		Public Shared Event ReceiveGroupAddApply As EventHandler(Of GroupAddRequestEventArgs)

		''' <summary>
		''' 酷Q事件: _eventRequest_AddGroup
		''' <para>Type=302 请求-群添加 - 被邀入群</para>
		''' </summary>
		Public Shared Event ReceiveGroupAddInvitee As EventHandler(Of GroupAddRequestEventArgs)
#End Region

#Region "--导出方法--"
		<DllExport(ExportName:="_eventStartup", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventStartUp() As Integer
			RaiseEvent CqStartup(Nothing, New EventArgs())
			Return 0
		End Function

		<DllExport(ExportName:="_eventExit", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventExit() As Integer
			RaiseEvent CqExit(Nothing, New EventArgs())
			Return 0
		End Function

		<DllExport(ExportName:="_eventEnable", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventEnable() As Integer
			RaiseEvent AppEnable(Nothing, New EventArgs())
			Return 0
		End Function

		<DllExport(ExportName:="_eventDisable", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventDisable() As Integer
			RaiseEvent AppDisable(Nothing, New EventArgs())
			Return 0
		End Function

		<DllExport(ExportName:="_eventPrivateMsg", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventPrivateMsg(ByVal subType As Integer, ByVal msgId As Integer, ByVal fromQQ As Long, ByVal msg As IntPtr, ByVal font As Integer) As Integer
			Dim args As PrivateMessageEventArgs = New PrivateMessageEventArgs()
			args.MsgId = msgId
			args.FromQQ = fromQQ
			args.Msg = NativeConvert.ToPtrString(msg, Encoding.GetEncoding("GB18030"))
			args.Handled = False

			If subType = 11 Then
				RaiseEvent ReceiveFriendMessage(Nothing, args)
			ElseIf subType = 1 Then
				RaiseEvent ReceiveQnlineStatusMessage(Nothing, args)
			ElseIf subType = 2 Then
				RaiseEvent ReceiveGroupPrivateMessage(Nothing, args)
			ElseIf subType = 3 Then
				RaiseEvent ReceiveDiscussPrivateMessage(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventPrivateMsg 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventGroupMsg", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventGroupMsg(ByVal subType As Integer, ByVal msgId As Integer, ByVal fromGroup As Long, ByVal fromQQ As Long, ByVal fromAnonymous As String, ByVal msg As IntPtr, ByVal font As Integer) As Integer
			Dim args As GroupMessageEventArgs = New GroupMessageEventArgs()
			args.MsgId = msgId
			args.FromGroup = fromGroup
			args.FromQQ = fromQQ
			args.Msg = NativeConvert.ToPtrString(msg, Encoding.GetEncoding("GB18030"))
			args.FromAnonymous = Nothing
			args.IsAnonymousMsg = False
			args.Handled = False

			If fromQQ = 80000000 AndAlso Not String.IsNullOrEmpty(fromAnonymous) Then
				args.FromAnonymous = Common.CqApi.GetAnonymous(fromAnonymous)
				args.IsAnonymousMsg = True
			End If

			If subType = 1 Then
				RaiseEvent ReceiveGroupMessage(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventGroupMsg 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventDiscussMsg", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventDiscussMsg(ByVal subType As Integer, ByVal msgId As Integer, ByVal fromDiscuss As Long, ByVal fromQQ As Long, ByVal msg As IntPtr, ByVal font As Integer) As Integer
			Dim args As DiscussMessageEventArgs = New DiscussMessageEventArgs()
			args.MsgId = msgId
			args.FromDiscuss = fromDiscuss
			args.FromQQ = fromQQ
			args.Msg = NativeConvert.ToPtrString(msg, Encoding.GetEncoding("GB18030"))
			args.Handled = False

			If subType = 1 Then
				RaiseEvent ReceiveDiscussMessage(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventDiscussMsg 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventGroupUpload", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventGroupUpload(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromGroup As Long, ByVal fromQQ As Long, ByVal file As String) As Integer
			Dim args As FileUploadMessageEventArgs = New FileUploadMessageEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromGroup = fromGroup
			args.FromQQ = fromQQ
			args.File = Common.CqApi.GetFile(file)
			RaiseEvent ReceiveFileUploadMessage(Nothing, args)
			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventSystem_GroupAdmin", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventSystemGroupAdmin(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromGroup As Long, ByVal beingOperateQQ As Long) As Integer
			Dim args As GroupManageAlterEventArgs = New GroupManageAlterEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromGroup = fromGroup
			args.BeingOperateQQ = beingOperateQQ
			args.Handled = False

			If subType = 1 Then
				RaiseEvent ReceiveManageDecrease(Nothing, args)
			ElseIf subType = 2 Then
				RaiseEvent ReceiveManageIncrease(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventSystemGroupAdmin 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventSystem_GroupMemberDecrease", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventSystemGroupMemberDecrease(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromGroup As Long, ByVal fromQQ As Long, ByVal beingOperateQQ As Long) As Integer
			Dim args As GroupMemberAlterEventArgs = New GroupMemberAlterEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromGroup = fromGroup
			args.FromQQ = fromQQ
			args.BeingOperateQQ = beingOperateQQ
			args.Handled = False

			If subType = 1 Then
				args.FromQQ = beingOperateQQ
				RaiseEvent ReceiveMemberLeave(Nothing, args)
			ElseIf subType = 2 Then
				RaiseEvent ReceiveMemberRemove(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventSystemGroupMemberDecrease 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventSystem_GroupMemberIncrease", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventSystemGroupMemberIncrease(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromGroup As Long, ByVal fromQQ As Long, ByVal beingOperateQQ As Long) As Integer
			Dim args As GroupMemberAlterEventArgs = New GroupMemberAlterEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromGroup = fromGroup
			args.FromQQ = fromQQ
			args.BeingOperateQQ = beingOperateQQ
			args.Handled = False

			If subType = 1 Then
				RaiseEvent ReceiveMemberJoin(Nothing, args)
			ElseIf subType = 2 Then
				RaiseEvent ReceiveMemberInvitee(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventSystemGroupMemberIncrease 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventFriend_Add", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventFriendAdd(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromQQ As Long) As Integer
			Dim args As FriendIncreaseEventArgs = New FriendIncreaseEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromQQ = fromQQ
			args.Handled = False

			If subType = 1 Then
				RaiseEvent ReceiveFriendIncrease(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventFriendAdd 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventRequest_AddFriend", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventRequestAddFriend(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromQQ As Long, ByVal msg As IntPtr, ByVal responseFlag As String) As Integer
			Dim args As FriendAddRequestEventArgs = New FriendAddRequestEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromQQ = fromQQ
			args.AppendMsg = NativeConvert.ToPtrString(msg, Encoding.GetEncoding("GB18030"))
			args.Tag = responseFlag
			args.Handled = False

			If subType = 1 Then
				RaiseEvent ReceiveFriendAdd(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventRequestAddFriend 方法发现新的消息类型")
			End If

			Return CInt((If(args.Handled, MessageHanding.Intercept, MessageHanding.Ignored)))
		End Function

		<DllExport(ExportName:="_eventRequest_AddGroup", CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EventRequestAddGroup(ByVal subType As Integer, ByVal sendTime As Integer, ByVal fromGroup As Long, ByVal fromQQ As Long, ByVal msg As IntPtr, ByVal responseFlag As String) As Integer
			Dim args As GroupAddRequestEventArgs = New GroupAddRequestEventArgs()
			args.SendTime = NativeConvert.FotmatUnixTime(sendTime.ToString())
			args.FromGroup = fromGroup
			args.FromQQ = fromQQ
			args.AppendMsg = NativeConvert.ToPtrString(msg, Encoding.GetEncoding("GB18030"))
			args.Tag = responseFlag
			args.Handled = False

			If subType = 1 Then
				RaiseEvent ReceiveGroupAddApply(Nothing, args)
			ElseIf subType = 2 Then
				RaiseEvent ReceiveGroupAddInvitee(Nothing, args)
			Else
				Common.CqApi.AddLoger(LogerLevel.Info, "Native提示", "EventRequestAddGroup 方法发现新的消息类型")
			End If

			Return 0
		End Function
#End Region

	End Class
End Namespace