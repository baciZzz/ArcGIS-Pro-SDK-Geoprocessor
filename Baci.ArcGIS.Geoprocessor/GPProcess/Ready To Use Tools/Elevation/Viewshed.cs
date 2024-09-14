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
	/// <para>Viewshed</para>
	/// <para>视域</para>
	/// <para>针对给定的输入观察点集，返回可见区域多边形。</para>
	/// </summary>
	public class Viewshed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpoints">
		/// <para>Input Point Features</para>
		/// <para>用作观察点位置的点要素。</para>
		/// </param>
		public Viewshed(object Inputpoints)
		{
			this.Inputpoints = Inputpoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 视域</para>
		/// </summary>
		public override string DisplayName() => "视域";

		/// <summary>
		/// <para>Tool Name : 视域</para>
		/// </summary>
		public override string ToolName() => "视域";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.Viewshed</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.Viewshed";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpoints, Maximumdistance, Maximumdistanceunits, Demresolution, Observerheight, Observerheightunits, Surfaceoffset, Surfaceoffsetunits, Generalizeviewshedpolygons, Outputviewshed };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>用作观察点位置的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputpoints { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>用于计算视域的最大距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Maximumdistance { get; set; }

		/// <summary>
		/// <para>Maximum Distance Units</para>
		/// <para>指定最大距离参数的单位。</para>
		/// <para>米—单位为米。 这是默认设置。</para>
		/// <para>千米—单位为千米。</para>
		/// <para>英尺—单位为英尺。</para>
		/// <para>码—单位为码。</para>
		/// <para>英里—单位为英里。</para>
		/// <para><see cref="MaximumdistanceunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Maximumdistanceunits { get; set; } = "Meters";

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
		public object Demresolution { get; set; }

		/// <summary>
		/// <para>Observer Height</para>
		/// <para>观察点表面以上的高度。默认值 1.75 米是人的平均身高。如果您要从较高位置（如瞭望塔或高建筑物）进行观察，请使用该高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Observerheight { get; set; } = "1.75";

		/// <summary>
		/// <para>Observer Height Units</para>
		/// <para>指定观察点高度参数的单位。</para>
		/// <para>米—单位为米。 这是默认设置。</para>
		/// <para>千米—单位为千米。</para>
		/// <para>英尺—单位为英尺。</para>
		/// <para>码—单位为码。</para>
		/// <para>英里—单位为英里。</para>
		/// <para><see cref="ObserverheightunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Observerheightunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Surface Offset</para>
		/// <para>正在查看的对象表面上方的高度。默认值为 0。如果正在查看建筑物或风力涡轮机，则使用其高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Surfaceoffset { get; set; } = "0";

		/// <summary>
		/// <para>Surface Offset Units</para>
		/// <para>指定表面偏移参数的单位。</para>
		/// <para>米—单位为米。 这是默认设置。</para>
		/// <para>千米—单位为千米。</para>
		/// <para>英尺—单位为英尺。</para>
		/// <para>码—单位为码。</para>
		/// <para>英里—单位为英里。</para>
		/// <para><see cref="SurfaceoffsetunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Surfaceoffsetunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Generalize Viewshed Polygons</para>
		/// <para>指定是否对视域面进行概化。</para>
		/// <para>视域计算基于栅格高程模型，以创建带阶梯状边缘的结果。要创建更美观的外观并提高性能，则默认行为是概化面。对于超过 DEM 分辨率一半的所有地点，这种概化将不会更改结果的准确性。</para>
		/// <para>选中 - 将概化视域面。这是默认设置。</para>
		/// <para>未选中 - 不会概化视域面。</para>
		/// <para><see cref="GeneralizeviewshedpolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Generalizeviewshedpolygons { get; set; } = "true";

		/// <summary>
		/// <para>Output Viewshed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputviewshed { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Maximum Distance Units</para>
		/// </summary>
		public enum MaximumdistanceunitsEnum 
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
		/// <para>Observer Height Units</para>
		/// </summary>
		public enum ObserverheightunitsEnum 
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

		/// <summary>
		/// <para>Surface Offset Units</para>
		/// </summary>
		public enum SurfaceoffsetunitsEnum 
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

		/// <summary>
		/// <para>Generalize Viewshed Polygons</para>
		/// </summary>
		public enum GeneralizeviewshedpolygonsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERALIZE")]
			GENERALIZE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERALIZE")]
			NO_GENERALIZE,

		}

#endregion
	}
}
