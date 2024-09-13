using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Calculate Density</para>
	/// <para>计算密度</para>
	/// <para>通过在地图范围内扩展某一现象（表示为点或线的属性）的已知量，根据点要素或线要素创建密度图。结果是按密度从小到大分类的面图层。</para>
	/// </summary>
	public class CalculateDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Features</para>
		/// <para>从中计算密度的点或线要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public CalculateDensity(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算密度</para>
		/// </summary>
		public override string DisplayName() => "计算密度";

		/// <summary>
		/// <para>Tool Name : CalculateDensity</para>
		/// </summary>
		public override string ToolName() => "CalculateDensity";

		/// <summary>
		/// <para>Tool Excute Name : sfa.CalculateDensity</para>
		/// </summary>
		public override string ExcuteName() => "sfa.CalculateDensity";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Outputname, Field!, Cellsize!, Cellsizeunits!, Radius!, Radiusunits!, Boundingpolygonlayer!, Areaunits!, Classificationtype!, Numclasses!, Outputlayer! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>从中计算密度的点或线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Count Field</para>
		/// <para>用于指定每个位置处的事件点数量的字段。例如，如果您具有表示城市的点，则可以将表示城市人口的字段作为计数字段，得到的人口密度图层将用于计算邻近较多人口城市的较大人口密度。</para>
		/// <para>如果未指定，则假定每个位置代表一个计数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>该值用于创建从中计算密度值的点网格。默认值约为上下文参数中定义的分析范围的宽度和高度中较小者的 1/1000。该值越小，面边界越平滑。相反，该值越大，面边界越粗糙和参差不齐。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Additional Options")]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Cell Size Units</para>
		/// <para>像元大小值的单位。如果已设置像元大小，则必须为其赋值。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para><see cref="CellsizeunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Cellsizeunits { get; set; }

		/// <summary>
		/// <para>Radius</para>
		/// <para>用于指定计算密度值时查找点要素或线要素搜索距离的距离。例如，如果您提供的搜索距离是 1,800 米，则输出图层中任意位置的密度将根据距此位置 1,800 米范围内的要素进行计算。在 1,800 米范围内任何不具有事件点的位置得到的密度值将为零。</para>
		/// <para>如果未提供距离，则将根据输入要素的位置和计数字段中的值（如果已提供计数字段）计算默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Additional Options")]
		public object? Radius { get; set; }

		/// <summary>
		/// <para>Radius Units</para>
		/// <para>半径值单位。如果已设置半径，则必须为其赋值。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para><see cref="RadiusunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Radiusunits { get; set; }

		/// <summary>
		/// <para>Bounding Polygons</para>
		/// <para>用于指定要计算其密度的面的图层。例如，如果您要对湖中鱼的密度进行插值，则可以使用此参数中湖的边界，使输出结果仅在湖的边界内绘制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Additional Options")]
		public object? Boundingpolygonlayer { get; set; }

		/// <summary>
		/// <para>Area Units</para>
		/// <para>所计算密度值的单位。</para>
		/// <para>平方英里—平方英里</para>
		/// <para>平方千米—平方千米</para>
		/// <para><see cref="AreaunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Areaunits { get; set; } = "SQUAREMILES";

		/// <summary>
		/// <para>Classification Type</para>
		/// <para>确定将密度值划分到面的方法。</para>
		/// <para>相等间隔— 将以每个区域的密度值范围相等的方式创建面。</para>
		/// <para>几何间隔— 面基于具有几何系列的分类间隔。此方法可确保每个类范围与每个类中所拥有的值的数量大致相同，且间隔之间的变化一致。</para>
		/// <para>自然间断点— 面的分类间隔基于数据的自然分组。将识别出能够对类似的值进行最恰当地分组并使各类之间的差异最大化的分类间隔值。</para>
		/// <para>等积— 将以各个区域大小相等的方式创建面。例如，如果结果的高密度值多于低密度值，则会为高密度创建更多面。</para>
		/// <para>标准差— 面将根据预测密度值的标准差进行创建。</para>
		/// <para><see cref="ClassificationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Classificationtype { get; set; } = "EQUALINTERVAL";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>该值用于将预测值范围划分为不同的类。每个类中值的范围由分类类型决定。每个类定义结果面的边界。</para>
		/// <para>默认值为 10，最大值为 32。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 32)]
		[Category("Additional Options")]
		public object? Numclasses { get; set; } = "10";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputlayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDensity SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Size Units</para>
		/// </summary>
		public enum CellsizeunitsEnum 
		{
			/// <summary>
			/// <para>英里—英里</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>英尺—英尺</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>千米—千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

		}

		/// <summary>
		/// <para>Radius Units</para>
		/// </summary>
		public enum RadiusunitsEnum 
		{
			/// <summary>
			/// <para>英里—英里</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>英尺—英尺</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>千米—千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

		}

		/// <summary>
		/// <para>Area Units</para>
		/// </summary>
		public enum AreaunitsEnum 
		{
			/// <summary>
			/// <para>平方英里—平方英里</para>
			/// </summary>
			[GPValue("SQUAREMILES")]
			[Description("平方英里")]
			Square_miles,

			/// <summary>
			/// <para>平方千米—平方千米</para>
			/// </summary>
			[GPValue("SQUAREKILOMETERS")]
			[Description("平方千米")]
			Square_kilometers,

		}

		/// <summary>
		/// <para>Classification Type</para>
		/// </summary>
		public enum ClassificationtypeEnum 
		{
			/// <summary>
			/// <para>相等间隔— 将以每个区域的密度值范围相等的方式创建面。</para>
			/// </summary>
			[GPValue("EQUALINTERVAL")]
			[Description("相等间隔")]
			Equal_interval,

			/// <summary>
			/// <para>几何间隔— 面基于具有几何系列的分类间隔。此方法可确保每个类范围与每个类中所拥有的值的数量大致相同，且间隔之间的变化一致。</para>
			/// </summary>
			[GPValue("GEOMETRICINTERVAL")]
			[Description("几何间隔")]
			Geometric_interval,

			/// <summary>
			/// <para>自然间断点— 面的分类间隔基于数据的自然分组。将识别出能够对类似的值进行最恰当地分组并使各类之间的差异最大化的分类间隔值。</para>
			/// </summary>
			[GPValue("NATURALBREAKS")]
			[Description("自然间断点")]
			Natural_breaks,

			/// <summary>
			/// <para>等积— 将以各个区域大小相等的方式创建面。例如，如果结果的高密度值多于低密度值，则会为高密度创建更多面。</para>
			/// </summary>
			[GPValue("EQUALAREA")]
			[Description("等积")]
			Equal_area,

			/// <summary>
			/// <para>标准差— 面将根据预测密度值的标准差进行创建。</para>
			/// </summary>
			[GPValue("STANDARDDEVIATION")]
			[Description("标准差")]
			Standard_deviation,

		}

#endregion
	}
}
