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
	/// <para>Assign Domain To Field</para>
	/// <para>指定字段的属性域</para>
	/// <para>设置特定字段的属性域，也可设置子类型的属性域。如果未指定任何子类型，则仅为特定字段指定属性域。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AssignDomainToField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要指定属性域的字段的表或要素类的名称。</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>要指定属性域的字段的名称。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>要指定给字段名的地理数据库属性域的名称。将自动加载可用的属性域。</para>
		/// </param>
		public AssignDomainToField(object InTable, object FieldName, object DomainName)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : 指定字段的属性域</para>
		/// </summary>
		public override string DisplayName() => "指定字段的属性域";

		/// <summary>
		/// <para>Tool Name : AssignDomainToField</para>
		/// </summary>
		public override string ToolName() => "AssignDomainToField";

		/// <summary>
		/// <para>Tool Excute Name : management.AssignDomainToField</para>
		/// </summary>
		public override string ExcuteName() => "management.AssignDomainToField";

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
		public override object[] Parameters() => new object[] { InTable, FieldName, DomainName, SubtypeCode, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要指定属性域的字段的表或要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>要指定属性域的字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>要指定给字段名的地理数据库属性域的名称。将自动加载可用的属性域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>要指定属性域的子类型编码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object SubtypeCode { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AssignDomainToField SetEnviroment(int? autoCommit = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
