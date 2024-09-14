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
	/// <para>Tile LAS</para>
	/// <para>切片 LAS</para>
	/// <para>创建一组不重叠的 LAS 文件，按规则格网划分其水平范围。</para>
	/// </summary>
	public class TileLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>将在其中写入切片 LAS 文件的文件夹。</para>
		/// </param>
		public TileLas(object InLasDataset, object TargetFolder)
		{
			this.InLasDataset = InLasDataset;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 切片 LAS</para>
		/// </summary>
		public override string DisplayName() => "切片 LAS";

		/// <summary>
		/// <para>Tool Name : TileLas</para>
		/// </summary>
		public override string ToolName() => "TileLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TileLas</para>
		/// </summary>
		public override string ExcuteName() => "3d.TileLas";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, TargetFolder, BaseName, OutLasDataset, ComputeStats, LasVersion, PointFormat, Compression, LasOptions, TileFeature, NamingMethod, FileSize, TileWidth, TileHeight, TileOrigin, OutFolder };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>将在其中写入切片 LAS 文件的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>每个输出文件均以该名称开头。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BaseName { get; set; } = "Tile";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>引用由此工具创建的切片 LAS 文件的新 LAS 数据集。此操作是可选的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output Version</para>
		/// <para>指定每个输出文件的 LAS 文件版本。默认值为 1.4。</para>
		/// <para>1.0—此版本支持 256 种唯一类代码，但是没有预定义的分类方案。</para>
		/// <para>1.1—该版本引入了预定义的分类方案和点记录格式 0 和 1，以及从激光雷达传感器以外的源获取的点的合成分类标记。</para>
		/// <para>1.2—此版本的特点是支持 GPS 时间以及点记录 2 和 3 中的 RGB 记录。</para>
		/// <para>1.3—该版本新增了对波形数据的点记录 4 和 5 的支持。但是，不会在 ArcGIS 中读取波形信息。</para>
		/// <para>1.4—此版本引入了点记录格式 6 到 10，以及新的类定义、256 种唯一类代码和重叠分类标记。</para>
		/// <para><see cref="LasVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object LasVersion { get; set; }

		/// <summary>
		/// <para>Point Format</para>
		/// <para>输出 LAS 文件的点记录格式。可用选项取决于输出版本参数中指定的 LAS 文件版本。</para>
		/// <para><see cref="PointFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object PointFormat { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定输出 LAS 文件将为压缩格式还是标准 LAS 格式。</para>
		/// <para>不压缩—输出将为标准 LAS 格式（*.las 文件）。这是默认设置。</para>
		/// <para>zLAS 压缩—输出 LAS 文件将压缩为 zLAS 格式。</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>LAS Options</para>
		/// <para>输出 LAS 文件的可选修改列表。</para>
		/// <para>重新排列点—LAS 点将根据其空间聚类进行排列。</para>
		/// <para>移除可变长度记录—添加在标题后的可变长度记录以及每个文件的点记录将被移除。</para>
		/// <para>移除多余字节—输入 LAS 文件中每个点记录存在的额外字节将被移除。</para>
		/// <para><see cref="LasOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object LasOptions { get; set; } = "REARRANGE_POINTS";

		/// <summary>
		/// <para>Import from Feature Class</para>
		/// <para>定义在切片激光雷达数据时使用的切片宽度和高度的面要素。假定面为矩形，并使用首个要素范围来定义切片宽度和高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Tiling Options")]
		public object TileFeature { get; set; }

		/// <summary>
		/// <para>Naming Method</para>
		/// <para>指定为每个输出 LAS 文件提供唯一名称的方法。每个文件名将追加到输出基本名称参数中指定的文本。使用输入要素来定义切片方案时，还将包含其文本或数值字段名称用作定义文件名的源。支持以下自动生成的命名约定：</para>
		/// <para>XY 坐标—在每个切片的中间点处追加 X 和 Y 坐标。这是默认设置。</para>
		/// <para>行和列—根据所属的整体切片方案中的行与列来分配切片名称。行将从上至下逐渐增加，而列将从左至右逐渐增加。</para>
		/// <para>序数标识—根据创建顺序分配切片名称，其中 1 为第一切片，2 为第二切片，以此类推。</para>
		/// <para><see cref="NamingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Tiling Options")]
		public object NamingMethod { get; set; } = "XY_COORDS";

		/// <summary>
		/// <para>Target File Size (MB)</para>
		/// <para>该值以兆字节表示，代表在整个范围内等值分布的输出 LAS 切片的未压缩文件大小的上限。默认值为 250，该值用于估算切片宽度和高度。</para>
		/// <para>此参数的值会在切片宽度和切片高度参数修改时发生变化。当在从要素类导入参数中指定了输入要素时，将会禁用该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Tiling Options")]
		public object FileSize { get; set; } = "250";

		/// <summary>
		/// <para>Tile Width</para>
		/// <para>每个切片的宽度。如果切片高度同时存在，指定一个值时会更新目标文件大小和点计数。同样，如果单独更新了目标文件大小或点计数，切片宽度和高度也将发生变化，以反映相应切片的大小。当已在从要素类导入参数中指定了输入要素时，切片宽度将通过第一要素的高度获取，而此参数将被禁用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Tiling Options")]
		public object TileWidth { get; set; }

		/// <summary>
		/// <para>Tile Height</para>
		/// <para>每个切片的高度。如果切片宽度同时存在，指定一个值时会更新目标文件大小。同样，如果单独更新了目标文件，切片宽度和高度也将按照比例发生变化，以反映相应切片的大小。当已在从要素类导入参数中指定了输入要素时，切片高度将通过第一要素的高度获取，而此参数将被禁用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Tiling Options")]
		public object TileHeight { get; set; }

		/// <summary>
		/// <para>Tile Origin</para>
		/// <para>切片网格原点的坐标。可在输入 LAS 数据集的左下角获取默认值。当已在从要素类导入参数中指定了输入要素时，将从第一要素的左下角继承原点，而此参数将被禁用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Tiling Options")]
		public object TileOrigin { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TileLas SetEnviroment(object extent = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute statistics</para>
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

		/// <summary>
		/// <para>Output Version</para>
		/// </summary>
		public enum LasVersionEnum 
		{
			/// <summary>
			/// <para>1.0—此版本支持 256 种唯一类代码，但是没有预定义的分类方案。</para>
			/// </summary>
			[GPValue("1.0")]
			[Description("1.0")]
			_10,

			/// <summary>
			/// <para>1.1—该版本引入了预定义的分类方案和点记录格式 0 和 1，以及从激光雷达传感器以外的源获取的点的合成分类标记。</para>
			/// </summary>
			[GPValue("1.1")]
			[Description("1.1")]
			_11,

			/// <summary>
			/// <para>1.2—此版本的特点是支持 GPS 时间以及点记录 2 和 3 中的 RGB 记录。</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>1.3—该版本新增了对波形数据的点记录 4 和 5 的支持。但是，不会在 ArcGIS 中读取波形信息。</para>
			/// </summary>
			[GPValue("1.3")]
			[Description("1.3")]
			_13,

			/// <summary>
			/// <para>1.4—此版本引入了点记录格式 6 到 10，以及新的类定义、256 种唯一类代码和重叠分类标记。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("1")]
			[Description("1")]
			_1,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2")]
			[Description("2")]
			_2,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("3")]
			[Description("3")]
			_3,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("6")]
			[Description("6")]
			_6,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para></para>
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
			/// <para>不压缩—输出将为标准 LAS 格式（*.las 文件）。这是默认设置。</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("不压缩")]
			No_Compression,

			/// <summary>
			/// <para>zLAS 压缩—输出 LAS 文件将压缩为 zLAS 格式。</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS 压缩")]
			zLAS_Compression,

		}

		/// <summary>
		/// <para>LAS Options</para>
		/// </summary>
		public enum LasOptionsEnum 
		{
			/// <summary>
			/// <para>重新排列点—LAS 点将根据其空间聚类进行排列。</para>
			/// </summary>
			[GPValue("REARRANGE_POINTS")]
			[Description("重新排列点")]
			Rearrange_Points,

			/// <summary>
			/// <para>移除可变长度记录—添加在标题后的可变长度记录以及每个文件的点记录将被移除。</para>
			/// </summary>
			[GPValue("REMOVE_VLR")]
			[Description("移除可变长度记录")]
			Remove_Variable_Length_Records,

			/// <summary>
			/// <para>移除多余字节—输入 LAS 文件中每个点记录存在的额外字节将被移除。</para>
			/// </summary>
			[GPValue("REMOVE_EXTRA_BYTES")]
			[Description("移除多余字节")]
			Remove_Extra_Bytes,

		}

		/// <summary>
		/// <para>Naming Method</para>
		/// </summary>
		public enum NamingMethodEnum 
		{
			/// <summary>
			/// <para>XY 坐标—在每个切片的中间点处追加 X 和 Y 坐标。这是默认设置。</para>
			/// </summary>
			[GPValue("XY_COORDS")]
			[Description("XY 坐标")]
			XY_Coordinates,

			/// <summary>
			/// <para>行和列—根据所属的整体切片方案中的行与列来分配切片名称。行将从上至下逐渐增加，而列将从左至右逐渐增加。</para>
			/// </summary>
			[GPValue("ROW_COLUMN")]
			[Description("行和列")]
			Rows_and_Columns,

			/// <summary>
			/// <para>序数标识—根据创建顺序分配切片名称，其中 1 为第一切片，2 为第二切片，以此类推。</para>
			/// </summary>
			[GPValue("ORDINAL")]
			[Description("序数标识")]
			Ordinal_Designation,

		}

#endregion
	}
}
