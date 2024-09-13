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
	/// <para>Delete Identical</para>
	/// <para>删除相同项</para>
	/// <para>如果要素类或表中的记录在字段列表中具有相同值，则可删除这些记录。如果选择了几何字段，将会对要素几何进行比较。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteIdentical : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>将删除相同记录的表或要素类。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field(s)</para>
		/// <para>将对字段值进行比较以查找相同记录的一个或多个字段。</para>
		/// </param>
		public DeleteIdentical(object InDataset, object Fields)
		{
			this.InDataset = InDataset;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除相同项</para>
		/// </summary>
		public override string DisplayName() => "删除相同项";

		/// <summary>
		/// <para>Tool Name : DeleteIdentical</para>
		/// </summary>
		public override string ToolName() => "DeleteIdentical";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteIdentical</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteIdentical";

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
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "ZTolerance", "extent", "maintainSpatialIndex", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, Fields, XyTolerance!, ZTolerance!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>将删除相同记录的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

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
		/// <para>在计算时应用于每个折点的 xy 容差（如果另一要素中存在相同的折点）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>在计算时应用于每个折点的 z 容差（如果另一要素中存在相同的折点）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteIdentical SetEnviroment(object? XYTolerance = null , object? ZTolerance = null , object? extent = null , bool? maintainSpatialIndex = null , object? workspace = null )
		{
			base.SetEnv(XYTolerance: XYTolerance, ZTolerance: ZTolerance, extent: extent, maintainSpatialIndex: maintainSpatialIndex, workspace: workspace);
			return this;
		}

	}
}
