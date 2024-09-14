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
	/// <para>Reclassify</para>
	/// <para>Reclassify</para>
	/// <para>Reclassifies (or changes) the values in a raster.</para>
	/// </summary>
	public class Reclassify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </param>
		/// <param name="ReclassField">
		/// <para>Reclass field</para>
		/// <para>Field denoting the values that will be reclassified.</para>
		/// </param>
		/// <param name="Remap">
		/// <para>Reclassification</para>
		/// <para>A remap table that defines how the values will be reclassified. Working with the table and it options are as follows:</para>
		/// <para>The values of the input raster can be classified as ranges of values or as individual values. The table will be displayed with Start and End values or single unique values, respectively. If the input is a layer in Contents, it will import the unique values or classified breaks of the symbology.</para>
		/// <para>Specify the New value that will be assigned in the output raster. Only integer values are supported.</para>
		/// <para>Use the Classify or Unique options to generate a remap table based on the values of the input raster. The Classify option opens a dialog and allow you to specify a method from one of the Data classification methods and number of classes. The Unique option will populate the remap table using the unique values from the input dataset.</para>
		/// <para>The Reverse New Values option resorts the new values list (for example, 1,2,3 becomes 3,2,1).</para>
		/// <para>To modify the table, new entries can be added by typing in the empty cells in the table and pressing the Enter key. This will validate the new entry and create a new, empty row for subsequent input. You can delete rows by selecting one or many rows and pressing the Delete key.</para>
		/// <para>Use the load and save options to save a remap for later use and apply it to other input data or for quickly repeating an analysis.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// </param>
		public Reclassify(object InRaster, object ReclassField, object Remap, object OutRaster)
		{
			this.InRaster = InRaster;
			this.ReclassField = ReclassField;
			this.Remap = Remap;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Reclassify</para>
		/// </summary>
		public override string DisplayName() => "Reclassify";

		/// <summary>
		/// <para>Tool Name : Reclassify</para>
		/// </summary>
		public override string ToolName() => "Reclassify";

		/// <summary>
		/// <para>Tool Excute Name : sa.Reclassify</para>
		/// </summary>
		public override string ExcuteName() => "sa.Reclassify";

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
		public override object[] Parameters() => new object[] { InRaster, ReclassField, Remap, OutRaster, MissingValues };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Reclass field</para>
		/// <para>Field denoting the values that will be reclassified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object ReclassField { get; set; }

		/// <summary>
		/// <para>Reclassification</para>
		/// <para>A remap table that defines how the values will be reclassified. Working with the table and it options are as follows:</para>
		/// <para>The values of the input raster can be classified as ranges of values or as individual values. The table will be displayed with Start and End values or single unique values, respectively. If the input is a layer in Contents, it will import the unique values or classified breaks of the symbology.</para>
		/// <para>Specify the New value that will be assigned in the output raster. Only integer values are supported.</para>
		/// <para>Use the Classify or Unique options to generate a remap table based on the values of the input raster. The Classify option opens a dialog and allow you to specify a method from one of the Data classification methods and number of classes. The Unique option will populate the remap table using the unique values from the input dataset.</para>
		/// <para>The Reverse New Values option resorts the new values list (for example, 1,2,3 becomes 3,2,1).</para>
		/// <para>To modify the table, new entries can be added by typing in the empty cells in the table and pressing the Enter key. This will validate the new entry and create a new, empty row for subsequent input. You can delete rows by selecting one or many rows and pressing the Delete key.</para>
		/// <para>Use the load and save options to save a remap for later use and apply it to other input data or for quickly repeating an analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSARemap()]
		[GPSARemapDomain()]
		[RemapType("Number", "String", "None")]
		public object Remap { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// <para>Denotes whether missing values in the reclass table retain their value or get mapped to NoData.</para>
		/// <para>Unchecked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in a remap table, the value should remain intact and be written for that location to the output raster. This is the default.</para>
		/// <para>Checked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in a remap table, the value will be reclassed to NoData for that location on the output raster.</para>
		/// <para><see cref="MissingValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MissingValues { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Reclassify SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// </summary>
		public enum MissingValuesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in a remap table, the value should remain intact and be written for that location to the output raster. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Checked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in a remap table, the value will be reclassed to NoData for that location on the output raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
