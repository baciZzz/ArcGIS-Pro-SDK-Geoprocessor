using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Classify Objects Using Deep Learning</para>
	/// <para>使用深度学习分类对象</para>
	/// <para>用于运行输入栅格和可选要素类上的训练深度学习模型，以生成要素类或表，其中每个输入对象或要素均具有一个分配的类或类别标注。</para>
	/// </summary>
	public class ClassifyObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>用于检测对象的输入图像。 输入可以是镶嵌数据集、影像服务或影像文件夹中的单个栅格或多个栅格。 还支持具有影像附件的要素类。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Classified Objects Feature Class</para>
		/// <para>包含输入要素类中对象或要素周围几何的输出要素类，以及用于存储分类标注的字段。</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>Esri 模型定义参数值可以是 Esri 模型定义 JSON 文件 (.emd)、JSON 字符串或深度学习模型包 (.dlpk)。 当在服务器上使用此工具时，JSON 字符串十分有用，因为您可以直接粘贴 JSON 字符串，而无需上传 .emd 文件。 .dlpk 文件必须存储在本地。</para>
		/// <para>其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </param>
		public ClassifyObjectsUsingDeepLearning(object InRaster, object OutFeatureClass, object InModelDefinition)
		{
			this.InRaster = InRaster;
			this.OutFeatureClass = OutFeatureClass;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习分类对象</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习分类对象";

		/// <summary>
		/// <para>Tool Name : ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ClassifyObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.ClassifyObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFeatureClass, InModelDefinition, InFeatures, ClassLabelField, ProcessingMode, ModelArguments };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>用于检测对象的输入图像。 输入可以是镶嵌数据集、影像服务或影像文件夹中的单个栅格或多个栅格。 还支持具有影像附件的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Classified Objects Feature Class</para>
		/// <para>包含输入要素类中对象或要素周围几何的输出要素类，以及用于存储分类标注的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Model Definition</para>
		/// <para>Esri 模型定义参数值可以是 Esri 模型定义 JSON 文件 (.emd)、JSON 字符串或深度学习模型包 (.dlpk)。 当在服务器上使用此工具时，JSON 字符串十分有用，因为您可以直接粘贴 JSON 字符串，而无需上传 .emd 文件。 .dlpk 文件必须存储在本地。</para>
		/// <para>其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InModelDefinition { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于标识要分类或要标注的每个对象或要素位置的点、线或面输入要素类。 输入要素类中的每一行表示一个对象或要素。</para>
		/// <para>如果未指定输入要素类，则工具将假设每个输入影像包含单个待分类对象。 如果一个或多个输入影像使用空间参考，则工具的输出为要素类，其中每个影像的范围将用作每个标注要素类的边界几何。 如果一个或多个输入影像没有使用空间参考，则工具的输出为包含影像 ID 值和每个影像类标注的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Class Label Field</para>
		/// <para>包含输出要素类中类或类别标注的字段名称。</para>
		/// <para>如果未指定字段名称，则会在输出要素类中生成一个名为 ClassLabel 的新字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ClassLabelField { get; set; } = "ClassLabel";

		/// <summary>
		/// <para>Processing Mode</para>
		/// <para>指定处理镶嵌数据集或影像服务中的所有栅格项目的方式。 当输入栅格是镶嵌数据集或影像服务时，将应用此参数。</para>
		/// <para>以镶嵌影像方式处理—将镶嵌在一起并处理镶嵌数据集或影像服务中的所有栅格项目。 这是默认设置。</para>
		/// <para>单独处理所有栅格项目—将作为独立影像处理镶嵌数据集或影像服务中的所有栅格项目。</para>
		/// <para><see cref="ProcessingModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ProcessingMode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>Python 栅格函数类中定义的函数参数。 可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于调整灵敏度的置信度阈值。 参数名称将通过 Python 模块进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ModelArguments { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyObjectsUsingDeepLearning SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Processing Mode</para>
		/// </summary>
		public enum ProcessingModeEnum 
		{
			/// <summary>
			/// <para>以镶嵌影像方式处理—将镶嵌在一起并处理镶嵌数据集或影像服务中的所有栅格项目。 这是默认设置。</para>
			/// </summary>
			[GPValue("PROCESS_AS_MOSAICKED_IMAGE")]
			[Description("以镶嵌影像方式处理")]
			Process_as_mosaicked_image,

			/// <summary>
			/// <para>单独处理所有栅格项目—将作为独立影像处理镶嵌数据集或影像服务中的所有栅格项目。</para>
			/// </summary>
			[GPValue("PROCESS_ITEMS_SEPARATELY")]
			[Description("单独处理所有栅格项目")]
			Process_all_raster_items_separately,

		}

#endregion
	}
}
