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
	/// <para>Extract by Mask</para>
	/// <para>按掩膜提取</para>
	/// <para>提取掩膜所定义区域内的相应栅格像元。</para>
	/// </summary>
	public class ExtractByMask : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>提取像元的输入栅格。</para>
		/// </param>
		/// <param name="InMaskData">
		/// <para>Input raster or feature mask data</para>
		/// <para>用于定义提取区域的输入掩膜数据。</para>
		/// <para>它可以是栅格，也可以是要素数据集。</para>
		/// <para>当输入掩膜数据为栅格时，将在输出栅格中为掩膜数据中的 NoData 像元指定 NoData 值。</para>
		/// <para>当输入掩膜是要素数据时，如果输入栅格中像元的中心位于要素周长范围内，则会在输出中包含这些像元，而其中心落在要素周长之外的像元将会收到 NoData。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </param>
		public ExtractByMask(object InRaster, object InMaskData, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InMaskData = InMaskData;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 按掩膜提取</para>
		/// </summary>
		public override string DisplayName() => "按掩膜提取";

		/// <summary>
		/// <para>Tool Name : ExtractByMask</para>
		/// </summary>
		public override string ToolName() => "ExtractByMask";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByMask</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByMask";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InMaskData, OutRaster };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>提取像元的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input raster or feature mask data</para>
		/// <para>用于定义提取区域的输入掩膜数据。</para>
		/// <para>它可以是栅格，也可以是要素数据集。</para>
		/// <para>当输入掩膜数据为栅格时，将在输出栅格中为掩膜数据中的 NoData 像元指定 NoData 值。</para>
		/// <para>当输入掩膜是要素数据时，如果输入栅格中像元的中心位于要素周长范围内，则会在输出中包含这些像元，而其中心落在要素周长之外的像元将会收到 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InMaskData { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByMask SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
