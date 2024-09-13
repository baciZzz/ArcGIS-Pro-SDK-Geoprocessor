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
	/// <para>Colorize LAS</para>
	/// <para>着色 LAS</para>
	/// <para>将正射影像的颜色和近红外值应用于 LAS 点。</para>
	/// </summary>
	public class ColorizeLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="InImage">
		/// <para>Input Image</para>
		/// <para>用于将颜色分配到 LAS 点的影像。</para>
		/// </param>
		/// <param name="Bands">
		/// <para>Band Assignment</para>
		/// <para>来自输入影像，将被分配到和输出 LAS 点相关联的颜色通道的波段。</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>输出 .las 文件将要写入的现有文件夹。</para>
		/// </param>
		public ColorizeLas(object InLasDataset, object InImage, object Bands, object TargetFolder)
		{
			this.InLasDataset = InLasDataset;
			this.InImage = InImage;
			this.Bands = Bands;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 着色 LAS</para>
		/// </summary>
		public override string DisplayName() => "着色 LAS";

		/// <summary>
		/// <para>Tool Name : ColorizeLas</para>
		/// </summary>
		public override string ToolName() => "ColorizeLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ColorizeLas</para>
		/// </summary>
		public override string ExcuteName() => "3d.ColorizeLas";

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
		public override object[] Parameters() => new object[] { InLasDataset, InImage, Bands, TargetFolder, NameSuffix!, LasVersion!, PointFormat!, Compression!, RearrangePoints!, ComputeStats!, OutLasDataset!, OutputFolder! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Image</para>
		/// <para>用于将颜色分配到 LAS 点的影像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InImage { get; set; }

		/// <summary>
		/// <para>Band Assignment</para>
		/// <para>来自输入影像，将被分配到和输出 LAS 点相关联的颜色通道的波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Bands { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>输出 .las 文件将要写入的现有文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Output File Name Suffix</para>
		/// <para>将追加到每个输出 .las 文件名的文本。 每个文件都将从其源文件继承其基本名称，后跟此参数中指定的后缀。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("LAS File Options")]
		public object? NameSuffix { get; set; } = "_colorized";

		/// <summary>
		/// <para>LAS File Version</para>
		/// <para>正在创建的输出文件的 LAS 版本。</para>
		/// <para>LAS 1.2 文件—将创建 LAS 文件版本 1.2。</para>
		/// <para>LAS 1.3 文件—将创建 LAS 文件版本 1.3。</para>
		/// <para>LAS 1.4 文件—将创建 LAS 文件版本 1.4。这是默认设置。</para>
		/// <para><see cref="LasVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? LasVersion { get; set; } = "1.4";

		/// <summary>
		/// <para>Point Format</para>
		/// <para>输出 LAS 文件的点记录格式。</para>
		/// <para>2—点记录格式 2。</para>
		/// <para>3—点记录格式 3 支持存储 GPS 时间。</para>
		/// <para>7—点记录格式 7。这是默认值，且仅适用于 LAS 版本 1.4</para>
		/// <para>8—点记录格式 8 支持存储近红外值。这仅适用于 LAS 版本 1.4。</para>
		/// <para><see cref="PointFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? PointFormat { get; set; } = "7";

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定输出 .las 文件为压缩格式还是标准 LAS 格式。</para>
		/// <para>不压缩—输出将为标准 LAS 格式（*.las 文件）。 这是默认设置。</para>
		/// <para>zLAS 压缩—输出 .las 文件将以 zLAS 格式压缩。</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>Rearrange Points</para>
		/// <para>指定 .las 文件中的点是否将重新排列。</para>
		/// <para>未选中 - .las 文件中点的顺序将不会重新排列。</para>
		/// <para>选中 - 将重新排列 .las 文件中的点。 这是默认设置。</para>
		/// <para><see cref="RearrangePointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? RearrangePoints { get; set; } = "true";

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>参考新创建的 .las 文件的输出 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object? OutLasDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? OutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColorizeLas SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>LAS File Version</para>
		/// </summary>
		public enum LasVersionEnum 
		{
			/// <summary>
			/// <para>LAS 1.2 文件—将创建 LAS 文件版本 1.2。</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("LAS 1.2 文件")]
			LAS_12_Files,

			/// <summary>
			/// <para>LAS 1.3 文件—将创建 LAS 文件版本 1.3。</para>
			/// </summary>
			[GPValue("1.3")]
			[Description("LAS 1.3 文件")]
			LAS_13_Files,

			/// <summary>
			/// <para>LAS 1.4 文件—将创建 LAS 文件版本 1.4。这是默认设置。</para>
			/// </summary>
			[GPValue("1.4")]
			[Description("LAS 1.4 文件")]
			LAS_14_Files,

		}

		/// <summary>
		/// <para>Point Format</para>
		/// </summary>
		public enum PointFormatEnum 
		{
			/// <summary>
			/// <para>7—点记录格式 7。这是默认值，且仅适用于 LAS 版本 1.4</para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para>8—点记录格式 8 支持存储近红外值。这仅适用于 LAS 版本 1.4。</para>
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
			/// <para>不压缩—输出将为标准 LAS 格式（*.las 文件）。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("不压缩")]
			No_Compression,

			/// <summary>
			/// <para>zLAS 压缩—输出 .las 文件将以 zLAS 格式压缩。</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS 压缩")]
			zLAS_Compression,

		}

		/// <summary>
		/// <para>Rearrange Points</para>
		/// </summary>
		public enum RearrangePointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REARRANGE_POINTS")]
			REARRANGE_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REARRANGE_POINTS")]
			NO_REARRANGE_POINTS,

		}

		/// <summary>
		/// <para>Compute Statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

#endregion
	}
}
