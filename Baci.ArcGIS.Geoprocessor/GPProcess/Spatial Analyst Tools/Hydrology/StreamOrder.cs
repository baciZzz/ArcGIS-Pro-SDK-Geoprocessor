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
	/// <para>Stream Order</para>
	/// <para>Assigns a numeric order to segments of a raster representing branches of a linear network.</para>
	/// </summary>
	public class StreamOrder : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStreamRaster">
		/// <para>Input stream raster</para>
		/// <para>An input raster that represents a linear stream network.</para>
		/// <para>The input stream raster linear network should be represented as values greater than or equal to one on a background of NoData.</para>
		/// </param>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool, run using the default flow direction type D8.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output stream order raster.</para>
		/// <para>This output is of integer type.</para>
		/// </param>
		public StreamOrder(object InStreamRaster, object InFlowDirectionRaster, object OutRaster)
		{
			this.InStreamRaster = InStreamRaster;
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Stream Order</para>
		/// </summary>
		public override string DisplayName => "Stream Order";

		/// <summary>
		/// <para>Tool Name : StreamOrder</para>
		/// </summary>
		public override string ToolName => "StreamOrder";

		/// <summary>
		/// <para>Tool Excute Name : sa.StreamOrder</para>
		/// </summary>
		public override string ExcuteName => "sa.StreamOrder";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InStreamRaster, InFlowDirectionRaster, OutRaster, OrderMethod! };

		/// <summary>
		/// <para>Input stream raster</para>
		/// <para>An input raster that represents a linear stream network.</para>
		/// <para>The input stream raster linear network should be represented as values greater than or equal to one on a background of NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InStreamRaster { get; set; }

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool, run using the default flow direction type D8.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output stream order raster.</para>
		/// <para>This output is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Method of stream ordering</para>
		/// <para>The method used for assigning stream order.</para>
		/// <para>Strahler—The method of stream ordering proposed by Strahler in 1952. Stream order only increases when streams of the same order intersect. Therefore, the intersection of a first-order and second-order link will remain a second-order link, rather than creating a third-order link. This is the default.</para>
		/// <para>Shreve—The method of stream ordering by magnitude, proposed by Shreve in 1967. All links with no tributaries are assigned a magnitude (order) of one. Magnitudes are additive downslope. When two links intersect, their magnitudes are added and assigned to the downslope link.</para>
		/// <para><see cref="OrderMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OrderMethod { get; set; } = "STRAHLER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StreamOrder SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method of stream ordering</para>
		/// </summary>
		public enum OrderMethodEnum 
		{
			/// <summary>
			/// <para>Strahler—The method of stream ordering proposed by Strahler in 1952. Stream order only increases when streams of the same order intersect. Therefore, the intersection of a first-order and second-order link will remain a second-order link, rather than creating a third-order link. This is the default.</para>
			/// </summary>
			[GPValue("STRAHLER")]
			[Description("Strahler")]
			Strahler,

			/// <summary>
			/// <para>Shreve—The method of stream ordering by magnitude, proposed by Shreve in 1967. All links with no tributaries are assigned a magnitude (order) of one. Magnitudes are additive downslope. When two links intersect, their magnitudes are added and assigned to the downslope link.</para>
			/// </summary>
			[GPValue("SHREVE")]
			[Description("Shreve")]
			Shreve,

		}

#endregion
	}
}
