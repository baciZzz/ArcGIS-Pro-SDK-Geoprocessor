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
	/// <para>Summarize Elevation</para>
	/// <para>汇总高程</para>
	/// <para>计算各个输入要素的高程汇总统计数据。</para>
	/// </summary>
	public class SummarizeElevation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputfeatures">
		/// <para>Input Features</para>
		/// <para>要为其汇总高程的输入点、线或面要素。</para>
		/// </param>
		public SummarizeElevation(object Inputfeatures)
		{
			this.Inputfeatures = Inputfeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总高程</para>
		/// </summary>
		public override string DisplayName() => "汇总高程";

		/// <summary>
		/// <para>Tool Name : SummarizeElevation</para>
		/// </summary>
		public override string ToolName() => "SummarizeElevation";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.SummarizeElevation</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.SummarizeElevation";

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
		public override object[] Parameters() => new object[] { Inputfeatures, Featureidfield!, Demresolution!, Includeslopeaspect!, Outputsummary! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要为其汇总高程的输入点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputfeatures { get; set; }

		/// <summary>
		/// <para>Feature ID Field</para>
		/// <para>用于输入要素的唯一 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Featureidfield { get; set; }

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>指定用于计算的源高程数据的近似空间分辨率（像元大小）。</para>
		/// <para>分辨率关键字是数字高程模型空间分辨率的近似值。 许多高程源以弧秒为单位进行分布；关键字是以米为单位的近似值更方便理解。</para>
		/// <para>最精细—适用于所使用范围的最精细单位。</para>
		/// <para>10 米—高程源分辨率为 1/3 弧秒，或大约 10 米。</para>
		/// <para>24 米—高程源是分辨率为 24 米的 Airbus WorldDEM4Ortho 数据集。</para>
		/// <para>30 米—高程源分辨率为 1 弧秒，或大约 30 米。</para>
		/// <para>90 米—高程源分辨率为 3 弧秒，或大约 90 米。 这是默认设置。</para>
		/// <para><see cref="DemresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Demresolution { get; set; }

		/// <summary>
		/// <para>Include Slope and Aspect</para>
		/// <para>指定除了高程值之外是否还在输出中包含输入要素的坡度和坡向值。</para>
		/// <para>选中 - 输出中将包含坡度和坡向值。</para>
		/// <para>未选中 - 输出中不会包含坡度和坡向值。 这是默认设置。</para>
		/// <para><see cref="IncludeslopeaspectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Includeslopeaspect { get; set; } = "false";

		/// <summary>
		/// <para>Output Summary</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputsummary { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>DEM Resolution</para>
		/// </summary>
		public enum DemresolutionEnum 
		{
			/// <summary>
			/// <para>最精细—适用于所使用范围的最精细单位。</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("最精细")]
			Finest,

			/// <summary>
			/// <para>10 米—高程源分辨率为 1/3 弧秒，或大约 10 米。</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 米")]
			_10_meters,

			/// <summary>
			/// <para>24 米—高程源是分辨率为 24 米的 Airbus WorldDEM4Ortho 数据集。</para>
			/// </summary>
			[GPValue("24m")]
			[Description("24 米")]
			_24_meters,

			/// <summary>
			/// <para>30 米—高程源分辨率为 1 弧秒，或大约 30 米。</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 米")]
			_30_meters,

			/// <summary>
			/// <para>90 米—高程源分辨率为 3 弧秒，或大约 90 米。 这是默认设置。</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 米")]
			_90_meters,

		}

		/// <summary>
		/// <para>Include Slope and Aspect</para>
		/// </summary>
		public enum IncludeslopeaspectEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SLOPE_ASPECT")]
			SLOPE_ASPECT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SLOPE_ASPECT")]
			NO_SLOPE_ASPECT,

		}

#endregion
	}
}
