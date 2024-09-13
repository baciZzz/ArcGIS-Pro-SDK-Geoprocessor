using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Trace Downstream</para>
	/// <para>追踪下游</para>
	/// <para>确定水从某一特定位置流入最远处下坡位置所流经的路径。</para>
	/// </summary>
	public class TraceDownstream : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpoints">
		/// <para>Input Points</para>
		/// <para>用于计算下游追踪的点要素。</para>
		/// </param>
		public TraceDownstream(object Inputpoints)
		{
			this.Inputpoints = Inputpoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 追踪下游</para>
		/// </summary>
		public override string DisplayName() => "追踪下游";

		/// <summary>
		/// <para>Tool Name : TraceDownstream</para>
		/// </summary>
		public override string ToolName() => "TraceDownstream";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.TraceDownstream</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.TraceDownstream";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpoints, Pointidfield!, Datasourceresolution!, Generalize!, Outputtraceline! };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>用于计算下游追踪的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputpoints { get; set; }

		/// <summary>
		/// <para>Point ID Field</para>
		/// <para>用于标识输入点的整数或字符串字段。</para>
		/// <para>默认使用唯一 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Pointidfield { get; set; }

		/// <summary>
		/// <para>Data Source Resolution</para>
		/// <para>指定将用于分析的源数据分辨率。 这些值是用于构建基础水文数据库的数字高程模型的空间分辨率近似值。 由于许多高程源以弧秒为单位进行分布，为了更方便理解，我们提供了以米为单位的近似值。</para>
		/// <para>空—将使用基于 3 弧秒的数据源（分辨率大约为 90 米的高程数据）构建的水文源。 这是默认设置。</para>
		/// <para>最精细—将使用所有可能数据源的每个位置的最佳可用分辨率。</para>
		/// <para>10 米—将使用基于 1/3 弧秒的数据源（分辨率大约为 10 米的高程数据）构建的水文源。</para>
		/// <para>30 米—将使用基于 1 弧秒的数据源（分辨率大约为 30 米的高程数据）构建的水文源。</para>
		/// <para>90 米—将使用基于 3 弧秒的数据源（分辨率大约为 90 米的高程数据）构建的水文源。</para>
		/// <para><see cref="DatasourceresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Datasourceresolution { get; set; } = " ";

		/// <summary>
		/// <para>Generalize</para>
		/// <para>指定是将输出下游追踪线平滑处理为更简单的线还是将其与原始 DEM 的像元中心保持一致。</para>
		/// <para>未选中 - 线条不会被平滑。 输出下游追踪线的每条追踪线都有更多的折点，因为它们与原始 DEM 像元中心保持一致。 这是默认设置。</para>
		/// <para>选中 - 将线平滑处理为更简单的线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? Generalize { get; set; } = "false";

		/// <summary>
		/// <para>Output Trace Line</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputtraceline { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Data Source Resolution</para>
		/// </summary>
		public enum DatasourceresolutionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue(" ")]
			[Description(" ")]
			_,

			/// <summary>
			/// <para>最精细—将使用所有可能数据源的每个位置的最佳可用分辨率。</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("最精细")]
			Finest,

			/// <summary>
			/// <para>10 米—将使用基于 1/3 弧秒的数据源（分辨率大约为 10 米的高程数据）构建的水文源。</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 米")]
			_10_meters,

			/// <summary>
			/// <para>30 米—将使用基于 1 弧秒的数据源（分辨率大约为 30 米的高程数据）构建的水文源。</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 米")]
			_30_meters,

			/// <summary>
			/// <para>90 米—将使用基于 3 弧秒的数据源（分辨率大约为 90 米的高程数据）构建的水文源。</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 米")]
			_90_meters,

		}

#endregion
	}
}
