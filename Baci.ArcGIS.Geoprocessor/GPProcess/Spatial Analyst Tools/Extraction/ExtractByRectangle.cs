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
	/// <para>Extract by Rectangle</para>
	/// <para>按矩形提取</para>
	/// <para>通过指定矩形范围，基于矩形提取栅格像元。</para>
	/// </summary>
	public class ExtractByRectangle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>从中提取像元的输入栅格。</para>
		/// </param>
		/// <param name="Rectangle">
		/// <para>Extent</para>
		/// <para>用于定义待提取区域的矩形。</para>
		/// <para>如果将范围参数设置为如下面的指定，则使用通过左箭头和下箭头识别的参数定义待提取区域左下方的坐标，并使用通过右箭头和上箭头识别的参数定义右上方的坐标。</para>
		/// <para>如果将范围参数设置为浏览，则可选择将通过边界框定义范围的数据集。</para>
		/// <para>将指定坐标使用与输入栅格相同的地图单位。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </param>
		public ExtractByRectangle(object InRaster, object Rectangle, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Rectangle = Rectangle;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 按矩形提取</para>
		/// </summary>
		public override string DisplayName() => "按矩形提取";

		/// <summary>
		/// <para>Tool Name : ExtractByRectangle</para>
		/// </summary>
		public override string ToolName() => "ExtractByRectangle";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByRectangle</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByRectangle";

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
		public override object[] Parameters() => new object[] { InRaster, Rectangle, OutRaster, ExtractionArea! };

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
		/// <para>Extent</para>
		/// <para>用于定义待提取区域的矩形。</para>
		/// <para>如果将范围参数设置为如下面的指定，则使用通过左箭头和下箭头识别的参数定义待提取区域左下方的坐标，并使用通过右箭头和上箭头识别的参数定义右上方的坐标。</para>
		/// <para>如果将范围参数设置为浏览，则可选择将通过边界框定义范围的数据集。</para>
		/// <para>将指定坐标使用与输入栅格相同的地图单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPExtent()]
		public object Rectangle { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>指定是选择输入矩形内部还是外部的像元并将其写入输出栅格。</para>
		/// <para>内部—将选择输入矩形内部的像元并将其写入输出栅格。 矩形区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
		/// <para>外部—将选择输入矩形外部的像元并将其写入输出栅格。 矩形区域内部的所有像元都将在输出栅格中获得 NoData 值。</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByRectangle SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extraction area</para>
		/// </summary>
		public enum ExtractionAreaEnum 
		{
			/// <summary>
			/// <para>内部—将选择输入矩形内部的像元并将其写入输出栅格。 矩形区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—将选择输入矩形外部的像元并将其写入输出栅格。 矩形区域内部的所有像元都将在输出栅格中获得 NoData 值。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

#endregion
	}
}
