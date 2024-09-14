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
	/// <para>Add Join</para>
	/// <para>添加连接</para>
	/// <para>基于公共字段将图层连接到另一图层或表。 支持带有栅格属性表的要素图层、表视图和栅格图层。</para>
	/// </summary>
	public class AddJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Table</para>
		/// <para>连接表将连接的图层或表视图。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>连接所依据的输入图层或表视图中的字段。</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>要连接到输入图层或表视图的表或表视图。</para>
		/// </param>
		/// <param name="JoinField">
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，其中包含连接所依据的值。</para>
		/// </param>
		public AddJoin(object InLayerOrView, object InField, object JoinTable, object JoinField)
		{
			this.InLayerOrView = InLayerOrView;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.JoinField = JoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加连接</para>
		/// </summary>
		public override string DisplayName() => "添加连接";

		/// <summary>
		/// <para>Tool Name : AddJoin</para>
		/// </summary>
		public override string ToolName() => "AddJoin";

		/// <summary>
		/// <para>Tool Excute Name : management.AddJoin</para>
		/// </summary>
		public override string ExcuteName() => "management.AddJoin";

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
		public override object[] Parameters() => new object[] { InLayerOrView, InField, JoinTable, JoinField, JoinType!, OutLayerOrView!, IndexJoinFields! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>连接表将连接的图层或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>连接所依据的输入图层或表视图中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Join Table</para>
		/// <para>要连接到输入图层或表视图的表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JoinTable { get; set; }

		/// <summary>
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，其中包含连接所依据的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object JoinField { get; set; }

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// <para>指定是否仅将输入中与连接表内的记录相匹配的记录包括在输出中。</para>
		/// <para>选中 - 输入图层或表视图中的所有记录都将包含在输出中。 这也称为外部连接。 这是默认设置。</para>
		/// <para>未选中 - 仅将输入中与连接表中的行相匹配的记录包括在输出中。 这也成为内部连接。</para>
		/// <para><see cref="JoinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? JoinType { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Layer or Table View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Index Joined Fields</para>
		/// <para>指定是否将表属性索引添加到两个连接字段。</para>
		/// <para>选中 - 将为两个连接字段创建索引。 如果表已包含索引，则不会添加新索引。</para>
		/// <para>未选中 - 不会添加索引。 这是默认设置。</para>
		/// <para><see cref="IndexJoinFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IndexJoinFields { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddJoin SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// </summary>
		public enum JoinTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_COMMON")]
			KEEP_COMMON,

		}

		/// <summary>
		/// <para>Index Joined Fields</para>
		/// </summary>
		public enum IndexJoinFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX_JOIN_FIELDS")]
			INDEX_JOIN_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX_JOIN_FIELDS")]
			NO_INDEX_JOIN_FIELDS,

		}

#endregion
	}
}
