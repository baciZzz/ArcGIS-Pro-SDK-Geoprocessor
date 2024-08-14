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
	/// <para>Find Identical</para>
	/// <para>Reports any records in a feature class or table that have identical values in a list of fields, and generates a table listing these identical records. If the field Shape is selected, feature geometries are compared.</para>
	/// </summary>
	public class FindIdentical : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The table or feature class for which identical records will be found.</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset</para>
		/// <para>The output table reporting identical records. The FEAT_SEQ field in the output table will have the same value for identical records.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field(s)</para>
		/// <para>The field or fields whose values will be compared to find identical records.</para>
		/// </param>
		public FindIdentical(object InDataset, object OutDataset, object Fields)
		{
			this.InDataset = InDataset;
			this.OutDataset = OutDataset;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Identical</para>
		/// </summary>
		public override string DisplayName => "Find Identical";

		/// <summary>
		/// <para>Tool Name : FindIdentical</para>
		/// </summary>
		public override string ToolName => "FindIdentical";

		/// <summary>
		/// <para>Tool Excute Name : management.FindIdentical</para>
		/// </summary>
		public override string ExcuteName => "management.FindIdentical";

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
		public override string[] ValidEnvironments => new string[] { "XYTolerance", "ZTolerance", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutDataset, Fields, XyTolerance!, ZTolerance!, OutputRecordOption! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The table or feature class for which identical records will be found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The output table reporting identical records. The FEAT_SEQ field in the output table will have the same value for identical records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>The field or fields whose values will be compared to find identical records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The xy tolerance that will be applied to each vertex when evaluating if there is an identical vertex in another feature. This parameter is enabled only when Shape is selected as one of the fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The Z tolerance that will be applied to each vertex when evaluating if there is an identical vertex in another feature. This parameter is enabled only when Shape is selected as one of the fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Output only duplicated records</para>
		/// <para>Choose if you want only duplicated records in the output table.</para>
		/// <para>Unchecked—All input records will have corresponding records in the output table. This is the default.</para>
		/// <para>Checked—Only duplicate records will have corresponding records in the output table. The output will be empty if no duplicate is found.</para>
		/// <para><see cref="OutputRecordOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutputRecordOption { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindIdentical SetEnviroment(object? XYTolerance = null , object? ZTolerance = null , object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYTolerance: XYTolerance, ZTolerance: ZTolerance, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output only duplicated records</para>
		/// </summary>
		public enum OutputRecordOptionEnum 
		{
			/// <summary>
			/// <para>Checked—Only duplicate records will have corresponding records in the output table. The output will be empty if no duplicate is found.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_DUPLICATES")]
			ONLY_DUPLICATES,

			/// <summary>
			/// <para>Unchecked—All input records will have corresponding records in the output table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

#endregion
	}
}
