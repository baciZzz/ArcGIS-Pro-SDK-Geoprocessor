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
	/// <para>Similarity Search</para>
	/// <para>相似性搜索</para>
	/// <para>根据要素属性确定哪些候选要素与单个或多个输入要素最相似或者最不相似。</para>
	/// </summary>
	public class SimilaritySearch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeaturesToMatch">
		/// <para>Input Features To Match</para>
		/// <para>该图层或者图层上的选择含有您想要匹配的要素；您正在搜索与这些要素相似的其他要素。如果提供了多个要素，则会根据属性平均值进行匹配。</para>
		/// <para>如果要匹配的输入要素和候选要素值来自单个数据集图层，则可以执行以下操作：</para>
		/// <para>将该图层复制到内容窗格以生成重复的图层。</para>
		/// <para>重命名该重复的图层。</para>
		/// <para>在重命名的图层上，选择或设置用于您希望匹配的参考要素的定义查询。将此新创建的图层用于要匹配的输入要素参数。</para>
		/// <para>在原始图层上选择或设置定义查询以便排除参考要素。这将为用于候选要素参数的图层。</para>
		/// </param>
		/// <param name="CandidateFeatures">
		/// <para>Candidate Features</para>
		/// <para>该图层或者图层上的选择包含候选匹配要素。该工具将在这些候选要素中检查与要匹配的输入要素值最相似（或者最不相似）的要素。</para>
		/// <para>如果要匹配的输入要素和候选要素值来自单个数据集图层，则可以执行以下操作：</para>
		/// <para>将该图层复制到内容窗格以生成重复的图层。</para>
		/// <para>重命名该重复的图层。</para>
		/// <para>在重命名的图层上，选择或设置用于您希望匹配的参考要素的定义查询。将此新创建的图层用于要匹配的输入要素参数。</para>
		/// <para>在原始图层上选择或设置定义查询以便排除参考要素。这将为用于候选要素参数的图层。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类包含每个要匹配的输入要素值的记录，以及查找到的所有与解决方案相匹配的要素的记录。</para>
		/// </param>
		/// <param name="CollapseOutputToPoints">
		/// <para>Collapse Output To Points</para>
		/// <para>如果要匹配的输入要素和候选要素参数值均为线或面，指定是否将输出要素参数的几何折叠为点或者将匹配输入要素的原始几何（线或面）。仅当具有 Desktop Advanced 许可时，此参数才可用。选中此参数将提高大型线和面数据集的工具性能。</para>
		/// <para>选中 - 线和面要素将表示为要素质心（点）。</para>
		/// <para>未选中 - 输出几何将与输入要素的线或面几何相匹配。这是默认设置。</para>
		/// <para><see cref="CollapseOutputToPointsEnum"/></para>
		/// </param>
		/// <param name="MostOrLeastSimilar">
		/// <para>Most Or Least Similar</para>
		/// <para>指定是否将标识与要匹配的输入要素值最相似或最不相似的要素。</para>
		/// <para>最相似—将标识最相似的要素。这是默认设置。</para>
		/// <para>最不相似—将标识最不相似的要素。</para>
		/// <para>两者—将标识最相似和最不相似的要素。</para>
		/// <para><see cref="MostOrLeastSimilarEnum"/></para>
		/// </param>
		/// <param name="MatchMethod">
		/// <para>Match Method</para>
		/// <para>用于指定是否根据值、等级或余弦关系进行匹配。</para>
		/// <para>属性值—匹配将以所有感兴趣属性值的标准化属性值平方差的总和为基础。这是默认设置。</para>
		/// <para>等级属性值—匹配将以所有感兴趣属性值的等级平方差的总和为基础。</para>
		/// <para>属性剖面—将以余弦相似性函数的方式来计算所有感兴趣属性的匹配。</para>
		/// <para><see cref="MatchMethodEnum"/></para>
		/// </param>
		/// <param name="NumberOfResults">
		/// <para>Number Of Results</para>
		/// <para>要查找的匹配解决方案的数量。输入 0 或一个大于候选要素值总数的数字，将返回所有候选要素的等级。默认值为 10。</para>
		/// </param>
		/// <param name="AttributesOfInterest">
		/// <para>Attributes Of Interest</para>
		/// <para>表示匹配条件的数值属性。</para>
		/// </param>
		public SimilaritySearch(object InputFeaturesToMatch, object CandidateFeatures, object OutputFeatures, object CollapseOutputToPoints, object MostOrLeastSimilar, object MatchMethod, object NumberOfResults, object AttributesOfInterest)
		{
			this.InputFeaturesToMatch = InputFeaturesToMatch;
			this.CandidateFeatures = CandidateFeatures;
			this.OutputFeatures = OutputFeatures;
			this.CollapseOutputToPoints = CollapseOutputToPoints;
			this.MostOrLeastSimilar = MostOrLeastSimilar;
			this.MatchMethod = MatchMethod;
			this.NumberOfResults = NumberOfResults;
			this.AttributesOfInterest = AttributesOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : 相似性搜索</para>
		/// </summary>
		public override string DisplayName() => "相似性搜索";

		/// <summary>
		/// <para>Tool Name : SimilaritySearch</para>
		/// </summary>
		public override string ToolName() => "SimilaritySearch";

		/// <summary>
		/// <para>Tool Excute Name : stats.SimilaritySearch</para>
		/// </summary>
		public override string ExcuteName() => "stats.SimilaritySearch";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeaturesToMatch, CandidateFeatures, OutputFeatures, CollapseOutputToPoints, MostOrLeastSimilar, MatchMethod, NumberOfResults, AttributesOfInterest, FieldsToAppendToOutput };

		/// <summary>
		/// <para>Input Features To Match</para>
		/// <para>该图层或者图层上的选择含有您想要匹配的要素；您正在搜索与这些要素相似的其他要素。如果提供了多个要素，则会根据属性平均值进行匹配。</para>
		/// <para>如果要匹配的输入要素和候选要素值来自单个数据集图层，则可以执行以下操作：</para>
		/// <para>将该图层复制到内容窗格以生成重复的图层。</para>
		/// <para>重命名该重复的图层。</para>
		/// <para>在重命名的图层上，选择或设置用于您希望匹配的参考要素的定义查询。将此新创建的图层用于要匹配的输入要素参数。</para>
		/// <para>在原始图层上选择或设置定义查询以便排除参考要素。这将为用于候选要素参数的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeaturesToMatch { get; set; }

		/// <summary>
		/// <para>Candidate Features</para>
		/// <para>该图层或者图层上的选择包含候选匹配要素。该工具将在这些候选要素中检查与要匹配的输入要素值最相似（或者最不相似）的要素。</para>
		/// <para>如果要匹配的输入要素和候选要素值来自单个数据集图层，则可以执行以下操作：</para>
		/// <para>将该图层复制到内容窗格以生成重复的图层。</para>
		/// <para>重命名该重复的图层。</para>
		/// <para>在重命名的图层上，选择或设置用于您希望匹配的参考要素的定义查询。将此新创建的图层用于要匹配的输入要素参数。</para>
		/// <para>在原始图层上选择或设置定义查询以便排除参考要素。这将为用于候选要素参数的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object CandidateFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类包含每个要匹配的输入要素值的记录，以及查找到的所有与解决方案相匹配的要素的记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Collapse Output To Points</para>
		/// <para>如果要匹配的输入要素和候选要素参数值均为线或面，指定是否将输出要素参数的几何折叠为点或者将匹配输入要素的原始几何（线或面）。仅当具有 Desktop Advanced 许可时，此参数才可用。选中此参数将提高大型线和面数据集的工具性能。</para>
		/// <para>选中 - 线和面要素将表示为要素质心（点）。</para>
		/// <para>未选中 - 输出几何将与输入要素的线或面几何相匹配。这是默认设置。</para>
		/// <para><see cref="CollapseOutputToPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapseOutputToPoints { get; set; } = "false";

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// <para>指定是否将标识与要匹配的输入要素值最相似或最不相似的要素。</para>
		/// <para>最相似—将标识最相似的要素。这是默认设置。</para>
		/// <para>最不相似—将标识最不相似的要素。</para>
		/// <para>两者—将标识最相似和最不相似的要素。</para>
		/// <para><see cref="MostOrLeastSimilarEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MostOrLeastSimilar { get; set; } = "MOST_SIMILAR";

		/// <summary>
		/// <para>Match Method</para>
		/// <para>用于指定是否根据值、等级或余弦关系进行匹配。</para>
		/// <para>属性值—匹配将以所有感兴趣属性值的标准化属性值平方差的总和为基础。这是默认设置。</para>
		/// <para>等级属性值—匹配将以所有感兴趣属性值的等级平方差的总和为基础。</para>
		/// <para>属性剖面—将以余弦相似性函数的方式来计算所有感兴趣属性的匹配。</para>
		/// <para><see cref="MatchMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchMethod { get; set; } = "ATTRIBUTE_VALUES";

		/// <summary>
		/// <para>Number Of Results</para>
		/// <para>要查找的匹配解决方案的数量。输入 0 或一个大于候选要素值总数的数字，将返回所有候选要素的等级。默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfResults { get; set; } = "10";

		/// <summary>
		/// <para>Attributes Of Interest</para>
		/// <para>表示匹配条件的数值属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AttributesOfInterest { get; set; }

		/// <summary>
		/// <para>Fields To Append To Output</para>
		/// <para>输出要素参数随附的字段。这些字段不用于确定相似性；它们仅包含在输出要素参数中供参考之用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Additional Options")]
		public object FieldsToAppendToOutput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimilaritySearch SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Collapse Output To Points</para>
		/// </summary>
		public enum CollapseOutputToPointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COLLAPSE")]
			COLLAPSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COLLAPSE")]
			NO_COLLAPSE,

		}

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// </summary>
		public enum MostOrLeastSimilarEnum 
		{
			/// <summary>
			/// <para>最相似—将标识最相似的要素。这是默认设置。</para>
			/// </summary>
			[GPValue("MOST_SIMILAR")]
			[Description("最相似")]
			Most_similar,

			/// <summary>
			/// <para>最不相似—将标识最不相似的要素。</para>
			/// </summary>
			[GPValue("LEAST_SIMILAR")]
			[Description("最不相似")]
			Least_similar,

			/// <summary>
			/// <para>两者—将标识最相似和最不相似的要素。</para>
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
			/// <para>属性值—匹配将以所有感兴趣属性值的标准化属性值平方差的总和为基础。这是默认设置。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_VALUES")]
			[Description("属性值")]
			Attribute_values,

			/// <summary>
			/// <para>等级属性值—匹配将以所有感兴趣属性值的等级平方差的总和为基础。</para>
			/// </summary>
			[GPValue("RANKED_ATTRIBUTE_VALUES")]
			[Description("等级属性值")]
			Ranked_attribute_values,

			/// <summary>
			/// <para>属性剖面—将以余弦相似性函数的方式来计算所有感兴趣属性的匹配。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_PROFILES")]
			[Description("属性剖面")]
			Attribute_profiles,

		}

#endregion
	}
}
