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
	/// <para>Point to Raster</para>
	/// <para>Point to Raster</para>
	/// <para>Converts point features to a raster dataset.</para>
	/// </summary>
	public class PointToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point or multipoint input feature dataset to be converted to a raster.</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>The field used to assign values to the output raster.</para>
		/// <para>It can be any field of the input feature dataset&apos;s attribute table.</para>
		/// <para>If the Shape field of a point or multipoint dataset contains z- or m-values, either of these can be used.</para>
		/// </param>
		/// <param name="OutRasterdataset">
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </param>
		public PointToRaster(object InFeatures, object ValueField, object OutRasterdataset)
		{
			this.InFeatures = InFeatures;
			this.ValueField = ValueField;
			this.OutRasterdataset = OutRasterdataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Point to Raster</para>
		/// </summary>
		public override string DisplayName() => "Point to Raster";

		/// <summary>
		/// <para>Tool Name : PointToRaster</para>
		/// </summary>
		public override string ToolName() => "PointToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PointToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.PointToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ValueField, OutRasterdataset, CellAssignment, PriorityField, Cellsize, BuildRat };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point or multipoint input feature dataset to be converted to a raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>The field used to assign values to the output raster.</para>
		/// <para>It can be any field of the input feature dataset&apos;s attribute table.</para>
		/// <para>If the Shape field of a point or multipoint dataset contains z- or m-values, either of these can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID")]
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
		/// <para>Most frequent—If there is more than one feature within the cell, the one with the most common attribute, in the Value field, is assigned to the cell. If they have the same number of common attributes, the one with the lowest FID is used.</para>
		/// <para>Sum—The sum of the attributes of all the points within the cell (not valid for string data).</para>
		/// <para>Mean—The mean of the attributes of all the points within the cell (not valid for string data).</para>
		/// <para>Standard deviation—The standard deviation of attributes of all the points within the cell. If there are less than two points in the cell, the cell is assigned NoData (not valid for string data).</para>
		/// <para>Maximum—The maximum value of the attributes of the points within the cell (not valid for string data).</para>
		/// <para>Minimum—The minimum value of the attributes of the points within the cell (not valid for string data).</para>
		/// <para>Range—The range of the attributes of the points within the cell (not valid for string data).</para>
		/// <para>Count—The number of points within the cell.</para>
		/// <para><see cref="CellAssignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CellAssignment { get; set; } = "MOST_FREQUENT";

		/// <summary>
		/// <para>Priority field</para>
		/// <para>This field is used when a feature should take preference over another feature with the same attribute.</para>
		/// <para>Priority field is only used with the Most frequent cell assignment type option.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[KeyField("NONE")]
		public object PriorityField { get; set; } = "NONE";

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The cell size of the output raster being created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn’t been explicitly specified as the parameter value, the environment cell size value is used, if specified; otherwise, additional rules are used to calculate it from the other inputs. See Usages for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPCompositeDomain()]
		public object Cellsize { get; set; }

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
		public object BuildRat { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointToRaster SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object pyramid = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell assignment type</para>
		/// </summary>
		public enum CellAssignmentEnum 
		{
			/// <summary>
			/// <para>Most frequent—If there is more than one feature within the cell, the one with the most common attribute, in the Value field, is assigned to the cell. If they have the same number of common attributes, the one with the lowest FID is used.</para>
			/// </summary>
			[GPValue("MOST_FREQUENT")]
			[Description("Most frequent")]
			Most_frequent,

			/// <summary>
			/// <para>Sum—The sum of the attributes of all the points within the cell (not valid for string data).</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Mean—The mean of the attributes of all the points within the cell (not valid for string data).</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Standard deviation—The standard deviation of attributes of all the points within the cell. If there are less than two points in the cell, the cell is assigned NoData (not valid for string data).</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Maximum—The maximum value of the attributes of the points within the cell (not valid for string data).</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Minimum—The minimum value of the attributes of the points within the cell (not valid for string data).</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Range—The range of the attributes of the points within the cell (not valid for string data).</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("Range")]
			Range,

			/// <summary>
			/// <para>Count—The number of points within the cell.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count")]
			Count,

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
