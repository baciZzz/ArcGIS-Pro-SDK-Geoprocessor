using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate OIS Profile Data</para>
	/// <para>Generate OIS Profile Data</para>
	/// <para>Generates a JSON string that is stored in the PROFILEJSON field on the input Obstruction Identification Surface multipatch feature class that contains the data necessary to depict the terrain, runway, and OIS in the Terrain and Obstacle Profile layout element.</para>
	/// </summary>
	public class GenerateOISProfileData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRunwayFeatures">
		/// <para>Input Runway Features</para>
		/// <para>This is the input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="InDems">
		/// <para>Input Elevation Model</para>
		/// <para>The DEMs covering the runways and their approach obstruction identification surfaces.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The multipatch features with defined Airport schema. The feature class must be z-enabled.</para>
		/// </param>
		public GenerateOISProfileData(object InRunwayFeatures, object InDems, object TargetOisFeatures)
		{
			this.InRunwayFeatures = InRunwayFeatures;
			this.InDems = InDems;
			this.TargetOisFeatures = TargetOisFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate OIS Profile Data</para>
		/// </summary>
		public override string DisplayName() => "Generate OIS Profile Data";

		/// <summary>
		/// <para>Tool Name : GenerateOISProfileData</para>
		/// </summary>
		public override string ToolName() => "GenerateOISProfileData";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateOISProfileData</para>
		/// </summary>
		public override string ExcuteName() => "aviation.GenerateOISProfileData";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRunwayFeatures, InDems, TargetOisFeatures, InFlightpathFeatures!, SamplingDistance!, SampleProfileOis!, SampleProfileRunways!, OutOisFeatures! };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>This is the input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRunwayFeatures { get; set; }

		/// <summary>
		/// <para>Input Elevation Model</para>
		/// <para>The DEMs covering the runways and their approach obstruction identification surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDems { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The multipatch features with defined Airport schema. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Input Flight Path Features</para>
		/// <para>The polyline features that define curved approaches to the specified runways. If unspecified, all input features will be processed as straight approaches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object? InFlightpathFeatures { get; set; }

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>The distance, in meters, between generated points. The default is 30.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SamplingDistance { get; set; } = "30";

		/// <summary>
		/// <para>Sample OIS Features</para>
		/// <para>Specifies whether elevation points for OIS features will be generated.</para>
		/// <para>Unchecked—Uses only the start and end points of the runways. Elevation points will not be generated. This is the default.</para>
		/// <para>Checked—Generates elevation points.</para>
		/// <para><see cref="SampleProfileOisEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SampleProfileOis { get; set; } = "false";

		/// <summary>
		/// <para>Sample Runway Features</para>
		/// <para>Specifies whether elevation points along the runways will be generated.</para>
		/// <para>Unchecked—Uses only the start and end points of the runways. This is the default.</para>
		/// <para>Checked—Generates elevation points along the runways.</para>
		/// <para><see cref="SampleProfileRunwaysEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SampleProfileRunways { get; set; } = "false";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? OutOisFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateOISProfileData SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sample OIS Features</para>
		/// </summary>
		public enum SampleProfileOisEnum 
		{
			/// <summary>
			/// <para>Checked—Generates elevation points.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROFILE_OIS")]
			PROFILE_OIS,

			/// <summary>
			/// <para>Unchecked—Uses only the start and end points of the runways. Elevation points will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PROFILE_OIS")]
			NO_PROFILE_OIS,

		}

		/// <summary>
		/// <para>Sample Runway Features</para>
		/// </summary>
		public enum SampleProfileRunwaysEnum 
		{
			/// <summary>
			/// <para>Checked—Generates elevation points along the runways.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROFILE_RUNWAY")]
			PROFILE_RUNWAY,

			/// <summary>
			/// <para>Unchecked—Uses only the start and end points of the runways. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PROFILE_RUNWAY")]
			NO_PROFILE_RUNWAY,

		}

#endregion
	}
}
