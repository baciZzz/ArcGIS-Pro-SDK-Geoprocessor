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
	/// <para>Multipatch to Raster</para>
	/// <para>多面体转栅格</para>
	/// <para>将多面体要素转换为栅格数据集。</para>
	/// </summary>
	public class MultipatchToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultipatchFeatures">
		/// <para>Input multipatch features</para>
		/// <para>要转换为栅格的输入多面体要素。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>此栅格为浮点类型。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </param>
		public MultipatchToRaster(object InMultipatchFeatures, object OutRaster)
		{
			this.InMultipatchFeatures = InMultipatchFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 多面体转栅格</para>
		/// </summary>
		public override string DisplayName() => "多面体转栅格";

		/// <summary>
		/// <para>Tool Name : MultipatchToRaster</para>
		/// </summary>
		public override string ToolName() => "MultipatchToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MultipatchToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.MultipatchToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultipatchFeatures, OutRaster, CellSize!, CellAssignmentMethod! };

		/// <summary>
		/// <para>Input multipatch features</para>
		/// <para>要转换为栅格的输入多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[GeometryType("MultiPatch")]
		public object InMultipatchFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>此栅格为浮点类型。</para>
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
		/// <para>Cell assignment method</para>
		/// <para>指定在从像元中心位置延伸一条垂直线与输入多面体要素相交的情况下，当在像元中心位置检测到多个 z 值时，是否将最大或最小 z 值用于像元。</para>
		/// <para>最大高度—将最大 z 值分配到像元。 这是默认设置。</para>
		/// <para>最小高度—将最小 z 值分配到像元。</para>
		/// <para><see cref="CellAssignmentMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CellAssignmentMethod { get; set; } = "MAXIMUM_HEIGHT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultipatchToRaster SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell assignment method</para>
		/// </summary>
		public enum CellAssignmentMethodEnum 
		{
			/// <summary>
			/// <para>最大高度—将最大 z 值分配到像元。 这是默认设置。</para>
			/// </summary>
			[GPValue("MAXIMUM_HEIGHT")]
			[Description("最大高度")]
			Maximum_height,

			/// <summary>
			/// <para>最小高度—将最小 z 值分配到像元。</para>
			/// </summary>
			[GPValue("MINIMUM_HEIGHT")]
			[Description("最小高度")]
			Minimum_height,

		}

#endregion
	}
}
