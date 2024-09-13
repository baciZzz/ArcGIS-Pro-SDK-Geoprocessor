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
	/// <para>Rank</para>
	/// <para>等级</para>
	/// <para>逐个像元地对一组输入栅格中的值进行排名，并根据排名输入栅格中的值确定返回哪些值。</para>
	/// </summary>
	public class Rank : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRankRasterOrConstant">
		/// <para>Input rank raster or constant value</para>
		/// <para>用于定义要返回的等级位置的输入栅格。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>将从中获得指定等级位置的栅格像元值的输入栅格列表。</para>
		/// <para>例如，考虑三个输入栅格中的像元值为 17、8 和 11 的特定位置。 该位置的等级值将被定义为 3。 该工具将先对输入值进行排序。 由于所要请求的等级值为 3，因此输出值将为 17。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于输出栅格上的每个像元，输入栅格上的值按从低到高的顺序排列，输入等级栅格的值用于选择哪一个将成为输出值。</para>
		/// </param>
		public Rank(object InRankRasterOrConstant, object InRasters, object OutRaster)
		{
			this.InRankRasterOrConstant = InRankRasterOrConstant;
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 等级</para>
		/// </summary>
		public override string DisplayName() => "等级";

		/// <summary>
		/// <para>Tool Name : 等级</para>
		/// </summary>
		public override string ToolName() => "等级";

		/// <summary>
		/// <para>Tool Excute Name : sa.Rank</para>
		/// </summary>
		public override string ExcuteName() => "sa.Rank";

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
		public override object[] Parameters() => new object[] { InRankRasterOrConstant, InRasters, OutRaster, ProcessAsMultiband };

		/// <summary>
		/// <para>Input rank raster or constant value</para>
		/// <para>用于定义要返回的等级位置的输入栅格。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRankRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>将从中获得指定等级位置的栅格像元值的输入栅格列表。</para>
		/// <para>例如，考虑三个输入栅格中的像元值为 17、8 和 11 的特定位置。 该位置的等级值将被定义为 3。 该工具将先对输入值进行排序。 由于所要请求的等级值为 3，因此输出值将为 17。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于输出栅格上的每个像元，输入栅格上的值按从低到高的顺序排列，输入等级栅格的值用于选择哪一个将成为输出值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		public Rank SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

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
