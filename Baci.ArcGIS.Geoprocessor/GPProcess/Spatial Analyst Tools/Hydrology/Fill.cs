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
	/// <para>Fill</para>
	/// <para>填洼</para>
	/// <para>通过填充表面栅格中的凹陷点来移除数据中的小缺陷。</para>
	/// </summary>
	public class Fill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续的表面。</para>
		/// </param>
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>已填充凹陷点的输出表面栅格。</para>
		/// <para>如果表面栅格数据为整型，则输出已填充栅格数据也为整型。如果输入栅格数据为浮点型，则输出栅格数据也为浮点型。</para>
		/// </param>
		public Fill(object InSurfaceRaster, object OutSurfaceRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutSurfaceRaster = OutSurfaceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 填洼</para>
		/// </summary>
		public override string DisplayName() => "填洼";

		/// <summary>
		/// <para>Tool Name : 填洼</para>
		/// </summary>
		public override string ToolName() => "填洼";

		/// <summary>
		/// <para>Tool Excute Name : sa.Fill</para>
		/// </summary>
		public override string ExcuteName() => "sa.Fill";

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
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutSurfaceRaster, ZLimit };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>已填充凹陷点的输出表面栅格。</para>
		/// <para>如果表面栅格数据为整型，则输出已填充栅格数据也为整型。如果输入栅格数据为浮点型，则输出栅格数据也为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Z limit</para>
		/// <para>要填充的凹陷点与其倾泻点之间的最大高程差。</para>
		/// <para>如果凹陷点与其倾泻点之间的 z 值差大于 z 限制，则不会填充此凹陷点。</para>
		/// <para>Z 限制值必须大于零。</para>
		/// <para>除非已指定该参数的值，否则将填充所有凹陷点（不考虑深度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ZLimit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Fill SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
