using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Evaluate Point Cloud Classification Model</para>
	/// <para>Evaluates the quality of one or more point cloud classification models using a well-classified point cloud as a baseline for comparing the classification results obtained from each model.</para>
	/// </summary>
	public class EvaluatePointCloudClassificationModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTrainedModel">
		/// <para>Input Model Definition</para>
		/// <para>The point cloud classification models and batch sizes that will be used during the evaluation process.</para>
		/// </param>
		/// <param name="InPointCloud">
		/// <para>Reference Point Cloud</para>
		/// <para>The point cloud that will be used to evaluate the classification models.</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>The directory that will store the files which summarize the evaluation results.</para>
		/// </param>
		/// <param name="BaseName">
		/// <para>Base Name</para>
		/// <para>The file name prefix that will be used for each of the output files summarizing the evaluation results.</para>
		/// </param>
		public EvaluatePointCloudClassificationModel(object InTrainedModel, object InPointCloud, object TargetFolder, object BaseName)
		{
			this.InTrainedModel = InTrainedModel;
			this.InPointCloud = InPointCloud;
			this.TargetFolder = TargetFolder;
			this.BaseName = BaseName;
		}

		/// <summary>
		/// <para>Tool Display Name : Evaluate Point Cloud Classification Model</para>
		/// </summary>
		public override string DisplayName => "Evaluate Point Cloud Classification Model";

		/// <summary>
		/// <para>Tool Name : EvaluatePointCloudClassificationModel</para>
		/// </summary>
		public override string ToolName => "EvaluatePointCloudClassificationModel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EvaluatePointCloudClassificationModel</para>
		/// </summary>
		public override string ExcuteName => "3d.EvaluatePointCloudClassificationModel";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTrainedModel, InPointCloud, TargetFolder, BaseName, Boundary!, ClassRemap!, OutConfusionMatrices!, OutModelStatistics!, OutClassCodeStatistics!, ReferenceHeight!, ExcludedClassCodes! };

		/// <summary>
		/// <para>Input Model Definition</para>
		/// <para>The point cloud classification models and batch sizes that will be used during the evaluation process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InTrainedModel { get; set; }

		/// <summary>
		/// <para>Reference Point Cloud</para>
		/// <para>The point cloud that will be used to evaluate the classification models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The directory that will store the files which summarize the evaluation results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Base Name</para>
		/// <para>The file name prefix that will be used for each of the output files summarizing the evaluation results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BaseName { get; set; } = "Evaluate";

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>The polygon feature that delineates the portions of the reference point cloud that will be used for evaluating the classification models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? Boundary { get; set; }

		/// <summary>
		/// <para>Point Cloud Class Remapping</para>
		/// <para>The class codes from the reference point cloud must match the class codes in the models being evaluated. When the class codes do not match, use this parameter to associate the differing class codes in the point cloud with the classes that are supported in the models being evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ClassRemap { get; set; }

		/// <summary>
		/// <para>Output Confusion Matrices</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutConfusionMatrices { get; set; }

		/// <summary>
		/// <para>Output Model Statistics</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutModelStatistics { get; set; }

		/// <summary>
		/// <para>Output Class Code Statistics</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutClassCodeStatistics { get; set; }

		/// <summary>
		/// <para>Reference Surface</para>
		/// <para>The raster surface that will be used to provide relative height values for each point in the point cloud data. Points that do not overlap with the raster will be omitted from the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceHeight { get; set; }

		/// <summary>
		/// <para>Excluded Class Codes</para>
		/// <para>The class codes that will be excluded from processing. Any value in the range of 0 to 255 can be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		public object? ExcludedClassCodes { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EvaluatePointCloudClassificationModel SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? processorType = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, processorType: processorType);
			return this;
		}

	}
}
