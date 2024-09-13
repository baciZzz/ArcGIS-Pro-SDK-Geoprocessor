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
	/// <para>Geocode Addresses</para>
	/// <para>地理编码地址</para>
	/// <para>对地址表进行地理编码。 此过程需要一个存储有要进行地理编码的地址的表和一个地址定位器或复合地址定位器。 此工具根据定位器来匹配存储的地址并将每个输入记录的结果保存在新的点要素类中。 使用 ArcGIS World Geocoding Service 时，此操作可能会消耗配额。</para>
	/// </summary>
	public class GeocodeAddresses : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要对其进行地理编码的地址表。</para>
		/// </param>
		/// <param name="AddressLocator">
		/// <para>Input Address Locator</para>
		/// <para>要用于对地址表进行地理编码的地址定位器。在定位器路径末尾的定位器名称后包含 .loc 扩展名为可选项。</para>
		/// </param>
		/// <param name="InAddressFields">
		/// <para>Input Address Fields</para>
		/// <para>地址定位器所使用的地址字段与输入地址表中的字段之间的映射。 如果完整地址储存在输入表的一个字段中，例如 303 Peachtree St NE, Atlanta, GA 30308，请选择单个字段。 如果将常规美国地址的输入地址拆分成 Address、City、State 和 ZIP 等多个字段，请选择多个字段。 如果将完整地址和国家/地区拆分为多个字段，例如 Address (303 Peachtree St NE, Atlanta, GA 30308) 和 Country (USA)，则选择单个字段和国家/地区字段。</para>
		/// <para>某些定位器支持多个输入地址字段，例如 Address、Address2 和 Address3。 在此情况下，可以将地址组件分为多个字段，然后在进行地理编码时将地址字段连接在一起。 例如，跨三个字段的 100、Main st 和 Apt 140，或者跨两个字段的 100 Main st 和 Apt 140，在进行地理编码时，都将成为 100 Main st Apt 140。</para>
		/// <para>如果不想将地址定位器所使用的可选输入地址字段映射到输入地址表中的字段，请使用 &lt;None&gt; 来代替字段名，以此指定不存在任何映射。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>经过地理编码的输出要素类。</para>
		/// <para>由于 shapefile 限制，系统不支持将输出保存为 shapefile 格式。</para>
		/// </param>
		public GeocodeAddresses(object InTable, object AddressLocator, object InAddressFields, object OutFeatureClass)
		{
			this.InTable = InTable;
			this.AddressLocator = AddressLocator;
			this.InAddressFields = InAddressFields;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 地理编码地址</para>
		/// </summary>
		public override string DisplayName() => "地理编码地址";

		/// <summary>
		/// <para>Tool Name : GeocodeAddresses</para>
		/// </summary>
		public override string ToolName() => "GeocodeAddresses";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.GeocodeAddresses</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.GeocodeAddresses";

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
		public override object[] Parameters() => new object[] { InTable, AddressLocator, InAddressFields, OutFeatureClass, OutRelationshipType!, Country!, LocationType!, Category!, OutputFields! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要对其进行地理编码的地址表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_gt_tables")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Address Locator</para>
		/// <para>要用于对地址表进行地理编码的地址定位器。在定位器路径末尾的定位器名称后包含 .loc 扩展名为可选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object AddressLocator { get; set; }

		/// <summary>
		/// <para>Input Address Fields</para>
		/// <para>地址定位器所使用的地址字段与输入地址表中的字段之间的映射。 如果完整地址储存在输入表的一个字段中，例如 303 Peachtree St NE, Atlanta, GA 30308，请选择单个字段。 如果将常规美国地址的输入地址拆分成 Address、City、State 和 ZIP 等多个字段，请选择多个字段。 如果将完整地址和国家/地区拆分为多个字段，例如 Address (303 Peachtree St NE, Atlanta, GA 30308) 和 Country (USA)，则选择单个字段和国家/地区字段。</para>
		/// <para>某些定位器支持多个输入地址字段，例如 Address、Address2 和 Address3。 在此情况下，可以将地址组件分为多个字段，然后在进行地理编码时将地址字段连接在一起。 例如，跨三个字段的 100、Main st 和 Apt 140，或者跨两个字段的 100 Main st 和 Apt 140，在进行地理编码时，都将成为 100 Main st Apt 140。</para>
		/// <para>如果不想将地址定位器所使用的可选输入地址字段映射到输入地址表中的字段，请使用 &lt;None&gt; 来代替字段名，以此指定不存在任何映射。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		public object InAddressFields { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>经过地理编码的输出要素类。</para>
		/// <para>由于 shapefile 限制，系统不支持将输出保存为 shapefile 格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_geodatabaseItems_featureClasses")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Dynamic Output Feature Class</para>
		/// <para>参数在 ArcGIS Pro 中处于非活动状态。 保留它是为了支持 ArcGIS Desktop 向后兼容。</para>
		/// <para><see cref="OutRelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutRelationshipType { get; set; } = "false";

		/// <summary>
		/// <para>Country</para>
		/// <para>此参数可用于支持国家/地区参数的定位器，并将地理编码限制在所选国家/地区。 选择一个国家/地区将在大多数情况下提高地理编码的准确性。 当为输入地址字段参数选择单个字段和国家/地区字段，并在映射表示国家的字段时将输入表参数值用于输入地址字段参数值的 Country 字段，输入表参数值中的国家/地区值将覆盖国家/地区参数。</para>
		/// <para>这仅限于所选的一个或多个国家/地区。 如果未指定国家/地区，则使用定位器的所有受支持国家/地区执行地理编码。</para>
		/// <para>国家/地区参数不适用于所有定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Country { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>用于指定 PointAddress 匹配的首选输出几何。 此参数的选项是路径位置（街道位置的一侧），可用于路径或表示地址屋顶或宗地质心的地址位置。 如果数据中不存在首选位置，则将返回默认位置。 对于 Addr_type=PointAddress 的地理编码结果，x,y 属性值用于描述沿着街道的地址的坐标，而 DisplayX 和 DisplayY 值用于描述屋顶或建筑物质心坐标。</para>
		/// <para>此参数并非支持所有定位器。</para>
		/// <para>地址位置—将返回地理编码结果的几何，该几何可以表示地址位置，例如屋顶位置、宗地质心或前门。</para>
		/// <para>路径位置—将返回地理编码结果的几何，该几何表示靠近街道一侧的位置，可用于车辆配送。 这是默认设置。</para>
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
		/// <para>有关类别过滤的详细信息，请参阅 ArcGIS REST API Web 帮助。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Category { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>指定将在地理编码结果中返回的定位器输出字段。</para>
		/// <para>此参数可与使用创建定位器工具或创建要素定位器工具创建的输入定位器一起使用，这些定位器存储在磁盘上或已发布到 Enterprise 10.9 或更高版本。 包含至少一个使用创建地址定位器工具创建的定位器的复合定位器不支持此参数。</para>
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
		public GeocodeAddresses SetEnviroment(object? configKeyword = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dynamic Output Feature Class</para>
		/// </summary>
		public enum OutRelationshipTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DYNAMIC")]
			DYNAMIC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("STATIC")]
			STATIC,

		}

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>路径位置—将返回地理编码结果的几何，该几何表示靠近街道一侧的位置，可用于车辆配送。 这是默认设置。</para>
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
