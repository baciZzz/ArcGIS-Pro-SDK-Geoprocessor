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
	/// <para>Build Mosaic Dataset Item Cache</para>
	/// <para>构建镶嵌数据集项目缓存</para>
	/// <para>插入“缓存栅格”函数，作为镶嵌数据集中所有函数链的最后一步。</para>
	/// </summary>
	public class BuildMosaicDatasetItemCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>希望应用缓存函数的镶嵌数据集。</para>
		/// </param>
		public BuildMosaicDatasetItemCache(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建镶嵌数据集项目缓存</para>
		/// </summary>
		public override string DisplayName() => "构建镶嵌数据集项目缓存";

		/// <summary>
		/// <para>Tool Name : BuildMosaicDatasetItemCache</para>
		/// </summary>
		public override string ToolName() => "BuildMosaicDatasetItemCache";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildMosaicDatasetItemCache</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildMosaicDatasetItemCache";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause!, DefineCache!, GenerateCache!, ItemCacheFolder!, CompressionMethod!, CompressionQuality!, MaxAllowedRows!, MaxAllowedColumns!, RequestSizeType!, RequestSize!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>希望应用缓存函数的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>在您希望构建项目缓存的镶嵌数据集中，用来选择特定栅格数据集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Define Cache</para>
		/// <para>启用缓存属性的编辑功能。</para>
		/// <para>选中 - 将“缓存栅格”函数添加到选定项目。如果项目已经具有该函数，将不再添加。这是默认设置。</para>
		/// <para>未选中 - 不定义栅格缓存。</para>
		/// <para><see cref="DefineCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DefineCache { get; set; } = "true";

		/// <summary>
		/// <para>Generate Cache</para>
		/// <para>根据“缓存栅格”函数中定义的属性（例如，缓存的位置和压缩）选择生成缓存文件。</para>
		/// <para>选中 - 将生成缓存。这是默认设置。</para>
		/// <para>未选中 - 不生成缓存。</para>
		/// <para><see cref="GenerateCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateCache { get; set; } = "true";

		/// <summary>
		/// <para>Cache Path</para>
		/// <para>选择覆盖保存缓存的默认位置。如果镶嵌数据集位于文件地理数据库中，则默认将缓存保存在与地理数据库名称相同的文件夹中，并使用 .cache 作为扩展名。如果镶嵌数据集位于企业级地理数据库中，则默认将缓存保存在该地理数据库中。创建后，缓存将始终保存到同一位置。要将缓存保存到其他位置，需要首先使用修复镶嵌数据集工具指定新位置，然后再次运行该工具。</para>
		/// <para>项目缓存创建完成后，无法通过指定不同的缓存路径并重新运行该工具来在其他位置处重新生成项目缓存。只能继续在首次生成项目缓存的位置上生成。不过，可删除此函数，然后在新路径中插入一个新函数；或者使用修复镶嵌数据集工具修改缓存路径，然后运行此工具，在其它位置上生成项目缓存。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		[Category("Cache Properties")]
		public object? ItemCacheFolder { get; set; }

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>选择数据压缩方式以便加快传输。</para>
		/// <para>无损压缩— 生成缓存时保留每个像素的值。无损压缩的压缩比接近 2:1。</para>
		/// <para>有损压缩— 适用于仅将影像用作背景时。有损压缩的压缩比最高 (20:1)，但对相似的像素值进行分组可实现更高的压缩比。</para>
		/// <para>无压缩— 不压缩影像。这样会降低影像的传输速度，但同时会加快绘制，因为不需要在查看时进行解压缩。</para>
		/// <para><see cref="CompressionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Cache Properties")]
		public object? CompressionMethod { get; set; } = "LOSSLESS";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>设置使用有损压缩方式时的压缩质量。压缩质量值介于 1% 到 100% 之间，其中 100% 的压缩程度最低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100)]
		[Category("Cache Properties")]
		public object? CompressionQuality { get; set; } = "80";

		/// <summary>
		/// <para>Maximum Allowed Rows</para>
		/// <para>利用行数限制缓存数据集的大小。如果值大于数据集中的行数，缓存将不会生成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 2147483647)]
		[Category("Cache Properties")]
		public object? MaxAllowedRows { get; set; } = "200000";

		/// <summary>
		/// <para>Maximum Allowed Columns</para>
		/// <para>利用列数限制缓存数据集的大小。如果值大于数据集中的列数，缓存将不会生成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 2147483647)]
		[Category("Cache Properties")]
		public object? MaxAllowedColumns { get; set; } = "200000";

		/// <summary>
		/// <para>Request Size Type</para>
		/// <para>使用以下两种方法之一对缓存进行重采样：</para>
		/// <para>像素大小因子— 设置与像素大小相关的比例因子。如果不想对缓存进行重采样，请选择像素大小因子并将请求大小参数设置为 1。</para>
		/// <para>像素大小— 为缓存栅格指定像素大小。</para>
		/// <para><see cref="RequestSizeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Resampling")]
		public object? RequestSizeType { get; set; } = "PIXEL_SIZE_FACTOR";

		/// <summary>
		/// <para>Request Size</para>
		/// <para>设置一个应用于请求大小类型的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		[Category("Resampling")]
		public object? RequestSize { get; set; } = "1";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildMosaicDatasetItemCache SetEnviroment(object? extent = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Define Cache</para>
		/// </summary>
		public enum DefineCacheEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_CACHE")]
			DEFINE_CACHE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DEFINE_CACHE")]
			NO_DEFINE_CACHE,

		}

		/// <summary>
		/// <para>Generate Cache</para>
		/// </summary>
		public enum GenerateCacheEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_CACHE")]
			GENERATE_CACHE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_CACHE")]
			NO_GENERATE_CACHE,

		}

		/// <summary>
		/// <para>Compression Method</para>
		/// </summary>
		public enum CompressionMethodEnum 
		{
			/// <summary>
			/// <para>无压缩— 不压缩影像。这样会降低影像的传输速度，但同时会加快绘制，因为不需要在查看时进行解压缩。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无压缩")]
			No_compression,

			/// <summary>
			/// <para>无损压缩— 生成缓存时保留每个像素的值。无损压缩的压缩比接近 2:1。</para>
			/// </summary>
			[GPValue("LOSSLESS")]
			[Description("无损压缩")]
			Lossless_compression,

			/// <summary>
			/// <para>有损压缩— 适用于仅将影像用作背景时。有损压缩的压缩比最高 (20:1)，但对相似的像素值进行分组可实现更高的压缩比。</para>
			/// </summary>
			[GPValue("LOSSY")]
			[Description("有损压缩")]
			Lossy_compression,

		}

		/// <summary>
		/// <para>Request Size Type</para>
		/// </summary>
		public enum RequestSizeTypeEnum 
		{
			/// <summary>
			/// <para>像素大小因子— 设置与像素大小相关的比例因子。如果不想对缓存进行重采样，请选择像素大小因子并将请求大小参数设置为 1。</para>
			/// </summary>
			[GPValue("PIXEL_SIZE")]
			[Description("像素大小")]
			Pixel_size,

			/// <summary>
			/// <para>像素大小因子— 设置与像素大小相关的比例因子。如果不想对缓存进行重采样，请选择像素大小因子并将请求大小参数设置为 1。</para>
			/// </summary>
			[GPValue("PIXEL_SIZE_FACTOR")]
			[Description("像素大小因子")]
			Pixel_size_factor,

		}

#endregion
	}
}
