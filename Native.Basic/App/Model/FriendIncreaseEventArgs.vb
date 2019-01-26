Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace App.Model
	Public Class FriendIncreaseEventArgs
		Inherits EventArgs

		''' <summary>
		''' 发送时间
		''' </summary>
		''' <returns></returns>
		Public Property SendTime As DateTime

		''' <summary>
		''' 来源QQ
		''' </summary>
		''' <returns></returns>
		Public Property FromQQ As Long

		''' <summary>
		''' 获取或设置一个值，该值指示是否处理过此事件
		''' </summary>
		''' <returns></returns>
		Public Property Handled As Boolean
	End Class
End Namespace
