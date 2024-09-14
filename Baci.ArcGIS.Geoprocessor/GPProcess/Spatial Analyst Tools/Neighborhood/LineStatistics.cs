using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Line Statistics</para>
	/// <para>线统计</para>
	/// <para>计算每个输出像元周围圆形邻域中线属性的统计信息。</para>
	/// </summary>
	public class LineStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolylineFeatures">
		/// <para>Input polyline features</para>
		/// <para>要在每个输出像元周围的邻域中计算统计数据的输入折线要素。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>将要计算指定统计数据的字段。 它可以是输入要素的任何数值字段。</para>
		/// <para>当统计类型设置为长度时，字段参数可被设置为“无”。</para>
		/// <para>如果输入要素包含 z 值，则它可以是 Shape 字段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出先统计数据栅格。</para>
		/// </param>
		public LineStatistics(object InPolylineFeatures, object Field, object OutRaster)
		{
			this.InPolylineFeatures = InPolylineFeatures;
			this.Field = Field;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 线统计</para>
		/// </summary>
		public override string DisplayName() => "线统计";

		/// <summary>
		/// <para>Tool Name : LineStatistics</para>
		/// </summary>
		public override string ToolName() => "LineStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.LineStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.LineStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolylineFeatures, Field, OutRaster, CellSize, SearchRadius, StatisticsType };

		/// <summary>
		/// <para>Input polyline features</para>
		/// <para>要在每个输出像元周围的邻域中计算统计数据的输入折线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Polyline")]
		public object InPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>将要计算指定统计数据的字段。 它可以是输入要素的任何数值字段。</para>
		/// <para>当统计类型设置为长度时，字段参数可被设置为“无”。</para>
		/// <para>如果输入要素包含 z 值，则它可以是 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出先统计数据栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Search radius</para>
		/// <para>要在其中计算所需统计数据的搜索半径，以地图单位为单位。</para>
		/// <para>默认半径是输出像元大小的五倍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>用于指定要计算的统计数据类型。</para>
		/// <para>根据邻域内所有行的指定字段的值计算统计数据。</para>
		/// <para>平均值—计算每个邻域中字段值的平均值，并根据长度进行加权。计算公式为：仅使用位于邻域内的长度的部分。</para>
		/// <para>均值 =（（长度 × 字段值）总和）/（长度总和）</para>
		/// <para>众数—确定在邻域中具有最大线长的值。</para>
		/// <para>最大值—确定邻域中的最大值。</para>
		/// <para>中值—用于确定中值，根据长度进行加权。从概念上讲，邻域中的所有线段都按值排序，并以端点对端点的方式放置成一条直线。 直线中点的线段值即为中值。</para>
		/// <para>最小值—计算每个邻域中的最小值。</para>
		/// <para>少数—在邻域中具有最小线长的值。</para>
		/// <para>范围—值范围（最大值 - 最小值）</para>
		/// <para>变异度—唯一值数。</para>
		/// <para>长度—邻域中的线的总长度。 如果字段值不是 1，则先将长度乘以项目值，然后再将它们相加。 当字段参数被设置为“无”时，可使用此选项。</para>
		/// <para>指定的字段为整型时，可用的统计选择有：均值、众数、最大值、中值、最小值、少数、范围以及变异度。 该字段为浮点型时，可用的统计选择仅有：均值、最大值、最小值和范围。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LineStatistics SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>平均值—计算每个邻域中字段值的平均值，并根据长度进行加权。计算公式为：仅使用位于邻域内的长度的部分。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>众数—确定在邻域中具有最大线长的值。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

			/// <summary>
			/// <para>最大值—确定邻域中的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>中值—用于确定中值，根据长度进行加权。从概念上讲，邻域中的所有线段都按值排序，并以端点对端点的方式放置成一条直线。 直线中点的线段值即为中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>最小值—计算每个邻域中的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>少数—在邻域中具有最小线长的值。</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("少数")]
			Minority,

			/// <summary>
			/// <para>范围—值范围（最大值 - 最小值）</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("范围")]
			Range,

			/// <summary>
			/// <para>变异度—唯一值数。</para>
			/// </summary>
			[GPValue("VARIETY")]
			[Description("变异度")]
			Variety,

			/// <summary>
			/// <para>长度—邻域中的线的总长度。 如果字段值不是 1，则先将长度乘以项目值，然后再将它们相加。 当字段参数被设置为“无”时，可使用此选项。</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("长度")]
			Length,

		}

#endregion
	}
}
