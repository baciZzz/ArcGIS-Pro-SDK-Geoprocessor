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
	/// <para>Spline</para>
	/// <para>样条</para>
	/// <para>使用二维最小曲率样条法将点插值成栅格表面。</para>
	/// </summary>
	public class Spline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入点要素。</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>存放每个点的高度值或量级值的字段。</para>
		/// <para>如果输入点要素包含 z 值，则该字段可以是数值型字段或者 Shape 字段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		public Spline(object InPointFeatures, object ZField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 样条</para>
		/// </summary>
		public override string DisplayName() => "样条";

		/// <summary>
		/// <para>Tool Name : 样条</para>
		/// </summary>
		public override string ToolName() => "样条";

		/// <summary>
		/// <para>Tool Excute Name : sa.Spline</para>
		/// </summary>
		public override string ExcuteName() => "sa.Spline";

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
		public override object[] Parameters() => new object[] { InPointFeatures, ZField, OutRaster, CellSize, SplineType, Weight, NumberPoints };

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
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>存放每个点的高度值或量级值的字段。</para>
		/// <para>如果输入点要素包含 z 值，则该字段可以是数值型字段或者 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Spline type</para>
		/// <para>要使用的样条函数法类型。</para>
		/// <para>正则化—产生平滑的表面和平滑的一阶导数。</para>
		/// <para>张力—根据建模现象的特征调整插值的硬度。</para>
		/// <para><see cref="SplineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplineType { get; set; } = "REGULARIZED";

		/// <summary>
		/// <para>Weight</para>
		/// <para>影响表面插值特征的参数。</para>
		/// <para>使用规则样条函数选项时，它定义曲率最小化表达式中表面的三阶导数的权重。如果使用张力样条函数选项，它将定义张力的权重。</para>
		/// <para>默认权重为 0.1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Weight { get; set; } = "0.1";

		/// <summary>
		/// <para>Number of points</para>
		/// <para>用于局部近似的每个区域的点数。</para>
		/// <para>默认值为 12。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberPoints { get; set; } = "12";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Spline SetEnviroment(int? autoCommit = null, object cellSize = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spline type</para>
		/// </summary>
		public enum SplineTypeEnum 
		{
			/// <summary>
			/// <para>正则化—产生平滑的表面和平滑的一阶导数。</para>
			/// </summary>
			[GPValue("REGULARIZED")]
			[Description("正则化")]
			Regularized,

			/// <summary>
			/// <para>张力—根据建模现象的特征调整插值的硬度。</para>
			/// </summary>
			[GPValue("TENSION")]
			[Description("张力")]
			Tension,

		}

#endregion
	}
}
