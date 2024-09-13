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
	/// <para>Remove Contingent Value</para>
	/// <para>Remove Contingent Value</para>
	/// <para>Removes a contingent value from a field group.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveContingentValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>The input geodatabase feature class or table containing the contingent value that will be removed.</para>
		/// </param>
		/// <param name="Id">
		/// <para>Contingent Value ID</para>
		/// <para>The unique contingent value ID.</para>
		/// <para>To view the contingent value ID in the Contingent Values view, click the Toggle Value IDs button on the ribbon. In Python, this value can be accessed using the arcpy.da.ListContingentValues function.</para>
		/// </param>
		public RemoveContingentValue(object TargetTable, object Id)
		{
			this.TargetTable = TargetTable;
			this.Id = Id;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Contingent Value</para>
		/// </summary>
		public override string DisplayName() => "Remove Contingent Value";

		/// <summary>
		/// <para>Tool Name : RemoveContingentValue</para>
		/// </summary>
		public override string ToolName() => "RemoveContingentValue";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveContingentValue</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveContingentValue";

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
		public override object[] Parameters() => new object[] { TargetTable, Id, OutTable! };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>The input geodatabase feature class or table containing the contingent value that will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Contingent Value ID</para>
		/// <para>The unique contingent value ID.</para>
		/// <para>To view the contingent value ID in the Contingent Values view, click the Toggle Value IDs button on the ribbon. In Python, this value can be accessed using the arcpy.da.ListContingentValues function.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Id { get; set; }

		/// <summary>
		/// <para>Updated Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveContingentValue SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
