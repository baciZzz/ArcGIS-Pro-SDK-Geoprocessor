using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Find Hot Spots</para>
	/// <para>查找热点</para>
	/// <para>给定一组要素，使用 Getis-Ord Gi* 统计识别具有统计显著性的热点和冷点。</para>
	/// </summary>
	public class FindHotSpots : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>将要执行热点分析的点要素类。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含 z 得分和 p 值结果的输出要素类。</para>
		/// </param>
		public FindHotSpots(object PointLayer, object OutFeatureClass)
		{
			this.PointLayer = PointLayer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找热点</para>
		/// </summary>
		public override string DisplayName() => "查找热点";

		/// <summary>
		/// <para>Tool Name : FindHotSpots</para>
		/// </summary>
		public override string ToolName() => "FindHotSpots";

		/// <summary>
		/// <para>Tool Excute Name : gapro.FindHotSpots</para>
		/// </summary>
		public override string ExcuteName() => "gapro.FindHotSpots";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { PointLayer, OutFeatureClass, BinSize!, NeighborhoodSize!, TimeStepInterval!, TimeStepAlignment!, TimeStepReference! };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>将要执行热点分析的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含 z 得分和 p 值结果的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>表示点图层将聚合到的条柱大小和单位的距离间隔。距离间隔必须为线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? BinSize { get; set; }

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// <para>分析邻域的空间范围。该值用于确定将哪些要素一起用于分析以便访问局部聚类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? NeighborhoodSize { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>将用于时间步长的间隔。 此参数仅在启用了点图层的时间时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>指定时间步长对齐的方式。只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// <para>结束时间—时间步长将与最后一次时间事件对齐，并向后聚合时间。</para>
		/// <para>开始时间—时间步长将与第一次时间事件对齐，并向前聚合时间。这是默认设置。</para>
		/// <para>参考时间—时间步长将与指定日期或时间对齐。如果输入要素中的所有点具有的时间戳大于指定的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为起始时间，并向前聚合时间（与使用起始时间对齐的情况相同）。如果输入要素中的所有点具有的时间戳小于指定的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的情况相同）。如果指定的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeStepAlignment { get; set; } = "START_TIME";

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>将用于对齐时间步长和时间间隔的时间。此参数仅在启用了点图层的时间时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeStepReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindHotSpots SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>开始时间—时间步长将与第一次时间事件对齐，并向前聚合时间。这是默认设置。</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("开始时间")]
			Start_time,

			/// <summary>
			/// <para>结束时间—时间步长将与最后一次时间事件对齐，并向后聚合时间。</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("结束时间")]
			End_time,

			/// <summary>
			/// <para>参考时间—时间步长将与指定日期或时间对齐。如果输入要素中的所有点具有的时间戳大于指定的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为起始时间，并向前聚合时间（与使用起始时间对齐的情况相同）。如果输入要素中的所有点具有的时间戳小于指定的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的情况相同）。如果指定的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("参考时间")]
			Reference_time,

		}

#endregion
	}
}
