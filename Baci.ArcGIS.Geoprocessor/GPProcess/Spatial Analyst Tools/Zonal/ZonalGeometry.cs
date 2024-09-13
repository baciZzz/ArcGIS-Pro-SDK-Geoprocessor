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
	/// <para>Zonal Geometry</para>
	/// <para>Zonal Geometry</para>
	/// <para>Calculates the specified geometry measure (area, perimeter, thickness, or the characteristics of ellipse) for each zone in a dataset.</para>
	/// </summary>
	public class ZonalGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneData">
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </param>
		/// <param name="ZoneField">
		/// <para>Zone field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It must be an integer field of the zone dataset.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output zonal geometry raster.</para>
		/// </param>
		public ZonalGeometry(object InZoneData, object ZoneField, object OutRaster)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Zonal Geometry</para>
		/// </summary>
		public override string DisplayName() => "Zonal Geometry";

		/// <summary>
		/// <para>Tool Name : ZonalGeometry</para>
		/// </summary>
		public override string ToolName() => "ZonalGeometry";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalGeometry</para>
		/// </summary>
		public override string ExcuteName() => "sa.ZonalGeometry";

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
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, OutRaster, GeometryType!, CellSize! };

		/// <summary>
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It must be an integer field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output zonal geometry raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Geometry type</para>
		/// <para>Geometry type to be calculated.</para>
		/// <para>Area—The area for each zone.</para>
		/// <para>Perimeter—The perimeter for each zone.</para>
		/// <para>Thickness—The deepest (or thickest) point within the zone from its surrounding cells.</para>
		/// <para>Centroid—Locates the centroids of each zone.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "AREA";

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalGeometry SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Area—The area for each zone.</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("Area")]
			Area,

			/// <summary>
			/// <para>Perimeter—The perimeter for each zone.</para>
			/// </summary>
			[GPValue("PERIMETER")]
			[Description("Perimeter")]
			Perimeter,

			/// <summary>
			/// <para>Thickness—The deepest (or thickest) point within the zone from its surrounding cells.</para>
			/// </summary>
			[GPValue("THICKNESS")]
			[Description("Thickness")]
			Thickness,

			/// <summary>
			/// <para>Centroid—Locates the centroids of each zone.</para>
			/// </summary>
			[GPValue("CENTROID")]
			[Description("Centroid")]
			Centroid,

		}

#endregion
	}
}
