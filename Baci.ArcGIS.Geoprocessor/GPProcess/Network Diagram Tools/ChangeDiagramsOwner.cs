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
	/// <para>Change Diagrams Owner</para>
	/// <para>更改逻辑示意图所有者</para>
	/// <para>更改已存储网络逻辑示意图的所有权。</para>
	/// </summary>
	public class ChangeDiagramsOwner : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>与感兴趣 公共设施网络或追踪网络 相关、包含将转让所有权的已存储网络逻辑示意图的输入网络图层或网络逻辑示意图图层。</para>
		/// </param>
		/// <param name="TargetOwner">
		/// <para>Target Owner</para>
		/// <para>将成为指定逻辑示意图的新所有者的用户名称。</para>
		/// </param>
		public ChangeDiagramsOwner(object InDiagrams, object TargetOwner)
		{
			this.InDiagrams = InDiagrams;
			this.TargetOwner = TargetOwner;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改逻辑示意图所有者</para>
		/// </summary>
		public override string DisplayName() => "更改逻辑示意图所有者";

		/// <summary>
		/// <para>Tool Name : ChangeDiagramsOwner</para>
		/// </summary>
		public override string ToolName() => "ChangeDiagramsOwner";

		/// <summary>
		/// <para>Tool Excute Name : nd.ChangeDiagramsOwner</para>
		/// </summary>
		public override string ExcuteName() => "nd.ChangeDiagramsOwner";

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
		public override object[] Parameters() => new object[] { InDiagrams, TargetOwner, SourceOwner, DiagramNames, OutDiagrams };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>与感兴趣 公共设施网络或追踪网络 相关、包含将转让所有权的已存储网络逻辑示意图的输入网络图层或网络逻辑示意图图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Target Owner</para>
		/// <para>将成为指定逻辑示意图的新所有者的用户名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TargetOwner { get; set; }

		/// <summary>
		/// <para>Source Owner</para>
		/// <para>将更改网络逻辑示意图所有权的用户名称。</para>
		/// <para>仅当未指定逻辑示意图名称时，才使用此参数。如果已指定逻辑示意图名称，将忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SourceOwner { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// <para>要处理的逻辑示意图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DiagramNames { get; set; }

		/// <summary>
		/// <para>Output Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDiagrams { get; set; }

	}
}
