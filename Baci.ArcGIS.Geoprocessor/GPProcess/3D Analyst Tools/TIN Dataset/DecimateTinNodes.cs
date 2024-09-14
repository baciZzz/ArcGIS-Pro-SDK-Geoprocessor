using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Decimate TIN Nodes</para>
	/// <para>Decimate TIN Nodes</para>
	/// <para>Creates a triangulated irregular network (TIN) dataset using a subset of nodes from a source TIN.</para>
	/// </summary>
	public class DecimateTinNodes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Decimation Method</para>
		/// <para>Specifies the thinning method used for selecting a subset of nodes from the input TIN.</para>
		/// <para>Z Tolerance—Creates a TIN that will maintain the vertical accuracy specified in the Z Tolerance parameter. This is the default.</para>
		/// <para>Count—Creates a TIN that will not exceed the node limit specified in the Maximum Number of Nodes parameter.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public DecimateTinNodes(object InTin, object OutTin, object Method)
		{
			this.InTin = InTin;
			this.OutTin = OutTin;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : Decimate TIN Nodes</para>
		/// </summary>
		public override string DisplayName() => "Decimate TIN Nodes";

		/// <summary>
		/// <para>Tool Name : DecimateTinNodes</para>
		/// </summary>
		public override string ToolName() => "DecimateTinNodes";

		/// <summary>
		/// <para>Tool Excute Name : 3d.DecimateTinNodes</para>
		/// </summary>
		public override string ExcuteName() => "3d.DecimateTinNodes";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutTin, Method, CopyBreaklines, ZToleranceValue, MaxNodeValue };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Decimation Method</para>
		/// <para>Specifies the thinning method used for selecting a subset of nodes from the input TIN.</para>
		/// <para>Z Tolerance—Creates a TIN that will maintain the vertical accuracy specified in the Z Tolerance parameter. This is the default.</para>
		/// <para>Count—Creates a TIN that will not exceed the node limit specified in the Maximum Number of Nodes parameter.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "Z_TOLERANCE";

		/// <summary>
		/// <para>Copy Breaklines</para>
		/// <para>Indicates whether breaklines from the input TIN are copied over to the output.</para>
		/// <para>Unchecked—Breaklines will not be copied. This is the default.</para>
		/// <para>Checked—Breaklines will be copied.</para>
		/// <para><see cref="CopyBreaklinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CopyBreaklines { get; set; } = "false";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The maximum deviation from the source TIN's Z-value that will be allowed in the output TIN, which defaults to the lesser of either one-tenth of the Z-range or the number 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZToleranceValue { get; set; }

		/// <summary>
		/// <para>Maximum Number of Nodes</para>
		/// <para>The maximum number of nodes that can be stored in the output TIN, which defaults to the total number of nodes in the source TIN minus 1. If the Z-tolerance method is used, the tool will stop processing if the Z tolerance value causes the resulting TIN to exceed the maximum number of nodes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxNodeValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DecimateTinNodes SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object tinSaveVersion = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Decimation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Z Tolerance—Creates a TIN that will maintain the vertical accuracy specified in the Z Tolerance parameter. This is the default.</para>
			/// </summary>
			[GPValue("Z_TOLERANCE")]
			[Description("Z Tolerance")]
			Z_Tolerance,

			/// <summary>
			/// <para>Count—Creates a TIN that will not exceed the node limit specified in the Maximum Number of Nodes parameter.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count")]
			Count,

		}

		/// <summary>
		/// <para>Copy Breaklines</para>
		/// </summary>
		public enum CopyBreaklinesEnum 
		{
			/// <summary>
			/// <para>Checked—Breaklines will be copied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BREAKLINES")]
			BREAKLINES,

			/// <summary>
			/// <para>Unchecked—Breaklines will not be copied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BREAKLINES")]
			NO_BREAKLINES,

		}

#endregion
	}
}
