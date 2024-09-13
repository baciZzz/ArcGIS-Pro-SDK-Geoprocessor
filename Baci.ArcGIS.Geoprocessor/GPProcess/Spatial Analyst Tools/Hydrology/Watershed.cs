using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Watershed</para>
	/// <para>集水区</para>
	/// <para>确定栅格中一组像元之上的汇流区域。</para>
	/// </summary>
	public class Watershed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input D8 flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以在流向工具中，运行使用默认流向类型 D8 来创建流向栅格。</para>
		/// </param>
		/// <param name="InPourPointData">
		/// <para>Input raster or feature pour point data</para>
		/// <para>输入倾泻点位置。</para>
		/// <para>对于栅格，输入倾泻点位置表示将确定的汇流区域或集水区之上的像元。所有非 NoData 的像元都将用作源像元。</para>
		/// <para>对于点要素数据集，输入倾泻点位置表示将确定的汇流区域或集水区之上的位置。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>显示汇流区域的输出栅格。</para>
		/// <para>输出为整型。</para>
		/// </param>
		public Watershed(object InFlowDirectionRaster, object InPourPointData, object OutRaster)
		{
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.InPourPointData = InPourPointData;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 集水区</para>
		/// </summary>
		public override string DisplayName() => "集水区";

		/// <summary>
		/// <para>Tool Name : 集水区</para>
		/// </summary>
		public override string ToolName() => "集水区";

		/// <summary>
		/// <para>Tool Excute Name : sa.Watershed</para>
		/// </summary>
		public override string ExcuteName() => "sa.Watershed";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFlowDirectionRaster, InPourPointData, OutRaster, PourPointField! };

		/// <summary>
		/// <para>Input D8 flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以在流向工具中，运行使用默认流向类型 D8 来创建流向栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Input raster or feature pour point data</para>
		/// <para>输入倾泻点位置。</para>
		/// <para>对于栅格，输入倾泻点位置表示将确定的汇流区域或集水区之上的像元。所有非 NoData 的像元都将用作源像元。</para>
		/// <para>对于点要素数据集，输入倾泻点位置表示将确定的汇流区域或集水区之上的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polyline", "Multipoint")]
		public object InPourPointData { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>显示汇流区域的输出栅格。</para>
		/// <para>输出为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Pour point field</para>
		/// <para>用于为倾泻点位置赋值的字段。</para>
		/// <para>如果倾泻点数据集为栅格，则使用 Value。</para>
		/// <para>如果倾泻点数据集为要素，则使用数值字段。 如果字段包含浮点型值，它们将被截断为整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? PourPointField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Watershed SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
