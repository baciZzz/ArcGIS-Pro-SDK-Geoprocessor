using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Flow Direction</para>
	/// <para>Flow Direction</para>
	/// <para>Calculates the direction of flow from each cell to its downslope neighbor or neighbors using the D8, D-Infinity (DINF), or Multiple Flow Direction (MFD) method.</para>
	/// </summary>
	public class FlowDirection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="Outputflowdirectionname">
		/// <para>Output Flow Direction Name</para>
		/// <para>The name of the output flow direction raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public FlowDirection(object Inputsurfaceraster, object Outputflowdirectionname)
		{
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputflowdirectionname = Outputflowdirectionname;
		}

		/// <summary>
		/// <para>Tool Display Name : Flow Direction</para>
		/// </summary>
		public override string DisplayName() => "Flow Direction";

		/// <summary>
		/// <para>Tool Name : FlowDirection</para>
		/// </summary>
		public override string ToolName() => "FlowDirection";

		/// <summary>
		/// <para>Tool Excute Name : ra.FlowDirection</para>
		/// </summary>
		public override string ExcuteName() => "ra.FlowDirection";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputsurfaceraster, Outputflowdirectionname, Forceflow!, Flowdirectiontype!, Outputdropname!, Outputflowdirectionraster!, Outputdropraster! };

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Flow Direction Name</para>
		/// <para>The name of the output flow direction raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputflowdirectionname { get; set; }

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// <para>Specifies if edge cells will always flow outward or follow normal flow rules.</para>
		/// <para>Unchecked—If the maximum drop on the inside of an edge cell is greater than zero, the flow direction will be determined as usual; otherwise, the flow direction will be toward the edge. Cells that should flow from the edge of the surface raster inward will do so. This is the default.</para>
		/// <para>Checked—All cells at the edge of the surface raster will flow outward from the surface raster.</para>
		/// <para><see cref="ForceflowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Forceflow { get; set; } = "false";

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// <para>Specifies the type of flow method to use while computing flow directions.</para>
		/// <para>D8—Assign a flow direction based on the D8 flow method. This method assigns flow direction to the steepest downslope neighbor. This is the default.</para>
		/// <para>MFD—Assign a flow direction based on the MFD flow method. This method assigns multiple flow directions towards all downslope neighbors.</para>
		/// <para>DINF—Assign a flow direction based on the D-Infinity flow method using the steepest slope of a triangular facet.</para>
		/// <para><see cref="FlowdirectiontypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Flowdirectiontype { get; set; } = "D8";

		/// <summary>
		/// <para>Output Drop Name</para>
		/// <para>The name of the output drop raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputdropname { get; set; }

		/// <summary>
		/// <para>Output Flow Direction Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Drop Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputdropraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDirection SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// </summary>
		public enum ForceflowEnum 
		{
			/// <summary>
			/// <para>Checked—All cells at the edge of the surface raster will flow outward from the surface raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE")]
			FORCE,

			/// <summary>
			/// <para>Unchecked—If the maximum drop on the inside of an edge cell is greater than zero, the flow direction will be determined as usual; otherwise, the flow direction will be toward the edge. Cells that should flow from the edge of the surface raster inward will do so. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NORMAL")]
			NORMAL,

		}

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// </summary>
		public enum FlowdirectiontypeEnum 
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
