using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Generate Range Fans</para>
	/// <para>生成扇形视域</para>
	/// <para>以给定水平起始角、水平终止角、最小距离和最大距离创建从起点开始的扇形视域。</para>
	/// </summary>
	public class GenerateRangeFans : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Points</para>
		/// <para>输入点要素集用于标识扇形视域的原点。输入必须至少具有一个点。</para>
		/// </param>
		/// <param name="OutRangeFanFeatureClass">
		/// <para>Output Range Fan Feature Class</para>
		/// <para>含有输出扇形视域要素的要素类。</para>
		/// </param>
		/// <param name="InnerRadius">
		/// <para>Minimum Distance</para>
		/// <para>原点距扇形视域起点的距离</para>
		/// </param>
		/// <param name="OuterRadius">
		/// <para>Maximum Distance</para>
		/// <para>原点距扇形视域终点的距离</para>
		/// </param>
		/// <param name="HorizontalStartAngle">
		/// <para>Horizontal Start Angle</para>
		/// <para>原点与扇形视域起点的角度</para>
		/// </param>
		/// <param name="HorizontalEndAngle">
		/// <para>Horizontal End Angle</para>
		/// <para>原点与扇形视域终点的角度</para>
		/// </param>
		public GenerateRangeFans(object InFeatures, object OutRangeFanFeatureClass, object InnerRadius, object OuterRadius, object HorizontalStartAngle, object HorizontalEndAngle)
		{
			this.InFeatures = InFeatures;
			this.OutRangeFanFeatureClass = OutRangeFanFeatureClass;
			this.InnerRadius = InnerRadius;
			this.OuterRadius = OuterRadius;
			this.HorizontalStartAngle = HorizontalStartAngle;
			this.HorizontalEndAngle = HorizontalEndAngle;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成扇形视域</para>
		/// </summary>
		public override string DisplayName() => "生成扇形视域";

		/// <summary>
		/// <para>Tool Name : GenerateRangeFans</para>
		/// </summary>
		public override string ToolName() => "GenerateRangeFans";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeFans</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateRangeFans";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutRangeFanFeatureClass, InnerRadius, OuterRadius, HorizontalStartAngle, HorizontalEndAngle, DistanceUnits!, AngleUnits! };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>输入点要素集用于标识扇形视域的原点。输入必须至少具有一个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Range Fan Feature Class</para>
		/// <para>含有输出扇形视域要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutRangeFanFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Distance</para>
		/// <para>原点距扇形视域起点的距离</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object InnerRadius { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>原点距扇形视域终点的距离</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object OuterRadius { get; set; }

		/// <summary>
		/// <para>Horizontal Start Angle</para>
		/// <para>原点与扇形视域起点的角度</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object HorizontalStartAngle { get; set; }

		/// <summary>
		/// <para>Horizontal End Angle</para>
		/// <para>原点与扇形视域终点的角度</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object HorizontalEndAngle { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>指定最小和最大距离的线性测量单位。</para>
		/// <para>米—单位将为米。 这是默认设置。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>美国测量英尺—单位将为美国测量英尺。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object? DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Angular Units</para>
		/// <para>指定起始角和终止角的角度测量单位。</para>
		/// <para>度—角度将以度为单位。 这是默认设置。</para>
		/// <para>密耳—角度将以密耳为单位。</para>
		/// <para>弧度—角度将以弧度为单位。</para>
		/// <para>百分度—角度将以百分度为单位。</para>
		/// <para><see cref="AngleUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object? AngleUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeFans SetEnviroment(object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>米—单位将为米。 这是默认设置。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—单位将为公里。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英里—单位将为英里。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—单位将为海里。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("海里")]
			Nautical_miles,

			/// <summary>
			/// <para>英尺—单位将为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>美国测量英尺—单位将为美国测量英尺。</para>
			/// </summary>
			[GPValue("US_SURVEY_FEET")]
			[Description("美国测量英尺")]
			US_survey_feet,

		}

		/// <summary>
		/// <para>Angular Units</para>
		/// </summary>
		public enum AngleUnitsEnum 
		{
			/// <summary>
			/// <para>度—角度将以度为单位。 这是默认设置。</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("度")]
			Degrees,

			/// <summary>
			/// <para>密耳—角度将以密耳为单位。</para>
			/// </summary>
			[GPValue("MILS")]
			[Description("密耳")]
			Mils,

			/// <summary>
			/// <para>弧度—角度将以弧度为单位。</para>
			/// </summary>
			[GPValue("RADS")]
			[Description("弧度")]
			Radians,

			/// <summary>
			/// <para>百分度—角度将以百分度为单位。</para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("百分度")]
			Gradians,

		}

#endregion
	}
}
