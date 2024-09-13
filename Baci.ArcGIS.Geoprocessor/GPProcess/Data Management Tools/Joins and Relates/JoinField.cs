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
	/// <para>Join Field</para>
	/// <para>连接字段</para>
	/// <para>基于公用属性字段将一个表的内容连接到另一个表。输入表将被更新，从而包含连接表中的字段。可选择将连接表中的哪些字段添加到输入表中。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class JoinField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Table</para>
		/// <para>连接表将连接的表或要素类。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>输入表中要用作连接依据的字段。</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>要连接到输入表中的表。</para>
		/// </param>
		/// <param name="Join_Field">
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，包含连接将基于的值。</para>
		/// </param>
		public JoinField(object InData, object InField, object JoinTable, object Join_Field)
		{
			this.InData = InData;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.Join_Field = Join_Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 连接字段</para>
		/// </summary>
		public override string DisplayName() => "连接字段";

		/// <summary>
		/// <para>Tool Name : JoinField</para>
		/// </summary>
		public override string ToolName() => "JoinField";

		/// <summary>
		/// <para>Tool Excute Name : management.JoinField</para>
		/// </summary>
		public override string ExcuteName() => "management.JoinField";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, InField, JoinTable, Join_Field, Fields, OutLayerOrView };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>连接表将连接的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>输入表中要用作连接依据的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Join Table</para>
		/// <para>要连接到输入表中的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JoinTable { get; set; }

		/// <summary>
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，包含连接将基于的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object Join_Field { get; set; }

		/// <summary>
		/// <para>Transfer Fields</para>
		/// <para>来自连接表的、将基于输入表和连接表之间的连接传输至输入表的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "GUID")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JoinField SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
