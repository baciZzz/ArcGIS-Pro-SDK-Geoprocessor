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
	/// <para>Cost Path</para>
	/// <para>Calculates the least-cost path from a source to a destination.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalPathAsRaster"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalPathAsRaster))]
	public class CostPath : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDestinationData">
		/// <para>Input raster or feature destination data</para>
		/// <para>A raster or feature dataset that identifies those cells from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is a raster, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </param>
		/// <param name="InCostDistanceRaster">
		/// <para>Input cost distance raster</para>
		/// <para>The name of a cost distance raster to be used to determine the least-cost path from the destination locations to a source.</para>
		/// <para>The cost distance raster is usually created with the Cost Distance, Cost Allocation or Cost Back Link tools. The cost distance raster stores, for each cell, the minimum accumulative cost distance over a cost surface from each cell to a set of source cells.</para>
		/// </param>
		/// <param name="InCostBacklinkRaster">
		/// <para>Input cost backlink raster</para>
		/// <para>The name of a cost back link raster used to determine the path to return to a source via the least-cost path.</para>
		/// <para>For each cell in the back link raster, a value identifies the neighbor that is the next cell on the least accumulative cost path from the cell to a single source cell or set of source cells.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output cost path raster.</para>
		/// <para>The output raster is of integer type.</para>
		/// </param>
		public CostPath(object InDestinationData, object InCostDistanceRaster, object InCostBacklinkRaster, object OutRaster)
		{
			this.InDestinationData = InDestinationData;
			this.InCostDistanceRaster = InCostDistanceRaster;
			this.InCostBacklinkRaster = InCostBacklinkRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Cost Path</para>
		/// </summary>
		public override string DisplayName => "Cost Path";

		/// <summary>
		/// <para>Tool Name : CostPath</para>
		/// </summary>
		public override string ToolName => "CostPath";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostPath</para>
		/// </summary>
		public override string ExcuteName => "sa.CostPath";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "compression", "configKeyword", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDestinationData, InCostDistanceRaster, InCostBacklinkRaster, OutRaster, PathType!, DestinationField!, ForceFlowDirectionConvention! };

		/// <summary>
		/// <para>Input raster or feature destination data</para>
		/// <para>A raster or feature dataset that identifies those cells from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is a raster, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InDestinationData { get; set; }

		/// <summary>
		/// <para>Input cost distance raster</para>
		/// <para>The name of a cost distance raster to be used to determine the least-cost path from the destination locations to a source.</para>
		/// <para>The cost distance raster is usually created with the Cost Distance, Cost Allocation or Cost Back Link tools. The cost distance raster stores, for each cell, the minimum accumulative cost distance over a cost surface from each cell to a set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InCostDistanceRaster { get; set; }

		/// <summary>
		/// <para>Input cost backlink raster</para>
		/// <para>The name of a cost back link raster used to determine the path to return to a source via the least-cost path.</para>
		/// <para>For each cell in the back link raster, a value identifies the neighbor that is the next cell on the least accumulative cost path from the cell to a single source cell or set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InCostBacklinkRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output cost path raster.</para>
		/// <para>The output raster is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>A keyword defining the manner in which the values and zones on the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>Each cell— For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each from cell.</para>
		/// <para>Each zone— For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
		/// <para>Best single— For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
		/// <para><see cref="PathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PathType { get; set; } = "EACH_CELL";

		/// <summary>
		/// <para>Destination field</para>
		/// <para>The field used to obtain values for the destination locations.</para>
		/// <para>Input feature data must contain at least one valid field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? DestinationField { get; set; }

		/// <summary>
		/// <para>Force flow direction convention for backlink raster</para>
		/// <para>Specifies whether the input backlink raster will be treated as a flow direction raster. Flow direction rasters can have integer values that range from 0-255.</para>
		/// <para>Unchecked—The Input cost backlink raster value will be interpreted based on the range of values and if it is integer or float. For a value range of 0-8, the Input cost backlink raster value will be treated as a backlink raster. For values 0-255 and integer, the Input cost backlink raster value will be treated as a flow direction raster. For a value range of 0-360 and floating point, the Input cost backlink raster value will be treated as a back direction raster.</para>
		/// <para>Checked—The raster supplied for the Input cost backlink raster parameter will be treated as a flow direction raster. This is necessary if the flow direction raster has a maximum value of 8 or less.</para>
		/// <para><see cref="ForceFlowDirectionConventionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ForceFlowDirectionConvention { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostPath SetEnviroment(int? autoCommit = null , object? compression = null , object? configKeyword = null , object? scratchWorkspace = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathTypeEnum 
		{
			/// <summary>
			/// <para>Each cell— For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each from cell.</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("Each cell")]
			Each_cell,

			/// <summary>
			/// <para>Each zone— For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("Each zone")]
			Each_zone,

			/// <summary>
			/// <para>Best single— For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

		}

		/// <summary>
		/// <para>Force flow direction convention for backlink raster</para>
		/// </summary>
		public enum ForceFlowDirectionConventionEnum 
		{
			/// <summary>
			/// <para>Unchecked—The Input cost backlink raster value will be interpreted based on the range of values and if it is integer or float. For a value range of 0-8, the Input cost backlink raster value will be treated as a backlink raster. For values 0-255 and integer, the Input cost backlink raster value will be treated as a flow direction raster. For a value range of 0-360 and floating point, the Input cost backlink raster value will be treated as a back direction raster.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INPUT_RANGE")]
			INPUT_RANGE,

			/// <summary>
			/// <para>Checked—The raster supplied for the Input cost backlink raster parameter will be treated as a flow direction raster. This is necessary if the flow direction raster has a maximum value of 8 or less.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FLOW_DIRECTION")]
			FLOW_DIRECTION,

		}

#endregion
	}
}
