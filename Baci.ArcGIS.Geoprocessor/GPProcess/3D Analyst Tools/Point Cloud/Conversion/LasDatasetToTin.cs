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
	/// <para>LAS Dataset To TIN</para>
	/// <para>LAS Dataset To TIN</para>
	/// <para>Exports a triangulated irregular network (TIN) from a  LAS dataset.</para>
	/// </summary>
	public class LasDatasetToTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </param>
		public LasDatasetToTin(object InLasDataset, object OutTin)
		{
			this.InLasDataset = InLasDataset;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Dataset To TIN</para>
		/// </summary>
		public override string DisplayName() => "LAS Dataset To TIN";

		/// <summary>
		/// <para>Tool Name : LasDatasetToTin</para>
		/// </summary>
		public override string ToolName() => "LasDatasetToTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasDatasetToTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.LasDatasetToTin";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutTin, ThinningType, ThinningMethod, ThinningValue, MaxNodes, ZFactor, ClipToExtent };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Thinning Type</para>
		/// <para>Specifies the type of thinning to be used to reduce the LAS data points saved as the nodes in the resulting TIN.</para>
		/// <para>No Thinning—No thinning is applied. This is the default.</para>
		/// <para>Random—LAS data points are randomly selected based on the corresponding Thinning Method selection and Thinning Value entry.</para>
		/// <para>Window Size—The LAS dataset is divided into square tiles defined by Thinning Value and LAS points are selected using Thinning Method.</para>
		/// <para><see cref="ThinningTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThinningType { get; set; } = "NONE";

		/// <summary>
		/// <para>Thinning Method</para>
		/// <para>Specifies the technique to be used to reduce the LAS data points, which impacts the interpretation of Thinning Value. The available options depend on the selected Thinning Type.</para>
		/// <para>Percent—Thinning value will reflect the percentage of LAS points that will be preserved in the output</para>
		/// <para>Node Count—Thinning value will reflect the total number of nodes that are allowed in the output</para>
		/// <para>Minimum Z—Selects the LAS data point with the lowest elevation in each window size area</para>
		/// <para>Maximum Z—Selects the LAS data point with the highest elevation in each of the automatically determined window size areas</para>
		/// <para>Closest To Mean Z—Selects the LAS data point with the elevation closest to the average value found in the automatically determined window size areas</para>
		/// <para><see cref="ThinningMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThinningMethod { get; set; }

		/// <summary>
		/// <para>Thinning Value</para>
		/// <para>The thinning value&apos;s interpretation depends on the selection made for Thinning Type.</para>
		/// <para>If Thinning Type is set to Window Size, this value represents the sampling area by which the LAS dataset will be divided.</para>
		/// <para>If Thinning Type is set to Random and Thinning Method is set to Percent, this value represents the percentage of LAS points that will be exported to the TIN.</para>
		/// <para>If Thinning Type is set to Random and Thinning Method is set to Node Count, this value represents the total number of LAS points that can be exported to the TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ThinningValue { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Number of Output Nodes</para>
		/// <para>The maximum number of nodes permitted in the output TIN. The default is 5 million.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaxNodes { get; set; } = "5000000";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Clip to Extent</para>
		/// <para>Specifies whether the resulting TIN will be clipped against the analysis extent. This only has an effect if the analysis extent is a subset of the input LAS dataset.</para>
		/// <para>Checked—Clips the output TIN against the analysis extent. This is the default.</para>
		/// <para>Unchecked—Does not clip the output TIN against the analysis extent.</para>
		/// <para><see cref="ClipToExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipToExtent { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasDatasetToTin SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object tinSaveVersion = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Thinning Type</para>
		/// </summary>
		public enum ThinningTypeEnum 
		{
			/// <summary>
			/// <para>No Thinning—No thinning is applied. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No Thinning")]
			No_Thinning,

			/// <summary>
			/// <para>Random—LAS data points are randomly selected based on the corresponding Thinning Method selection and Thinning Value entry.</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("Random")]
			Random,

			/// <summary>
			/// <para>Window Size—The LAS dataset is divided into square tiles defined by Thinning Value and LAS points are selected using Thinning Method.</para>
			/// </summary>
			[GPValue("WINDOW_SIZE")]
			[Description("Window Size")]
			Window_Size,

		}

		/// <summary>
		/// <para>Thinning Method</para>
		/// </summary>
		public enum ThinningMethodEnum 
		{
			/// <summary>
			/// <para>Percent—Thinning value will reflect the percentage of LAS points that will be preserved in the output</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("Percent")]
			Percent,

			/// <summary>
			/// <para>Node Count—Thinning value will reflect the total number of nodes that are allowed in the output</para>
			/// </summary>
			[GPValue("NODE_COUNT")]
			[Description("Node Count")]
			Node_Count,

			/// <summary>
			/// <para>Minimum Z—Selects the LAS data point with the lowest elevation in each window size area</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum Z")]
			Minimum_Z,

			/// <summary>
			/// <para>Maximum Z—Selects the LAS data point with the highest elevation in each of the automatically determined window size areas</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum Z")]
			Maximum_Z,

			/// <summary>
			/// <para>Closest To Mean Z—Selects the LAS data point with the elevation closest to the average value found in the automatically determined window size areas</para>
			/// </summary>
			[GPValue("CLOSEST_TO_MEAN")]
			[Description("Closest To Mean Z")]
			Closest_To_Mean_Z,

		}

		/// <summary>
		/// <para>Clip to Extent</para>
		/// </summary>
		public enum ClipToExtentEnum 
		{
			/// <summary>
			/// <para>Checked—Clips the output TIN against the analysis extent. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para>Unchecked—Does not clip the output TIN against the analysis extent.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIP")]
			NO_CLIP,

		}

#endregion
	}
}
