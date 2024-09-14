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
	/// <para>Classify Objects Using Deep Learning</para>
	/// <para>使用深度学习分类对象</para>
	/// <para>用于运行输入栅格和可选要素类上的训练深度学习模型，以生成要素类或表，其中每个输入对象或要素均具有一个分配的类或类别标注。</para>
	/// </summary>
	public class ClassifyObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>待分类的输入影像。 该影像可以是影像服务 URL、栅格图层、影像服务、地图服务器图层或 Internet 切片图层。</para>
		/// </param>
		/// <param name="Inputmodel">
		/// <para>Input Model</para>
		/// <para>深度学习模型用于对输入影像中的对象进行分类。 输入是深度学习包 (.dlpk) 项目的 URL，其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>包含已分类对象的要素服务的名称。</para>
		/// </param>
		public ClassifyObjectsUsingDeepLearning(object Inputraster, object Inputmodel, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmodel = Inputmodel;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ra.ClassifyObjectsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "parallelProcessingFactor", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputraster, Inputmodel, Outputname, Inputfeatures!, Modelarguments!, Classlabelfield!, Processingmode!, Outobjects! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待分类的输入影像。 该影像可以是影像服务 URL、栅格图层、影像服务、地图服务器图层或 Internet 切片图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Model</para>
		/// <para>深度学习模型用于对输入影像中的对象进行分类。 输入是深度学习包 (.dlpk) 项目的 URL，其中包含深度学习二进制模型文件的路径、待使用的 Python 栅格函数的路径以及其他参数，例如首选切片大小或填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("", "dlpk_remote")]
		public object Inputmodel { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>包含已分类对象的要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于标识要分类或要标注的每个对象或要素位置的要素服务。 输入要素服务中的每一行表示一个对象或要素。</para>
		/// <para>如果未指定输入要素服务，则每个输入影像将被分类为单个对象。 如果一个或多个输入影像使用空间参考，则工具的输出为要素类，其中每个影像的范围将用作每个标注要素类的边界几何。 如果一个或多个输入影像没有使用空间参考，则工具的输出为包含影像 ID 值和每个影像类标注的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? Inputfeatures { get; set; }

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>用于分类的函数模型参数。 函数参数在输入模型引用的 Python 栅格函数类中定义。 您可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于调整灵敏度的置信度阈值。 参数名称将由栅格分析服务器上的 Python 模块中的工具进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Modelarguments { get; set; }

		/// <summary>
		/// <para>Class Label Field</para>
		/// <para>包含输出要素类中类或类别标注的字段名称。</para>
		/// <para>如果未指定字段名称，则会在输出要素类中生成一个名为 ClassLabel 的新字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Classlabelfield { get; set; } = "ClassLabel";

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
		/// <para>Output Objects</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? Outobjects { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyObjectsUsingDeepLearning SetEnviroment(object? cellSize = null, object? extent = null, object? parallelProcessingFactor = null, object? processorType = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType);
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
