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
	/// <para>Flow Direction</para>
	/// <para>Creates a raster of flow direction from each cell to its downslope neighbor, or neighbors, using the D8, Multiple Flow Direction (MFD), or D-Infinity (DINF) method.</para>
	/// </summary>
	public class FlowDirection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="OutFlowDirectionRaster">
		/// <para>Output flow direction raster</para>
		/// <para>The output raster that shows the flow direction from each cell to its downslope neighbor(s) using D8, Multiple Flow Direction (MFD) or D-Infinity (DINF) methods.</para>
		/// <para>This output is of integer type.</para>
		/// </param>
		public FlowDirection(object InSurfaceRaster, object OutFlowDirectionRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutFlowDirectionRaster = OutFlowDirectionRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Flow Direction</para>
		/// </summary>
		public override string DisplayName => "Flow Direction";

		/// <summary>
		/// <para>Tool Name : FlowDirection</para>
		/// </summary>
		public override string ToolName => "FlowDirection";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowDirection</para>
		/// </summary>
		public override string ExcuteName => "sa.FlowDirection";

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
		public override object[] Parameters => new object[] { InSurfaceRaster, OutFlowDirectionRaster, ForceFlow, OutDropRaster, FlowDirectionType };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output flow direction raster</para>
		/// <para>The output raster that shows the flow direction from each cell to its downslope neighbor(s) using D8, Multiple Flow Direction (MFD) or D-Infinity (DINF) methods.</para>
		/// <para>This output is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// <para>Specifies if edge cells will always flow outward or follow normal flow rules.</para>
		/// <para>Unchecked—If the maximum drop on the inside of an edge cell is greater than zero, the flow direction will be determined as usual; otherwise, the flow direction will be toward the edge. Cells that should flow from the edge of the surface raster inward will do so. This is the default.</para>
		/// <para>Checked—All cells at the edge of the surface raster will flow outward from the surface raster.</para>
		/// <para><see cref="ForceFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ForceFlow { get; set; } = "false";

		/// <summary>
		/// <para>Output drop raster</para>
		/// <para>An optional output drop raster.</para>
		/// <para>The drop raster returns the ratio of the maximum change in elevation from each cell along the direction of flow to the path length between centers of cells, expressed in percentages.</para>
		/// <para>This output is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDropRaster { get; set; }

		/// <summary>
		/// <para>Flow direction type</para>
		/// <para>Specifies the type of flow method to use while computing flow directions.</para>
		/// <para>D8—Assign a flow direction based on the D8 flow method. This method assigns flow direction to the steepest downslope neighbor. This is the default.</para>
		/// <para>MFD—Assign a flow direction based on the MFD flow method. This method assigns multiple flow directions towards all downslope neighbors.</para>
		/// <para>DINF—Assign a flow direction based on the D-Infinity flow method using the steepest slope of a triangular facet.</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FlowDirectionType { get; set; } = "D8";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDirection SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// </summary>
		public enum ForceFlowEnum 
		{
			/// <summary>
			/// <para>Unchecked—If the maximum drop on the inside of an edge cell is greater than zero, the flow direction will be determined as usual; otherwise, the flow direction will be toward the edge. Cells that should flow from the edge of the surface raster inward will do so. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NORMAL")]
			NORMAL,

			/// <summary>
			/// <para>Checked—All cells at the edge of the surface raster will flow outward from the surface raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE")]
			FORCE,

		}

		/// <summary>
		/// <para>Flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>D8—Assign a flow direction based on the D8 flow method. This method assigns flow direction to the steepest downslope neighbor. This is the default.</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—Assign a flow direction based on the MFD flow method. This method assigns multiple flow directions towards all downslope neighbors.</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

			/// <summary>
			/// <para>DINF—Assign a flow direction based on the D-Infinity flow method using the steepest slope of a triangular facet.</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

#endregion
	}
}
