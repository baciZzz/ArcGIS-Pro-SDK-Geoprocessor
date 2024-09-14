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
	/// <para>Make Raster Layer</para>
	/// <para>创建栅格图层</para>
	/// <para>根据输入栅格数据集或图层文件创建栅格图层。该工具创建的图层是临时图层，如果不将此图层保存到磁盘或保存地图文档，该图层在会话结束后将不会继续存在。</para>
	/// </summary>
	public class MakeRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入栅格数据集的路径和名称。</para>
		/// <para>可将 GeoPackage 中的栅格图层用作输入。要参考 GeoPackage 中的栅格，请输入路径名，后接 GeoPackage 的名称和栅格名称。例如 c:\data\sample.gpkg\raster_tile 是输入栅格，其中 sample.gpkg 是 GeoPackage 的名称，raster_tile 是包中的栅格数据集。</para>
		/// </param>
		/// <param name="OutRasterlayer">
		/// <para>Output raster layer name</para>
		/// <para>要创建的图层的名称。</para>
		/// </param>
		public MakeRasterLayer(object InRaster, object OutRasterlayer)
		{
			this.InRaster = InRaster;
			this.OutRasterlayer = OutRasterlayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建栅格图层</para>
		/// </summary>
		public override string DisplayName() => "创建栅格图层";

		/// <summary>
		/// <para>Tool Name : MakeRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeRasterLayer";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRasterlayer, WhereClause, Envelope, BandIndex };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入栅格数据集的路径和名称。</para>
		/// <para>可将 GeoPackage 中的栅格图层用作输入。要参考 GeoPackage 中的栅格，请输入路径名，后接 GeoPackage 的名称和栅格名称。例如 c:\data\sample.gpkg\raster_tile 是输入栅格，其中 sample.gpkg 是 GeoPackage 的名称，raster_tile 是包中的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false, Guid = "{91BF8D7D-195F-4E08-8D03-D204FA3C7A13}")]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster layer name</para>
		/// <para>要创建的图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutRasterlayer { get; set; }

		/// <summary>
		/// <para>Where clause</para>
		/// <para>可以使用 SQL 定义查询，或者使用查询构建器构建查询。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Envelope</para>
		/// <para>指定输出范围的方法可以是定义四个坐标，也可以是使用现有图层的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Envelope { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>选择要为图层输出哪些波段。 如果未指定波段，则输出中将使用所有波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object BandIndex { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRasterLayer SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
