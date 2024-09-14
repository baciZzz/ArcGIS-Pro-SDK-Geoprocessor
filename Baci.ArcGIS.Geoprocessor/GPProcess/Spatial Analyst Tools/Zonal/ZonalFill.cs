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
	/// <para>Zonal Fill</para>
	/// <para>区域填充</para>
	/// <para>使用权重栅格数据沿区域边界的最小像元值填充区域。</para>
	/// </summary>
	public class ZonalFill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneRaster">
		/// <para>Input zone raster</para>
		/// <para>定义待填充区域的输入栅格。</para>
		/// </param>
		/// <param name="InWeightRaster">
		/// <para>Input weight raster</para>
		/// <para>要分配至各个区域的权重或值。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>已对区域完成填充的输出栅格。</para>
		/// </param>
		public ZonalFill(object InZoneRaster, object InWeightRaster, object OutRaster)
		{
			this.InZoneRaster = InZoneRaster;
			this.InWeightRaster = InWeightRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 区域填充</para>
		/// </summary>
		public override string DisplayName() => "区域填充";

		/// <summary>
		/// <para>Tool Name : ZonalFill</para>
		/// </summary>
		public override string ToolName() => "ZonalFill";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalFill</para>
		/// </summary>
		public override string ExcuteName() => "sa.ZonalFill";

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
		public override object[] Parameters() => new object[] { InZoneRaster, InWeightRaster, OutRaster };

		/// <summary>
		/// <para>Input zone raster</para>
		/// <para>定义待填充区域的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InZoneRaster { get; set; }

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>要分配至各个区域的权重或值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>已对区域完成填充的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalFill SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
