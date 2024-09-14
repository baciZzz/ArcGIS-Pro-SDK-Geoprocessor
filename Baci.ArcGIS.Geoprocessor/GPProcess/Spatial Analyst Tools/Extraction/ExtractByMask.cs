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
		/// <para>从中提取像元的输入栅格。</para>
		/// </param>
		/// <param name="InMaskData">
		/// <para>Input raster or feature mask data</para>
		/// <para>用于定义要提取的像元位置的输入掩膜数据。</para>
		/// <para>它可以是栅格，也可以是要素数据集。</para>
		/// <para>当输入掩膜数据为栅格时，将在输出栅格中为掩膜数据中的 NoData 像元指定 NoData 值。</para>
		/// <para>当输入掩膜是要素数据时，如果输入栅格中像元的中心位于要素指定形状内，则会在输出中包含这些像元，而其中心落在要素周长之外的像元将会收到 NoData。</para>
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
		public override object[] Parameters() => new object[] { InRaster, InMaskData, OutRaster, ExtractionArea!, AnalysisExtent! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>从中提取像元的输入栅格。</para>
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
		/// <para>用于定义要提取的像元位置的输入掩膜数据。</para>
		/// <para>它可以是栅格，也可以是要素数据集。</para>
		/// <para>当输入掩膜数据为栅格时，将在输出栅格中为掩膜数据中的 NoData 像元指定 NoData 值。</para>
		/// <para>当输入掩膜是要素数据时，如果输入栅格中像元的中心位于要素指定形状内，则会在输出中包含这些像元，而其中心落在要素周长之外的像元将会收到 NoData。</para>
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
		/// <para>Extraction Area</para>
		/// <para>指定是选择输入掩膜定义的位置内部还是外部的像元并将其写入输出栅格。</para>
		/// <para>内部—将选择输入掩膜内部的像元并将其写入输出栅格。 掩膜外部的所有像元都将在输出栅格中获得 NoData 值。 这是默认设置。</para>
		/// <para>外部—将选择输入掩膜外部的像元并将其写入输出栅格。 掩膜覆盖的所有像元均会获得 NoData。</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Analysis Extent</para>
		/// <para>用于定义待提取区域的范围。</para>
		/// <para>默认情况下，该范围是根据输入栅格值与输入栅格或要素掩膜数据值的交集计算得出的。 处理可能会超出 x 和 y 坐标范围，在此范围之外的像元将为 NoData。</para>
		/// <para>使用通过左箭头和下箭头识别的参数定义待提取区域左下方的坐标，并使用通过右箭头和上箭头识别的参数定义右上方的坐标。</para>
		/// <para>如果分析环境未显式设置，则将指定坐标使用与输入栅格相同的地图单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? AnalysisExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByMask SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extraction Area</para>
		/// </summary>
		public enum ExtractionAreaEnum 
		{
			/// <summary>
			/// <para>内部—将选择输入掩膜内部的像元并将其写入输出栅格。 掩膜外部的所有像元都将在输出栅格中获得 NoData 值。 这是默认设置。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—将选择输入掩膜外部的像元并将其写入输出栅格。 掩膜覆盖的所有像元均会获得 NoData。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

#endregion
	}
}
