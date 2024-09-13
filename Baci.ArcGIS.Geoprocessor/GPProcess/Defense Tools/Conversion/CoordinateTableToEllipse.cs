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
	/// <para>Coordinate Table To Ellipse</para>
	/// <para>坐标表转椭圆</para>
	/// <para>可根据表中存储的坐标和输入数据值创建椭圆要素。</para>
	/// </summary>
	public class CoordinateTableToEllipse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Ellipse Feature Class</para>
		/// <para>包含输出椭圆面要素的要素类。</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GeoRef)</para>
		/// <para>输入表中包含 x 或经度坐标的字段。</para>
		/// </param>
		/// <param name="MajorField">
		/// <para>Major Field</para>
		/// <para>输入表中包含长轴值的字段。</para>
		/// </param>
		/// <param name="MinorField">
		/// <para>Minor Field</para>
		/// <para>输入表中包含短轴值的字段。</para>
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
		public CoordinateTableToEllipse(object InTable, object OutFeatureClass, object XOrLonField, object MajorField, object MinorField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XOrLonField = XOrLonField;
			this.MajorField = MajorField;
			this.MinorField = MinorField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : 坐标表转椭圆</para>
		/// </summary>
		public override string DisplayName() => "坐标表转椭圆";

		/// <summary>
		/// <para>Tool Name : CoordinateTableToEllipse</para>
		/// </summary>
		public override string ToolName() => "CoordinateTableToEllipse";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableToEllipse</para>
		/// </summary>
		public override string ExcuteName() => "defense.CoordinateTableToEllipse";

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
		public override object[] Parameters() => new object[] { InTable, OutFeatureClass, XOrLonField, MajorField, MinorField, InCoordinateFormat, DistanceUnits, YOrLatField, AzimuthField, AzimuthUnits, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Ellipse Feature Class</para>
		/// <para>包含输出椭圆面要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GeoRef)</para>
		/// <para>输入表中包含 x 或经度坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XOrLonField { get; set; }

		/// <summary>
		/// <para>Major Field</para>
		/// <para>输入表中包含长轴值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object MajorField { get; set; }

		/// <summary>
		/// <para>Minor Field</para>
		/// <para>输入表中包含短轴值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object MinorField { get; set; }

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
		/// <para>Distance Units</para>
		/// <para>指定长轴和短轴的测量单位。</para>
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
		/// <para>输入表中包含纬度坐标的字段。</para>
		/// <para>当输入坐标格式参数设置为十进制度 - 两个字段、度和十进制分 - 两个字段或度分秒 - 两个字段时，将使用 Y 字段（纬度）参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object YOrLatField { get; set; }

		/// <summary>
		/// <para>Azimuth Field</para>
		/// <para>输入表中包含椭圆方位角值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object AzimuthField { get; set; }

		/// <summary>
		/// <para>Azimuth Units</para>
		/// <para>指定方位角字段的测量单位。</para>
		/// <para>度—角度将以度为单位。这是默认设置。</para>
		/// <para>密耳—角度将以密耳为单位。</para>
		/// <para>弧度—角度将以弧度为单位。</para>
		/// <para>百分度—角度将以百分度为单位。</para>
		/// <para><see cref="AzimuthUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object AzimuthUnits { get; set; } = "DEGREES";

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
		public CoordinateTableToEllipse SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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
		/// <para>Azimuth Units</para>
		/// </summary>
		public enum AzimuthUnitsEnum 
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

#endregion
	}
}
