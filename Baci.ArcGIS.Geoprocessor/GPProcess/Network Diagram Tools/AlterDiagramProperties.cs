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
	/// <para>Alter Diagram Properties</para>
	/// <para>更改逻辑示意图属性</para>
	/// <para>用于更改存储的网络逻辑示意图的属性。</para>
	/// </summary>
	public class AlterDiagramProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>要更改的存储的网络逻辑示意图。</para>
		/// </param>
		public AlterDiagramProperties(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改逻辑示意图属性</para>
		/// </summary>
		public override string DisplayName() => "更改逻辑示意图属性";

		/// <summary>
		/// <para>Tool Name : AlterDiagramProperties</para>
		/// </summary>
		public override string ToolName() => "AlterDiagramProperties";

		/// <summary>
		/// <para>Tool Excute Name : nd.AlterDiagramProperties</para>
		/// </summary>
		public override string ExcuteName() => "nd.AlterDiagramProperties";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutName!, AccessRightType!, Tags!, OutNetworkDiagramLayer! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>要更改的存储的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>输入网络逻辑示意图的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutName { get; set; }

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// <para>指定输入逻辑示意图的访问权限等级。</para>
		/// <para>公共—其他用户均具有逻辑示意图的完全访问权限；所有人都可以查看、编辑、更新和覆盖逻辑示意图。 但是，除了逻辑示意图所有者和门户 utility network 所有者之外（如果逻辑示意图与企业级地理数据库中的 utility network 相关），没有人能够使用更改逻辑示意图属性工具来更改访问权限等级。 这是默认设置。</para>
		/// <para>受保护—其他用户具有逻辑示意图的只读访问权限。 无法编辑、更新或覆盖逻辑示意图。</para>
		/// <para>私有—其他用户没有访问逻辑示意图的权限。 查找逻辑示意图窗格中将对其他用户隐藏相应的逻辑示意图项目。</para>
		/// <para><see cref="AccessRightTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AccessRightType { get; set; } = "PUBLIC";

		/// <summary>
		/// <para>Tags (optional)</para>
		/// <para>可帮助查找存储的逻辑示意图的一个或多个标签。这些标签可用于查找逻辑示意图窗格。</para>
		/// <para>要添加多个标签，可使用数字符号 (#) 分隔各个标签。这同样可使逻辑示意图的搜索更加全面和高效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; } = " ";

		/// <summary>
		/// <para>Altered Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// </summary>
		public enum AccessRightTypeEnum 
		{
			/// <summary>
			/// <para>公共—其他用户均具有逻辑示意图的完全访问权限；所有人都可以查看、编辑、更新和覆盖逻辑示意图。 但是，除了逻辑示意图所有者和门户 utility network 所有者之外（如果逻辑示意图与企业级地理数据库中的 utility network 相关），没有人能够使用更改逻辑示意图属性工具来更改访问权限等级。 这是默认设置。</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("公共")]
			Public,

			/// <summary>
			/// <para>受保护—其他用户具有逻辑示意图的只读访问权限。 无法编辑、更新或覆盖逻辑示意图。</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("受保护")]
			Protected,

			/// <summary>
			/// <para>私有—其他用户没有访问逻辑示意图的权限。 查找逻辑示意图窗格中将对其他用户隐藏相应的逻辑示意图项目。</para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("私有")]
			Private,

		}

#endregion
	}
}
