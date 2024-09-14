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
	/// <para>Coordinate Table To Point</para>
	/// <para>坐标表转点</para>
	/// <para>可根据表中存储的坐标创建点要素类。</para>
	/// </summary>
	public class CoordinateTableToPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Point Feature Class</para>
		/// <para>包含输出点要素的要素类。</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含 x 或经度坐标的字段。</para>
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
		public CoordinateTableToPoint(object InTable, object OutFeatureClass, object XOrLonField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XOrLonField = XOrLonField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : 坐标表转点</para>
		/// </summary>
		public override string DisplayName() => "坐标表转点";

		/// <summary>
		/// <para>Tool Name : CoordinateTableToPoint</para>
		/// </summary>
		public override string ToolName() => "CoordinateTableToPoint";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableToPoint</para>
		/// </summary>
		public override string ExcuteName() => "defense.CoordinateTableToPoint";

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
		public override object[] Parameters() => new object[] { InTable, OutFeatureClass, XOrLonField, InCoordinateFormat, YOrLatField, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// <para>包含输出点要素的要素类。</para>
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
		/// <para>Y Field (latitude)</para>
		/// <para>输入表中包含 y 或纬度坐标的字段。</para>
		/// <para>当输入坐标格式参数设置为十进制度 - 两个字段、度和十进制分 - 两个字段或度分秒 - 两个字段时，将使用 Y 字段（纬度）参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object YOrLatField { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>输出要素类的空间参考。 默认值为 GCS_WGS_1984。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CoordinateTableToPoint SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
