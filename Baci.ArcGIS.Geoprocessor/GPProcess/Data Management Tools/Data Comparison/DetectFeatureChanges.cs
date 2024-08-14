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
	/// <para>Detect Feature Changes</para>
	/// <para>Finds where the update line features spatially match the base line features and detects spatial changes, attribute changes, or both, as well as no change. It then creates an output feature class containing matched update features with information about their changes, unmatched update features, and unmatched base features.</para>
	/// </summary>
	public class DetectFeatureChanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="UpdateFeatures">
		/// <para>Update Features</para>
		/// <para>The line features that will be compared to the base features.</para>
		/// </param>
		/// <param name="BaseFeatures">
		/// <para>Base Features</para>
		/// <para>The line features that will be compared to the update features for change detection.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output line feature class containing the change information. The output contains all participating update features (matched and unmatched) and any unmatched base features.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public DetectFeatureChanges(object UpdateFeatures, object BaseFeatures, object OutFeatureClass, object SearchDistance)
		{
			this.UpdateFeatures = UpdateFeatures;
			this.BaseFeatures = BaseFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Feature Changes</para>
		/// </summary>
		public override string DisplayName => "Detect Feature Changes";

		/// <summary>
		/// <para>Tool Name : DetectFeatureChanges</para>
		/// </summary>
		public override string ToolName => "DetectFeatureChanges";

		/// <summary>
		/// <para>Tool Excute Name : management.DetectFeatureChanges</para>
		/// </summary>
		public override string ExcuteName => "management.DetectFeatureChanges";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { UpdateFeatures, BaseFeatures, OutFeatureClass, SearchDistance, MatchFields!, OutMatchTable!, ChangeTolerance!, CompareFields!, CompareLineDirection! };

		/// <summary>
		/// <para>Update Features</para>
		/// <para>The line features that will be compared to the base features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object UpdateFeatures { get; set; }

		/// <summary>
		/// <para>Base Features</para>
		/// <para>The line features that will be compared to the update features for change detection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object BaseFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output line feature class containing the change information. The output contains all participating update features (matched and unmatched) and any unmatched base features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>The match fields from the update and base features. If specified, each pair of fields are compared for match candidates to help determine the right match.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>The output table containing complete feature matching information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutMatchTable { get; set; }

		/// <summary>
		/// <para>Change Tolerance</para>
		/// <para>The distance used to determine if there is a spatial change. All matched update features and base features are compared to this tolerance. If any portions of the update or the base features fall outside the zone around the matched feature, it is considered a spatial change. The value must be greater than the XY Tolerance of the input data so this process can be performed and the output will include the LEN_PCT and LEN_ABS fields. The default is 0, meaning this process is not performed. Any value between 0 and the data's XY Tolerance (inclusively) will make the process irrelevant and will be replaced by 0. You can choose a unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ChangeTolerance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Compare Fields</para>
		/// <para>The fields that will determine if there is an attribute change between the matched update and base features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		public object? CompareFields { get; set; }

		/// <summary>
		/// <para>Compare line direction</para>
		/// <para>Specifies whether line directions will be compared for matched features.</para>
		/// <para>Unchecked—Line directions will not be compared for matched features. This is the default.</para>
		/// <para>Checked—Line directions will be compared for matched features.</para>
		/// <para><see cref="CompareLineDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompareLineDirection { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectFeatureChanges SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compare line direction</para>
		/// </summary>
		public enum CompareLineDirectionEnum 
		{
			/// <summary>
			/// <para>Checked—Line directions will be compared for matched features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPARE_DIRECTION")]
			COMPARE_DIRECTION,

			/// <summary>
			/// <para>Unchecked—Line directions will not be compared for matched features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPARE_DIRECTION")]
			NO_COMPARE_DIRECTION,

		}

#endregion
	}
}
