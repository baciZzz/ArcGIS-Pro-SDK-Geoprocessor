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
	/// <para>Region Group</para>
	/// <para>For each cell in the output, the identity of the connected region to which that cell belongs is recorded. A unique number is assigned to each region.</para>
	/// </summary>
	public class RegionGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster for which unique connected regions of cells will be identified.</para>
		/// <para>It must be of integer type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output region group raster.</para>
		/// <para>The output is always of integer type.</para>
		/// </param>
		public RegionGroup(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Region Group</para>
		/// </summary>
		public override string DisplayName() => "Region Group";

		/// <summary>
		/// <para>Tool Name : RegionGroup</para>
		/// </summary>
		public override string ToolName() => "RegionGroup";

		/// <summary>
		/// <para>Tool Excute Name : sa.RegionGroup</para>
		/// </summary>
		public override string ExcuteName() => "sa.RegionGroup";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberNeighbors, ZoneConnectivity, AddLink, ExcludedValue };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster for which unique connected regions of cells will be identified.</para>
		/// <para>It must be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output region group raster.</para>
		/// <para>The output is always of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// <para>Specifies the number of neighboring cells to use when evaluating connectivity between cells that define a region.</para>
		/// <para>Four—Connectivity is evaluated for the four nearest (orthogonal) neighbors of each input cell. Only the cells with the same value that share at least one side will contribute to an individual region. If two cells with the same value are diagonal from one another, they are not considered connected. This is the default.</para>
		/// <para>Eight—Connectivity is evaluated for the eight nearest neighbors (both orthogonal and diagonal) of each input cell. Cells with the same value that are connected either along a common edge or corner to each other will contribute to an individual region.</para>
		/// <para><see cref="NumberNeighborsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NumberNeighbors { get; set; } = "FOUR";

		/// <summary>
		/// <para>Zone grouping method</para>
		/// <para>Defines which cell values should be considered when testing for connectivity.</para>
		/// <para>Within—Connectivity for a region is evaluated for input cells that are part of the same zone (cell value). The only cells that can be grouped are cells from the same zone that meet the spatial requirements of connectivity specified by the Number of neighbors to use parameter (four or eight). This is the default.</para>
		/// <para>Cross—Connectivity for a region is evaluated between cells of any value, except for the zone cells identified to be excluded by the Excluded value parameter, and subject to the spatial requirements specified by the Number of neighbors to use parameter. Groupings of regions in the input that are separated from other groupings by a buffer of NoData cells will be processed independently from each other.</para>
		/// <para><see cref="ZoneConnectivityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ZoneConnectivity { get; set; } = "WITHIN";

		/// <summary>
		/// <para>Add link field to output</para>
		/// <para>Specifies whether a link field will be added to the table of the output when the Zone grouping method parameter is set to Within. It is ignored if that parameter is set to Cross.</para>
		/// <para>Checked—A LINK field will be added to the table of the output raster. This field stores the value of the zone to which the cells of each region in the output belong, according to the connectivity rule defined in the Number of neighbors to use parameter. This is the default.</para>
		/// <para>Unchecked—A LINK field will not be added. The attribute table for the output raster will only contain the Value and Count fields.</para>
		/// <para><see cref="AddLinkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddLink { get; set; } = "true";

		/// <summary>
		/// <para>Excluded value</para>
		/// <para>A value that excludes all cells of that zone from the connectivity evaluation. If a cell location contains the value, no spatial connectivity will be evaluated, regardless of how the number of neighbors is specified.</para>
		/// <para>Cells with the excluded value will be treated in a similar way to NoData cells, and are eliminated from consideration in the operation. Input cells that contain the excluded value will receive 0 on the output raster. The excluded value is similar to the concept of a background value.</para>
		/// <para>By default, there is no value defined for this parameter, which means that all of the input cells will be considered in the operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ExcludedValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegionGroup SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// </summary>
		public enum NumberNeighborsEnum 
		{
			/// <summary>
			/// <para>Four—Connectivity is evaluated for the four nearest (orthogonal) neighbors of each input cell. Only the cells with the same value that share at least one side will contribute to an individual region. If two cells with the same value are diagonal from one another, they are not considered connected. This is the default.</para>
			/// </summary>
			[GPValue("FOUR")]
			[Description("Four")]
			Four,

			/// <summary>
			/// <para>Eight—Connectivity is evaluated for the eight nearest neighbors (both orthogonal and diagonal) of each input cell. Cells with the same value that are connected either along a common edge or corner to each other will contribute to an individual region.</para>
			/// </summary>
			[GPValue("EIGHT")]
			[Description("Eight")]
			Eight,

		}

		/// <summary>
		/// <para>Zone grouping method</para>
		/// </summary>
		public enum ZoneConnectivityEnum 
		{
			/// <summary>
			/// <para>Within—Connectivity for a region is evaluated for input cells that are part of the same zone (cell value). The only cells that can be grouped are cells from the same zone that meet the spatial requirements of connectivity specified by the Number of neighbors to use parameter (four or eight). This is the default.</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("Within")]
			Within,

			/// <summary>
			/// <para>Cross—Connectivity for a region is evaluated between cells of any value, except for the zone cells identified to be excluded by the Excluded value parameter, and subject to the spatial requirements specified by the Number of neighbors to use parameter. Groupings of regions in the input that are separated from other groupings by a buffer of NoData cells will be processed independently from each other.</para>
			/// </summary>
			[GPValue("CROSS")]
			[Description("Cross")]
			Cross,

		}

		/// <summary>
		/// <para>Add link field to output</para>
		/// </summary>
		public enum AddLinkEnum 
		{
			/// <summary>
			/// <para>Checked—A LINK field will be added to the table of the output raster. This field stores the value of the zone to which the cells of each region in the output belong, according to the connectivity rule defined in the Number of neighbors to use parameter. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_LINK")]
			ADD_LINK,

			/// <summary>
			/// <para>Unchecked—A LINK field will not be added. The attribute table for the output raster will only contain the Value and Count fields.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LINK")]
			NO_LINK,

		}

#endregion
	}
}
