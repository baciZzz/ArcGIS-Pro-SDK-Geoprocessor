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
	/// <para>Delete Field</para>
	/// <para>删除字段</para>
	/// <para>可从表、要素类、要素图层或栅格数据集中删除一个或多个字段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要删除字段的表。将修改现有输入表。</para>
		/// </param>
		/// <param name="DropField">
		/// <para>Drop Field</para>
		/// <para>要从输入表中删除的字段。必填字段不能删除。</para>
		/// </param>
		public DeleteField(object InTable, object DropField)
		{
			this.InTable = InTable;
			this.DropField = DropField;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除字段</para>
		/// </summary>
		public override string DisplayName() => "删除字段";

		/// <summary>
		/// <para>Tool Name : DeleteField</para>
		/// </summary>
		public override string ToolName() => "DeleteField";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteField</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteField";

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
		public override object[] Parameters() => new object[] { InTable, DropField, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要删除字段的表。将修改现有输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Drop Field</para>
		/// <para>要从输入表中删除的字段。必填字段不能删除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object DropField { get; set; }

		/// <summary>
		/// <para>Update Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteField SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
