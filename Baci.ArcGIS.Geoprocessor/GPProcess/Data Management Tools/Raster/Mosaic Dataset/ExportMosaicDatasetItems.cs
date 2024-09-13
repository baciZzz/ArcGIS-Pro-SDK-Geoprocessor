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
	/// <para>Export Mosaic Dataset Items</para>
	/// <para>导出镶嵌数据集项目</para>
	/// <para>将镶嵌数据集中处理过的影像副本以栅格文件格式保存到指定的文件夹。</para>
	/// </summary>
	public class ExportMosaicDatasetItems : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>包含要导出的影像的镶嵌数据集。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>将保存影像的文件夹。</para>
		/// </param>
		public ExportMosaicDatasetItems(object InMosaicDataset, object OutFolder)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出镶嵌数据集项目</para>
		/// </summary>
		public override string DisplayName() => "导出镶嵌数据集项目";

		/// <summary>
		/// <para>Tool Name : ExportMosaicDatasetItems</para>
		/// </summary>
		public override string ToolName() => "ExportMosaicDatasetItems";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportMosaicDatasetItems</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportMosaicDatasetItems";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "snapRaster", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFolder, OutBaseName!, WhereClause!, Format!, NodataValue!, ClipType!, TemplateDataset!, CellSize!, DerivedOutFolder!, ImageSpace! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>包含要导出的影像的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将保存影像的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>复制后添加到每个项目名称的前缀。 前缀后跟镶嵌数据集覆盖区表中的 Object ID 值。</para>
		/// <para>如果未设置基本名称，则将使用镶嵌数据集项的 Name 字段中的文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutBaseName { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中保存选定影像的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>指定输出栅格数据集的格式。</para>
		/// <para>TIFF—将使用 TIFF 格式。 这是默认设置。</para>
		/// <para>Cloud Optimized GeoTIFF—使用 Cloud Optimized GeoTIFF 格式。</para>
		/// <para>BMP—使用 BMP 格式。</para>
		/// <para>ENVI DAT—使用 ENVI DAT 格式。</para>
		/// <para>Esri BIL—使用 Esri BIL 格式。</para>
		/// <para>Esri BIP—使用 Esri BIP 格式。</para>
		/// <para>Esri BSQ—使用 Esri BSQ 格式。</para>
		/// <para>GIF—将使用图形交换格式 (GIF)。</para>
		/// <para>Esri 格网—将使用 Esri Grid 栅格数据集格式。</para>
		/// <para>ERDAS IMAGINE—将使用 ERDAS Imagine 格式。</para>
		/// <para>JPEG 2000—使用 JPEG 2000 格式。</para>
		/// <para>JPEG—将使用 JPEG 格式。</para>
		/// <para>PNG—将使用 PNG 格式。</para>
		/// <para>云栅格格式—将使用云栅格格式。</para>
		/// <para>元栅格格式—将使用元栅格格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>具有指定值的所有像素将在输出栅格数据集中被设置为 NoData。</para>
		/// <para>如果将裁剪输出影像，建议指定 NoData 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NodataValue { get; set; }

		/// <summary>
		/// <para>Clip Type</para>
		/// <para>指定栅格数据集的处理范围。 如果选择的范围或要素类涵盖的区域大于栅格数据，则输出将具有更大的范围。</para>
		/// <para>无裁剪—将不会裁剪输出。 这是默认设置。</para>
		/// <para>裁剪至范围—将使用范围裁剪输出。</para>
		/// <para>裁剪至要素类—将使用要素类范围裁剪输出。</para>
		/// <para><see cref="ClipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? ClipType { get; set; } = "NONE";

		/// <summary>
		/// <para>Clipping Template</para>
		/// <para>将用于限制范围的要素类或边界框。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Advanced Setting")]
		public object? TemplateDataset { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>输出像元的水平 (x) 和垂直 (y) 尺寸。</para>
		/// <para>如果未指定像元大小，则将使用输入的空间分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Advanced Setting")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Updated Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Export images to image space</para>
		/// <para>指定将栅格项目导出到地图空间还是影像空间。</para>
		/// <para>未选中 - 栅格项目将在地图空间中导出。 这是默认设置。</para>
		/// <para>选中 - 栅格项目将在影像空间中导出。</para>
		/// <para><see cref="ImageSpaceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ImageSpace { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetItems SetEnviroment(object? compression = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? snapRaster = null , object? tileSize = null )
		{
			base.SetEnv(compression: compression, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, snapRaster: snapRaster, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip Type</para>
		/// </summary>
		public enum ClipTypeEnum 
		{
			/// <summary>
			/// <para>无裁剪—将不会裁剪输出。 这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无裁剪")]
			No_clipping,

			/// <summary>
			/// <para>裁剪至范围—将使用范围裁剪输出。</para>
			/// </summary>
			[GPValue("EXTENT")]
			[Description("裁剪至范围")]
			Clip_to_extent,

			/// <summary>
			/// <para>裁剪至要素类—将使用要素类范围裁剪输出。</para>
			/// </summary>
			[GPValue("FEATURE_CLASS")]
			[Description("裁剪至要素类")]
			Clip_to_feature_class,

		}

		/// <summary>
		/// <para>Export images to image space</para>
		/// </summary>
		public enum ImageSpaceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IMAGESPACE")]
			IMAGESPACE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MAPSPACE")]
			MAPSPACE,

		}

#endregion
	}
}
