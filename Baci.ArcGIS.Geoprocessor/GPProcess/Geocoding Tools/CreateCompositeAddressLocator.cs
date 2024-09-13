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
	/// <para>Create Composite Address Locator</para>
	/// <para>创建复合地址定位器</para>
	/// <para>创建复合地址定位器。一个复合定位器由两个或更多的定位器组成，这些定位器允许根据多个定位器来匹配地址。</para>
	/// </summary>
	public class CreateCompositeAddressLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAddressLocators">
		/// <para>Address Locators</para>
		/// <para>参与地址定位器的顺序决定候选项的搜素方式以及地址的匹配方式。对单个地址进行地理编码时，除非为定位器指定了选择条件，否则将根据所有参与地址定位器来匹配地址。系统将根据参与地址定位器的列出顺序来显示找到的所有候选项。对地址表进行地理编码时，地址将自动与在前几个参与地址定位器中找到的第一个最佳候选项匹配。如果地址匹配失败，它将回退到列表中后面的定位器。</para>
		/// <para>每个参与定位器都需要一个参考名称。该定位器名称即复合定位器所引用的名称。该名称不应包含空格或特殊符号。其最大长度为 14 个字符。</para>
		/// </param>
		/// <param name="InFieldMap">
		/// <para>Field Map</para>
		/// <para>每个参与定位器所使用的输入字段与复合定位器的输入字段之间的映射。</para>
		/// <para>由参与定位器生成的字段和字段内容。字段映射部分列出了所有的唯一输入字段，展开后，可看到每个参与地址定位器的所有输入字段（子字段）的列表。这些字段是复合地址定位器的输入字段。如果由于唯一名称是根据参与地址定位器进行填充的，因而产生了重复的字段（如 ZIP 和邮政编码），那么您可以对子字段进行分组，方法是将子字段拖放到相应的字段，或使用上箭头或下箭头按钮来移动子字段。</para>
		/// </param>
		/// <param name="OutCompositeAddressLocator">
		/// <para>Output Composite Address Locator</para>
		/// <para>要创建的复合地址定位器。ArcGIS Pro 仅支持保存在文件文件夹中的定位器。</para>
		/// </param>
		public CreateCompositeAddressLocator(object InAddressLocators, object InFieldMap, object OutCompositeAddressLocator)
		{
			this.InAddressLocators = InAddressLocators;
			this.InFieldMap = InFieldMap;
			this.OutCompositeAddressLocator = OutCompositeAddressLocator;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建复合地址定位器</para>
		/// </summary>
		public override string DisplayName() => "创建复合地址定位器";

		/// <summary>
		/// <para>Tool Name : CreateCompositeAddressLocator</para>
		/// </summary>
		public override string ToolName() => "CreateCompositeAddressLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.CreateCompositeAddressLocator</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.CreateCompositeAddressLocator";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAddressLocators, InFieldMap, InSelectionCriteria, OutCompositeAddressLocator };

		/// <summary>
		/// <para>Address Locators</para>
		/// <para>参与地址定位器的顺序决定候选项的搜素方式以及地址的匹配方式。对单个地址进行地理编码时，除非为定位器指定了选择条件，否则将根据所有参与地址定位器来匹配地址。系统将根据参与地址定位器的列出顺序来显示找到的所有候选项。对地址表进行地理编码时，地址将自动与在前几个参与地址定位器中找到的第一个最佳候选项匹配。如果地址匹配失败，它将回退到列表中后面的定位器。</para>
		/// <para>每个参与定位器都需要一个参考名称。该定位器名称即复合定位器所引用的名称。该名称不应包含空格或特殊符号。其最大长度为 14 个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object InAddressLocators { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>每个参与定位器所使用的输入字段与复合定位器的输入字段之间的映射。</para>
		/// <para>由参与定位器生成的字段和字段内容。字段映射部分列出了所有的唯一输入字段，展开后，可看到每个参与地址定位器的所有输入字段（子字段）的列表。这些字段是复合地址定位器的输入字段。如果由于唯一名称是根据参与地址定位器进行填充的，因而产生了重复的字段（如 ZIP 和邮政编码），那么您可以对子字段进行分组，方法是将子字段拖放到相应的字段，或使用上箭头或下箭头按钮来移动子字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldMapping()]
		public object InFieldMap { get; set; }

		/// <summary>
		/// <para>Selection criteria</para>
		/// <para>每个参与定位器的选择条件。每个参与定位器仅支持一个选择条件。</para>
		/// <para>构建复合地址定位器时，您可能希望基于输入地址字段的值来指定所使用的地址定位器。例如，如果复合地址定位器使用包含某特定城市街道数据的定位器，则您可能希望过滤掉没有此特定城市名称的所有地址。使用选择条件将会排除不满足特定地址条件的参与地址定位器，从而提高地理编码过程的效率。例如，如果为某个街道地址定位器指定了选择条件 &quot;City&quot; = &apos;Atlanta&apos;，则只有包含城市名“Atlanta”的地址才会根据此定位器进行地理编码。</para>
		/// <para>要指定选择条件，请在选择条件列中单击要应用此条件的地址定位器旁边的框。可在文本框中输入一个表达式（例如 &quot;City&quot; = &apos;Atlanta&apos;）或单击 ... 按钮打开指定定位器选择条件 对话框并定义相应的条件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object InSelectionCriteria { get; set; }

		/// <summary>
		/// <para>Output Composite Address Locator</para>
		/// <para>要创建的复合地址定位器。ArcGIS Pro 仅支持保存在文件文件夹中的定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object OutCompositeAddressLocator { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateCompositeAddressLocator SetEnviroment(object configKeyword = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
