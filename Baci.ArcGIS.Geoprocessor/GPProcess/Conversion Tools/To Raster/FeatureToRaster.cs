using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Feature to Raster</para>
	/// <para>要素转栅格</para>
	/// <para>将要素转换为栅格数据集。</para>
	/// </summary>
	public class FeatureToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>要转换为栅格数据集的输入要素数据集。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>用于向输出栅格分配值的字段。</para>
		/// <para>可以是输入要素数据集属性表中的任何字段。</para>
		/// <para>如果点数据集或多点数据集的 Shape 字段含有 z 值或 m 值，则可以使用二者中的任意一个。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </param>
		public FeatureToRaster(object InFeatures, object Field, object OutRaster)
		{
			this.InFeatures = InFeatures;
			this.Field = Field;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转栅格</para>
		/// </summary>
		public override string DisplayName() => "要素转栅格";

		/// <summary>
		/// <para>Tool Name : FeatureToRaster</para>
		/// </summary>
		public override string ToolName() => "FeatureToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeatureToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeatureToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Field, OutRaster, CellSize! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>要转换为栅格数据集的输入要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>用于向输出栅格分配值的字段。</para>
		/// <para>可以是输入要素数据集属性表中的任何字段。</para>
		/// <para>如果点数据集或多点数据集的 Shape 字段含有 z 值或 m 值，则可以使用二者中的任意一个。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Geometry", "OID")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>正在创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。有关详细信息，请参阅“用法”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureToRaster SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? pyramid = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
