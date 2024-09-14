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
	/// <para>Geocode Locations From Table</para>
	/// <para>对表格中的位置进行地理编码</para>
	/// <para>此工具使用在 ArcGIS Enterprise 门户上托管的定位器对托管表格进行地理编码，可创建包含地理编码结果的托管要素图层。</para>
	/// </summary>
	public class GeocodeLocationsFromTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>门户中的表格，其中包含要进行地理编码的地址或地点。</para>
		/// </param>
		/// <param name="InAddressLocator">
		/// <para>Address Locator</para>
		/// <para>将用于对门户的输入表格进行地理编码的门户定位器。</para>
		/// <para>可以从活动门户上的已填充定位器列表中选择一个定位器，或者浏览活动门户以搜索其他可用定位器。 默认情况下，已在活动门户中设置为实用程序服务的定位器将可用。 如果您要使用的门户定位器未包含在填充列表中，可请求您的门户管理员将此定位器添加为门户实用程序服务，并针对批量地理编码配置此定位器。</para>
		/// <para>ArcGIS World Geocoding Service 已针对此工具禁用。 如果想要使用 ArcGIS World Geocoding Service，请使用地理编码地址工具。</para>
		/// </param>
		/// <param name="AddressFields">
		/// <para>Address Field Mapping</para>
		/// <para>定位器所使用的地址字段与输入地址表中的字段之间的映射。 如果完整地址储存在输入表的一个字段中，例如 303 Peachtree St NE, Atlanta, GA 30308，请选择单个字段。 如果将常规美国地址的输入地址拆分成 Address、City、State 和 ZIP 等多个字段，请选择多个字段。 如果将完整地址 (303 Peachtree St NE, Atlanta, GA 30308) 和国家/地区 (USA) 拆分为多个字段（例如 Address 和 Country），则选择单个字段和国家/地区字段。</para>
		/// <para>某些定位器支持多个输入地址字段，例如 Address、Address2 和 Address3。 在此情况下，可以将地址组件分为多个字段，然后在进行地理编码时将地址字段连接在一起。 例如，跨三个字段的 100、Main St 和 Apt 140，或者跨两个字段的 100 Main St 和 Apt 140，在进行地理编码时，都将成为 100 Main St Apt 140。</para>
		/// <para>如果不想将定位器所使用的可选输入地址字段映射到输入地址表中的字段，请使用 &lt;无&gt; 来代替字段名，以此指定不存在任何映射。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Feature Layer Name</para>
		/// <para>将在门户上创建的输出地理编码要素图层的名称。</para>
		/// </param>
		public GeocodeLocationsFromTable(object InTable, object InAddressLocator, object AddressFields, object OutputName)
		{
			this.InTable = InTable;
			this.InAddressLocator = InAddressLocator;
			this.AddressFields = AddressFields;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : 对表格中的位置进行地理编码</para>
		/// </summary>
		public override string DisplayName() => "对表格中的位置进行地理编码";

		/// <summary>
		/// <para>Tool Name : GeocodeLocationsFromTable</para>
		/// </summary>
		public override string ToolName() => "GeocodeLocationsFromTable";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.GeocodeLocationsFromTable</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.GeocodeLocationsFromTable";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, InAddressLocator, AddressFields, OutputName, Country!, LocationType!, Category!, OutputLayer!, OutputFields! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>门户中的表格，其中包含要进行地理编码的地址或地点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_glft_tables")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Address Locator</para>
		/// <para>将用于对门户的输入表格进行地理编码的门户定位器。</para>
		/// <para>可以从活动门户上的已填充定位器列表中选择一个定位器，或者浏览活动门户以搜索其他可用定位器。 默认情况下，已在活动门户中设置为实用程序服务的定位器将可用。 如果您要使用的门户定位器未包含在填充列表中，可请求您的门户管理员将此定位器添加为门户实用程序服务，并针对批量地理编码配置此定位器。</para>
		/// <para>ArcGIS World Geocoding Service 已针对此工具禁用。 如果想要使用 ArcGIS World Geocoding Service，请使用地理编码地址工具。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InAddressLocator { get; set; }

		/// <summary>
		/// <para>Address Field Mapping</para>
		/// <para>定位器所使用的地址字段与输入地址表中的字段之间的映射。 如果完整地址储存在输入表的一个字段中，例如 303 Peachtree St NE, Atlanta, GA 30308，请选择单个字段。 如果将常规美国地址的输入地址拆分成 Address、City、State 和 ZIP 等多个字段，请选择多个字段。 如果将完整地址 (303 Peachtree St NE, Atlanta, GA 30308) 和国家/地区 (USA) 拆分为多个字段（例如 Address 和 Country），则选择单个字段和国家/地区字段。</para>
		/// <para>某些定位器支持多个输入地址字段，例如 Address、Address2 和 Address3。 在此情况下，可以将地址组件分为多个字段，然后在进行地理编码时将地址字段连接在一起。 例如，跨三个字段的 100、Main St 和 Apt 140，或者跨两个字段的 100 Main St 和 Apt 140，在进行地理编码时，都将成为 100 Main St Apt 140。</para>
		/// <para>如果不想将定位器所使用的可选输入地址字段映射到输入地址表中的字段，请使用 &lt;无&gt; 来代替字段名，以此指定不存在任何映射。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		public object AddressFields { get; set; }

		/// <summary>
		/// <para>Output Feature Layer Name</para>
		/// <para>将在门户上创建的输出地理编码要素图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Country</para>
		/// <para>搜索地理编码地址的一个或多个国家/地区。</para>
		/// <para>此参数可用于支持国家/地区参数的定位器，并将地理编码限制在所选国家/地区。 选择一个国家/地区将在大多数情况下提高地理编码的准确性。 当您在地址字段映射中选择单个字段和国家/地区字段，并将输入表参数中代表国家/地区的字段映射到地址字段映射中的 Country 字段时，输入表参数中的国家/地区值将覆盖国家/地区参数。</para>
		/// <para>这仅限于所选的一个或多个国家/地区。 如果未指定国家/地区，则使用定位器的所有受支持国家/地区执行地理编码。</para>
		/// <para>国家/地区参数不适用于所有定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Country { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>用于指定将返回的 PointAddress 匹配的首选输出几何。 此参数的选项包括路由位置（可用于路由的街道位置侧）和地址位置（表示地址屋顶或宗地质心的位置）。 如果数据中不存在首选位置，则将返回默认位置。 对于 Addr_type=PointAddress 的地理编码结果，x,y 属性值用于描述沿着街道的地址的坐标，而 DisplayX 和 DisplayY 值用于描述屋顶或建筑物质心坐标。</para>
		/// <para>此参数并非支持所有定位器。</para>
		/// <para>地址位置—将返回地理编码结果的几何，该几何可以表示地址位置，例如屋顶位置、宗地质心或前门。</para>
		/// <para>路径位置—将返回表示靠近街道一侧（可用于车辆配送）的位置的地理编码结果的几何。 这是默认设置。</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocationType { get; set; } = "ROUTING_LOCATION";

		/// <summary>
		/// <para>Category</para>
		/// <para>限制定位器搜索的地点类型，从而消除误报匹配并可能加快搜索过程的速度。 如果未使用任何类别，将使用所有支持的类别执行地理编码。 并非所有位置和国家/地区都支持所有类别值。 通常，该参数可以用于以下几个方面：</para>
		/// <para>将匹配限制到特定地点类型或地址级别</para>
		/// <para>避免回退匹配到不需要的地址级别</para>
		/// <para>消除坐标搜索的歧义</para>
		/// <para>此参数并非支持所有定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Category { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>指定将在地理编码结果中返回的定位器输出字段。</para>
		/// <para>此参数可与使用创建定位器工具或创建要素定位器工具创建的输入定位器一起使用，这些定位器已发布到 Enterprise 10.9 或更高版本。 包含至少一个使用创建地址定位器工具创建的定位器的复合定位器不支持此参数。</para>
		/// <para>全部—在地理编码结果中包含所有可用的定位器输出字段。 这是默认设置。</para>
		/// <para>仅位置—在地理编码结果中存储 Shape 字段。 输入表参数中的原始字段名称与其原始字段名称一起保留。</para>
		/// <para>最小化—添加以下字段，用于描述位置以及其与地理编码结果中定位器中的信息的匹配程度：Shape、Status、Score、Match_type、Match_addr 和 Addr_type。 保留输入表参数中的原始字段名称。</para>
		/// <para><see cref="OutputFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Optional parameters")]
		public object? OutputFields { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeocodeLocationsFromTable SetEnviroment(object? outputCoordinateSystem = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>路径位置—将返回表示靠近街道一侧（可用于车辆配送）的位置的地理编码结果的几何。 这是默认设置。</para>
			/// </summary>
			[GPValue("ROUTING_LOCATION")]
			[Description("路径位置")]
			Routing_location,

			/// <summary>
			/// <para>地址位置—将返回地理编码结果的几何，该几何可以表示地址位置，例如屋顶位置、宗地质心或前门。</para>
			/// </summary>
			[GPValue("ADDRESS_LOCATION")]
			[Description("地址位置")]
			Address_location,

		}

		/// <summary>
		/// <para>Output Fields</para>
		/// </summary>
		public enum OutputFieldsEnum 
		{
			/// <summary>
			/// <para>全部—在地理编码结果中包含所有可用的定位器输出字段。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>最小化—添加以下字段，用于描述位置以及其与地理编码结果中定位器中的信息的匹配程度：Shape、Status、Score、Match_type、Match_addr 和 Addr_type。 保留输入表参数中的原始字段名称。</para>
			/// </summary>
			[GPValue("MINIMAL")]
			[Description("最小化")]
			Minimal,

			/// <summary>
			/// <para>仅位置—在地理编码结果中存储 Shape 字段。 输入表参数中的原始字段名称与其原始字段名称一起保留。</para>
			/// </summary>
			[GPValue("LOCATION_ONLY")]
			[Description("仅位置")]
			Location_Only,

		}

#endregion
	}
}
