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
	/// <para>管理要素图格化缓存</para>
	/// <para>管理启用要素图格的数据的要素图格缓存。</para>
	/// </summary>
	public class ManageFeatureBinCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将更新其静态缓存的启用图格的要素类。</para>
		/// </param>
		public ManageFeatureBinCache(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理要素图格化缓存</para>
		/// </summary>
		public override string DisplayName() => "管理要素图格化缓存";

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
		public override object[] Parameters() => new object[] { InFeatures, BinType!, MaxLod!, AddCacheStatistics!, DeleteCacheStatistics!, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将更新其静态缓存的启用图格的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>指定要启用的图格化类型。</para>
		/// <para>平六边形—将启用平面六边形图格化方案，也称为平面几何六边形或平面六边形图格化。 切片是六边形方向在顶部具有六边形平边的六边形镶嵌。 这是 Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。</para>
		/// <para>尖六边形—将启用尖六边形图格化方案，也称为尖几何六边形或尖六边形图格化。 切片是六边形方向在顶部具有六边形点的六边形镶嵌。</para>
		/// <para>方形—将启用正方形图格化方案，其中切片是正方形的细分，也称为几何正方形或正方形图格化。 这是 Db2 数据的默认值。</para>
		/// <para>Geohash—将启用 Geohash 图格化方案，其中切片是矩形的细分。 由于 Geohash 图格始终使用 WGS84 地理坐标系（GCS WGS84、EPSG WKID 4326），因此无法为 Geohash 图格指定图格坐标系。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; }

		/// <summary>
		/// <para>Level of Detail</para>
		/// <para>指定将用于缓存的最高细节层次。</para>
		/// <para>切片方案是比例范围的连续体。 根据特定地图，您可能希望放弃针对切片方案中极大或极小的比例创建缓存。 此工具将检查地图中的比例可变选项，并提供进行缓存的最高比例范围。 选择与显示数据的地图的预期用途最匹配的细节层次。</para>
		/// <para>世界—将使用世界比例作为最高细节层次。</para>
		/// <para>多个大洲—将使用多个大洲比例作为最高细节层次。</para>
		/// <para>单个大洲—将使用单个大洲比例作为最高细节层次。</para>
		/// <para>多个国家/地区—将使用多个国家/地区比例作为最高细节层次。</para>
		/// <para>国家/地区—将使用单个国家/地区比例作为最高细节层次。</para>
		/// <para>多个省/自治区/直辖市—将使用多个省/自治区/直辖市比例作为最高细节层次。</para>
		/// <para>单个省/自治区/直辖市—将使用单个省/自治区/直辖市比例作为最高细节层次。</para>
		/// <para>多个县—将使用多个县比例作为最高细节层次。</para>
		/// <para>单个县—将使用单个县比例作为最高细节层次。</para>
		/// <para>多个城市—将使用多个城市比例作为最高细节层次。</para>
		/// <para>单个城市—将使用单个城市比例作为最高细节层次。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MaxLod { get; set; }

		/// <summary>
		/// <para>Add Statistic to Cache</para>
		/// <para>指定将在图格缓存中汇总并存储的统计信息。 统计信息用于符号化图格，并为图格中的所有点提供聚合信息。 汇总统计信息 shape_count （总要素计数）始终可用。</para>
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
		public object? AddCacheStatistics { get; set; }

		/// <summary>
		/// <para>Delete Statistic from Cache</para>
		/// <para>将从缓存中删除的汇总统计信息。 您无法删除默认 COUNT 汇总统计信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DeleteCacheStatistics { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageFeatureBinCache SetEnviroment(object? workspace = null )
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
			/// <para>平六边形—将启用平面六边形图格化方案，也称为平面几何六边形或平面六边形图格化。 切片是六边形方向在顶部具有六边形平边的六边形镶嵌。 这是 Microsoft SQL Server、Oracle 和 PostgreSQL 数据的默认值。</para>
			/// </summary>
			[GPValue("FLAT_HEXAGON")]
			[Description("平六边形")]
			Flat_hexagon,

			/// <summary>
			/// <para>尖六边形—将启用尖六边形图格化方案，也称为尖几何六边形或尖六边形图格化。 切片是六边形方向在顶部具有六边形点的六边形镶嵌。</para>
			/// </summary>
			[GPValue("POINTY_HEXAGON")]
			[Description("尖六边形")]
			Pointy_hexagon,

			/// <summary>
			/// <para>方形—将启用正方形图格化方案，其中切片是正方形的细分，也称为几何正方形或正方形图格化。 这是 Db2 数据的默认值。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("方形")]
			Square,

			/// <summary>
			/// <para>Geohash—将启用 Geohash 图格化方案，其中切片是矩形的细分。 由于 Geohash 图格始终使用 WGS84 地理坐标系（GCS WGS84、EPSG WKID 4326），因此无法为 Geohash 图格指定图格坐标系。</para>
			/// </summary>
			[GPValue("GEOHASH")]
			[Description("Geohash")]
			Geohash,

		}

#endregion
	}
}
