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
	/// <para>Cost Path As Polyline</para>
	/// <para>Calculates the least-cost path from a source to a destination as a line feature.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalPathAsLine"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalPathAsLine))]
	public class CostPathAsPolyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDestinationData">
		/// <para>Input raster or feature destination data</para>
		/// <para>A raster or feature dataset that identifies those cells from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is a raster, it must consist of cells that have valid values for the destinations, and the remaining cells must be assigned NoData. Zero is a valid value.</para>
		/// </param>
		/// <param name="InCostDistanceRaster">
		/// <para>Input cost distance or euclidean distance raster</para>
		/// <para>The cost distance raster to be used to determine the least-cost path from the sources to the destinations.</para>
		/// <para>The cost distance raster is usually created with the Cost Distance, Cost Allocation, or Cost Back Link tools. The cost distance raster stores, for each cell, the minimum accumulative cost distance over a cost surface from each cell to a set of source cells.</para>
		/// </param>
		/// <param name="InCostBacklinkRaster">
		/// <para>Input cost backlink, back direction or flow direction raster</para>
		/// <para>The cost backlink raster to be used to determine the path to return to a source via the least-cost path, or the shortest path.</para>
		/// <para>For each cell in a backlink, back direction, or flow direction raster, the value identifies the neighbor that is the next cell on the path from that cell to a source cell.</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output polyline features</para>
		/// <para>The output feature class that will hold the least cost path.</para>
		/// </param>
		public CostPathAsPolyline(object InDestinationData, object InCostDistanceRaster, object InCostBacklinkRaster, object OutPolylineFeatures)
		{
			this.InDestinationData = InDestinationData;
			this.InCostDistanceRaster = InCostDistanceRaster;
			this.InCostBacklinkRaster = InCostBacklinkRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Cost Path As Polyline</para>
		/// </summary>
		public override string DisplayName() => "Cost Path As Polyline";

		/// <summary>
		/// <para>Tool Name : CostPathAsPolyline</para>
		/// </summary>
		public override string ToolName() => "CostPathAsPolyline";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostPathAsPolyline</para>
		/// </summary>
		public override string ExcuteName() => "sa.CostPathAsPolyline";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDestinationData, InCostDistanceRaster, InCostBacklinkRaster, OutPolylineFeatures, PathType, DestinationField, ForceFlowDirectionConvention };

		/// <summary>
		/// <para>Input raster or feature destination data</para>
		/// <para>A raster or feature dataset that identifies those cells from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is a raster, it must consist of cells that have valid values for the destinations, and the remaining cells must be assigned NoData. Zero is a valid value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDestinationData { get; set; }

		/// <summary>
		/// <para>Input cost distance or euclidean distance raster</para>
		/// <para>The cost distance raster to be used to determine the least-cost path from the sources to the destinations.</para>
		/// <para>The cost distance raster is usually created with the Cost Distance, Cost Allocation, or Cost Back Link tools. The cost distance raster stores, for each cell, the minimum accumulative cost distance over a cost surface from each cell to a set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostDistanceRaster { get; set; }

		/// <summary>
		/// <para>Input cost backlink, back direction or flow direction raster</para>
		/// <para>The cost backlink raster to be used to determine the path to return to a source via the least-cost path, or the shortest path.</para>
		/// <para>For each cell in a backlink, back direction, or flow direction raster, the value identifies the neighbor that is the next cell on the path from that cell to a source cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostBacklinkRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>The output feature class that will hold the least cost path.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>Specifies a keyword defining the manner in which the values and zones on the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>Best single— For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
		/// <para>Each zone— For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
		/// <para>Each cell— For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each cell.</para>
		/// <para><see cref="PathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PathType { get; set; } = "BEST_SINGLE";

		/// <summary>
		/// <para>Destination field</para>
		/// <para>The field to be used to obtain values for the destination locations.</para>
		/// <para>Input feature data must contain at least one valid field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object DestinationField { get; set; }

		/// <summary>
		/// <para>Force flow direction convention for backlink raster</para>
		/// <para>Forces the tool to treat the input backlink raster as a flow direction raster. Flow direction rasters can have integer values that range from 0-255.</para>
		/// <para>Unchecked—The Input cost backlink raster will be interpreted differently based on the range of values and if it is integer or float. For a value range of 0-8, the Input cost backlink raster will be treated as a backlink raster. For values 0-255 and integer, the Input cost backlink raster will be treated as a flow direction raster. For a value range of 0-360 and floating point, the Input cost backlink raster will be treated as a back direction raster.</para>
		/// <para>Checked—The raster supplied for the Input cost backlink raster will be treated as a flow direction raster. This is necessary if the flow direction raster has a maximum value of 8 or less.</para>
		/// <para><see cref="ForceFlowDirectionConventionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ForceFlowDirectionConvention { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostPathAsPolyline SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathTypeEnum 
		{
			/// <summary>
			/// <para>Best single— For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

			/// <summary>
			/// <para>Each cell— For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each cell.</para>
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

		}

		/// <summary>
		/// <para>Force flow direction convention for backlink raster</para>
		/// </summary>
		public enum ForceFlowDirectionConventionEnum 
		{
			/// <summary>
			/// <para>Unchecked—The Input cost backlink raster will be interpreted differently based on the range of values and if it is integer or float. For a value range of 0-8, the Input cost backlink raster will be treated as a backlink raster. For values 0-255 and integer, the Input cost backlink raster will be treated as a flow direction raster. For a value range of 0-360 and floating point, the Input cost backlink raster will be treated as a back direction raster.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INPUT_RANGE")]
			INPUT_RANGE,

			/// <summary>
			/// <para>Checked—The raster supplied for the Input cost backlink raster will be treated as a flow direction raster. This is necessary if the flow direction raster has a maximum value of 8 or less.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FLOW_DIRECTION")]
			FLOW_DIRECTION,

		}

#endregion
	}
}
