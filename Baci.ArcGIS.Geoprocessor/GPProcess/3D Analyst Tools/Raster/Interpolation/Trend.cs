using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Trend</para>
	/// <para>趋势面法</para>
	/// <para>使用趋势面法将点插值成栅格表面。</para>
	/// </summary>
	public class Trend : AbstractGPProcess
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
		/// <para>如果回归类型为 Logistic，则该字段的值只能为 0 或 1。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		public Trend(object InPointFeatures, object ZField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 趋势面法</para>
		/// </summary>
		public override string DisplayName() => "趋势面法";

		/// <summary>
		/// <para>Tool Name : 趋势面法</para>
		/// </summary>
		public override string ToolName() => "趋势面法";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Trend</para>
		/// </summary>
		public override string ExcuteName() => "3d.Trend";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, ZField, OutRaster, CellSize, Order, RegressionType, OutRmsFile };

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
		/// <para>如果回归类型为 Logistic，则该字段的值只能为 0 或 1。</para>
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
		/// <para>Polynomial order</para>
		/// <para>多项式的阶。</para>
		/// <para>该值必须是介于 1 到 12 之间的整数。值为 1 会对点进行平面拟合，而较高的值则会拟合出更为复杂的曲面。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 12)]
		public object Order { get; set; } = "1";

		/// <summary>
		/// <para>Type of regression</para>
		/// <para>要执行的回归类型。</para>
		/// <para>线性—执行多项式回归，对输入点进行最小二乘曲面拟合。这种类型适用于连续型数据。</para>
		/// <para>逻辑—执行逻辑趋势面分析。为二元数据生成连续的概率曲面。</para>
		/// <para><see cref="RegressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RegressionType { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Output RMS file</para>
		/// <para>包含插值的 RMS 误差和卡方相关信息的输出文本文件的文件名。</para>
		/// <para>扩展名必须为 .txt。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT")]
		public object OutRmsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Trend SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type of regression</para>
		/// </summary>
		public enum RegressionTypeEnum 
		{
			/// <summary>
			/// <para>线性—执行多项式回归，对输入点进行最小二乘曲面拟合。这种类型适用于连续型数据。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>逻辑—执行逻辑趋势面分析。为二元数据生成连续的概率曲面。</para>
			/// </summary>
			[GPValue("LOGISTIC")]
			[Description("逻辑")]
			Logistic,

		}

#endregion
	}
}
