using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Register Raster</para>
	/// <para>注册栅格</para>
	/// <para>自动对齐栅格与参考影像，或者使用控制点文件进行地理注册。 如果输入数据集为镶嵌数据集，此工具将应用于每个镶嵌数据集项。 要自动注册图像，输入栅格和参考栅格必须位于相对较近的地理区域内。 栅格数据集越接近对齐，该工具运行得更快。 您可能需要创建一个包含若干链接的链接文件（即控制点文件），才能将输入栅格置于同一地图空间内。</para>
	/// </summary>
	public class RegisterRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要重新对齐的栅格。 注册镶嵌数据集项目会更新该镶嵌数据集中的特定项目。</para>
		/// <para>镶嵌数据集项目的路径将为镶嵌数据集路径，后跟该项目的对象 ID。 例如，镶嵌数据集中第一个项目的路径将如下所示：.\mosaicDataset\objectid=1。</para>
		/// </param>
		/// <param name="RegisterMode">
		/// <para>Register Mode</para>
		/// <para>指定注册模式。 既可以注册含变换的栅格，也可以重置变换。</para>
		/// <para>注册—将几何变换应用到输入栅格。</para>
		/// <para>注册多光谱—将多光谱输入注册到全色输入。 这仅适用于在两者之间具有偏差的镶嵌数据集。</para>
		/// <para>重置—移除此工具之前添加的几何变换。</para>
		/// <para>创建链接—使用自动生成的链接创建链接文件。</para>
		/// <para><see cref="RegisterModeEnum"/></para>
		/// </param>
		public RegisterRaster(object InRaster, object RegisterMode)
		{
			this.InRaster = InRaster;
			this.RegisterMode = RegisterMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 注册栅格</para>
		/// </summary>
		public override string DisplayName() => "注册栅格";

		/// <summary>
		/// <para>Tool Name : RegisterRaster</para>
		/// </summary>
		public override string ToolName() => "RegisterRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.RegisterRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.RegisterRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, RegisterMode, ReferenceRaster!, InputLinkFile!, TransformationType!, OutputCptLinkFile!, MaximumRmsValue!, OutRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要重新对齐的栅格。 注册镶嵌数据集项目会更新该镶嵌数据集中的特定项目。</para>
		/// <para>镶嵌数据集项目的路径将为镶嵌数据集路径，后跟该项目的对象 ID。 例如，镶嵌数据集中第一个项目的路径将如下所示：.\mosaicDataset\objectid=1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Register Mode</para>
		/// <para>指定注册模式。 既可以注册含变换的栅格，也可以重置变换。</para>
		/// <para>注册—将几何变换应用到输入栅格。</para>
		/// <para>注册多光谱—将多光谱输入注册到全色输入。 这仅适用于在两者之间具有偏差的镶嵌数据集。</para>
		/// <para>重置—移除此工具之前添加的几何变换。</para>
		/// <para>创建链接—使用自动生成的链接创建链接文件。</para>
		/// <para><see cref="RegisterModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RegisterMode { get; set; } = "REGISTER";

		/// <summary>
		/// <para>Reference Raster</para>
		/// <para>将对齐输入栅格数据集的栅格数据集。 如果要将多光谱镶嵌数据集项目注册到与之关联的全色栅格数据集，请将此参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceRaster { get; set; }

		/// <summary>
		/// <para>Input Link File</para>
		/// <para>具有将输入栅格数据集与参考进行链接的坐标的文件。 输入链接表可处理镶嵌图层中的单个镶嵌项目。 输入必须指定要处理的项目，指定方式为：选择项目或在输入中指定 ObjectID。 要将多光谱镶嵌数据集项目注册到关联的全色栅格数据集，请将此参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InputLinkFile { get; set; }

		/// <summary>
		/// <para>Transformation Type</para>
		/// <para>指定平移栅格数据集的方法。</para>
		/// <para>仅平移—此方法使用零阶多项式平移数据。 当数据已进行地理配准但通过微小的平移可以更好的排列数据时，通常使用该多项式。 执行零阶多项式平移只需要一个连接线。</para>
		/// <para>相似变换—此变换为尝试保存原始栅格形状的一阶变换。 RMS 错误会高于其他多项式变换，因为保存形状比最佳大小更重要。</para>
		/// <para>仿射变换—一阶多项式（仿射）将输入点拟合为平面。</para>
		/// <para>二阶多项式变换—二阶多项式将输入点拟合为稍微复杂一些的曲面。</para>
		/// <para>三阶多项式变换—三阶多项式将输入点拟合为更为复杂的曲面。</para>
		/// <para>校正变换—此方法结合多项式变换并使用不规则三角网 (TIN) 插值法对全局和局部精度进行优化。</para>
		/// <para>样条函数变换—此方法将源控制点准确地变换为目标控制点。 在输出中，控制点是准确的，只是控制点之间的栅格像素则不准确。</para>
		/// <para>投影变换—此方法将扭曲线以使其保持平直。 进行变换时，之前平行的线可能不再保持平行。 投影变换尤其适用于倾斜的影像、扫描的地图和一些影像产品。</para>
		/// <para>框架变换—该方法将针对航空影像使用影像切除算法。 影像切除算法可使用最小二乘拟合算法从已知的地面控制点优化影像的外部方向（透视、omega、phi 和 kappa）。 每个影像必须具有至少三个非共线点。 一旦输入为镶嵌数据集，它将一次注册一个所选影像。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Output Link File</para>
		/// <para>如果已指定，则会写入包含由此工具创建的链接的文本文件。 该文件可用于从文件扭曲工具。 输出链接表可处理镶嵌图层中的单个镶嵌数据集项目。 输入必须指定要处理的项目，指定方式为：选择项目或在输入中指定 ObjectID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETextFile()]
		public object? OutputCptLinkFile { get; set; }

		/// <summary>
		/// <para>Maximum RMS</para>
		/// <para>您希望在输出中所包含的建模错误数量（以像素为单位）。 默认值为 0.5，由于低于 0.3 的值会导致过度拟合，因此不建议使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumRmsValue { get; set; }

		/// <summary>
		/// <para>Registered Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegisterRaster SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Register Mode</para>
		/// </summary>
		public enum RegisterModeEnum 
		{
			/// <summary>
			/// <para>注册—将几何变换应用到输入栅格。</para>
			/// </summary>
			[GPValue("REGISTER")]
			[Description("注册")]
			Register,

			/// <summary>
			/// <para>注册多光谱—将多光谱输入注册到全色输入。 这仅适用于在两者之间具有偏差的镶嵌数据集。</para>
			/// </summary>
			[GPValue("REGISTER_MS")]
			[Description("注册多光谱")]
			Register_multispectral,

			/// <summary>
			/// <para>重置—移除此工具之前添加的几何变换。</para>
			/// </summary>
			[GPValue("RESET")]
			[Description("重置")]
			Reset,

			/// <summary>
			/// <para>创建链接—使用自动生成的链接创建链接文件。</para>
			/// </summary>
			[GPValue("CREATE_LINKS")]
			[Description("创建链接")]
			Create_links,

		}

		/// <summary>
		/// <para>Transformation Type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>仅平移—此方法使用零阶多项式平移数据。 当数据已进行地理配准但通过微小的平移可以更好的排列数据时，通常使用该多项式。 执行零阶多项式平移只需要一个连接线。</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("仅平移")]
			Shift_only,

			/// <summary>
			/// <para>相似变换—此变换为尝试保存原始栅格形状的一阶变换。 RMS 错误会高于其他多项式变换，因为保存形状比最佳大小更重要。</para>
			/// </summary>
			[GPValue("POLYSIMILARITY")]
			[Description("相似变换")]
			Similarity_transformation,

			/// <summary>
			/// <para>仿射变换—一阶多项式（仿射）将输入点拟合为平面。</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("仿射变换")]
			Affine_transformation,

			/// <summary>
			/// <para>二阶多项式变换—二阶多项式将输入点拟合为稍微复杂一些的曲面。</para>
			/// </summary>
			[GPValue("POLYORDER2")]
			[Description("二阶多项式变换")]
			POLYORDER2,

			/// <summary>
			/// <para>三阶多项式变换—三阶多项式将输入点拟合为更为复杂的曲面。</para>
			/// </summary>
			[GPValue("POLYORDER3")]
			[Description("三阶多项式变换")]
			POLYORDER3,

			/// <summary>
			/// <para>投影变换—此方法将扭曲线以使其保持平直。 进行变换时，之前平行的线可能不再保持平行。 投影变换尤其适用于倾斜的影像、扫描的地图和一些影像产品。</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("投影变换")]
			Projective_transformation,

			/// <summary>
			/// <para>样条函数变换—此方法将源控制点准确地变换为目标控制点。 在输出中，控制点是准确的，只是控制点之间的栅格像素则不准确。</para>
			/// </summary>
			[GPValue("SPLINE")]
			[Description("样条函数变换")]
			Spline_transformation,

			/// <summary>
			/// <para>校正变换—此方法结合多项式变换并使用不规则三角网 (TIN) 插值法对全局和局部精度进行优化。</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("校正变换")]
			Adjust_transformation,

			/// <summary>
			/// <para>框架变换—该方法将针对航空影像使用影像切除算法。 影像切除算法可使用最小二乘拟合算法从已知的地面控制点优化影像的外部方向（透视、omega、phi 和 kappa）。 每个影像必须具有至少三个非共线点。 一旦输入为镶嵌数据集，它将一次注册一个所选影像。</para>
			/// </summary>
			[GPValue("FRAME")]
			[Description("框架变换")]
			Frame_transformation,

		}

#endregion
	}
}
