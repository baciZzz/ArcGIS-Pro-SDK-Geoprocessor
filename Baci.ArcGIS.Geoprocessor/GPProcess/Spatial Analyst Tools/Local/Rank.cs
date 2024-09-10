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
	/// <para>Ranks on a cell-by-cell basis the values from a set of input rasters and determines which values are returned based on the value of the rank input raster.</para>
	/// </summary>
	public class Rank : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRankRasterOrConstant">
		/// <para>Input rank raster or constant value</para>
		/// <para>The input raster that defines the rank position to be returned.</para>
		/// <para>A number can be used as an input; however, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>The list of input rasters from which the cell value of the raster at the specified rank position will be obtained.</para>
		/// <para>For example, consider a particular location where the cell values in the three input rasters are 17, 8 and 11. The rank value for that location is defined as 3. The tool will first sort the input values. Since the rank value being requested is 3, the output value will be 17.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell on the output raster, the values on the input rasters are sorted from lowest to highest, and the input rank raster&apos;s value is used to select which will be the output value.</para>
		/// </param>
		public Rank(object InRankRasterOrConstant, object InRasters, object OutRaster)
		{
			this.InRankRasterOrConstant = InRankRasterOrConstant;
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Rank</para>
		/// </summary>
		public override string DisplayName() => "Rank";

		/// <summary>
		/// <para>Tool Name : Rank</para>
		/// </summary>
		public override string ToolName() => "Rank";

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
		/// <para>The input raster that defines the rank position to be returned.</para>
		/// <para>A number can be used as an input; however, the cell size and extent must first be set in the environment.</para>
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
		/// <para>The list of input rasters from which the cell value of the raster at the specified rank position will be obtained.</para>
		/// <para>For example, consider a particular location where the cell values in the three input rasters are 17, 8 and 11. The rank value for that location is defined as 3. The tool will first sort the input values. Since the rank value being requested is 3, the output value will be 17.</para>
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
		/// <para>The output raster.</para>
		/// <para>For each cell on the output raster, the values on the input rasters are sorted from lowest to highest, and the input rank raster&apos;s value is used to select which will be the output value.</para>
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
