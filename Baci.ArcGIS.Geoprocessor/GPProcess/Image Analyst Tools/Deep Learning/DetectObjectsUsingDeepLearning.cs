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
	/// <para>Detect Objects Using Deep Learning</para>
	/// <para>使用深度学习检测对象</para>
	/// <para>用于运行输入栅格上的训练深度学习模型，以生成包含其找到对象的要素类。 这些要素可以是所找到对象周围的边界框或面，也可以是对象中心的点。</para>
	/// </summary>
	public class DetectObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>用于检测对象的输入图像。 输入可以是镶嵌数据集、影像服务或影像文件夹中的单个栅格或多个栅格。 还支持具有影像附件的要素类。</para>
		/// </param>
		/// <param name="OutDetectedObjects">
		/// <para>Output Detected Objects</para>
		/// <para>此输出要素类中包含围绕输入图像中检测到的一个或多个对象的几何。</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>此参数可以是 Esri 模型定义 JSON 文件 (.emd)、JSON 字符串或深度学习模型包 (.dlpk)。 当在服务器上使用此工具时，JSON 字符串十分有用，因为您可以直接粘贴 JSON 字符串，而无需上传 .emd 文件。 .dlpk 文件必须存储在本地。</para>
		/// <para>其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </param>
		public DetectObjectsUsingDeepLearning(object InRaster, object OutDetectedObjects, object InModelDefinition)
		{
			this.InRaster = InRaster;
			this.OutDetectedObjects = OutDetectedObjects;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习检测对象</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习检测对象";

		/// <summary>
		/// <para>Tool Name : DetectObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "DetectObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.DetectObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.DetectObjectsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutDetectedObjects, InModelDefinition, Arguments!, RunNms!, ConfidenceScoreField!, ClassValueField!, MaxOverlapRatio!, ProcessingMode!, OutClassifiedRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>用于检测对象的输入图像。 输入可以是镶嵌数据集、影像服务或影像文件夹中的单个栅格或多个栅格。 还支持具有影像附件的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Detected Objects</para>
		/// <para>此输出要素类中包含围绕输入图像中检测到的一个或多个对象的几何。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutDetectedObjects { get; set; }

		/// <summary>
		/// <para>Model Definition</para>
		/// <para>此参数可以是 Esri 模型定义 JSON 文件 (.emd)、JSON 字符串或深度学习模型包 (.dlpk)。 当在服务器上使用此工具时，JSON 字符串十分有用，因为您可以直接粘贴 JSON 字符串，而无需上传 .emd 文件。 .dlpk 文件必须存储在本地。</para>
		/// <para>其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InModelDefinition { get; set; }

		/// <summary>
		/// <para>Arguments</para>
		/// <para>函数参数在 Python 栅格函数类中定义。 可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于调整灵敏度的置信度阈值。 参数名称将通过 Python 模块进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Arguments { get; set; }

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// <para>指定是否将执行非极大值抑制，其中将标识重复的对象，并移除置信度值较低的重复要素。</para>
		/// <para>未选中 - 不执行非极大值抑制。 所有检测到的对象都将位于输出要素类中。 这是默认设置。</para>
		/// <para>选中 - 将执行非极大值抑制，并且将移除检测到的重复对象。</para>
		/// <para><see cref="RunNmsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RunNms { get; set; } = "false";

		/// <summary>
		/// <para>Confidence Score Field</para>
		/// <para>要素类中包含将由对象检测方法输出的置信度得分的字段的名称。</para>
		/// <para>当选中了非最大抑制参数时需要用到该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ConfidenceScoreField { get; set; } = "Confidence";

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>输入要素类中类值字段的名称。</para>
		/// <para>如果未指定字段名称，则 Classvalue 或 Value 字段将被使用。 如果这些字段不存在，则会将所有记录标识为属于一个类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ClassValueField { get; set; } = "Class";

		/// <summary>
		/// <para>Max Overlap Ratio</para>
		/// <para>两个重叠要素的最大重叠比，其定义为交集区域与并集区域之比。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxOverlapRatio { get; set; } = "0";

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
		public object? ProcessingMode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutClassifiedRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectObjectsUsingDeepLearning SetEnviroment(object? cellSize = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? processorType = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// </summary>
		public enum RunNmsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NMS")]
			NMS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_NMS")]
			NO_NMS,

		}

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
