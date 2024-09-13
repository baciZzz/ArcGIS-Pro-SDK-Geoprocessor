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
	/// <para>Create Mosaic Dataset</para>
	/// <para>创建镶嵌数据集</para>
	/// <para>在地理数据库中创建一个空的镶嵌数据集。</para>
	/// </summary>
	public class CreateMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Output Location</para>
		/// <para>地理数据库路径。</para>
		/// <para>自 ArcGIS Pro 1.4 版本开始，在 Oracle、PostgreSQL 和 SQL Server 地理数据库中创建的镶嵌数据集都将使用名为 RASTERBLOB 的新 RASTER_STORAGE 关键词进行创建。 RASTERBLOB 关键词可以有效地将镶嵌数据集目录项转移至 DBMS。</para>
		/// <para>软件的早期版本无法打开利用 RASTERBLOB 创建的镶嵌数据集。 要创建与早期版本兼容的镶嵌数据集，您需要为 RASTER_STORAGE 更改配置关键词，使其变为以下任一兼容的关键词：</para>
		/// <para>适用于 PostgreSQL 和 SQL Server 的 BINARY</para>
		/// <para>适用于 Oracle 的 BLOB</para>
		/// </param>
		/// <param name="InMosaicdatasetName">
		/// <para>Mosaic Dataset Name</para>
		/// <para>新镶嵌数据集的名称。</para>
		/// </param>
		/// <param name="CoordinateSystem">
		/// <para>Coordinate System</para>
		/// <para>将用于镶嵌数据集中所有项目的坐标系。</para>
		/// </param>
		public CreateMosaicDataset(object InWorkspace, object InMosaicdatasetName, object CoordinateSystem)
		{
			this.InWorkspace = InWorkspace;
			this.InMosaicdatasetName = InMosaicdatasetName;
			this.CoordinateSystem = CoordinateSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "创建镶嵌数据集";

		/// <summary>
		/// <para>Tool Name : CreateMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "CreateMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, InMosaicdatasetName, CoordinateSystem, NumBands!, PixelType!, ProductDefinition!, ProductBandDefinitions!, OutMosaicDataset! };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>地理数据库路径。</para>
		/// <para>自 ArcGIS Pro 1.4 版本开始，在 Oracle、PostgreSQL 和 SQL Server 地理数据库中创建的镶嵌数据集都将使用名为 RASTERBLOB 的新 RASTER_STORAGE 关键词进行创建。 RASTERBLOB 关键词可以有效地将镶嵌数据集目录项转移至 DBMS。</para>
		/// <para>软件的早期版本无法打开利用 RASTERBLOB 创建的镶嵌数据集。 要创建与早期版本兼容的镶嵌数据集，您需要为 RASTER_STORAGE 更改配置关键词，使其变为以下任一兼容的关键词：</para>
		/// <para>适用于 PostgreSQL 和 SQL Server 的 BINARY</para>
		/// <para>适用于 Oracle 的 BLOB</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset Name</para>
		/// <para>新镶嵌数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InMosaicdatasetName { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>将用于镶嵌数据集中所有项目的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>镶嵌数据集中栅格数据集的波段数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pixel Properties")]
		public object? NumBands { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>指定将用于镶嵌数据集的位深度或辐射分辨率。 如果未定义，则将使用第一个栅格数据集的像素类型。</para>
		/// <para>1 位—像素类型为 1 位无符号整数。 值可以为 0 或 1。</para>
		/// <para>2 位—像素类型为 2 位无符号整数。 受支持的值范围为 0 到 3。</para>
		/// <para>4 位—像素类型为 4 位无符号整数。 受支持的值范围为 0 到 15。</para>
		/// <para>8 位无符号—像素类型为 8 位无符号数据类型。 受支持的值范围为 0 到 255。</para>
		/// <para>8 位有符号—像素类型为 8 位有符号数据类型。 受支持的值范围为 -128 到 127。</para>
		/// <para>16 位无符号—像素类型为 16 位无符号数据类型。 取值范围为 0 到 65,535。</para>
		/// <para>16 位有符号—像素类型为 16 位有符号数据类型。 取值范围为 -32,768 到 32,767。</para>
		/// <para>32 位无符号—像素类型为 32 位无符号数据类型。 取值范围为 0 到 4,294,967,295。</para>
		/// <para>32 位有符号—像素类型为 32 位有符号数据类型。 取值范围为 -2,147,483,648 到 2,147,483,647。</para>
		/// <para>32 位浮点型—像素类型为支持小数的 32 位数据类型。</para>
		/// <para>64 位—像素类型为支持小数的 64 位数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pixel Properties")]
		public object? PixelType { get; set; }

		/// <summary>
		/// <para>Product Definition</para>
		/// <para>指定模板是特定于您正在使用的图像类型还是通用的。 通用选项包含以下标准栅格数据类型：</para>
		/// <para>无—不为镶嵌数据集指定波段顺序。 这是默认设置。</para>
		/// <para>真彩色—将使用红色、绿色和蓝色波长范围创建 3 波段镶嵌数据集。 其专用于真彩色影像。</para>
		/// <para>真彩色和彩色红外—将使用红色、绿色、蓝色和近红外波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>U 和 V—将创建一个显示两个变量的镶嵌数据集。</para>
		/// <para>量级和方向—将创建一个显示量级和方向的镶嵌数据集。</para>
		/// <para>彩色红外—将使用近红外、红色和绿色波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>DMCii—将使用 DMCii 波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>Deimos-2—将使用 Deimos-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>DubaiSat-2—将使用 DubaiSat-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>FORMOSAT-2—将使用 FORMOSAT-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GeoEye-1—将使用 GeoEye-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-1 全色/多光谱 (PMS)—将使用 Gaofen-1 全色多光谱传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-1 宽视域 (WFV)—将使用 Gaofen-1 宽视域传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-2 全色/多光谱 (PMS)—将使用 Gaofen-2 全色多光谱传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>GF-4 全色或多光谱影像 (PMI)—将使用 Gaofen-4 全色和多光谱波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>HJ 1A 或 1B 多光谱或高光谱—将使用 Huan Jing-1 CCD 多光谱或高光谱传感器波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>IKONOS—将使用 IKONOS 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Jilin-1—将使用 Jilin-1 波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>KOMPSAT-2—将使用 KOMPSAT-2 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>KOMPSAT-3—将使用 KOMPSAT-3 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Landsat TM 和 ETM+—将使用 Landsat 5 和 7 的 TM 和 ETM+ 传感器的波长范围创建 6 波段镶嵌数据集。</para>
		/// <para>Landsat OLI—将使用 LANDSAT 8 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>Landsat 9—将使用 LANDSAT 9 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>Landsat MSS—将使用 MSS 传感器的 Landsat 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Pleiades 1—将使用 PLEIADES-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>Pleiades Neo—将使用 Pleiades Neo 波长范围创建 6 波段镶嵌数据集。</para>
		/// <para>QuickBird—将使用 QuickBird 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>RapidEye—将使用 RapidEye 波长范围创建 5 波段镶嵌数据集。</para>
		/// <para>Sentinel 2 MSI—将使用 Sentinel 2 MSI 波长范围创建 13 波段镶嵌数据集。</para>
		/// <para>SkySat-C—将使用 SkySat-C MSI 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>SPOT-5—将使用 SPOT-5 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>SPOT-6—将使用 SPOT-6 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>SPOT-7—将使用 SPOT-7 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>SuperView-1—将使用 SuperView-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>TH-01—将使用 Tian Hui-1 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>WorldView-2—将使用 WorldView-2 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>WorldView-3—将使用 WorldView-3 波长范围创建 8 波段镶嵌数据集。</para>
		/// <para>WorldView-4—将使用 WorldView-4 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>ZY-1 全色/多光谱—将使用 ZiYuan-1 全色或多光谱波长范围创建 3 波段镶嵌数据集。</para>
		/// <para>ZY-3 CRESDA—将使用 ZiYuan-3 CRESDA 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>ZY3 SASMAC—将使用 ZiYuan-3 SASMAC 波长范围创建 4 波段镶嵌数据集。</para>
		/// <para>自定义—使用产品波段定义参数（Python 中的 product_band_definitions）定义波段数和每个波段的平均波长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ProductDefinition { get; set; } = "NONE";

		/// <summary>
		/// <para>Product Band Definitions</para>
		/// <para>波段的定义。 通过调整波长范围、更改波段顺序和添加新波段来编辑产品定义。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Product Properties")]
		public object? ProductBandDefinitions { get; set; }

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEMosaicDataset()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateMosaicDataset SetEnviroment(object? configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

	}
}
