using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Create Buffers</para>
	/// <para>创建缓冲区</para>
	/// <para>通过点、线、面要素创建覆盖指定距离的面。</para>
	/// </summary>
	public class CreateBuffers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>要进行缓冲的点、线或面要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public CreateBuffers(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建缓冲区</para>
		/// </summary>
		public override string DisplayName() => "创建缓冲区";

		/// <summary>
		/// <para>Tool Name : CreateBuffers</para>
		/// </summary>
		public override string ToolName() => "CreateBuffers";

		/// <summary>
		/// <para>Tool Excute Name : sfa.CreateBuffers</para>
		/// </summary>
		public override string ExcuteName() => "sfa.CreateBuffers";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Outputname, Distances!, Field!, Units!, Dissolvetype!, Ringtype!, Sidetype!, Endtype!, Output! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要进行缓冲的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>用于缓冲输入要素的距离值列表。您必须提供距离或距离字段的值。可以输入一个距离值或多个距离值。距离值的单位由距离单位提供。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Distances { get; set; }

		/// <summary>
		/// <para>Distance Field</para>
		/// <para>每个要素包含一个缓冲距离的输入图层中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>缓冲距离的单位。如果已设置像元大小，则必须为其赋值。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para>海里—海里</para>
		/// <para>码—码</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Units { get; set; } = "METERS";

		/// <summary>
		/// <para>Dissolve Type</para>
		/// <para>确定重叠缓冲区的处理方式。</para>
		/// <para>未融合— 保留重叠区域。这是默认设置。</para>
		/// <para>融合重叠区域— 合并重叠区域。</para>
		/// <para><see cref="DissolvetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Dissolvetype { get; set; } = "NONE";

		/// <summary>
		/// <para>Buffer Ring Type</para>
		/// <para>确定多距离缓冲区的处理方式。</para>
		/// <para>同心重叠圆盘— 缓冲区为同心并将重叠。例如，如果距离为 10 和 14，则结果将为两个缓冲区，一个为 0 到 10，另一个为 0 到 14。这是默认设置。</para>
		/// <para>非重叠圆环— 缓冲区将不会重叠。例如，如果距离为 10 和 14，则结果将为两个缓冲区，一个为 0 到 10，另一个为 10 到 14。</para>
		/// <para><see cref="RingtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Ringtype { get; set; } = "DISKS";

		/// <summary>
		/// <para>Side Type</para>
		/// <para>缓冲线要素时，您可以选择要缓冲的线的某一侧。通常，您可以选择两侧（全部，此为默认设置）。左侧和右侧的确定犹如从该线的第一个 x,y 坐标（起点坐标）步行至最后一个 x,y 坐标（终点坐标）。选择左侧或右侧通常意味着您知道线要素在特定的方向进行创建和存储（例如，河流网络的上游或下游）。</para>
		/// <para>当缓冲面要素时，您可以选择缓冲区中是否包括正在缓冲的面。</para>
		/// <para>如果没有提供侧类型，则正在缓冲的面将包含在结果缓冲区中。这是面要素的默认选项。</para>
		/// <para>全部— 将缓冲线的两侧。这是线要素的默认选项。</para>
		/// <para>右— 仅在线的右侧进行缓冲。</para>
		/// <para>左— 仅在线的右侧进行缓冲。</para>
		/// <para>外部— 当缓冲面时，正在缓冲的面将排除在结果缓冲区之外。</para>
		/// <para><see cref="SidetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Sidetype { get; set; }

		/// <summary>
		/// <para>End Type</para>
		/// <para>线输入要素末端的缓冲区形状。此参数对于面输入要素无效。在线的两端，缓冲区可以是圆的（圆形）或者直的（平面）。</para>
		/// <para>圆形末端— 在线的两端，缓冲区将会是圆的。这是默认设置。</para>
		/// <para>平面末端— 在线的两端，缓冲区将会是平面或直的。</para>
		/// <para><see cref="EndtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Endtype { get; set; } = "ROUND";

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateBuffers SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>米—米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—英尺</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>英里—英里</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—海里</para>
			/// </summary>
			[GPValue("NAUTICALMILES")]
			[Description("海里")]
			Nautical_miles,

			/// <summary>
			/// <para>码—码</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

		}

		/// <summary>
		/// <para>Dissolve Type</para>
		/// </summary>
		public enum DissolvetypeEnum 
		{
			/// <summary>
			/// <para>未融合— 保留重叠区域。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("未融合")]
			No_dissolve,

			/// <summary>
			/// <para>融合重叠区域— 合并重叠区域。</para>
			/// </summary>
			[GPValue("DISSOLVE")]
			[Description("融合重叠区域")]
			Dissolve_overlapping_areas,

		}

		/// <summary>
		/// <para>Buffer Ring Type</para>
		/// </summary>
		public enum RingtypeEnum 
		{
			/// <summary>
			/// <para>同心重叠圆盘— 缓冲区为同心并将重叠。例如，如果距离为 10 和 14，则结果将为两个缓冲区，一个为 0 到 10，另一个为 0 到 14。这是默认设置。</para>
			/// </summary>
			[GPValue("DISKS")]
			[Description("同心重叠圆盘")]
			Concentric_overlapping_disks,

			/// <summary>
			/// <para>非重叠圆环— 缓冲区将不会重叠。例如，如果距离为 10 和 14，则结果将为两个缓冲区，一个为 0 到 10，另一个为 10 到 14。</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("非重叠圆环")]
			Nonoverlapping_rings,

		}

		/// <summary>
		/// <para>Side Type</para>
		/// </summary>
		public enum SidetypeEnum 
		{
			/// <summary>
			/// <para>全部— 将缓冲线的两侧。这是线要素的默认选项。</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("全部")]
			Full,

			/// <summary>
			/// <para>右— 仅在线的右侧进行缓冲。</para>
			/// </summary>
			[GPValue("RIGHT")]
			[Description("右")]
			Right,

			/// <summary>
			/// <para>左— 仅在线的右侧进行缓冲。</para>
			/// </summary>
			[GPValue("LEFT")]
			[Description("左")]
			Left,

			/// <summary>
			/// <para>外部— 当缓冲面时，正在缓冲的面将排除在结果缓冲区之外。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

		/// <summary>
		/// <para>End Type</para>
		/// </summary>
		public enum EndtypeEnum 
		{
			/// <summary>
			/// <para>圆形末端— 在线的两端，缓冲区将会是圆的。这是默认设置。</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("圆形末端")]
			Round_ends,

			/// <summary>
			/// <para>平面末端— 在线的两端，缓冲区将会是平面或直的。</para>
			/// </summary>
			[GPValue("FLAT")]
			[Description("平面末端")]
			Flat_ends,

		}

#endregion
	}
}
