using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeocodingTools
{
	/// <summary>
	/// <para>Create Locator</para>
	/// <para>创建定位器</para>
	/// <para>创建定位器，以供查找地址或地点位置，将地址或地点表转换为点要素集合，或标识点位置的地址。</para>
	/// </summary>
	public class CreateLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="CountryCode">
		/// <para>Country or Region</para>
		/// <para>指定将于何处将特定于国家/地区的地理编码逻辑应用于定位器的参考数据。</para>
		/// <para>默认值为操作系统的区域设置。 可通过从列表中选择 &lt;按数据中所定义的方式&gt; 并从字段映射中的数据内映射某一值来对其进行指定，或通过从列表中选择某一国家/地区来将其应用于整个数据集。</para>
		/// <para>它提供了一个国家/地区模板，该模板中包含了显示于字段映射参数中的预期字段名称以便为定位器创建指定的国家/地区。</para>
		/// <para>&lt;按数据中所定义的方式&gt;—在每个要素的参考数据中定义的三位字符国家/地区代码值</para>
		/// <para>美属萨摩亚—美属萨摩亚</para>
		/// <para>澳洲—澳洲</para>
		/// <para>奥地利—奥地利</para>
		/// <para>比利时—比利时</para>
		/// <para>加拿大—加拿大</para>
		/// <para>瑞士—瑞士</para>
		/// <para>德国—德国</para>
		/// <para>西班牙—西班牙</para>
		/// <para>法国—法国</para>
		/// <para>大不列颠—大不列颠</para>
		/// <para>关岛—关岛</para>
		/// <para>北马里亚纳群岛—北马里亚纳群岛</para>
		/// <para>荷兰—荷兰</para>
		/// <para>波多黎各—波多黎各</para>
		/// <para>美属维京群岛—美属维京群岛</para>
		/// <para>美国—美国</para>
		/// <para>美属边疆群岛—美属边疆群岛</para>
		/// </param>
		/// <param name="PrimaryReferenceData">
		/// <para>Primary Table(s)</para>
		/// <para>参考数据要素类及其将用于创建定位器的角色。 每个角色只能使用一个主表。</para>
		/// <para>表示为服务的要素类作为数据类型，支持用作主要参考数据。</para>
		/// <para>如果为主要参考数据定义了定义查询或存在选定要素，则在创建定位器时，仅将包含查询要素和所选要素。</para>
		/// <para>如果使用包含数百万个要素的参考数据创建地址定位器，则包含临时目录的驱动上的可用磁盘空间必须至少为数据大小的 3 到 4 倍，原因是在将定位器复制到输出位置之前，需将用于构建定位器的文件写入此位置。 如果没有足够的磁盘空间，则一旦空间不足，工具将失败。 此外，在创建大型定位器时，计算机必须具备足够的 RAM，才能处理占用较大内存的进程。</para>
		/// </param>
		/// <param name="FieldMapping">
		/// <para>Field Mapping</para>
		/// <para>主参考数据集字段到定位器角色所支持字段的映射。 名称旁带有星号 (*) 的字段是定位器角色的必填字段。 映射主表参数中每个表的相关字段。</para>
		/// <para>如果正在使用的是备用名称表，请映射主表中的连接 ID。</para>
		/// <para>要添加自定义输出字段，请键入自定义输出字段参数中的字段名称。 新的字段将添加至字段映射参数。 然后，您可从主表参数中选择字段，这些字段包含了要纳入地理编码输出的附加值。</para>
		/// </param>
		/// <param name="OutLocator">
		/// <para>Output Locator</para>
		/// <para>输出地址定位器文件。</para>
		/// </param>
		/// <param name="LanguageCode">
		/// <para>Language Code</para>
		/// <para>指定将于何处将特定于语言的地理编码逻辑应用于定位器的参考数据。</para>
		/// <para>若主要参考数据中存在语言代码字段，则提供语言代码可改善地理编码的结果。</para>
		/// <para>可通过从列表中选择 &lt;按数据中所定义的方式&gt; 并从字段映射中的主参考数据内映射某一值来对其进行指定，或通过从列表中选择某一语言来将其应用于整个数据集。</para>
		/// <para>&lt;按数据中所定义的方式&gt;—在每个要素的参考数据中定义的三位字符国家/地区代码值</para>
		/// <para>巴斯克语—巴斯克语</para>
		/// <para>加泰罗尼亚语—加泰罗尼亚语</para>
		/// <para>荷兰语—荷兰语</para>
		/// <para>英语—英语</para>
		/// <para>法语—法语</para>
		/// <para>德语—德语</para>
		/// <para>加利西亚语—加利西亚语</para>
		/// <para>意大利语—意大利语</para>
		/// <para>西班牙语—西班牙语</para>
		/// <para><see cref="LanguageCodeEnum"/></para>
		/// </param>
		public CreateLocator(object CountryCode, object PrimaryReferenceData, object FieldMapping, object OutLocator, object LanguageCode)
		{
			this.CountryCode = CountryCode;
			this.PrimaryReferenceData = PrimaryReferenceData;
			this.FieldMapping = FieldMapping;
			this.OutLocator = OutLocator;
			this.LanguageCode = LanguageCode;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建定位器</para>
		/// </summary>
		public override string DisplayName() => "创建定位器";

		/// <summary>
		/// <para>Tool Name : CreateLocator</para>
		/// </summary>
		public override string ToolName() => "CreateLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.CreateLocator</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.CreateLocator";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise() => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { CountryCode, PrimaryReferenceData, FieldMapping, OutLocator, LanguageCode, AlternatenameTables, AlternateFieldMapping, CustomOutputFields, PrecisionType };

		/// <summary>
		/// <para>Country or Region</para>
		/// <para>指定将于何处将特定于国家/地区的地理编码逻辑应用于定位器的参考数据。</para>
		/// <para>默认值为操作系统的区域设置。 可通过从列表中选择 &lt;按数据中所定义的方式&gt; 并从字段映射中的数据内映射某一值来对其进行指定，或通过从列表中选择某一国家/地区来将其应用于整个数据集。</para>
		/// <para>它提供了一个国家/地区模板，该模板中包含了显示于字段映射参数中的预期字段名称以便为定位器创建指定的国家/地区。</para>
		/// <para>&lt;按数据中所定义的方式&gt;—在每个要素的参考数据中定义的三位字符国家/地区代码值</para>
		/// <para>美属萨摩亚—美属萨摩亚</para>
		/// <para>澳洲—澳洲</para>
		/// <para>奥地利—奥地利</para>
		/// <para>比利时—比利时</para>
		/// <para>加拿大—加拿大</para>
		/// <para>瑞士—瑞士</para>
		/// <para>德国—德国</para>
		/// <para>西班牙—西班牙</para>
		/// <para>法国—法国</para>
		/// <para>大不列颠—大不列颠</para>
		/// <para>关岛—关岛</para>
		/// <para>北马里亚纳群岛—北马里亚纳群岛</para>
		/// <para>荷兰—荷兰</para>
		/// <para>波多黎各—波多黎各</para>
		/// <para>美属维京群岛—美属维京群岛</para>
		/// <para>美国—美国</para>
		/// <para>美属边疆群岛—美属边疆群岛</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CountryCode { get; set; } = "USA";

		/// <summary>
		/// <para>Primary Table(s)</para>
		/// <para>参考数据要素类及其将用于创建定位器的角色。 每个角色只能使用一个主表。</para>
		/// <para>表示为服务的要素类作为数据类型，支持用作主要参考数据。</para>
		/// <para>如果为主要参考数据定义了定义查询或存在选定要素，则在创建定位器时，仅将包含查询要素和所选要素。</para>
		/// <para>如果使用包含数百万个要素的参考数据创建地址定位器，则包含临时目录的驱动上的可用磁盘空间必须至少为数据大小的 3 到 4 倍，原因是在将定位器复制到输出位置之前，需将用于构建定位器的文件写入此位置。 如果没有足够的磁盘空间，则一旦空间不足，工具将失败。 此外，在创建大型定位器时，计算机必须具备足够的 RAM，才能处理占用较大内存的进程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object PrimaryReferenceData { get; set; }

		/// <summary>
		/// <para>Field Mapping</para>
		/// <para>主参考数据集字段到定位器角色所支持字段的映射。 名称旁带有星号 (*) 的字段是定位器角色的必填字段。 映射主表参数中每个表的相关字段。</para>
		/// <para>如果正在使用的是备用名称表，请映射主表中的连接 ID。</para>
		/// <para>要添加自定义输出字段，请键入自定义输出字段参数中的字段名称。 新的字段将添加至字段映射参数。 然后，您可从主表参数中选择字段，这些字段包含了要纳入地理编码输出的附加值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Output Locator</para>
		/// <para>输出地址定位器文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object OutLocator { get; set; }

		/// <summary>
		/// <para>Language Code</para>
		/// <para>指定将于何处将特定于语言的地理编码逻辑应用于定位器的参考数据。</para>
		/// <para>若主要参考数据中存在语言代码字段，则提供语言代码可改善地理编码的结果。</para>
		/// <para>可通过从列表中选择 &lt;按数据中所定义的方式&gt; 并从字段映射中的主参考数据内映射某一值来对其进行指定，或通过从列表中选择某一语言来将其应用于整个数据集。</para>
		/// <para>&lt;按数据中所定义的方式&gt;—在每个要素的参考数据中定义的三位字符国家/地区代码值</para>
		/// <para>巴斯克语—巴斯克语</para>
		/// <para>加泰罗尼亚语—加泰罗尼亚语</para>
		/// <para>荷兰语—荷兰语</para>
		/// <para>英语—英语</para>
		/// <para>法语—法语</para>
		/// <para>德语—德语</para>
		/// <para>加利西亚语—加利西亚语</para>
		/// <para>意大利语—意大利语</para>
		/// <para>西班牙语—西班牙语</para>
		/// <para><see cref="LanguageCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LanguageCode { get; set; }

		/// <summary>
		/// <para>Alternate Name Tables</para>
		/// <para>包含主角色表中备用要素名称的表。</para>
		/// <para>表示为服务的表作为数据类型，支持用作备用名称表。</para>
		/// <para>如果为备用名称表定义了定义查询或存在选定记录，则在创建定位器时，仅将包含查询记录和所选记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Optional parameters")]
		public object AlternatenameTables { get; set; }

		/// <summary>
		/// <para>Alternate Data Field Mapping</para>
		/// <para>将备用名称表字段映射到定位器角色所支持的备用数据字段。 名称旁带有星号 (*) 的字段是定位器角色的必填字段。 映射替代名称表中每个表的相关字段。</para>
		/// <para>如果数据已归一化且主表不包含城市名称值（但备用名称表中包含），则可将 Primary Name Indicator 字段映射至备用名称表中的字段，该字段包含一个值，该值指示了记录是否为主字段（例如，true/false 或 Yes/No）。 如果未映射此字段，则备用名称表中的第一条记录将被用作主值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Optional parameters")]
		public object AlternateFieldMapping { get; set; }

		/// <summary>
		/// <para>Custom Output Fields</para>
		/// <para>将输出字段添加至地理编码结果。 针对此参数指定的值将定义由地理编码结果返回的输出字段的名称；但必须将各个新字段映射至参考数据中的字段。 这个新输出字段将应用于定位器中所使用的全部角色。 如果定位器角色具有左侧和右侧之分，则字段名称的末尾将附加 _left 和 _right。 定位器中支持的最大字段数量为 50。</para>
		/// <para>执行以下操作，将自定义输出字段添加至定位器以在地理编码结果中使用：</para>
		/// <para>键入自定义输出字段的名称。 自定义输出字段名称将被添加至字段映射。</para>
		/// <para>选择参考数据中的字段，该字段包含了要纳入地理编码输出的附加值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Optional parameters")]
		public object CustomOutputFields { get; set; }

		/// <summary>
		/// <para>Precision Type</para>
		/// <para>指定定位器的精度。</para>
		/// <para>使用全球超高或局部超高精度创建的定位器可用于 ArcGIS Pro 2.6 或更高版本以及 Enterprise 10.8.1 或更高版本。</para>
		/// <para>全球超高—精度约为 1 厘米，在全球范围内保持一致。</para>
		/// <para>全球高—精度约为 0.5 米，在全球范围内保持一致。 这是默认设置。</para>
		/// <para>局部超高—将对局部区域使用更高的精度。</para>
		/// <para><see cref="PrecisionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Optional parameters")]
		public object PrecisionType { get; set; } = "GLOBAL_HIGH";

		#region InnerClass

		/// <summary>
		/// <para>Language Code</para>
		/// </summary>
		public enum LanguageCodeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AS_DEFINED_IN_DATA")]
			[Description("<按数据中所定义的方式>")]
			AS_DEFINED_IN_DATA,

			/// <summary>
			/// <para>巴斯克语—巴斯克语</para>
			/// </summary>
			[GPValue("BAQ")]
			[Description("巴斯克语")]
			Basque,

			/// <summary>
			/// <para>加泰罗尼亚语—加泰罗尼亚语</para>
			/// </summary>
			[GPValue("CAT")]
			[Description("加泰罗尼亚语")]
			Catalan,

			/// <summary>
			/// <para>荷兰语—荷兰语</para>
			/// </summary>
			[GPValue("DUT")]
			[Description("荷兰语")]
			Dutch,

			/// <summary>
			/// <para>英语—英语</para>
			/// </summary>
			[GPValue("ENG")]
			[Description("英语")]
			English,

			/// <summary>
			/// <para>法语—法语</para>
			/// </summary>
			[GPValue("FRE")]
			[Description("法语")]
			French,

			/// <summary>
			/// <para>德语—德语</para>
			/// </summary>
			[GPValue("GER")]
			[Description("德语")]
			German,

			/// <summary>
			/// <para>加利西亚语—加利西亚语</para>
			/// </summary>
			[GPValue("GLG")]
			[Description("加利西亚语")]
			Galician,

			/// <summary>
			/// <para>意大利语—意大利语</para>
			/// </summary>
			[GPValue("ITA")]
			[Description("意大利语")]
			Italian,

			/// <summary>
			/// <para>西班牙语—西班牙语</para>
			/// </summary>
			[GPValue("SPA")]
			[Description("西班牙语")]
			Spanish,

		}

		/// <summary>
		/// <para>Precision Type</para>
		/// </summary>
		public enum PrecisionTypeEnum 
		{
			/// <summary>
			/// <para>全球高—精度约为 0.5 米，在全球范围内保持一致。 这是默认设置。</para>
			/// </summary>
			[GPValue("GLOBAL_HIGH")]
			[Description("全球高")]
			Global_High,

			/// <summary>
			/// <para>全球超高—精度约为 1 厘米，在全球范围内保持一致。</para>
			/// </summary>
			[GPValue("GLOBAL_EXTRA_HIGH")]
			[Description("全球超高")]
			Global_Extra_High,

			/// <summary>
			/// <para>局部超高—将对局部区域使用更高的精度。</para>
			/// </summary>
			[GPValue("LOCAL_EXTRA_HIGH")]
			[Description("局部超高")]
			Local_Extra_High,

		}

#endregion
	}
}
