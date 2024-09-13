using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Configure Route Dominance Rules</para>
	/// <para>配置路径优先级规则</para>
	/// <para>配置一组规则以确定存在并发路径的网络中的主要路径。</para>
	/// </summary>
	public class ConfigureRouteDominanceRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>输入要素类。 仅可使用已注册的 LRS 网络要素类。</para>
		/// </param>
		/// <param name="ConfigureType">
		/// <para>Configure Type</para>
		/// <para>指定将应用于 LRS 网络要素类参数值的配置类型。</para>
		/// <para>添加—新规则将添加到配置中。</para>
		/// <para>更新—将更新现有规则。</para>
		/// <para>删除—将删除现有规则。</para>
		/// <para><see cref="ConfigureTypeEnum"/></para>
		/// </param>
		/// <param name="RuleName">
		/// <para>Rule Name</para>
		/// <para>将添加、更新或删除的规则名称。 规则名称最多可包含 30 个字符。</para>
		/// </param>
		public ConfigureRouteDominanceRules(object InFeatureClass, object ConfigureType, object RuleName)
		{
			this.InFeatureClass = InFeatureClass;
			this.ConfigureType = ConfigureType;
			this.RuleName = RuleName;
		}

		/// <summary>
		/// <para>Tool Display Name : 配置路径优先级规则</para>
		/// </summary>
		public override string DisplayName() => "配置路径优先级规则";

		/// <summary>
		/// <para>Tool Name : ConfigureRouteDominanceRules</para>
		/// </summary>
		public override string ToolName() => "ConfigureRouteDominanceRules";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureRouteDominanceRules</para>
		/// </summary>
		public override string ExcuteName() => "locref.ConfigureRouteDominanceRules";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, ConfigureType, RuleName, UpdatedRuleName!, SourceTableName!, Fields!, OrderMethod!, OrderType!, PrioritizedExceptions!, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>输入要素类。 仅可使用已注册的 LRS 网络要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Configure Type</para>
		/// <para>指定将应用于 LRS 网络要素类参数值的配置类型。</para>
		/// <para>添加—新规则将添加到配置中。</para>
		/// <para>更新—将更新现有规则。</para>
		/// <para>删除—将删除现有规则。</para>
		/// <para><see cref="ConfigureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigureType { get; set; }

		/// <summary>
		/// <para>Rule Name</para>
		/// <para>将添加、更新或删除的规则名称。 规则名称最多可包含 30 个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleName { get; set; }

		/// <summary>
		/// <para>Updated Rule Name</para>
		/// <para>规则的更新名称。 此参数仅在将更新指定为配置类型参数值时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? UpdatedRuleName { get; set; }

		/// <summary>
		/// <para>Source Table Name</para>
		/// <para>注册到 LRS 网络要素类参数值的源事件表或要素类。 或者，可以使用网络要素类。 仅支持非跨线事件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SourceTableName { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>源表中的属性字段别名。 如果使用多个字段，它们将被串连起来。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Order Method</para>
		/// <para>指定路径优先级排序是否将由较小或较大的值确定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OrderMethod { get; set; }

		/// <summary>
		/// <para>Order Type</para>
		/// <para>指定在评估数字或字母数字字符串时将使用的排序类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OrderType { get; set; }

		/// <summary>
		/// <para>Prioritized Exceptions</para>
		/// <para>用户提供的异常的逗号分隔列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PrioritizedExceptions { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Configure Type</para>
		/// </summary>
		public enum ConfigureTypeEnum 
		{
			/// <summary>
			/// <para>添加—新规则将添加到配置中。</para>
			/// </summary>
			[GPValue("ADD")]
			[Description("添加")]
			Add,

			/// <summary>
			/// <para>更新—将更新现有规则。</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("更新")]
			Update,

			/// <summary>
			/// <para>删除—将删除现有规则。</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("删除")]
			Delete,

		}

#endregion
	}
}
