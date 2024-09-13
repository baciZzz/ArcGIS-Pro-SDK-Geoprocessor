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
	/// <para>Line Density</para>
	/// <para>线密度分析</para>
	/// <para>根据落入每个单元一定半径范围内的折线要素计算每单位面积的量级。</para>
	/// </summary>
	public class LineDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolylineFeatures">
		/// <para>Input polyline features</para>
		/// <para>要计算密度的输入线要素。</para>
		/// </param>
		/// <param name="PopulationField">
		/// <para>Population field</para>
		/// <para>表示各折线总体值（线应被统计的次数）的数值字段。</para>
		/// <para>population 字段的值可以是整型或浮点型。</para>
		/// <para>以下列出的是该字段的选项和默认特性。</para>
		/// <para>如果不使用任何项目或特殊值，则选择 None，这样每一要素就只计数一次。</para>
		/// <para>如果输入要素包含 Z 值，则可以使用 Shape 字段。</para>
		/// <para>否则，默认字段为 POPULATION。 以下条件同样适用：</para>
		/// <para>如果没有 POPULATION 字段，但有 POPULATIONxxxx 字段，则默认使用该字段。 xxxx 可以是任何有效字符，例如 POPULATION6、POPULATION1974 和 POPULATIONROADTYPE。</para>
		/// <para>如果没有 POPULATION 字段或 POPULATIONxxxx 字段，但有 POP 字段，则默认使用 POP 字段。</para>
		/// <para>如果没有 POPULATION 字段、POPULATIONxxxx 字段或 POP 字段，但有 POPxxxx 字段，则默认使用 POPxxxx 字段。</para>
		/// <para>如果没有 POPULATION 字段、POPULATIONxxxx 字段、POP 字段或 POPxxxx 字段，则默认使用 NONE。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出线密度栅格。</para>
		/// <para>总为浮点栅格。</para>
		/// </param>
		public LineDensity(object InPolylineFeatures, object PopulationField, object OutRaster)
		{
			this.InPolylineFeatures = InPolylineFeatures;
			this.PopulationField = PopulationField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 线密度分析</para>
		/// </summary>
		public override string DisplayName() => "线密度分析";

		/// <summary>
		/// <para>Tool Name : LineDensity</para>
		/// </summary>
		public override string ToolName() => "LineDensity";

		/// <summary>
		/// <para>Tool Excute Name : sa.LineDensity</para>
		/// </summary>
		public override string ExcuteName() => "sa.LineDensity";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolylineFeatures, PopulationField, OutRaster, CellSize!, SearchRadius!, AreaUnitScaleFactor! };

		/// <summary>
		/// <para>Input polyline features</para>
		/// <para>要计算密度的输入线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Polyline")]
		public object InPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Population field</para>
		/// <para>表示各折线总体值（线应被统计的次数）的数值字段。</para>
		/// <para>population 字段的值可以是整型或浮点型。</para>
		/// <para>以下列出的是该字段的选项和默认特性。</para>
		/// <para>如果不使用任何项目或特殊值，则选择 None，这样每一要素就只计数一次。</para>
		/// <para>如果输入要素包含 Z 值，则可以使用 Shape 字段。</para>
		/// <para>否则，默认字段为 POPULATION。 以下条件同样适用：</para>
		/// <para>如果没有 POPULATION 字段，但有 POPULATIONxxxx 字段，则默认使用该字段。 xxxx 可以是任何有效字符，例如 POPULATION6、POPULATION1974 和 POPULATIONROADTYPE。</para>
		/// <para>如果没有 POPULATION 字段或 POPULATIONxxxx 字段，但有 POP 字段，则默认使用 POP 字段。</para>
		/// <para>如果没有 POPULATION 字段、POPULATIONxxxx 字段或 POP 字段，但有 POPxxxx 字段，则默认使用 POPxxxx 字段。</para>
		/// <para>如果没有 POPULATION 字段、POPULATIONxxxx 字段、POP 字段或 POPxxxx 字段，则默认使用 NONE。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[KeyField("NONE")]
		public object PopulationField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出线密度栅格。</para>
		/// <para>总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。 如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。 有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Search radius</para>
		/// <para>在其范围内计算密度的搜索半径。 单位基于输出空间参考投影的线性单位。</para>
		/// <para>例如，如果单位为米，若要包含一英里邻域内的所有要素，可将搜索半径设置为 1609.344（1 英里 = 1609.344 米）。</para>
		/// <para>默认值为输出空间参考中输出范围的宽度或高度的最小值除以 30。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Area units</para>
		/// <para>输出密度值的面积单位。</para>
		/// <para>基于输出空间参考的线性单位选择默认单位。 要转换密度输出，可将此单位更改为合适的单位。 线密度值将转换长度和面积的单位。</para>
		/// <para>未指定输出空间参考的情况下，输出空间参考与输入要素类相同。 默认输出密度单位通过输出空间参考的线性单位确定，如下所示。 如果输出线性单位是米，输出面积密度单位将设置为平方千米，输出平方千米（点要素）或千米每平方千米（折线要素）。 如果输出线性单位是英尺，输出面积密度单位将设置为平方英里。</para>
		/// <para>如果输出单位不是英尺和米，输出面积密度单位将设置为平方地图单位。 即，输出密度单位为输出空间参考的线性单位的平方。 例如，如果输出线性单位是厘米，输出面积密度单位将是平方地图单位，即平方厘米。 如果输出线性单位是千米，输出面积密度单位将是平方地图单位，即平方千米。</para>
		/// <para>可用选项及相应的输出密度单位如下：</para>
		/// <para>平方地图单位—用于输出空间参考的线性单位的平方。</para>
		/// <para>平方英里—英里（美国）。</para>
		/// <para>平方千米—千米。</para>
		/// <para>英亩—英亩（美国）。</para>
		/// <para>公顷—公顷。</para>
		/// <para>平方码—码（美国）。</para>
		/// <para>平方英尺—英尺（美国）。</para>
		/// <para>平方英寸—英寸（美国）。</para>
		/// <para>平方米—米。</para>
		/// <para>平方厘米—厘米。</para>
		/// <para>平方毫米—毫米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnitScaleFactor { get; set; } = "SQUARE_MAP_UNITS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LineDensity SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
