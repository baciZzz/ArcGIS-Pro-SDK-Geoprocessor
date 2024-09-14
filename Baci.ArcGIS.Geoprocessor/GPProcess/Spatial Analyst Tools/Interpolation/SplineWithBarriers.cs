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
	/// <para>Spline with Barriers</para>
	/// <para>含障碍的样条函数</para>
	/// <para>通过最小曲率样条法利用障碍将点插值成栅格表面。障碍以面要素或折线要素的形式输入。</para>
	/// </summary>
	public class SplineWithBarriers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input point features</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入点要素。</para>
		/// </param>
		/// <param name="ZValueField">
		/// <para>Z value field</para>
		/// <para>存放每个点的高度值或量级值的字段。</para>
		/// <para>如果输入点要素包含 z 值，则该字段可以是数值型字段或者 Shape 字段。</para>
		/// </param>
		/// <param name="OutputRaster">
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		public SplineWithBarriers(object InputPointFeatures, object ZValueField, object OutputRaster)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.ZValueField = ZValueField;
			this.OutputRaster = OutputRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 含障碍的样条函数</para>
		/// </summary>
		public override string DisplayName() => "含障碍的样条函数";

		/// <summary>
		/// <para>Tool Name : SplineWithBarriers</para>
		/// </summary>
		public override string ToolName() => "SplineWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : sa.SplineWithBarriers</para>
		/// </summary>
		public override string ExcuteName() => "sa.SplineWithBarriers";

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
		public override object[] Parameters() => new object[] { InputPointFeatures, ZValueField, InputBarrierFeatures, OutputCellSize, OutputRaster, SmoothingFactor };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>存放每个点的高度值或量级值的字段。</para>
		/// <para>如果输入点要素包含 z 值，则该字段可以是数值型字段或者 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object ZValueField { get; set; }

		/// <summary>
		/// <para>Input barrier features</para>
		/// <para>用于约束插值的可选输入障碍要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Polyline", "Polygon")]
		public object InputBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object OutputCellSize { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Smoothing Factor</para>
		/// <para>影响输出表面的平滑的参数。</para>
		/// <para>当值为零时不会应用任何平滑，当因子等于 1 时将应用最大平滑量。</para>
		/// <para>默认值为 0.0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object SmoothingFactor { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplineWithBarriers SetEnviroment(int? autoCommit = null, object cellSize = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
