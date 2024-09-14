using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Feature Class Z To ASCII</para>
	/// <para>要素类 Z 转 ASCII</para>
	/// <para>将 3D 要素导出到存储有 GENERATE、XYZ 或专用标准数据的 ASCII 文本文件。</para>
	/// </summary>
	public class FeatureClassZToASCII : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>导出到 ASCII 文件的 3D 点、多点、折线或面要素类。</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>将在其中写入输出文件的文件夹。</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output Text File</para>
		/// <para>生成的 ASCII 文件的名称。</para>
		/// <para>如果线或面要素类导出为 XYZ 格式，则使用文件名作为基础名称。因为 XYZ 格式每个文件仅支持一条线或一个面，所以每个要素都将具有唯一的文件输出。多部件要素的各部件也将写入单独的文件。文件名将附有每个要素的 OID，以及使各文件名唯一所需的任何附加字符。</para>
		/// </param>
		public FeatureClassZToASCII(object InFeatureClass, object OutputLocation, object OutFile)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutputLocation = OutputLocation;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素类 Z 转 ASCII</para>
		/// </summary>
		public override string DisplayName() => "要素类 Z 转 ASCII";

		/// <summary>
		/// <para>Tool Name : FeatureClassZToASCII</para>
		/// </summary>
		public override string ToolName() => "FeatureClassZToASCII";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FeatureClassZToASCII</para>
		/// </summary>
		public override string ExcuteName() => "3d.FeatureClassZToASCII";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutputLocation, OutFile, Format, Delimiter, DecimalFormat, DigitsAfterDecimal, DecimalSeparator, DerivedOutput };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>导出到 ASCII 文件的 3D 点、多点、折线或面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>将在其中写入输出文件的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Output Text File</para>
		/// <para>生成的 ASCII 文件的名称。</para>
		/// <para>如果线或面要素类导出为 XYZ 格式，则使用文件名作为基础名称。因为 XYZ 格式每个文件仅支持一条线或一个面，所以每个要素都将具有唯一的文件输出。多部件要素的各部件也将写入单独的文件。文件名将附有每个要素的 OID，以及使各文件名唯一所需的任何附加字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFile { get; set; } = "pf.txt";

		/// <summary>
		/// <para>ASCII Format</para>
		/// <para>指定要创建的 ASCII 文件的格式。</para>
		/// <para>GENERATE—以 GENERATE 格式写入输出。这是默认设置。</para>
		/// <para>XYZ—写入输入要素的 XYZ 信息。将为输入要素中的各线或面创建一个文件。</para>
		/// <para>专用标准—为可用于外部图表绘制应用程序中的线要素写入专用标准信息。</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "GENERATE";

		/// <summary>
		/// <para>Delimiter</para>
		/// <para>指定将指示文本文件表的列中条目间隔的分隔符。</para>
		/// <para>空格—空格将用于分隔字段值。这是默认设置。</para>
		/// <para>逗号—逗号将用于分隔字段值。如果小数分隔符也是逗号，则此选项不适用。</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Delimiter { get; set; } = "SPACE";

		/// <summary>
		/// <para>Decimal Notation</para>
		/// <para>指定将确定输出文件中存储的有效数字位数的方法。</para>
		/// <para>自动确定—在移除多余的后补零时，自动确定保留可用精度所需的有效数字位数。这是默认设置。</para>
		/// <para>指定数目—有效数字位数在小数点后的位数参数中定义。</para>
		/// <para><see cref="DecimalFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalFormat { get; set; } = "AUTOMATIC";

		/// <summary>
		/// <para>Digits after Decimal</para>
		/// <para>将在浮点值的小数部分写入到输出文件之后写入的位数。当十进制记数法参数设置为指定数量（Python 中的 decimal_format=FIXED）时，将使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object DigitsAfterDecimal { get; set; } = "3";

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>指定将区分数字的整数部分与其小数部分的小数字符。</para>
		/// <para>点—点用作小数字符。这是默认设置。</para>
		/// <para>逗号—逗号用作小数字符。</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object DerivedOutput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureClassZToASCII SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>ASCII Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>GENERATE—以 GENERATE 格式写入输出。这是默认设置。</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("GENERATE")]
			GENERATE,

			/// <summary>
			/// <para>XYZ—写入输入要素的 XYZ 信息。将为输入要素中的各线或面创建一个文件。</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("XYZ")]
			XYZ,

			/// <summary>
			/// <para>专用标准—为可用于外部图表绘制应用程序中的线要素写入专用标准信息。</para>
			/// </summary>
			[GPValue("PROFILE")]
			[Description("专用标准")]
			Profile,

		}

		/// <summary>
		/// <para>Delimiter</para>
		/// </summary>
		public enum DelimiterEnum 
		{
			/// <summary>
			/// <para>逗号—逗号将用于分隔字段值。如果小数分隔符也是逗号，则此选项不适用。</para>
			/// </summary>
			[GPValue("COMMA")]
			[Description("逗号")]
			Comma,

			/// <summary>
			/// <para>空格—空格将用于分隔字段值。这是默认设置。</para>
			/// </summary>
			[GPValue("SPACE")]
			[Description("空格")]
			Space,

		}

		/// <summary>
		/// <para>Decimal Notation</para>
		/// </summary>
		public enum DecimalFormatEnum 
		{
			/// <summary>
			/// <para>自动确定—在移除多余的后补零时，自动确定保留可用精度所需的有效数字位数。这是默认设置。</para>
			/// </summary>
			[GPValue("AUTOMATIC")]
			[Description("自动确定")]
			Automatically_Determined,

			/// <summary>
			/// <para>指定数目—有效数字位数在小数点后的位数参数中定义。</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("指定数目")]
			Specified_Number,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>点—点用作小数字符。这是默认设置。</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>逗号—逗号用作小数字符。</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("逗号")]
			Comma,

		}

#endregion
	}
}
