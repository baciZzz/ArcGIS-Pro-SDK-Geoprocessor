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
	/// <para>Average Nearest Neighbor</para>
	/// <para>平均最近邻</para>
	/// <para>根据每个要素与其最近邻要素之间的平均距离计算其最近邻指数。</para>
	/// </summary>
	public class AverageNearestNeighbor : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>要对平均最近邻距离进行计算的要素类（通常是点要素类）。</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		public AverageNearestNeighbor(object InputFeatureClass, object DistanceMethod)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.DistanceMethod = DistanceMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 平均最近邻</para>
		/// </summary>
		public override string DisplayName() => "平均最近邻";

		/// <summary>
		/// <para>Tool Name : AverageNearestNeighbor</para>
		/// </summary>
		public override string ToolName() => "AverageNearestNeighbor";

		/// <summary>
		/// <para>Tool Excute Name : stats.AverageNearestNeighbor</para>
		/// </summary>
		public override string ExcuteName() => "stats.AverageNearestNeighbor";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, DistanceMethod, GenerateReport, Area, Nnratio, Nnzscore, Pvalue, Nnexpected, Nnobserved, ReportFile };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>要对平均最近邻距离进行计算的要素类（通常是点要素类）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

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
		/// <para>Generate Report</para>
		/// <para>指定工具是否将创建结果的图形汇总。</para>
		/// <para>选中 - 图形汇总将以 HTML 文件形式创建。</para>
		/// <para>未选中 - 不会创建图形汇总。这是默认设置。</para>
		/// <para><see cref="GenerateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateReport { get; set; } = "false";

		/// <summary>
		/// <para>Area</para>
		/// <para>表示研究区域大小的数值。默认值是包含所有要素（或所有选定要素）的最小外接矩形的面积。单位应与“输出坐标系”的单位一致。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999999999)]
		public object Area { get; set; }

		/// <summary>
		/// <para>Nearest Neighbor Index</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnratio { get; set; } = "0";

		/// <summary>
		/// <para>z-score</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnzscore { get; set; } = "0";

		/// <summary>
		/// <para>p-value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Pvalue { get; set; } = "0";

		/// <summary>
		/// <para>Expected Mean Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnexpected { get; set; } = "0";

		/// <summary>
		/// <para>Observed Mean Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnobserved { get; set; } = "0";

		/// <summary>
		/// <para>Report File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object ReportFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AverageNearestNeighbor SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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

		/// <summary>
		/// <para>Generate Report</para>
		/// </summary>
		public enum GenerateReportEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_REPORT")]
			GENERATE_REPORT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REPORT")]
			NO_REPORT,

		}

#endregion
	}
}
