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
	/// <para>Time Series Clustering</para>
	/// <para>时间序列聚类</para>
	/// <para>基于时间序列特征的相似性，对存储在时空立方体中的时间序列集合进行划分。 可以基于三个条件聚集时间序列：具有相似的时间值，趋于同时增加和减少以及具有相似的重复模式。 此工具的输出为一个 2D 地图，该地图可显示按聚类成员资格和消息进行符号化的立方体中的每个位置。 输出还包括相应图表，其中包含有关每个聚类的代表性时间序列签名的信息。</para>
	/// </summary>
	public class TimeSeriesClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>包含要分析的变量的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>netCDF 文件中的数值变量会随时间改变，将用于区分各个聚类。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>新的输出要素类，包含时空立方体中的所有位置以及一个表示聚类成员资格的字段。 此要素类将为数据中聚类的二维表示。</para>
		/// </param>
		/// <param name="CharacteristicOfInterest">
		/// <para>Characteristic of Interest</para>
		/// <para>指定时间序列的特征，用于确定应聚集在一起的位置。</para>
		/// <para>值—时间值相似的位置将聚集在一起。</para>
		/// <para>轮廓（相关性）—值趋于同时按比例增加和减少的位置将聚集在一起。</para>
		/// <para>轮廓（傅里叶）—值具有相似的平滑周期性模式的位置将聚集在一起。</para>
		/// <para><see cref="CharacteristicOfInterestEnum"/></para>
		/// </param>
		public TimeSeriesClustering(object InCube, object AnalysisVariable, object OutputFeatures, object CharacteristicOfInterest)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
			this.CharacteristicOfInterest = CharacteristicOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : 时间序列聚类</para>
		/// </summary>
		public override string DisplayName() => "时间序列聚类";

		/// <summary>
		/// <para>Tool Name : TimeSeriesClustering</para>
		/// </summary>
		public override string ToolName() => "TimeSeriesClustering";

		/// <summary>
		/// <para>Tool Excute Name : stpm.TimeSeriesClustering</para>
		/// </summary>
		public override string ExcuteName() => "stpm.TimeSeriesClustering";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, CharacteristicOfInterest, ClusterCount!, OutputTableForCharts!, ShapeCharacteristicToIgnore!, EnableTimeSeriesPopups! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>包含要分析的变量的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>netCDF 文件中的数值变量会随时间改变，将用于区分各个聚类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>新的输出要素类，包含时空立方体中的所有位置以及一个表示聚类成员资格的字段。 此要素类将为数据中聚类的二维表示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Characteristic of Interest</para>
		/// <para>指定时间序列的特征，用于确定应聚集在一起的位置。</para>
		/// <para>值—时间值相似的位置将聚集在一起。</para>
		/// <para>轮廓（相关性）—值趋于同时按比例增加和减少的位置将聚集在一起。</para>
		/// <para>轮廓（傅里叶）—值具有相似的平滑周期性模式的位置将聚集在一起。</para>
		/// <para><see cref="CharacteristicOfInterestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CharacteristicOfInterest { get; set; }

		/// <summary>
		/// <para>Number of Clusters</para>
		/// <para>要创建的聚类数。 如果留空，该工具将使用伪 F 统计量评估最佳聚类数。 并将在消息窗口中报告聚类的最佳数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? ClusterCount { get; set; }

		/// <summary>
		/// <para>Output Table for Charts</para>
		/// <para>如果指定，则此图表将包含每个聚类的代表性时间序列，其中每个聚类基于每个时间序列聚类和中心点时间序列的平均值。 基于该表创建的图表可通过独立表部分进行访问。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputTableForCharts { get; set; }

		/// <summary>
		/// <para>Time Series Characteristics to Ignore</para>
		/// <para>指定确定两个时间序列之间的相似性时将忽略的特征。</para>
		/// <para>时差—将忽略每个周期的开始时间（包括时差）。 例如，如果两个时间序列的周期性模式相似，但是一个时间序列的值比另一个时间序列的值晚三天，则这两个时间序列视为相似。</para>
		/// <para>范围—将忽略每个周期中的值量级。 例如，如果两个时间序列的周期同时开始和结束，则二者视为相似，即使实际值相差很大。</para>
		/// <para>如果忽略了这两个特征，则当周期的持续时间相似时，这两个时间序列将视为相似，即使二者开始时间不同且在周期内具有不同的值。</para>
		/// <para><see cref="ShapeCharacteristicToIgnoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ShapeCharacteristicToIgnore { get; set; }

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// <para>指定是否将在每个输出要素的弹出窗口中创建时间序列图表，以显示要素的时间序列以及该要素所在聚类中所有要素的平均时间序列。</para>
		/// <para>选中 - 将为输出要素创建时间序列图表。</para>
		/// <para>未选中 - 不会创建时间序列图表。 这是默认设置。</para>
		/// <para><see cref="EnableTimeSeriesPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableTimeSeriesPopups { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TimeSeriesClustering SetEnviroment(object? parallelProcessingFactor = null , object? randomGenerator = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Characteristic of Interest</para>
		/// </summary>
		public enum CharacteristicOfInterestEnum 
		{
			/// <summary>
			/// <para>值—时间值相似的位置将聚集在一起。</para>
			/// </summary>
			[GPValue("VALUE")]
			[Description("值")]
			Value,

			/// <summary>
			/// <para>轮廓（相关性）—值趋于同时按比例增加和减少的位置将聚集在一起。</para>
			/// </summary>
			[GPValue("PROFILE")]
			[Description("轮廓（相关性）")]
			PROFILE,

			/// <summary>
			/// <para>轮廓（傅里叶）—值具有相似的平滑周期性模式的位置将聚集在一起。</para>
			/// </summary>
			[GPValue("PROFILE_FOURIER")]
			[Description("轮廓（傅里叶）")]
			PROFILE_FOURIER,

		}

		/// <summary>
		/// <para>Time Series Characteristics to Ignore</para>
		/// </summary>
		public enum ShapeCharacteristicToIgnoreEnum 
		{
			/// <summary>
			/// <para>时差—将忽略每个周期的开始时间（包括时差）。 例如，如果两个时间序列的周期性模式相似，但是一个时间序列的值比另一个时间序列的值晚三天，则这两个时间序列视为相似。</para>
			/// </summary>
			[GPValue("TIME_LAG")]
			[Description("时差")]
			Time_lag,

			/// <summary>
			/// <para>范围—将忽略每个周期中的值量级。 例如，如果两个时间序列的周期同时开始和结束，则二者视为相似，即使实际值相差很大。</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("范围")]
			Range,

		}

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
