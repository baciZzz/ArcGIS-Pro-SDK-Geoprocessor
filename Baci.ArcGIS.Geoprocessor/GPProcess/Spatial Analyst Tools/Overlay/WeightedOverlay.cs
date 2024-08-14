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
	/// <para>Weighted Overlay</para>
	/// <para>Overlays several rasters using a common measurement scale and weights each according to its importance.</para>
	/// </summary>
	public class WeightedOverlay : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWeightedOverlayTable">
		/// <para>Weighted overlay table</para>
		/// <para>The weighted overlay table allows the calculation of a multiple-criteria analysis between several rasters.</para>
		/// <para>Input Rasters:</para>
		/// <para>Rasters—List of input criteria rasters being weighted. Use the options to browse for raster datasets or add map layers to the list of inputs.</para>
		/// <para>%—The percent influence of the input raster compared to the other criteria rasters as a percentage of 100. Influences are specified by integer values only. Decimal values are rounded down to the nearest integer. The sum of influences must equal 100.Use the set equal influences option (the = sign button) to balance the percent influence of all rasters equally and sum them to 100.</para>
		/// <para>Remap Table:</para>
		/// <para>Field—The field of the input criteria to be weighted.</para>
		/// <para>Value—The input field value.</para>
		/// <para>Scale—The output scale value for the criterion, as specified by the Scale setting. Changing these values will alter the value in the input raster. You can enter a value directly or select from the drop-down list. In addition to numerical values, the following options are available:</para>
		/// <para>Restricted—Assigns the restricted value (the minimum value of the evaluation scale set, minus one) to cells in the output, regardless of whether other input rasters have a different scale value set for that cell.</para>
		/// <para>NoData—Assigns NoData to cells in the output, regardless of whether other input rasters have a different scale value set for that cell.</para>
		/// <para>Scale—Evaluation scale for defining the remap values. Select from a list of predefined evaluation scales. You can also define your own evaluation scale controls by typing in the parameter sign hyphens or spaces to separate values. A negative value must be preceded by a space.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output weighted raster.</para>
		/// </param>
		public WeightedOverlay(object InWeightedOverlayTable, object OutRaster)
		{
			this.InWeightedOverlayTable = InWeightedOverlayTable;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Weighted Overlay</para>
		/// </summary>
		public override string DisplayName => "Weighted Overlay";

		/// <summary>
		/// <para>Tool Name : WeightedOverlay</para>
		/// </summary>
		public override string ToolName => "WeightedOverlay";

		/// <summary>
		/// <para>Tool Excute Name : sa.WeightedOverlay</para>
		/// </summary>
		public override string ExcuteName => "sa.WeightedOverlay";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWeightedOverlayTable, OutRaster };

		/// <summary>
		/// <para>Weighted overlay table</para>
		/// <para>The weighted overlay table allows the calculation of a multiple-criteria analysis between several rasters.</para>
		/// <para>Input Rasters:</para>
		/// <para>Rasters—List of input criteria rasters being weighted. Use the options to browse for raster datasets or add map layers to the list of inputs.</para>
		/// <para>%—The percent influence of the input raster compared to the other criteria rasters as a percentage of 100. Influences are specified by integer values only. Decimal values are rounded down to the nearest integer. The sum of influences must equal 100.Use the set equal influences option (the = sign button) to balance the percent influence of all rasters equally and sum them to 100.</para>
		/// <para>Remap Table:</para>
		/// <para>Field—The field of the input criteria to be weighted.</para>
		/// <para>Value—The input field value.</para>
		/// <para>Scale—The output scale value for the criterion, as specified by the Scale setting. Changing these values will alter the value in the input raster. You can enter a value directly or select from the drop-down list. In addition to numerical values, the following options are available:</para>
		/// <para>Restricted—Assigns the restricted value (the minimum value of the evaluation scale set, minus one) to cells in the output, regardless of whether other input rasters have a different scale value set for that cell.</para>
		/// <para>NoData—Assigns NoData to cells in the output, regardless of whether other input rasters have a different scale value set for that cell.</para>
		/// <para>Scale—Evaluation scale for defining the remap values. Select from a list of predefined evaluation scales. You can also define your own evaluation scale controls by typing in the parameter sign hyphens or spaces to separate values. A negative value must be preceded by a space.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAWeightedOverlayTable()]
		[GPCompositeDomain()]
		public object InWeightedOverlayTable { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output weighted raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WeightedOverlay SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
