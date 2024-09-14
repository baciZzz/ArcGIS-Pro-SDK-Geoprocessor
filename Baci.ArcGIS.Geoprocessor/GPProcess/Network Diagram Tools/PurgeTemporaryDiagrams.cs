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
	/// <para>Purge Temporary Diagrams</para>
	/// <para>清除临时逻辑示意图</para>
	/// <para>用于清除与给定 公共设施网络或追踪网络 相关的临时网络逻辑示意图。</para>
	/// </summary>
	public class PurgeTemporaryDiagrams : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>带有要清除的临时逻辑示意图的 公共设施网络或追踪网络 数据元素。</para>
		/// </param>
		public PurgeTemporaryDiagrams(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 清除临时逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "清除临时逻辑示意图";

		/// <summary>
		/// <para>Tool Name : PurgeTemporaryDiagrams</para>
		/// </summary>
		public override string ToolName() => "PurgeTemporaryDiagrams";

		/// <summary>
		/// <para>Tool Excute Name : nd.PurgeTemporaryDiagrams</para>
		/// </summary>
		public override string ExcuteName() => "nd.PurgeTemporaryDiagrams";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, CreatedBefore, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>带有要清除的临时逻辑示意图的 公共设施网络或追踪网络 数据元素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Created Before</para>
		/// <para>清除临时网络逻辑示意图的截止日期。将清除在此日期之前创建的所有临时网络逻辑示意图。</para>
		/// <para>默认情况下，此对话框中的日期为当前日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object CreatedBefore { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

	}
}
