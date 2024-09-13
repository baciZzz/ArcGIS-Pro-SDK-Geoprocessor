using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Calculate Distance Band from Neighbor Count</para>
	/// <para>计算近邻点距离</para>
	/// <para>返回一组要素与指定的第 N 个最邻近点（N 为输入参数）的最小、最大和平均距离。结果以工具执行消息的形式写入。</para>
	/// </summary>
	public class CalculateDistanceBand : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>用于计算距离统计值的要素类或图层。</para>
		/// </param>
		/// <param name="Neighbors">
		/// <para>Neighbors</para>
		/// <para>将要考虑的各要素的相邻点数目 (N)。此数目应为介于 1 和要素类中的要素总数之间的任意整数。各要素与其第 N 个相邻点之间的距离的列表将被编译，并且最大、最小和平均距离将被输出到“结果”窗口。</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		public CalculateDistanceBand(object InputFeatures, object Neighbors, object DistanceMethod)
		{
			this.InputFeatures = InputFeatures;
			this.Neighbors = Neighbors;
			this.DistanceMethod = DistanceMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算近邻点距离</para>
		/// </summary>
		public override string DisplayName() => "计算近邻点距离";

		/// <summary>
		/// <para>Tool Name : CalculateDistanceBand</para>
		/// </summary>
		public override string ToolName() => "CalculateDistanceBand";

		/// <summary>
		/// <para>Tool Excute Name : stats.CalculateDistanceBand</para>
		/// </summary>
		public override string ExcuteName() => "stats.CalculateDistanceBand";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, Neighbors, DistanceMethod, MinimumDistance, AverageDistance, MaximumDistance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于计算距离统计值的要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Neighbors</para>
		/// <para>将要考虑的各要素的相邻点数目 (N)。此数目应为介于 1 和要素类中的要素总数之间的任意整数。各要素与其第 N 个相邻点之间的距离的列表将被编译，并且最大、最小和平均距离将被输出到“结果”窗口。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 9999)]
		public object Neighbors { get; set; } = "1";

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Minimum Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MinimumDistance { get; set; }

		/// <summary>
		/// <para>Average Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object AverageDistance { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDistanceBand SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>欧氏—两点间的直线距离</para>
			/// </summary>
			[GPValue("EUCLIDEAN_DISTANCE")]
			[Description("欧氏")]
			Euclidean,

			/// <summary>
			/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
			/// </summary>
			[GPValue("MANHATTAN_DISTANCE")]
			[Description("曼哈顿")]
			Manhattan,

		}

#endregion
	}
}
