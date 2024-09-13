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
	/// <para>Focal Flow</para>
	/// <para>焦点流</para>
	/// <para>确定输入栅格中每个像元的直接邻域内值的流量。</para>
	/// </summary>
	public class FocalFlow : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>要计算焦点流的输入表面栅格数据。</para>
		/// <para>可评估每个像元的八个直接邻域来确定流量。</para>
		/// <para>输入栅格数据可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出焦点流栅格。</para>
		/// <para>输出栅格始终为整型。</para>
		/// </param>
		public FocalFlow(object InSurfaceRaster, object OutRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 焦点流</para>
		/// </summary>
		public override string DisplayName() => "焦点流";

		/// <summary>
		/// <para>Tool Name : FocalFlow</para>
		/// </summary>
		public override string ToolName() => "FocalFlow";

		/// <summary>
		/// <para>Tool Excute Name : sa.FocalFlow</para>
		/// </summary>
		public override string ExcuteName() => "sa.FocalFlow";

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
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutRaster, ThresholdValue };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>要计算焦点流的输入表面栅格数据。</para>
		/// <para>可评估每个像元的八个直接邻域来确定流量。</para>
		/// <para>输入栅格数据可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出焦点流栅格。</para>
		/// <para>输出栅格始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Threshold value</para>
		/// <para>定义构成阈值的值（必须先等于或超过该值，然后才能出现流）。</para>
		/// <para>阈值可以是整型或浮点型值。</para>
		/// <para>如果相邻像元位置上的值与待处理像元的值之差小于或等于阈值，则输出将为 0（或无流量）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object ThresholdValue { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FocalFlow SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
