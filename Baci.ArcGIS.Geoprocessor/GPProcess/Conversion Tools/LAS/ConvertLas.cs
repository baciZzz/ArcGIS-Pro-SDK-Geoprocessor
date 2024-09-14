using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Convert LAS</para>
	/// <para>转换 LAS</para>
	/// <para>在不同的压缩方法、文件版本和点记录格式间转换 .las、.zlas 和 .laz 文件。</para>
	/// </summary>
	public class ConvertLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLas">
		/// <para>Input LAS</para>
		/// <para>将转换 .las、.zlas 或 .laz 文件。 通过指定包含文件或 LAS 数据集的文件夹，可以处理多个文件。</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>输出文件将要写入的现有文件夹。</para>
		/// </param>
		public ConvertLas(object InLas, object TargetFolder)
		{
			this.InLas = InLas;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换 LAS</para>
		/// </summary>
		public override string DisplayName() => "转换 LAS";

		/// <summary>
		/// <para>Tool Name : ConvertLas</para>
		/// </summary>
		public override string ToolName() => "ConvertLas";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ConvertLas</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ConvertLas";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLas, TargetFolder, FileVersion!, PointFormat!, Compression!, LasOptions!, OutLasDataset!, DefineCoordinateSystem!, InCoordinateSystem! };

		/// <summary>
		/// <para>Input LAS</para>
		/// <para>将转换 .las、.zlas 或 .laz 文件。 通过指定包含文件或 LAS 数据集的文件夹，可以处理多个文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLas { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>输出文件将要写入的现有文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>File Version</para>
		/// <para>指定将用于输出文件的文件版本。</para>
		/// <para>与输入相同—输出文件与输入文件具有相同的版本。 这是默认设置。</para>
		/// <para>1.0—使用支持 256 种类代码的 LAS 格式的基础版本。</para>
		/// <para>1.1—输出文件的版本为 1.1。 类代码减少到 32 种，但是增加了对分类标记的支持。</para>
		/// <para>1.2—输出文件的版本为 1.2。 增加了对红绿蓝 (RGB) 彩色通道和 GPS 时间的支持。</para>
		/// <para>1.3—输出文件的版本为 1.3。 增加了不受 ArcGIS 平台支持的点记录格式激光雷达波形数据的存储。</para>
		/// <para>1.4—输出文件的版本为 1.4。 增加了对使用可识别文本 (WKT) 约定定义坐标系、256 种类代码、每个脉冲多达 15 个离散回波、更高精度的扫描角度和重叠分类标记的支持。</para>
		/// <para><see cref="FileVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FileVersion { get; set; } = "SAME_AS_INPUT";

		/// <summary>
		/// <para>Point Format</para>
		/// <para>指定输出文件的点记录格式。 可用选项因输出 LAS 格式文件的版本而异。</para>
		/// <para>0—用于存储离散 LAS 点的基本类型，该类型支持诸如激光雷达强度、返回值、扫描角度、扫描方向和飞行航线的边缘等属性。</para>
		/// <para>1—将 GPS 时间添加至将使用的点格式 0 所支持的属性。</para>
		/// <para>2—将 RGB 值添加至将使用的点格式 0 所支持的属性。</para>
		/// <para>3—将 RGB 值和 GPS 时间添加至将使用的点格式 0 所支持的属性。</para>
		/// <para>6—将使用在 LAS 文件版本 1.4 中存储离散 LAS 点的首选基本类型。</para>
		/// <para>7—将 RGB 值添加至将使用的点格式 6 所支持的属性。</para>
		/// <para>8—将 RGB 和近红外值添加至将使用的点格式 6 所支持的属性。</para>
		/// <para><see cref="PointFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PointFormat { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定输出文件将存储为压缩格式还是未压缩格式。</para>
		/// <para>不压缩—输出文件将采用未压缩的 LAS 格式 (*.las)。 此格式支持编辑分类代码和标记。 这是默认设置。</para>
		/// <para>zLAS 压缩—输出文件将以 zLAS 格式 (*.zlas) 压缩。</para>
		/// <para>LAZ 压缩—输出文件将以 LAZ 格式 (*.laz) 压缩。</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>LAS Options</para>
		/// <para>指定将对输出文件进行的修改，从而减小其大小并提高其显示和分析性能。</para>
		/// <para>重新排列点—将重新排列点，以提高显示和分析性能。 将在此过程中自动计算统计数据。 这是默认设置。</para>
		/// <para>移除变量长度记录—添加在标题后的可变长度记录以及每个文件的点记录将被移除。</para>
		/// <para>移除多余字节—输入文件中每个点可能出现的额外字节将被删除。</para>
		/// <para><see cref="LasOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? LasOptions { get; set; } = "REARRANGE_POINTS";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>参考新创建的 .las 文件的输出 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object? OutLasDataset { get; set; }

		/// <summary>
		/// <para>Define Input Coordinate System</para>
		/// <para>指定如何定义每个输入文件的坐标系。</para>
		/// <para>无 LAS 文件—每个输入文件的坐标系均将由其标题中的信息定义。 任何缺少空间参考信息的文件都将被视为具有未知坐标系。 这是默认设置。</para>
		/// <para>所有 LAS 文件—每个输入文件的坐标系均将由输入坐标系参数定义。</para>
		/// <para>无空间参考的 LAS 文件—标题中不包含空间参考信息的任何输入文件的坐标系均将由输入坐标系参数定义。</para>
		/// <para><see cref="DefineCoordinateSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DefineCoordinateSystem { get; set; } = "NO_FILES";

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>在根据定义输入坐标系参数中的选择内容来定义部分或所有输入文件的空间参考时将使用的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertLas SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Version</para>
		/// </summary>
		public enum FileVersionEnum 
		{
			/// <summary>
			/// <para>与输入相同—输出文件与输入文件具有相同的版本。 这是默认设置。</para>
			/// </summary>
			[GPValue("SAME_AS_INPUT")]
			[Description("与输入相同")]
			Same_As_Input,

			/// <summary>
			/// <para>1.0—使用支持 256 种类代码的 LAS 格式的基础版本。</para>
			/// </summary>
			[GPValue("1.0")]
			[Description("1.0")]
			_10,

			/// <summary>
			/// <para>1.1—输出文件的版本为 1.1。 类代码减少到 32 种，但是增加了对分类标记的支持。</para>
			/// </summary>
			[GPValue("1.1")]
			[Description("1.1")]
			_11,

			/// <summary>
			/// <para>1.2—输出文件的版本为 1.2。 增加了对红绿蓝 (RGB) 彩色通道和 GPS 时间的支持。</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>1.3—输出文件的版本为 1.3。 增加了不受 ArcGIS 平台支持的点记录格式激光雷达波形数据的存储。</para>
			/// </summary>
			[GPValue("1.3")]
			[Description("1.3")]
			_13,

			/// <summary>
			/// <para>1.4—输出文件的版本为 1.4。 增加了对使用可识别文本 (WKT) 约定定义坐标系、256 种类代码、每个脉冲多达 15 个离散回波、更高精度的扫描角度和重叠分类标记的支持。</para>
			/// </summary>
			[GPValue("1.4")]
			[Description("1.4")]
			_14,

		}

		/// <summary>
		/// <para>Point Format</para>
		/// </summary>
		public enum PointFormatEnum 
		{
			/// <summary>
			/// <para>0—用于存储离散 LAS 点的基本类型，该类型支持诸如激光雷达强度、返回值、扫描角度、扫描方向和飞行航线的边缘等属性。</para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para>1—将 GPS 时间添加至将使用的点格式 0 所支持的属性。</para>
			/// </summary>
			[GPValue("1")]
			[Description("1")]
			_1,

			/// <summary>
			/// <para>2—将 RGB 值添加至将使用的点格式 0 所支持的属性。</para>
			/// </summary>
			[GPValue("2")]
			[Description("2")]
			_2,

			/// <summary>
			/// <para>3—将 RGB 值和 GPS 时间添加至将使用的点格式 0 所支持的属性。</para>
			/// </summary>
			[GPValue("3")]
			[Description("3")]
			_3,

			/// <summary>
			/// <para>6—将使用在 LAS 文件版本 1.4 中存储离散 LAS 点的首选基本类型。</para>
			/// </summary>
			[GPValue("6")]
			[Description("6")]
			_6,

			/// <summary>
			/// <para>7—将 RGB 值添加至将使用的点格式 6 所支持的属性。</para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para>8—将 RGB 和近红外值添加至将使用的点格式 6 所支持的属性。</para>
			/// </summary>
			[GPValue("8")]
			[Description("8")]
			_8,

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum CompressionEnum 
		{
			/// <summary>
			/// <para>不压缩—输出文件将采用未压缩的 LAS 格式 (*.las)。 此格式支持编辑分类代码和标记。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("不压缩")]
			No_Compression,

			/// <summary>
			/// <para>zLAS 压缩—输出文件将以 zLAS 格式 (*.zlas) 压缩。</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS 压缩")]
			zLAS_Compression,

			/// <summary>
			/// <para>LAZ 压缩—输出文件将以 LAZ 格式 (*.laz) 压缩。</para>
			/// </summary>
			[GPValue("LAZ")]
			[Description("LAZ 压缩")]
			LAZ_Compression,

		}

		/// <summary>
		/// <para>LAS Options</para>
		/// </summary>
		public enum LasOptionsEnum 
		{
			/// <summary>
			/// <para>重新排列点—将重新排列点，以提高显示和分析性能。 将在此过程中自动计算统计数据。 这是默认设置。</para>
			/// </summary>
			[GPValue("REARRANGE_POINTS")]
			[Description("重新排列点")]
			Rearrange_Points,

			/// <summary>
			/// <para>移除变量长度记录—添加在标题后的可变长度记录以及每个文件的点记录将被移除。</para>
			/// </summary>
			[GPValue("REMOVE_VLR")]
			[Description("移除变量长度记录")]
			Remove_Variable_Length_Records,

			/// <summary>
			/// <para>移除多余字节—输入文件中每个点可能出现的额外字节将被删除。</para>
			/// </summary>
			[GPValue("REMOVE_EXTRA_BYTES")]
			[Description("移除多余字节")]
			Remove_Extra_Bytes,

		}

		/// <summary>
		/// <para>Define Input Coordinate System</para>
		/// </summary>
		public enum DefineCoordinateSystemEnum 
		{
			/// <summary>
			/// <para>无 LAS 文件—每个输入文件的坐标系均将由其标题中的信息定义。 任何缺少空间参考信息的文件都将被视为具有未知坐标系。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_FILES")]
			[Description("无 LAS 文件")]
			No_LAS_Files,

			/// <summary>
			/// <para>所有 LAS 文件—每个输入文件的坐标系均将由输入坐标系参数定义。</para>
			/// </summary>
			[GPValue("ALL_FILES")]
			[Description("所有 LAS 文件")]
			All_LAS_Files,

			/// <summary>
			/// <para>无空间参考的 LAS 文件—标题中不包含空间参考信息的任何输入文件的坐标系均将由输入坐标系参数定义。</para>
			/// </summary>
			[GPValue("FILES_MISSING_PROJECTION")]
			[Description("无空间参考的 LAS 文件")]
			LAS_Files_with_No_Spatial_Reference,

		}

#endregion
	}
}
