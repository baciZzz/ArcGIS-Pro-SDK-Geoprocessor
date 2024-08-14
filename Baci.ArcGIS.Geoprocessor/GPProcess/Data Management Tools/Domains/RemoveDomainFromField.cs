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
	/// <para>Remove Domain From Field</para>
	/// <para>Removes an attribute domain association from a feature class or table field.</para>
	/// </summary>
	public class RemoveDomainFromField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table containing the attribute domain that will be removed.</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>The field that will no longer be associated with an attribute domain.</para>
		/// </param>
		public RemoveDomainFromField(object InTable, object FieldName)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Domain From Field</para>
		/// </summary>
		public override string DisplayName => "Remove Domain From Field";

		/// <summary>
		/// <para>Tool Name : RemoveDomainFromField</para>
		/// </summary>
		public override string ToolName => "RemoveDomainFromField";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveDomainFromField</para>
		/// </summary>
		public override string ExcuteName => "management.RemoveDomainFromField";

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
		public override object[] Parameters => new object[] { InTable, FieldName, SubtypeCode, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table containing the attribute domain that will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The field that will no longer be associated with an attribute domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The subtype code(s) that will no longer be associated with an attribute domain.</para>
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
		public RemoveDomainFromField SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
