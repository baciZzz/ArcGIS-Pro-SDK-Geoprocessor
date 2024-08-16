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
	/// <para>Euclidean Allocation</para>
	/// <para>Calculates, for each cell, the nearest source based on Euclidean distance.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAllocation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAllocation))]
	public class EucAllocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceData">
		/// <para>Input raster or feature source data</para>
		/// <para>The input source locations.</para>
		/// <para>This is a raster or feature dataset that identifies the cells or locations to which the Euclidean distance for every output cell location is calculated.</para>
		/// <para>For rasters, the input type can be integer or floating point.</para>
		/// <para>If the input source raster is floating point, the Input value raster parameter must be set, and it must be integer. The value raster will take precedence over the Source field parameter setting.</para>
		/// </param>
		/// <param name="OutAllocationRaster">
		/// <para>Output allocation raster</para>
		/// <para>The output Euclidean allocation raster.</para>
		/// <para>The cell values (zones) identify the nearest source location.</para>
		/// <para>The output raster is of integer type.</para>
		/// </param>
		public EucAllocation(object InSourceData, object OutAllocationRaster)
		{
			this.InSourceData = InSourceData;
			this.OutAllocationRaster = OutAllocationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Euclidean Allocation</para>
		/// </summary>
		public override string DisplayName => "Euclidean Allocation";

		/// <summary>
		/// <para>Tool Name : EucAllocation</para>
		/// </summary>
		public override string ToolName => "EucAllocation";

		/// <summary>
		/// <para>Tool Excute Name : sa.EucAllocation</para>
		/// </summary>
		public override string ExcuteName => "sa.EucAllocation";

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
		public override object[] Parameters => new object[] { InSourceData, OutAllocationRaster, MaximumDistance, InValueRaster, CellSize, SourceField, OutDistanceRaster, OutDirectionRaster, DistanceMethod, InBarrierData, OutBackDirectionRaster };

		/// <summary>
		/// <para>Input raster or feature source data</para>
		/// <para>The input source locations.</para>
		/// <para>This is a raster or feature dataset that identifies the cells or locations to which the Euclidean distance for every output cell location is calculated.</para>
		/// <para>For rasters, the input type can be integer or floating point.</para>
		/// <para>If the input source raster is floating point, the Input value raster parameter must be set, and it must be integer. The value raster will take precedence over the Source field parameter setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSourceData { get; set; }

		/// <summary>
		/// <para>Output allocation raster</para>
		/// <para>The output Euclidean allocation raster.</para>
		/// <para>The cell values (zones) identify the nearest source location.</para>
		/// <para>The output raster is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutAllocationRaster { get; set; }

		/// <summary>
		/// <para>Maximum distance</para>
		/// <para>The threshold that the accumulative distance values cannot exceed.</para>
		/// <para>If an accumulative Euclidean distance value exceeds this value, the output value for the cell location will be NoData.</para>
		/// <para>The default distance is to the edge of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Input value raster</para>
		/// <para>The input integer raster that identifies the zone values that will be used for each input source location.</para>
		/// <para>For each source location (cell or feature), the Input value raster value will be assigned to all cells allocated to the source location for the computation. The value raster will take precedence over the Source field parameter setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InValueRaster { get; set; }

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
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Source field</para>
		/// <para>The field used to assign values to the source locations. It must be of integer type.</para>
		/// <para>If the Input value raster parameter has been set, the values in that input will have precedence over the Source field parameter setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object SourceField { get; set; }

		/// <summary>
		/// <para>Output distance raster</para>
		/// <para>The output Euclidean distance raster.</para>
		/// <para>The distance raster identifies, for each cell, the Euclidean distance to the closest source cell, set of source cells, or source location.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDistanceRaster { get; set; }

		/// <summary>
		/// <para>Output direction raster</para>
		/// <para>The output Euclidean direction raster.</para>
		/// <para>The direction raster contains the calculated direction, in degrees, that each cell center is from the closest source cell center.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees, with 0 reserved for the source cells. Due east (right) is 90, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// <para>The output raster is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDirectionRaster { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies whether to calculate the distance using a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
		/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Input raster or feature barrier data</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be defined by an integer or a floating-point raster, or by a feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InBarrierData { get; set; }

		/// <summary>
		/// <para>Out back direction raster</para>
		/// <para>The output Euclidean back direction raster.</para>
		/// <para>The back direction raster contains the calculated direction in degrees. The direction identifies the next cell along the shortest path back to the closest source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees, with 0 reserved for the source cells. Due east (right) is 90, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// <para>The output raster is of type float.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutBackDirectionRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EucAllocation SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
