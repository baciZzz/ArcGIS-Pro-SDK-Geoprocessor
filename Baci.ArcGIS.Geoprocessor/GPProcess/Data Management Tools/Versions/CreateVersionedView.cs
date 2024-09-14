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
	/// <para>Create Versioned View</para>
	/// <para>Create Versioned View</para>
	/// <para>Creates a versioned view on a table or feature class.</para>
	/// </summary>
	[Obsolete()]
	public class CreateVersionedView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Table or Feature Class</para>
		/// <para>Input table or feature class for which a versioned view will be created.</para>
		/// </param>
		public CreateVersionedView(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Versioned View</para>
		/// </summary>
		public override string DisplayName() => "Create Versioned View";

		/// <summary>
		/// <para>Tool Name : CreateVersionedView</para>
		/// </summary>
		public override string ToolName() => "CreateVersionedView";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVersionedView</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateVersionedView";

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
		public override object[] Parameters() => new object[] { InDataset, InName, OutDataset };

		/// <summary>
		/// <para>Input Table or Feature Class</para>
		/// <para>Input table or feature class for which a versioned view will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Versioned View Name</para>
		/// <para>Name for the versioned view that is created. If nothing is specified the output versioned view name is the name of the table or feature class with _evw appended to the end.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object InName { get; set; }

		/// <summary>
		/// <para>Output Table or Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateVersionedView SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
