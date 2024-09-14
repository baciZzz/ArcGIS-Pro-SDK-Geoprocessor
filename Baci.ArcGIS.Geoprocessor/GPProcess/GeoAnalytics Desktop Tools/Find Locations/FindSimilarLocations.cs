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
	/// <para>Find Similar Locations</para>
	/// <para>查找相似位置</para>
	/// <para>根据要素属性识别与单个或多个输入要素最相似或者最不相似的候选要素。</para>
	/// </summary>
	public class FindSimilarLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>包含要匹配的要素的参考图层（或图层上的选择）。该工具用于搜索与这些要素类似的其他要素。如果提供了多个要素，则会根据属性平均值进行匹配。</para>
		/// </param>
		/// <param name="SearchLayer">
		/// <para>Search Layer</para>
		/// <para>候选图层（或者图层上的选择）包含候选匹配要素。该工具会在这些候选要素中查找与输入图层参数最相似（或最不相似）的要素。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>输出要素类的名称。输出要素类包含每个输入图层参数的记录，以及查找到的所有与解决方案相匹配的要素的记录。</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>表示匹配条件的数值属性列表。</para>
		/// </param>
		public FindSimilarLocations(object InputLayer, object SearchLayer, object Output, object AnalysisFields)
		{
			this.InputLayer = InputLayer;
			this.SearchLayer = SearchLayer;
			this.Output = Output;
			this.AnalysisFields = AnalysisFields;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找相似位置</para>
		/// </summary>
		public override string DisplayName() => "查找相似位置";

		/// <summary>
		/// <para>Tool Name : FindSimilarLocations</para>
		/// </summary>
		public override string ToolName() => "FindSimilarLocations";

		/// <summary>
		/// <para>Tool Excute Name : gapro.FindSimilarLocations</para>
		/// </summary>
		public override string ExcuteName() => "gapro.FindSimilarLocations";

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
		public override object[] Parameters() => new object[] { InputLayer, SearchLayer, Output, AnalysisFields, MostOrLeastSimilar, MatchMethod, NumberOfResults, AppendFields };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>包含要匹配的要素的参考图层（或图层上的选择）。该工具用于搜索与这些要素类似的其他要素。如果提供了多个要素，则会根据属性平均值进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Search Layer</para>
		/// <para>候选图层（或者图层上的选择）包含候选匹配要素。该工具会在这些候选要素中查找与输入图层参数最相似（或最不相似）的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object SearchLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>输出要素类的名称。输出要素类包含每个输入图层参数的记录，以及查找到的所有与解决方案相匹配的要素的记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>表示匹配条件的数值属性列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// <para>用于指定要查找的要素与输入图层参数最相似还是最不相似。</para>
		/// <para>最相似—查找最相似的要素。</para>
		/// <para>最不相似—查找最不相似的要素。</para>
		/// <para>两者—查找最相似的要素和最不相似的要素。</para>
		/// <para><see cref="MostOrLeastSimilarEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MostOrLeastSimilar { get; set; } = "MOST_SIMILAR";

		/// <summary>
		/// <para>Match Method</para>
		/// <para>用于指定是根据值还是余弦关系进行匹配。</para>
		/// <para>属性值—相似性或相异性取决于所有分析字段属性的标准化属性值平方差的总和。</para>
		/// <para>属性剖面—将根据余弦相似性函数来计算所有分析字段属性的相似性或相异性。</para>
		/// <para><see cref="MatchMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchMethod { get; set; } = "ATTRIBUTE_VALUES";

		/// <summary>
		/// <para>Number Of Results</para>
		/// <para>要查找的匹配解决方案的数量。输入 0 或一个大于搜索图层要素总数的数字，将返回所有候选要素的等级（最多 10,000 个）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000)]
		public object NumberOfResults { get; set; } = "10";

		/// <summary>
		/// <para>Append Fields</para>
		/// <para>将包含输出的可选属性列表。例如，您可以包含名称标识符、分类字段或者日期字段。这些字段不用于确定相似性；它们包含在输出参数属性中仅供参考之用。默认情况下，将添加所有字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "GUID", "GlobalID", "XML")]
		public object AppendFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindSimilarLocations SetEnviroment(object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// </summary>
		public enum MostOrLeastSimilarEnum 
		{
			/// <summary>
			/// <para>最相似—查找最相似的要素。</para>
			/// </summary>
			[GPValue("MOST_SIMILAR")]
			[Description("最相似")]
			Most_similar,

			/// <summary>
			/// <para>最不相似—查找最不相似的要素。</para>
			/// </summary>
			[GPValue("LEAST_SIMILAR")]
			[Description("最不相似")]
			Least_similar,

			/// <summary>
			/// <para>两者—查找最相似的要素和最不相似的要素。</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("两者")]
			Both,

		}

		/// <summary>
		/// <para>Match Method</para>
		/// </summary>
		public enum MatchMethodEnum 
		{
			/// <summary>
			/// <para>属性值—相似性或相异性取决于所有分析字段属性的标准化属性值平方差的总和。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_VALUES")]
			[Description("属性值")]
			Attribute_values,

			/// <summary>
			/// <para>属性剖面—将根据余弦相似性函数来计算所有分析字段属性的相似性或相异性。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_PROFILES")]
			[Description("属性剖面")]
			Attribute_profiles,

		}

#endregion
	}
}
