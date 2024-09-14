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
	/// <para>Raster To Multipoint</para>
	/// <para>栅格转多点</para>
	/// <para>将栅格像元中心转换为 3D 多点要素（其 Z 值反映栅格像元值）。</para>
	/// </summary>
	public class RasterToMultipoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待处理的栅格。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public RasterToMultipoint(object InRaster, object OutFeatureClass)
		{
			this.InRaster = InRaster;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转多点</para>
		/// </summary>
		public override string DisplayName() => "栅格转多点";

		/// <summary>
		/// <para>Tool Name : RasterToMultipoint</para>
		/// </summary>
		public override string ToolName() => "RasterToMultipoint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RasterToMultipoint</para>
		/// </summary>
		public override string ExcuteName() => "3d.RasterToMultipoint";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFeatureClass, OutVipTable, Method, KernelMethod, ZFactor, ThinningValue };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待处理的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output VIP table</para>
		/// <para>为方法参数指定 VIP 直方图时要生成的直方图表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutVipTable { get; set; }

		/// <summary>
		/// <para>Thinning Method</para>
		/// <para>应用于输入栅格的细化方法，用于选择要导出至多点要素类的像元的子集。</para>
		/// <para>无细化—不应用细化。这是默认设置。</para>
		/// <para>Z 容差—仅导出维护输入栅格指定 Z 范围内的表面所需的像元。</para>
		/// <para>核—基于指定细化值将栅格分割成大小相等的分块，然后选择一个或两个符合指定核方法所定义条件的像元。</para>
		/// <para>VIP—采用创建三维最佳拟合平面所使用的 3 像元 × 3 像元的移动窗口。每个像元都基于其与此平面的绝对差获得一个显著性得分。随后，这些得分的直方图将用于根据细化值参数中指定的百分比数确定要导出的像元。</para>
		/// <para>VIP 直方图—创建表格来查看实际显著值和与这些值关联的相应点数。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "NO_THIN";

		/// <summary>
		/// <para>Kernel Method</para>
		/// <para>对输入栅格应用核细化时在每个核邻域中使用的选择方法。</para>
		/// <para>最小值—在像元处（此像元具有在核邻域中找到的最小高程值）创建一个点。这是默认设置。</para>
		/// <para>最大值—在像元处（此像元具有在核邻域中找到的最大高程值）创建一个点。</para>
		/// <para>最小值和最大值—在像元处（分别具有在核邻域中找到的最小和最大 Z 值）创建两个点。</para>
		/// <para>最接近平均值—在像元处（其高程值最接近核邻域中像元的平均值）创建一个点。</para>
		/// <para><see cref="KernelMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelMethod { get; set; } = "MIN";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Thinning Value</para>
		/// <para>此值的含义取决于指定的细化方法。</para>
		/// <para>Z 容差 - 输入栅格与通过输出多点要素类创建的表面之间所允许的最大差异（z 单位）。选择此方法时，细化值默认为输入栅格 z 范围的 1/10。</para>
		/// <para>核 - 每个分块边缘的栅格像元数。该值默认为 3，即栅格将被分割为 3 像元 × 3 像元的窗口。</para>
		/// <para>VIP - 显著性得分直方图的百分比数等级。此值默认为 5.0，表示将导出得分在直方图中排在前 5% 的像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ThinningValue { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToMultipoint SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Thinning Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Z 容差—仅导出维护输入栅格指定 Z 范围内的表面所需的像元。</para>
			/// </summary>
			[GPValue("ZTOLERANCE")]
			[Description("Z 容差")]
			Z_Tolerance,

			/// <summary>
			/// <para>核—基于指定细化值将栅格分割成大小相等的分块，然后选择一个或两个符合指定核方法所定义条件的像元。</para>
			/// </summary>
			[GPValue("KERNEL")]
			[Description("核")]
			Kernel,

			/// <summary>
			/// <para>VIP 直方图—创建表格来查看实际显著值和与这些值关联的相应点数。</para>
			/// </summary>
			[GPValue("VIP_HISTOGRAM")]
			[Description("VIP 直方图")]
			VIP_Histogram,

			/// <summary>
			/// <para>VIP—采用创建三维最佳拟合平面所使用的 3 像元 × 3 像元的移动窗口。每个像元都基于其与此平面的绝对差获得一个显著性得分。随后，这些得分的直方图将用于根据细化值参数中指定的百分比数确定要导出的像元。</para>
			/// </summary>
			[GPValue("VIP")]
			[Description("VIP")]
			VIP,

			/// <summary>
			/// <para>无细化—不应用细化。这是默认设置。</para>
			/// </summary>
			[GPValue("NO_THIN")]
			[Description("无细化")]
			No_Thinning,

		}

		/// <summary>
		/// <para>Kernel Method</para>
		/// </summary>
		public enum KernelMethodEnum 
		{
			/// <summary>
			/// <para>最小值—在像元处（此像元具有在核邻域中找到的最小高程值）创建一个点。这是默认设置。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—在像元处（此像元具有在核邻域中找到的最大高程值）创建一个点。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>最小值和最大值—在像元处（分别具有在核邻域中找到的最小和最大 Z 值）创建两个点。</para>
			/// </summary>
			[GPValue("MINMAX")]
			[Description("最小值和最大值")]
			Minimum_and_Maximum,

			/// <summary>
			/// <para>最接近平均值—在像元处（其高程值最接近核邻域中像元的平均值）创建一个点。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("最接近平均值")]
			Closest_to_Mean,

		}

#endregion
	}
}
