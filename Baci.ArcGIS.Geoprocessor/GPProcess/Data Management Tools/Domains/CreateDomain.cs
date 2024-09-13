using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Domain</para>
	/// <para>创建属性域</para>
	/// <para>在指定工作空间中创建属性域。</para>
	/// </summary>
	public class CreateDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>将包含新属性域的地理数据库。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>要创建的属性域的名称。</para>
		/// </param>
		public CreateDomain(object InWorkspace, object DomainName)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建属性域</para>
		/// </summary>
		public override string DisplayName() => "创建属性域";

		/// <summary>
		/// <para>Tool Name : CreateDomain</para>
		/// </summary>
		public override string ToolName() => "CreateDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateDomain";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, DomainDescription, FieldType, DomainType, SplitPolicy, MergePolicy, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>将包含新属性域的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>要创建的属性域的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Domain Description</para>
		/// <para>要创建的属性域的描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DomainDescription { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定要创建的属性域的类型。 属性域属性是描述字段类型允许值的规则。 指定的字段类型应与将属性域指定到的字段的数据类型相匹配。</para>
		/// <para>文本—将创建一个包含字符串的文本类型字段。</para>
		/// <para>浮点型（单精度）—将创建一个包含介于 -3.4E38 和 1.2E38 之间的小数的浮点类型字段。</para>
		/// <para>双精度型（双精度）—将创建一个包含介于 -2.2E308 和 1.8E308 之间的小数的双精度类型字段。</para>
		/// <para>短整型（小整数）—将创建一个包含介于 -32,768 和 32,767 之间的整数的短整型类型字段。</para>
		/// <para>长整型（大整数）—将创建一个包含介于 -2,147,483,648 和 2,147,483,647 之间的整数的长整型类型字段。</para>
		/// <para>日期—将创建一个包含日期和/或时间的日期类型字段。</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "SHORT";

		/// <summary>
		/// <para>Domain Type</para>
		/// <para>指定要创建的属性域的类型。</para>
		/// <para>编码值属性域—将创建一个包含属性的一组有效值的编码类型属性域。 这是默认设置。 例如，可用编码值属性域指定有效的管道材料值：如 CL - 铸铁管、DL - 球墨铸铁管或 ACP - 石棉混凝土管。</para>
		/// <para>值域范围—将创建一个包含数值属性有效值范围的范围类型属性域。 例如，如果给水干管的压力介于 50 和 75 psi 之间，则可用范围属性域指定这些最大值和最小值。</para>
		/// <para><see cref="DomainTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DomainType { get; set; } = "CODED";

		/// <summary>
		/// <para>Split Policy</para>
		/// <para>指定将用于所创建属性域的分割策略。 分割要素时，属性值的行为受控于它的分割策略。</para>
		/// <para>使用属性的默认值—两个结果要素的属性将使用给定要素类或子类型的默认属性值。</para>
		/// <para>复制属性值—两个结果要素的属性使用原始对象的属性值副本。</para>
		/// <para>使用几何比—结果要素的属性将是原始要素值的比率。 该比率取决于原始几何的分割比例。 如果几何被分割成相等的两部分，则每个新要素的属性值将是原始对象属性值的一半。 几何比策略仅适用于范围属性域。</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitPolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Merge Policy</para>
		/// <para>指定将用于所创建属性域的合并策略。 在将两个要素合并为一个要素时，合并策略控制着新要素的属性值。</para>
		/// <para>使用属性的默认值—结果要素的属性将使用给定要素类或子类型的默认属性值。 这是唯一适用于非数字字段和编码值属性域的合并策略。</para>
		/// <para>值的总和—结果要素的属性将使用原始要素属性值的总和。 总和值策略仅适用于范围属性域。</para>
		/// <para>面积加权平均值—结果要素的属性将使用原始要素属性值的加权平均值。 此平均值取决于原始要素的几何。 加权面积策略仅适用于范围属性域。</para>
		/// <para><see cref="MergePolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MergePolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDomain SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>短整型（小整数）—将创建一个包含介于 -32,768 和 32,767 之间的整数的短整型类型字段。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（小整数）")]
			SHORT,

			/// <summary>
			/// <para>长整型（大整数）—将创建一个包含介于 -2,147,483,648 和 2,147,483,647 之间的整数的长整型类型字段。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（大整数）")]
			LONG,

			/// <summary>
			/// <para>浮点型（单精度）—将创建一个包含介于 -3.4E38 和 1.2E38 之间的小数的浮点类型字段。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型（单精度）")]
			FLOAT,

			/// <summary>
			/// <para>双精度型（双精度）—将创建一个包含介于 -2.2E308 和 1.8E308 之间的小数的双精度类型字段。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型（双精度）")]
			DOUBLE,

			/// <summary>
			/// <para>文本—将创建一个包含字符串的文本类型字段。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本")]
			Text,

			/// <summary>
			/// <para>日期—将创建一个包含日期和/或时间的日期类型字段。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

		}

		/// <summary>
		/// <para>Domain Type</para>
		/// </summary>
		public enum DomainTypeEnum 
		{
			/// <summary>
			/// <para>编码值属性域—将创建一个包含属性的一组有效值的编码类型属性域。 这是默认设置。 例如，可用编码值属性域指定有效的管道材料值：如 CL - 铸铁管、DL - 球墨铸铁管或 ACP - 石棉混凝土管。</para>
			/// </summary>
			[GPValue("CODED")]
			[Description("编码值属性域")]
			Coded_value_domain,

			/// <summary>
			/// <para>值域范围—将创建一个包含数值属性有效值范围的范围类型属性域。 例如，如果给水干管的压力介于 50 和 75 psi 之间，则可用范围属性域指定这些最大值和最小值。</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("值域范围")]
			Range_domain,

		}

		/// <summary>
		/// <para>Split Policy</para>
		/// </summary>
		public enum SplitPolicyEnum 
		{
			/// <summary>
			/// <para>使用属性的默认值—两个结果要素的属性将使用给定要素类或子类型的默认属性值。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("使用属性的默认值")]
			DEFAULT,

			/// <summary>
			/// <para>复制属性值—两个结果要素的属性使用原始对象的属性值副本。</para>
			/// </summary>
			[GPValue("DUPLICATE")]
			[Description("复制属性值")]
			Duplicate_attribute_values,

			/// <summary>
			/// <para>使用几何比—结果要素的属性将是原始要素值的比率。 该比率取决于原始几何的分割比例。 如果几何被分割成相等的两部分，则每个新要素的属性值将是原始对象属性值的一半。 几何比策略仅适用于范围属性域。</para>
			/// </summary>
			[GPValue("GEOMETRY_RATIO")]
			[Description("使用几何比")]
			Use_geometric_ratio,

		}

		/// <summary>
		/// <para>Merge Policy</para>
		/// </summary>
		public enum MergePolicyEnum 
		{
			/// <summary>
			/// <para>使用属性的默认值—结果要素的属性将使用给定要素类或子类型的默认属性值。 这是唯一适用于非数字字段和编码值属性域的合并策略。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("使用属性的默认值")]
			DEFAULT,

			/// <summary>
			/// <para>值的总和—结果要素的属性将使用原始要素属性值的总和。 总和值策略仅适用于范围属性域。</para>
			/// </summary>
			[GPValue("SUM_VALUES")]
			[Description("值的总和")]
			Sum_of_the_values,

			/// <summary>
			/// <para>面积加权平均值—结果要素的属性将使用原始要素属性值的加权平均值。 此平均值取决于原始要素的几何。 加权面积策略仅适用于范围属性域。</para>
			/// </summary>
			[GPValue("AREA_WEIGHTED")]
			[Description("面积加权平均值")]
			Area_weighted_average,

		}

#endregion
	}
}
