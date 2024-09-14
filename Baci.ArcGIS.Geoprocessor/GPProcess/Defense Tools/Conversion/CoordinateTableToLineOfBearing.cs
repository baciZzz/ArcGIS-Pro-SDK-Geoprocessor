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
	/// <para>Coordinate Table To Line Of Bearing</para>
	/// <para>坐标表转方位线</para>
	/// <para>可根据表中存储的坐标创建方位线。</para>
	/// </summary>
	public class CoordinateTableToLineOfBearing : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Bearing Lines Feature Class</para>
		/// <para>包含输出方位线的要素类。</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含 x 或经度坐标的字段。</para>
		/// </param>
		/// <param name="BearingField">
		/// <para>Bearing Field</para>
		/// <para>输入表中包含方位角值的字段。</para>
		/// </param>
		/// <param name="DistanceField">
		/// <para>Distance Field</para>
		/// <para>输入表中包含距离值的字段。</para>
		/// </param>
		/// <param name="InCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>指定输入表坐标的格式。</para>
		/// <para>十进制度 - 一个字段—坐标将采用存储在单个字段中的十进制度坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>十进制度 - 两个字段—坐标将采用存储在两个表字段中的十进制度坐标对格式。这是默认设置。</para>
		/// <para>度和十进制分 - 一个字段—坐标将采用存储在单个表字段中的度和十进制分坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度和十进制分 - 两个字段—坐标将采用存储在两个表字段中的度和十进制分坐标对格式。</para>
		/// <para>度分秒 - 一个字段—坐标将采用存储在单个表字段中的度、分和秒坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度分秒 - 两个字段—坐标将采用存储在两个表字段中的度、分和秒坐标对格式。</para>
		/// <para>全球区域参考系统—坐标将采用全球区域参考系格式。</para>
		/// <para>世界地理参考系— 坐标将采用世界地理参考系格式。</para>
		/// <para>通用横轴墨卡托坐标带—坐标将采用通用横轴墨卡托坐标带格式。</para>
		/// <para>通用横轴墨卡托坐标区域—坐标将采用通用横轴墨卡托坐标区域格式。</para>
		/// <para>美国国家格网—坐标将采用美国国家网格格式。</para>
		/// <para>军事格网参考系—坐标将采用军事格网参考系格式。</para>
		/// </param>
		public CoordinateTableToLineOfBearing(object InTable, object OutFeatureClass, object XOrLonField, object BearingField, object DistanceField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XOrLonField = XOrLonField;
			this.BearingField = BearingField;
			this.DistanceField = DistanceField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : 坐标表转方位线</para>
		/// </summary>
		public override string DisplayName() => "坐标表转方位线";

		/// <summary>
		/// <para>Tool Name : CoordinateTableToLineOfBearing</para>
		/// </summary>
		public override string ToolName() => "CoordinateTableToLineOfBearing";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableToLineOfBearing</para>
		/// </summary>
		public override string ExcuteName() => "defense.CoordinateTableToLineOfBearing";

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
		public override object[] Parameters() => new object[] { InTable, OutFeatureClass, XOrLonField, BearingField, DistanceField, InCoordinateFormat, BearingUnits, DistanceUnits, YOrLatField, LineType, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Bearing Lines Feature Class</para>
		/// <para>包含输出方位线的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含 x 或经度坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XOrLonField { get; set; }

		/// <summary>
		/// <para>Bearing Field</para>
		/// <para>输入表中包含方位角值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object BearingField { get; set; }

		/// <summary>
		/// <para>Distance Field</para>
		/// <para>输入表中包含距离值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object DistanceField { get; set; }

		/// <summary>
		/// <para>Input Coordinate Format</para>
		/// <para>指定输入表坐标的格式。</para>
		/// <para>十进制度 - 一个字段—坐标将采用存储在单个字段中的十进制度坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>十进制度 - 两个字段—坐标将采用存储在两个表字段中的十进制度坐标对格式。这是默认设置。</para>
		/// <para>度和十进制分 - 一个字段—坐标将采用存储在单个表字段中的度和十进制分坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度和十进制分 - 两个字段—坐标将采用存储在两个表字段中的度和十进制分坐标对格式。</para>
		/// <para>度分秒 - 一个字段—坐标将采用存储在单个表字段中的度、分和秒坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度分秒 - 两个字段—坐标将采用存储在两个表字段中的度、分和秒坐标对格式。</para>
		/// <para>全球区域参考系统—坐标将采用全球区域参考系格式。</para>
		/// <para>世界地理参考系— 坐标将采用世界地理参考系格式。</para>
		/// <para>通用横轴墨卡托坐标带—坐标将采用通用横轴墨卡托坐标带格式。</para>
		/// <para>通用横轴墨卡托坐标区域—坐标将采用通用横轴墨卡托坐标区域格式。</para>
		/// <para>美国国家格网—坐标将采用美国国家网格格式。</para>
		/// <para>军事格网参考系—坐标将采用军事格网参考系格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InCoordinateFormat { get; set; } = "DD_2";

		/// <summary>
		/// <para>Bearing Units</para>
		/// <para>指定方位角的测量单位。</para>
		/// <para>度—角度将以度为单位。这是默认设置。</para>
		/// <para>密耳—角度将以密耳为单位。</para>
		/// <para>弧度—角度将以弧度为单位。</para>
		/// <para>百分度—角度将以百分度为单位。</para>
		/// <para><see cref="BearingUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object BearingUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>指定距离的测量单位。</para>
		/// <para>米—单位将为米。这是默认设置。</para>
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
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Y Field (latitude)</para>
		/// <para>输入表中包含 y 或纬度坐标的字段。</para>
		/// <para>当输入坐标格式参数设置为十进制度 - 两个字段、度和十进制分 - 两个字段或度分秒 - 两个字段时，将使用 Y 字段（纬度）参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object YOrLatField { get; set; }

		/// <summary>
		/// <para>Line Type</para>
		/// <para>指定输出线类型。</para>
		/// <para>测地线—将使用地球椭球体（椭圆体）表面上任何两点之间的最短距离。这是默认设置。</para>
		/// <para>大圆线—将使用由通过椭球体中心的平面的交点定义的椭球体（椭圆体）上的线。</para>
		/// <para>恒向线—将使用恒定方位角的线。</para>
		/// <para>法向截面—将使用包含起点和终点的地球椭球体表面的法线平面。</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LineType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>输出要素类的空间参考。 默认值为 GCS_WGS_1984。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CoordinateTableToLineOfBearing SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bearing Units</para>
		/// </summary>
		public enum BearingUnitsEnum 
		{
			/// <summary>
			/// <para>度—角度将以度为单位。这是默认设置。</para>
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

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>米—单位将为米。这是默认设置。</para>
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
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>测地线—将使用地球椭球体（椭圆体）表面上任何两点之间的最短距离。这是默认设置。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic_line,

			/// <summary>
			/// <para>大圆线—将使用由通过椭球体中心的平面的交点定义的椭球体（椭圆体）上的线。</para>
			/// </summary>
			[GPValue("GREAT_CIRCLE")]
			[Description("大圆线")]
			Great_circle_line,

			/// <summary>
			/// <para>恒向线—将使用恒定方位角的线。</para>
			/// </summary>
			[GPValue("RHUMB_LINE")]
			[Description("恒向线")]
			Rhumb_line,

			/// <summary>
			/// <para>法向截面—将使用包含起点和终点的地球椭球体表面的法线平面。</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("法向截面")]
			Normal_section,

		}

#endregion
	}
}
