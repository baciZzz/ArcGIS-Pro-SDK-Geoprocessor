using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Strip Map Index Features</para>
	/// <para>带状地图索引要素</para>
	/// <para>该工具可根据单个线状要素或一组线状要素创建一系列矩形面或索引要素。这些索引要素可与空间地图系列结合使用，以便根据线状要素定义一幅带状地图或一组地图中的页面。生成的索引要素中包含可在页面上旋转及定向地图的属性，还包含决定哪些索引要素或页面与当前页面相邻（左右侧或上下侧）的属性。</para>
	/// </summary>
	public class StripMapIndexFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Line Features</para>
		/// <para>定义带状地图索引要素路径的输入折线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>面索引要素的输出要素类。</para>
		/// </param>
		public StripMapIndexFeatures(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 带状地图索引要素</para>
		/// </summary>
		public override string DisplayName() => "带状地图索引要素";

		/// <summary>
		/// <para>Tool Name : StripMapIndexFeatures</para>
		/// </summary>
		public override string ToolName() => "StripMapIndexFeatures";

		/// <summary>
		/// <para>Tool Excute Name : cartography.StripMapIndexFeatures</para>
		/// </summary>
		public override string ExcuteName() => "cartography.StripMapIndexFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, UsePageUnit!, Scale!, LengthAlongLine!, LengthPerpendicularToLine!, PageOrientation!, OverlapPercentage!, StartingPageNumber!, DirectionType! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>定义带状地图索引要素路径的输入折线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>面索引要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// <para>指定索引要素的大小输入是否使用页面单位。</para>
		/// <para>已选中 - 索引面的高度和宽度使用页面单位来计算。</para>
		/// <para>未选中 - 索引面的高度和宽度使用地图单位来计算。这是默认设置。</para>
		/// <para><see cref="UsePageUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UsePageUnit { get; set; } = "false";

		/// <summary>
		/// <para>Map Scale</para>
		/// <para>如果要以页面单位计算索引要素的长度（沿线长度和垂直于线的长度），则必须指定地图比例。如果正在使用 ArcGIS Pro，则默认值将为活动数据框的比例；否则，默认值将为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? Scale { get; set; }

		/// <summary>
		/// <para>Length Along the Line</para>
		/// <para>沿以地图单位或页面单位指定的输入线要素方向的面索引要素长度。默认值由输入的一个或多个线要素的空间参考决定。该值为 x 轴方向上输入要素类长度的 1/100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LengthAlongLine { get; set; } = "2 DecimalDegrees";

		/// <summary>
		/// <para>Length Perpendicular to the Line</para>
		/// <para>垂直于以地图单位或页面单位指定的输入线要素的面索引要素长度。默认值由输入的一个或多个线要素的空间参考决定。该值为沿线方向要素长度的一半。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LengthPerpendicularToLine { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Page Orientation</para>
		/// <para>指定布局页面上输入线要素的方向。</para>
		/// <para>竖直—页面上带状地图系列的方向为从上至下。</para>
		/// <para>水平—页面上带状地图系列的方向为从左至右。这是默认设置。</para>
		/// <para><see cref="PageOrientationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PageOrientation { get; set; } = "HORIZONTAL";

		/// <summary>
		/// <para>Percentage of Overlap</para>
		/// <para>系列中单个地图页面与其相邻页面之间地理叠加的近似百分比。默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 20)]
		public object? OverlapPercentage { get; set; } = "10";

		/// <summary>
		/// <para>Starting Page Number</para>
		/// <para>起始页的页码。各格网索引要素将分配到连续的页码，起始页码需要指定。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object? StartingPageNumber { get; set; } = "1";

		/// <summary>
		/// <para>Strip Map Direction</para>
		/// <para>指定带状地图的初始方向。</para>
		/// <para>自西向东和自北向南—如果线的方向趋势是自西向东，则起点将在线的最西端；如果线的方向趋势是自北向南，则起点将在线的最北端。这是默认设置。</para>
		/// <para>自西向东和自南向北—如果线的方向趋势是自西向东，则起点将在线的最西端；如果线的方向趋势是自南向北，则起点将在线的最南端。</para>
		/// <para>自东向西和自北向南—如果线的方向趋势是自东向西，则起点将在线的最东端；如果线的方向趋势是自北向南，则起点将在线的最北端。</para>
		/// <para>自东向西和自南向北—如果线的方向趋势是自东向西，则起点将在线的最东端；如果线的方向趋势是自南向北，则起点将在线的最南端。</para>
		/// <para><see cref="DirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DirectionType { get; set; } = "WE_NS";

		#region InnerClass

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// </summary>
		public enum UsePageUnitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USEPAGEUNIT")]
			USEPAGEUNIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USEPAGEUNIT")]
			NO_USEPAGEUNIT,

		}

		/// <summary>
		/// <para>Page Orientation</para>
		/// </summary>
		public enum PageOrientationEnum 
		{
			/// <summary>
			/// <para>水平—页面上带状地图系列的方向为从左至右。这是默认设置。</para>
			/// </summary>
			[GPValue("HORIZONTAL")]
			[Description("水平")]
			Horizontal,

			/// <summary>
			/// <para>竖直—页面上带状地图系列的方向为从上至下。</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("竖直")]
			Vertical,

		}

		/// <summary>
		/// <para>Strip Map Direction</para>
		/// </summary>
		public enum DirectionTypeEnum 
		{
			/// <summary>
			/// <para>自西向东和自北向南—如果线的方向趋势是自西向东，则起点将在线的最西端；如果线的方向趋势是自北向南，则起点将在线的最北端。这是默认设置。</para>
			/// </summary>
			[GPValue("WE_NS")]
			[Description("自西向东和自北向南")]
			West_to_East_and_North_to_South,

			/// <summary>
			/// <para>自西向东和自南向北—如果线的方向趋势是自西向东，则起点将在线的最西端；如果线的方向趋势是自南向北，则起点将在线的最南端。</para>
			/// </summary>
			[GPValue("WE_SN")]
			[Description("自西向东和自南向北")]
			West_to_East_and_South_to_North,

			/// <summary>
			/// <para>自东向西和自北向南—如果线的方向趋势是自东向西，则起点将在线的最东端；如果线的方向趋势是自北向南，则起点将在线的最北端。</para>
			/// </summary>
			[GPValue("EW_NS")]
			[Description("自东向西和自北向南")]
			East_to_West_and_North_to_South,

			/// <summary>
			/// <para>自东向西和自南向北—如果线的方向趋势是自东向西，则起点将在线的最东端；如果线的方向趋势是自南向北，则起点将在线的最南端。</para>
			/// </summary>
			[GPValue("EW_SN")]
			[Description("自东向西和自南向北")]
			East_to_West_and_South_to_North,

		}

#endregion
	}
}
