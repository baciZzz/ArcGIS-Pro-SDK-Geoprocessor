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
	/// <para>XY To Line</para>
	/// <para>XY 转线</para>
	/// <para>创建要素类，其中包含基于表的起点 x 坐标字段、起点 y 坐标字段、终点 x 坐标字段和终点 y 坐标字段中的值构建的大地测量线要素。</para>
	/// </summary>
	public class XYToLine : AbstractGPProcess
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
		/// <para>包含增密测地线的输出要素类。</para>
		/// </param>
		/// <param name="StartxField">
		/// <para>Start X Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 x 坐标（或经度）。</para>
		/// </param>
		/// <param name="StartyField">
		/// <para>Start Y Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 y 坐标（或纬度）。</para>
		/// </param>
		/// <param name="EndxField">
		/// <para>End X Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的终点 x 坐标（或经度）。</para>
		/// </param>
		/// <param name="EndyField">
		/// <para>End Y Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的终点 y 坐标（或纬度）。</para>
		/// </param>
		public XYToLine(object InTable, object OutFeatureclass, object StartxField, object StartyField, object EndxField, object EndyField)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.StartxField = StartxField;
			this.StartyField = StartyField;
			this.EndxField = EndxField;
			this.EndyField = EndyField;
		}

		/// <summary>
		/// <para>Tool Display Name : XY 转线</para>
		/// </summary>
		public override string DisplayName() => "XY 转线";

		/// <summary>
		/// <para>Tool Name : XYToLine</para>
		/// </summary>
		public override string ToolName() => "XYToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.XYToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.XYToLine";

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
		public override object[] Parameters() => new object[] { InTable, OutFeatureclass, StartxField, StartyField, EndxField, EndyField, LineType, IdField, SpatialReference, Attributes };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表。可以是文本文件、CSV 文件、Excel 文件、dBASE 表或地理数据库表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含增密测地线的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Start X Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 x 坐标（或经度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object StartxField { get; set; }

		/// <summary>
		/// <para>Start Y Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的起点 y 坐标（或纬度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object StartyField { get; set; }

		/// <summary>
		/// <para>End X Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的终点 x 坐标（或经度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object EndxField { get; set; }

		/// <summary>
		/// <para>End Y Field</para>
		/// <para>输入表中的数值字段，其中包含在空间参考参数所指定的输出坐标系中进行定位的线的终点 y 坐标（或纬度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object EndyField { get; set; }

		/// <summary>
		/// <para>Line Type</para>
		/// <para>指定要构造的测地线类型。</para>
		/// <para>测地线— 测地线类型，可以最准确地表示将构造的地球表面任意两点之间的最短距离。测地线的数学定义十分复杂冗长，因此此处略去该定义。这是默认设置。</para>
		/// <para>大圆—测地线类型，可以表示将构造的地球表面与通过地心的平面的相交线上任意两点之间的路径。根据空间参考参数所指定的输出坐标系，在基于椭球体的坐标系中，该线表示大椭圆；在基于球体的坐标系中，该线表示唯一的大圆（球面上最大半径的圆）。</para>
		/// <para>恒向线—测地线类型，又称为等角航线 (loxodrome line)，可以表示将构造的通过以极点为起点的等方位角所定义的椭球体表面上的任意两点之间的路径。等角航线在墨卡托投影中显示为直线。</para>
		/// <para>法向截面—测地线类型，可以表示将构造的由椭球体表面与通过椭球体表面上两点并垂直于两点起点处椭球面的平面相交而定义的椭球面上任意两点之间的路径。因此，从 A 点到 B 点与从 B 点到 A 点的法向截面线不同。</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LineType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>ID</para>
		/// <para>输入表中的字段。此字段和值均包含在输出中，可用于连接输出要素和输入表中的记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出要素类的空间参考。默认值为 GCS_WGS_1984 或输入坐标系（如果非“Unknown”）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; } = "{B286C06B-0879-11D2-AACA-00C04FA33C20};IsHighPrecision";

		/// <summary>
		/// <para>Preserve attributes</para>
		/// <para>指定是否将其余输入字段写入输出要素类。</para>
		/// <para>未选中 - 不会将其余输入字段写入输出要素类。这是默认设置。</para>
		/// <para>选中 - 其余输入字段将包含在输出要素类中。还将向输出要素类添加新字段 ORIG_FID 以存储输入要素 ID 值。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Attributes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public XYToLine SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>测地线— 测地线类型，可以最准确地表示将构造的地球表面任意两点之间的最短距离。测地线的数学定义十分复杂冗长，因此此处略去该定义。这是默认设置。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

			/// <summary>
			/// <para>大圆—测地线类型，可以表示将构造的地球表面与通过地心的平面的相交线上任意两点之间的路径。根据空间参考参数所指定的输出坐标系，在基于椭球体的坐标系中，该线表示大椭圆；在基于球体的坐标系中，该线表示唯一的大圆（球面上最大半径的圆）。</para>
			/// </summary>
			[GPValue("GREAT_CIRCLE")]
			[Description("大圆")]
			Great_circle,

			/// <summary>
			/// <para>恒向线—测地线类型，又称为等角航线 (loxodrome line)，可以表示将构造的通过以极点为起点的等方位角所定义的椭球体表面上的任意两点之间的路径。等角航线在墨卡托投影中显示为直线。</para>
			/// </summary>
			[GPValue("RHUMB_LINE")]
			[Description("恒向线")]
			Rhumb_line,

			/// <summary>
			/// <para>法向截面—测地线类型，可以表示将构造的由椭球体表面与通过椭球体表面上两点并垂直于两点起点处椭球面的平面相交而定义的椭球面上任意两点之间的路径。因此，从 A 点到 B 点与从 B 点到 A 点的法向截面线不同。</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("法向截面")]
			Normal_section,

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
