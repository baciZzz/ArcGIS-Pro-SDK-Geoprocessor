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
	/// <para>Add Rasters To Mosaic Dataset</para>
	/// <para>添加栅格至镶嵌数据集</para>
	/// <para>将文件、文件夹、表或 Web 服务等多种来源的栅格数据集添加到镶嵌数据集。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddRastersToMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>要添加栅格数据的镶嵌数据集的路径和名称。</para>
		/// </param>
		/// <param name="RasterType">
		/// <para>Raster Type</para>
		/// <para>将添加的栅格类型。 栅格类型特定于影像产品。 它与栅格格式一起标识元数据信息，例如地理配准、采集日期和传感器类型。</para>
		/// <para>如果要使用 LAS、LAS 数据集或 Terrain 栅格类型，则必须在栅格类型属性页面上指定像元大小。</para>
		/// <para>处理模板下拉列表中包含将应用于添加到镶嵌数据集的各项目的函数，以及应用函数的方式或顺序。 可以使用单个函数（例如拉伸函数），也可以将多个函数链接到一起以创建更高级的产品。 大多数镶嵌类型具有多个预先存在的关联函数。 可以使用此下拉列表来编辑现有函数，或将新函数添加到要添加到镶嵌数据集的项目。</para>
		/// <para>要编辑模板，请在处理模板下拉列表中选择模板，然后单击编辑 。 完成模板编辑后，单击保存 更新模板，或单击另存为 将其另存为下拉列表中的新项目。 要将模板导出到磁盘，以与其他镶嵌数据集配合使用，请单击导出按钮 。</para>
		/// <para>要创建模板，请在处理模板下拉列表中单击创建新模板 。 有关详细信息，请参阅栅格函数。</para>
		/// <para>要从磁盘或栅格函数窗格导入函数链，请在处理模板下拉列表中单击导入 。 如果未使用栅格类型模板编辑器创建模板，则需要将主要输入栅格变量的名称更改为 Dataset。 为此，请双击链中的第一个函数，然后单击变量选项卡。 将栅格参数的 Name 字段中的值更改为 Dataset。</para>
		/// </param>
		/// <param name="InputPath">
		/// <para>Input Data</para>
		/// <para>指定输入文件、文件夹、栅格数据集、镶嵌数据集、表或服务的路径和名称。</para>
		/// <para>并非所有输入选项都可用。 所选栅格类型将确定可用选项。</para>
		/// <para>数据集—ArcGIS 地理数据集（例如地理数据库或表中的栅格或镶嵌数据集）将被用作输入。</para>
		/// <para>工作空间—包含多个栅格数据集的文件夹将被用作输入。 该文件夹可包含子文件夹。此选项受包括子文件夹和输入数据过滤器参数的影响。</para>
		/// <para>文件—一个或多个存储于磁盘的文件夹、影像服务定义文件 (.ISDef) 或栅格处理定义文件 (.RPDef) 中的栅格数据集将被用作输入。将忽略与添加的栅格类型不对应的文件。此选项不得与栅格数据集文件格式（如 TIFF 或 MrSID 文件）配合使用，请改为使用数据集输入类型。</para>
		/// <para>服务—WCS、地图、影像服务或 web 服务图层文件将被用作输入。</para>
		/// </param>
		public AddRastersToMosaicDataset(object InMosaicDataset, object RasterType, object InputPath)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.RasterType = RasterType;
			this.InputPath = InputPath;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加栅格至镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "添加栅格至镶嵌数据集";

		/// <summary>
		/// <para>Tool Name : AddRastersToMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "AddRastersToMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRastersToMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.AddRastersToMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "parallelProcessingFactor", "pyramid", "rasterStatistics", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, RasterType, InputPath, UpdateCellsizeRanges!, UpdateBoundary!, UpdateOverviews!, MaximumPyramidLevels!, MaximumCellSize!, MinimumDimension!, SpatialReference!, Filter!, SubFolder!, DuplicateItemsAction!, BuildPyramids!, CalculateStatistics!, BuildThumbnails!, OperationDescription!, ForceSpatialReference!, EstimateStatistics!, AuxInputs!, EnablePixelCache!, CacheLocation!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>要添加栅格数据的镶嵌数据集的路径和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Raster Type</para>
		/// <para>将添加的栅格类型。 栅格类型特定于影像产品。 它与栅格格式一起标识元数据信息，例如地理配准、采集日期和传感器类型。</para>
		/// <para>如果要使用 LAS、LAS 数据集或 Terrain 栅格类型，则必须在栅格类型属性页面上指定像元大小。</para>
		/// <para>处理模板下拉列表中包含将应用于添加到镶嵌数据集的各项目的函数，以及应用函数的方式或顺序。 可以使用单个函数（例如拉伸函数），也可以将多个函数链接到一起以创建更高级的产品。 大多数镶嵌类型具有多个预先存在的关联函数。 可以使用此下拉列表来编辑现有函数，或将新函数添加到要添加到镶嵌数据集的项目。</para>
		/// <para>要编辑模板，请在处理模板下拉列表中选择模板，然后单击编辑 。 完成模板编辑后，单击保存 更新模板，或单击另存为 将其另存为下拉列表中的新项目。 要将模板导出到磁盘，以与其他镶嵌数据集配合使用，请单击导出按钮 。</para>
		/// <para>要创建模板，请在处理模板下拉列表中单击创建新模板 。 有关详细信息，请参阅栅格函数。</para>
		/// <para>要从磁盘或栅格函数窗格导入函数链，请在处理模板下拉列表中单击导入 。 如果未使用栅格类型模板编辑器创建模板，则需要将主要输入栅格变量的名称更改为 Dataset。 为此，请双击链中的第一个函数，然后单击变量选项卡。 将栅格参数的 Name 字段中的值更改为 Dataset。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterBuilder()]
		public object RasterType { get; set; } = "Raster Dataset";

		/// <summary>
		/// <para>Input Data</para>
		/// <para>指定输入文件、文件夹、栅格数据集、镶嵌数据集、表或服务的路径和名称。</para>
		/// <para>并非所有输入选项都可用。 所选栅格类型将确定可用选项。</para>
		/// <para>数据集—ArcGIS 地理数据集（例如地理数据库或表中的栅格或镶嵌数据集）将被用作输入。</para>
		/// <para>工作空间—包含多个栅格数据集的文件夹将被用作输入。 该文件夹可包含子文件夹。此选项受包括子文件夹和输入数据过滤器参数的影响。</para>
		/// <para>文件—一个或多个存储于磁盘的文件夹、影像服务定义文件 (.ISDef) 或栅格处理定义文件 (.RPDef) 中的栅格数据集将被用作输入。将忽略与添加的栅格类型不对应的文件。此选项不得与栅格数据集文件格式（如 TIFF 或 MrSID 文件）配合使用，请改为使用数据集输入类型。</para>
		/// <para>服务—WCS、地图、影像服务或 web 服务图层文件将被用作输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputPath { get; set; }

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// <para>指定是否计算镶嵌数据集中每个栅格的像元大小范围。 这些值将写入 minPS 和 maxPS 字段中的属性表。</para>
		/// <para>选中 - 计算镶嵌数据集中所有栅格的像元大小范围。 这是默认设置。</para>
		/// <para>取消选中 - 不会计算像元大小范围。</para>
		/// <para><see cref="UpdateCellsizeRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? UpdateCellsizeRanges { get; set; } = "true";

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>指定是否生成或更新镶嵌数据集的边界面。 默认情况下，边界会合并所有轮廓线面以创建一个表示有效像素范围的边界。</para>
		/// <para>选中 - 生成或更新边界。 这是默认设置。</para>
		/// <para>未选中 - 不会生成或更新边界。</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Update Overviews</para>
		/// <para>指定是否定义和生成镶嵌数据集的概视图。</para>
		/// <para>选中 - 将定义和生成概览。</para>
		/// <para>取消选中 - 将不会定义或生成概视图。 这是默认设置。</para>
		/// <para><see cref="UpdateOverviewsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? UpdateOverviews { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Levels</para>
		/// <para>将在镶嵌数据集中使用的最大金字塔等级数。 例如，值 2 表示仅使用源栅格的前两个金字塔等级。 将此参数留空或输入值 -1 将会构建所有等级的金字塔。</para>
		/// <para>该值可影响显示及将要生成的概视图数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Raster Processing")]
		public object? MaximumPyramidLevels { get; set; }

		/// <summary>
		/// <para>Maximum Cell Size</para>
		/// <para>将在镶嵌数据集中使用的最大金字塔像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Raster Processing")]
		public object? MaximumCellSize { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Rows or Columns</para>
		/// <para>将在镶嵌数据集中使用的栅格金字塔的最小尺寸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Raster Processing")]
		public object? MinimumDimension { get; set; } = "1500";

		/// <summary>
		/// <para>Coordinate System for Input Data</para>
		/// <para>输入数据的空间参考系统。</para>
		/// <para>如果数据没有坐标系，则应指定此参数；否则，将使用镶嵌数据集的坐标系。 它还可用于覆盖输入数据的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Input Data Options")]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Input Data Filter</para>
		/// <para>将被添加到镶嵌数据集的数据的过滤器。 可以使用 SQL 表达式来创建数据过滤器。 过滤器的通配符适用于输入数据的完整路径。</para>
		/// <para>以下 SQL 语句将用于选择与以下对象 ID 相匹配的行：</para>
		/// <para>OBJECTID IN (19745, 19680, 19681, 19744, 5932, 5931, 5889, 5890, 14551, 14552, 14590, 14591)</para>
		/// <para>要仅添加一个 TIFF 图像，可以在文件扩展名前添加一个星号。</para>
		/// <para>*.TIF</para>
		/// <para>要添加文件路径或文件名中包含单词 sensor 的图像，则需要在单词 sensor 前后都填加一个星号。</para>
		/// <para>*sensor2009*</para>
		/// <para>您还可以使用 PERL 语法来创建数据过滤器。</para>
		/// <para>REGEX:.*1923.*|.*1922.*</para>
		/// <para>REGEX:.*192[34567].*|.*194.*|.*195.*</para>
		/// <para>不支持以下将多个词汇分组作为表达式一部分的 PERL 语法：</para>
		/// <para>REGEX:.* map_mean_.*(?:(?:[a-z0-9]*)_pptPct_(?:[0-9]|1[0-2]*?)_2[0-9]_*\w*).img</para>
		/// <para>或者也可以使用以下语法：</para>
		/// <para>REGEX:.*map_mean_*[a-z0-9]*_pptPct_([0-9]|1[0-2])_2[0-9]*_\w*.img</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Input Data Options")]
		public object? Filter { get; set; }

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// <para>指定是否递归搜索子文件夹。</para>
		/// <para>选中 - 在所有子文件夹中搜索数据。 这是默认设置。</para>
		/// <para>取消选中 - 仅浏览顶级文件夹以查找数据。</para>
		/// <para><see cref="SubFolderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? SubFolder { get; set; } = "true";

		/// <summary>
		/// <para>Add New Datasets Only</para>
		/// <para>指定如何处理重复栅格。 将使用原始路径和文件名来执行检查，以确定是否已添加各个栅格。 选择在发现重复路径和文件名后执行的操作。</para>
		/// <para>允许副本—将添加所有栅格，即使它们已经存在于镶嵌数据集中。 这是默认设置。</para>
		/// <para>排除副本—不会添加重复栅格。</para>
		/// <para>覆盖副本—重复栅格将覆盖现有栅格。</para>
		/// <para><see cref="DuplicateItemsActionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? DuplicateItemsAction { get; set; } = "ALLOW_DUPLICATES";

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// <para>指定是否为每个源栅格构建金字塔。</para>
		/// <para>未选中 - 不构建金字塔。 这是默认设置。</para>
		/// <para>选中 - 将构建金字塔。</para>
		/// <para><see cref="BuildPyramidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Raster Processing")]
		public object? BuildPyramids { get; set; } = "false";

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// <para>指定是否为每个源栅格计算统计数据。</para>
		/// <para>未选中 - 不计算统计数据。 这是默认设置。</para>
		/// <para>选中 - 计算统计数据。</para>
		/// <para><see cref="CalculateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Raster Processing")]
		public object? CalculateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// <para>指定是否为每个源栅格构建缩略图。</para>
		/// <para>未选中 - 不构建缩略图。 这是默认设置。</para>
		/// <para>选中 - 构建缩略图。</para>
		/// <para><see cref="BuildThumbnailsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? BuildThumbnails { get; set; } = "false";

		/// <summary>
		/// <para>Operation Description</para>
		/// <para>用于介绍栅格数据添加操作的描述。 它将添加到可用作搜索的一部分或在其他时间作为引用的栅格类型表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Post-processing")]
		public object? OperationDescription { get; set; }

		/// <summary>
		/// <para>Force this Coordinate System for Input Data</para>
		/// <para>将数据加载到镶嵌数据集中时，指定是否将输入数据的坐标系参数值用于所有栅格。 此选项不会重新投影数据；而是使用在工具中定义的坐标系构建镶嵌数据集中的项目。 将会使用影像的范围，但会覆盖投影。</para>
		/// <para>未选中 - 加载数据时，将使用各个栅格数据的坐标系。 这是默认设置。 如果未选中此选项，并且输入图像不具备坐标系（即坐标系未知），则会在构建镶嵌数据集项目时使用镶嵌数据集坐标系。 如果图像具备坐标系，则将使用此坐标系。</para>
		/// <para>选中 - 加载数据时，输入数据的坐标系参数中指定的坐标系将用于各个栅格数据集。</para>
		/// <para><see cref="ForceSpatialReferenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? ForceSpatialReference { get; set; } = "false";

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// <para>指定是否在镶嵌数据集级别对镶嵌数据集估算统计数据，以便更快地进行渲染和处理。</para>
		/// <para>未选中 - 不估算统计数据。 将使用每个项目在镶嵌数据集中生成的统计数据进行显示和处理。 这是默认设置。</para>
		/// <para>选中 - 将在镶嵌数据集级别估算统计数据。 将会使用用于显示镶嵌数据集的像素分布，而非镶嵌数据集中的源项目分布。</para>
		/// <para><see cref="EstimateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? EstimateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Auxiliary Inputs</para>
		/// <para>栅格类型设置，可在栅格类型属性页面中进行定义。 此参数中的设置将覆盖在栅格类型属性页面中定义的设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Advanced Input Data Options")]
		public object? AuxInputs { get; set; }

		/// <summary>
		/// <para>Enable Pixel Cache</para>
		/// <para>指定是否生成像素缓存，以便更快地显示和处理镶嵌数据集。</para>
		/// <para>未选中 - 不生成像素缓存。 这是默认设置。</para>
		/// <para>选中 - 生成像素缓存。</para>
		/// <para><see cref="EnablePixelCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? EnablePixelCache { get; set; } = "false";

		/// <summary>
		/// <para>Pixel Cache Location</para>
		/// <para>像素缓存的位置。 如果未定义位置，则缓存将写入 C:\Users\&lt;Username&gt;\AppData\Local\ESRI\rasterproxies\。</para>
		/// <para>如果已定义位置，则向镶嵌数据集添加新栅格时无需重新定义路径。 您只需在添加新数据时选中启用像素缓存参数（Python 中的 enable_pixel_cache = &quot;USE_PIXEL_CACHE&quot;）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Advanced Input Data Options")]
		public object? CacheLocation { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRastersToMosaicDataset SetEnviroment(object? extent = null , object? geographicTransformations = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// </summary>
		public enum UpdateCellsizeRangesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_CELL_SIZES")]
			UPDATE_CELL_SIZES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CELL_SIZES")]
			NO_CELL_SIZES,

		}

		/// <summary>
		/// <para>Update Boundary</para>
		/// </summary>
		public enum UpdateBoundaryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

		/// <summary>
		/// <para>Update Overviews</para>
		/// </summary>
		public enum UpdateOverviewsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_OVERVIEWS")]
			UPDATE_OVERVIEWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERVIEWS")]
			NO_OVERVIEWS,

		}

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// </summary>
		public enum SubFolderEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SUBFOLDERS")]
			SUBFOLDERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUBFOLDERS")]
			NO_SUBFOLDERS,

		}

		/// <summary>
		/// <para>Add New Datasets Only</para>
		/// </summary>
		public enum DuplicateItemsActionEnum 
		{
			/// <summary>
			/// <para>允许副本—将添加所有栅格，即使它们已经存在于镶嵌数据集中。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALLOW_DUPLICATES")]
			[Description("允许副本")]
			Allow_duplicates,

			/// <summary>
			/// <para>排除副本—不会添加重复栅格。</para>
			/// </summary>
			[GPValue("EXCLUDE_DUPLICATES")]
			[Description("排除副本")]
			Exclude_duplicates,

			/// <summary>
			/// <para>覆盖副本—重复栅格将覆盖现有栅格。</para>
			/// </summary>
			[GPValue("OVERWRITE_DUPLICATES")]
			[Description("覆盖副本")]
			Overwrite_duplicates,

		}

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// </summary>
		public enum BuildPyramidsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_PYRAMIDS")]
			BUILD_PYRAMIDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PYRAMIDS")]
			NO_PYRAMIDS,

		}

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// </summary>
		public enum CalculateStatisticsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CALCULATE_STATISTICS")]
			CALCULATE_STATISTICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// </summary>
		public enum BuildThumbnailsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_THUMBNAILS")]
			BUILD_THUMBNAILS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_THUMBNAILS")]
			NO_THUMBNAILS,

		}

		/// <summary>
		/// <para>Force this Coordinate System for Input Data</para>
		/// </summary>
		public enum ForceSpatialReferenceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE_SPATIAL_REFERENCE")]
			FORCE_SPATIAL_REFERENCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FORCE_SPATIAL_REFERENCE")]
			NO_FORCE_SPATIAL_REFERENCE,

		}

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// </summary>
		public enum EstimateStatisticsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE_STATISTICS")]
			ESTIMATE_STATISTICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

		/// <summary>
		/// <para>Enable Pixel Cache</para>
		/// </summary>
		public enum EnablePixelCacheEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_PIXEL_CACHE")]
			USE_PIXEL_CACHE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PIXEL_CACHE")]
			NO_PIXEL_CACHE,

		}

#endregion
	}
}
