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
	/// <para>Extend Diagram</para>
	/// <para>扩展逻辑示意图</para>
	/// <para>基于网络连通性、可遍历性、包含或结构附件关联将网络逻辑示意图扩展一个网络元素级别。</para>
	/// </summary>
	public class ExtendDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>要扩展的网络逻辑示意图。</para>
		/// </param>
		public ExtendDiagram(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 扩展逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "扩展逻辑示意图";

		/// <summary>
		/// <para>Tool Name : ExtendDiagram</para>
		/// </summary>
		public override string ToolName() => "ExtendDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.ExtendDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.ExtendDiagram";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, IgnoreTraversability, OutNetworkDiagramLayer, ExtensionType };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>要扩展的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Ignore traversability</para>
		/// <para>指定是否使用可遍历性或连通性来扩展逻辑示意。此参数已在 ArcGIS Pro 2.2 中弃用。如果指定了 extension_type 参数，则无论其值是多少，都会被系统忽略。未指定 extension_type 参数时，如果要保持与模型以及在 ArcGIS Pro 2.1 中编写的 Python 脚本的兼容性，则其将保持启用。</para>
		/// <para>IGNORE_TRAVERSABILITY—将忽略网络的可遍历性。这是默认设置。</para>
		/// <para>HONOR_TRAVERSABILITY —支持网络的可遍历性。</para>
		/// <para><see cref="IgnoreTraversabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreTraversability { get; set; } = "true";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Extension Type</para>
		/// <para>指定扩展逻辑示意图的方法。</para>
		/// <para>按连通性—基于网络连通性将网络逻辑示意图扩展一个网络元素级别。这是默认设置。</para>
		/// <para>按可遍历性—基于网络可遍历性将网络逻辑示意图扩展一个网络元素级别。</para>
		/// <para>按附件—基于结构附件关联将网络逻辑示意图扩展一个网络元素级别。</para>
		/// <para>按包含—基于包含关联将网络逻辑示意图扩展一个网络元素级别。</para>
		/// <para><see cref="ExtensionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExtensionType { get; set; } = "BY_CONNECTIVITY";

		#region InnerClass

		/// <summary>
		/// <para>Ignore traversability</para>
		/// </summary>
		public enum IgnoreTraversabilityEnum 
		{
			/// <summary>
			/// <para>IGNORE_TRAVERSABILITY—将忽略网络的可遍历性。这是默认设置。</para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_TRAVERSABILITY")]
			IGNORE_TRAVERSABILITY,

			/// <summary>
			/// <para>HONOR_TRAVERSABILITY —支持网络的可遍历性。</para>
			/// </summary>
			[GPValue("false")]
			[Description("HONOR_TRAVERSABILITY")]
			HONOR_TRAVERSABILITY,

		}

		/// <summary>
		/// <para>Extension Type</para>
		/// </summary>
		public enum ExtensionTypeEnum 
		{
			/// <summary>
			/// <para>按连通性—基于网络连通性将网络逻辑示意图扩展一个网络元素级别。这是默认设置。</para>
			/// </summary>
			[GPValue("BY_CONNECTIVITY")]
			[Description("按连通性")]
			By_connectivity,

			/// <summary>
			/// <para>按可遍历性—基于网络可遍历性将网络逻辑示意图扩展一个网络元素级别。</para>
			/// </summary>
			[GPValue("BY_TRAVERSABILITY")]
			[Description("按可遍历性")]
			By_traversability,

			/// <summary>
			/// <para>按附件—基于结构附件关联将网络逻辑示意图扩展一个网络元素级别。</para>
			/// </summary>
			[GPValue("BY_ATTACHMENT")]
			[Description("按附件")]
			By_attachment,

			/// <summary>
			/// <para>按包含—基于包含关联将网络逻辑示意图扩展一个网络元素级别。</para>
			/// </summary>
			[GPValue("BY_CONTAINMENT")]
			[Description("按包含")]
			By_containment,

		}

#endregion
	}
}
