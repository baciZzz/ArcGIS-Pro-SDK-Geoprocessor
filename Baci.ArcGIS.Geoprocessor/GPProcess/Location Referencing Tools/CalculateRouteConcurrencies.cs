using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Calculate Route Concurrencies</para>
	/// <para>计算路径并发</para>
	/// <para>计算和报告 LRS 网络中的并发路径弧段。</para>
	/// </summary>
	public class CalculateRouteConcurrencies : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>将在其中计算路径并发的 LRS 网络要素类。</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset</para>
		/// <para>计算结果将发布到的要素类或表。</para>
		/// </param>
		public CalculateRouteConcurrencies(object InRouteFeatures, object OutDataset)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.OutDataset = OutDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算路径并发</para>
		/// </summary>
		public override string DisplayName() => "计算路径并发";

		/// <summary>
		/// <para>Tool Name : CalculateRouteConcurrencies</para>
		/// </summary>
		public override string ToolName() => "CalculateRouteConcurrencies";

		/// <summary>
		/// <para>Tool Excute Name : locref.CalculateRouteConcurrencies</para>
		/// </summary>
		public override string ExcuteName() => "locref.CalculateRouteConcurrencies";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, OutDataset, Tvd!, FindDominance!, IncludeGeometry! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>将在其中计算路径并发的 LRS 网络要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>计算结果将发布到的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Temporal View Date</para>
		/// <para>网络的时态视图日期（如果已指定）。 将此字段留空可以显示所有时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? Tvd { get; set; }

		/// <summary>
		/// <para>Set route dominance based on priority rules</para>
		/// <para>指定是否使用配置的路径优先级规则来设置优先级。</para>
		/// <para>选中 - 将使用配置的路径优先级规则来确定每个并发弧段中的主要路径。 这是默认设置。</para>
		/// <para>未选中 - 不会使用配置的路径优先级规则来确定每个并发弧段中的主要路径。</para>
		/// <para><see cref="FindDominanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FindDominance { get; set; } = "true";

		/// <summary>
		/// <para>Include Geometry</para>
		/// <para>指定输出数据集中是否包含几何。</para>
		/// <para>选中 - 输出数据集中将包含几何。</para>
		/// <para>未选中 - 结果中将不包含几何。 这是默认设置。</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateRouteConcurrencies SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Set route dominance based on priority rules</para>
		/// </summary>
		public enum FindDominanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DOMINANCE")]
			FIND_DOMINANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIND_DOMINANCE")]
			NO_FIND_DOMINANCE,

		}

		/// <summary>
		/// <para>Include Geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

#endregion
	}
}
