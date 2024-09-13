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
	/// <para>Create Feature Locator</para>
	/// <para>创建要素定位器</para>
	/// <para>使用参考数据创建定位器，该参考数据包含在单个字段中存储的每个要素的唯一名称或值。 使用此工具创建的定位器具有广泛的应用。 可使用该定位器搜索要素的名称或唯一属性，例如水表、地名简称、手机信号塔或用于标识位置的字母数字字符串（例如，N1N115）。</para>
	/// </summary>
	public class CreateFeatureLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将用于创建定位器的参考数据要素类或要素图层。</para>
		/// <para>支持将表示为服务的要素类数据类型用作参考数据。</para>
		/// <para>如果为参考数据定义了定义查询或存在选定要素，则在创建定位器时，仅包含查询要素和所选要素。</para>
		/// <para>如果使用包含数百万个要素的参考数据创建地址定位器，则包含临时目录的驱动上的可用磁盘空间必须至少为数据大小的 3 到 4 倍，原因是在将定位器复制到输出位置之前，需将用于构建定位器的文件写入此位置。 如果没有足够的磁盘空间，则一旦空间不足，工具将失败。 此外，在创建大型定位器时，计算机必须具备足够的 RAM，才能处理占用较大内存的进程。</para>
		/// </param>
		/// <param name="SearchFields">
		/// <para>Search Fields</para>
		/// <para>将参考数据字段映射到用于搜索输入要素参数的字段。 名称旁带有星号 (*) 的字段为必填字段。 所选字段将编入索引并用于搜索。</para>
		/// </param>
		/// <param name="OutputLocator">
		/// <para>Output Locator</para>
		/// <para>要在文件夹中创建的输出定位器文件。 创建定位器后，可以在定位器设置中修改其他属性和选项。</para>
		/// </param>
		public CreateFeatureLocator(object InFeatures, object SearchFields, object OutputLocator)
		{
			this.InFeatures = InFeatures;
			this.SearchFields = SearchFields;
			this.OutputLocator = OutputLocator;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建要素定位器</para>
		/// </summary>
		public override string DisplayName() => "创建要素定位器";

		/// <summary>
		/// <para>Tool Name : CreateFeatureLocator</para>
		/// </summary>
		public override string ToolName() => "CreateFeatureLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.CreateFeatureLocator</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.CreateFeatureLocator";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, SearchFields, OutputLocator, LocatorFields! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将用于创建定位器的参考数据要素类或要素图层。</para>
		/// <para>支持将表示为服务的要素类数据类型用作参考数据。</para>
		/// <para>如果为参考数据定义了定义查询或存在选定要素，则在创建定位器时，仅包含查询要素和所选要素。</para>
		/// <para>如果使用包含数百万个要素的参考数据创建地址定位器，则包含临时目录的驱动上的可用磁盘空间必须至少为数据大小的 3 到 4 倍，原因是在将定位器复制到输出位置之前，需将用于构建定位器的文件写入此位置。 如果没有足够的磁盘空间，则一旦空间不足，工具将失败。 此外，在创建大型定位器时，计算机必须具备足够的 RAM，才能处理占用较大内存的进程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Search Fields</para>
		/// <para>将参考数据字段映射到用于搜索输入要素参数的字段。 名称旁带有星号 (*) 的字段为必填字段。 所选字段将编入索引并用于搜索。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		[xmlserialize(Xml = "<GPFieldInfoDomain xsi:type='typens:GPFieldInfoDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'><GPCodedValueDomain xsi:type='typens:GPCodedValueDomain'><GPDomainPropertiesArray xsi:type='typens:ArrayOfGPCodedValueDomainProperty'><GPCodedValueDomainProperty xsi:type='typens:GPCodedValueDomainProperty'><Name>&lt;None&gt;</Name><Value xsi:type='typens:Field'><Name>&lt;None&gt;</Name><Type>esriFieldTypeInteger</Type><IsNullable>true</IsNullable><Length>0</Length><Precision>0</Precision><Scale>0</Scale></Value></GPCodedValueDomainProperty></GPDomainPropertiesArray></GPCodedValueDomain></GPFieldInfoDomain>")]
		public object SearchFields { get; set; } = "*Name <None> VISIBLE NONE";

		/// <summary>
		/// <para>Output Locator</para>
		/// <para>要在文件夹中创建的输出定位器文件。 创建定位器后，可以在定位器设置中修改其他属性和选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object OutputLocator { get; set; }

		/// <summary>
		/// <para>Additional Locator Fields</para>
		/// <para>映射范围和等级的附加字段（如果数据中存在）。 Rank 字段用于对模糊不清的查询的结果或具有相同名称和分数的候选项进行排序。 范围字段有助于设置地图范围以显示经过地理编码的结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldInfo()]
		[xmlserialize(Xml = "<GPFieldInfoDomain xsi:type='typens:GPFieldInfoDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'><GPCodedValueDomain xsi:type='typens:GPCodedValueDomain'><GPDomainPropertiesArray xsi:type='typens:ArrayOfGPCodedValueDomainProperty'><GPCodedValueDomainProperty xsi:type='typens:GPCodedValueDomainProperty'><Name>&lt;None&gt;</Name><Value xsi:type='typens:Field'><Name>&lt;None&gt;</Name><Type>esriFieldTypeInteger</Type><IsNullable>true</IsNullable><Length>0</Length><Precision>0</Precision><Scale>0</Scale></Value></GPCodedValueDomainProperty></GPDomainPropertiesArray></GPCodedValueDomain></GPFieldInfoDomain>")]
		[Category("Optional parameters")]
		public object? LocatorFields { get; set; } = "Rank <None> VISIBLE NONE;'Min X' <None> VISIBLE NONE;'Max X' <None> VISIBLE NONE;'Min Y' <None> VISIBLE NONE;'Max Y' <None> VISIBLE NONE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFeatureLocator SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
