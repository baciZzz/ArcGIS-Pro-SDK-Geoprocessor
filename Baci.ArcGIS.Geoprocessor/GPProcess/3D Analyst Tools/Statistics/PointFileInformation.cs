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
	/// <para>创建面或多面体输出，它们用于捕获有关一个或多个 ASCII 或 LAS 格式点文件的空间范围和统计信息。</para>
	/// </summary>
	public class PointFileInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Point Data</para>
		/// <para>待处理的点数据。 支持的输入包括 LAS 数据集、.las 文件、.zlas 文件和包含点记录的 ASCII 文件。 也可以将一个或多个包含文件的文件夹指定为输入。 包含文件夹时，必须在文件后缀参数中指定点文件的文件后缀。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="InFileType">
		/// <para>File Format</para>
		/// <para>指定输入文件的格式。</para>
		/// <para>LAS 格式激光雷达—输入文件的格式是 LAS 格式激光雷达。</para>
		/// <para>含 XYZ 的 ASCII 文件—输入文件的格式是包含 XYZ 的 ASCII 文件。</para>
		/// <para>含 XYZI 的 ASCII 文件—输入文件的格式是包含 XYZI 的 ASCII 文件。</para>
		/// <para>生成格式的 ASCII 文件—输入文件的格式是 Generate 格式的 ASCII 文件。</para>
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
		public override object[] Parameters() => new object[] { Input, OutFeatureClass, InFileType, FileSuffix!, InputCoordinateSystem!, FolderRecursion!, ExtrudeGeometry!, DecimalSeparator!, SummarizeByClassCode!, ImproveLasPointSpacing!, MinPointSpacing! };

		/// <summary>
		/// <para>Point Data</para>
		/// <para>待处理的点数据。 支持的输入包括 LAS 数据集、.las 文件、.zlas 文件和包含点记录的 ASCII 文件。 也可以将一个或多个包含文件的文件夹指定为输入。 包含文件夹时，必须在文件后缀参数中指定点文件的文件后缀。</para>
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
		/// <para>LAS 格式激光雷达—输入文件的格式是 LAS 格式激光雷达。</para>
		/// <para>含 XYZ 的 ASCII 文件—输入文件的格式是包含 XYZ 的 ASCII 文件。</para>
		/// <para>含 XYZI 的 ASCII 文件—输入文件的格式是包含 XYZI 的 ASCII 文件。</para>
		/// <para>生成格式的 ASCII 文件—输入文件的格式是 Generate 格式的 ASCII 文件。</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFileType { get; set; } = "LAS";

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>在输入中指定文件夹时，将导入的文件后缀。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FileSuffix { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输入数据的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Include Subfolders</para>
		/// <para>指定是否子文件夹中的数据将用于生成结果。 当所选输入文件夹中的子文件夹目录含有数据时，工具将扫描子文件夹。 为目录结构中的每个文件生成一行输出要素类。</para>
		/// <para>未选中 - 只有输入文件夹中的数据才用于生成结果。 这是默认设置。</para>
		/// <para>选中 - 在输入文件夹及其子目录中找到的任何数据均将用于生成结果。</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Extrude Geometry Shapes</para>
		/// <para>指定是将输出创建为 2D 面要素类还是具有拉伸要素（可反映出每个文件中找到的高程范围）的多面体要素类。</para>
		/// <para>未选中 - 输出将创建为 2D 面要素类。 这是默认设置。</para>
		/// <para>选中 - 输出将创建为多面体要素类。</para>
		/// <para><see cref="ExtrudeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExtrudeGeometry { get; set; } = "false";

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
		public object? DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Summarize by class code</para>
		/// <para>指定输出是按类代码还是按文件汇总 .las 文件。 此参数仅适用于 LAS 格式数据，并且需要对每个输入文件进行完整扫描。</para>
		/// <para>未选中 - 每个输出要素将表示 .las 文件中找到的所有数据。 这是默认设置。</para>
		/// <para>选中 - 每个输出要素将表示在 .las 文件中找到的单个类代码。</para>
		/// <para><see cref="SummarizeByClassCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SummarizeByClassCode { get; set; } = "false";

		/// <summary>
		/// <para>Improve LAS files point spacing estimate</para>
		/// <para>指定是否将使用 .las 文件中的点间距的加强版评估，从而减少由不规则数据分布导致的过高评估。</para>
		/// <para>未选中 - 将对 .las 文件使用常规点间距估计值，其中范围由点数均分。 这是默认设置。</para>
		/// <para>选中 - 将使用分组，从而为 .las 文件获取更精确的点间距估计值。 这可能会增加工具运行时间。</para>
		/// <para><see cref="ImproveLasPointSpacingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ImproveLasPointSpacing { get; set; } = "false";

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? MinPointSpacing { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointFileInformation SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
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
			/// <para>LAS 格式激光雷达—输入文件的格式是 LAS 格式激光雷达。</para>
			/// </summary>
			[GPValue("LAS")]
			[Description("LAS 格式激光雷达")]
			LAS_format_lidar,

			/// <summary>
			/// <para>含 XYZ 的 ASCII 文件—输入文件的格式是包含 XYZ 的 ASCII 文件。</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("含 XYZ 的 ASCII 文件")]
			ASCII_file_with_XYZ,

			/// <summary>
			/// <para>含 XYZI 的 ASCII 文件—输入文件的格式是包含 XYZI 的 ASCII 文件。</para>
			/// </summary>
			[GPValue("XYZI")]
			[Description("含 XYZI 的 ASCII 文件")]
			ASCII_file_with_XYZI,

			/// <summary>
			/// <para>生成格式的 ASCII 文件—输入文件的格式是 Generate 格式的 ASCII 文件。</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("生成格式的 ASCII 文件")]
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
