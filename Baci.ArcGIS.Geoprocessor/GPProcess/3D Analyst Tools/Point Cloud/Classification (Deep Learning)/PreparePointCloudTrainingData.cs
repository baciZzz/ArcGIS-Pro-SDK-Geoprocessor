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
	/// <para>用于生成相应数据，这些数据用于训练和验证 PointCNN 模型以对点云进行分类。</para>
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
		/// <para>根据输入点云创建的每个 HDF5 切片的二维宽度和高度。 通常，块大小应足够大，才能捕获感兴趣对象及其周围环境。</para>
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
		public override object[] Parameters() => new object[] { InPointCloud, BlockSize, OutTrainingData, TrainingBoundary, ValidationPointCloud, ValidationBoundary, ClassCodesOfInterest, BlockPointLimit };

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
		/// <para>根据输入点云创建的每个 HDF5 切片的二维宽度和高度。 通常，块大小应足够大，才能捕获感兴趣对象及其周围环境。</para>
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
		public object TrainingBoundary { get; set; }

		/// <summary>
		/// <para>Validation Point Cloud</para>
		/// <para>将用于验证深度学习模型的点云的源。 该数据集必须引用与输入点云不同的点集，才能确保经过训练的模型的质量。 如果未指定验证点云，则必须同时提供训练边界要素和验证边界要素参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object ValidationPointCloud { get; set; }

		/// <summary>
		/// <para>Validation Boundary Features</para>
		/// <para>将描绘用于验证经过训练的模型的点子集的面要素。 如果未指定验证点云，则将从输入点云中获取这些点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object ValidationBoundary { get; set; }

		/// <summary>
		/// <para>Class Codes of Interest</para>
		/// <para>将导出的训练数据块限制为仅包含指定值的训练数据块的类代码。 对于至少包含此参数中列出的其中一个类代码的任何块，将导出该块中的所有点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ClassCodesOfInterest { get; set; }

		/// <summary>
		/// <para>Block Point Limit</para>
		/// <para>每个训练数据块中允许的最大点数。 如果某个块中包含的点数超过该值，则将针对同一位置创建多个块，以确保训练时使用所有这些点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object BlockPointLimit { get; set; } = "8192";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PreparePointCloudTrainingData SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
