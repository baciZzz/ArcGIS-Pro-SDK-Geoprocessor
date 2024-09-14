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
	/// <para>Point File Information</para>
	/// <para>点文件信息</para>
	/// <para>在面或多面体输出中生成有关一个或多个点文件的统计信息。</para>
	/// </summary>
	public class PointFileInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Point Data</para>
		/// <para>存储将要分析的点记录的文件夹和文件的任意组合。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="InFileType">
		/// <para>File Format</para>
		/// <para>指定输入文件的格式。</para>
		/// <para>LAS 格式的激光雷达数据—美国摄影测量及遥感协会 (ASPRS) 定义的激光雷达数据存储格式。</para>
		/// <para>含 XYZ 的 ASCII 文件—XYZ 文件。</para>
		/// <para>含 XYZI 的 ASCII 文件—XYZI 文件。</para>
		/// <para>Generate 格式的 ASCII 文件—GENERATE 文件。</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </param>
		public PointFileInformation(object Input, object OutFeatureClass, object InFileType)
		{
			this.Input = Input;
			this.OutFeatureClass = OutFeatureClass;
			this.InFileType = InFileType;
		}

		/// <summary>
		/// <para>Tool Display Name : 点文件信息</para>
		/// </summary>
		public override string DisplayName() => "点文件信息";

		/// <summary>
		/// <para>Tool Name : PointFileInformation</para>
		/// </summary>
		public override string ToolName() => "PointFileInformation";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PointFileInformation</para>
		/// </summary>
		public override string ExcuteName() => "3d.PointFileInformation";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, OutFeatureClass, InFileType, FileSuffix, InputCoordinateSystem, FolderRecursion, ExtrudeGeometry, DecimalSeparator, SummarizeByClassCode, ImproveLasPointSpacing, MinPointSpacing };

		/// <summary>
		/// <para>Point Data</para>
		/// <para>存储将要分析的点记录的文件夹和文件的任意组合。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>File Format</para>
		/// <para>指定输入文件的格式。</para>
		/// <para>LAS 格式的激光雷达数据—美国摄影测量及遥感协会 (ASPRS) 定义的激光雷达数据存储格式。</para>
		/// <para>含 XYZ 的 ASCII 文件—XYZ 文件。</para>
		/// <para>含 XYZI 的 ASCII 文件—XYZI 文件。</para>
		/// <para>Generate 格式的 ASCII 文件—GENERATE 文件。</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFileType { get; set; } = "LAS";

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>在输入中指定文件夹时导入的文件的后缀。如果提供输入文件夹，则此参数为必填项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FileSuffix { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输入数据的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Include Subfolders</para>
		/// <para>指定是否子文件夹中的数据将用于生成结果。当所选输入文件夹中的子文件夹目录含有数据时，工具将扫描子文件夹。为目录结构中包含的每个文件生成一行输出要素类。</para>
		/// <para>未选中 - 只有在输入文件夹中找到的数据才用于生成结果。这是默认设置。</para>
		/// <para>选中 - 在输入文件夹及其子目录中找到的任何数据均将用于生成结果。</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Extrude Geometry Shapes</para>
		/// <para>指定是将输出创建为 2D 面要素类还是具有拉伸要素（可反映出每个文件中找到的高程范围）的多面体要素类。</para>
		/// <para>未选中 - 输出将创建为 2D 面要素类。这是默认设置。</para>
		/// <para>选中 - 输出将创建为多面体要素类。</para>
		/// <para><see cref="ExtrudeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExtrudeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>文本文件中将用于区分数字的整数部分与其小数部分的小数分隔符。</para>
		/// <para>点—将使用点作为小数字符。 这是默认设置。</para>
		/// <para>逗号—将使用逗号作为小数字符。</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Summarize by class code</para>
		/// <para>指定结果将按类代码还是 LAS 文件汇总 LAS 文件。该选项要求对 LAS 文件进行密集扫描。</para>
		/// <para>未选中 - 每个输出要素都将表示在激光雷达文件中找到的所有数据。这是默认设置。</para>
		/// <para>选中 - 每个输出要素将表示在激光雷达文件中找到的单个类代码。</para>
		/// <para><see cref="SummarizeByClassCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SummarizeByClassCode { get; set; } = "false";

		/// <summary>
		/// <para>Improve LAS files point spacing estimate</para>
		/// <para>指定是否将使用 LAS 文件中的点间距的加强版评估，从而减少由不规则数据分布导致的过高评估。</para>
		/// <para>未选中 - 对 LAS 文件使用规则点间距估计值，其中范围由点数均分。这是默认设置。</para>
		/// <para>选中 - 将分块计算以获取 LAS 文件的更精确的点间距估计值。这可能增加工具的执行时间。</para>
		/// <para><see cref="ImproveLasPointSpacingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ImproveLasPointSpacing { get; set; } = "false";

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MinPointSpacing { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointFileInformation SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Format</para>
		/// </summary>
		public enum InFileTypeEnum 
		{
			/// <summary>
			/// <para>LAS 格式的激光雷达数据—美国摄影测量及遥感协会 (ASPRS) 定义的激光雷达数据存储格式。</para>
			/// </summary>
			[GPValue("LAS")]
			[Description("LAS 格式的激光雷达数据")]
			LAS_format_lidar,

			/// <summary>
			/// <para>含 XYZ 的 ASCII 文件—XYZ 文件。</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("含 XYZ 的 ASCII 文件")]
			ASCII_file_with_XYZ,

			/// <summary>
			/// <para>含 XYZI 的 ASCII 文件—XYZI 文件。</para>
			/// </summary>
			[GPValue("XYZI")]
			[Description("含 XYZI 的 ASCII 文件")]
			ASCII_file_with_XYZI,

			/// <summary>
			/// <para>Generate 格式的 ASCII 文件—GENERATE 文件。</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("Generate 格式的 ASCII 文件")]
			ASCII_file_in_Generate_format,

		}

		/// <summary>
		/// <para>Include Subfolders</para>
		/// </summary>
		public enum FolderRecursionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSION")]
			RECURSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECURSION")]
			NO_RECURSION,

		}

		/// <summary>
		/// <para>Extrude Geometry Shapes</para>
		/// </summary>
		public enum ExtrudeGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTRUSION")]
			EXTRUSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXTRUSION")]
			NO_EXTRUSION,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>点—将使用点作为小数字符。 这是默认设置。</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>逗号—将使用逗号作为小数字符。</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("逗号")]
			Comma,

		}

		/// <summary>
		/// <para>Summarize by class code</para>
		/// </summary>
		public enum SummarizeByClassCodeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SUMMARIZE")]
			SUMMARIZE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUMMARIZE")]
			NO_SUMMARIZE,

		}

		/// <summary>
		/// <para>Improve LAS files point spacing estimate</para>
		/// </summary>
		public enum ImproveLasPointSpacingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LAS_SPACING")]
			LAS_SPACING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LAS_SPACING")]
			NO_LAS_SPACING,

		}

#endregion
	}
}
