using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Visualize Space Time Cube in 3D</para>
	/// <para>以 3D 形式查看时空立方体</para>
	/// <para>显示使用时空模式挖掘工具创建并存储在 netCDF 立方体中的变量。 该工具的输出是根据指定变量和专题进行唯一渲染的三维制图表达。</para>
	/// </summary>
	public class VisualizeSpaceTimeCube3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>netCDF 立方体中包含了要显示的变量。 此文件必须具有 .nc 扩展名，并且必须已使用通过聚合点创建时空立方体或通过已定义位置创建时空立方体工具进行创建。</para>
		/// </param>
		/// <param name="CubeVariable">
		/// <para>Cube Variable</para>
		/// <para>要研究的 netCDF 立方体中的数值变量。 如果在立方体创建中使用聚合，则该时空立方体将始终包含 COUNT 变量。 创建立方体时包含的所有汇总字段或变量也将可用。</para>
		/// </param>
		/// <param name="DisplayTheme">
		/// <para>Display Theme</para>
		/// <para>指定要显示的立方体变量参数的特征。 这些选项会有所不同，具体取决于立方体的创建方式和分析的运行方式。</para>
		/// <para>值—将显示立方体变量参数的数值。</para>
		/// <para>热点和冷点结果—将显示基于运行于新兴时空热点分析中空间时间热点分析的每个条柱的统计显著性。</para>
		/// <para>估算立方图格—将显示具有估计值的立方图格。</para>
		/// <para>聚类和异常值结果—将显示由局部异常值分析确定的每个条柱的聚类或异常值类型 (COType)。</para>
		/// <para>时间聚合计数—将显示聚合到每个时空立方图格中的记录计数。</para>
		/// <para>预测结果—将显示时间序列预测工具中的输入时间步和生成的预测值。</para>
		/// <para>时间序列异常值结果—将显示时间序列预测工具中的异常值选项参数的结果。</para>
		/// <para>值是立方体变量参数的数值，并且始终可用。 估算条柱值仅可用于创建立方体时包含的汇总字段。 热点和冷点结果值仅可用于已运行新兴热点分析的立方体变量参数值。 聚类和异常值结果值仅可用于运行了局部异常值分析的立方体变量。 时间聚合计数值仅适用于已在时间上聚合的已定义位置立方体。 预测结果值仅可用于已运行时间序列预测工具的立方体变量参数值。 仅当在时间序列预测工具集中为工具设置了异常值选项参数时，时间序列异常值结果值才可用。</para>
		/// <para>有关每个选项的详细信息，其中包括输出说明和创建的图表，请参阅时空立方体的可视化显示主题主题。</para>
		/// <para><see cref="DisplayThemeEnum"/></para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类结果。 此要素类为显示变量的三维地图制图表达，可在 3D 场景中显示。</para>
		/// </param>
		public VisualizeSpaceTimeCube3D(object InCube, object CubeVariable, object DisplayTheme, object OutputFeatures)
		{
			this.InCube = InCube;
			this.CubeVariable = CubeVariable;
			this.DisplayTheme = DisplayTheme;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 以 3D 形式查看时空立方体</para>
		/// </summary>
		public override string DisplayName() => "以 3D 形式查看时空立方体";

		/// <summary>
		/// <para>Tool Name : VisualizeSpaceTimeCube3D</para>
		/// </summary>
		public override string ToolName() => "VisualizeSpaceTimeCube3D";

		/// <summary>
		/// <para>Tool Excute Name : stpm.VisualizeSpaceTimeCube3D</para>
		/// </summary>
		public override string ExcuteName() => "stpm.VisualizeSpaceTimeCube3D";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, CubeVariable, DisplayTheme, OutputFeatures };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>netCDF 立方体中包含了要显示的变量。 此文件必须具有 .nc 扩展名，并且必须已使用通过聚合点创建时空立方体或通过已定义位置创建时空立方体工具进行创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Cube Variable</para>
		/// <para>要研究的 netCDF 立方体中的数值变量。 如果在立方体创建中使用聚合，则该时空立方体将始终包含 COUNT 变量。 创建立方体时包含的所有汇总字段或变量也将可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CubeVariable { get; set; }

		/// <summary>
		/// <para>Display Theme</para>
		/// <para>指定要显示的立方体变量参数的特征。 这些选项会有所不同，具体取决于立方体的创建方式和分析的运行方式。</para>
		/// <para>值—将显示立方体变量参数的数值。</para>
		/// <para>热点和冷点结果—将显示基于运行于新兴时空热点分析中空间时间热点分析的每个条柱的统计显著性。</para>
		/// <para>估算立方图格—将显示具有估计值的立方图格。</para>
		/// <para>聚类和异常值结果—将显示由局部异常值分析确定的每个条柱的聚类或异常值类型 (COType)。</para>
		/// <para>时间聚合计数—将显示聚合到每个时空立方图格中的记录计数。</para>
		/// <para>预测结果—将显示时间序列预测工具中的输入时间步和生成的预测值。</para>
		/// <para>时间序列异常值结果—将显示时间序列预测工具中的异常值选项参数的结果。</para>
		/// <para>值是立方体变量参数的数值，并且始终可用。 估算条柱值仅可用于创建立方体时包含的汇总字段。 热点和冷点结果值仅可用于已运行新兴热点分析的立方体变量参数值。 聚类和异常值结果值仅可用于运行了局部异常值分析的立方体变量。 时间聚合计数值仅适用于已在时间上聚合的已定义位置立方体。 预测结果值仅可用于已运行时间序列预测工具的立方体变量参数值。 仅当在时间序列预测工具集中为工具设置了异常值选项参数时，时间序列异常值结果值才可用。</para>
		/// <para>有关每个选项的详细信息，其中包括输出说明和创建的图表，请参阅时空立方体的可视化显示主题主题。</para>
		/// <para><see cref="DisplayThemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DisplayTheme { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类结果。 此要素类为显示变量的三维地图制图表达，可在 3D 场景中显示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public VisualizeSpaceTimeCube3D SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Display Theme</para>
		/// </summary>
		public enum DisplayThemeEnum 
		{
			/// <summary>
			/// <para>值—将显示立方体变量参数的数值。</para>
			/// </summary>
			[GPValue("VALUE")]
			[Description("值")]
			Value,

			/// <summary>
			/// <para>热点和冷点结果—将显示基于运行于新兴时空热点分析中空间时间热点分析的每个条柱的统计显著性。</para>
			/// </summary>
			[GPValue("HOT_AND_COLD_SPOT_RESULTS")]
			[Description("热点和冷点结果")]
			Hot_and_cold_spot_results,

			/// <summary>
			/// <para>聚类和异常值结果—将显示由局部异常值分析确定的每个条柱的聚类或异常值类型 (COType)。</para>
			/// </summary>
			[GPValue("LOCAL_OUTLIER_RESULTS")]
			[Description("聚类和异常值结果")]
			Cluster_and_outlier_results,

			/// <summary>
			/// <para>估算立方图格—将显示具有估计值的立方图格。</para>
			/// </summary>
			[GPValue("ESTIMATED_BINS")]
			[Description("估算立方图格")]
			Estimated_bins,

			/// <summary>
			/// <para>时间聚合计数—将显示聚合到每个时空立方图格中的记录计数。</para>
			/// </summary>
			[GPValue("TEMPORAL_AGGREGATION_COUNT")]
			[Description("时间聚合计数")]
			Temporal_aggregation_count,

			/// <summary>
			/// <para>预测结果—将显示时间序列预测工具中的输入时间步和生成的预测值。</para>
			/// </summary>
			[GPValue("FORECAST_RESULTS")]
			[Description("预测结果")]
			Forecast_results,

			/// <summary>
			/// <para>时间序列异常值结果—将显示时间序列预测工具中的异常值选项参数的结果。</para>
			/// </summary>
			[GPValue("TIME_SERIES_OUTLIER_RESULTS")]
			[Description("时间序列异常值结果")]
			Time_series_outlier_results,

		}

#endregion
	}
}
