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
	/// <para>InList</para>
	/// <para>InList</para>
	/// <para>Determines which values from the first input are contained in a set of other inputs, on a cell-by-cell basis.</para>
	/// </summary>
	public class InList : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterOrConstant">
		/// <para>Input raster or constant value</para>
		/// <para>The input that defines the value that will be looked for in a list of rasters on a cell-by-cell basis.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="InRasterOrConstants">
		/// <para>Input raster or constant values</para>
		/// <para>A list of input rasters that the first input will be evaluated against. For each location, if the cell value from the first input exists in any of the other rasters, that value will be assigned to the output raster. If the value does not exist in any of the other rasters, the output value at that location will be NoData.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// </param>
		public InList(object InRasterOrConstant, object InRasterOrConstants, object OutRaster)
		{
			this.InRasterOrConstant = InRasterOrConstant;
			this.InRasterOrConstants = InRasterOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : InList</para>
		/// </summary>
		public override string DisplayName() => "InList";

		/// <summary>
		/// <para>Tool Name : InList</para>
		/// </summary>
		public override string ToolName() => "InList";

		/// <summary>
		/// <para>Tool Excute Name : sa.InList</para>
		/// </summary>
		public override string ExcuteName() => "sa.InList";

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
		public override object[] Parameters() => new object[] { InRasterOrConstant, InRasterOrConstants, OutRaster, ProcessAsMultiband! };

		/// <summary>
		/// <para>Input raster or constant value</para>
		/// <para>The input that defines the value that will be looked for in a list of rasters on a cell-by-cell basis.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Input raster or constant values</para>
		/// <para>A list of input rasters that the first input will be evaluated against. For each location, if the cell value from the first input exists in any of the other rasters, that value will be assigned to the output raster. If the value does not exist in any of the other rasters, the output value at that location will be NoData.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstants { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Process as multiband</para>
		/// <para>Specifies how the input multiband raster bands will be processed.</para>
		/// <para>Unchecked—Each band from a multiband raster input will be processed separately as a single band raster. This is the default.</para>
		/// <para>Checked—Each multiband raster input will be processed as a multiband raster. The operation will be performed for each band from one input using the corresponding band number from the other inputs.</para>
		/// <para><see cref="ProcessAsMultibandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProcessAsMultiband { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InList SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
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
			/// <para>Unchecked—Each band from a multiband raster input will be processed separately as a single band raster. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_BAND")]
			SINGLE_BAND,

			/// <summary>
			/// <para>Checked—Each multiband raster input will be processed as a multiband raster. The operation will be performed for each band from one input using the corresponding band number from the other inputs.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_BAND")]
			MULTI_BAND,

		}

#endregion
	}
}
