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
	/// <para>Sets the domain for a particular field and, optionally, for a subtype. If no subtype is specified, the domain is only assigned to the specified field.</para>
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
		/// <para>The name of the table or feature class containing the field that will be assigned a domain.</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>The name of the field to be assigned a domain.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of a geodatabase domain to assign to the field name. Available domains will automatically be loaded.</para>
		/// </param>
		public AssignDomainToField(object InTable, object FieldName, object DomainName)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : Assign Domain To Field</para>
		/// </summary>
		public override string DisplayName => "Assign Domain To Field";

		/// <summary>
		/// <para>Tool Name : AssignDomainToField</para>
		/// </summary>
		public override string ToolName => "AssignDomainToField";

		/// <summary>
		/// <para>Tool Excute Name : management.AssignDomainToField</para>
		/// </summary>
		public override string ExcuteName => "management.AssignDomainToField";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, FieldName, DomainName, SubtypeCode, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The name of the table or feature class containing the field that will be assigned a domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The name of the field to be assigned a domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of a geodatabase domain to assign to the field name. Available domains will automatically be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The subtype code to be assigned a domain.</para>
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
		public AssignDomainToField SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
