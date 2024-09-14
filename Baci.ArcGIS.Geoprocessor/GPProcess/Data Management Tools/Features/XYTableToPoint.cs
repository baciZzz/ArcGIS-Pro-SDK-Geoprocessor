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
	/// <para>XY Table To Point</para>
	/// <para>XY 表转点</para>
	/// <para>根据表中的 x、y 和 z 坐标创建点要素类。</para>
	/// </summary>
	public class XYTableToPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>定义要创建的点要素位置的表（包含 x 和 y 坐标）。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含输出点要素的要素类。</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>输入表中包含 X 坐标（或经度）的字段。</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>输入表中包含 Y 坐标（或纬度）的字段。</para>
		/// </param>
		public XYTableToPoint(object InTable, object OutFeatureClass, object XField, object YField)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XField = XField;
			this.YField = YField;
		}

		/// <summary>
		/// <para>Tool Display Name : XY 表转点</para>
		/// </summary>
		public override string DisplayName() => "XY 表转点";

		/// <summary>
		/// <para>Tool Name : XYTableToPoint</para>
		/// </summary>
		public override string ToolName() => "XYTableToPoint";

		/// <summary>
		/// <para>Tool Excute Name : management.XYTableToPoint</para>
		/// </summary>
		public override string ExcuteName() => "management.XYTableToPoint";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutFeatureClass, XField, YField, ZField!, CoordinateSystem! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>定义要创建的点要素位置的表（包含 x 和 y 坐标）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含输出点要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>输入表中包含 X 坐标（或经度）的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>输入表中包含 Y 坐标（或纬度）的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>输入表中包含 Z 坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ZField { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>x 和 y 坐标的坐标系。 这将是输出要素类的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public XYTableToPoint SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
