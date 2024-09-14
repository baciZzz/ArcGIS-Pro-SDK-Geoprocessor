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
	/// <para>Table To Ellipse</para>
	/// <para>表转椭圆</para>
	/// <para>创建一个要素类，该要素类中包含根据表的 x 坐标字段、y 坐标字段、长轴字段、短轴字段和方位角字段中的值所构建的大地测量椭圆要素。</para>
	/// </summary>
	public class TableToEllipse : AbstractGPProcess
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
		/// <para>输出要素类，其中包含表示为增密折线的大地测量椭圆。</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>输入表中的数值型字段，其中包含在空间参考参数所指定的输出坐标系中用于定位的椭圆中心点的 x 坐标（或经线）。</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>输入表中的数值型字段，其中包含在空间参考参数所指定的输出坐标系中用于定位的椭圆中心点的 y 坐标（或纬线）。</para>
		/// </param>
		/// <param name="MajorField">
		/// <para>Major Field</para>
		/// <para>输入表中包含椭圆长轴长度的数值型字段。</para>
		/// </param>
		/// <param name="MinorField">
		/// <para>Minor Field</para>
		/// <para>输入表中包含椭圆短轴长度的数值型字段。</para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Units</para>
		/// <para>指定长轴字段和短轴字段参数将使用的单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>美国测量英尺—单位将为美国测量英尺。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		public TableToEllipse(object InTable, object OutFeatureclass, object XField, object YField, object MajorField, object MinorField, object DistanceUnits)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.XField = XField;
			this.YField = YField;
			this.MajorField = MajorField;
			this.MinorField = MinorField;
			this.DistanceUnits = DistanceUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转椭圆</para>
		/// </summary>
		public override string DisplayName() => "表转椭圆";

		/// <summary>
		/// <para>Tool Name : TableToEllipse</para>
		/// </summary>
		public override string ToolName() => "TableToEllipse";

		/// <summary>
		/// <para>Tool Excute Name : management.TableToEllipse</para>
		/// </summary>
		public override string ExcuteName() => "management.TableToEllipse";

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
		public override object[] Parameters() => new object[] { InTable, OutFeatureclass, XField, YField, MajorField, MinorField, DistanceUnits, AzimuthField, AzimuthUnits, IdField, SpatialReference, Attributes };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表。可以是文本文件、CSV 文件、Excel 文件、dBASE 表或地理数据库表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类，其中包含表示为增密折线的大地测量椭圆。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>输入表中的数值型字段，其中包含在空间参考参数所指定的输出坐标系中用于定位的椭圆中心点的 x 坐标（或经线）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>输入表中的数值型字段，其中包含在空间参考参数所指定的输出坐标系中用于定位的椭圆中心点的 y 坐标（或纬线）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Major Field</para>
		/// <para>输入表中包含椭圆长轴长度的数值型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object MajorField { get; set; }

		/// <summary>
		/// <para>Minor Field</para>
		/// <para>输入表中包含椭圆短轴长度的数值型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object MinorField { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>指定长轴字段和短轴字段参数将使用的单位。</para>
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
		/// <para>Azimuth Field</para>
		/// <para>输入表中的数值型字段，其中包含输出椭圆的长轴旋转的方位角值。 这些值是以北为基准方向按顺时针方向进行测量的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object AzimuthField { get; set; }

		/// <summary>
		/// <para>Azimuth Units</para>
		/// <para>指定方位角字段参数将使用的单位。</para>
		/// <para><see cref="AzimuthUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AzimuthUnits { get; set; } = "DEGREES";

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
		public TableToEllipse SetEnviroment(object scratchWorkspace = null, object workspace = null)
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
		/// <para>Azimuth Units</para>
		/// </summary>
		public enum AzimuthUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("十进制度")]
			Decimal_degrees,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MILS")]
			[Description("密耳")]
			Mils,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RADS")]
			[Description("弧度")]
			Radians,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("百分度")]
			Gradians,

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
