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
	/// <para>Mosaic Dataset To Mobile Mosaic Dataset</para>
	/// <para>镶嵌数据集至移动镶嵌数据集</para>
	/// <para>将镶嵌数据集转换为兼容 ArcGIS Runtime SDK 的移动镶嵌数据集。移动镶嵌数据集位于移动地理数据库。</para>
	/// </summary>
	public class MosaicDatasetToMobileMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>要转换为移动镶嵌数据集的镶嵌数据集。</para>
		/// </param>
		/// <param name="OutMobileGdb">
		/// <para>Mobile Geodatabase</para>
		/// <para>用于在其中创建转换的镶嵌数据集的地理数据库。</para>
		/// </param>
		/// <param name="MosaicDatasetName">
		/// <para>Mosaic Dataset Name</para>
		/// <para>要创建的移动镶嵌数据集的名称。</para>
		/// </param>
		public MosaicDatasetToMobileMosaicDataset(object InMosaicDataset, object OutMobileGdb, object MosaicDatasetName)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutMobileGdb = OutMobileGdb;
			this.MosaicDatasetName = MosaicDatasetName;
		}

		/// <summary>
		/// <para>Tool Display Name : 镶嵌数据集至移动镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "镶嵌数据集至移动镶嵌数据集";

		/// <summary>
		/// <para>Tool Name : MosaicDatasetToMobileMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "MosaicDatasetToMobileMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.MosaicDatasetToMobileMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.MosaicDatasetToMobileMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutMobileGdb, MosaicDatasetName, WhereClause!, SelectionFeature!, OutDataFolder!, ConvertRasters!, OutNamePrefix!, Format!, CompressionMethod!, CompressionQuality!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>要转换为移动镶嵌数据集的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Mobile Geodatabase</para>
		/// <para>用于在其中创建转换的镶嵌数据集的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutMobileGdb { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset Name</para>
		/// <para>要创建的移动镶嵌数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MosaicDatasetName { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来选择将特定项目添加到移动镶嵌数据集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Search Options")]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Selection Feature</para>
		/// <para>要添加到输出中的镶嵌数据集项目基于其他影像或要素类的范围。位于已定义范围边缘的项目将被包含到镶嵌数据集中。因此将不会进行裁剪。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Search Options")]
		public object? SelectionFeature { get; set; }

		/// <summary>
		/// <para>Output Data Folder</para>
		/// <para>如果指定，则工具将在此文件夹中创建源数据的副本。如果选中转换栅格，则将在创建副本前执行与镶嵌数据集相关的所有栅格函数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Output Data Options")]
		public object? OutDataFolder { get; set; }

		/// <summary>
		/// <para>Convert Rasters</para>
		/// <para>创建移动镶嵌数据集前应用与输入镶嵌数据集相关的栅格函数。如果已选中，且 ArcGIS Runtime SDK 不支持栅格函数，工具将应用栅格函数链并将输出另存为已转换的栅格项目。如未选中，工具将不转换栅格项目。如果 ArcGIS Runtime SDK 不支持栅格函数，工具将返回相应的错误消息。</para>
		/// <para>未选中 - 不转换带有 ArcGIS Runtime SDK 不支持函数的栅格项目。这是默认设置。</para>
		/// <para>选中 - 应用栅格函数链并将输出另存为已转换的栅格项目。</para>
		/// <para><see cref="ConvertRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output Data Options")]
		public object? ConvertRasters { get; set; } = "false";

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>为每个复制或转换到输出数据文件夹的项目追加一个前缀。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output Data Options")]
		public object? OutNamePrefix { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>写入到输出数据文件夹中的栅格的格式。</para>
		/// <para>TIFF—TIFF 格式</para>
		/// <para>PNG—PNG 格式</para>
		/// <para>JPEG—JPEG 格式</para>
		/// <para>JPEG2000—JPEG2000 格式</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Data Options")]
		public object? Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>用于将镶嵌影像从计算机传输到显示器（或者从服务器到客户端）的压缩方法。</para>
		/// <para>无—不应用压缩。</para>
		/// <para>JPEG—最多压缩至 8:1 并且适合用作背景。</para>
		/// <para>LZ77—压缩大约为 2:1。适合用于分析。</para>
		/// <para>RLE—无损压缩 适用于分类数据集。</para>
		/// <para><see cref="CompressionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Data Options")]
		public object? CompressionMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>0 到 100 之间的值。数字越大，意味着影像的质量越高，但压缩程度越低。仅在指定压缩方法为 JPEG 或 JP2000 时启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Data Options")]
		public object? CompressionQuality { get; set; }

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEMosaicDataset()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MosaicDatasetToMobileMosaicDataset SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert Rasters</para>
		/// </summary>
		public enum ConvertRastersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALWAYS")]
			ALWAYS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("AS_REQUIRED")]
			AS_REQUIRED,

		}

		/// <summary>
		/// <para>Output Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>TIFF—TIFF 格式</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

			/// <summary>
			/// <para>PNG—PNG 格式</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>JPEG—JPEG 格式</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>JPEG2000—JPEG2000 格式</para>
			/// </summary>
			[GPValue("JP2")]
			[Description("JPEG2000")]
			JPEG2000,

		}

		/// <summary>
		/// <para>Compression Method</para>
		/// </summary>
		public enum CompressionMethodEnum 
		{
			/// <summary>
			/// <para>无—不应用压缩。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>JPEG—最多压缩至 8:1 并且适合用作背景。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>LZ77—压缩大约为 2:1。适合用于分析。</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("LZ77")]
			LZ77,

			/// <summary>
			/// <para>RLE—无损压缩 适用于分类数据集。</para>
			/// </summary>
			[GPValue("RLE")]
			[Description("RLE")]
			RLE,

		}

#endregion
	}
}
