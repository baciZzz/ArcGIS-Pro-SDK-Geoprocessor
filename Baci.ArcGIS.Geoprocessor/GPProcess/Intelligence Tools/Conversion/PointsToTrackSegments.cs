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
	/// <para>Points To Track Segments</para>
	/// <para>点至轨迹段</para>
	/// <para>将启用时间的输入点数据序列（例如 GPS 点）转换为一系列输出路径。</para>
	/// </summary>
	public class PointsToTrackSegments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>点沿待创建轨迹放置的点要素。</para>
		/// </param>
		/// <param name="DateField">
		/// <para>Date Field</para>
		/// <para>将用于对输入要素点进行排序的日期字段。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出轨迹线要素。</para>
		/// </param>
		public PointsToTrackSegments(object InFeatures, object DateField, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.DateField = DateField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 点至轨迹段</para>
		/// </summary>
		public override string DisplayName() => "点至轨迹段";

		/// <summary>
		/// <para>Tool Name : PointsToTrackSegments</para>
		/// </summary>
		public override string ToolName() => "PointsToTrackSegments";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.PointsToTrackSegments</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.PointsToTrackSegments";

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
		public override object[] Parameters() => new object[] { InFeatures, DateField, OutFeatureClass, GroupField, IncludeVelocity, OutPointFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>点沿待创建轨迹放置的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>将用于对输入要素点进行排序的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出轨迹线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; } = "out_tracks";

		/// <summary>
		/// <para>Group Field</para>
		/// <para>将用于对输入点进行分组的输入要素参数中的字段。 每个唯一的组将创建一个单独的轨迹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short")]
		public object GroupField { get; set; }

		/// <summary>
		/// <para>Include Velocity Fields</para>
		/// <para>指定是否在输出要素类参数中包含速度字段（speed_mps、speed_mph、speed_kph 和 speed_knt）是否将包含在“输出要素类”参数中。</para>
		/// <para>选中 - 输出将包含输出速度字段。 这是默认设置。</para>
		/// <para>未选中 - 输出不会包含输出速度字段。</para>
		/// <para><see cref="IncludeVelocityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeVelocity { get; set; } = "true";

		/// <summary>
		/// <para>Output Sequence Points</para>
		/// <para>输出点要素。 输出将包含 SEQUENCE 字段，该字段包含在输出要素类参数将创建的路径排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Include Velocity Fields</para>
		/// </summary>
		public enum IncludeVelocityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_VELOCITY")]
			INCLUDE_VELOCITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_VELOCITY")]
			EXCLUDE_VELOCITY,

		}

#endregion
	}
}
