using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Copy S-57 Features</para>
	/// <para>Copy S-57 Features</para>
	/// <para>Copies features from a layer or multiple</para>
	/// <para>layers to a target geodatabase.</para>
	/// </summary>
	public class CopyS57Features : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that will be copied to the Target Workspace parameter value.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which the output data will be written.</para>
		/// </param>
		public CopyS57Features(object InFeatures, object TargetWorkspace)
		{
			this.InFeatures = InFeatures;
			this.TargetWorkspace = TargetWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy S-57 Features</para>
		/// </summary>
		public override string DisplayName() => "Copy S-57 Features";

		/// <summary>
		/// <para>Tool Name : CopyS57Features</para>
		/// </summary>
		public override string ToolName() => "CopyS57Features";

		/// <summary>
		/// <para>Tool Excute Name : maritime.CopyS57Features</para>
		/// </summary>
		public override string ExcuteName() => "maritime.CopyS57Features";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise() => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, TargetWorkspace, CompilationScale, UpdatedWorkspace };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that will be copied to the Target Workspace parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which the output data will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Compilation Scale</para>
		/// <para>The compilation scale attribute value that will be applied to the copied features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CompilationScale { get; set; }

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedWorkspace { get; set; }

	}
}
