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
	/// <para>Quick Export</para>
	/// <para>Quick Export</para>
	/// <para>Geoprocessing tool to convert one or more input feature classes or feature layers into any format supported by the ArcGIS Data Interoperability extension.</para>
	/// </summary>
	public class QuickExport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input Layer</para>
		/// <para>The feature layers or feature classes that will be exported from ArcGIS.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>The format and dataset to which the data will be exported.</para>
		/// </param>
		public QuickExport(object Input, object Output)
		{
			this.Input = Input;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : Quick Export</para>
		/// </summary>
		public override string DisplayName() => "Quick Export";

		/// <summary>
		/// <para>Tool Name : QuickExport</para>
		/// </summary>
		public override string ToolName() => "QuickExport";

		/// <summary>
		/// <para>Tool Excute Name : interop.QuickExport</para>
		/// </summary>
		public override string ExcuteName() => "interop.QuickExport";

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
		public override string[] ValidEnvironments() => new string[] { "workspace", "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The feature layers or feature classes that will be exported from ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The format and dataset to which the data will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[FMEDestDatasetType()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public QuickExport SetEnviroment(object? workspace = null , object? scratchWorkspace = null )
		{
			base.SetEnv(workspace: workspace, scratchWorkspace: scratchWorkspace);
			return this;
		}

	}
}
