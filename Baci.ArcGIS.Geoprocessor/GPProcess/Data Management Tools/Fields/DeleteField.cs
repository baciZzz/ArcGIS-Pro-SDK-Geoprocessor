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
	/// <para>Deletes one or more fields from a table, feature class, feature layer, or raster dataset.</para>
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
		/// <para>The table containing the fields to be deleted. The existing input table will be modified.</para>
		/// </param>
		/// <param name="DropField">
		/// <para>Drop Field</para>
		/// <para>The fields to be dropped from the input table. Only nonrequired fields may be deleted.</para>
		/// </param>
		public DeleteField(object InTable, object DropField)
		{
			this.InTable = InTable;
			this.DropField = DropField;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Field</para>
		/// </summary>
		public override string DisplayName => "Delete Field";

		/// <summary>
		/// <para>Tool Name : DeleteField</para>
		/// </summary>
		public override string ToolName => "DeleteField";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteField</para>
		/// </summary>
		public override string ExcuteName => "management.DeleteField";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, DropField, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the fields to be deleted. The existing input table will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Drop Field</para>
		/// <para>The fields to be dropped from the input table. Only nonrequired fields may be deleted.</para>
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
		public DeleteField SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
