using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Distance From Point</para>
	/// <para>与点的距离</para>
	/// <para>确定图层中的实体是否在坐标位置的一定距离范围内。</para>
	/// </summary>
	[Obsolete()]
	public class DistanceFromPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		/// <param name="InputCoordinateType">
		/// <para>Coordinate Type</para>
		/// <para>十进制度 - 经度优先—十进制度 - 经度优先。 这是默认设置。</para>
		/// <para>十进制度 - 纬度优先—十进制度 - 纬度优先</para>
		/// <para>度分秒 - 经度优先—度分秒 - 经度优先</para>
		/// <para>度分秒 - 纬度优先—度分秒 - 纬度优先</para>
		/// <para>度十进制分 - 经度优先—度十进制分 - 经度优先</para>
		/// <para>度十进制分 - 纬度优先—度十进制分 - 纬度优先</para>
		/// <para>军事格网参考系—军事格网参考系记法</para>
		/// <para>美国国家格网—美国国家格网记法</para>
		/// <para>通用横轴墨卡托投影—通用横轴墨卡托记法</para>
		/// <para><see cref="InputCoordinateTypeEnum"/></para>
		/// </param>
		/// <param name="InputCoordinateString">
		/// <para>Coordinate Location</para>
		/// </param>
		/// <param name="InputSearchDistance">
		/// <para>Distance</para>
		/// </param>
		public DistanceFromPoint(object InputPointFeatures, object InputCoordinateType, object InputCoordinateString, object InputSearchDistance)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.InputCoordinateType = InputCoordinateType;
			this.InputCoordinateString = InputCoordinateString;
			this.InputSearchDistance = InputSearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 与点的距离</para>
		/// </summary>
		public override string DisplayName() => "与点的距离";

		/// <summary>
		/// <para>Tool Name : DistanceFromPoint</para>
		/// </summary>
		public override string ToolName() => "DistanceFromPoint";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DistanceFromPoint</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.DistanceFromPoint";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPointFeatures, InputCoordinateType, InputCoordinateString, InputSearchDistance, InputSearchExpression!, OutputIdList! };

		/// <summary>
		/// <para>Input Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Coordinate Type</para>
		/// <para>十进制度 - 经度优先—十进制度 - 经度优先。 这是默认设置。</para>
		/// <para>十进制度 - 纬度优先—十进制度 - 纬度优先</para>
		/// <para>度分秒 - 经度优先—度分秒 - 经度优先</para>
		/// <para>度分秒 - 纬度优先—度分秒 - 纬度优先</para>
		/// <para>度十进制分 - 经度优先—度十进制分 - 经度优先</para>
		/// <para>度十进制分 - 纬度优先—度十进制分 - 纬度优先</para>
		/// <para>军事格网参考系—军事格网参考系记法</para>
		/// <para>美国国家格网—美国国家格网记法</para>
		/// <para>通用横轴墨卡托投影—通用横轴墨卡托记法</para>
		/// <para><see cref="InputCoordinateTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputCoordinateType { get; set; } = "DD(long/lat)";

		/// <summary>
		/// <para>Coordinate Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputCoordinateString { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object InputSearchDistance { get; set; }

		/// <summary>
		/// <para>Input Search Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? InputSearchExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputIdList { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Coordinate Type</para>
		/// </summary>
		public enum InputCoordinateTypeEnum 
		{
			/// <summary>
			/// <para>十进制度 - 经度优先—十进制度 - 经度优先。 这是默认设置。</para>
			/// </summary>
			[GPValue("DD(long/lat)")]
			[Description("十进制度 - 经度优先")]
			DD,

			/// <summary>
			/// <para>十进制度 - 纬度优先—十进制度 - 纬度优先</para>
			/// </summary>
			[GPValue("DD(lat/long)")]
			[Description("十进制度 - 纬度优先")]
			DD1,

			/// <summary>
			/// <para>度分秒 - 经度优先—度分秒 - 经度优先</para>
			/// </summary>
			[GPValue("DMS(long/lat)")]
			[Description("度分秒 - 经度优先")]
			DMS,

			/// <summary>
			/// <para>度分秒 - 纬度优先—度分秒 - 纬度优先</para>
			/// </summary>
			[GPValue("DMS(lat/long)")]
			[Description("度分秒 - 纬度优先")]
			DMS1,

			/// <summary>
			/// <para>度十进制分 - 经度优先—度十进制分 - 经度优先</para>
			/// </summary>
			[GPValue("DDM(long/lat)")]
			[Description("度十进制分 - 经度优先")]
			DDM,

			/// <summary>
			/// <para>度十进制分 - 纬度优先—度十进制分 - 纬度优先</para>
			/// </summary>
			[GPValue("DDM(lat/long)")]
			[Description("度十进制分 - 纬度优先")]
			DDM1,

			/// <summary>
			/// <para>军事格网参考系—军事格网参考系记法</para>
			/// </summary>
			[GPValue("MGRS")]
			[Description("军事格网参考系")]
			Military_Grid_Reference_System,

			/// <summary>
			/// <para>美国国家格网—美国国家格网记法</para>
			/// </summary>
			[GPValue("USNG")]
			[Description("美国国家格网")]
			US_National_Grid,

			/// <summary>
			/// <para>通用横轴墨卡托投影—通用横轴墨卡托记法</para>
			/// </summary>
			[GPValue("UTM")]
			[Description("通用横轴墨卡托投影")]
			Universal_Transverse_Mercator,

		}

#endregion
	}
}
