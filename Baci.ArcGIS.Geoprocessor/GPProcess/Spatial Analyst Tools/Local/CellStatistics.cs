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
	/// <para>Cell Statistics</para>
	/// <para>像元统计</para>
	/// <para>根据多个栅格计算每个像元的统计数据。</para>
	/// </summary>
	public class CellStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRastersOrConstants">
		/// <para>Input rasters or constant values</para>
		/// <para>输入栅格列表，将为其中的输入栅格计算“分析”窗口中各个像元的统计数据。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// <para>如果选中了以多波段方式处理参数，则所有多波段输入都必须具有相同数量的波段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于各个像元，可通过将指定统计数据类型应用到该位置处的输入栅格来确定该值。</para>
		/// </param>
		public CellStatistics(object InRastersOrConstants, object OutRaster)
		{
			this.InRastersOrConstants = InRastersOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 像元统计</para>
		/// </summary>
		public override string DisplayName() => "像元统计";

		/// <summary>
		/// <para>Tool Name : CellStatistics</para>
		/// </summary>
		public override string ToolName() => "CellStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.CellStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.CellStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRastersOrConstants, OutRaster, StatisticsType, IgnoreNodata, ProcessAsMultiband };

		/// <summary>
		/// <para>Input rasters or constant values</para>
		/// <para>输入栅格列表，将为其中的输入栅格计算“分析”窗口中各个像元的统计数据。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// <para>如果选中了以多波段方式处理参数，则所有多波段输入都必须具有相同数量的波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRastersOrConstants { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于各个像元，可通过将指定统计数据类型应用到该位置处的输入栅格来确定该值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Overlay statistic</para>
		/// <para>指定要计算的统计数据类型。</para>
		/// <para>平均值—将计算输入的平均值。</para>
		/// <para>众数—将计算输入的众数（出现次数最多的值）。</para>
		/// <para>最大值—将计算输入的最大值。</para>
		/// <para>中值—将计算输入的中值。</para>
		/// <para>最小值—将计算输入的最小值。</para>
		/// <para>少数—将计算输入的少数（出现次数最少的值）。</para>
		/// <para>范围—将计算输入的范围（最大值和最小值之差）。</para>
		/// <para>标准差—将计算输入的标准偏差。</para>
		/// <para>总和—将计算输入的总和（所有值的总和）。</para>
		/// <para>变异度—将计算输入的变异度（唯一值的数量）。</para>
		/// <para>默认统计类型为平均值。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>指定在进行统计计算时是否将忽略 NoData 值。</para>
		/// <para>选中 - 在处理像元位置处，如果任意输入栅格具有 NoData，将忽略该 NoData 值。 仅考虑具有有效数据的像元来计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 如果任意输入栅格的处理像元位置为 NoData，该像元的输出将为 NoData。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Process as multiband</para>
		/// <para>指定如何处理输入多波段栅格波段。</para>
		/// <para>未选中 - 来自多波段栅格输入的每个波段将被单独处理为单波段栅格。 这是默认设置。</para>
		/// <para>选中 - 每个多波段栅格输入都将作为多波段栅格进行处理。 将使用其他输入的相应波段数对一个输入的每个波段执行操作。</para>
		/// <para><see cref="ProcessAsMultibandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultiband { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CellStatistics SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay statistic</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>平均值—将计算输入的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>众数—将计算输入的众数（出现次数最多的值）。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

			/// <summary>
			/// <para>最大值—将计算输入的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>中值—将计算输入的中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>最小值—将计算输入的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>少数—将计算输入的少数（出现次数最少的值）。</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("少数")]
			Minority,

			/// <summary>
			/// <para>范围—将计算输入的范围（最大值和最小值之差）。</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("范围")]
			Range,

			/// <summary>
			/// <para>标准差—将计算输入的标准偏差。</para>
			/// </summary>
			[GPValue("STD")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>总和—将计算输入的总和（所有值的总和）。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

			/// <summary>
			/// <para>变异度—将计算输入的变异度（唯一值的数量）。</para>
			/// </summary>
			[GPValue("VARIETY")]
			[Description("变异度")]
			Variety,

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

		/// <summary>
		/// <para>Process as multiband</para>
		/// </summary>
		public enum ProcessAsMultibandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_BAND")]
			SINGLE_BAND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_BAND")]
			MULTI_BAND,

		}

#endregion
	}
}
