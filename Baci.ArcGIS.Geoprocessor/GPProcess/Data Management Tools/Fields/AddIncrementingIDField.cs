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
	/// <para>Add Incrementing ID Field</para>
	/// <para>Add Incrementing ID Field</para>
	/// <para>Adds a database-maintained ID field to an existing table or feature class in a Dameng, IBM Db2, Microsoft Azure SQL Database, Microsoft SQL Server, Oracle, or PostgreSQL database. A database-maintained ID field is required for all feature classes or tables you plan to edit through a feature service.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddIncrementingIDField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The location and name of the table or feature class to which an ID field will be added.</para>
		/// </param>
		public AddIncrementingIDField(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Incrementing ID Field</para>
		/// </summary>
		public override string DisplayName() => "Add Incrementing ID Field";

		/// <summary>
		/// <para>Tool Name : AddIncrementingIDField</para>
		/// </summary>
		public override string ToolName() => "AddIncrementingIDField";

		/// <summary>
		/// <para>Tool Excute Name : management.AddIncrementingIDField</para>
		/// </summary>
		public override string ExcuteName() => "management.AddIncrementingIDField";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, FieldName!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The location and name of the table or feature class to which an ID field will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPTablesDomain(HideJoinedLayers = true, ShowOnlyStandaloneTables = false)]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The name to be used for the ID field. If no input is provided, the default ObjectID will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FieldName { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

	}
}
