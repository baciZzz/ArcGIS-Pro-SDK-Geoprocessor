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
	/// <para>Reverse Geocode</para>
	/// <para>反向地理编码</para>
	/// <para>基于要素类中的点位置创建地址。 在反向地理编码过程中，根据指定的搜索距离搜索点位置的最近地址或交叉点。 使用 ArcGIS World Geocoding Service 时，此操作可能会消耗配额。</para>
	/// </summary>
	public class ReverseGeocode : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Feature Class or layer</para>
		/// <para>将根据要素的点位置从中返回匹配的地点或地址的点要素类或图层。</para>
		/// </param>
		/// <param name="InAddressLocator">
		/// <para>Input Address Locator</para>
		/// <para>将用于对输入要素类或图层进行反向地理编码的定位器。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>搜索点位置的最近地址或交叉点时将使用的距离。 某些定位器使用不支持覆盖搜索距离参数的优化距离值。</para>
		/// <para>此参数仅适用于使用创建地址定位器工具构建的定位器，或包含使用创建地址定位器工具构建的定位器的复合定位器。</para>
		/// </param>
		public ReverseGeocode(object InFeatures, object InAddressLocator, object OutFeatureClass, object SearchDistance)
		{
			this.InFeatures = InFeatures;
			this.InAddressLocator = InAddressLocator;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 反向地理编码</para>
		/// </summary>
		public override string DisplayName() => "反向地理编码";

		/// <summary>
		/// <para>Tool Name : ReverseGeocode</para>
		/// </summary>
		public override string ToolName() => "ReverseGeocode";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.ReverseGeocode</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.ReverseGeocode";

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
		public override object[] Parameters() => new object[] { InFeatures, InAddressLocator, OutFeatureClass, AddressType, SearchDistance, FeatureType, LocationType };

		/// <summary>
		/// <para>Input Feature Class or layer</para>
		/// <para>将根据要素的点位置从中返回匹配的地点或地址的点要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Address Locator</para>
		/// <para>将用于对输入要素类或图层进行反向地理编码的定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InAddressLocator { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Address Type</para>
		/// <para>指定是将点的地址以街道地址的形式返回，还是以交叉点地址的形式返回（如果定位器支持交叉点匹配）。</para>
		/// <para>此参数仅适用于使用创建地址定位器工具构建的定位器，或包含使用创建地址定位器工具构建的定位器的复合定位器。</para>
		/// <para>地址—地址将以街道地址的形式返回，或者以输入地址定位器所定义的格式返回。 这是默认设置。</para>
		/// <para>交叉点—地址将以交叉点地址的形式返回。 如果地址定位器支持匹配交叉点地址，则可使用此选项。</para>
		/// <para><see cref="AddressTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AddressType { get; set; } = "ADDRESS";

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>搜索点位置的最近地址或交叉点时将使用的距离。 某些定位器使用不支持覆盖搜索距离参数的优化距离值。</para>
		/// <para>此参数仅适用于使用创建地址定位器工具构建的定位器，或包含使用创建地址定位器工具构建的定位器的复合定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>指定将返回的可能匹配类型。 可选择单个值或多个值。 如果选择单个值，则输入要素类型的搜索容差为 500 米。 如果包括多个值，则将应用要素类型等级表中指定的默认搜索距离。</para>
		/// <para>此参数并非支持所有定位器。</para>
		/// <para>子地址—匹配将限于街道地址（基于代表房屋和建筑物子地址位置的点）。</para>
		/// <para>点地址—匹配将限于街道地址（基于代表房屋和建筑物位置的点）。</para>
		/// <para>宗地—匹配将限于被视为不动产并且可包括一个或多个房屋或其他建筑物的一片土地。 通常会为此匹配类型分配一个地址和宗地标识号。</para>
		/// <para>街道地址—匹配将限于与点地址不同的街道地址，因为门牌号是由数字范围内插的。 街道地址匹配包括匹配街段的门牌号范围，而不包括内插的门牌号值。</para>
		/// <para>街道交叉点—匹配将限于包括街道交叉点和城市以及州和邮政编码信息（可选信息）的街道地址。 这是从街道地址参考数据中获取的，例如 Redlands Blvd &amp; New York St, Redlands, CA, 92373。</para>
		/// <para>街道名称—匹配将限于类似于街道地址，但没有门牌号、行政区域和邮政编码（可选）的街道地址，例如 W Olive Ave, Redlands, CA, 92373。</para>
		/// <para>所在地—匹配将限于代表居民区的地名。</para>
		/// <para>邮政地址—匹配将限于邮政编码。 参考数据是邮政编码点，例如 90210 USA。</para>
		/// <para>感兴趣点—匹配将限于感兴趣点。 参考数据包括行政区域、地名、企业、地标和地理要素，例如星巴克。</para>
		/// <para>距离标记—匹配将限于表示沿某条街道的线性距离的街道地址（通常以公里或英里为单位，且指定了原点位置，如 Mile 25 I-5 N, San Diego, CA）。</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object FeatureType { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>用于指定点地址匹配的首选输出几何。 此参数的选项是街道位置的一侧，可用于路径或表示地址屋顶或宗地质心的位置。 如果数据中不存在首选位置，则将返回默认位置。 对于 Addr_type=PointAddress 的地理编码结果，x,y 属性值用于描述沿着街道的地址的坐标，而 DisplayX 和 DisplayY 值用于描述屋顶或建筑物质心坐标。</para>
		/// <para>此参数并非支持所有定位器。</para>
		/// <para>地址位置—将返回地理编码结果的几何，该几何可以表示地址位置，例如屋顶、建筑物质心或前门。</para>
		/// <para>路径位置—将返回地理编码结果的几何，该几何表示靠近街道一侧的位置，可用于车辆配送。 这是默认设置。</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocationType { get; set; } = "ROUTING_LOCATION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReverseGeocode SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Address Type</para>
		/// </summary>
		public enum AddressTypeEnum 
		{
			/// <summary>
			/// <para>地址—地址将以街道地址的形式返回，或者以输入地址定位器所定义的格式返回。 这是默认设置。</para>
			/// </summary>
			[GPValue("ADDRESS")]
			[Description("地址")]
			Address,

			/// <summary>
			/// <para>交叉点—地址将以交叉点地址的形式返回。 如果地址定位器支持匹配交叉点地址，则可使用此选项。</para>
			/// </summary>
			[GPValue("INTERSECTION")]
			[Description("交叉点")]
			Intersection,

		}

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>点地址—匹配将限于街道地址（基于代表房屋和建筑物位置的点）。</para>
			/// </summary>
			[GPValue("POINT_ADDRESS")]
			[Description("点地址")]
			Point_Address,

			/// <summary>
			/// <para>街道地址—匹配将限于与点地址不同的街道地址，因为门牌号是由数字范围内插的。 街道地址匹配包括匹配街段的门牌号范围，而不包括内插的门牌号值。</para>
			/// </summary>
			[GPValue("STREET_ADDRESS")]
			[Description("街道地址")]
			Street_Address,

			/// <summary>
			/// <para>街道交叉点—匹配将限于包括街道交叉点和城市以及州和邮政编码信息（可选信息）的街道地址。 这是从街道地址参考数据中获取的，例如 Redlands Blvd &amp; New York St, Redlands, CA, 92373。</para>
			/// </summary>
			[GPValue("STREET_INTERSECTION")]
			[Description("街道交叉点")]
			Street_Intersection,

			/// <summary>
			/// <para>街道名称—匹配将限于类似于街道地址，但没有门牌号、行政区域和邮政编码（可选）的街道地址，例如 W Olive Ave, Redlands, CA, 92373。</para>
			/// </summary>
			[GPValue("STREET_NAME")]
			[Description("街道名称")]
			Street_Name,

			/// <summary>
			/// <para>所在地—匹配将限于代表居民区的地名。</para>
			/// </summary>
			[GPValue("LOCALITY")]
			[Description("所在地")]
			Locality,

			/// <summary>
			/// <para>邮政地址—匹配将限于邮政编码。 参考数据是邮政编码点，例如 90210 USA。</para>
			/// </summary>
			[GPValue("POSTAL")]
			[Description("邮政地址")]
			Postal,

			/// <summary>
			/// <para>感兴趣点—匹配将限于感兴趣点。 参考数据包括行政区域、地名、企业、地标和地理要素，例如星巴克。</para>
			/// </summary>
			[GPValue("POINT_OF_INTEREST")]
			[Description("感兴趣点")]
			Point_of_Interest,

			/// <summary>
			/// <para>距离标记—匹配将限于表示沿某条街道的线性距离的街道地址（通常以公里或英里为单位，且指定了原点位置，如 Mile 25 I-5 N, San Diego, CA）。</para>
			/// </summary>
			[GPValue("DISTANCE_MARKER")]
			[Description("距离标记")]
			Distance_Marker,

			/// <summary>
			/// <para>宗地—匹配将限于被视为不动产并且可包括一个或多个房屋或其他建筑物的一片土地。 通常会为此匹配类型分配一个地址和宗地标识号。</para>
			/// </summary>
			[GPValue("PARCEL")]
			[Description("宗地")]
			Parcel,

			/// <summary>
			/// <para>子地址—匹配将限于街道地址（基于代表房屋和建筑物子地址位置的点）。</para>
			/// </summary>
			[GPValue("SUBADDRESS")]
			[Description("子地址")]
			Subaddress,

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
			/// <para>地址位置—将返回地理编码结果的几何，该几何可以表示地址位置，例如屋顶、建筑物质心或前门。</para>
			/// </summary>
			[GPValue("ADDRESS_LOCATION")]
			[Description("地址位置")]
			Address_location,

		}

#endregion
	}
}
