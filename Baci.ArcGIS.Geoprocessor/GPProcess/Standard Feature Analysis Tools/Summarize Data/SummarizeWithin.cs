using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Summarize Within</para>
	/// <para>范围内汇总</para>
	/// <para>用于查找位于另一个图层面边界范围内的点、线或面要素（或前述部分要素）。</para>
	/// </summary>
	public class SummarizeWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Sumwithinlayer">
		/// <para>Input Polygons</para>
		/// <para>将汇总落入这些面边界范围内的输入汇总要素中的要素或要素部分。</para>
		/// </param>
		/// <param name="Summarylayer">
		/// <para>Input Summary Features</para>
		/// <para>将为各输入面汇总的点、线或面要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public SummarizeWithin(object Sumwithinlayer, object Summarylayer, object Outputname)
		{
			this.Sumwithinlayer = Sumwithinlayer;
			this.Summarylayer = Summarylayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 范围内汇总</para>
		/// </summary>
		public override string DisplayName() => "范围内汇总";

		/// <summary>
		/// <para>Tool Name : SummarizeWithin</para>
		/// </summary>
		public override string ToolName() => "SummarizeWithin";

		/// <summary>
		/// <para>Tool Excute Name : sfa.SummarizeWithin</para>
		/// </summary>
		public override string ExcuteName() => "sfa.SummarizeWithin";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Sumwithinlayer, Summarylayer, Outputname, Sumshape, Shapeunits, Summaryfields, Groupbyfield, Minoritymajority, Percentshape, Outputlayer, Groupbysummarylayer };

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>将汇总落入这些面边界范围内的输入汇总要素中的要素或要素部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object Sumwithinlayer { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>将为各输入面汇总的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object Summarylayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// <para>根据输入汇总要素的形状计算统计数据，例如各输入面中输入汇总要素线的长度或面的面积。</para>
		/// <para>选中 - 计算形状汇总属性。这是默认设置。</para>
		/// <para>未选中 - 不计算形状汇总属性。</para>
		/// <para><see cref="SumshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Sumshape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>如果要汇总输入汇总要素的形状，请指定形状汇总的单位。</para>
		/// <para>如果输入汇总要素为面，则有效选项为英亩、公顷、平方米、平方千米、平方英尺、平方码和平方英里。</para>
		/// <para>如果输入汇总要素为线，则有效选项为米、千米、英尺、码和英里。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para>码—码</para>
		/// <para>英亩—英亩</para>
		/// <para>公顷—公顷</para>
		/// <para>平方米—平方米</para>
		/// <para>平方千米—平方千米</para>
		/// <para>平方英尺—平方英尺</para>
		/// <para>平方码—平方码</para>
		/// <para>平方英里—平方英里</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Shapeunits { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>字段名称及您想要为各面内全部点计算的统计汇总类型的列表。始终返回每个面内的点计数。支持的统计数据类型如下：</para>
		/// <para>Sum - 总值。</para>
		/// <para>Minimum - 最小值。</para>
		/// <para>Max - 最大值。</para>
		/// <para>Mean - 平均值。</para>
		/// <para>Standard deviation - 标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Summaryfields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>这是输入汇总要素的一个字段，可用于分别计算每个唯一属性值的统计数据。例如，假设输入汇总要素包含存储危险材料的企业的点位置，且其中一个字段为 HazardClass，字段中含有用于描述所存储危险材料类型的代码。要根据每个 HazardClass 唯一值计算汇总，请将其用作分组条件字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object Groupbyfield { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>仅当使用分组条件字段时适用。如果选中，将对各个边界内每个组字段的少数（所占比例最小）或众数（所占比例最大）属性值进行计算。前缀为众数_和少数_的两个新字段将添加至输出图层。</para>
		/// <para>未选中 - 不添加少数和众数字段。这是默认设置。</para>
		/// <para>选中 - 添加少数和众数字段。</para>
		/// <para><see cref="MinoritymajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Minoritymajority { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>仅当使用分组条件字段时适用。如果选中，则系统将针对每个输入面计算各唯一组值的百分比。</para>
		/// <para>未选中 - 不添加百分比字段。这是默认设置。</para>
		/// <para>选中 - 添加百分比字段。</para>
		/// <para><see cref="PercentshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Percentshape { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputlayer { get; set; }

		/// <summary>
		/// <para>Output Group Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Groupbysummarylayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeWithin SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// </summary>
		public enum SumshapeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum MinoritymajorityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add group percentages</para>
		/// </summary>
		public enum PercentshapeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
