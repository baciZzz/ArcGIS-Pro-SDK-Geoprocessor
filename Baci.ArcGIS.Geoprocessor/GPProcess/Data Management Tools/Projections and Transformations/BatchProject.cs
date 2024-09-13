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
	/// <para>批量投影</para>
	/// <para>将一组输入要素类或要素数据集的坐标系更改为通用坐标系。要更改单个要素类或数据集的坐标系，请使用投影工具。</para>
	/// </summary>
	public class BatchProject : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClassOrDataset">
		/// <para>Input Feature Class or Dataset</para>
		/// <para>要转换坐标的输入要素类或要素数据集。</para>
		/// </param>
		/// <param name="OutputWorkspace">
		/// <para>Output Workspace</para>
		/// <para>每个新输出要素类或要素数据集的位置。</para>
		/// </param>
		public BatchProject(object InputFeatureClassOrDataset, object OutputWorkspace)
		{
			this.InputFeatureClassOrDataset = InputFeatureClassOrDataset;
			this.OutputWorkspace = OutputWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 批量投影</para>
		/// </summary>
		public override string DisplayName() => "批量投影";

		/// <summary>
		/// <para>Tool Name : BatchProject</para>
		/// </summary>
		public override string ToolName() => "BatchProject";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchProject</para>
		/// </summary>
		public override string ExcuteName() => "management.BatchProject";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClassOrDataset, OutputWorkspace, OutputCoordinateSystem!, TemplateDataset!, Transformation!, DerivedOutput! };

		/// <summary>
		/// <para>Input Feature Class or Dataset</para>
		/// <para>要转换坐标的输入要素类或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputFeatureClassOrDataset { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// <para>每个新输出要素类或要素数据集的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>用于对输入进行投影的坐标系。默认值将基于输出坐标系环境进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? OutputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Template dataset</para>
		/// <para>用于指定投影时所用输出坐标系的要素类或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEGeoDatasetType()]
		public object? TemplateDataset { get; set; }

		/// <summary>
		/// <para>Transformation</para>
		/// <para>在两种地理坐标系（基准面）之间转换数据所应用的地理（坐标）变换的名称。</para>
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
