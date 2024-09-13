using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Find Cotravelers</para>
	/// <para>查找同行者</para>
	/// <para>用于提取点轨迹数据集中以指定的间隔在空间和时间中移动的唯一标识符。</para>
	/// </summary>
	public class FindCotravelers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>启用时间的要素，表示将用于查找同行者的已知标识符。 唯一标识符、时间戳和位置将传输到输出图层，以帮助计算时间和空间间隔。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>该输出要素类将包含标识为与输入源图层同行的点轨迹段。 该要素类将包含与指定点轨迹段关联的源。 将为每个点轨迹要素计算时间和空间间隔。</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>输入要素参数中的字段，用于获取每个点轨迹的唯一标识符。 该字段将复制到输出要素类。</para>
		/// </param>
		public FindCotravelers(object InputFeatures, object OutFeatureclass, object IdField)
		{
			this.InputFeatures = InputFeatures;
			this.OutFeatureclass = OutFeatureclass;
			this.IdField = IdField;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找同行者</para>
		/// </summary>
		public override string DisplayName() => "查找同行者";

		/// <summary>
		/// <para>Tool Name : FindCotravelers</para>
		/// </summary>
		public override string ToolName() => "FindCotravelers";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindCotravelers</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.FindCotravelers";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutFeatureclass, IdField, SearchDistance!, TimeDifference!, InputType!, SecondaryFeatures!, SecondaryIdField!, CreateSummaryTable!, OutSummaryTable!, IncludeMinCotravelingDuration!, MinCotravelingDuration! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>启用时间的要素，表示将用于查找同行者的已知标识符。 唯一标识符、时间戳和位置将传输到输出图层，以帮助计算时间和空间间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>该输出要素类将包含标识为与输入源图层同行的点轨迹段。 该要素类将包含与指定点轨迹段关联的源。 将为每个点轨迹要素计算时间和空间间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>输入要素参数中的字段，用于获取每个点轨迹的唯一标识符。 该字段将复制到输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>在要素不被视为同行要素之前可以分隔的最大距离。 默认值为 100 英尺。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; } = "100 Feet";

		/// <summary>
		/// <para>Time Difference</para>
		/// <para>在要素不被视为同行要素之前可以分隔的最大时间差。 默认值为 10 秒。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeDifference { get; set; } = "10 Seconds";

		/// <summary>
		/// <para>Input Type</para>
		/// <para>指定将在一个要素类中还是在跨要素类检测同行者。</para>
		/// <para>一个要素类—将在一个要素类中检测同行者。 这是默认设置。</para>
		/// <para>两个要素类—将在两个要素类中检测同行者。</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InputType { get; set; } = "ONE_FEATURECLASS";

		/// <summary>
		/// <para>Secondary Features</para>
		/// <para>将用于标识同行者的第二个要素类。 将使用以下内容来评估潜在同行者：</para>
		/// <para>同行者正在输入要素内同行。</para>
		/// <para>同行者正在次要要素内同行。</para>
		/// <para>同行者正在输入要素和次要要素之间同行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object? SecondaryFeatures { get; set; }

		/// <summary>
		/// <para>Secondary ID Field</para>
		/// <para>次要要素参数中的字段，用于获取每个点轨迹的唯一标识符。 该字段将复制到输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? SecondaryIdField { get; set; }

		/// <summary>
		/// <para>Create Summary Table</para>
		/// <para>指定是否将创建输出汇总表。</para>
		/// <para>选中 - 将创建汇总表。</para>
		/// <para>未选中 - 将不会创建汇总表。 这是默认设置。</para>
		/// <para><see cref="CreateSummaryTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateSummaryTable { get; set; }

		/// <summary>
		/// <para>Output Summary Table</para>
		/// <para>将存储汇总信息的输出表。 此参数仅在选中创建汇总表参数时处于活动状态。 输出文件必须是文件地理数据库、文本文件或逗号分隔值文件 (.csv) 中的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutSummaryTable { get; set; }

		/// <summary>
		/// <para>Include Minimum Cotraveling Duration Filter</para>
		/// <para>指定是否将应用仅返回满足最短共同出行时间的同行者的过滤器。</para>
		/// <para>选中 - 将应用最短同行者持续时间过滤器。</para>
		/// <para>未选中 - 将不会应用最短同行者持续时间过滤器。 这是默认设置。</para>
		/// <para><see cref="IncludeMinCotravelingDurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeMinCotravelingDuration { get; set; }

		/// <summary>
		/// <para>Minimum Cotraveling Duration</para>
		/// <para>两个要素在被视为同行者之前，必须先在空间和时间上一起运动的最短时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? MinCotravelingDuration { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindCotravelers SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Type</para>
		/// </summary>
		public enum InputTypeEnum 
		{
			/// <summary>
			/// <para>一个要素类—将在一个要素类中检测同行者。 这是默认设置。</para>
			/// </summary>
			[GPValue("ONE_FEATURECLASS")]
			[Description("一个要素类")]
			One_Feature_Class,

			/// <summary>
			/// <para>两个要素类—将在两个要素类中检测同行者。</para>
			/// </summary>
			[GPValue("TWO_FEATURECLASSES")]
			[Description("两个要素类")]
			Two_Feature_Classes,

		}

		/// <summary>
		/// <para>Create Summary Table</para>
		/// </summary>
		public enum CreateSummaryTableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_SUMMARY_TABLE")]
			CREATE_SUMMARY_TABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUMMARY_TABLE")]
			NO_SUMMARY_TABLE,

		}

		/// <summary>
		/// <para>Include Minimum Cotraveling Duration Filter</para>
		/// </summary>
		public enum IncludeMinCotravelingDurationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MIN_COTRAVELING_DURATION")]
			MIN_COTRAVELING_DURATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_COTRAVELING_DURATION")]
			NO_MIN_COTRAVELING_DURATION,

		}

#endregion
	}
}
