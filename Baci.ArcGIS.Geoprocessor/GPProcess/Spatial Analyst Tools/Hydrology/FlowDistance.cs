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
	/// <para>Flow Distance</para>
	/// <para>Flow Distance</para>
	/// <para>Computes, for each cell, the horizontal or vertical component of downslope distance, following the flow paths, to cells on a stream into which they flow. In case of multiple flow paths, minimum, weighted mean, or maximum flow distance can be computed.</para>
	/// </summary>
	public class FlowDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStreamRaster">
		/// <para>Input stream raster</para>
		/// <para>An input stream raster that represents a linear stream network.</para>
		/// </param>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output flow distance raster.</para>
		/// </param>
		public FlowDistance(object InStreamRaster, object InSurfaceRaster, object OutRaster)
		{
			this.InStreamRaster = InStreamRaster;
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Flow Distance</para>
		/// </summary>
		public override string DisplayName() => "Flow Distance";

		/// <summary>
		/// <para>Tool Name : FlowDistance</para>
		/// </summary>
		public override string ToolName() => "FlowDistance";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowDistance</para>
		/// </summary>
		public override string ExcuteName() => "sa.FlowDistance";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InStreamRaster, InSurfaceRaster, OutRaster, InFlowDirectionRaster!, DistanceType!, FlowDirectionType!, StatisticsType! };

		/// <summary>
		/// <para>Input stream raster</para>
		/// <para>An input stream raster that represents a linear stream network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InStreamRaster { get; set; }

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output flow distance raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>When a flow direction raster is provided, the down slope direction(s) will be limited to those defined by the input flow directions.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool.</para>
		/// <para>The flow direction raster can be created using the D8, Multiple Flow Direction (MFD), or D-Infinity method. Use the Input flow direction type parameter to specify the method used when the flow direction raster was created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Distance type</para>
		/// <para>Determines if the vertical or horizontal component of flow distance is calculated.</para>
		/// <para>Vertical—The flow distance calculations represent the vertical component of flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow. This is the default.</para>
		/// <para>Horizontal—The flow distance calculations represent the horizontal component of flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow.</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceType { get; set; } = "VERTICAL";

		/// <summary>
		/// <para>Input flow direction type</para>
		/// <para>Specifies the input flow direction raster type.</para>
		/// <para>D8—The input flow direction raster is of type D8. This is the default.</para>
		/// <para>MFD—The input flow direction raster is of type Multi Flow Direction (MFD).</para>
		/// <para>DINF—The input flow direction raster is of type D-Infinity (DINF).</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlowDirectionType { get; set; } = "MFD";

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>Determines the statistics type used to compute flow distance over multiple flow paths. If there is only a single flow path from each cell to a cell on the stream, all statistics types produce the same result.</para>
		/// <para>Minimum—Where multiple flow paths exist, minimum flow distance in computed. This is the default.</para>
		/// <para>Weighted Mean—Where multiple flow paths exist, a weighted mean of flow distance is computed. Flow proportion from a cell to its downstream neighboring cells are used as weights for computing weighted mean.</para>
		/// <para>Maximum—When multiple flow paths exist, maximum flow distance is computed.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MINIMUM";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDistance SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance type</para>
		/// </summary>
		public enum DistanceTypeEnum 
		{
			/// <summary>
			/// <para>Vertical—The flow distance calculations represent the vertical component of flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow. This is the default.</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("Vertical")]
			Vertical,

			/// <summary>
			/// <para>Horizontal—The flow distance calculations represent the horizontal component of flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow.</para>
			/// </summary>
			[GPValue("HORIZONTAL")]
			[Description("Horizontal")]
			Horizontal,

		}

		/// <summary>
		/// <para>Input flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>MFD—The input flow direction raster is of type Multi Flow Direction (MFD).</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

		}

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Minimum—Where multiple flow paths exist, minimum flow distance in computed. This is the default.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Weighted Mean—Where multiple flow paths exist, a weighted mean of flow distance is computed. Flow proportion from a cell to its downstream neighboring cells are used as weights for computing weighted mean.</para>
			/// </summary>
			[GPValue("WEIGHTED_MEAN")]
			[Description("Weighted Mean")]
			Weighted_Mean,

			/// <summary>
			/// <para>Maximum—When multiple flow paths exist, maximum flow distance is computed.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

		}

#endregion
	}
}
