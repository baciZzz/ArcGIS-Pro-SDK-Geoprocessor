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
	/// <para>Visualize Space Time Cube in 2D</para>
	/// <para>在 2D 模式下显示时空立方体</para>
	/// <para>显示存储在 netCDF 立方体中的变量和时空模式挖掘工具生成的结果。 该工具的输出是根据指定的变量和专题进行唯一渲染的二维制图表达。</para>
	/// </summary>
	public class VisualizeSpaceTimeCube2D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>netCDF 立方体中包含了要显示的变量。 此文件必须具有 .nc 扩展名，并且必须使用通过聚合点创建时空立方体、通过已定义位置创建时空立方体或通过多维栅格图层创建时空立方体工具进行创建。</para>
		/// </param>
		/// <param name="CubeVariable">
		/// <para>Cube Variable</para>
		/// <para>要研究的 netCDF 立方体中的数值变量。 时空立方体始终包含 COUNT 变量。 创建立方体时包含的所有汇总字段或变量值也将可用。</para>
		/// </param>
		/// <param name="DisplayTheme">
		/// <para>Display Theme</para>
		/// <para>指定要显示的立方体变量值的特征。 这些选项会有所不同，具体取决于立方体的创建方式和分析的运行方式。</para>
		/// <para>如果立方体是通过聚合点创建的，则带有数据的位置和趋势将始终可用。 估算的立方图格数量和从分析中排除的位置选项仅适用于在立方体创建过程中包含的汇总字段。</para>
		/// <para>如果立方体是通过定义的位置创建的，则趋势选项将适用于在立方体创建过程中包含的汇总字段或变量。</para>
		/// <para>热点和冷点趋势与新兴时空热点分析结果选项仅在针对所选立方体变量运行新兴时空热点分析后才可使用。 仅当运行了局部异常值分析工具后，局部异常值百分比、最近时间段内的局部异常值、局部异常值分析结果和无空间邻域的位置选项才可用。</para>
		/// <para>预测结果选项仅适用于由时间序列预测工具集中的工具创建的立方体。 仅当指定了时间序列预测工具中的异常值选项参数时，时间序列异常值结果选项才可用。</para>
		/// <para>有关每个选项的详细信息，其中包括输出说明和创建的图表，请参阅时空立方体的可视化显示主题主题。</para>
		/// <para>带有数据的位置—将显示所有包含立方体变量参数数据的位置。</para>
		/// <para>趋势—将显示使用 Mann-Kendall 统计确定的每个位置的值趋势。</para>
		/// <para>热点和冷点趋势—将显示使用 Mann-Kendall 统计确定的每个位置的 z 得分趋势。</para>
		/// <para>新兴时空热点分析结果—将显示指定立方体变量参数的新兴时空热点分析的结果工具的结果。</para>
		/// <para>本地异常值分析结果—将显示指定立方体变量参数的局部异常值分析工具的结果。</para>
		/// <para>局部异常值百分比—将显示每个位置的总异常值百分比。</para>
		/// <para>最近时间段内的局部异常值—将显示最近时间段内发生的异常值。</para>
		/// <para>时间序列聚类结果—将显示指定立方体变量参数的时间序列聚类工具的结果。</para>
		/// <para>无空间邻域的位置—对于最后一次分析运行，将显示无空间邻域的位置。 这些位置仅依赖时间邻域进行分析。</para>
		/// <para>估算的立方图格数量—将显示为每个位置估算的立方图格数量</para>
		/// <para>从分析中排除的位置—将显示因含有不符合估算条件的空立方图格而从分析中排除的位置。</para>
		/// <para>预测结果—将显示指定分析变量参数所使用的时间序列预测工具的结果。</para>
		/// <para>时间序列异常值结果—将显示时间序列预测工具中的异常值选项参数的结果。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类结果。 此要素类为指定显示变量的二维地图制图表达。</para>
		/// </param>
		public VisualizeSpaceTimeCube2D(object InCube, object CubeVariable, object DisplayTheme, object OutputFeatures)
		{
			this.InCube = InCube;
			this.CubeVariable = CubeVariable;
			this.DisplayTheme = DisplayTheme;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 在 2D 模式下显示时空立方体</para>
		/// </summary>
		public override string DisplayName() => "在 2D 模式下显示时空立方体";

		/// <summary>
		/// <para>Tool Name : VisualizeSpaceTimeCube2D</para>
		/// </summary>
		public override string ToolName() => "VisualizeSpaceTimeCube2D";

		/// <summary>
		/// <para>Tool Excute Name : stpm.VisualizeSpaceTimeCube2D</para>
		/// </summary>
		public override string ExcuteName() => "stpm.VisualizeSpaceTimeCube2D";

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
		public override object[] Parameters() => new object[] { InCube, CubeVariable, DisplayTheme, OutputFeatures, EnableTimeSeriesPopups };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>netCDF 立方体中包含了要显示的变量。 此文件必须具有 .nc 扩展名，并且必须使用通过聚合点创建时空立方体、通过已定义位置创建时空立方体或通过多维栅格图层创建时空立方体工具进行创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Cube Variable</para>
		/// <para>要研究的 netCDF 立方体中的数值变量。 时空立方体始终包含 COUNT 变量。 创建立方体时包含的所有汇总字段或变量值也将可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CubeVariable { get; set; }

		/// <summary>
		/// <para>Display Theme</para>
		/// <para>指定要显示的立方体变量值的特征。 这些选项会有所不同，具体取决于立方体的创建方式和分析的运行方式。</para>
		/// <para>如果立方体是通过聚合点创建的，则带有数据的位置和趋势将始终可用。 估算的立方图格数量和从分析中排除的位置选项仅适用于在立方体创建过程中包含的汇总字段。</para>
		/// <para>如果立方体是通过定义的位置创建的，则趋势选项将适用于在立方体创建过程中包含的汇总字段或变量。</para>
		/// <para>热点和冷点趋势与新兴时空热点分析结果选项仅在针对所选立方体变量运行新兴时空热点分析后才可使用。 仅当运行了局部异常值分析工具后，局部异常值百分比、最近时间段内的局部异常值、局部异常值分析结果和无空间邻域的位置选项才可用。</para>
		/// <para>预测结果选项仅适用于由时间序列预测工具集中的工具创建的立方体。 仅当指定了时间序列预测工具中的异常值选项参数时，时间序列异常值结果选项才可用。</para>
		/// <para>有关每个选项的详细信息，其中包括输出说明和创建的图表，请参阅时空立方体的可视化显示主题主题。</para>
		/// <para>带有数据的位置—将显示所有包含立方体变量参数数据的位置。</para>
		/// <para>趋势—将显示使用 Mann-Kendall 统计确定的每个位置的值趋势。</para>
		/// <para>热点和冷点趋势—将显示使用 Mann-Kendall 统计确定的每个位置的 z 得分趋势。</para>
		/// <para>新兴时空热点分析结果—将显示指定立方体变量参数的新兴时空热点分析的结果工具的结果。</para>
		/// <para>本地异常值分析结果—将显示指定立方体变量参数的局部异常值分析工具的结果。</para>
		/// <para>局部异常值百分比—将显示每个位置的总异常值百分比。</para>
		/// <para>最近时间段内的局部异常值—将显示最近时间段内发生的异常值。</para>
		/// <para>时间序列聚类结果—将显示指定立方体变量参数的时间序列聚类工具的结果。</para>
		/// <para>无空间邻域的位置—对于最后一次分析运行，将显示无空间邻域的位置。 这些位置仅依赖时间邻域进行分析。</para>
		/// <para>估算的立方图格数量—将显示为每个位置估算的立方图格数量</para>
		/// <para>从分析中排除的位置—将显示因含有不符合估算条件的空立方图格而从分析中排除的位置。</para>
		/// <para>预测结果—将显示指定分析变量参数所使用的时间序列预测工具的结果。</para>
		/// <para>时间序列异常值结果—将显示时间序列预测工具中的异常值选项参数的结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DisplayTheme { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类结果。 此要素类为指定显示变量的二维地图制图表达。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// <para>指定是否为每个输出要素生成时间序列弹出窗口。 shapefile 输出不支持弹出图表。</para>
		/// <para>将为数据集中的每个要素生成时间序列弹出窗口。</para>
		/// <para>未选中 - 将不会生成时间序列弹出窗口。 这是默认设置。</para>
		/// <para><see cref="EnableTimeSeriesPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableTimeSeriesPopups { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public VisualizeSpaceTimeCube2D SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// </summary>
		public enum EnableTimeSeriesPopupsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

#endregion
	}
}
