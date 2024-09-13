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
	/// <para>Pick</para>
	/// <para>选取</para>
	/// <para>位置栅格数据的值用于确定要从输入栅格列表中的哪一个栅格获取输出像元值。</para>
	/// </summary>
	public class Pick : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPositionRaster">
		/// <para>Input position raster</para>
		/// <para>定义要用于输出值的栅格位置的输入栅格。</para>
		/// <para>输入可以是整型或浮点型栅格。</para>
		/// </param>
		/// <param name="InRastersOrConstants">
		/// <para>Input rasters or constant values</para>
		/// <para>将从中选择输出值的输入的列表。</para>
		/// <para>输入可以是整型栅格或浮点型栅格。也可使用数字作为输入。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// </param>
		public Pick(object InPositionRaster, object InRastersOrConstants, object OutRaster)
		{
			this.InPositionRaster = InPositionRaster;
			this.InRastersOrConstants = InRastersOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 选取</para>
		/// </summary>
		public override string DisplayName() => "选取";

		/// <summary>
		/// <para>Tool Name : 选取</para>
		/// </summary>
		public override string ToolName() => "选取";

		/// <summary>
		/// <para>Tool Excute Name : sa.Pick</para>
		/// </summary>
		public override string ExcuteName() => "sa.Pick";

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
		public override object[] Parameters() => new object[] { InPositionRaster, InRastersOrConstants, OutRaster, ProcessAsMultiband! };

		/// <summary>
		/// <para>Input position raster</para>
		/// <para>定义要用于输出值的栅格位置的输入栅格。</para>
		/// <para>输入可以是整型或浮点型栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InPositionRaster { get; set; }

		/// <summary>
		/// <para>Input rasters or constant values</para>
		/// <para>将从中选择输出值的输入的列表。</para>
		/// <para>输入可以是整型栅格或浮点型栅格。也可使用数字作为输入。</para>
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
		public object? ProcessAsMultiband { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Pick SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
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
