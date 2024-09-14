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
	/// <para>Find Meeting Locations</para>
	/// <para>查找汇合位置</para>
	/// <para>用于标识多个唯一运动轨迹在定义时间内停留的位置。</para>
	/// </summary>
	public class FindMeetingLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入运动轨迹点，用于分析是否为可能的汇合地点。 该图层必须已启用时间。</para>
		/// </param>
		/// <param name="OutAreaFeatures">
		/// <para>Output Area Features</para>
		/// <para>输出面要素，用于表示标识的汇合地点范围。</para>
		/// </param>
		/// <param name="OutPointFeatures">
		/// <para>Output Point Features</para>
		/// <para>表示各个汇合面的质心的输出点要素。 在给定汇合位置可以发生多次汇合。 要素类包含有关各个汇合的所有详细信息，包括参与者、持续时间以及开始和结束时间。</para>
		/// </param>
		/// <param name="UniqueNameField">
		/// <para>In Features Name Field</para>
		/// <para>此字段包含运动轨迹点的唯一标识符。</para>
		/// </param>
		public FindMeetingLocations(object InFeatures, object OutAreaFeatures, object OutPointFeatures, object UniqueNameField)
		{
			this.InFeatures = InFeatures;
			this.OutAreaFeatures = OutAreaFeatures;
			this.OutPointFeatures = OutPointFeatures;
			this.UniqueNameField = UniqueNameField;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找汇合位置</para>
		/// </summary>
		public override string DisplayName() => "查找汇合位置";

		/// <summary>
		/// <para>Tool Name : FindMeetingLocations</para>
		/// </summary>
		public override string ToolName() => "FindMeetingLocations";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindMeetingLocations</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.FindMeetingLocations";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutAreaFeatures, OutPointFeatures, UniqueNameField, SearchDistance!, MinimumLoiterTime!, TemporalRelationship!, MinMeetingDuration!, MaxMeetingDuration! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入运动轨迹点，用于分析是否为可能的汇合地点。 该图层必须已启用时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Area Features</para>
		/// <para>输出面要素，用于表示标识的汇合地点范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutAreaFeatures { get; set; }

		/// <summary>
		/// <para>Output Point Features</para>
		/// <para>表示各个汇合面的质心的输出点要素。 在给定汇合位置可以发生多次汇合。 要素类包含有关各个汇合的所有详细信息，包括参与者、持续时间以及开始和结束时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPointFeatures { get; set; }

		/// <summary>
		/// <para>In Features Name Field</para>
		/// <para>此字段包含运动轨迹点的唯一标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object UniqueNameField { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>运动轨迹在不再被视为汇合的一部分之前可以徘徊的最大距离。 默认值是 100 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Minimum Loiter Time</para>
		/// <para>运动轨迹点在被视为停留之前可以在区域中徘徊的最短时间。 这有助于确定多个唯一运动轨迹在同一时间和空间内停留的可能汇合地点。 默认值为 10 分钟。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? MinimumLoiterTime { get; set; } = "10 Minutes";

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// <para>指定将用于匹配要素的时间条件。</para>
		/// <para>重叠—当目标时间在连接时间间隔之前开始，且目标时间在连接时间间隔终点之前结束时，目标时间将覆盖连接时间。</para>
		/// <para>相交—当目标时间的任何一部分与连接时间在同一时间发生时，目标时间与连接时间相交。 这是默认设置。</para>
		/// <para><see cref="TemporalRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TemporalRelationship { get; set; } = "INTERSECTS";

		/// <summary>
		/// <para>Minimum Meeting Duration</para>
		/// <para>最短汇合持续时间，用于要包含在输出中的汇合。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? MinMeetingDuration { get; set; }

		/// <summary>
		/// <para>Maximum Meeting Duration</para>
		/// <para>最长汇合持续时间，用于要包含在输出中的汇合。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? MaxMeetingDuration { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindMeetingLocations SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// </summary>
		public enum TemporalRelationshipEnum 
		{
			/// <summary>
			/// <para>重叠—当目标时间在连接时间间隔之前开始，且目标时间在连接时间间隔终点之前结束时，目标时间将覆盖连接时间。</para>
			/// </summary>
			[GPValue("OVERLAPS")]
			[Description("重叠")]
			Overlaps,

			/// <summary>
			/// <para>相交—当目标时间的任何一部分与连接时间在同一时间发生时，目标时间与连接时间相交。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("相交")]
			Intersects,

		}

#endregion
	}
}
