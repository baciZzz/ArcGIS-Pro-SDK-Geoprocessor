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
	/// <para>Add Aviation Line Bypass</para>
	/// <para>Adjusts route polyline features that overlap point features.</para>
	/// </summary>
	public class AddAviationLineBypass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The input map with a set reference scale.</para>
		/// </param>
		/// <param name="TargetLineFeatures">
		/// <para>Target Line Features</para>
		/// <para>The polyline features representing Air Traffic Service (ATS) routes.</para>
		/// </param>
		public AddAviationLineBypass(object InMap, object TargetLineFeatures)
		{
			this.InMap = InMap;
			this.TargetLineFeatures = TargetLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Aviation Line Bypass</para>
		/// </summary>
		public override string DisplayName() => "Add Aviation Line Bypass";

		/// <summary>
		/// <para>Tool Name : AddAviationLineBypass</para>
		/// </summary>
		public override string ToolName() => "AddAviationLineBypass";

		/// <summary>
		/// <para>Tool Excute Name : aviation.AddAviationLineBypass</para>
		/// </summary>
		public override string ExcuteName() => "aviation.AddAviationLineBypass";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, TargetLineFeatures, BypassFeatures, Tolerance, RadiusOption, RadiusScale, Radius, MergeOption, UpdatedLineFeatures };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map with a set reference scale.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Target Line Features</para>
		/// <para>The polyline features representing Air Traffic Service (ATS) routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TargetLineFeatures { get; set; }

		/// <summary>
		/// <para>Bypass Features</para>
		/// <para>The point features that the Target Line Features value will bypass.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object BypassFeatures { get; set; }

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>The maximum distance between the center point of a bypass feature and a route.</para>
		/// <para>If the linear unit is not specified or is set to Unknown, it will be the same as the input map&apos;s spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Radius Option</para>
		/// <para>Specifies the type of bypass radius that will be used.</para>
		/// <para>Dynamic Radius—The radius will be dynamic relative to its scale factor. This is the default.</para>
		/// <para>Constant Radius—The radius will be a constant radius.</para>
		/// <para><see cref="RadiusOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RadiusOption { get; set; } = "DYNAMIC_RADIUS";

		/// <summary>
		/// <para>Radius Scale Factor</para>
		/// <para>The amount a bypass with a dynamic radius will be scaled. This parameter is only valid if Dynamic Radius is selected as the Radius Option parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RadiusScale { get; set; } = "1";

		/// <summary>
		/// <para>Radius</para>
		/// <para>The radius of a bypass with a constant radius. This parameter is only valid if Constant Radius is selected as the Radius Option parameter value.</para>
		/// <para>If the linear unit is not specified or is set to Unknown, it will be the same as the input map&apos;s spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Radius { get; set; }

		/// <summary>
		/// <para>Merge Option</para>
		/// <para>Specifies whether consecutive bypass lines will be merged.</para>
		/// <para>Consecutive bypass lines will not be merged.—Consecutive bypass lines will not be merged. This is the default.</para>
		/// <para>Consecutive bypass lines will be merged.—Consecutive bypass lines will be merged.</para>
		/// <para><see cref="MergeOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MergeOption { get; set; } = "NO_MERGE_BYPASS";

		/// <summary>
		/// <para>Updated Line Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object UpdatedLineFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Radius Option</para>
		/// </summary>
		public enum RadiusOptionEnum 
		{
			/// <summary>
			/// <para>Dynamic Radius—The radius will be dynamic relative to its scale factor. This is the default.</para>
			/// </summary>
			[GPValue("DYNAMIC_RADIUS")]
			[Description("Dynamic Radius")]
			Dynamic_Radius,

			/// <summary>
			/// <para>Constant Radius—The radius will be a constant radius.</para>
			/// </summary>
			[GPValue("CONSTANT_RADIUS")]
			[Description("Constant Radius")]
			Constant_Radius,

		}

		/// <summary>
		/// <para>Merge Option</para>
		/// </summary>
		public enum MergeOptionEnum 
		{
			/// <summary>
			/// <para>Consecutive bypass lines will not be merged.—Consecutive bypass lines will not be merged. This is the default.</para>
			/// </summary>
			[GPValue("NO_MERGE_BYPASS")]
			[Description("Consecutive bypass lines will not be merged.")]
			Consecutive_bypass_lines_will_not_be_merged,

			/// <summary>
			/// <para>Consecutive bypass lines will be merged.—Consecutive bypass lines will be merged.</para>
			/// </summary>
			[GPValue("MERGE_BYPASS")]
			[Description("Consecutive bypass lines will be merged.")]
			Consecutive_bypass_lines_will_be_merged,

		}

#endregion
	}
}
