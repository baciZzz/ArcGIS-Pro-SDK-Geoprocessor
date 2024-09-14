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
	/// <para>Make XY Event Layer</para>
	/// <para>创建 XY 事件图层</para>
	/// <para>根据表中定义的 X 和 Y 坐标创建新的点要素图层。如果源表包含 Z 坐标（高程值），则可以在创建事件图层时指定该字段。由此工具创建的图层是临时图层。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.XYTableToPoint"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.XYTableToPoint))]
	public class MakeXYEventLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Table">
		/// <para>XY Table</para>
		/// <para>定义要创建的点要素位置的表（包含 x 和 y 坐标）。</para>
		/// </param>
		/// <param name="InXField">
		/// <para>X Field</para>
		/// <para>输入表中包含 X 坐标（或经度）的字段。</para>
		/// </param>
		/// <param name="InYField">
		/// <para>Y Field</para>
		/// <para>输入表中包含 Y 坐标（或纬度）的字段。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Layer Name</para>
		/// <para>输出点事件图层的名称。</para>
		/// </param>
		public MakeXYEventLayer(object Table, object InXField, object InYField, object OutLayer)
		{
			this.Table = Table;
			this.InXField = InXField;
			this.InYField = InYField;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 XY 事件图层</para>
		/// </summary>
		public override string DisplayName() => "创建 XY 事件图层";

		/// <summary>
		/// <para>Tool Name : MakeXYEventLayer</para>
		/// </summary>
		public override string ToolName() => "MakeXYEventLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeXYEventLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeXYEventLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Table, InXField, InYField, OutLayer, SpatialReference!, InZField! };

		/// <summary>
		/// <para>XY Table</para>
		/// <para>定义要创建的点要素位置的表（包含 x 和 y 坐标）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object Table { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>输入表中包含 X 坐标（或经度）的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object InXField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>输入表中包含 Y 坐标（或纬度）的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object InYField { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>输出点事件图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>X 字段和 Y 字段参数中指定的坐标的空间参考。这将是输出事件图层的空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>输入表中包含 Z 坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object? InZField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeXYEventLayer SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
