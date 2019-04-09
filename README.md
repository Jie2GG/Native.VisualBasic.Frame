## Native.SDK 优点介绍

> 1. 程序集脱库打包
> 2. 原生c#开发体验
> 3. 完美翻译酷QApi
> 4. 支持酷Q应用打包
> 5. 支持代码实时调试

## Native.SDK 项目结构

![SDK结构](https://github.com/Jie2GG/Image/blob/master/NativeSDK(1).png "SDK结构") <br/>

## Native.SDK 开发环境

>1. Visual Studio 2012 或更高版本
>2. Microsoft .Net Framework 4.0 **(XP系统支持的最后一个版本)**

## Native.SDK 开发流程

	1. 下载并打开 Native.SDK
	2. 打开 Native.Basic 项目属性, 修改 "应用程序" 中的 "程序集名称" 为你的AppId(规则参见http://d.cqp.me/Pro/开发/基础信息)
	3. 展开 Native.Basic 项目, 修改 "Native.Basic.json" 文件名为你的AppId
	4. 展开 Native.Basic 项目, 找到 App -> Core -> LibExport.tt 文件, 右击选择 "运行自定义工具"
	
	此时 Native.SDK 的开发环境已经配置成功!
	要找到生成的 程序集, 请找 Native.Basic -> bin -> x86 -> (Debug\Release) 

## Native.SDK 调试流程

	1. 打开菜单 生成 -> 配置管理器, 修改 "Native.Basic" 项目的生成方式为 "Debug x86" 生成方式
	2. 打开项目 Native.Basic 项目属性, 修改 "编译" 中的 "生成输出路径" 至酷Q的 "app" 目录
	3. 修改 "调试" 中的 "启动操作" 为 "启动外部程序", 并且定位到酷Q主程序
	4. 打开菜单 工具 -> 选项 -> 调试, 关闭 "要求源文件与原始版本匹配" 选项
	
	若还是不行调试?
	5. 打开项目 Native.Basic 项目属性, 打开 "调试" 中的 "启用本地代码调试" 选项, 保存即可
	
	此时 Native.SDK 已经可以进行实时调试!

## Native.SDK 已知问题

> 1. 对于 VisualBasic 项目不知道为什么安装高版本的 Fody 就编译不通过, 现 Fody 版本为 1.6.2, 所以暂时不支持无缝升级到 .Net Framewrok 4.5+

## Native.SDK 更新日志
> 2019年04月09日 版本: V1.1.3

	1. 修复 CqMsg 类针对 VS2012 的兼容问题
	2. 修复 HttpWebClient 类在增加 Cookies 时, 参数 "{0}" 为空字符串的异常
	3. 新增 HttpWebClient 类属性 "KeepAlive", 允许指定 HttpWebClient 在做请求时是否建立持续型的 Internal 连接

> 2019年04月06日 版本: V1.1.2
	
	1. 优化 Native.Csharp.Sdk 项目的结构, 修改类: CqApi 的命名空间
	2. 新增 消息解析类: CqMsg
	
``` VB
' 使用方法如下, 例如在群消息接受方法中
Public Sub ReceiveGroupMessage(ByVal sender As Object, ByVal e As GroupMessageEventArgs) Implements IEvent_GroupMessage.ReceiveGroupMessage
	Dim parseResult As CqMsg = CqMsg.Parse (e.Msg)		' 使用消息解析
	Dim cqCodes As List(Of CqCode) = parseResult.Contents	' 获取消息中所有的 CQ码
	
	' 此时, 获取到的 cqCodes 中就包含此条消息所有的 CQ码
End Sub
```

> 2019年03月12日 版本: V1.1.1

	1. 新增 Sex 枚举中未知性别, 值为 255
	2. 优化 IOC 容器在获取对象时, 默认拉取所有注入的对象, 简化消息类接口的注入流程.
	
> 2019年03月03日 版本: V1.1.0

	本次更新于响应 "酷Q" 官方 "易语言 SDK" 的迭代更新
	
	1. 新增 CqApi.ReceiveImage (用于获取消息中 "图片" 的绝对路径)
	2. 新增 CqApi.GetSendRecordSupport (用于获取 "是否支持发送语音", 即用于区别 Air 和 Pro 版本之间的区别)
	3. 新增 CqApi.GetSendImageSupport (用于获取 "是否支持发送图片", 即用于区别 Air 和 Pro 版本指间的区别)
	4. 优化 CqApi.ReceiveRecord 方法, 使其获取到的语音路径为绝对路径, 而非相对路径
	
> 2019年02月26日 版本: V1.0.6

	1. 默认注释 Event_GroupMessage 中 ReceiveGroupMessage 方法的部分代码, 防止因为机器人复读群消息而禁言

> 2019年02月24日 版本: V1.0.5

	1. 为 SDK 添加了提交版本号

> 2019年02月20日 版本: V1.0.4

	1. 还原 Event_AppMain.Resolvebackcall 方法的执行, 防止偶尔获取不到注入的类

> 2019年02月20日 版本: V1.0.3

	1. 更新 Native.Basic 项目的部分注释
	2. 新增 Event_AppMain.Initialize 方法, 位于 "Native.Basic.App.Event" 下, 用于当作本项目的初始化方法
	3. 优化 Event_AppMain.Resolvebackcall 方法的执行, 默认将依据接口注入的类型全部实例化并取出分发到事件上 

> 2019年02月16日 版本: V1.0.2

	1. 优化 FodyWeavers.xml 配置, 为其加上注释. 方便开发者使用
	2. 修复 IniValue 中 ToType 方法导致栈溢出的

> 2019年01月27日 版本: V1.0.1

	1. 移除 AnyCPU 配置项, 提升编译稳定性
	2. 提交相关依赖项, 提升编译稳定性

> 2019年01月27日 版本: V1.0.0

    1. 打包上传项目
