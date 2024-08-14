using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Create Cross-Reference Geodatabase</para>
	/// <para>Creates a cross-reference geodatabase that the Load Data tool uses to map source data to target data when loading batch data.</para>
	/// </summary>
	public class CreateCrossReferenceGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceWorkspace">
		/// <para>Source Workspace</para>
		/// <para>The workspace, either a geodatabase or shapefile directory, that contains the schema of data that will be mapped to the target workspace.</para>
		/// </param>
		/// <param name="TargetDatabase">
		/// <para>Target Database</para>
		/// <para>The geodatabase that contains the schema of the database to which the source will be mapped.</para>
		/// </param>
		/// <param name="OutDatabase">
		/// <para>Output Database</para>
		/// <para>The file geodatabase that will be created containing the mapping from the Source Workspace parameter value to the Target Database parameter value.</para>
		/// </param>
		public CreateCrossReferenceGeodatabase(object SourceWorkspace, object TargetDatabase, object OutDatabase)
		{
			this.SourceWorkspace = SourceWorkspace;
			this.TargetDatabase = TargetDatabase;
			this.OutDatabase = OutDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Cross-Reference Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Create Cross-Reference Geodatabase";

		/// <summary>
		/// <para>Tool Name : CreateCrossReferenceGeodatabase</para>
		/// </summary>
		public override string ToolName => "CreateCrossReferenceGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CreateCrossReferenceGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "topographic.CreateCrossReferenceGeodatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SourceWorkspace, TargetDatabase, OutDatabase, MappingFile! };

		/// <summary>
		/// <para>Source Workspace</para>
		/// <para>The workspace, either a geodatabase or shapefile directory, that contains the schema of data that will be mapped to the target workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPWorkspaceDomain()]
		public object SourceWorkspace { get; set; }

		/// <summary>
		/// <para>Target Database</para>
		/// <para>The geodatabase that contains the schema of the database to which the source will be mapped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetDatabase { get; set; }

		/// <summary>
		/// <para>Output Database</para>
		/// <para>The file geodatabase that will be created containing the mapping from the Source Workspace parameter value to the Target Database parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object OutDatabase { get; set; }

		/// <summary>
		/// <para>Mapping File</para>
		/// <para>An Excel spreadsheet that contains information on how the source features, fields, and attribute value will be mapped to the Target Database parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? MappingFile { get; set; }

	}
}
