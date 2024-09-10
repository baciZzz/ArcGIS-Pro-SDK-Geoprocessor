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
	/// <para>Flow Accumulation</para>
	/// <para>Creates a raster of accumulated flow into each cell.</para>
	/// </summary>
	public class FlowAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputflowdirectionraster">
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the D8, MFD, or DINF method. Use the Flow Direction Type parameter to specify the method used when the flow direction raster was created.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output flow accumulation raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public FlowAccumulation(object Inputflowdirectionraster, object Outputname)
		{
			this.Inputflowdirectionraster = Inputflowdirectionraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Flow Accumulation</para>
		/// </summary>
		public override string DisplayName() => "Flow Accumulation";

		/// <summary>
		/// <para>Tool Name : FlowAccumulation</para>
		/// </summary>
		public override string ToolName() => "FlowAccumulation";

		/// <summary>
		/// <para>Tool Excute Name : ra.FlowAccumulation</para>
		/// </summary>
		public override string ExcuteName() => "ra.FlowAccumulation";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputflowdirectionraster, Outputname, Inputweightraster, Datatype, Flowdirectiontype, Outputraster };

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the D8, MFD, or DINF method. Use the Flow Direction Type parameter to specify the method used when the flow direction raster was created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output flow accumulation raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Input Weight Raster</para>
		/// <para>An optional integer input raster for applying a weight to each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputweightraster { get; set; }

		/// <summary>
		/// <para>Output Data Type</para>
		/// <para>The output accumulation raster can be integer, floating or double type.</para>
		/// <para>Float—The output raster will be floating point type. This is the default.</para>
		/// <para>Integer—The output raster will be integer type.</para>
		/// <para>Double—The output raster will be double type.</para>
		/// <para><see cref="DatatypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Datatype { get; set; } = "FLOAT";

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
		public object Flowdirectiontype { get; set; } = "D8";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowAccumulation SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Data Type</para>
		/// </summary>
		public enum DatatypeEnum 
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

#endregion
	}
}
