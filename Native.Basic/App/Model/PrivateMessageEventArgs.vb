Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.Model
	Public Class PrivateMessageEventArgs
		Inherits EventArgs

		''' <summary>
		''' 消息ID
		''' </summary>
		''' <returns></returns>
		Public Property MsgId As Integer

		''' <summary>
		''' 来源QQ
		''' </summary>
		''' <returns></returns>
		Public Property FromQQ As Long

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
