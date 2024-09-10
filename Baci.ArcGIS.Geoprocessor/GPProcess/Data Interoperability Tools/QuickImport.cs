using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataInteroperabilityTools
{
	/// <summary>
	/// <para>Quick Import</para>
	/// <para>Geoprocessing tool to import data in any format supported by the ArcGIS Data Interoperability extension into feature classes.</para>
	/// </summary>
	public class QuickImport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input Dataset</para>
		/// <para>The data to be imported.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Geodatabase</para>
		/// <para>The output file or personal geodatabase.</para>
		/// </param>
		public QuickImport(object Input, object Output)
		{
			this.Input = Input;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : Quick Import</para>
		/// </summary>
		public override string DisplayName() => "Quick Import";

		/// <summary>
		/// <para>Tool Name : QuickImport</para>
		/// </summary>
		public override string ToolName() => "QuickImport";

		/// <summary>
		/// <para>Tool Excute Name : interop.QuickImport</para>
		/// </summary>
		public override string ExcuteName() => "interop.QuickImport";

		/// <summary>
		/// <para>Toolbox Display Name : Data Interoperability Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Interoperability Tools";

		/// <summary>
		/// <para>Toolbox Alise : interop</para>
		/// </summary>
		public override string ToolboxAlise() => "interop";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, Output };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The data to be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[FMESourceDatasetType()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The output file or personal geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object Output { get; set; }

	}
}
