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
	/// <para>Make LAS Dataset Layer</para>
	/// <para>Make LAS Dataset Layer</para>
	/// <para>Creates a  LAS dataset layer that can apply  filters to LAS points and control the enforcement of surface constraint features.</para>
	/// </summary>
	public class MakeLasDatasetLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The name of the resulting LAS dataset layer. A backslash or forward slash can be used to denote a group layer.</para>
		/// </param>
		public MakeLasDatasetLayer(object InLasDataset, object OutLayer)
		{
			this.InLasDataset = InLasDataset;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make LAS Dataset Layer</para>
		/// </summary>
		public override string DisplayName() => "Make LAS Dataset Layer";

		/// <summary>
		/// <para>Tool Name : MakeLasDatasetLayer</para>
		/// </summary>
		public override string ToolName() => "MakeLasDatasetLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeLasDatasetLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeLasDatasetLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutLayer, ClassCode!, ReturnValues!, NoFlag!, Synthetic!, Keypoint!, Withheld!, SurfaceConstraints!, Overlap! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The name of the resulting LAS dataset layer. A backslash or forward slash can be used to denote a group layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Class Codes</para>
		/// <para>Specifies the classification codes that will be used to filter LAS points. All class codes will be selected by default.</para>
		/// <para>0—Never processed by a classification method</para>
		/// <para>1—Processed by a classification method but could not be determined</para>
		/// <para>2—Bare earth measurements</para>
		/// <para>3—Vegetation whose height is considered to be low for the area</para>
		/// <para>4—Vegetation whose height is considered to be intermediate for the area</para>
		/// <para>5—Vegetation whose height is considered to be high for the area</para>
		/// <para>6—Structure with roof and walls</para>
		/// <para>7—Erroneous or undesirable data that is closer to the ground</para>
		/// <para>8—Reserved for later use, but used for model key points in LAS 1.1 - 1.3</para>
		/// <para>9—Water</para>
		/// <para>10—Railway tracks used by trains</para>
		/// <para>11—Road surfaces</para>
		/// <para>12—Reserved for later use, but used for overlap points in LAS 1.1 - 1.3</para>
		/// <para>13—Shielding around electrical wires</para>
		/// <para>14—Power lines</para>
		/// <para>15—A lattice tower used to support an overhead power line</para>
		/// <para>16—A mechanical assembly that joins an electrical circuit</para>
		/// <para>17—The surface of a bridge</para>
		/// <para>18—Erroneous or undesirable data that is far from the ground</para>
		/// <para>19 - 63—Reserved class codes for ASPRS designation</para>
		/// <para>64 - 255—User-definable class codes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ClassCode { get; set; }

		/// <summary>
		/// <para>Return Values</para>
		/// <para>Specifies the ordinal pulse return values that will be used to filter LAS points. All returns will be used when no value is specified. Return information is only available for LAS point clouds collected from a lidar scanner. The return number reflects the order of discrete points obtained from the lidar pulse, whereby the first return is closest to the scanner and the last return is farthest from the scanner.</para>
		/// <para>LAST—The last point from all lidar pulses will be used.</para>
		/// <para>FIRST_OF_MANY—The first point from each lidar pulse with multiple returns will be used.</para>
		/// <para>LAST_OF_MANY—The last point from each lidar pulse with multiple returns will be used.</para>
		/// <para>SINGLE—All points from lidar pulses with only one return will be used.</para>
		/// <para>1st Return—All points with a return value of 1 will be used.</para>
		/// <para>2nd Return—All points with a return value of 2 will be used.</para>
		/// <para>3rd Return—All points with a return value of 3 will be used.</para>
		/// <para>4th Return—All points with a return value of 4 will be used.</para>
		/// <para>5th Return—All points with a return value of 5 will be used.</para>
		/// <para>6th Return—All points with a return value of 6 will be used.</para>
		/// <para>7th Return—All points with a return value of 7 will be used.</para>
		/// <para>8th Return—All points with a return value of 8 will be used.</para>
		/// <para>9th Return—All points with a return value of 9 will be used.</para>
		/// <para>10th Return—All points with a return value of 10 will be used.</para>
		/// <para>11th Return—All points with a return value of 11 will be used.</para>
		/// <para>12th Return—All points with a return value of 12 will be used.</para>
		/// <para>13th Return—All points with a return value of 13 will be used.</para>
		/// <para>14th Return—All points with a return value of 14 will be used.</para>
		/// <para>15th Return—All points with a return value of 15 will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ReturnValues { get; set; }

		/// <summary>
		/// <para>Unflagged Points</para>
		/// <para>Specifies whether data points that do not have classification flags assigned will be included.</para>
		/// <para>Checked—Unflagged points will be included. This is the default.</para>
		/// <para>Unchecked—Unflagged points will be excluded.</para>
		/// <para><see cref="NoFlagEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NoFlag { get; set; } = "true";

		/// <summary>
		/// <para>Synthetic Points</para>
		/// <para>Specifies whether data points flagged as synthetic will be included. Synthetic points refer to LAS points that originated from a data source other than a lidar scanner.</para>
		/// <para>Checked—Synthetic points will be included. This is the default.</para>
		/// <para>Unchecked—Synthetic points will be excluded.</para>
		/// <para><see cref="SyntheticEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Synthetic { get; set; } = "true";

		/// <summary>
		/// <para>Model Key-Point</para>
		/// <para>Specifies whether data points flagged as model key points will be included. Model key points refer to LAS points that are significant for modeling the object they are associated with.</para>
		/// <para>Checked—Model key points will be included. This is the default.</para>
		/// <para>Unchecked—Model key points will be excluded.</para>
		/// <para><see cref="KeypointEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Keypoint { get; set; } = "true";

		/// <summary>
		/// <para>Withheld Points</para>
		/// <para>Specifies whether data points flagged as withheld will be included. Withheld points represent erroneous or undesired measurements captured in the LAS points.</para>
		/// <para>Checked—Withheld points will be included.</para>
		/// <para>Unchecked—Withheld points will be excluded. This is the default.</para>
		/// <para><see cref="WithheldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Withheld { get; set; } = "false";

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>The name of the surface constraint features that will be enabled in the layer. All constraints are enabled by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? SurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Overlap Points</para>
		/// <para>Specifies whether data points flagged as overlap will be included. Overlap points refer to points collected in overlapping scans that typically have a larger scan angle. Filtering overlap points can help ensure a regular distribution of LAS points is achieved across the extent of the data.</para>
		/// <para>Checked—Overlap points will be included. This is the default.</para>
		/// <para>Unchecked—Overlap points will be excluded.</para>
		/// <para><see cref="OverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overlap { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeLasDatasetLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Unflagged Points</para>
		/// </summary>
		public enum NoFlagEnum 
		{
			/// <summary>
			/// <para>Checked—Unflagged points will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_UNFLAGGED")]
			INCLUDE_UNFLAGGED,

			/// <summary>
			/// <para>Unchecked—Unflagged points will be excluded.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_UNFLAGGED")]
			EXCLUDE_UNFLAGGED,

		}

		/// <summary>
		/// <para>Synthetic Points</para>
		/// </summary>
		public enum SyntheticEnum 
		{
			/// <summary>
			/// <para>Checked—Synthetic points will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SYNTHETIC")]
			INCLUDE_SYNTHETIC,

			/// <summary>
			/// <para>Unchecked—Synthetic points will be excluded.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_SYNTHETIC")]
			EXCLUDE_SYNTHETIC,

		}

		/// <summary>
		/// <para>Model Key-Point</para>
		/// </summary>
		public enum KeypointEnum 
		{
			/// <summary>
			/// <para>Checked—Model key points will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_KEYPOINT")]
			INCLUDE_KEYPOINT,

			/// <summary>
			/// <para>Unchecked—Model key points will be excluded.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_KEYPOINT")]
			EXCLUDE_KEYPOINT,

		}

		/// <summary>
		/// <para>Withheld Points</para>
		/// </summary>
		public enum WithheldEnum 
		{
			/// <summary>
			/// <para>Checked—Withheld points will be included.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_WITHHELD")]
			INCLUDE_WITHHELD,

			/// <summary>
			/// <para>Unchecked—Withheld points will be excluded. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_WITHHELD")]
			EXCLUDE_WITHHELD,

		}

		/// <summary>
		/// <para>Overlap Points</para>
		/// </summary>
		public enum OverlapEnum 
		{
			/// <summary>
			/// <para>Checked—Overlap points will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_OVERLAP")]
			INCLUDE_OVERLAP,

			/// <summary>
			/// <para>Unchecked—Overlap points will be excluded.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_OVERLAP")]
			EXCLUDE_OVERLAP,

		}

#endregion
	}
}
