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
	/// <para>Generate Coordinate Notations</para>
	/// <para>生成坐标符号</para>
	/// <para>用于将表中的源坐标转换为多种坐标格式。</para>
	/// </summary>
	public class GenerateCoordinateNotations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>包含转换后的坐标的输出表。</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>输入表中包含 x 或经度坐标的字段。</para>
		/// </param>
		/// <param name="InCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>指定输入表坐标的格式。</para>
		/// <para>十进制度 - 一个字段—坐标将采用存储在单个字段中的十进制度坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>十进制度 - 两个字段—坐标将采用存储在两个表字段中的十进制度坐标对格式。 这是默认设置。</para>
		/// <para>度和十进制分 - 一个字段—坐标将采用存储在单个表字段中的度和十进制分坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度和十进制分 - 两个字段—坐标将采用存储在两个表字段中的度和十进制分坐标对格式。</para>
		/// <para>度分秒 - 一个字段—坐标将采用存储在单个表字段中的度、分和秒坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度分秒 - 两个字段—坐标将采用存储在两个表字段中的度、分和秒坐标对格式。</para>
		/// <para>全球区域参考系统—坐标将采用全球区域参考系格式。</para>
		/// <para>世界地理参考系—坐标将采用世界地理参考系格式。</para>
		/// <para>通用横轴墨卡托坐标带—坐标将采用通用横轴墨卡托坐标带格式。</para>
		/// <para>通用横轴墨卡托坐标区域—坐标将采用通用横轴墨卡托坐标区域格式。</para>
		/// <para>美国国家格网—坐标将采用美国国家网格格式。</para>
		/// <para>军事格网参考系—坐标将采用军事格网参考系格式。</para>
		/// </param>
		public GenerateCoordinateNotations(object InTable, object OutTable, object XOrLonField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.XOrLonField = XOrLonField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成坐标符号</para>
		/// </summary>
		public override string DisplayName() => "生成坐标符号";

		/// <summary>
		/// <para>Tool Name : GenerateCoordinateNotations</para>
		/// </summary>
		public override string ToolName() => "GenerateCoordinateNotations";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateCoordinateNotations</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateCoordinateNotations";

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
		public override object[] Parameters() => new object[] { InTable, OutTable, XOrLonField, InCoordinateFormat, YOrLatField!, CoordinateSystem! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含源坐标的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含转换后的坐标的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

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
		/// <para>十进制度 - 两个字段—坐标将采用存储在两个表字段中的十进制度坐标对格式。 这是默认设置。</para>
		/// <para>度和十进制分 - 一个字段—坐标将采用存储在单个表字段中的度和十进制分坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度和十进制分 - 两个字段—坐标将采用存储在两个表字段中的度和十进制分坐标对格式。</para>
		/// <para>度分秒 - 一个字段—坐标将采用存储在单个表字段中的度、分和秒坐标对格式，其中坐标以空格、逗号或斜线分隔。</para>
		/// <para>度分秒 - 两个字段—坐标将采用存储在两个表字段中的度、分和秒坐标对格式。</para>
		/// <para>全球区域参考系统—坐标将采用全球区域参考系格式。</para>
		/// <para>世界地理参考系—坐标将采用世界地理参考系格式。</para>
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
		public object? YOrLatField { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>输出表中的坐标的空间参考。 默认值为 GCS_WGS_1984。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCoordinateNotations SetEnviroment(object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
