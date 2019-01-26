Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.Model
	Public Class GroupAddRequestEventArgs
		Inherits EventArgs

		''' <summary>
		''' 发送时间
		''' </summary>
		''' <returns></returns>
		Public Property SendTime As DateTime

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
		''' 附加消息
		''' </summary>
		''' <returns></returns>
		Public Property AppendMsg As String

		''' <summary>
		''' 反馈标识 (处理请求用)
		''' </summary>
		''' <returns></returns>
		Public Property Tag As String

		''' <summary>
		''' 获取或设置一个值，该值指示是否处理过此事件
		''' </summary>
		''' <returns></returns>
		Public Property Handled As Boolean
	End Class
End Namespace
