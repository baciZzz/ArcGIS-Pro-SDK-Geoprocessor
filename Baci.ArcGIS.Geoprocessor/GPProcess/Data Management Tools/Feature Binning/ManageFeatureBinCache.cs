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
	/// <para>Manage Feature Bin Cache</para>
	/// <para>管理要素图格缓存</para>
	/// <para>管理已启用要素分箱的数据的要素分箱缓存。</para>
	/// </summary>
	public class ManageFeatureBinCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将更新静态缓存的已启用分箱要素类。</para>
		/// </param>
		public ManageFeatureBinCache(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理要素图格缓存</para>
		/// </summary>
		public override string DisplayName() => "管理要素图格缓存";

		/// <summary>
		/// <para>Tool Name : ManageFeatureBinCache</para>
		/// </summary>
		public override string ToolName() => "ManageFeatureBinCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ManageFeatureBinCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ManageFeatureBinCache";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, BinType, MaxLod, AddCacheStatistics, DeleteCacheStatistics, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将更新静态缓存的已启用分箱要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>指定要启用的分箱类型。如果正在使用 SAP HANA 数据，仅支持正方形图格。</para>
		/// <para>平六边形—也称为平面几何六边形或平面六边形分箱的分箱方案。切片是六边形方向在顶部具有六边形平边的六边形镶嵌。这是 Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。</para>
		/// <para>尖六边形—也称为尖几何六边形或尖六边形分箱的分箱方案。切片是六边形方向在顶部具有六边形点的六边形镶嵌。</para>
		/// <para>正方形—也称为几何正方形或正方形分箱、切片是正方形镶嵌的分箱方案。这是 Db2 和 SAP HANA 数据的默认值。这是适用于 SAP HANA 数据的唯一图格类型。</para>
		/// <para>Geohash—切片是矩形向前的分箱方案。由于 Geohash 图格始终使用 WGS 1984 地理坐标系（GCS WGS 1984、EPSG WKID 4326），因此无法为 Geohash 图格指定图格坐标系。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BinType { get; set; }

		/// <summary>
		/// <para>Level of Detail</para>
		/// <para>指定将用于缓存的最高细节层次。</para>
		/// <para>切片方案是比例范围连续体。根据特定地图，您可能希望放弃缓存切片方案中的某些极大或极小比例。此工具用于检查地图中的比例可变选项，并尝试提供用于缓存的最大比例范围。选择与要显示数据的地图的预期用途最匹配的细节层次。</para>
		/// <para>世界—世界比例将用作最高细节层次。</para>
		/// <para>大洲—多个大陆比例将用作最高细节层次。</para>
		/// <para>洲—单个大陆比例将用作最高细节层次。</para>
		/// <para>多个国家/地区—多个国家/地区比例将用作最高细节层次。</para>
		/// <para>国家/地区—单个国家/地区比例将用作最高细节层次。</para>
		/// <para>多个州—多个州比例将用作最高细节层次。</para>
		/// <para>州—单个州比例将用作最高细节层次。</para>
		/// <para>县—多个县比例将用作最高细节层次。</para>
		/// <para>县—单个县比例将用作最高细节层次。</para>
		/// <para>多个城市—多个城市比例将用作最高细节层次。</para>
		/// <para>城市—单个城市比例将用作最高细节层次。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MaxLod { get; set; }

		/// <summary>
		/// <para>Add Statistic to Cache</para>
		/// <para>指定将在图格缓存中汇总并存储的统计信息。统计信息用于符号化图格，并为图格中的所有点提供聚合信息。汇总统计信息 shape_count（这是总要素计数）始终可用。</para>
		/// <para>字段 - 计算汇总统计信息时基于的字段。支持的字段类型包括短型、长型、浮点型和双精度型。</para>
		/// <para>统计类型 - 要为指定字段计算的统计类型。可以计算图格中所有要素的统计信息。可用统计类型如下：</para>
		/// <para>平均值 (AVG) - 计算指定字段的平均值。</para>
		/// <para>最小值 (MIN) - 查找指定字段的所有记录的最小值。</para>
		/// <para>最大值 (MAX) - 查找指定字段的所有记录的最大值。</para>
		/// <para>标准偏差 (STDDEV) - 计算字段的标准偏差值。</para>
		/// <para>总和 (SUM) - 添加指定字段的总计值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AddCacheStatistics { get; set; }

		/// <summary>
		/// <para>Delete Statistic from Cache</para>
		/// <para>将从缓存中删除的汇总统计信息。无法删除默认 COUNT 汇总统计信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DeleteCacheStatistics { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageFeatureBinCache SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>平六边形—也称为平面几何六边形或平面六边形分箱的分箱方案。切片是六边形方向在顶部具有六边形平边的六边形镶嵌。这是 Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。</para>
			/// </summary>
			[GPValue("FLAT_HEXAGON")]
			[Description("平六边形")]
			Flat_hexagon,

			/// <summary>
			/// <para>尖六边形—也称为尖几何六边形或尖六边形分箱的分箱方案。切片是六边形方向在顶部具有六边形点的六边形镶嵌。</para>
			/// </summary>
			[GPValue("POINTY_HEXAGON")]
			[Description("尖六边形")]
			Pointy_hexagon,

			/// <summary>
			/// <para>正方形—也称为几何正方形或正方形分箱、切片是正方形镶嵌的分箱方案。这是 Db2 和 SAP HANA 数据的默认值。这是适用于 SAP HANA 数据的唯一图格类型。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>Geohash—切片是矩形向前的分箱方案。由于 Geohash 图格始终使用 WGS 1984 地理坐标系（GCS WGS 1984、EPSG WKID 4326），因此无法为 Geohash 图格指定图格坐标系。</para>
			/// </summary>
			[GPValue("GEOHASH")]
			[Description("Geohash")]
			Geohash,

		}

#endregion
	}
}
