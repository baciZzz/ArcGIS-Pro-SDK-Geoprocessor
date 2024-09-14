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
	/// <para>Create Feature Dataset</para>
	/// <para>Create Feature Dataset</para>
	/// <para>Creates a feature dataset in the output location—an existing enterprise,  file, or mobile geodatabase.</para>
	/// </summary>
	public class CreateFeatureDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutDatasetPath">
		/// <para>Output Geodatabase</para>
		/// <para>The enterprise, file, or mobile geodatabase in which the output feature dataset will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Feature Dataset Name</para>
		/// <para>The name of the feature dataset to be created.</para>
		/// </param>
		public CreateFeatureDataset(object OutDatasetPath, object OutName)
		{
			this.OutDatasetPath = OutDatasetPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Feature Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Feature Dataset";

		/// <summary>
		/// <para>Tool Name : CreateFeatureDataset</para>
		/// </summary>
		public override string ToolName() => "CreateFeatureDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFeatureDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFeatureDataset";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutDatasetPath, OutName, SpatialReference!, OutDataset! };

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The enterprise, file, or mobile geodatabase in which the output feature dataset will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutDatasetPath { get; set; }

		/// <summary>
		/// <para>Feature Dataset Name</para>
		/// <para>The name of the feature dataset to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output feature dataset. On the Spatial Reference Properties dialog box, you can select, import, or create a new coordinate system. To set aspects of the spatial reference, such as the x,y-, z-, or m-domain, resolution, or tolerance, use the Environments dialog box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFeatureDataset SetEnviroment(double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
