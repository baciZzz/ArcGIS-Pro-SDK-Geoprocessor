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
	/// <para>Export Topology Errors</para>
	/// <para>Exports the errors and exceptions from a geodatabase topology to the target geodatabase.  All information associated with the errors and exceptions, such as the features referenced by the error or exception, is exported.</para>
	/// <para>Once the errors and exceptions are exported, the feature classes can be accessed using any license level of ArcGIS.  The feature classes can be used with the Select Layer By Location tool and can be shared with other users who do not have access to the topology.</para>
	/// </summary>
	public class ExportTopologyErrors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The topology from which the errors will be exported.</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>The output workspace in which the feature classes will be created. The default is the workspace where the topology is located. If the input is a topology service, the default will be the default geodatabase for the project.</para>
		/// </param>
		/// <param name="OutBasename">
		/// <para>Base Name</para>
		/// <para>The name to prefix to each output feature class. This allows you to specify unique output names when running multiple exports to the same workspace. The default is the topology name.</para>
		/// </param>
		public ExportTopologyErrors(object InTopology, object OutPath, object OutBasename)
		{
			this.InTopology = InTopology;
			this.OutPath = OutPath;
			this.OutBasename = OutBasename;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Topology Errors</para>
		/// </summary>
		public override string DisplayName => "Export Topology Errors";

		/// <summary>
		/// <para>Tool Name : ExportTopologyErrors</para>
		/// </summary>
		public override string ToolName => "ExportTopologyErrors";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportTopologyErrors</para>
		/// </summary>
		public override string ExcuteName => "management.ExportTopologyErrors";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTopology, OutPath, OutBasename, OutFeatureClassPoints, OutFeatureClassLines, OutFeatureClassPolygons };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>The topology from which the errors will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The output workspace in which the feature classes will be created. The default is the workspace where the topology is located. If the input is a topology service, the default will be the default geodatabase for the project.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Base Name</para>
		/// <para>The name to prefix to each output feature class. This allows you to specify unique output names when running multiple exports to the same workspace. The default is the topology name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutBasename { get; set; }

		/// <summary>
		/// <para>Output point features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClassPoints { get; set; }

		/// <summary>
		/// <para>Output line features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClassLines { get; set; }

		/// <summary>
		/// <para>Output polygon features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClassPolygons { get; set; }

	}
}
