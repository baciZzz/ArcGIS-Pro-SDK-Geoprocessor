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
	/// <para>Classify Pixels Using Deep Learning</para>
	/// <para>使用深度学习分类像素</para>
	/// <para>用于运行输入栅格上的训练深度学习模型，以生成分类栅格，其中每个有效像素都被分配了一个类标注。</para>
	/// </summary>
	public class ClassifyPixelsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待分类的输入栅格数据集。 输入可以是镶嵌数据集、影像服务或影像文件夹中的单个栅格或多个栅格。</para>
		/// </param>
		/// <param name="OutClassifiedRaster">
		/// <para>Output Classified Raster</para>
		/// <para>分类栅格的名称或包含分类栅格的镶嵌数据集的名称。</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>Esri 模型定义参数值可以是 Esri 模型定义 JSON 文件 (.emd)、JSON 字符串或深度学习模型包 (.dlpk)。 当在服务器上使用此工具时，JSON 字符串十分有用，因为您可以直接粘贴 JSON 字符串，而无需上传 .emd 文件。 .dlpk 文件必须存储在本地。</para>
		/// <para>其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </param>
		public ClassifyPixelsUsingDeepLearning(object InRaster, object OutClassifiedRaster, object InModelDefinition)
		{
			this.InRaster = InRaster;
			this.OutClassifiedRaster = OutClassifiedRaster;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习分类像素</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习分类像素";

		/// <summary>
		/// <para>Tool Name : ClassifyPixelsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ClassifyPixelsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.ClassifyPixelsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.ClassifyPixelsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutClassifiedRaster, InModelDefinition, Arguments, ProcessingMode, OutClassifiedFolder };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待分类的输入栅格数据集。 输入可以是镶嵌数据集、影像服务或影像文件夹中的单个栅格或多个栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// <para>分类栅格的名称或包含分类栅格的镶嵌数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutClassifiedRaster { get; set; }

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
		/// <para>Arguments</para>
		/// <para>函数参数在 Python 栅格函数类中定义。 您可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于调整灵敏度的置信度阈值。 参数名称将通过读取 Python 模块进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Arguments { get; set; }

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
		/// <para>Output Folder</para>
		/// <para>将存储输出分类栅格的文件夹。将使用此文件夹中的分类栅格来生成镶嵌数据集。</para>
		/// <para>当输入栅格是要单独处理所有项目的影像文件夹或镶嵌数据集时，此参数为必需项。默认为工程文件夹中的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object OutClassifiedFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyPixelsUsingDeepLearning SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
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
