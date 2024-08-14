using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Polyline to Raster</para>
	/// <para>Converts polyline features to a raster dataset.</para>
	/// </summary>
	public class PolylineToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polyline input feature dataset to be converted to a raster.</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>The field used to assign values to the output raster.</para>
		/// <para>It can be any field of the input feature dataset&apos;s attribute table.</para>
		/// </param>
		/// <param name="OutRasterdataset">
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </param>
		public PolylineToRaster(object InFeatures, object ValueField, object OutRasterdataset)
		{
			this.InFeatures = InFeatures;
			this.ValueField = ValueField;
			this.OutRasterdataset = OutRasterdataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Polyline to Raster</para>
		/// </summary>
		public override string DisplayName => "Polyline to Raster";

		/// <summary>
		/// <para>Tool Name : PolylineToRaster</para>
		/// </summary>
		public override string ToolName => "PolylineToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PolylineToRaster</para>
		/// </summary>
		public override string ExcuteName => "conversion.PolylineToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, ValueField, OutRasterdataset, CellAssignment!, PriorityField!, Cellsize!, BuildRat! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polyline input feature dataset to be converted to a raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>The field used to assign values to the output raster.</para>
		/// <para>It can be any field of the input feature dataset&apos;s attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRasterdataset { get; set; }

		/// <summary>
		/// <para>Cell assignment type</para>
		/// <para>The method to determine how the cell will be assigned a value when more than one feature falls within a cell.</para>
		/// <para>Maximum length—The feature with the longest length that covers the cell will determine the value to assign to the cell.</para>
		/// <para>Maximum combined length—If there is more than one feature in a cell with the same value, the lengths of these features will be combined. The combined feature with the longest length within the cell will determine the value to assign to the cell.</para>
		/// <para><see cref="CellAssignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CellAssignment { get; set; } = "MAXIMUM_LENGTH";

		/// <summary>
		/// <para>Priority field</para>
		/// <para>This field is used to determine which feature should take preference over another feature that falls over a cell. When it is used, the feature with the largest positive priority is always selected for conversion irrespective of the Cell assignment type chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? PriorityField { get; set; } = "NONE";

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The cell size of the output raster being created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn’t been explicitly specified as the parameter value, the environment cell size value is used, if specified; otherwise, additional rules are used to calculate it from the other inputs. See Usages for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// <para>Specifies whether the output raster will have a raster attribute table.</para>
		/// <para>This parameter only applies to integer rasters.</para>
		/// <para>Checked—The output raster will have a raster attribute table. This is the default.</para>
		/// <para>Unchecked—The output raster will not have a raster attribute table.</para>
		/// <para><see cref="BuildRatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildRat { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolylineToRaster SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? pyramid = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell assignment type</para>
		/// </summary>
		public enum CellAssignmentEnum 
		{
			/// <summary>
			/// <para>Maximum length—The feature with the longest length that covers the cell will determine the value to assign to the cell.</para>
			/// </summary>
			[GPValue("MAXIMUM_LENGTH")]
			[Description("Maximum length")]
			Maximum_length,

			/// <summary>
			/// <para>Maximum combined length—If there is more than one feature in a cell with the same value, the lengths of these features will be combined. The combined feature with the longest length within the cell will determine the value to assign to the cell.</para>
			/// </summary>
			[GPValue("MAXIMUM_COMBINED_LENGTH")]
			[Description("Maximum combined length")]
			Maximum_combined_length,

		}

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// </summary>
		public enum BuildRatEnum 
		{
			/// <summary>
			/// <para>Checked—The output raster will have a raster attribute table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD")]
			BUILD,

			/// <summary>
			/// <para>Unchecked—The output raster will not have a raster attribute table.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD")]
			DO_NOT_BUILD,

		}

#endregion
	}
}
