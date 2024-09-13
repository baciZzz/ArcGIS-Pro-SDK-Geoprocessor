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
	/// <para>Trace Proximity Events</para>
	/// <para>追踪邻域事件</para>
	/// <para>追踪在空间（位置）和时间上彼此邻近的事件。启用时间的点数据必须包含表示时刻的要素。</para>
	/// </summary>
	public class TraceProximityEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPoints">
		/// <para>Input Points</para>
		/// <para>启用时间的点要素类，用于追踪邻域事件。</para>
		/// </param>
		/// <param name="EntityIdField">
		/// <para>Entity ID Field</para>
		/// <para>表示每个实体的唯一 ID 的字段。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>指定将与空间搜索距离参数一起使用的距离类型。</para>
		/// <para>平面—要素之间将使用平面距离。这是默认设置。</para>
		/// <para>测地线—将在要素之间使用测地线距离。这种线类型考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="SpatialSearchDistance">
		/// <para>Spatial Search Distance</para>
		/// <para>两点视为邻近时相距的最大距离。满足空间搜索距离和时间搜索距离条件的要素视为彼此邻近。</para>
		/// <para><see cref="SpatialSearchDistanceEnum"/></para>
		/// </param>
		/// <param name="TemporalSearchDistance">
		/// <para>Temporal Search Distance</para>
		/// <para>两点视为邻近时相距的最大持续时间。时间搜索距离内满足空间搜索距离条件的要素视为彼此邻近。</para>
		/// <para><see cref="TemporalSearchDistanceEnum"/></para>
		/// </param>
		/// <param name="EntitiesOfInterestInputType">
		/// <para>Define Entities of Interest Using</para>
		/// <para>指定感兴趣实体。</para>
		/// <para>感兴趣实体 ID—实体名称和时间将用作感兴趣实体。这是默认设置。</para>
		/// <para>指定感兴趣实体图层中的选定要素—在指定感兴趣实体图层中选择的要素将用作感兴趣实体。</para>
		/// <para><see cref="EntitiesOfInterestInputTypeEnum"/></para>
		/// </param>
		public TraceProximityEvents(object InPoints, object EntityIdField, object OutputName, object DistanceMethod, object SpatialSearchDistance, object TemporalSearchDistance, object EntitiesOfInterestInputType)
		{
			this.InPoints = InPoints;
			this.EntityIdField = EntityIdField;
			this.OutputName = OutputName;
			this.DistanceMethod = DistanceMethod;
			this.SpatialSearchDistance = SpatialSearchDistance;
			this.TemporalSearchDistance = TemporalSearchDistance;
			this.EntitiesOfInterestInputType = EntitiesOfInterestInputType;
		}

		/// <summary>
		/// <para>Tool Display Name : 追踪邻域事件</para>
		/// </summary>
		public override string DisplayName() => "追踪邻域事件";

		/// <summary>
		/// <para>Tool Name : TraceProximityEvents</para>
		/// </summary>
		public override string ToolName() => "TraceProximityEvents";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.TraceProximityEvents</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.TraceProximityEvents";

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
		public override object[] Parameters() => new object[] { InPoints, EntityIdField, OutputName, DistanceMethod, SpatialSearchDistance, TemporalSearchDistance, EntitiesOfInterestInputType, EntitiesInterestIds, EntitiesInterestLayer, IncludeTracksLayer, MaxTraceDepth, AttributeMatchCriteria, DataStore, Output, TracksLayer };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>启用时间的点要素类，用于追踪邻域事件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InPoints { get; set; }

		/// <summary>
		/// <para>Entity ID Field</para>
		/// <para>表示每个实体的唯一 ID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object EntityIdField { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定将与空间搜索距离参数一起使用的距离类型。</para>
		/// <para>平面—要素之间将使用平面距离。这是默认设置。</para>
		/// <para>测地线—将在要素之间使用测地线距离。这种线类型考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Spatial Search Distance</para>
		/// <para>两点视为邻近时相距的最大距离。满足空间搜索距离和时间搜索距离条件的要素视为彼此邻近。</para>
		/// <para><see cref="SpatialSearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SpatialSearchDistance { get; set; }

		/// <summary>
		/// <para>Temporal Search Distance</para>
		/// <para>两点视为邻近时相距的最大持续时间。时间搜索距离内满足空间搜索距离条件的要素视为彼此邻近。</para>
		/// <para><see cref="TemporalSearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TemporalSearchDistance { get; set; }

		/// <summary>
		/// <para>Define Entities of Interest Using</para>
		/// <para>指定感兴趣实体。</para>
		/// <para>感兴趣实体 ID—实体名称和时间将用作感兴趣实体。这是默认设置。</para>
		/// <para>指定感兴趣实体图层中的选定要素—在指定感兴趣实体图层中选择的要素将用作感兴趣实体。</para>
		/// <para><see cref="EntitiesOfInterestInputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EntitiesOfInterestInputType { get; set; } = "ID_START_TIME";

		/// <summary>
		/// <para>Entities of Interest IDs</para>
		/// <para>感兴趣实体的实体名称和开始时间。仅当为感兴趣实体定义方式参数指定感兴趣实体 ID 时，此参数才受支持。</para>
		/// <para>实体 ID - 唯一实体名称。该名称区分大小写。</para>
		/// <para>开始时间 - 追踪感兴趣实体的可选开始时间。如果未指定时间，则将使用 1970 年 1 月 1 日。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object EntitiesInterestIds { get; set; }

		/// <summary>
		/// <para>Entities of Interest Layer</para>
		/// <para>包含感兴趣实体的图层或表。仅当为感兴趣实体定义方式参数指定指定感兴趣实体图层中的选定要素时，此参数才受支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object EntitiesInterestLayer { get; set; }

		/// <summary>
		/// <para>Output Tracks</para>
		/// <para>指定是否将生成相应输出图层，其中包含第一个追踪事件以及该指定实体的所有后续要素。</para>
		/// <para>选中 - 将生成包含第一个追踪事件以及所有后续要素的输出图层。</para>
		/// <para>未选中 - 将不会生成包含第一个追踪事件以及所有后续要素的输出图层。这是默认设置。</para>
		/// <para><see cref="IncludeTracksLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Outputs")]
		public object IncludeTracksLayer { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Trace Depth</para>
		/// <para>感兴趣实体和追踪中更远的实体（下游）之间的最大分离度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object MaxTraceDepth { get; set; }

		/// <summary>
		/// <para>Attribute Match Criteria</para>
		/// <para>用于约束邻域事件的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[Category("Advanced Options")]
		public object AttributeMatchCriteria { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Proximity Events</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Output Tracks</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object TracksLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TraceProximityEvents SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>平面—要素之间将使用平面距离。这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—将在要素之间使用测地线距离。这种线类型考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Spatial Search Distance</para>
		/// </summary>
		public enum SpatialSearchDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

		/// <summary>
		/// <para>Temporal Search Distance</para>
		/// </summary>
		public enum TemporalSearchDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Define Entities of Interest Using</para>
		/// </summary>
		public enum EntitiesOfInterestInputTypeEnum 
		{
			/// <summary>
			/// <para>感兴趣实体 ID—实体名称和时间将用作感兴趣实体。这是默认设置。</para>
			/// </summary>
			[GPValue("ID_START_TIME")]
			[Description("感兴趣实体 ID")]
			Entities_of_Interest_IDs,

			/// <summary>
			/// <para>指定感兴趣实体图层中的选定要素—在指定感兴趣实体图层中选择的要素将用作感兴趣实体。</para>
			/// </summary>
			[GPValue("SELECTED_FEATURE")]
			[Description("指定感兴趣实体图层中的选定要素")]
			Selected_features_in_a_specified_entity_of_interest_layer,

		}

		/// <summary>
		/// <para>Output Tracks</para>
		/// </summary>
		public enum IncludeTracksLayerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACKS")]
			TRACKS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRACKS")]
			NO_TRACKS,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
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
