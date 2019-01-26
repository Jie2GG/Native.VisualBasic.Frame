Imports Native.Csharp.Sdk.Cqp.Model
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.Model
	Public Class GroupMessageEventArgs
		Inherits EventArgs

		''' <summary>
		''' 消息Id
		''' </summary>
		''' <returns></returns>
		Public Property MsgId As Integer

		''' <summary>
		''' 来源群号
		''' </summary>
		''' <returns></returns>
		Public Property FromGroup As Long

		''' <summary>
		''' 来源QQ
		''' </summary>
		''' <returns></returns>
		Public Property FromQQ As Long

		''' <summary>
		''' 是否是匿名消息
		''' </summary>
		''' <returns></returns>
		Public Property IsAnonymousMsg As Boolean

		''' <summary>
		''' 来源匿名
		''' </summary>
		''' <returns></returns>
		Public Property FromAnonymous As GroupAnonymous

		''' <summary>
		''' 消息内容
		''' </summary>
		''' <returns></returns>
		Public Property Msg As String

		''' <summary>
		''' 获取或设置一个值，该值指示是否处理过此事件
		''' </summary>
		''' <returns></returns>
		Public Property Handled As Boolean
	End Class
End Namespace
