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
	/// <para>Flow Length</para>
	/// <para>Calculates the upstream or downstream distance, or weighted distance, along the flow path for each cell.</para>
	/// </summary>
	public class FlowLength : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster that shows for each cell the upstream or downstream distance along a flow path.</para>
		/// </param>
		public FlowLength(object InFlowDirectionRaster, object OutRaster)
		{
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Flow Length</para>
		/// </summary>
		public override string DisplayName() => "Flow Length";

		/// <summary>
		/// <para>Tool Name : FlowLength</para>
		/// </summary>
		public override string ToolName() => "FlowLength";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowLength</para>
		/// </summary>
		public override string ExcuteName() => "sa.FlowLength";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFlowDirectionRaster, OutRaster, DirectionMeasurement, InWeightRaster };

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster that shows for each cell the upstream or downstream distance along a flow path.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Direction of measurement</para>
		/// <para>The direction of measurement along the flow path.</para>
		/// <para>Downstream—Calculates the downslope distance along the flow path, from each cell to a sink or outlet on the edge of the raster.</para>
		/// <para>Upstream—Calculates the longest upslope distance along the flow path, from each cell to the top of the drainage divide.</para>
		/// <para><see cref="DirectionMeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DirectionMeasurement { get; set; } = "DOWNSTREAM";

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>An optional input raster for applying a weight to each cell.</para>
		/// <para>If no weight raster is specified, a default weight of 1 will be applied to each cell. For each cell in the output raster, the result will be the number of cells that flow into it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowLength SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Direction of measurement</para>
		/// </summary>
		public enum DirectionMeasurementEnum 
		{
			/// <summary>
			/// <para>Downstream—Calculates the downslope distance along the flow path, from each cell to a sink or outlet on the edge of the raster.</para>
			/// </summary>
			[GPValue("DOWNSTREAM")]
			[Description("Downstream")]
			Downstream,

			/// <summary>
			/// <para>Upstream—Calculates the longest upslope distance along the flow path, from each cell to the top of the drainage divide.</para>
			/// </summary>
			[GPValue("UPSTREAM")]
			[Description("Upstream")]
			Upstream,

		}

#endregion
	}
}
