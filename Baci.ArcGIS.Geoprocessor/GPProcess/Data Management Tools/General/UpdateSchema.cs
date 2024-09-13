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
	/// <para>Update Schema</para>
	/// <para>Update Schema</para>
	/// <para>Updates the schema of a dataset based upon a Xml set of instructions</para>
	/// </summary>
	[Obsolete()]
	public class UpdateSchema : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// </param>
		/// <param name="Operations">
		/// <para>Schema Operations</para>
		/// </param>
		public UpdateSchema(object InTable, object Operations)
		{
			this.InTable = InTable;
			this.Operations = Operations;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Schema</para>
		/// </summary>
		public override string DisplayName() => "Update Schema";

		/// <summary>
		/// <para>Tool Name : UpdateSchema</para>
		/// </summary>
		public override string ToolName() => "UpdateSchema";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateSchema</para>
		/// </summary>
		public override string ExcuteName() => "management.UpdateSchema";

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
		public override object[] Parameters() => new object[] { InTable, Operations, OutMessages, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Schema Operations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Operations { get; set; }

		/// <summary>
		/// <para>Output Messages</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutMessages { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

	}
}
