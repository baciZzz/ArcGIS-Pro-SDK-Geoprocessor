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
	/// <para>Generate Grid From Area</para>
	/// <para>根据区域生成格网</para>
	/// <para>基于边界面在指定区域上以自定义大小生成格网化参考图形 (GRG)。</para>
	/// </summary>
	public class GenerateGRGFromArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeature">
		/// <para>Input Feature</para>
		/// <para>将基于 GRG 的输入面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含 GRG 的输出面要素类。</para>
		/// </param>
		public GenerateGRGFromArea(object InFeature, object OutFeatureClass)
		{
			this.InFeature = InFeature;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 根据区域生成格网</para>
		/// </summary>
		public override string DisplayName() => "根据区域生成格网";

		/// <summary>
		/// <para>Tool Name : GenerateGRGFromArea</para>
		/// </summary>
		public override string ToolName() => "GenerateGRGFromArea";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateGRGFromArea</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateGRGFromArea";

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
		public override object[] Parameters() => new object[] { InFeature, OutFeatureClass, CellWidth!, CellHeight!, CellUnits!, LabelStartPosition!, LabelFormat!, LabelSeparator! };

		/// <summary>
		/// <para>Input Feature</para>
		/// <para>将基于 GRG 的输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeature { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含 GRG 的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Cell Width</para>
		/// <para>像元的宽度。 测量单位由像元单位参数指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Cell Options")]
		public object? CellWidth { get; set; } = "1000";

		/// <summary>
		/// <para>Cell Height</para>
		/// <para>像元的高度。 测量单位由像元单位参数指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Cell Options")]
		public object? CellHeight { get; set; } = "1000";

		/// <summary>
		/// <para>Cell Units</para>
		/// <para>指定像元宽度和高度的测量单位。</para>
		/// <para>米—单位将为米。 这是默认设置。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>美国测量英尺—单位将为美国测量英尺。</para>
		/// <para><see cref="CellUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Cell Options")]
		public object? CellUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Label Start Position</para>
		/// <para>指定将开始进行标记的格网像元。</para>
		/// <para>左上角—标注位置将位于左上角。 这是默认设置。</para>
		/// <para>左下角—标注位置将位于左下角。</para>
		/// <para>右上角—标注位置将位于右上角。</para>
		/// <para>右下角—标注位置将位于右下角。</para>
		/// <para><see cref="LabelStartPositionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Label Options")]
		public object? LabelStartPosition { get; set; } = "UPPER_LEFT";

		/// <summary>
		/// <para>Label Format</para>
		/// <para>指定每个格网像元的标注类型。</para>
		/// <para>字母-数字—标注将使用字母字符、分隔符和数字。 这是默认设置。</para>
		/// <para>字母-字母—标注将使用字母字符、分隔符和附加字母字符。</para>
		/// <para>数字—标注将为数字。</para>
		/// <para><see cref="LabelFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Label Options")]
		public object? LabelFormat { get; set; } = "ALPHA_NUMERIC";

		/// <summary>
		/// <para>Label Separator</para>
		/// <para>指定当标注格式参数设置为字母-字母（例如 A-A、A-AA、AA-A）时，将在 x 值和 y 值之间使用的分隔符。</para>
		/// <para>连字符—标注分隔符将为连字符。 这是默认设置。</para>
		/// <para>逗号—标注分隔符将为逗号。</para>
		/// <para>句点—标注分隔符将为句号。</para>
		/// <para>正斜线—标注分隔符将为正斜线。</para>
		/// <para><see cref="LabelSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Label Options")]
		public object? LabelSeparator { get; set; } = "-";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateGRGFromArea SetEnviroment(object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Units</para>
		/// </summary>
		public enum CellUnitsEnum 
		{
			/// <summary>
			/// <para>米—单位将为米。 这是默认设置。</para>
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
		/// <para>Label Start Position</para>
		/// </summary>
		public enum LabelStartPositionEnum 
		{
			/// <summary>
			/// <para>左上角—标注位置将位于左上角。 这是默认设置。</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("左上角")]
			Upper_left,

			/// <summary>
			/// <para>左下角—标注位置将位于左下角。</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("左下角")]
			Lower_left,

			/// <summary>
			/// <para>右上角—标注位置将位于右上角。</para>
			/// </summary>
			[GPValue("UPPER_RIGHT")]
			[Description("右上角")]
			Upper_right,

			/// <summary>
			/// <para>右下角—标注位置将位于右下角。</para>
			/// </summary>
			[GPValue("LOWER_RIGHT")]
			[Description("右下角")]
			Lower_right,

		}

		/// <summary>
		/// <para>Label Format</para>
		/// </summary>
		public enum LabelFormatEnum 
		{
			/// <summary>
			/// <para>字母-数字—标注将使用字母字符、分隔符和数字。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALPHA_NUMERIC")]
			[Description("字母-数字")]
			ALPHA_NUMERIC,

			/// <summary>
			/// <para>字母-字母—标注将使用字母字符、分隔符和附加字母字符。</para>
			/// </summary>
			[GPValue("ALPHA_ALPHA")]
			[Description("字母-字母")]
			ALPHA_ALPHA,

			/// <summary>
			/// <para>数字—标注将为数字。</para>
			/// </summary>
			[GPValue("NUMERIC")]
			[Description("数字")]
			Numeric,

		}

		/// <summary>
		/// <para>Label Separator</para>
		/// </summary>
		public enum LabelSeparatorEnum 
		{
			/// <summary>
			/// <para>连字符—标注分隔符将为连字符。 这是默认设置。</para>
			/// </summary>
			[GPValue("-")]
			[Description("连字符")]
			Hyphen,

			/// <summary>
			/// <para>逗号—标注分隔符将为逗号。</para>
			/// </summary>
			[GPValue(",")]
			[Description("逗号")]
			Comma,

			/// <summary>
			/// <para>句点—标注分隔符将为句号。</para>
			/// </summary>
			[GPValue(".")]
			[Description("句点")]
			Period,

			/// <summary>
			/// <para>正斜线—标注分隔符将为正斜线。</para>
			/// </summary>
			[GPValue("/")]
			[Description("正斜线")]
			Forward_slash,

		}

#endregion
	}
}
