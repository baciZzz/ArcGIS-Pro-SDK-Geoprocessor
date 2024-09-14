using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Store Diagram</para>
	/// <para>存储逻辑示意图</para>
	/// <para>用于在数据库中存储临时网络逻辑示意图。可以分配访问权限和标签以控制逻辑示意图的安全性和可搜索性。</para>
	/// </summary>
	public class StoreDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>要存储的临时网络逻辑示意图。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Network Diagram Name</para>
		/// <para>输出网络逻辑示意图的名称。</para>
		/// </param>
		public StoreDiagram(object InNetworkDiagramLayer, object OutName)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 存储逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "存储逻辑示意图";

		/// <summary>
		/// <para>Tool Name : StoreDiagram</para>
		/// </summary>
		public override string ToolName() => "StoreDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.StoreDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.StoreDiagram";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutName, AccessRightType, Tags };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>要存储的临时网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>输出网络逻辑示意图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// <para>指定输入逻辑示意图的访问权限等级。</para>
		/// <para>公众—其他用户均具有逻辑示意图的完全访问权限；所有人都可以查看、编辑、更新和覆盖逻辑示意图。但是，除了逻辑示意图所有者和门户 公共设施网络 所有者之外（如果逻辑示意图与企业级地理数据库中的 公共设施网络 相关），没有人能够使用更改逻辑示意图属性工具来更改访问权限等级。这是默认设置。</para>
		/// <para>保护—其他用户具有逻辑示意图的只读访问权限。无法编辑、更新或覆盖逻辑示意图。</para>
		/// <para>私有— 其他用户没有访问逻辑示意图的权限。查找逻辑示意图窗格中将对其他用户隐藏相应的逻辑示意图项目。</para>
		/// <para><see cref="AccessRightTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AccessRightType { get; set; } = "PUBLIC";

		/// <summary>
		/// <para>Tags (optional)</para>
		/// <para>标签可帮助使用查找逻辑示意图窗格来查询存储的逻辑示意图。</para>
		/// <para>可以使用 # 字符分隔各个标签，有助于进行高效的逻辑示意图搜索。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// </summary>
		public enum AccessRightTypeEnum 
		{
			/// <summary>
			/// <para>公众—其他用户均具有逻辑示意图的完全访问权限；所有人都可以查看、编辑、更新和覆盖逻辑示意图。但是，除了逻辑示意图所有者和门户 公共设施网络 所有者之外（如果逻辑示意图与企业级地理数据库中的 公共设施网络 相关），没有人能够使用更改逻辑示意图属性工具来更改访问权限等级。这是默认设置。</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("公众")]
			Public,

			/// <summary>
			/// <para>保护—其他用户具有逻辑示意图的只读访问权限。无法编辑、更新或覆盖逻辑示意图。</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("保护")]
			Protected,

			/// <summary>
			/// <para>私有— 其他用户没有访问逻辑示意图的权限。查找逻辑示意图窗格中将对其他用户隐藏相应的逻辑示意图项目。</para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("私有")]
			Private,

		}

#endregion
	}
}
