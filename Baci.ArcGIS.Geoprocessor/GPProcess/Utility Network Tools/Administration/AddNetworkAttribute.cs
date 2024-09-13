using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Add Network Attribute</para>
	/// <para>添加网络属性</para>
	/// <para>用于向公共设施网络中添加网络属性。</para>
	/// </summary>
	public class AddNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将添加网络属性的输入公共设施网络。</para>
		/// </param>
		/// <param name="AttributeName">
		/// <para>Attribute Name</para>
		/// <para>要添加至公共设施网络的网络属性的名称。</para>
		/// </param>
		/// <param name="AttributeType">
		/// <para>Attribute Type</para>
		/// <para>指定网络属性的数据类型。</para>
		/// <para>短整型（16 位整型）—字段类型将为短整型。</para>
		/// <para>长整型（32 位整数）—字段类型将为长整型。</para>
		/// <para>双精度型（64 位浮点型）—字段类型将为双精度型。</para>
		/// <para>日期—字段类型将为日期型。</para>
		/// <para><see cref="AttributeTypeEnum"/></para>
		/// </param>
		public AddNetworkAttribute(object InUtilityNetwork, object AttributeName, object AttributeType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.AttributeName = AttributeName;
			this.AttributeType = AttributeType;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加网络属性</para>
		/// </summary>
		public override string DisplayName() => "添加网络属性";

		/// <summary>
		/// <para>Tool Name : AddNetworkAttribute</para>
		/// </summary>
		public override string ToolName() => "AddNetworkAttribute";

		/// <summary>
		/// <para>Tool Excute Name : un.AddNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName() => "un.AddNetworkAttribute";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, AttributeName, AttributeType, IsInline!, IsApportionable!, Domain!, IsOverridable!, IsNullable!, IsSubstitution!, NetworkAttributeToSubstitute!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将添加网络属性的输入公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Attribute Name</para>
		/// <para>要添加至公共设施网络的网络属性的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AttributeName { get; set; }

		/// <summary>
		/// <para>Attribute Type</para>
		/// <para>指定网络属性的数据类型。</para>
		/// <para>短整型（16 位整型）—字段类型将为短整型。</para>
		/// <para>长整型（32 位整数）—字段类型将为长整型。</para>
		/// <para>双精度型（64 位浮点型）—字段类型将为双精度型。</para>
		/// <para>日期—字段类型将为日期型。</para>
		/// <para><see cref="AttributeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AttributeType { get; set; }

		/// <summary>
		/// <para>In Line</para>
		/// <para>指定是否将网络属性保留在行内。 内嵌网络属性的效率略高，但是用户定义的内嵌网络属性的位数被限制在每个公共设施网络 25 位。 如果可能的话，应在线中存储最常用的网络属性（例如电力网络相位、天然气网和水网压力）。 位的大小由域参数决定。 内嵌属性仅支持整型网络属性（短整型或长整型）。</para>
		/// <para>选中 - 该属性将添加到拓扑内部，从而提高检索效率。</para>
		/// <para>未选中 - 该属性将存储在外部表中，且检索需要调用外部权重表。 这是默认设置。</para>
		/// <para><see cref="IsInlineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsInline { get; set; } = "false";

		/// <summary>
		/// <para>Apportionable</para>
		/// <para>指定是否在同一要素的多条边之间分配网络属性。</para>
		/// <para>可以将具有可分配属性的网络属性分配给行内字段或交汇点要素类，但仅行要素具有已分配行为。</para>
		/// <para>例如，对于 shape_length 网络属性，如果一个线要素由五个边元素组成，并且该线要素的总长度是 100 英尺，则将在所有边上分配该属性，每条边 20 英尺。 值的分布取决于每个边元素方向上相对于原始要素起点的百分比。</para>
		/// <para>已选中 - 将分配网络属性。</para>
		/// <para>未选中 - 不会分配网络属性。 这是默认设置。</para>
		/// <para><see cref="IsApportionableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsApportionable { get; set; } = "false";

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>将与网络属性相关联的域。 选中内嵌时，需要使用此参数。 该域必须是编码值类型，用于确定要为内嵌属性分配的位数。 例如，LifeCycleStatusDomain (0, Unknown | 1, In-Service | 2, Proposed | 3, Abandoned) 域有 4 个条目，这意味着需要 2 位来存储内嵌属性。 编码值域必须具有从 0 开始的相继代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Domain { get; set; }

		/// <summary>
		/// <para>Is Overridable</para>
		/// <para>当前版本中未使用此参数，任何提供的值都将被忽略。 此参数的功能正在研发中，且将在未来的版本中适用。</para>
		/// <para>指定是否将使用外部覆盖表覆盖存储在拓扑中的当前值。 例如，此参数可用于输入来自外部系统的实时数据，例如电力网络中的当前位置或天然气网的压力值。 以 SCADA 系统为例，该系统可将更新的设备 A 开关位置推送至 DeviceStatus 网络属性的覆盖表，拓扑引擎随后将通过该系统用覆盖值来覆盖设备 A 设备状态的当前值。</para>
		/// <para>已选中 - 将覆盖在拓扑中存储的当前值。</para>
		/// <para>未选中 - 不会覆盖在拓扑中存储的当前值。 这是默认设置。</para>
		/// <para><see cref="IsOverridableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsOverridable { get; set; } = "false";

		/// <summary>
		/// <para>Nullable</para>
		/// <para>指定网络属性是否支持空值。</para>
		/// <para>选中 - 网络属性支持空值。</para>
		/// <para>未选中 - 网络属性不支持空值。 这是默认设置。</para>
		/// <para><see cref="IsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsNullable { get; set; } = "false";

		/// <summary>
		/// <para>Substitution</para>
		/// <para>指定是否将网络属性用作替换项。 替换网络属性允许在追踪操作的传递期间使用替换值而不是 bitset 网络属性值。</para>
		/// <para>选中 - 网络属性将用作替换项。</para>
		/// <para>未选中 - 网络属性不会用作替换项。 这是默认设置。</para>
		/// <para><see cref="IsSubstitutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsSubstitution { get; set; } = "false";

		/// <summary>
		/// <para>Network Attribute to Substitute</para>
		/// <para>用于替换的网络属性。 替换是基于正在传递的网络属性中的位数进行编码的。 网络属性必须为内嵌，且必须为小于或等于 8 位的整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NetworkAttributeToSubstitute { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddNetworkAttribute SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attribute Type</para>
		/// </summary>
		public enum AttributeTypeEnum 
		{
			/// <summary>
			/// <para>短整型（16 位整型）—字段类型将为短整型。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（16 位整型）")]
			SHORT,

			/// <summary>
			/// <para>长整型（32 位整数）—字段类型将为长整型。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（32 位整数）")]
			LONG,

			/// <summary>
			/// <para>双精度型（64 位浮点型）—字段类型将为双精度型。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型（64 位浮点型）")]
			DOUBLE,

			/// <summary>
			/// <para>日期—字段类型将为日期型。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

		}

		/// <summary>
		/// <para>In Line</para>
		/// </summary>
		public enum IsInlineEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INLINE")]
			INLINE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INLINE")]
			NOT_INLINE,

		}

		/// <summary>
		/// <para>Apportionable</para>
		/// </summary>
		public enum IsApportionableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPORTIONABLE")]
			APPORTIONABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_APPORTIONABLE")]
			NOT_APPORTIONABLE,

		}

		/// <summary>
		/// <para>Is Overridable</para>
		/// </summary>
		public enum IsOverridableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERRIDE")]
			OVERRIDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_OVERRIDABLE")]
			NOT_OVERRIDABLE,

		}

		/// <summary>
		/// <para>Nullable</para>
		/// </summary>
		public enum IsNullableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NULLABLE")]
			NULLABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_NULLABLE")]
			NOT_NULLABLE,

		}

		/// <summary>
		/// <para>Substitution</para>
		/// </summary>
		public enum IsSubstitutionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SUBSTITUTION")]
			SUBSTITUTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_SUBSTITUTION")]
			NOT_SUBSTITUTION,

		}

#endregion
	}
}
