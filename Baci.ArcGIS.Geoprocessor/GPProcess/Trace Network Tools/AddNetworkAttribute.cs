using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Add Network Attribute</para>
	/// <para>添加网络属性</para>
	/// <para>用于向追踪网络中添加网络属性。</para>
	/// </summary>
	public class AddNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>将添加网络属性的输入追踪网络。</para>
		/// </param>
		/// <param name="AttributeName">
		/// <para>Attribute Name</para>
		/// <para>要添加至追踪网络的网络属性的名称。</para>
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
		public AddNetworkAttribute(object InTraceNetwork, object AttributeName, object AttributeType)
		{
			this.InTraceNetwork = InTraceNetwork;
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
		/// <para>Tool Excute Name : tn.AddNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName() => "tn.AddNetworkAttribute";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, AttributeName, AttributeType, IsNullable!, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>将添加网络属性的输入追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Attribute Name</para>
		/// <para>要添加至追踪网络的网络属性的名称。</para>
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
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

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

#endregion
	}
}
