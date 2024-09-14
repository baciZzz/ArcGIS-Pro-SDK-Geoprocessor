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
	/// <para>Bearing Distance To Line</para>
	/// <para>原点夹角距离定义线</para>
	/// <para>创建要素类，该新要素类包含基于表的 x 坐标字段、y 坐标字段、方位角字段和距离字段中的值的大地测量和平面线要素。</para>
	/// </summary>
	public class BearingDistanceToLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入表。可以是文本文件、CSV 文件、Excel 文件、dBASE 表或地理数据库表。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类，其中包含大地测量和平面线。</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 x 坐标（或经度）。</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 y 坐标（或纬度）。</para>
		/// </param>
		/// <param name="DistanceField">
		/// <para>Distance Field</para>
		/// <para>输入表中的数值字段，其中包含到用于创建输出线的起点的距离。</para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Units</para>
		/// <para>指定距离字段参数将使用的单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>美国测量英尺—单位将为美国测量英尺。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		/// <param name="BearingField">
		/// <para>Bearing Field</para>
		/// <para>输入表中包含输出线旋转的方位角值的数值字段。 以北为基准方向按顺时针进行测量的角度。</para>
		/// </param>
		/// <param name="BearingUnits">
		/// <para>Bearing Units</para>
		/// <para>指定方位角字段参数值的单位。</para>
		/// <para>十进制度— 单位将为十进制度。这是默认设置。</para>
		/// <para>密耳—单位将为密耳。</para>
		/// <para>弧度—单位将为弧度。</para>
		/// <para>百分度—单位将为百分度。</para>
		/// <para><see cref="BearingUnitsEnum"/></para>
		/// </param>
		public BearingDistanceToLine(object InTable, object OutFeatureclass, object XField, object YField, object DistanceField, object DistanceUnits, object BearingField, object BearingUnits)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.XField = XField;
			this.YField = YField;
			this.DistanceField = DistanceField;
			this.DistanceUnits = DistanceUnits;
			this.BearingField = BearingField;
			this.BearingUnits = BearingUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 原点夹角距离定义线</para>
		/// </summary>
		public override string DisplayName() => "原点夹角距离定义线";

		/// <summary>
		/// <para>Tool Name : BearingDistanceToLine</para>
		/// </summary>
		public override string ToolName() => "BearingDistanceToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.BearingDistanceToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.BearingDistanceToLine";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutFeatureclass, XField, YField, DistanceField, DistanceUnits, BearingField, BearingUnits, LineType!, IdField!, SpatialReference!, Attributes! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表。可以是文本文件、CSV 文件、Excel 文件、dBASE 表或地理数据库表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类，其中包含大地测量和平面线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 x 坐标（或经度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 y 坐标（或纬度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Distance Field</para>
		/// <para>输入表中的数值字段，其中包含到用于创建输出线的起点的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object DistanceField { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>指定距离字段参数将使用的单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>美国测量英尺—单位将为美国测量英尺。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Bearing Field</para>
		/// <para>输入表中包含输出线旋转的方位角值的数值字段。 以北为基准方向按顺时针进行测量的角度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object BearingField { get; set; }

		/// <summary>
		/// <para>Bearing Units</para>
		/// <para>指定方位角字段参数值的单位。</para>
		/// <para>十进制度— 单位将为十进制度。这是默认设置。</para>
		/// <para>密耳—单位将为密耳。</para>
		/// <para>弧度—单位将为弧度。</para>
		/// <para>百分度—单位将为百分度。</para>
		/// <para><see cref="BearingUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BearingUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Line Type</para>
		/// <para>指定要构造的线类型。</para>
		/// <para>测地线—测地线类型，可以最准确地表示将构造的地球表面任意两点之间的最短距离。 这是默认设置。</para>
		/// <para>大圆—测地线类型，可以表示将构造的地球表面与通过地心的平面的相交线上任意两点之间的路径。 如果空间参考参数值是基于椭球体的坐标系，则线将为大椭圆。 如果空间参考参数值是基于球体的坐标系，该线表示唯一的大圆（球面上最大半径的圆）。</para>
		/// <para>恒向线—测地线类型，又称为等角航线 (loxodrome line)，可以表示将构造的通过以极点为起点的等方位角所定义的椭球体表面上的任意两点之间的路径。 等角航线在墨卡托投影中显示为直线。</para>
		/// <para>法向截面—测地线类型，可以表示将构造的由椭球体表面与通过椭球体表面上两点并垂直于两点起点处椭球面的平面相交而定义的椭球面上任意两点之间的路径。 从 A 点到 B 点与从 B 点到 A 点的法向截面线不同。</para>
		/// <para>平面线—将使用投影平面中的直线。 平面线通常不像测地线那样准确地表示地球表面的最短距离。 此选项不适用于地理坐标系。</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>ID</para>
		/// <para>输入表中的字段。此字段和值均包含在输出中，可用于连接输出要素和输入表中的记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object? IdField { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出要素类的空间参考。默认值为 GCS_WGS_1984 或输入坐标系（如果非“Unknown”）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; } = "{B286C06B-0879-11D2-AACA-00C04FA33C20};-450359962737.049 -450359962737.049 10000;-100000 10000;-100000 10000;0.001;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Preserve attributes</para>
		/// <para>指定是否将其余输入字段添加到输出要素类。</para>
		/// <para>未选中 - 不会将其余输入字段添加到输出要素类。 这是默认设置。</para>
		/// <para>选中 - 将其余输入字段添加到输出要素类。 还将向输出要素类添加新字段 ORIG_FID 以存储输入要素 ID 值。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Attributes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BearingDistanceToLine SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>米—单位将为米。</para>
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
		/// <para>Bearing Units</para>
		/// </summary>
		public enum BearingUnitsEnum 
		{
			/// <summary>
			/// <para>十进制度— 单位将为十进制度。这是默认设置。</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("十进制度")]
			Decimal_degrees,

			/// <summary>
			/// <para>密耳—单位将为密耳。</para>
			/// </summary>
			[GPValue("MILS")]
			[Description("密耳")]
			Mils,

			/// <summary>
			/// <para>弧度—单位将为弧度。</para>
			/// </summary>
			[GPValue("RADS")]
			[Description("弧度")]
			Radians,

			/// <summary>
			/// <para>百分度—单位将为百分度。</para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("百分度")]
			Gradians,

		}

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>测地线—测地线类型，可以最准确地表示将构造的地球表面任意两点之间的最短距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

			/// <summary>
			/// <para>大圆—测地线类型，可以表示将构造的地球表面与通过地心的平面的相交线上任意两点之间的路径。 如果空间参考参数值是基于椭球体的坐标系，则线将为大椭圆。 如果空间参考参数值是基于球体的坐标系，该线表示唯一的大圆（球面上最大半径的圆）。</para>
			/// </summary>
			[GPValue("GREAT_CIRCLE")]
			[Description("大圆")]
			Great_circle,

			/// <summary>
			/// <para>恒向线—测地线类型，又称为等角航线 (loxodrome line)，可以表示将构造的通过以极点为起点的等方位角所定义的椭球体表面上的任意两点之间的路径。 等角航线在墨卡托投影中显示为直线。</para>
			/// </summary>
			[GPValue("RHUMB_LINE")]
			[Description("恒向线")]
			Rhumb_line,

			/// <summary>
			/// <para>法向截面—测地线类型，可以表示将构造的由椭球体表面与通过椭球体表面上两点并垂直于两点起点处椭球面的平面相交而定义的椭球面上任意两点之间的路径。 从 A 点到 B 点与从 B 点到 A 点的法向截面线不同。</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("法向截面")]
			Normal_section,

			/// <summary>
			/// <para>平面线—将使用投影平面中的直线。 平面线通常不像测地线那样准确地表示地球表面的最短距离。 此选项不适用于地理坐标系。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面线")]
			Planar_line,

		}

		/// <summary>
		/// <para>Preserve attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ATTRIBUTES")]
			ATTRIBUTES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTRIBUTES")]
			NO_ATTRIBUTES,

		}

#endregion
	}
}
