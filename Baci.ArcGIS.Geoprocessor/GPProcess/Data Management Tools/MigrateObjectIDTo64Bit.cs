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
	/// <para>Migrate ObjectID to 64-Bit</para>
	/// <para>Migrate ObjectID to 64-Bit</para>
	/// <para>Migrates the ObjectID to 64-Bit Precision</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[Obsolete()]
	[InputWillBeModified()]
	public class MigrateObjectIDTo64Bit : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDatasets">
		/// <para>Input Datasets</para>
		/// </param>
		public MigrateObjectIDTo64Bit(object InDatasets)
		{
			this.InDatasets = InDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : Migrate ObjectID to 64-Bit</para>
		/// </summary>
		public override string DisplayName() => "Migrate ObjectID to 64-Bit";

		/// <summary>
		/// <para>Tool Name : MigrateObjectIDTo64Bit</para>
		/// </summary>
		public override string ToolName() => "MigrateObjectIDTo64Bit";

		/// <summary>
		/// <para>Tool Excute Name : management.MigrateObjectIDTo64Bit</para>
		/// </summary>
		public override string ExcuteName() => "management.MigrateObjectIDTo64Bit";

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
		public override object[] Parameters() => new object[] { InDatasets, OutDatasets! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Output Datasets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutDatasets { get; set; }

	}
}
