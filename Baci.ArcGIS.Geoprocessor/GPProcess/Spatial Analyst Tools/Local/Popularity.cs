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
	/// <para>Popularity</para>
	/// <para>频数取值</para>
	/// <para>逐个像元地确定参数列表中具有特定频数级别的值。 特定的频数级别（每个值的出现次数）由第一个参数指定。</para>
	/// </summary>
	public class Popularity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPopularityRasterOrConstant">
		/// <para>Input popularity raster or constant value</para>
		/// <para>用于定义要返回的频数位置的输入栅格。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>用于为每个像元位置计算值的频数的输入栅格列表。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出栅格上的每个像元都表示来自满足输入频数值的输入栅格的同一位置的值。</para>
		/// </param>
		public Popularity(object InPopularityRasterOrConstant, object InRasters, object OutRaster)
		{
			this.InPopularityRasterOrConstant = InPopularityRasterOrConstant;
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 频数取值</para>
		/// </summary>
		public override string DisplayName() => "频数取值";

		/// <summary>
		/// <para>Tool Name : 频数取值</para>
		/// </summary>
		public override string ToolName() => "频数取值";

		/// <summary>
		/// <para>Tool Excute Name : sa.Popularity</para>
		/// </summary>
		public override string ExcuteName() => "sa.Popularity";

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
		public override object[] Parameters() => new object[] { InPopularityRasterOrConstant, InRasters, OutRaster, ProcessAsMultiband };

		/// <summary>
		/// <para>Input popularity raster or constant value</para>
		/// <para>用于定义要返回的频数位置的输入栅格。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InPopularityRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>用于为每个像元位置计算值的频数的输入栅格列表。</para>
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
		/// <para>输出栅格上的每个像元都表示来自满足输入频数值的输入栅格的同一位置的值。</para>
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
		public Popularity SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
