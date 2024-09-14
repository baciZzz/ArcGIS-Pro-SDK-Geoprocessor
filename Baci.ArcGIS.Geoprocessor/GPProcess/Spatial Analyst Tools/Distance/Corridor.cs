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
	/// <para>Corridor</para>
	/// <para>廊道分析</para>
	/// <para>计算两个输入累积成本栅格的累积成本总和。</para>
	/// </summary>
	public class Corridor : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDistanceRaster1">
		/// <para>Input cost distance raster 1</para>
		/// <para>第一个输入距离栅格。</para>
		/// <para>它应是来自距离工具的累积成本距离输出，如成本距离或路径距离。</para>
		/// </param>
		/// <param name="InDistanceRaster2">
		/// <para>Input cost distance raster 2</para>
		/// <para>第二个输入距离栅格。</para>
		/// <para>它应是来自距离工具的累积成本距离输出，如成本距离或路径距离。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出廊道栅格。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </param>
		public Corridor(object InDistanceRaster1, object InDistanceRaster2, object OutRaster)
		{
			this.InDistanceRaster1 = InDistanceRaster1;
			this.InDistanceRaster2 = InDistanceRaster2;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 廊道分析</para>
		/// </summary>
		public override string DisplayName() => "廊道分析";

		/// <summary>
		/// <para>Tool Name : 廊道分析</para>
		/// </summary>
		public override string ToolName() => "廊道分析";

		/// <summary>
		/// <para>Tool Excute Name : sa.Corridor</para>
		/// </summary>
		public override string ExcuteName() => "sa.Corridor";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDistanceRaster1, InDistanceRaster2, OutRaster };

		/// <summary>
		/// <para>Input cost distance raster 1</para>
		/// <para>第一个输入距离栅格。</para>
		/// <para>它应是来自距离工具的累积成本距离输出，如成本距离或路径距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDistanceRaster1 { get; set; }

		/// <summary>
		/// <para>Input cost distance raster 2</para>
		/// <para>第二个输入距离栅格。</para>
		/// <para>它应是来自距离工具的累积成本距离输出，如成本距离或路径距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDistanceRaster2 { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出廊道栅格。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Corridor SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
