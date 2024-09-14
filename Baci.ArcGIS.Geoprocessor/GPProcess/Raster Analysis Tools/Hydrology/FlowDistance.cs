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
	/// <para>Flow Distance</para>
	/// <para>Flow Distance</para>
	/// <para>Computes, for each cell, the horizontal or vertical component of downslope distance, following the flow paths, to cells on a stream into which they flow. In the case of multiple flow paths, minimum, weighted mean, or maximum flow distance can be computed.</para>
	/// </summary>
	public class FlowDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputstreamraster">
		/// <para>Input Stream Raster</para>
		/// <para>The input raster that defines the stream network.</para>
		/// </param>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output flow distance raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public FlowDistance(object Inputstreamraster, object Inputsurfaceraster, object Outputname)
		{
			this.Inputstreamraster = Inputstreamraster;
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.FlowDistance</para>
		/// </summary>
		public override string ExcuteName() => "ra.FlowDistance";

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
		public override object[] Parameters() => new object[] { Inputstreamraster, Inputsurfaceraster, Outputname, Inputflowdirectionraster!, Distancetype!, Flowdirectiontype!, Outputraster!, Statisticstype! };

		/// <summary>
		/// <para>Input Stream Raster</para>
		/// <para>The input raster that defines the stream network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputstreamraster { get; set; }

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output flow distance raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>When a flow direction raster is provided, the down slope direction(s) will be limited to those defined by the input flow directions.</para>
		/// <para>The flow direction raster can be created using the D8, MFD, or DINF method. Use the Flow Direction Type parameter to specify the method used when the flow direction raster was created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The distance type to be calculated.</para>
		/// <para>Vertical—The flow distance calculations represent the vertical component of minimum flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow. This is the default.</para>
		/// <para>Horizontal—The flow distance calculations represent the horizontal component of minimum flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow.</para>
		/// <para><see cref="DistancetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Distancetype { get; set; } = "VERTICAL";

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// <para>Specifies the input flow direction raster type.</para>
		/// <para>D8—The input flow direction raster is of type D8. This is the default.</para>
		/// <para>MFD—The input flow direction raster is of type Multi Flow Direction (MFD).</para>
		/// <para>DINF—The input flow direction raster is of type D-Infinity (DINF).</para>
		/// <para><see cref="FlowdirectiontypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Flowdirectiontype { get; set; } = "D8";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>Determines the statistics type used to compute flow distance over multiple flow paths.</para>
		/// <para>If there exists only a single flow path from each cell to a cell on the stream, all statistics types produce the same result.</para>
		/// <para>Minimum—Where multiple flow paths exist, minimum flow distance is computed. This is the default.</para>
		/// <para>Weighted Mean—Where multiple flow paths exist, a weighted mean of flow distance is computed. Flow proportion from a cell to its downstream neighboring cells is used as a weight for computing weighted mean.</para>
		/// <para>Maximum—When multiple flow paths exist, maximum flow distance is computed.</para>
		/// <para><see cref="StatisticstypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Statisticstype { get; set; } = "MINIMUM";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDistance SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Type</para>
		/// </summary>
		public enum DistancetypeEnum 
		{
			/// <summary>
			/// <para>Vertical—The flow distance calculations represent the vertical component of minimum flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow. This is the default.</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("Vertical")]
			Vertical,

			/// <summary>
			/// <para>Horizontal—The flow distance calculations represent the horizontal component of minimum flow distance, following the flow path, from each cell in the domain to cell(s) on the stream into which they flow.</para>
			/// </summary>
			[GPValue("HORIZONTAL")]
			[Description("Horizontal")]
			Horizontal,

		}

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// </summary>
		public enum FlowdirectiontypeEnum 
		{
			/// <summary>
			/// <para>D8—The input flow direction raster is of type D8. This is the default.</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—The input flow direction raster is of type Multi Flow Direction (MFD).</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

			/// <summary>
			/// <para>DINF—The input flow direction raster is of type D-Infinity (DINF).</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticstypeEnum 
		{
			/// <summary>
			/// <para>Minimum—Where multiple flow paths exist, minimum flow distance is computed. This is the default.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—When multiple flow paths exist, maximum flow distance is computed.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Weighted Mean—Where multiple flow paths exist, a weighted mean of flow distance is computed. Flow proportion from a cell to its downstream neighboring cells is used as a weight for computing weighted mean.</para>
			/// </summary>
			[GPValue("WEIGHTED_MEAN")]
			[Description("Weighted Mean")]
			Weighted_Mean,

		}

#endregion
	}
}
