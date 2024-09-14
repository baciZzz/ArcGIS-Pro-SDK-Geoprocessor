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
	/// <para>Aggregate</para>
	/// <para>聚合</para>
	/// <para>生成分辨率降低版本的栅格。每个输出像元包含此像元范围内所涵盖的输入像元的总和、最小值、最大值、平均值或中值。</para>
	/// </summary>
	public class Aggregate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要聚合的输入栅格。</para>
		/// <para>可以是整型或浮点型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出的聚合栅格。</para>
		/// <para>它是分辨率降低版本的输入栅格。</para>
		/// </param>
		/// <param name="CellFactor">
		/// <para>Cell factor</para>
		/// <para>要获得输出栅格所需的分辨率，与输入栅格的像元大小相乘的系数。</para>
		/// <para>例如，像元系数值 3 会使输出像元大小比输入栅格的像元大小大三倍。</para>
		/// <para>该值必须为大于 1 的整数。</para>
		/// </param>
		public Aggregate(object InRaster, object OutRaster, object CellFactor)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.CellFactor = CellFactor;
		}

		/// <summary>
		/// <para>Tool Display Name : 聚合</para>
		/// </summary>
		public override string DisplayName() => "聚合";

		/// <summary>
		/// <para>Tool Name : 聚合</para>
		/// </summary>
		public override string ToolName() => "聚合";

		/// <summary>
		/// <para>Tool Excute Name : sa.Aggregate</para>
		/// </summary>
		public override string ExcuteName() => "sa.Aggregate";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, CellFactor, AggregationType!, ExtentHandling!, IgnoreNodata! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要聚合的输入栅格。</para>
		/// <para>可以是整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出的聚合栅格。</para>
		/// <para>它是分辨率降低版本的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Cell factor</para>
		/// <para>要获得输出栅格所需的分辨率，与输入栅格的像元大小相乘的系数。</para>
		/// <para>例如，像元系数值 3 会使输出像元大小比输入栅格的像元大小大三倍。</para>
		/// <para>该值必须为大于 1 的整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		public object CellFactor { get; set; }

		/// <summary>
		/// <para>Aggregation technique</para>
		/// <para>指出确定每个输出像元值的方式。</para>
		/// <para>由以下统计数据之一对粗糙输出像元所包含的输入像元的值进行聚合：</para>
		/// <para>总和—输入像元值的总和。这是默认设置。</para>
		/// <para>最大值—输入像元的最大值。</para>
		/// <para>平均值—输入像元的平均值。</para>
		/// <para>中值—输入像元的中值。</para>
		/// <para>最小值—输入像元的最小值。</para>
		/// <para><see cref="AggregationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AggregationType { get; set; } = "SUM";

		/// <summary>
		/// <para>Expand extent if needed</para>
		/// <para>定义当输入栅格的行数或列数不是像元系数的倍数时处理输入栅格边界的方式。</para>
		/// <para>选中 - 扩展输入栅格的顶部或右侧边界，以使像元的总行数或总列数是像元系数的倍数。在进行计算时，这些扩展的像元将获得 NoData 值。使用此选项时，输出栅格可比输入栅格覆盖更大的空间范围。</para>
		/// <para>这是默认设置。</para>
		/// <para>未选中 - 将减去输出栅格的行数或列数。此操作将从输入栅格的顶部或右侧边界截断其余像元，以使输入栅格的行数或列数是像元系数的倍数。使用此选项时，输出栅格可比输入栅格覆盖更小的空间范围。</para>
		/// <para>如果输入栅格的行数和列数是像元系数的倍数，则不需要使用这些关键字。</para>
		/// <para><see cref="ExtentHandlingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExtentHandling { get; set; } = "true";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>指示在进行聚合计算时是否忽略 NoData 值。</para>
		/// <para>选中 - 指定对于落在输出栅格上较大像元空间范围内的任何像元，如果存在 NoData 值，则在确定输出像元位置的值时，将忽略 NoData 值。在确定输出像元值时，将仅使用在输出像元范围内具有数据值的输入像元。这是默认设置。</para>
		/// <para>未选中 - 指定如果落在输出栅格上较大像元空间范围内的任何像元具有 NoData 值，则该输出像元位置的值为 NoData。如果使用“未选中”，则表示在聚合内的像元包含 NoData 值时，执行确定输出值所必需的指定计算所需要的信息不足。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Aggregate SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Aggregation technique</para>
		/// </summary>
		public enum AggregationTypeEnum 
		{
			/// <summary>
			/// <para>总和—输入像元值的总和。这是默认设置。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

			/// <summary>
			/// <para>最大值—输入像元的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>平均值—输入像元的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>中值—输入像元的中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>最小值—输入像元的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

		}

		/// <summary>
		/// <para>Expand extent if needed</para>
		/// </summary>
		public enum ExtentHandlingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPAND")]
			EXPAND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("TRUNCATE")]
			TRUNCATE,

		}

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
