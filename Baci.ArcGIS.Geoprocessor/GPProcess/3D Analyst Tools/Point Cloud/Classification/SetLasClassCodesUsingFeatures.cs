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
	/// <para>Set LAS Class Codes Using Features</para>
	/// <para>使用要素设置 LAS 类代码</para>
	/// <para>对与输入要素二维范围相交的 LAS 点进行分类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetLasClassCodesUsingFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="FeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>一个或多个输入要素，用于为 LAS 数据集引用的激光雷达文件定义类代码值。 分类标记选项默认设置为没有更改，但是可以通过选择设置进行分配或者通过选择清除进行移除。 每个要素均具有以下选项：</para>
		/// <para>要素 - 用于对 LAS 点进行重新分类的要素。</para>
		/// <para>缓冲距离 - 确定与缓冲区域相交的 LAS 点之前，缓冲输入要素的距离。</para>
		/// <para>新建类 - 要分配的类代码。</para>
		/// <para>合成 -“合成”分类标记可用于识别未从激光雷达传感器获取但包含在 .las 文件中的点，例如激光雷达传感器尚未捕获的测量控制点。</para>
		/// <para>关键点 -“模型关键点”分类标记代表在激光雷达集合中捕获特定细节层次所需的点子集。 过去，此标记与代表特定 z 容差内细化的地面点相关联。</para>
		/// <para>保留 -“保留”分类标记表示应从分析和可视化中排除的错误数据。</para>
		/// <para>重叠 -“重叠”标识可以标识重叠扫描的点，仅在 LAS 1.4 文件中受支持。</para>
		/// </param>
		public SetLasClassCodesUsingFeatures(object InLasDataset, object FeatureClass)
		{
			this.InLasDataset = InLasDataset;
			this.FeatureClass = FeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用要素设置 LAS 类代码</para>
		/// </summary>
		public override string DisplayName() => "使用要素设置 LAS 类代码";

		/// <summary>
		/// <para>Tool Name : SetLasClassCodesUsingFeatures</para>
		/// </summary>
		public override string ToolName() => "SetLasClassCodesUsingFeatures";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SetLasClassCodesUsingFeatures</para>
		/// </summary>
		public override string ExcuteName() => "3d.SetLasClassCodesUsingFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, FeatureClass, ComputeStats, DerivedLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>一个或多个输入要素，用于为 LAS 数据集引用的激光雷达文件定义类代码值。 分类标记选项默认设置为没有更改，但是可以通过选择设置进行分配或者通过选择清除进行移除。 每个要素均具有以下选项：</para>
		/// <para>要素 - 用于对 LAS 点进行重新分类的要素。</para>
		/// <para>缓冲距离 - 确定与缓冲区域相交的 LAS 点之前，缓冲输入要素的距离。</para>
		/// <para>新建类 - 要分配的类代码。</para>
		/// <para>合成 -“合成”分类标记可用于识别未从激光雷达传感器获取但包含在 .las 文件中的点，例如激光雷达传感器尚未捕获的测量控制点。</para>
		/// <para>关键点 -“模型关键点”分类标记代表在激光雷达集合中捕获特定细节层次所需的点子集。 过去，此标记与代表特定 z 容差内细化的地面点相关联。</para>
		/// <para>保留 -“保留”分类标记表示应从分析和可视化中排除的错误数据。</para>
		/// <para>重叠 -“重叠”标识可以标识重叠扫描的点，仅在 LAS 1.4 文件中受支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object FeatureClass { get; set; }

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
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object DerivedLasDataset { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetLasClassCodesUsingFeatures SetEnviroment(object extent = null, object geographicTransformations = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, workspace: workspace);
			return this;
		}

		#region InnerClass

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
