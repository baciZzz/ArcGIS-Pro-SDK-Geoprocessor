using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Add Field To Analysis Layer</para>
	/// <para>向分析图层添加字段</para>
	/// <para>用于向网络分析图层的子图层添加字段。</para>
	/// </summary>
	public class AddFieldToAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>要添加新字段的网络分析图层。</para>
		/// </param>
		/// <param name="SubLayer">
		/// <para>Sub Layer</para>
		/// <para>要添加新字段的网络分析图层的子图层。</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>要添加到网络分析图层的指定子图层中的字段名称。</para>
		/// </param>
		/// <param name="FieldType">
		/// <para>Field Type</para>
		/// <para>指定在创建新字段时所使用的字段类型。</para>
		/// <para>长整型（大整数）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
		/// <para>浮点型（单精度）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para>双精度型（双精度）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>短整型（小整数）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
		/// <para>Blob（二进制数据）—此字段类型将为 BLOB。 BLOB 字段支持存储为长度较长的一系列二进制数的数据。 您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </param>
		public AddFieldToAnalysisLayer(object InNetworkAnalysisLayer, object SubLayer, object FieldName, object FieldType)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.SubLayer = SubLayer;
			this.FieldName = FieldName;
			this.FieldType = FieldType;
		}

		/// <summary>
		/// <para>Tool Display Name : 向分析图层添加字段</para>
		/// </summary>
		public override string DisplayName() => "向分析图层添加字段";

		/// <summary>
		/// <para>Tool Name : AddFieldToAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "AddFieldToAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.AddFieldToAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.AddFieldToAnalysisLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, SubLayer, FieldName, FieldType, FieldPrecision!, FieldScale!, FieldLength!, FieldAlias!, FieldIsNullable!, OutputLayer! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>要添加新字段的网络分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Sub Layer</para>
		/// <para>要添加新字段的网络分析图层的子图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubLayer { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>要添加到网络分析图层的指定子图层中的字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定在创建新字段时所使用的字段类型。</para>
		/// <para>长整型（大整数）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
		/// <para>浮点型（单精度）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para>双精度型（双精度）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>短整型（小整数）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
		/// <para>Blob（二进制数据）—此字段类型将为 BLOB。 BLOB 字段支持存储为长度较长的一系列二进制数的数据。 您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>Field Precision</para>
		/// <para>可存储在字段中的位数。 所有位数都被计算在内，无论其位于小数点的哪一侧。</para>
		/// <para>参数值仅对数值字段类型有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldPrecision { get; set; }

		/// <summary>
		/// <para>Field Scale</para>
		/// <para>可存储在字段中的小数位数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldScale { get; set; }

		/// <summary>
		/// <para>Field Length</para>
		/// <para>字段长度。 它为字段的每条记录设置最大允许字符数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldLength { get; set; }

		/// <summary>
		/// <para>Field Alias</para>
		/// <para>字段名称的备用名称。 此名称用于描述含义隐晦的字段名称。 此参数仅适用于地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FieldAlias { get; set; }

		/// <summary>
		/// <para>Field IsNullable</para>
		/// <para>指定该字段是否可包含空值。 空值不同于零字段或空字段，仅支持地理数据库中的字段。</para>
		/// <para>选中 - 字段可包含空值。 这是默认设置。</para>
		/// <para>未选中 - 字段不可包含空值。</para>
		/// <para><see cref="FieldIsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FieldIsNullable { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Sublayer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFieldToAnalysisLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本")]
			Text,

			/// <summary>
			/// <para>浮点型（单精度）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型（单精度）")]
			FLOAT,

			/// <summary>
			/// <para>双精度型（双精度）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型（双精度）")]
			DOUBLE,

			/// <summary>
			/// <para>短整型（小整数）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（小整数）")]
			SHORT,

			/// <summary>
			/// <para>长整型（大整数）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（大整数）")]
			LONG,

			/// <summary>
			/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>Blob（二进制数据）—此字段类型将为 BLOB。 BLOB 字段支持存储为长度较长的一系列二进制数的数据。 您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob（二进制数据）")]
			BLOB,

		}

		/// <summary>
		/// <para>Field IsNullable</para>
		/// </summary>
		public enum FieldIsNullableEnum 
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
			[Description("NON_NULLABLE")]
			NON_NULLABLE,

		}

#endregion
	}
}
