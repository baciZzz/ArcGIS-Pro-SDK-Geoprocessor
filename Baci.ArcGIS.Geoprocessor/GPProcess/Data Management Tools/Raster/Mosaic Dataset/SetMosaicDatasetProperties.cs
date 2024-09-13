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
	/// <para>Set Mosaic Dataset Properties</para>
	/// <para>设置镶嵌数据集属性</para>
	/// <para>定义用于显示镶嵌数据集并将其用作影像服务的默认设置。</para>
	/// </summary>
	public class SetMosaicDatasetProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>具有需要设置的属性的镶嵌数据集。</para>
		/// </param>
		public SetMosaicDatasetProperties(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置镶嵌数据集属性</para>
		/// </summary>
		public override string DisplayName() => "设置镶嵌数据集属性";

		/// <summary>
		/// <para>Tool Name : SetMosaicDatasetProperties</para>
		/// </summary>
		public override string ToolName() => "SetMosaicDatasetProperties";

		/// <summary>
		/// <para>Tool Excute Name : management.SetMosaicDatasetProperties</para>
		/// </summary>
		public override string ExcuteName() => "management.SetMosaicDatasetProperties";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, RowsMaximumImagesize, ColumnsMaximumImagesize, AllowedCompressions, DefaultCompressionType, JPEGQuality, LERCTolerance, ResamplingType, ClipToFootprints, FootprintsMayContainNodata, ClipToBoundary, ColorCorrection, AllowedMensurationCapabilities, DefaultMensurationCapabilities, AllowedMosaicMethods, DefaultMosaicMethod, OrderField, OrderBase, SortingOrder, MosaicOperator, BlendWidth, ViewPointX, ViewPointY, MaxNumPerMosaic, CellSizeTolerance, CellSize, MetadataLevel, TransmissionFields, UseTime, StartTimeField, EndTimeField, TimeFormat, GeographicTransform, MaxNumOfDownloadItems, MaxNumOfRecordsReturned, DataSourceType, MinimumPixelContribution, ProcessingTemplates, DefaultProcessingTemplate, OutMosaicDataset, TimeInterval, TimeIntervalUnits, ProductDefinition, ProductBandDefinitions };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>具有需要设置的属性的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Rows of Maximum Image Size of Requests</para>
		/// <para>镶嵌影像的最大行数，由镶嵌数据集在每次请求时生成。 这有助于控制客户查看影像时服务器必须执行的工作量。 如果数字较大，则会创建更大的影像，但同时也会延长处理镶嵌数据集的时间。 如果将值设置得过小，影像可能无法显示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Image Properties")]
		public object RowsMaximumImagesize { get; set; } = "4100";

		/// <summary>
		/// <para>Columns of Maximum Image Size of Requests</para>
		/// <para>镶嵌影像的最大列数，由镶嵌数据集在每次请求时生成。 这有助于控制客户查看影像时服务器必须执行的工作量。 如果数字较大，则会创建更大的影像，但同时也会延长处理镶嵌数据集的时间。 如果将值设置得过小，影像可能无法显示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Image Properties")]
		public object ColumnsMaximumImagesize { get; set; } = "15000";

		/// <summary>
		/// <para>Allowed Transmission Compression</para>
		/// <para>指定将用于将镶嵌影像从计算机传输到显示器（或从服务器传输到客户端）的压缩方法。</para>
		/// <para>无—不使用压缩。</para>
		/// <para>JPEG—最多压缩至 8:1 并且适合用作背景。</para>
		/// <para>LZ77—将使用适用于分析的压缩比接近 2:1 的压缩。</para>
		/// <para>LERC—将使用压缩比在 10:1 和 20:1 之间的压缩，这种压缩速度快且适用于具有高位深度（12 位至 32 位）的原始图像。</para>
		/// <para><see cref="AllowedCompressionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object AllowedCompressions { get; set; } = "None;JPEG;LZ77;LERC";

		/// <summary>
		/// <para>Default Compression Type</para>
		/// <para>指定默认压缩类型。 默认压缩必须位于允许的传输压缩参数所用值的列表中，或者必须在镶嵌数据集的允许的压缩方法属性中进行设置。</para>
		/// <para>无—不使用压缩。</para>
		/// <para>JPEG—最多压缩至 8:1 并且适合用作背景。</para>
		/// <para>LZ77—将使用适用于分析的压缩比接近 2:1 的压缩。</para>
		/// <para>LERC—将使用压缩比在 10:1 和 20:1 之间的压缩，这种压缩速度快且适用于具有高位深度（12 位至 32 位）的原始图像。</para>
		/// <para><see cref="DefaultCompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object DefaultCompressionType { get; set; } = "None";

		/// <summary>
		/// <para>JPEG Quality</para>
		/// <para>使用 JPEG 时的压缩质量。 压缩质量的范围是 1 到 100。 数字越大，意味着影像的质量越高，但压缩程度越低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Image Properties")]
		public object JPEGQuality { get; set; } = "75";

		/// <summary>
		/// <para>LERC Tolerance</para>
		/// <para>使用 LERC 压缩时的每像素最大误差值。 该值以镶嵌数据集的单位指定。 例如，如果误差为 10 厘米而镶嵌数据集的单位为米，则输入 0.1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Image Properties")]
		public object LERCTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>指定以较小比例显示数据集时计算像素值的方法。 根据数据类型选择适当的技术。</para>
		/// <para>最邻近—每个像素的值将来自最近的对应像素。 此技术适用于离散数据，例如土地覆被。此为最快的重采样技术。 由于它使用了来自最近像素的值，因此可以最小化像素值的变化。</para>
		/// <para>双线性—通过计算周围 4 像素的平均值（基于距离）来计算每个像素的值。 此技术适用于连续数据。</para>
		/// <para>三次—通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此技术将生成平滑影像，但可创建超出源数据范围的值。 适用于连续数据。</para>
		/// <para>众数—每个像素的值基于 3 x 3 窗口中出现频率最高的值。 此技术适用于离散数据。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object ResamplingType { get; set; } = "BILINEAR";

		/// <summary>
		/// <para>Clip To Footprints</para>
		/// <para>指定是否将栅格裁剪至覆盖区。 栅格数据集及其轮廓通常会具有相同的范围。 如果范围不同，可将栅格数据集裁剪至覆盖区。</para>
		/// <para>未选中 - 栅格不会被裁剪至覆盖区。 这是默认设置。</para>
		/// <para>选中 - 栅格将被裁剪至覆盖区。</para>
		/// <para><see cref="ClipToFootprintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object ClipToFootprints { get; set; } = "false";

		/// <summary>
		/// <para>Footprints May Contain NoData</para>
		/// <para>指定是否显示包含 NoData 值的像素。</para>
		/// <para>选中 - 将显示包含 NoData 值的像素。</para>
		/// <para>未选中 - 不显示包含 NoData 值的像素。 您可能会注意到性能有所提高；但是，如果您的影像确实包含 NoData 值，则它们将在镶嵌数据集中显示为孔。</para>
		/// <para><see cref="FootprintsMayContainNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object FootprintsMayContainNodata { get; set; } = "true";

		/// <summary>
		/// <para>Clip To Boundary</para>
		/// <para>指定是否将镶嵌影像裁剪至边界。 镶嵌数据集及其边界通常具有相同的范围。 如果范围不同，可将向前数据集裁剪至边界。</para>
		/// <para>选中 - 将镶嵌影像裁剪至边界。 这是默认设置。</para>
		/// <para>未选中 - 不将镶嵌影像裁剪至边界。</para>
		/// <para><see cref="ClipToBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object ClipToBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Color Correction</para>
		/// <para>指定是否将色彩校正用于镶嵌数据集。</para>
		/// <para>未选中 - 不使用色彩校正。 这是默认设置。</para>
		/// <para>选中 - 将使用为镶嵌数据集设置的色彩校正。</para>
		/// <para><see cref="ColorCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object ColorCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Allowed Mensuration Capabilities</para>
		/// <para>指定将在镶嵌数据集上执行的测量。 执行垂直测量的功能取决于影像，并且可能需要 DEM。</para>
		/// <para>无—不执行测量功能。</para>
		/// <para>基础—将执行距离、点、质心和面积计算等地面测量。</para>
		/// <para>要素底端至要素顶端—将执行从要素底端到要素顶端的测量。 有理多项式系数必须嵌入影像中。</para>
		/// <para>要素底端至阴影顶端—将执行从要素底端到其阴影顶端的测量。 需要太阳方位角和太阳高度角的信息。</para>
		/// <para>要素顶端至阴影顶端—将执行从要素顶端到其阴影顶端的测量。 需要太阳方位角、太阳高度角和有理多项式系数。</para>
		/// <para>3D 测量—如果 DEM 可用，则将在 3D 模式下进行测量。</para>
		/// <para><see cref="AllowedMensurationCapabilitiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object AllowedMensurationCapabilities { get; set; }

		/// <summary>
		/// <para>Default Mensuration</para>
		/// <para>指定镶嵌数据集的默认测量功能。 必须在允许的测量功能参数所用值的列表中设置默认测量值，或在镶嵌数据集的测量功能属性中设置默认测量值。</para>
		/// <para>无—不执行测量功能。</para>
		/// <para>基础—将执行距离、点、质心和面积计算等地面测量。</para>
		/// <para>要素底端至要素顶端—将执行从要素底端到要素顶端的测量。 有理多项式系数必须嵌入影像中。</para>
		/// <para>要素底端至阴影顶端—将执行从要素底端到其阴影顶端的测量。 需要太阳方位角和太阳高度角的信息。</para>
		/// <para>要素顶端至阴影顶端—将执行从要素顶端到其阴影顶端的测量。 需要太阳方位角、太阳高度角和有理多项式系数。</para>
		/// <para>3D 测量—如果 DEM 可用，则将在 3D 模式下进行测量。</para>
		/// <para><see cref="DefaultMensurationCapabilitiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object DefaultMensurationCapabilities { get; set; } = "None";

		/// <summary>
		/// <para>Allowed Mosaic Methods</para>
		/// <para>指定显示重叠影像的规则。</para>
		/// <para>无—将根据镶嵌数据集属性表中的 ObjectID 字段对栅格进行排序。</para>
		/// <para>居中—将显示距离屏幕中心最近的影像。</para>
		/// <para>西北—将显示距离镶嵌数据集边界西北角最近的影像。</para>
		/// <para>锁定栅格—将显示所选栅格数据集。</para>
		/// <para>按属性—将基于属性表中的字段显示影像并设置影像优先级。</para>
		/// <para>像底点—将通过最接近零视角的视角范围来显示栅格。</para>
		/// <para>视点—将显示距离所选视角最近的影像。</para>
		/// <para>接缝线—将使用接缝线在影像间进行平滑过渡。</para>
		/// <para><see cref="AllowedMosaicMethodsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object AllowedMosaicMethods { get; set; } = "Center;NorthWest;LockRaster;ByAttribute;Nadir;Viewpoint;Seamline;None";

		/// <summary>
		/// <para>Default Mosaic Methods</para>
		/// <para>指定将用于视图的镶嵌方法。 必须在允许的镶嵌方法参数所用值的列表中设置默认镶嵌方法，或者在镶嵌数据集的允许的镶嵌方法属性中设置默认镶嵌方法。</para>
		/// <para>无—将根据镶嵌数据集属性表中的 ObjectID 字段对栅格进行排序。</para>
		/// <para>居中—将显示距离屏幕中心最近的影像。</para>
		/// <para>西北—将显示距离镶嵌数据集边界西北角最近的影像。</para>
		/// <para>锁定栅格—将显示所选栅格数据集。</para>
		/// <para>按属性—将基于属性表中的字段显示影像并设置影像优先级。</para>
		/// <para>像底点—将通过最接近零视角的视角范围来显示栅格。</para>
		/// <para>视点—将显示距离所选视角最近的影像。</para>
		/// <para>接缝线—将使用接缝线在影像间进行平滑过渡。</para>
		/// <para><see cref="DefaultMosaicMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object DefaultMosaicMethod { get; set; } = "Center";

		/// <summary>
		/// <para>Order Field</para>
		/// <para>使用默认镶嵌方法参数的按属性值排列栅格时要使用的字段。 根据属性表中类型为元数据并且为整型的字段来定义可用字段列表。 此列表可包括但不限于以下各项：</para>
		/// <para>MinPS</para>
		/// <para>MaxPS</para>
		/// <para>LowPS</para>
		/// <para>HighPS</para>
		/// <para>CenterX</para>
		/// <para>CenterY</para>
		/// <para>ZOrder</para>
		/// <para>Shape_Length</para>
		/// <para>Shape_Area</para>
		/// <para>如果字段是数值或日期字段，则必须设置排序基础参数。</para>
		/// <para>如果允许的镶嵌方法列表中不包含按属性值，则不需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object OrderField { get; set; }

		/// <summary>
		/// <para>Order Base</para>
		/// <para>按栅格与排序字段参数中所选字段的值之间的差异对栅格进行排序。</para>
		/// <para>如果使用“日期”属性，则必须采用下列格式之一：</para>
		/// <para>YYYY/MM/DD hh:mm:ss.s</para>
		/// <para>YYYY/MM/DD hh:mm:ss</para>
		/// <para>yyyy/MM/dd HH:mm</para>
		/// <para>yyyy/MM/dd HH</para>
		/// <para>YYYY/MM/DD</para>
		/// <para>YYYY/MM</para>
		/// <para>YYYY</para>
		/// <para>仅在允许的镶嵌方法参数中指定按属性值时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object OrderBase { get; set; }

		/// <summary>
		/// <para>Sorting Order Ascending</para>
		/// <para>指定将按升序还是降序排序栅格。</para>
		/// <para>选中 - 栅格将按升序排序。 这是默认设置。</para>
		/// <para>未选中 - 栅格将按降序排序。</para>
		/// <para>仅在允许的镶嵌方法参数中指定按属性值时，需要此参数。</para>
		/// <para><see cref="SortingOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object SortingOrder { get; set; } = "true";

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>指定重叠像素的解决规则。</para>
		/// <para>第一个—将显示属性表中的第一个影像。</para>
		/// <para>最后一个—将显示属性表中的最后一个影像。</para>
		/// <para>最小值—将显示最低像素值。</para>
		/// <para>最大值—将显示最高像素值。</para>
		/// <para>平均值—将使用算术平均值计算平均重叠像素值。</para>
		/// <para>混合—将使用距离权重算法计算平均重叠像素值。</para>
		/// <para>总和—将所有的重叠像素值相加在一起。</para>
		/// <para><see cref="MosaicOperatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object MosaicOperator { get; set; } = "FIRST";

		/// <summary>
		/// <para>Blend Width</para>
		/// <para>将应用镶嵌运算符参数的混合值的像素数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Mosaic Properties")]
		public object BlendWidth { get; set; } = "10";

		/// <summary>
		/// <para>View Point Spacing X</para>
		/// <para>将用于水平平移影像中心的数值。 单位与空间参考系统相同。</para>
		/// <para>仅当允许的镶嵌方法参数设置为视点时，此参数才适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Mosaic Properties")]
		public object ViewPointX { get; set; } = "600";

		/// <summary>
		/// <para>View Point Spacing Y</para>
		/// <para>将用于垂直平移影像中心的数值。 单位与空间参考系统相同。</para>
		/// <para>仅当允许的镶嵌方法参数设置为视点时，此参数才适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Mosaic Properties")]
		public object ViewPointY { get; set; } = "300";

		/// <summary>
		/// <para>Max Number Per Mosaic</para>
		/// <para>给定时间内镶嵌数据集中将显示的栅格数据集的最大数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Mosaic Properties")]
		public object MaxNumPerMosaic { get; set; } = "20";

		/// <summary>
		/// <para>Cell Size Tolerance Factor</para>
		/// <para>在影像被视为具有不同的像元像素之前允许的最大像素大小差异。</para>
		/// <para>这允许将具有相似空间分辨率的影像视为具有相同的标称分辨率。 例如，如果系数为 0.1，则所有像元大小相差在 10% 内的影像将被分组为使用像元大小的工具和操作。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Mosaic Properties")]
		public object CellSizeTolerance { get; set; } = "0.8";

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>使用现有栅格数据集或指定宽度 (x) 和高度 (y) 设置镶嵌数据集的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCellSizeXY()]
		[Category("Mosaic Properties")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Metadata Level</para>
		/// <para>指定发布镶嵌数据集时将从服务器向客户端显示的元数据级别。</para>
		/// <para>完整元数据—将显示与镶嵌数据集级别应用的处理相关的元数据以及与单个栅格数据集相关的元数据。</para>
		/// <para>没有元数据—不向客户端显示元数据。</para>
		/// <para>基本元数据—将传输与单个栅格数据集相关的元数据，如列数和行数、像元大小和空间参考信息。</para>
		/// <para><see cref="MetadataLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Catalog Item Properties")]
		public object MetadataLevel { get; set; } = "FULL";

		/// <summary>
		/// <para>Allowed Transmission Field</para>
		/// <para>属性表中可供客户查看的字段。 默认情况下，列表包括以下各项：</para>
		/// <para>Name</para>
		/// <para>MinPS</para>
		/// <para>MaxPS</para>
		/// <para>LowPS</para>
		/// <para>HighPS</para>
		/// <para>Tag</para>
		/// <para>GroupName</para>
		/// <para>ProductName</para>
		/// <para>CenterX</para>
		/// <para>CenterY</para>
		/// <para>ZOrder</para>
		/// <para>Shape_Length</para>
		/// <para>Shape_Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Catalog Item Properties")]
		public object TransmissionFields { get; set; }

		/// <summary>
		/// <para>Use Time</para>
		/// <para>指定镶嵌数据集是否具有时间感知功能。 如果激活了时间，则必须指定起始和结束字段，以及时间格式。</para>
		/// <para>未选中 - 镶嵌数据集将不具有时间感知功能。 这是默认设置。</para>
		/// <para>选中 - 镶嵌数据集将具有时间感知功能。 这样客户就可以使用时间滑块。</para>
		/// <para><see cref="UseTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Catalog Item Properties")]
		public object UseTime { get; set; } = "false";

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>属性表中用于显示起始时间的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Catalog Item Properties")]
		public object StartTimeField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>属性表中用于显示结束时间的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Catalog Item Properties")]
		public object EndTimeField { get; set; }

		/// <summary>
		/// <para>Time Format</para>
		/// <para>指定开始时间字段和结束时间字段等参数的镶嵌数据集的时间格式。</para>
		/// <para>YYYY（年）—年</para>
		/// <para>YYYYMM（年和月）—年和月</para>
		/// <para>YYYY/MM（年和月）—年和月</para>
		/// <para>YYYY-MM（年和月）—年和月</para>
		/// <para>YYYYMMDD（年、月和日）—年，月和日</para>
		/// <para>YYYY/MM/DD（年、月和日）—年，月和日</para>
		/// <para>YYYY-MM-DD（年、月和日）—年，月和日</para>
		/// <para>YYYYMMDDhhmmss（年、月、日、小时、分钟和秒）—年、月、日、小时、分钟和秒</para>
		/// <para>YYYY/MM/DD hh:mm:ss（年、月、日、小时、分钟和秒）—年、月、日、小时、分钟和秒</para>
		/// <para>YYYY-MM-DD hh:mm:ss（年、月、日、小时、分钟和秒）—年、月、日、小时、分钟和秒</para>
		/// <para>YYYYMMDDhhmmss.s（年、月、日、小时、分钟、秒和秒的小数位）—年、月、日、小时、分钟、秒和秒的小数位</para>
		/// <para>YYYY/MM/DD hh:mm:ss.s（年、月、日、小时、分钟、秒和秒的小数位）—年、月、日、小时、分钟、秒和秒的小数位</para>
		/// <para>YYYY-MM-DD hh:mm:ss.s（年、月、日、小时、分钟、秒和秒的小数位）—年、月、日、小时、分钟、秒和秒的小数位</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Catalog Item Properties")]
		public object TimeFormat { get; set; }

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>与镶嵌数据集关联的地理变换。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Catalog Item Properties")]
		public object GeographicTransform { get; set; }

		/// <summary>
		/// <para>Max Number of Download Items</para>
		/// <para>每个请求可下载的最大栅格数据集数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Catalog Item Properties")]
		public object MaxNumOfDownloadItems { get; set; } = "20";

		/// <summary>
		/// <para>Max Number of Records Returned</para>
		/// <para>每个请求可下载的最大记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Catalog Item Properties")]
		public object MaxNumOfRecordsReturned { get; set; } = "1000";

		/// <summary>
		/// <para>Data Source Type</para>
		/// <para>指定镶嵌数据集内的影像类型。</para>
		/// <para>通用—镶嵌数据集包含未指定数据类型。</para>
		/// <para>专题—镶嵌数据集包含具有离散值的专题数据，例如土地覆被。</para>
		/// <para>已处理—已对镶嵌数据集进行了色彩校正。</para>
		/// <para>高程—镶嵌数据集包含高程数据。</para>
		/// <para>科学—镶嵌数据集包含科学数据。</para>
		/// <para>双变量矢量—镶嵌数据集具有两个变量。</para>
		/// <para>量级和方向—镶嵌数据集具有量级和方向。</para>
		/// <para><see cref="DataSourceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Image Properties")]
		public object DataSourceType { get; set; } = "GENERIC";

		/// <summary>
		/// <para>Minimum Pixel Contribution</para>
		/// <para>镶嵌数据集项目至少需要具有多少像素才可视为足够在镶嵌数据集中使用。 由于存在重叠影像，可能有某个项目仅显示整个影像的一小部分。 跳过这些镶嵌数据集项目将提高镶嵌数据集的性能。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Catalog Item Properties")]
		public object MinimumPixelContribution { get; set; } = "1";

		/// <summary>
		/// <para>Processing Templates</para>
		/// <para>将用于动态处理镶嵌数据集或镶嵌数据集项目的函数链。 您可以添加、移除函数链，或对其进行重新排序。</para>
		/// <para>添加的所有模板名称必须唯一。</para>
		/// <para>有关函数链使用方法的信息，请参阅栅格函数模板。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFileDomain()]
		[FileTypes("rft.xml", "rft.json", "rft", "xml", "json")]
		[Category("Image Properties")]
		public object ProcessingTemplates { get; set; }

		/// <summary>
		/// <para>Default Processing Template</para>
		/// <para>默认函数链。 当访问镶嵌数据集时，将应用默认函数链。</para>
		/// <para>无—无处理模板。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Image Properties")]
		public object DefaultProcessingTemplate { get; set; } = "None";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Time Interval</para>
		/// <para>每个时间步长间隔的持续时间。 时间步长间隔定义时态数据的间隔长度。 时间单位在时间间隔单位参数中进行指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Catalog Item Properties")]
		public object TimeInterval { get; set; }

		/// <summary>
		/// <para>Time Interval Units</para>
		/// <para>指定时间间隔的单位。</para>
		/// <para>无—无时间单位或时间单位未知。</para>
		/// <para>毫秒—时间单位为毫秒。</para>
		/// <para>秒—时间单位为秒。</para>
		/// <para>分—时间单位为分钟。</para>
		/// <para>小时—时间单位为小时。</para>
		/// <para>天—时间单位为天。</para>
		/// <para>周—时间单位为周。</para>
		/// <para>月—时间单位为月。</para>
		/// <para>年—时间单位为年。</para>
		/// <para>十年—时间单位为十年。</para>
		/// <para>世纪—时间单位为百年。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Catalog Item Properties")]
		public object TimeIntervalUnits { get; set; }

		/// <summary>
		/// <para>Product Definition</para>
		/// <para>指定您正在使用的影像类型的特定模板，或选择通用模板。 通用选项包含以下标准支持栅格传感器类型：</para>
		/// <para>无—不为镶嵌数据集指定波段顺序。 这是默认设置。</para>
		/// <para>真彩色—使用红色、绿色和蓝色波长范围创建 3 波段镶嵌数据集。 该选项适用于自然色影像。</para>
		/// <para>自然色和红外—使用红色、绿色、蓝色和近红外波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>U 和 V—创建显示两个变量的镶嵌数据集。</para>
		/// <para>量级和方向—创建显示量级和方向的镶嵌数据集。</para>
		/// <para>彩色红外—使用近红外、红色和绿色波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>DMCii—使用 DMCii 波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>Deimos-2—使用 Deimos-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>DubaiSat-2—使用 DubaiSat-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>FORMOSAT-2—使用 FORMOSAT-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GeoEye-1—使用 GeoEye-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-1 全色/多光谱 (PMS)—使用 Gaofen-1 全色多光谱传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-1 宽视域 (WFV)—使用 Gaofen-1 宽视域传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-2 全色/多光谱 (PMS)—使用 Gaofen-2 全色多光谱传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-4 全色或多光谱影像 (PMI)—使用 Gaofen-4 全色和多光谱波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>HJ 1A 或 1B 多光谱或高光谱—使用 Huan Jing-1 CCD 多光谱或高光谱传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>IKONOS—使用 IKONOS 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Jilin-1—使用 Jilin-1 波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>KOMPSAT-2—使用 KOMPSAT-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>KOMPSAT-3—使用 KOMPSAT-3 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Landsat TM 和 ETM+—使用 Landsat 5 和 7 的 TM 和 ETM+ 传感器的波长范围创建 6 波段镶嵌数据集。</para>
		/// <para>Landsat OLI—使用 LANDSAT 8 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>Landsat MSS—使用 MSS 传感器的 Landsat 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>PlanetScope—使用 PlanetScope 波长范围创建镶嵌数据集。</para>
		/// <para>Pleiades 1—使用 PLEIADES-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>QuickBird—使用 QuickBird 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>RapidEye—使用 RapidEye 波长范围创建 5 波段镶嵌数据集。</para>
		/// <para>Sentinel 2 MSI—使用 Sentinel 2 MSI 波长范围创建 13 波段镶嵌数据集。</para>
		/// <para>SkySat-C—使用 SkySat-C MSI 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Spot 5—使用 SPOT-5 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Spot 6—使用 SPOT-6 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Spot 7—使用 SPOT-7 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>TH-01—使用 Tian Hui-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>WorldView 2—使用 WorldView-2 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>WorldView 3—使用 WorldView-3 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>WorldView 4—使用 WorldView-4 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>ZY-1 全色/多光谱—使用 ZiYuan-1 全色或多光谱波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>ZY-3 CRESDA—使用 ZiYuan-3 CRESDA 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>ZY3 SASMAC—使用 ZiYuan-3 SASMAC 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>自定义—定义波段数和每个波段的平均波长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object ProductDefinition { get; set; } = "NONE";

		/// <summary>
		/// <para>Product Band Definitions</para>
		/// <para>波长范围、波段数量和波段顺序的定义。 要编辑波段数量，请使用添加其他和移除控件。 要重新排列波段顺序，请右键单击波段定义，然后在列表中上下移动波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Mosaic Properties")]
		public object ProductBandDefinitions { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Allowed Transmission Compression</para>
		/// </summary>
		public enum AllowedCompressionsEnum 
		{
			/// <summary>
			/// <para>无—不使用压缩。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>JPEG—最多压缩至 8:1 并且适合用作背景。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>LZ77—将使用适用于分析的压缩比接近 2:1 的压缩。</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77")]
			LZ77,

			/// <summary>
			/// <para>LERC—将使用压缩比在 10:1 和 20:1 之间的压缩，这种压缩速度快且适用于具有高位深度（12 位至 32 位）的原始图像。</para>
			/// </summary>
			[GPValue("LERC")]
			[Description("LERC")]
			LERC,

		}

		/// <summary>
		/// <para>Default Compression Type</para>
		/// </summary>
		public enum DefaultCompressionTypeEnum 
		{
			/// <summary>
			/// <para>无—不使用压缩。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>JPEG—最多压缩至 8:1 并且适合用作背景。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>LZ77—将使用适用于分析的压缩比接近 2:1 的压缩。</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77")]
			LZ77,

			/// <summary>
			/// <para>LERC—将使用压缩比在 10:1 和 20:1 之间的压缩，这种压缩速度快且适用于具有高位深度（12 位至 32 位）的原始图像。</para>
			/// </summary>
			[GPValue("LERC")]
			[Description("LERC")]
			LERC,

		}

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>最邻近—每个像素的值将来自最近的对应像素。 此技术适用于离散数据，例如土地覆被。此为最快的重采样技术。 由于它使用了来自最近像素的值，因此可以最小化像素值的变化。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>双线性—通过计算周围 4 像素的平均值（基于距离）来计算每个像素的值。 此技术适用于连续数据。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性")]
			Bilinear,

			/// <summary>
			/// <para>三次—通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此技术将生成平滑影像，但可创建超出源数据范围的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

			/// <summary>
			/// <para>众数—每个像素的值基于 3 x 3 窗口中出现频率最高的值。 此技术适用于离散数据。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

		}

		/// <summary>
		/// <para>Clip To Footprints</para>
		/// </summary>
		public enum ClipToFootprintsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_CLIP")]
			NOT_CLIP,

		}

		/// <summary>
		/// <para>Footprints May Contain NoData</para>
		/// </summary>
		public enum FootprintsMayContainNodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FOOTPRINTS_MAY_CONTAIN_NODATA")]
			FOOTPRINTS_MAY_CONTAIN_NODATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FOOTPRINTS_DO_NOT_CONTAIN_NODATA")]
			FOOTPRINTS_DO_NOT_CONTAIN_NODATA,

		}

		/// <summary>
		/// <para>Clip To Boundary</para>
		/// </summary>
		public enum ClipToBoundaryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_CLIP")]
			NOT_CLIP,

		}

		/// <summary>
		/// <para>Color Correction</para>
		/// </summary>
		public enum ColorCorrectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY")]
			APPLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_APPLY")]
			NOT_APPLY,

		}

		/// <summary>
		/// <para>Allowed Mensuration Capabilities</para>
		/// </summary>
		public enum AllowedMensurationCapabilitiesEnum 
		{
			/// <summary>
			/// <para>无—不执行测量功能。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>基础—将执行距离、点、质心和面积计算等地面测量。</para>
			/// </summary>
			[GPValue("Basic")]
			[Description("基础")]
			Basic,

			/// <summary>
			/// <para>要素底端至要素顶端—将执行从要素底端到要素顶端的测量。 有理多项式系数必须嵌入影像中。</para>
			/// </summary>
			[GPValue("Base-Top Height")]
			[Description("要素底端至要素顶端")]
			Feature_base_to_top_of_feature,

			/// <summary>
			/// <para>要素底端至阴影顶端—将执行从要素底端到其阴影顶端的测量。 需要太阳方位角和太阳高度角的信息。</para>
			/// </summary>
			[GPValue("Base-Top Shadow Height")]
			[Description("要素底端至阴影顶端")]
			Feature_base_to_top_of_shadow,

			/// <summary>
			/// <para>要素顶端至阴影顶端—将执行从要素顶端到其阴影顶端的测量。 需要太阳方位角、太阳高度角和有理多项式系数。</para>
			/// </summary>
			[GPValue("Top-Top Shadow Height")]
			[Description("要素顶端至阴影顶端")]
			Top_of_feature_to_top_of_shadow,

			/// <summary>
			/// <para>3D 测量—如果 DEM 可用，则将在 3D 模式下进行测量。</para>
			/// </summary>
			[GPValue("3D")]
			[Description("3D 测量")]
			Measure_in_3D,

		}

		/// <summary>
		/// <para>Default Mensuration</para>
		/// </summary>
		public enum DefaultMensurationCapabilitiesEnum 
		{
			/// <summary>
			/// <para>无—不执行测量功能。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>基础—将执行距离、点、质心和面积计算等地面测量。</para>
			/// </summary>
			[GPValue("Basic")]
			[Description("基础")]
			Basic,

			/// <summary>
			/// <para>要素底端至要素顶端—将执行从要素底端到要素顶端的测量。 有理多项式系数必须嵌入影像中。</para>
			/// </summary>
			[GPValue("Base-Top Height")]
			[Description("要素底端至要素顶端")]
			Feature_base_to_top_of_feature,

			/// <summary>
			/// <para>要素底端至阴影顶端—将执行从要素底端到其阴影顶端的测量。 需要太阳方位角和太阳高度角的信息。</para>
			/// </summary>
			[GPValue("Base-Top Shadow Height")]
			[Description("要素底端至阴影顶端")]
			Feature_base_to_top_of_shadow,

			/// <summary>
			/// <para>要素顶端至阴影顶端—将执行从要素顶端到其阴影顶端的测量。 需要太阳方位角、太阳高度角和有理多项式系数。</para>
			/// </summary>
			[GPValue("Top-Top Shadow Height")]
			[Description("要素顶端至阴影顶端")]
			Top_of_feature_to_top_of_shadow,

			/// <summary>
			/// <para>3D 测量—如果 DEM 可用，则将在 3D 模式下进行测量。</para>
			/// </summary>
			[GPValue("3D")]
			[Description("3D 测量")]
			Measure_in_3D,

		}

		/// <summary>
		/// <para>Allowed Mosaic Methods</para>
		/// </summary>
		public enum AllowedMosaicMethodsEnum 
		{
			/// <summary>
			/// <para>无—将根据镶嵌数据集属性表中的 ObjectID 字段对栅格进行排序。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>居中—将显示距离屏幕中心最近的影像。</para>
			/// </summary>
			[GPValue("Center")]
			[Description("居中")]
			Center,

			/// <summary>
			/// <para>西北—将显示距离镶嵌数据集边界西北角最近的影像。</para>
			/// </summary>
			[GPValue("NorthWest")]
			[Description("西北")]
			Northwest,

			/// <summary>
			/// <para>锁定栅格—将显示所选栅格数据集。</para>
			/// </summary>
			[GPValue("LockRaster")]
			[Description("锁定栅格")]
			Lock_raster,

			/// <summary>
			/// <para>按属性—将基于属性表中的字段显示影像并设置影像优先级。</para>
			/// </summary>
			[GPValue("ByAttribute")]
			[Description("按属性")]
			By_attribute,

			/// <summary>
			/// <para>像底点—将通过最接近零视角的视角范围来显示栅格。</para>
			/// </summary>
			[GPValue("Nadir")]
			[Description("像底点")]
			Nadir,

			/// <summary>
			/// <para>视点—将显示距离所选视角最近的影像。</para>
			/// </summary>
			[GPValue("Viewpoint")]
			[Description("视点")]
			Viewpoint,

			/// <summary>
			/// <para>接缝线—将使用接缝线在影像间进行平滑过渡。</para>
			/// </summary>
			[GPValue("Seamline")]
			[Description("接缝线")]
			Seamline,

		}

		/// <summary>
		/// <para>Default Mosaic Methods</para>
		/// </summary>
		public enum DefaultMosaicMethodEnum 
		{
			/// <summary>
			/// <para>无—将根据镶嵌数据集属性表中的 ObjectID 字段对栅格进行排序。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>居中—将显示距离屏幕中心最近的影像。</para>
			/// </summary>
			[GPValue("Center")]
			[Description("居中")]
			Center,

			/// <summary>
			/// <para>西北—将显示距离镶嵌数据集边界西北角最近的影像。</para>
			/// </summary>
			[GPValue("NorthWest")]
			[Description("西北")]
			Northwest,

			/// <summary>
			/// <para>锁定栅格—将显示所选栅格数据集。</para>
			/// </summary>
			[GPValue("LockRaster")]
			[Description("锁定栅格")]
			Lock_raster,

			/// <summary>
			/// <para>按属性—将基于属性表中的字段显示影像并设置影像优先级。</para>
			/// </summary>
			[GPValue("ByAttribute")]
			[Description("按属性")]
			By_attribute,

			/// <summary>
			/// <para>像底点—将通过最接近零视角的视角范围来显示栅格。</para>
			/// </summary>
			[GPValue("Nadir")]
			[Description("像底点")]
			Nadir,

			/// <summary>
			/// <para>视点—将显示距离所选视角最近的影像。</para>
			/// </summary>
			[GPValue("Viewpoint")]
			[Description("视点")]
			Viewpoint,

			/// <summary>
			/// <para>接缝线—将使用接缝线在影像间进行平滑过渡。</para>
			/// </summary>
			[GPValue("Seamline")]
			[Description("接缝线")]
			Seamline,

		}

		/// <summary>
		/// <para>Sorting Order Ascending</para>
		/// </summary>
		public enum SortingOrderEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ASCENDING")]
			ASCENDING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DESCENDING")]
			DESCENDING,

		}

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// </summary>
		public enum MosaicOperatorEnum 
		{
			/// <summary>
			/// <para>第一个—将显示属性表中的第一个影像。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("第一个")]
			First,

			/// <summary>
			/// <para>最后一个—将显示属性表中的最后一个影像。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后一个")]
			Last,

			/// <summary>
			/// <para>最小值—将显示最低像素值。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—将显示最高像素值。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>平均值—将使用算术平均值计算平均重叠像素值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>混合—将使用距离权重算法计算平均重叠像素值。</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("混合")]
			Blend,

			/// <summary>
			/// <para>总和—将所有的重叠像素值相加在一起。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

		}

		/// <summary>
		/// <para>Metadata Level</para>
		/// </summary>
		public enum MetadataLevelEnum 
		{
			/// <summary>
			/// <para>没有元数据—不向客户端显示元数据。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("没有元数据")]
			No_metadata,

			/// <summary>
			/// <para>基本元数据—将传输与单个栅格数据集相关的元数据，如列数和行数、像元大小和空间参考信息。</para>
			/// </summary>
			[GPValue("BASIC")]
			[Description("基本元数据")]
			Basic_metadata,

			/// <summary>
			/// <para>完整元数据—将显示与镶嵌数据集级别应用的处理相关的元数据以及与单个栅格数据集相关的元数据。</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("完整元数据")]
			Full_metadata,

		}

		/// <summary>
		/// <para>Use Time</para>
		/// </summary>
		public enum UseTimeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLED")]
			ENABLED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLED")]
			DISABLED,

		}

		/// <summary>
		/// <para>Data Source Type</para>
		/// </summary>
		public enum DataSourceTypeEnum 
		{
			/// <summary>
			/// <para>通用—镶嵌数据集包含未指定数据类型。</para>
			/// </summary>
			[GPValue("GENERIC")]
			[Description("通用")]
			Generic,

			/// <summary>
			/// <para>专题—镶嵌数据集包含具有离散值的专题数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("THEMATIC")]
			[Description("专题")]
			Thematic,

			/// <summary>
			/// <para>已处理—已对镶嵌数据集进行了色彩校正。</para>
			/// </summary>
			[GPValue("PROCESSED")]
			[Description("已处理")]
			Processed,

			/// <summary>
			/// <para>高程—镶嵌数据集包含高程数据。</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("高程")]
			Elevation,

			/// <summary>
			/// <para>科学—镶嵌数据集包含科学数据。</para>
			/// </summary>
			[GPValue("SCIENTIFIC")]
			[Description("科学")]
			Scientific,

			/// <summary>
			/// <para>双变量矢量—镶嵌数据集具有两个变量。</para>
			/// </summary>
			[GPValue("VECTOR_UV")]
			[Description("双变量矢量")]
			Two_variable_vector,

			/// <summary>
			/// <para>量级和方向—镶嵌数据集具有量级和方向。</para>
			/// </summary>
			[GPValue("VECTOR_MAGDIR")]
			[Description("量级和方向")]
			Magnitude_and_direction,

		}

#endregion
	}
}
