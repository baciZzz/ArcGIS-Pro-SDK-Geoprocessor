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
	/// <para>Classify Point Cloud Using Trained Model</para>
	/// <para>使用经过训练的模型对点云进行分类</para>
	/// <para>使用 PointCNN 分类模型对点云进行分类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyPointCloudUsingTrainedModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Target Point Cloud</para>
		/// <para>将进行分类的点云。</para>
		/// </param>
		/// <param name="InTrainedModel">
		/// <para>Input Model Definition</para>
		/// <para>输入 Esri 模型定义文件 (*.emd) 或深度学习包 (*.dlpk) 将用于分类点云。 也可以使用在 ArcGIS Online 或 ArcGIS Living Atlas 上发布的深度学习包的网址。</para>
		/// </param>
		/// <param name="OutputClasses">
		/// <para>Target Classification</para>
		/// <para>训练模型中的类代码，将用于对输入点云进行分类。 除非已指定子集，否则默认情况下将使用输入模型中的所有类。</para>
		/// </param>
		public ClassifyPointCloudUsingTrainedModel(object InPointCloud, object InTrainedModel, object OutputClasses)
		{
			this.InPointCloud = InPointCloud;
			this.InTrainedModel = InTrainedModel;
			this.OutputClasses = OutputClasses;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用经过训练的模型对点云进行分类</para>
		/// </summary>
		public override string DisplayName() => "使用经过训练的模型对点云进行分类";

		/// <summary>
		/// <para>Tool Name : ClassifyPointCloudUsingTrainedModel</para>
		/// </summary>
		public override string ToolName() => "ClassifyPointCloudUsingTrainedModel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyPointCloudUsingTrainedModel</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyPointCloudUsingTrainedModel";

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
		public override object[] Parameters() => new object[] { InPointCloud, InTrainedModel, OutputClasses, InClassMode, TargetClasses, ComputeStats, Boundary, UpdatePyramid, OutPointCloud };

		/// <summary>
		/// <para>Target Point Cloud</para>
		/// <para>将进行分类的点云。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Input Model Definition</para>
		/// <para>输入 Esri 模型定义文件 (*.emd) 或深度学习包 (*.dlpk) 将用于分类点云。 也可以使用在 ArcGIS Online 或 ArcGIS Living Atlas 上发布的深度学习包的网址。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InTrainedModel { get; set; }

		/// <summary>
		/// <para>Target Classification</para>
		/// <para>训练模型中的类代码，将用于对输入点云进行分类。 除非已指定子集，否则默认情况下将使用输入模型中的所有类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object OutputClasses { get; set; }

		/// <summary>
		/// <para>Existing Class Code Handling</para>
		/// <para>指定如何定义输入点云中的可编辑点。</para>
		/// <para>EDIT_ALL—将会编辑输入点云中的所有点。 这是默认设置。</para>
		/// <para>EDIT_SELECTED—仅会编辑具有在现有类代码参数中指定的类代码的点；所有其他点保持不变。</para>
		/// <para>PRESERVE_SELECTED—将会保留具有在现有类代码参数中指定的类代码的点；将会编辑其余点。</para>
		/// <para><see cref="InClassModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InClassMode { get; set; } = "EDIT_ALL";

		/// <summary>
		/// <para>Existing Class Codes</para>
		/// <para>将根据现有类代码处理参数值编辑点或保留原始类代码名称的类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object TargetClasses { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>面边界，可用于定义要通过输入点云处理的点的子集。 边界要素之外的点将不会进行评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Update pyramid</para>
		/// <para>指定修改类代码后，LAS 数据集金字塔是否会更新。</para>
		/// <para>选中 - LAS 数据集金字塔将更新。 这是默认设置。</para>
		/// <para>未选中 - LAS 数据集金字塔不会更新。</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Output Point Cloud</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutPointCloud { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyPointCloudUsingTrainedModel SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Existing Class Code Handling</para>
		/// </summary>
		public enum InClassModeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDIT_ALL")]
			[Description("编辑所有点")]
			Edit_All_Points,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDIT_SELECTED")]
			[Description("编辑所选点")]
			Edit_Selected_Points,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PRESERVE_SELECTED")]
			[Description("保留所选点")]
			Preserve_Selected_Points,

		}

		/// <summary>
		/// <para>Compute statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Update pyramid</para>
		/// </summary>
		public enum UpdatePyramidEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
