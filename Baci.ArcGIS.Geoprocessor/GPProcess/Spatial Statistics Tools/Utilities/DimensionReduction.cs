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
	/// <para>Dimension Reduction</para>
	/// <para>降维</para>
	/// <para>使用主成分分析 (PCA) 或降级线性判别分析 (LDA) 将尽可能多的方差聚合成更少的分量，来降低连续变量集的维数。</para>
	/// </summary>
	public class DimensionReduction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table or Features</para>
		/// <para>包含要降维的字段的表或要素。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Analysis Fields</para>
		/// <para>表示要降维的数据的字段。</para>
		/// </param>
		public DimensionReduction(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 降维</para>
		/// </summary>
		public override string DisplayName() => "降维";

		/// <summary>
		/// <para>Tool Name : DimensionReduction</para>
		/// </summary>
		public override string ToolName() => "DimensionReduction";

		/// <summary>
		/// <para>Tool Excute Name : stats.DimensionReduction</para>
		/// </summary>
		public override string ExcuteName() => "stats.DimensionReduction";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutputData, Fields, Method, Scale, CategoricalField, MinVariance, MinComponents, AppendFields, OutputEigenvaluesTable, OutputEigenvectorsTable, NumberOfPermutations, AppendToInput, UpdatedTable };

		/// <summary>
		/// <para>Input Table or Features</para>
		/// <para>包含要降维的字段的表或要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table or Feature Class</para>
		/// <para>包含降维的生成分量的输出表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputData { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>表示要降维的数据的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Dimension Reduction Method</para>
		/// <para>指定将用于对分析字段进行降维的方法。</para>
		/// <para>主成分分析 (PCA)—分析字段将划分为多个分量，每个分量将保持在总方差中的最大占比。 这是默认设置。</para>
		/// <para>降级线性判别分析 (LDA)—分析字段将将分为多个分量，每个分量将保持分类变量的最大类别间可分离性。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PCA";

		/// <summary>
		/// <para>Scale Data</para>
		/// <para>指定是否将调整每个分析的值比例，以使方差等于 1。 这种比例调整可确保每个分析字段在分量中的优先级相同。 比例调整还消除了线性单位的影响，例如，以米和英尺测量的相同数据将生成等效分量。 将转换分析字段的值，以使这两个选项的平均值为零。</para>
		/// <para>选中 - 将调整每个分析字段的值比例，以使方差等于 1。 这是默认设置。</para>
		/// <para>未选中 - 不会调整每个分析字段的方差比例。</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Scale { get; set; } = "true";

		/// <summary>
		/// <para>Categorical Field</para>
		/// <para>表示 LDA 的分类变量的字段。 这些分量将保留将每个输入记录分类为这些类别所需的最大信息量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long")]
		public object CategoricalField { get; set; }

		/// <summary>
		/// <para>Minimum Percent Variance to Maintain</para>
		/// <para>必须在分量中保持的分析字段总方差的最小百分比。 总方差取决于是否使用调整数据比例参数调整分析字段的比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 100)]
		public object MinVariance { get; set; }

		/// <summary>
		/// <para>Minimum Number of Components</para>
		/// <para>最小分量数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 65534)]
		public object MinComponents { get; set; }

		/// <summary>
		/// <para>Copy All Fields to Output Dataset</para>
		/// <para>指定是否复制输入表或要素中的所有字段并将其追加到输出表或要素类中。 分析字段参数中提供的字段将复制到输出中，无论此参数的值为何。</para>
		/// <para>选中 - 将复制输入表或要素中的所有字段并将其追加到输出表或要素类中。</para>
		/// <para>未选中 - 仅在输出表或要素类中包含分析字段。 这是默认设置。</para>
		/// <para><see cref="AppendFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object AppendFields { get; set; } = "false";

		/// <summary>
		/// <para>Output Eigenvalues Table</para>
		/// <para>包含每个分量的特征值的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object OutputEigenvaluesTable { get; set; }

		/// <summary>
		/// <para>Output Eigenvectors Table</para>
		/// <para>包含每个分量的特征向量的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object OutputEigenvectorsTable { get; set; }

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>确定最佳分量数时要使用的置换检验次数。 默认值为 0，表示不会执行置换检验。</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object NumberOfPermutations { get; set; } = "0";

		/// <summary>
		/// <para>Append Fields to Input Data</para>
		/// <para>指定是将分量字段追加到输入数据集还是将其保存到输出表或要素类。 如果您将字段追加到输入，则会忽略输出坐标系环境。</para>
		/// <para>选中 - 包含分量的字段将被追加到输入要素。 此选项会修改输入数据。</para>
		/// <para>未选中 - 将创建包含分量字段的输出表或要素类。 这是默认设置。</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Updated Table or Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DimensionReduction SetEnviroment(object outputCoordinateSystem = null , object randomGenerator = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dimension Reduction Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>主成分分析 (PCA)—分析字段将划分为多个分量，每个分量将保持在总方差中的最大占比。 这是默认设置。</para>
			/// </summary>
			[GPValue("PCA")]
			[Description("主成分分析 (PCA)")]
			PCA,

			/// <summary>
			/// <para>降级线性判别分析 (LDA)—分析字段将将分为多个分量，每个分量将保持分类变量的最大类别间可分离性。</para>
			/// </summary>
			[GPValue("LDA")]
			[Description("降级线性判别分析 (LDA)")]
			LDA,

		}

		/// <summary>
		/// <para>Scale Data</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SCALE_DATA")]
			SCALE_DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SCALE_DATA")]
			NO_SCALE_DATA,

		}

		/// <summary>
		/// <para>Copy All Fields to Output Dataset</para>
		/// </summary>
		public enum AppendFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPEND")]
			NO_APPEND,

		}

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

		}

		/// <summary>
		/// <para>Append Fields to Input Data</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_OUTPUT")]
			NEW_OUTPUT,

		}

#endregion
	}
}
