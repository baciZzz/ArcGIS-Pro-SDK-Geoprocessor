using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>GA Layer To Contour</para>
	/// <para>GA 图层转等值线</para>
	/// <para>在地统计图层中创建等值线要素类。输出要素类可以是由等值线构成的线要素类，或由填充的等值线构成的面要素类。</para>
	/// </summary>
	public class GALayerToContour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </param>
		/// <param name="ContourType">
		/// <para>Contour type</para>
		/// <para>表示地统计图层的等值线类型。</para>
		/// <para>等值线— 用等值线或等高线表示地统计图层。可按草稿质量或显示质量显示线。</para>
		/// <para>填充的等值线—用面表示地统计图层。假设图形显示的等值线之间的值在面范围内的所有位置都是相同的。可按草稿质量或显示质量显示线。</para>
		/// <para>与图层相同—使用输入地统计图层的当前渲染器。</para>
		/// <para><see cref="ContourTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>输出要素类可以是折线或面，具体取决于所选的等值线类型。</para>
		/// </param>
		public GALayerToContour(object InGeostatLayer, object ContourType, object OutFeatureClass)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.ContourType = ContourType;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GA 图层转等值线</para>
		/// </summary>
		public override string DisplayName() => "GA 图层转等值线";

		/// <summary>
		/// <para>Tool Name : GALayerToContour</para>
		/// </summary>
		public override string ToolName() => "GALayerToContour";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToContour</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayerToContour";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, ContourType, OutFeatureClass, ContourQuality, ClassificationType, ClassesCount, ClassesBreaks, OutElevation };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Contour type</para>
		/// <para>表示地统计图层的等值线类型。</para>
		/// <para>等值线— 用等值线或等高线表示地统计图层。可按草稿质量或显示质量显示线。</para>
		/// <para>填充的等值线—用面表示地统计图层。假设图形显示的等值线之间的值在面范围内的所有位置都是相同的。可按草稿质量或显示质量显示线。</para>
		/// <para>与图层相同—使用输入地统计图层的当前渲染器。</para>
		/// <para><see cref="ContourTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourType { get; set; } = "SAME_AS_LAYER";

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>输出要素类可以是折线或面，具体取决于所选的等值线类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Contour quality</para>
		/// <para>确定等值线制图表达的平滑度。</para>
		/// <para>草稿— 默认的质量选项为“草稿”，即显示一条概化版本的等值线以获得较快的显示。</para>
		/// <para>演示—“显示”选项可确保为输出要素类显示更为精细的等值线。</para>
		/// <para><see cref="ContourQualityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourQuality { get; set; } = "DRAFT";

		/// <summary>
		/// <para>Classification type</para>
		/// <para>指定如何计算等值线间隔。</para>
		/// <para>几何间隔—根据几何间隔计算等值线间隔。</para>
		/// <para>相等间隔—根据相等间隔计算等值线间隔。</para>
		/// <para>分位数—根据输入数据的分位数计算等值线间隔。</para>
		/// <para>手动—指定您自己的中断值。</para>
		/// <para><see cref="ClassificationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Classification")]
		public object ClassificationType { get; set; } = "GEOMETRIC_INTERVAL";

		/// <summary>
		/// <para>Number of classes</para>
		/// <para>指定输出要素类的类数。</para>
		/// <para>如果将等值线类型设置为输出填充的等值线面，则创建的面数将等于该参数中指定的值。如果将其设置为输出等值线折线，则折线数将比该参数中指定的值少一个（因为 N 个类间隔定义 N-1 个等值线中断值）。</para>
		/// <para>如果将分类类型设置为手动，则该参数将不适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 256)]
		[Category("Classification")]
		public object ClassesCount { get; set; } = "10";

		/// <summary>
		/// <para>Class breaks</para>
		/// <para>将分类类型设置为手动时的中断值列表。</para>
		/// <para>对于等值线输出，这些值为等值线的值。</para>
		/// <para>对于填充的等值线，这些值为每个类间隔的上限。请注意，如果最大中断值小于地统计图层最大值，输出要素类将不会填满整个矩形范围；预测值大于最大中断值的所有位置都不会接收填充的等值线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Classification")]
		public object ClassesBreaks { get; set; }

		/// <summary>
		/// <para>Output elevation</para>
		/// <para>对于 3D 插值模型，可以导出任何高程处的等值线。可以使用此参数来指定要导出的高程。如果留空，则将从输入图层继承高程。单位将默认为输入图层的相同单位。</para>
		/// <para><see cref="OutElevationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object OutElevation { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToContour SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contour type</para>
		/// </summary>
		public enum ContourTypeEnum 
		{
			/// <summary>
			/// <para>与图层相同—使用输入地统计图层的当前渲染器。</para>
			/// </summary>
			[GPValue("SAME_AS_LAYER")]
			[Description("与图层相同")]
			Same_as_layer,

			/// <summary>
			/// <para>等值线— 用等值线或等高线表示地统计图层。可按草稿质量或显示质量显示线。</para>
			/// </summary>
			[GPValue("CONTOUR")]
			[Description("等值线")]
			Contour,

			/// <summary>
			/// <para>填充的等值线—用面表示地统计图层。假设图形显示的等值线之间的值在面范围内的所有位置都是相同的。可按草稿质量或显示质量显示线。</para>
			/// </summary>
			[GPValue("FILLED_CONTOUR")]
			[Description("填充的等值线")]
			Filled_contour,

		}

		/// <summary>
		/// <para>Contour quality</para>
		/// </summary>
		public enum ContourQualityEnum 
		{
			/// <summary>
			/// <para>草稿— 默认的质量选项为“草稿”，即显示一条概化版本的等值线以获得较快的显示。</para>
			/// </summary>
			[GPValue("DRAFT")]
			[Description("草稿")]
			Draft,

			/// <summary>
			/// <para>演示—“显示”选项可确保为输出要素类显示更为精细的等值线。</para>
			/// </summary>
			[GPValue("PRESENTATION")]
			[Description("演示")]
			Presentation,

		}

		/// <summary>
		/// <para>Classification type</para>
		/// </summary>
		public enum ClassificationTypeEnum 
		{
			/// <summary>
			/// <para>几何间隔—根据几何间隔计算等值线间隔。</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("几何间隔")]
			Geometric_interval,

			/// <summary>
			/// <para>相等间隔—根据相等间隔计算等值线间隔。</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("相等间隔")]
			Equal_interval,

			/// <summary>
			/// <para>分位数—根据输入数据的分位数计算等值线间隔。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

			/// <summary>
			/// <para>手动—指定您自己的中断值。</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("手动")]
			Manual,

		}

		/// <summary>
		/// <para>Output elevation</para>
		/// </summary>
		public enum OutElevationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Millimeters")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

#endregion
	}
}
