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
	/// <para>查找相同项</para>
	/// <para>报告要素类或表中在一系列字段中具有相同值的所有记录并生成一个列表文件以列出记录。如果选择了 Shape 字段，将会对要素几何进行比较。</para>
	/// </summary>
	public class FindIdentical : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要查找相同记录的表或要素类。</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset</para>
		/// <para>用于报告相同记录的输出表。在输出表中，相同记录的 FEAT_SEQ 字段具有相同值。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field(s)</para>
		/// <para>将对字段值进行比较以查找相同记录的一个或多个字段。</para>
		/// </param>
		public FindIdentical(object InDataset, object OutDataset, object Fields)
		{
			this.InDataset = InDataset;
			this.OutDataset = OutDataset;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找相同项</para>
		/// </summary>
		public override string DisplayName() => "查找相同项";

		/// <summary>
		/// <para>Tool Name : FindIdentical</para>
		/// </summary>
		public override string ToolName() => "FindIdentical";

		/// <summary>
		/// <para>Tool Excute Name : management.FindIdentical</para>
		/// </summary>
		public override string ExcuteName() => "management.FindIdentical";

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
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "ZTolerance", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutDataset, Fields, XyTolerance!, ZTolerance!, OutputRecordOption! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要查找相同记录的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>用于报告相同记录的输出表。在输出表中，相同记录的 FEAT_SEQ 字段具有相同值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>将对字段值进行比较以查找相同记录的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Geometry", "GUID")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>在计算时应用于每个折点的 xy 容差（如果另一要素中存在相同的折点）。仅当 Shape 被选作其中一个输入字段时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>在计算时应用于每个折点的 z 容差（如果另一要素中存在相同的折点）。仅当 Shape 被选作其中一个输入字段时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Output only duplicated records</para>
		/// <para>当仅需要在输出表中包含重复记录时选择。</para>
		/// <para>未选中 - 所有输入记录在输出表中都有对应的记录。这是默认设置。</para>
		/// <para>选中 - 仅重复记录在输出表中有对应的记录。无重复记录时输出为空。</para>
		/// <para><see cref="OutputRecordOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutputRecordOption { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindIdentical SetEnviroment(object? XYTolerance = null, object? ZTolerance = null, object? extent = null, object? scratchWorkspace = null, object? workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_DUPLICATES")]
			ONLY_DUPLICATES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

#endregion
	}
}
