using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Group By Proximity</para>
	/// <para>按邻近性分组</para>
	/// <para>可对空间或时空上彼此接近的要素进行分组。</para>
	/// </summary>
	public class GroupByProximity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将对点、线或面要素进行分组。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// <para>具有分组要素的输出要素服务的名称将由新命名的字段表示 group_id</para>
		/// </param>
		/// <param name="SpatialRelationship">
		/// <para>Spatial Relationship</para>
		/// <para>指定要素分组所依据的关系类型。</para>
		/// <para>相交—当某些要素或其中的部分重叠时，则将对这些要素进行分组。 这是默认设置。</para>
		/// <para>接触—如果要素与另一个要素具有相交顶点，但两者不重叠，则将对要素进行分组。</para>
		/// <para>平面邻近—如果顶点或边在另一个要素的给定平面距离内，则将对要素进行分组。</para>
		/// <para>测地线邻近—如果顶点或边在另一个要素的给定测地线距离内，则将对要素进行分组。</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </param>
		public GroupByProximity(object InputLayer, object OutputName, object SpatialRelationship)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.SpatialRelationship = SpatialRelationship;
		}

		/// <summary>
		/// <para>Tool Display Name : 按邻近性分组</para>
		/// </summary>
		public override string DisplayName() => "按邻近性分组";

		/// <summary>
		/// <para>Tool Name : GroupByProximity</para>
		/// </summary>
		public override string ToolName() => "GroupByProximity";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.GroupByProximity</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.GroupByProximity";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, SpatialRelationship, SpatialNearDistance!, TemporalRelationship!, TemporalNearDistance!, DataStore!, Output!, AttributeRelationship! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将对点、线或面要素进行分组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// <para>具有分组要素的输出要素服务的名称将由新命名的字段表示 group_id</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>指定要素分组所依据的关系类型。</para>
		/// <para>相交—当某些要素或其中的部分重叠时，则将对这些要素进行分组。 这是默认设置。</para>
		/// <para>接触—如果要素与另一个要素具有相交顶点，但两者不重叠，则将对要素进行分组。</para>
		/// <para>平面邻近—如果顶点或边在另一个要素的给定平面距离内，则将对要素进行分组。</para>
		/// <para>测地线邻近—如果顶点或边在另一个要素的给定测地线距离内，则将对要素进行分组。</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialRelationship { get; set; } = "INTERSECTS";

		/// <summary>
		/// <para>Spatial Near Distance</para>
		/// <para>该距离将用于对邻近要素进行分组。 仅当空间关系参数值为邻近平面或邻近测地线时，使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SpatialNearDistance { get; set; }

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// <para>指定将用于匹配要素的时间条件。 当将该参数设置为相交或邻近且当空间和时间条件都满足时，要素将被分组。 要支持此功能必须在输入上启用时间。</para>
		/// <para>相交—当要素时间的任何部分与另一要素重叠时，要素将被分组。 这是默认设置。</para>
		/// <para>邻近—如果要素的时间在另一要素的时间范围内，则要素将被分组。</para>
		/// <para>无—时间将不会用于对要素进行分组。</para>
		/// <para><see cref="TemporalRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TemporalRelationship { get; set; } = "NONE";

		/// <summary>
		/// <para>Temporal Near Distance</para>
		/// <para>时间距离将用于对邻近要素进行分组。 仅当空间关系参数值为邻近时，使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TemporalNearDistance { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。 默认设置为时空大数据存储。 在时空大数据存储中存储的所有结果都将存储在 WGS84 中。 在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Attribute Relationship</para>
		/// <para>此 ArcGIS Arcade 表达式将用于对要素进行分组。 例如，当 Amount 字段具有相同的值时，$a["Amount"] == $b["Amount"] 将对要素进行分组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AttributeRelationship { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GroupByProximity SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>平面邻近—如果顶点或边在另一个要素的给定平面距离内，则将对要素进行分组。</para>
			/// </summary>
			[GPValue("NEAR_PLANAR")]
			[Description("平面邻近")]
			Planar_Near,

			/// <summary>
			/// <para>测地线邻近—如果顶点或边在另一个要素的给定测地线距离内，则将对要素进行分组。</para>
			/// </summary>
			[GPValue("NEAR_GEODESIC")]
			[Description("测地线邻近")]
			Geodesic_Near,

			/// <summary>
			/// <para>接触—如果要素与另一个要素具有相交顶点，但两者不重叠，则将对要素进行分组。</para>
			/// </summary>
			[GPValue("TOUCHES")]
			[Description("接触")]
			Touches,

			/// <summary>
			/// <para>相交—当某些要素或其中的部分重叠时，则将对这些要素进行分组。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("相交")]
			Intersects,

		}

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// </summary>
		public enum TemporalRelationshipEnum 
		{
			/// <summary>
			/// <para>相交—当要素时间的任何部分与另一要素重叠时，要素将被分组。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("相交")]
			Intersects,

			/// <summary>
			/// <para>邻近—如果要素的时间在另一要素的时间范围内，则要素将被分组。</para>
			/// </summary>
			[GPValue("NEAR")]
			[Description("邻近")]
			Near,

			/// <summary>
			/// <para>无—时间将不会用于对要素进行分组。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
