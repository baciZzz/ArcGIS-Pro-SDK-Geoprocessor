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
	/// <para>Point Statistics</para>
	/// <para>点统计</para>
	/// <para>对每个输出像元周围的邻域中的点计算统计数据。</para>
	/// </summary>
	public class PointStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>要在每个输出像元周围的邻域中计算其统计数据的输入点要素类。</para>
		/// <para>输入可以是点或多点要素类。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>将要计算指定统计数据的字段。 它可以是输入要素的任何数值字段。</para>
		/// <para>如果输入要素包含 z 值，则它可以是 Shape 字段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出点统计数据栅格。</para>
		/// </param>
		public PointStatistics(object InPointFeatures, object Field, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.Field = Field;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 点统计</para>
		/// </summary>
		public override string DisplayName() => "点统计";

		/// <summary>
		/// <para>Tool Name : PointStatistics</para>
		/// </summary>
		public override string ToolName() => "PointStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.PointStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.PointStatistics";

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
		public override object[] Parameters() => new object[] { InPointFeatures, Field, OutRaster, CellSize, Neighborhood, StatisticsType };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>要在每个输出像元周围的邻域中计算其统计数据的输入点要素类。</para>
		/// <para>输入可以是点或多点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>将要计算指定统计数据的字段。 它可以是输入要素的任何数值字段。</para>
		/// <para>如果输入要素包含 z 值，则它可以是 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出点统计数据栅格。</para>
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
		/// <para>Neighborhood</para>
		/// <para>每个处理像元周围的区域，在该区域中找到的所有输入点均将用于统计计算。 有多种预定义邻域类型可供选择。</para>
		/// <para>选择邻域类型后，可设置其他参数来完全定义形状、大小和测量单位。 默认邻域为矩形。</para>
		/// <para>以下为可用邻域类型的形式：</para>
		/// <para>环形，内半径，外半径，单位类型由内半径或外半径定义的环形（圆环形）邻域。 默认环形具有一个像元的内半径以及三个像元的外半径。</para>
		/// <para>圆，半径，单位类型具有给定半径的圆形邻域。 默认半径为三个像元。</para>
		/// <para>矩形，高度，宽度，单位类型由高度和宽度定义的矩形邻域。 默认设置是高和宽为三个像元的正方形。</para>
		/// <para>楔形，半径，起始角度，终止角度，单位类型由半径、起始角度和终止角度定义的楔形邻域。 楔形按逆时针方向从起始角延伸到终止角。 角度以度为单位进行指定，0 或 360 的值表示东方。 也可使用负角度。 默认楔形起始角度为 0 度，终止角度为 90 度，半径为三个像元。</para>
		/// <para>参数的距离单位可指定为像元单位或地图单位。 默认设置为“像元”单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSANeighborhood()]
		[GPSANeighborhoodDomain()]
		[NeighbourType("Rectangle", "Circle", "Annulus", "Wedge")]
		public object Neighborhood { get; set; } = "Rectangle 3 3 CELL";

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>用于指定要计算的统计数据类型。</para>
		/// <para>对位于每个输出栅格像元指定邻域中的点对应的指定字段值执行计算。</para>
		/// <para>平均值—将计算每个邻域中字段值的平均值。</para>
		/// <para>众数—将识别每个邻域中出现频率最高的字段值。 如果出现频率相同，则使用较低的值。</para>
		/// <para>最大值—将识别每个邻域中的最大字段值。</para>
		/// <para>中值—将计算每个邻域中的中间字段值。 如果邻域中的点数为偶数，则结果将为两个中间值中的较小值。</para>
		/// <para>最小值—将识别每个邻域中的最小字段值。</para>
		/// <para>少数—将识别每个邻域中出现频率最低的字段值。 如果出现频率相同，则使用较低的值。</para>
		/// <para>范围—将计算每个邻域内字段值的范围（最大值和最小值之差）。</para>
		/// <para>标准差—将计算每个邻域中字段值的标准差。</para>
		/// <para>总和—将计算邻域内字段值的总和。</para>
		/// <para>变异度—将计算每个邻域中唯一字段值的数量。</para>
		/// <para>统计类型的可用选择取决于指定字段的数值型。 如果字段为整型，则所有统计类型均可用。 如果字段为浮点型，则仅可使用最大值、平均值、最小值、范围、标准差以及总和。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointStatistics SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
			/// <para>平均值—将计算每个邻域中字段值的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>众数—将识别每个邻域中出现频率最高的字段值。 如果出现频率相同，则使用较低的值。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

			/// <summary>
			/// <para>最大值—将识别每个邻域中的最大字段值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>中值—将计算每个邻域中的中间字段值。 如果邻域中的点数为偶数，则结果将为两个中间值中的较小值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>最小值—将识别每个邻域中的最小字段值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>少数—将识别每个邻域中出现频率最低的字段值。 如果出现频率相同，则使用较低的值。</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("少数")]
			Minority,

			/// <summary>
			/// <para>范围—将计算每个邻域内字段值的范围（最大值和最小值之差）。</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("范围")]
			Range,

			/// <summary>
			/// <para>标准差—将计算每个邻域中字段值的标准差。</para>
			/// </summary>
			[GPValue("STD")]
			[Description("标准差")]
			Standard_Deviation,

			/// <summary>
			/// <para>总和—将计算邻域内字段值的总和。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

			/// <summary>
			/// <para>变异度—将计算每个邻域中唯一字段值的数量。</para>
			/// </summary>
			[GPValue("VARIETY")]
			[Description("变异度")]
			Variety,

		}

#endregion
	}
}
