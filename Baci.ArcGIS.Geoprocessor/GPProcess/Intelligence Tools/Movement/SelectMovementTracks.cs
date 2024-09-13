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
	/// <para>Select Movement Tracks</para>
	/// <para>选择运动轨迹</para>
	/// <para>根据感兴趣区域选择运动轨迹。</para>
	/// </summary>
	public class SelectMovementTracks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将与感兴趣区域参数值进行比较以识别唯一轨迹并选择相关轨迹的要素。</para>
		/// </param>
		/// <param name="TrackIdField">
		/// <para>Track ID Field</para>
		/// <para>此字段包含运动轨迹点的唯一标识符。 该字段可以是数值型或字符串型字段。</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area Of Interest</para>
		/// <para>将与输入要素值进行比较以确定要选择的轨迹的要素。</para>
		/// </param>
		public SelectMovementTracks(object InFeatures, object TrackIdField, object AreaOfInterest)
		{
			this.InFeatures = InFeatures;
			this.TrackIdField = TrackIdField;
			this.AreaOfInterest = AreaOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : 选择运动轨迹</para>
		/// </summary>
		public override string DisplayName() => "选择运动轨迹";

		/// <summary>
		/// <para>Tool Name : SelectMovementTracks</para>
		/// </summary>
		public override string ToolName() => "SelectMovementTracks";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.SelectMovementTracks</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.SelectMovementTracks";

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
		public override object[] Parameters() => new object[] { InFeatures, TrackIdField, AreaOfInterest, TimeRelationship!, SelectionTime!, UpdatedFeatureclass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将与感兴趣区域参数值进行比较以识别唯一轨迹并选择相关轨迹的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Track ID Field</para>
		/// <para>此字段包含运动轨迹点的唯一标识符。 该字段可以是数值型或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object TrackIdField { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>将与输入要素值进行比较以确定要选择的轨迹的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Time Relationship</para>
		/// <para>指定输入要素和感兴趣区域参数值之间的时间关系。 如果指定了之前、之后或之前和之后选项，则输出选择中将仅包含指定时间窗内感兴趣区域值中存在的要素。</para>
		/// <para>之前和之后—当要素的时间在第一次识别感兴趣区域值之前和最后一次识别该值之后，但在第一次识别时间和最后一次识别时间之间指定的时间范围内时，则时间关系将在选择时间之前和之后。</para>
		/// <para>之前—当要素的时间在第一次识别感兴趣区域值之前，但在第一次识别时间指定时间范围内时，则时间关系将在选择时间之前。</para>
		/// <para>之后—当要素的时间在最后一次识别感兴趣区域值之后，但在最后一次识别时间指定时间范围内时，则时间关系将在选择时间之后。</para>
		/// <para>无—将返回在感兴趣区域值内，与追踪 ID 字段中指定的唯一标识符相关联的所有轨迹。</para>
		/// <para><see cref="TimeRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeRelationship { get; set; } = "NONE";

		/// <summary>
		/// <para>Selection Time</para>
		/// <para>如果为时间关系参数指定了之前、之后或之前和之后，将用于选择要素的时间范围。</para>
		/// <para>如果指定了之前或之前和之后，则选择的最早时间将是从输入要素和感兴趣区域参数生成的初始选择中选择的要素的第一个识别时间减去指定的时间值。 如果指定了之后或之前和之后，则选择时间将添加到从初始选择开始的最晚时间以确定所选要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object? SelectionTime { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatureclass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Time Relationship</para>
		/// </summary>
		public enum TimeRelationshipEnum 
		{
			/// <summary>
			/// <para>之前和之后—当要素的时间在第一次识别感兴趣区域值之前和最后一次识别该值之后，但在第一次识别时间和最后一次识别时间之间指定的时间范围内时，则时间关系将在选择时间之前和之后。</para>
			/// </summary>
			[GPValue("BEFORE_AFTER")]
			[Description("之前和之后")]
			Before_and_after,

			/// <summary>
			/// <para>之前和之后—当要素的时间在第一次识别感兴趣区域值之前和最后一次识别该值之后，但在第一次识别时间和最后一次识别时间之间指定的时间范围内时，则时间关系将在选择时间之前和之后。</para>
			/// </summary>
			[GPValue("BEFORE")]
			[Description("之前")]
			Before,

			/// <summary>
			/// <para>之后—当要素的时间在最后一次识别感兴趣区域值之后，但在最后一次识别时间指定时间范围内时，则时间关系将在选择时间之后。</para>
			/// </summary>
			[GPValue("AFTER")]
			[Description("之后")]
			After,

			/// <summary>
			/// <para>无—将返回在感兴趣区域值内，与追踪 ID 字段中指定的唯一标识符相关联的所有轨迹。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

#endregion
	}
}
