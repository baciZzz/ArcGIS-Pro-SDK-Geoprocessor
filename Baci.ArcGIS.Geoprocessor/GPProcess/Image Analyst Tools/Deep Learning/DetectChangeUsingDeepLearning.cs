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
	/// <para>Detect Change Using Deep Learning</para>
	/// <para>使用深度学习检测变化</para>
	/// <para>运行经过训练的深度学习模型，以检测两个栅格之间的变化。</para>
	/// </summary>
	public class DetectChangeUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FromRaster">
		/// <para>From Raster</para>
		/// <para>先前栅格的输入图像。</para>
		/// </param>
		/// <param name="ToRaster">
		/// <para>To Raster</para>
		/// <para>最近栅格的输入图像。</para>
		/// </param>
		/// <param name="OutClassifiedRaster">
		/// <para>Output Classified Raster</para>
		/// <para>显示变化的输出分类栅格。</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>Esri 模型定义参数值可以是 Esri 模型定义 JSON 文件 (.emd)、JSON 字符串或深度学习模型包 (.dlpk)。 当在服务器上使用此工具时，JSON 字符串十分有用，因为您可以直接粘贴 JSON 字符串，而无需上传 .emd 文件。 .dlpk 文件必须存储在本地。</para>
		/// <para>其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </param>
		public DetectChangeUsingDeepLearning(object FromRaster, object ToRaster, object OutClassifiedRaster, object InModelDefinition)
		{
			this.FromRaster = FromRaster;
			this.ToRaster = ToRaster;
			this.OutClassifiedRaster = OutClassifiedRaster;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习检测变化</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习检测变化";

		/// <summary>
		/// <para>Tool Name : DetectChangeUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "DetectChangeUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.DetectChangeUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.DetectChangeUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { FromRaster, ToRaster, OutClassifiedRaster, InModelDefinition, Arguments };

		/// <summary>
		/// <para>From Raster</para>
		/// <para>先前栅格的输入图像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object FromRaster { get; set; }

		/// <summary>
		/// <para>To Raster</para>
		/// <para>最近栅格的输入图像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object ToRaster { get; set; }

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// <para>显示变化的输出分类栅格。</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectChangeUsingDeepLearning SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
