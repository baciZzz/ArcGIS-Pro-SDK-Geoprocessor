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
	/// <para>Batch Project</para>
	/// <para>Changes the coordinate system of a set of input feature classes or feature datasets to a common coordinate system. To change the coordinate system of a single feature class or dataset use the Project tool.</para>
	/// </summary>
	public class BatchProject : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClassOrDataset">
		/// <para>Input Feature Class or Dataset</para>
		/// <para>The input feature classes or feature datasets whose coordinates are to be converted.</para>
		/// </param>
		/// <param name="OutputWorkspace">
		/// <para>Output Workspace</para>
		/// <para>The location of each new output feature class or feature dataset.</para>
		/// </param>
		public BatchProject(object InputFeatureClassOrDataset, object OutputWorkspace)
		{
			this.InputFeatureClassOrDataset = InputFeatureClassOrDataset;
			this.OutputWorkspace = OutputWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Batch Project</para>
		/// </summary>
		public override string DisplayName => "Batch Project";

		/// <summary>
		/// <para>Tool Name : BatchProject</para>
		/// </summary>
		public override string ToolName => "BatchProject";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchProject</para>
		/// </summary>
		public override string ExcuteName => "management.BatchProject";

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
		public override string[] ValidEnvironments => new string[] { "XYResolution", "XYTolerance", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatureClassOrDataset, OutputWorkspace, OutputCoordinateSystem!, TemplateDataset!, Transformation!, DerivedOutput! };

		/// <summary>
		/// <para>Input Feature Class or Dataset</para>
		/// <para>The input feature classes or feature datasets whose coordinates are to be converted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputFeatureClassOrDataset { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// <para>The location of each new output feature class or feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system to be used to project the inputs. The default value is set based on the output coordinate system environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? OutputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Template dataset</para>
		/// <para>The feature class or the feature dataset used to specify the output coordinate system used for projection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEGeoDatasetType()]
		public object? TemplateDataset { get; set; }

		/// <summary>
		/// <para>Transformation</para>
		/// <para>The name of the geographic transformation to be applied to convert data between two geographic coordinate systems (datums).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Transformation { get; set; }

		/// <summary>
		/// <para>Updated Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? DerivedOutput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchProject SetEnviroment(object? XYResolution = null , object? XYTolerance = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
