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
	/// <para>Prepare Point Cloud Training Data</para>
	/// <para>准备点云训练数据</para>
	/// <para>用于生成相应数据，这些数据用于训练和验证 PointCNN 模型以进行点云分类。</para>
	/// </summary>
	public class PreparePointCloudTrainingData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Input Point Cloud</para>
		/// <para>如果未指定任何验证点云，则将用于创建训练数据以及可能用于创建验证数据的点云。 在这种情况下，必须同时定义训练边界和验证边界。</para>
		/// </param>
		/// <param name="BlockSize">
		/// <para>Block Size</para>
		/// <para>根据输入点云创建的每个圆形 HDF5 切片的直径大小。 通常，块大小应足够大，才能捕获感兴趣对象及其周围环境。</para>
		/// </param>
		/// <param name="OutTrainingData">
		/// <para>Output Training Data</para>
		/// <para>输出训练数据 (*.pctd) 的位置和名称。</para>
		/// </param>
		public PreparePointCloudTrainingData(object InPointCloud, object BlockSize, object OutTrainingData)
		{
			this.InPointCloud = InPointCloud;
			this.BlockSize = BlockSize;
			this.OutTrainingData = OutTrainingData;
		}

		/// <summary>
		/// <para>Tool Display Name : 准备点云训练数据</para>
		/// </summary>
		public override string DisplayName() => "准备点云训练数据";

		/// <summary>
		/// <para>Tool Name : PreparePointCloudTrainingData</para>
		/// </summary>
		public override string ToolName() => "PreparePointCloudTrainingData";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PreparePointCloudTrainingData</para>
		/// </summary>
		public override string ExcuteName() => "3d.PreparePointCloudTrainingData";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointCloud, BlockSize, OutTrainingData, TrainingBoundary!, ValidationPointCloud!, ValidationBoundary!, ClassCodesOfInterest!, BlockPointLimit!, ReferenceHeight!, ExcludedClassCodes! };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>如果未指定任何验证点云，则将用于创建训练数据以及可能用于创建验证数据的点云。 在这种情况下，必须同时定义训练边界和验证边界。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Block Size</para>
		/// <para>根据输入点云创建的每个圆形 HDF5 切片的直径大小。 通常，块大小应足够大，才能捕获感兴趣对象及其周围环境。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BlockSize { get; set; }

		/// <summary>
		/// <para>Output Training Data</para>
		/// <para>输出训练数据 (*.pctd) 的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pctd")]
		public object OutTrainingData { get; set; }

		/// <summary>
		/// <para>Training Boundary Features</para>
		/// <para>将根据用于训练深度学习模型的输入点云描绘点的子集的边界面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? TrainingBoundary { get; set; }

		/// <summary>
		/// <para>Validation Point Cloud</para>
		/// <para>在训练过程中将用于验证深度学习模型的点云。 该数据集必须引用与输入点云不同的点集，才能确保经过训练的模型的质量。 如果未指定验证点云，则输入点云可用于通过为训练边界要素和验证边界要素参数提供面要素类来定义训练和验证数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? ValidationPointCloud { get; set; }

		/// <summary>
		/// <para>Validation Boundary Features</para>
		/// <para>将描绘用于在训练过程中评估模型的点子集的面要素。 如果未指定验证点云，则将从输入点云中获取这些点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? ValidationBoundary { get; set; }

		/// <summary>
		/// <para>Filter Blocks By Class Code</para>
		/// <para>将用于限制导出的训练数据块的类代码。 块中所有至少包含一个为此参数列出的值的点都将被导出，但排除的类代码参数中指定的类或标记为保留点的点除外。 可以指定 0 到 255 范围内的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ClassCodesOfInterest { get; set; }

		/// <summary>
		/// <para>Block Point Limit</para>
		/// <para>每个训练数据块中将允许的最大点数。 如果某个块中包含的点数超过该值，则将针对同一位置创建多个块，以确保训练时使用所有这些点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? BlockPointLimit { get; set; } = "8192";

		/// <summary>
		/// <para>Reference Surface</para>
		/// <para>将用于为点云数据中的每个点提供相对高度值的栅格表面。 与栅格不重叠的点将在分析中忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceHeight { get; set; }

		/// <summary>
		/// <para>Excluded Class Codes</para>
		/// <para>将从训练数据中排除的类代码。 可以指定 0 到 255 范围内的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPRangeDomain(Min = 0, Max = 255)]
		public object? ExcludedClassCodes { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PreparePointCloudTrainingData SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
