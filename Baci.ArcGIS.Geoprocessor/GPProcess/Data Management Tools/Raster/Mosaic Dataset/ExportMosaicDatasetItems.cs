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
		/// <para>想要保存影像的文件夹。</para>
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
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFolder, OutBaseName, WhereClause, Format, NodataValue, ClipType, TemplateDataset, CellSize, DerivedOutFolder };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>包含要导出的影像的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>想要保存影像的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>前缀命名被复制后的各项。前缀后跟镶嵌数据集覆盖区表中的 Object ID。</para>
		/// <para>如果未设置基本名称，则将使用镶嵌数据集项的 Name 字段中的文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中保存选定影像的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>指定输出栅格数据集的格式。</para>
		/// <para>TIFF—TIFF 格式。这是默认设置。</para>
		/// <para>Cloud Optimized GeoTIFF—Cloud Optimized GeoTIFF 格式。</para>
		/// <para>BMP—BMP 格式。</para>
		/// <para>ENVI DAT—ENVI DAT 格式。</para>
		/// <para>Esri BIL—Esri BIL 格式。</para>
		/// <para>Esri BIP—Esri BIP 格式。</para>
		/// <para>Esri BSQ—Esri BSQ 格式。</para>
		/// <para>GIF—GIF 格式。</para>
		/// <para>Esri Grid—Esri Grid 格式。</para>
		/// <para>ERDAS IMAGINE—ERDAS IMAGINE 格式。</para>
		/// <para>JPEG 2000—JPEG 2000 格式。</para>
		/// <para>JPEG—JPEG 格式。</para>
		/// <para>PNG—PNG 格式。</para>
		/// <para>云栅格格式—云栅格格式。</para>
		/// <para>元栅格格式—元栅格格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>具有指定值的所有像素将在输出栅格数据集中被设置为 NoData。</para>
		/// <para>如果将裁剪输出影像，建议指定 NoData 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Clip Type</para>
		/// <para>指定栅格数据集的处理范围。如果选择的范围或要素类涵盖的区域大于栅格数据，则输出将具有更大的范围。</para>
		/// <para>无裁剪—将不会裁剪输出。这是默认设置。</para>
		/// <para>裁剪至范围—将使用范围裁剪输出。</para>
		/// <para>裁剪至要素类—将使用要素类范围裁剪输出。</para>
		/// <para><see cref="ClipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object ClipType { get; set; } = "NONE";

		/// <summary>
		/// <para>Clipping Template</para>
		/// <para>用于限制范围的要素类或边界框。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Advanced Setting")]
		public object TemplateDataset { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>输出像元的水平 (x) 和垂直 (y) 尺寸。</para>
		/// <para>如果未指定，将使用输入的空间分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Advanced Setting")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Updated Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetItems SetEnviroment(object compression = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object snapRaster = null , double[] tileSize = null )
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
			/// <para>无裁剪—将不会裁剪输出。这是默认设置。</para>
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

#endregion
	}
}
