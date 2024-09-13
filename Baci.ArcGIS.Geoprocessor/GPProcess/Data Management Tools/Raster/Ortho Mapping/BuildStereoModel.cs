using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Build Stereo Model</para>
	/// <para>Build Stereo Model</para>
	/// <para>Builds a stereo model of a mosaic dataset based on a user-provided stereo pair.</para>
	/// </summary>
	public class BuildStereoModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset on which the stereo model will be built.</para>
		/// <para>Running Apply Block Adjustment on the input mosaic dataset first will help create a more accurate stereo model.</para>
		/// </param>
		public BuildStereoModel(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Stereo Model</para>
		/// </summary>
		public override string DisplayName() => "Build Stereo Model";

		/// <summary>
		/// <para>Tool Name : BuildStereoModel</para>
		/// </summary>
		public override string ToolName() => "BuildStereoModel";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildStereoModel</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildStereoModel";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, MinimumAngle!, MaximumAngle!, MinimumOverlap!, MaximumDiffOP!, MaximumDiffGSD!, GroupBy!, OutMosaicDataset!, SameFlight! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset on which the stereo model will be built.</para>
		/// <para>Running Apply Block Adjustment on the input mosaic dataset first will help create a more accurate stereo model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Minimum Intersection Angle (in degree)</para>
		/// <para>The value, in degrees, that defines the minimum angle the stereo pair must meet. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumAngle { get; set; } = "5";

		/// <summary>
		/// <para>Maximum Intersection Angle (in degree)</para>
		/// <para>The value, in degrees, that defines the maximum angle the stereo pair must meet. The default is 70.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumAngle { get; set; } = "90";

		/// <summary>
		/// <para>Minimum Area Overlap</para>
		/// <para>The percentage of the overlapping area over the whole image. The default is 0.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumOverlap { get; set; } = "0.5";

		/// <summary>
		/// <para>Maximum Omega/Phi Difference (in degree)</para>
		/// <para>The maximum threshold for the Omega and Phi difference between the two image pairs. The Omega values and Phi values for the image pairs are compared. If the difference between either the two Omega or the two Phi values is above the threshold, the pairs will not be formatted as a stereo pair.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffOP { get; set; }

		/// <summary>
		/// <para>Maximum GSD Difference</para>
		/// <para>The threshold for the maximum GSD between two images in a pair. If the resolution ratio between the two images is greater than the threshold value, the pairs will not be built as a stereo pair. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffGSD { get; set; } = "2";

		/// <summary>
		/// <para>Group by</para>
		/// <para>Builds the stereo model from raster items within the same group, defined by a mosaic dataset field such as RGB, Panchromatic, or Infrared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Date", "OID", "Text")]
		public object? GroupBy { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only pick stereo models in the same flight line</para>
		/// <para>Specifies how the stereo models will be selected.</para>
		/// <para>Checked—Stereo pairs will be selected along the same flight line.</para>
		/// <para>Unchecked—Stereo pairs will be selected across flight lines. This is the default.</para>
		/// <para>This parameter is not applicable to satellite-based sensors.</para>
		/// <para><see cref="SameFlightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SameFlight { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Only pick stereo models in the same flight line</para>
		/// </summary>
		public enum SameFlightEnum 
		{
			/// <summary>
			/// <para>Checked—Stereo pairs will be selected along the same flight line.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SAMEFLIGHT")]
			SAMEFLIGHT,

			/// <summary>
			/// <para>Unchecked—Stereo pairs will be selected across flight lines. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SAMEFLIGHT")]
			NO_SAMEFLIGHT,

		}

#endregion
	}
}
