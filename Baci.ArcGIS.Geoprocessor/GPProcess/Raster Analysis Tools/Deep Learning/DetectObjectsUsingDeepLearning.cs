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
	/// <para>Detect Objects Using Deep Learning</para>
	/// <para>使用深度学习检测对象</para>
	/// <para>用于运行输入栅格上的训练深度学习模型，以生成包含其识别对象的要素类。 此要素类可作为托管要素图层在门户中共享。 这些要素可以是所找到对象周围的边界框或面，也可以是对象中心的点。</para>
	/// </summary>
	public class DetectObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>用于检测对象的输入图像。 它可以是影像服务 URL、栅格图层、影像服务、地图服务器图层或 Internet 切片图层。</para>
		/// </param>
		/// <param name="Inputmodel">
		/// <para>Input Model</para>
		/// <para>输入模型可以是文件或者来自门户的深度学习包 (.dlpk) 项目的 URL。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>检测对象的输出要素服务的名称。</para>
		/// </param>
		public DetectObjectsUsingDeepLearning(object Inputraster, object Inputmodel, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmodel = Inputmodel;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.DetectObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ra.DetectObjectsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "outputCoordinateSystem", "parallelProcessingFactor", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputraster, Inputmodel, Outputname, Modelarguments!, Runnms!, Confidencescorefield!, Classvaluefield!, Maxoverlapratio!, Outobjects!, Processingmode! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>用于检测对象的输入图像。 它可以是影像服务 URL、栅格图层、影像服务、地图服务器图层或 Internet 切片图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Model</para>
		/// <para>输入模型可以是文件或者来自门户的深度学习包 (.dlpk) 项目的 URL。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("", "dlpk_remote")]
		public object Inputmodel { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>检测对象的输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>函数模型参数在输入模型引用的 Python 栅格函数类中定义。 您可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于优化灵敏度的置信度阈值。 参数名称将由工具通过读取 RA 服务器上的 Python 模块进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Modelarguments { get; set; }

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// <para>指定是否执行可用于标识重复对象和移除置信值较低的重复要素的非极大值抑制。</para>
		/// <para>未选中 - 所有检测到的对象都将位于输出要素类中。 这是默认设置。</para>
		/// <para>选中 - 将移除重复检测到的对象。</para>
		/// <para><see cref="RunnmsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Runnms { get; set; } = "false";

		/// <summary>
		/// <para>Confidence Score Field</para>
		/// <para>要素服务中的字段，该字段包含将由对象检测方法用作输出的置信度得分。</para>
		/// <para>当选中了非极大值抑制参数时需要用到 该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Confidencescorefield { get; set; } = "Confidence";

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>要素服务中类值字段的名称。</para>
		/// <para>如果未指定字段名称，则 Classvalue 或 Value 字段将被使用。 如果这些字段不存在，则会将所有记录标识为属于一个类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Classvaluefield { get; set; } = "Class";

		/// <summary>
		/// <para>Max Overlap Ratio</para>
		/// <para>两个重叠要素的最大重叠比，其定义为交集区域与并集区域之比。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Maxoverlapratio { get; set; } = "0";

		/// <summary>
		/// <para>Out Objects</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? Outobjects { get; set; }

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
		public DetectObjectsUsingDeepLearning SetEnviroment(object? cellSize = null , object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? processorType = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// </summary>
		public enum RunnmsEnum 
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
