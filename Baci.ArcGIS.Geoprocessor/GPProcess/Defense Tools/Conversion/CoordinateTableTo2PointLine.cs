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
	/// <para>Coordinate Table To 2-Point Line</para>
	/// <para>坐标表转 2 点线</para>
	/// <para>可根据表中存储的坐标创建 2 点线要素。</para>
	/// </summary>
	public class CoordinateTableTo2PointLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Line Feature Class</para>
		/// <para>包含输出线要素的要素类。</para>
		/// </param>
		/// <param name="StartXOrLonField">
		/// <para>Start X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含起点 x 或经度坐标的字段。</para>
		/// </param>
		/// <param name="EndXOrLonField">
		/// <para>End X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含终点 x 或经度坐标的字段。</para>
		/// </param>
		/// <param name="InCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>指定点坐标的格式。</para>
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
		public CoordinateTableTo2PointLine(object InTable, object OutFeatureClass, object StartXOrLonField, object EndXOrLonField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.StartXOrLonField = StartXOrLonField;
			this.EndXOrLonField = EndXOrLonField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : 坐标表转 2 点线</para>
		/// </summary>
		public override string DisplayName() => "坐标表转 2 点线";

		/// <summary>
		/// <para>Tool Name : CoordinateTableTo2PointLine</para>
		/// </summary>
		public override string ToolName() => "CoordinateTableTo2PointLine";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableTo2PointLine</para>
		/// </summary>
		public override string ExcuteName() => "defense.CoordinateTableTo2PointLine";

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
		public override object[] Parameters() => new object[] { InTable, OutFeatureClass, StartXOrLonField, EndXOrLonField, InCoordinateFormat, StartYOrLatField, EndYOrLatField, LineType, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// <para>包含输出线要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Start X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含起点 x 或经度坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object StartXOrLonField { get; set; }

		/// <summary>
		/// <para>End X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含终点 x 或经度坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object EndXOrLonField { get; set; }

		/// <summary>
		/// <para>Input Coordinate Format</para>
		/// <para>指定点坐标的格式。</para>
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
		/// <para>Start Y Field (latitude)</para>
		/// <para>输入表中包含起点 y 或纬度坐标的字段。</para>
		/// <para>当输入坐标格式参数设置为十进制度 - 两个字段、度和十进制分 - 两个字段或度分秒 - 两个字段时，将使用起点 Y 字段（纬度）参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object StartYOrLatField { get; set; }

		/// <summary>
		/// <para>End Y Field (latitude)</para>
		/// <para>输入表中包含终点 y 或纬度坐标的字段。</para>
		/// <para>当输入坐标格式参数设置为十进制度 - 两个字段、度和十进制分 - 两个字段或度分秒 - 两个字段时，将使用终点 Y 字段（纬度）参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object EndYOrLatField { get; set; }

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
		public CoordinateTableTo2PointLine SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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
