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
	/// <para>Lookup</para>
	/// <para>Lookup</para>
	/// <para>Creates a raster by looking up values in another field in the table of the input raster.</para>
	/// </summary>
	public class Lookup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster that contains a field from which to create a new raster.</para>
		/// </param>
		/// <param name="LookupField">
		/// <para>Lookup field</para>
		/// <para>Field containing the desired values for the new raster.</para>
		/// <para>It can be a numeric or string type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster whose values are determined by the specified field of the input raster.</para>
		/// </param>
		public Lookup(object InRaster, object LookupField, object OutRaster)
		{
			this.InRaster = InRaster;
			this.LookupField = LookupField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Lookup</para>
		/// </summary>
		public override string DisplayName() => "Lookup";

		/// <summary>
		/// <para>Tool Name : Lookup</para>
		/// </summary>
		public override string ToolName() => "Lookup";

		/// <summary>
		/// <para>Tool Excute Name : sa.Lookup</para>
		/// </summary>
		public override string ExcuteName() => "sa.Lookup";

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
		public override object[] Parameters() => new object[] { InRaster, LookupField, OutRaster };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster that contains a field from which to create a new raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Lookup field</para>
		/// <para>Field containing the desired values for the new raster.</para>
		/// <para>It can be a numeric or string type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object LookupField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster whose values are determined by the specified field of the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Lookup SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
