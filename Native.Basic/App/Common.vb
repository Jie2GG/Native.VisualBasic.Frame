Imports Native.Csharp.Sdk.Cqp.Api
Imports Unity

Namespace App
	''' <summary>
	''' 用于存放 App 数据的公共类
	''' </summary>
	Public Module Common

		''' <summary>
		''' 获取或设置 App 在运行期间所使用的数据路径
		''' </summary>
		''' <returns></returns>
		Public Property AppDirectory As String

		''' <summary>
		''' 获取或设置当前 App 是否处于运行状态
		''' </summary>
		''' <returns></returns>
		Public Property IsRunning As Boolean

		''' <summary>
		''' 获取或设置当前 App 使用的 <see cref="Csharp.Sdk.Cqp.Api.CqApi"/> 接口实例
		''' </summary>
		''' <returns></returns>
		Public Property CqApi As CqApi

		''' <summary>
		''' 获取或设置当前 App 使用的依赖注入容器实例
		''' </summary>
		''' <returns></returns>
		Public Property UnityContainer As IUnityContainer
	End Module
End Namespace
