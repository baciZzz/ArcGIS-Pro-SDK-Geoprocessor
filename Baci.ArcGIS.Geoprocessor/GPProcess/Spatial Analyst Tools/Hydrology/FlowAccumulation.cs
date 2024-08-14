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
	/// <para>Flow Accumulation</para>
	/// <para>Creates a raster of accumulated flow into each cell. A weight factor can optionally be applied.</para>
	/// </summary>
	public class FlowAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool.</para>
		/// <para>The flow direction raster can be created using the D8, Multiple Flow Direction (MFD), or D-Infinity method. Use the Input flow direction type parameter to specify the method used when the flow direction raster was created.</para>
		/// </param>
		/// <param name="OutAccumulationRaster">
		/// <para>Output accumulation raster</para>
		/// <para>The output raster that shows the accumulated flow to each cell.</para>
		/// </param>
		public FlowAccumulation(object InFlowDirectionRaster, object OutAccumulationRaster)
		{
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutAccumulationRaster = OutAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Flow Accumulation</para>
		/// </summary>
		public override string DisplayName => "Flow Accumulation";

		/// <summary>
		/// <para>Tool Name : FlowAccumulation</para>
		/// </summary>
		public override string ToolName => "FlowAccumulation";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowAccumulation</para>
		/// </summary>
		public override string ExcuteName => "sa.FlowAccumulation";

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
		public override object[] Parameters => new object[] { InFlowDirectionRaster, OutAccumulationRaster, InWeightRaster, DataType, FlowDirectionType };

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool.</para>
		/// <para>The flow direction raster can be created using the D8, Multiple Flow Direction (MFD), or D-Infinity method. Use the Input flow direction type parameter to specify the method used when the flow direction raster was created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output accumulation raster</para>
		/// <para>The output raster that shows the accumulated flow to each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>An optional input raster for applying a weight to each cell.</para>
		/// <para>If no weight raster is specified, a default weight of 1 will be applied to each cell. For each cell in the output raster, the result will be the number of cells that flow into it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Output data type</para>
		/// <para>The output accumulation raster can be integer, floating point, or double type.</para>
		/// <para>Float—The output raster will be floating point type. This is the default.</para>
		/// <para>Integer—The output raster will be integer type.</para>
		/// <para>Double—The output raster will be double type.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "FLOAT";

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
		public object FlowDirectionType { get; set; } = "D8";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowAccumulation SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Float—The output raster will be floating point type. This is the default.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float")]
			Float,

			/// <summary>
			/// <para>Integer—The output raster will be integer type.</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("Integer")]
			Integer,

			/// <summary>
			/// <para>Double—The output raster will be double type.</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double")]
			Double,

		}

		/// <summary>
		/// <para>Input flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>D8—The input flow direction raster is of type D8. This is the default.</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>DINF—The input flow direction raster is of type D-Infinity (DINF).</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

#endregion
	}
}
