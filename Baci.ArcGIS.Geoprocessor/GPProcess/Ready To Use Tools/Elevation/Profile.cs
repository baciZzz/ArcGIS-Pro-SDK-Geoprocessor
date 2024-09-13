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
	/// <para>Profile</para>
	/// <para>专用标准</para>
	/// <para>返回输入线要素的高程剖面。</para>
	/// </summary>
	public class Profile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlinefeatures">
		/// <para>Input Line Features</para>
		/// <para>将在表面输入上描绘剖面的线要素。</para>
		/// </param>
		public Profile(object Inputlinefeatures)
		{
			this.Inputlinefeatures = Inputlinefeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 专用标准</para>
		/// </summary>
		public override string DisplayName() => "专用标准";

		/// <summary>
		/// <para>Tool Name : 专用标准</para>
		/// </summary>
		public override string ToolName() => "专用标准";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.Profile</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.Profile";

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
		public override object[] Parameters() => new object[] { Inputlinefeatures, Profileidfield, Demresolution, Maximumsampledistance, Maximumsampledistanceunits, Outputprofile };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>将在表面输入上描绘剖面的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlinefeatures { get; set; }

		/// <summary>
		/// <para>Profile ID Field</para>
		/// <para>将剖面与其对应的输入线要素关联的唯一标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Profileidfield { get; set; }

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>指定用于计算的源高程数据的近似空间分辨率（像元大小）。</para>
		/// <para>分辨率关键字是数字高程模型空间分辨率的近似值。 许多高程源以弧秒为单位进行分布；关键字是以米为单位的近似值更方便理解。</para>
		/// <para>最精细—适用于所使用范围的最精细单位。</para>
		/// <para>10 米—高程源分辨率为 1/3 弧秒，或大约 10 米。</para>
		/// <para>24 米—高程源是分辨率为 24 米的 Airbus WorldDEM4Ortho 数据集。</para>
		/// <para>30 米—高程源分辨率为 1 弧秒，或大约 30 米。</para>
		/// <para>90 米—高程源分辨率为 3 弧秒，或大约 90 米。 这是默认设置。</para>
		/// <para>500 米—高程源分辨率为 15 弧秒，或大约 500 米。</para>
		/// <para>1000 米—高程源分辨率为 30 弧秒，或大约 1000 米。</para>
		/// <para><see cref="DemresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Demresolution { get; set; }

		/// <summary>
		/// <para>Maximum Sample Distance</para>
		/// <para>沿线采样高程值的最大采样距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Maximumsampledistance { get; set; }

		/// <summary>
		/// <para>Maximum Sample Distance Units</para>
		/// <para>指定最大采样距离参数的单位。</para>
		/// <para>米—单位为米。 这是默认设置。</para>
		/// <para>千米—单位为千米。</para>
		/// <para>英尺—单位为英尺。</para>
		/// <para>码—单位为码。</para>
		/// <para>英里—单位为英里。</para>
		/// <para><see cref="MaximumsampledistanceunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Maximumsampledistanceunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Output Profile</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputprofile { get; set; }

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

			/// <summary>
			/// <para>500 米—高程源分辨率为 15 弧秒，或大约 500 米。</para>
			/// </summary>
			[GPValue("500m")]
			[Description("500 米")]
			_500_meters,

			/// <summary>
			/// <para>1000 米—高程源分辨率为 30 弧秒，或大约 1000 米。</para>
			/// </summary>
			[GPValue("1000m")]
			[Description("1000 米")]
			_1000_meters,

		}

		/// <summary>
		/// <para>Maximum Sample Distance Units</para>
		/// </summary>
		public enum MaximumsampledistanceunitsEnum 
		{
			/// <summary>
			/// <para>米—单位为米。 这是默认设置。</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—单位为千米。</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—单位为英尺。</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—单位为码。</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英里—单位为英里。</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

		}

#endregion
	}
}
