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
	/// <para>评估点云分类模型</para>
	/// <para>使用分类良好的点云作为基线来评估一个或多个点云分类模型的质量，从而比较从每个模型获得的分类结果。</para>
	/// </summary>
	public class EvaluatePointCloudClassificationModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTrainedModel">
		/// <para>Input Model Definition</para>
		/// <para>将在评估过程中使用的点云分类模型和批量大小。</para>
		/// </param>
		/// <param name="InPointCloud">
		/// <para>Reference Point Cloud</para>
		/// <para>将用于评估分类模型的点云。</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>将用于存储汇总评估结果的文件的目录。</para>
		/// </param>
		/// <param name="BaseName">
		/// <para>Base Name</para>
		/// <para>将用于汇总评估结果的每个输出文件的文件名前缀。</para>
		/// </param>
		public EvaluatePointCloudClassificationModel(object InTrainedModel, object InPointCloud, object TargetFolder, object BaseName)
		{
			this.InTrainedModel = InTrainedModel;
			this.InPointCloud = InPointCloud;
			this.TargetFolder = TargetFolder;
			this.BaseName = BaseName;
		}

		/// <summary>
		/// <para>Tool Display Name : 评估点云分类模型</para>
		/// </summary>
		public override string DisplayName() => "评估点云分类模型";

		/// <summary>
		/// <para>Tool Name : EvaluatePointCloudClassificationModel</para>
		/// </summary>
		public override string ToolName() => "EvaluatePointCloudClassificationModel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EvaluatePointCloudClassificationModel</para>
		/// </summary>
		public override string ExcuteName() => "3d.EvaluatePointCloudClassificationModel";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTrainedModel, InPointCloud, TargetFolder, BaseName, Boundary!, ClassRemap!, OutConfusionMatrices!, OutModelStatistics!, OutClassCodeStatistics!, ReferenceHeight!, ExcludedClassCodes! };

		/// <summary>
		/// <para>Input Model Definition</para>
		/// <para>将在评估过程中使用的点云分类模型和批量大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InTrainedModel { get; set; }

		/// <summary>
		/// <para>Reference Point Cloud</para>
		/// <para>将用于评估分类模型的点云。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>将用于存储汇总评估结果的文件的目录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Base Name</para>
		/// <para>将用于汇总评估结果的每个输出文件的文件名前缀。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BaseName { get; set; } = "Evaluate";

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>用于描绘将用于评估分类模型的参考点云部分的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? Boundary { get; set; }

		/// <summary>
		/// <para>Point Cloud Class Remapping</para>
		/// <para>参考点云中的类代码必须与正在评估的模型中的类代码相匹配。 当类代码不匹配时，使用此参数将点云中的不同类代码与正在评估的模型中支持的类相关联。</para>
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
		/// <para>将用于为点云数据中的每个点提供相对高度值的栅格表面。 与栅格不重叠的点将在分析中忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceHeight { get; set; }

		/// <summary>
		/// <para>Excluded Class Codes</para>
		/// <para>将从处理过程中排除的类代码。 可以指定 0 到 255 范围内的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 255)]
		public object? ExcludedClassCodes { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EvaluatePointCloudClassificationModel SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? processorType = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, processorType: processorType);
			return this;
		}

	}
}
