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
	/// <para>Greater Than Frequency</para>
	/// <para>Evaluates on a cell-by-cell basis the number of times a set of rasters is greater than another raster.</para>
	/// </summary>
	public class GreaterThanFrequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InValueRaster">
		/// <para>Input value raster</para>
		/// <para>For each cell location in the input value raster, the number of occurrences (frequency) where a raster in the input list has a greater value is counted.</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>The list of rasters that will be compared to the value raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell in the output raster, the value represents the number of times that the corresponding cells in the list of rasters is greater than the value raster.</para>
		/// </param>
		public GreaterThanFrequency(object InValueRaster, object InRasters, object OutRaster)
		{
			this.InValueRaster = InValueRaster;
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Greater Than Frequency</para>
		/// </summary>
		public override string DisplayName() => "Greater Than Frequency";

		/// <summary>
		/// <para>Tool Name : GreaterThanFrequency</para>
		/// </summary>
		public override string ToolName() => "GreaterThanFrequency";

		/// <summary>
		/// <para>Tool Excute Name : sa.GreaterThanFrequency</para>
		/// </summary>
		public override string ExcuteName() => "sa.GreaterThanFrequency";

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
		public override object[] Parameters() => new object[] { InValueRaster, InRasters, OutRaster, ProcessAsMultiband };

		/// <summary>
		/// <para>Input value raster</para>
		/// <para>For each cell location in the input value raster, the number of occurrences (frequency) where a raster in the input list has a greater value is counted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InValueRaster { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>The list of rasters that will be compared to the value raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell in the output raster, the value represents the number of times that the corresponding cells in the list of rasters is greater than the value raster.</para>
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
		public GreaterThanFrequency SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
