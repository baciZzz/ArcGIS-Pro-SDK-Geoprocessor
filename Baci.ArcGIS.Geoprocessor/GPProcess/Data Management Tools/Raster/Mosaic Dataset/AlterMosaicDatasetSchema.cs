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
	/// <para>Alter Mosaic Dataset Schema</para>
	/// <para>更改镶嵌数据集方案</para>
	/// <para>定义在企业级地理数据库中编辑镶嵌数据集时非所有者可以执行的编辑操作。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterMosaicDatasetSchema : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>要更改允许的操作的镶嵌数据集。</para>
		/// </param>
		public AlterMosaicDatasetSchema(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改镶嵌数据集方案</para>
		/// </summary>
		public override string DisplayName() => "更改镶嵌数据集方案";

		/// <summary>
		/// <para>Tool Name : AlterMosaicDatasetSchema</para>
		/// </summary>
		public override string ToolName() => "AlterMosaicDatasetSchema";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterMosaicDatasetSchema</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterMosaicDatasetSchema";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, SideTables!, RasterTypeNames!, EditorTracking!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>要更改允许的操作的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Operations</para>
		/// <para>指定此镶嵌数据集允许的操作。</para>
		/// <para>分析—允许非所有者运行镶嵌数据集上的分析镶嵌数据集工具。</para>
		/// <para>边界—允许非所有者创建或编辑镶嵌数据集的边界。 如果非所有者将在现有边界外添加栅格数据集，则需要此操作。</para>
		/// <para>缓存—允许非所有者创建镶嵌数据集的缓存。</para>
		/// <para>色彩校正—允许非所有者校正镶嵌数据集的色彩。</para>
		/// <para>定义—允许非所有者向镶嵌数据集添加多维数据或处理模板。</para>
		/// <para>级别—允许非所有者计算镶嵌数据集的像元大小范围。</para>
		/// <para>对数—允许非所有者创建镶嵌数据集的日志表。</para>
		/// <para>概视图—允许非所有者创建镶嵌数据集的概览。</para>
		/// <para>接缝线—允许非所有者创建镶嵌数据集的接缝线。</para>
		/// <para>立体—允许非所有者定义镶嵌数据集的立体对。</para>
		/// <para>视图—允许非所有者编辑影像服务。 选中后将自动打开启用编辑者追踪。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? SideTables { get; set; }

		/// <summary>
		/// <para>Raster Types</para>
		/// <para>指定非所有者可向该镶嵌数据集添加的栅格类型。</para>
		/// <para>要选择自定义栅格类型，请提供自定义栅格类型文件的位置。</para>
		/// <para>机载数字传感器—Leica ADS 栅格类型</para>
		/// <para>Altum—Altum 栅格类型</para>
		/// <para>ASTER—ASTER 栅格类型</para>
		/// <para>CADRG/ECRG—CADRG/ECRG 栅格类型</para>
		/// <para>CIB—CIB 栅格类型</para>
		/// <para>Deimos-2—Deimos-2 栅格类型</para>
		/// <para>DTED—DTED 栅格类型</para>
		/// <para>DMCii—DMCii 栅格类型</para>
		/// <para>DubaiSat-2—DubaiSat-2 栅格类型</para>
		/// <para>FORMOSAT-2—FORMOSAT-2 栅格类型</para>
		/// <para>帧照相机—帧照相机栅格类型</para>
		/// <para>GeoEye—GeoEye-1 栅格类型</para>
		/// <para>GF-1 PMS—GF-1 PMS 栅格类型</para>
		/// <para>GF-1 WFV—GF-1 WFV 栅格类型</para>
		/// <para>GF-2 PMS—GF-2 PMS 栅格类型</para>
		/// <para>GF-4 PMI—GF-4 PMI 栅格类型</para>
		/// <para>GRIB—GRIB 栅格类型</para>
		/// <para>HDF—HDF 栅格类型</para>
		/// <para>HJ 1A/HJ 1B CCD—HJ 1A/HJ 1B CCD 栅格类型</para>
		/// <para>HRE—HRE 栅格类型</para>
		/// <para>IKONOS—IKONOS 栅格类型</para>
		/// <para>Jilin-1—Jilin-1 栅格类型</para>
		/// <para>KOMPSAT-2—KOMPSAT-2 栅格类型</para>
		/// <para>KOMPSAT-3—KOMPSAT-3 栅格类型</para>
		/// <para>LAS—LAS 栅格类型</para>
		/// <para>Landsat MSS—Landsat 1-5 MSS 栅格类型</para>
		/// <para>Landsat TM—Landsat 4-5 TM 栅格类型</para>
		/// <para>Landsat ETM+—Landsat 7 ETM+ 栅格类型</para>
		/// <para>Landsat 8—Landsat 8 栅格类型</para>
		/// <para>Landsat 9—Landsat 9 栅格类型</para>
		/// <para>Maxar—Maxar</para>
		/// <para>NCDRD—NCDRD 栅格类型</para>
		/// <para>NITF—NITF 栅格类型</para>
		/// <para>NetCDF—NetCDF 栅格类型</para>
		/// <para>PlanetScope—PlanetScope 栅格类型</para>
		/// <para>Pleiades Neo—Pleiades Neo 栅格类型</para>
		/// <para>Pleiades-1—Pleiades-1 栅格类型</para>
		/// <para>QuickBird—Quickbird 栅格类型</para>
		/// <para>RADARSAT-2—RADARSAT-2 栅格类型</para>
		/// <para>RapidEye—RapidEye 栅格类型</para>
		/// <para>栅格处理定义—栅格处理定义栅格类型</para>
		/// <para>RedEdge—RedEdge 栅格类型</para>
		/// <para>扫描的航空影像—扫描的航空影像栅格类型</para>
		/// <para>Sentinel-1—Sentinel -1 栅格类型</para>
		/// <para>Sentinel-2—Sentinel -2 栅格类型</para>
		/// <para>Sentinel-3—Sentinel -3 栅格类型</para>
		/// <para>SkySat-C—SkySat-C 栅格类型</para>
		/// <para>Spot 5—SPOT 5 栅格类型</para>
		/// <para>Spot 6—SPOT 6 栅格类型</para>
		/// <para>Spot 7—SPOT 7 栅格类型</para>
		/// <para>SuperView-1—SuperView-1 栅格类型</para>
		/// <para>TeLEOS-1—TelEOS-1 栅格类型</para>
		/// <para>TH-01—TH-01 栅格类型</para>
		/// <para>UAV/UAS—UAV/UAS 栅格类型</para>
		/// <para>WorldView-1—WorldView-1 栅格类型</para>
		/// <para>WorldView-2—WorldView-2 栅格类型</para>
		/// <para>WorldView-3—WorldView-3 栅格类型</para>
		/// <para>WorldView-4—WorldView-4 栅格类型</para>
		/// <para>ZY1-02C HRC—ZY1-02C HRC 栅格类型</para>
		/// <para>ZY1-02C PMS—ZY1-02C PMS 栅格类型</para>
		/// <para>ZY3-CRESDA—ZY3-CRESDA 栅格类型</para>
		/// <para>ZY3-SASMAC—ZY3-SASMAC 栅格类型</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? RasterTypeNames { get; set; }

		/// <summary>
		/// <para>Enable Editor Tracking</para>
		/// <para>指定是否激活启用编辑者追踪</para>
		/// <para>编辑者追踪有助于维持责任制度，并强化质量控制标准。</para>
		/// <para>未选中 - 不激活编辑者追踪。 这是默认设置。</para>
		/// <para>选中 - 激活编辑者追踪。</para>
		/// <para>如果在操作参数中使用视图选项，则将自动激活编辑者追踪。</para>
		/// <para><see cref="EditorTrackingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EditorTracking { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Enable Editor Tracking</para>
		/// </summary>
		public enum EditorTrackingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EDITOR_TRACKING")]
			EDITOR_TRACKING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EDITOR_TRACKING")]
			NO_EDITOR_TRACKING,

		}

#endregion
	}
}
