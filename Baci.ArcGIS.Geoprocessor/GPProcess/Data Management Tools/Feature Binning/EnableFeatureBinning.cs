using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Enable Feature Binning</para>
	/// <para>启用要素图格</para>
	/// <para>在要素类上启用要素图格。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableFeatureBinning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要启用要素图格的要素类。 仅支持在企业级地理数据库或数据库中存储的点和多点要素类。 数据无法启用版本化或存档。</para>
		/// </param>
		public EnableFeatureBinning(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用要素图格</para>
		/// </summary>
		public override string DisplayName() => "启用要素图格";

		/// <summary>
		/// <para>Tool Name : EnableFeatureBinning</para>
		/// </summary>
		public override string ToolName() => "EnableFeatureBinning";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableFeatureBinning</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableFeatureBinning";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, BinType, BinCoordSys, SummaryStats, GenerateStaticCache, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要启用要素图格的要素类。 仅支持在企业级地理数据库或数据库中存储的点和多点要素类。 数据无法启用版本化或存档。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>指定要启用的图格化类型。 如果正在使用 SAP HANA 数据，仅支持正方形图格。</para>
		/// <para>平六边形—此图格化方案也称为平面几何六边形或平面六边形图格。 切片是六边形方向在顶部具有六边形平边的六边形镶嵌。 这是 Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。</para>
		/// <para>尖六边形—此图格化方案也称为尖几何六边形或尖六边形图格。 切片是六边形方向在顶部具有六边形点的六边形镶嵌。</para>
		/// <para>正方形—此图格化方案也称为几何正方形或正方形图格。 切片是矩形的细分。这是 Db2 和 SAP HANA 数据的默认值。 这是适用于 SAP HANA 数据的唯一图格类型。</para>
		/// <para>Geohash—在此图格化方案中，分块是矩形细分。 由于 Geohash 图格始终使用 WGS 1984 地理坐标系（GCS WGS 1984、EPSG WKID 4326），因此无法为 Geohash 图格指定图格坐标系。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BinType { get; set; }

		/// <summary>
		/// <para>Bin Coordinate Systems</para>
		/// <para>用于可视化已聚合输出要素图层的坐标系。 最多可以选择两个坐标系来可视化输出图层。 默认使用输入要素类的坐标系。 不支持自定义坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object BinCoordSys { get; set; }

		/// <summary>
		/// <para>Summary Statistics</para>
		/// <para>指定将在图格缓存中汇总并存储的统计信息。 统计信息用于符号化图格，并为图格中的所有点提供聚合信息。 汇总统计信息总要素计数 (shape_count) 始终可用。 最多可定义五个其他汇总统计信息。</para>
		/// <para>字段 - 计算汇总统计信息时基于的字段。 支持的字段类型包括短整型、长整型、浮点型和双精度型。</para>
		/// <para>统计类型 - 要为指定字段计算的统计类型。 可以计算图格中所有要素的统计信息。 可用统计类型如下：</para>
		/// <para>平均值 (AVG) - 计算指定字段的平均值</para>
		/// <para>最小值 (MIN) - 查找指定字段的所有记录的最小值</para>
		/// <para>最大值 (MAX) - 查找指定字段的所有记录的最大值</para>
		/// <para>标准差 (STDDEV) - 计算字段的标准差值</para>
		/// <para>总和 (SUM) - 添加指定字段的总计值</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryStats { get; set; }

		/// <summary>
		/// <para>Generate Binning Cache</para>
		/// <para>指定将生成已聚合结果的静态缓存，还是将动态聚合可视化。 无需针对所有细节层次创建缓存。</para>
		/// <para>选中 - 将生成已聚合结果的静态缓存。 要提高性能，建议使用此选项。 但是，对基础数据所做的更改将不会在缓存中更新，除非运行管理要素图格缓存工具。 这是 IBM Db2、Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。 不能为 SAP HANA 数据生成静态缓存。 要为 PostgreSQL 中使用 PostGIS 空间类型的要素类生成静态缓存，必须在数据库中安装 GDAL 库。</para>
		/// <para>未选中 - 将不会生成已聚合结果的静态缓存，并且将动态聚合可视化。 这是适用于 SAP HANA 数据的唯一选项。</para>
		/// <para><see cref="GenerateStaticCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateStaticCache { get; set; } = "true";

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>平六边形—此图格化方案也称为平面几何六边形或平面六边形图格。 切片是六边形方向在顶部具有六边形平边的六边形镶嵌。 这是 Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。</para>
			/// </summary>
			[GPValue("FLAT_HEXAGON")]
			[Description("平六边形")]
			Flat_hexagon,

			/// <summary>
			/// <para>尖六边形—此图格化方案也称为尖几何六边形或尖六边形图格。 切片是六边形方向在顶部具有六边形点的六边形镶嵌。</para>
			/// </summary>
			[GPValue("POINTY_HEXAGON")]
			[Description("尖六边形")]
			Pointy_hexagon,

			/// <summary>
			/// <para>正方形—此图格化方案也称为几何正方形或正方形图格。 切片是矩形的细分。这是 Db2 和 SAP HANA 数据的默认值。 这是适用于 SAP HANA 数据的唯一图格类型。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>Geohash—在此图格化方案中，分块是矩形细分。 由于 Geohash 图格始终使用 WGS 1984 地理坐标系（GCS WGS 1984、EPSG WKID 4326），因此无法为 Geohash 图格指定图格坐标系。</para>
			/// </summary>
			[GPValue("GEOHASH")]
			[Description("Geohash")]
			Geohash,

		}

		/// <summary>
		/// <para>Generate Binning Cache</para>
		/// </summary>
		public enum GenerateStaticCacheEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("STATIC_CACHE")]
			STATIC_CACHE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DYNAMIC")]
			DYNAMIC,

		}

#endregion
	}
}
