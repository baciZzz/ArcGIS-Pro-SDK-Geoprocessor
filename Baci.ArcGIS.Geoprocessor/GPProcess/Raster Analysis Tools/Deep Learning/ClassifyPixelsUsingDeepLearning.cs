using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Classify Pixels Using Deep Learning</para>
	/// <para>使用深度学习分类像素</para>
	/// <para>用于运行输入图像上的训练深度学习模型，以生成分类栅格，并作为托管影像图层发布到门户中。</para>
	/// </summary>
	public class ClassifyPixelsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>待分类的输入影像。 它可以是影像服务 URL、栅格图层、影像服务、地图服务器图层或 Internet 切片图层。</para>
		/// </param>
		/// <param name="Inputmodel">
		/// <para>Input Model</para>
		/// <para>输入是深度学习包 (.dlpk) 项目的 URL。 其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>分类像素的影像服务的名称。</para>
		/// </param>
		public ClassifyPixelsUsingDeepLearning(object Inputraster, object Inputmodel, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmodel = Inputmodel;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.ClassifyPixelsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ra.ClassifyPixelsUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputraster, Inputmodel, Outputname, Modelarguments!, Outraster!, Processingmode! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待分类的输入影像。 它可以是影像服务 URL、栅格图层、影像服务、地图服务器图层或 Internet 切片图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Model</para>
		/// <para>输入是深度学习包 (.dlpk) 项目的 URL。 其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("", "dlpk_remote")]
		public object Inputmodel { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>分类像素的影像服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>函数参数在输入模型引用的 Python 栅格函数类中定义。 您可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于调整灵敏度的置信度阈值。 参数名称将由工具通过读取 RA 服务器上的 Python 模块进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Modelarguments { get; set; }

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outraster { get; set; }

		/// <summary>
		/// <para>Processing Mode</para>
		/// <para>指定处理镶嵌数据集或影像服务中的所有栅格项目的方式。 当输入栅格是镶嵌数据集或影像服务时，将应用此参数。</para>
		/// <para>以镶嵌影像方式处理—将镶嵌在一起并处理镶嵌数据集或影像服务中的所有栅格项目。 这是默认设置。</para>
		/// <para>单独处理所有栅格项目—将作为独立影像处理镶嵌数据集或影像服务中的所有栅格项目。</para>
		/// <para><see cref="ProcessingmodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Processingmode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyPixelsUsingDeepLearning SetEnviroment(object? cellSize = null , object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? processorType = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Processing Mode</para>
		/// </summary>
		public enum ProcessingmodeEnum 
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
