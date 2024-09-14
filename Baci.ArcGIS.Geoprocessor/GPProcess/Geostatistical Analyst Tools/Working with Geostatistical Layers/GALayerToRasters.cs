using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>GA Layer To Rasters</para>
	/// <para>GA 图层转栅格</para>
	/// <para>将地统计图层导出为一个或多个栅格。</para>
	/// </summary>
	public class GALayerToRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>要创建的主要输出栅格。其他栅格可以通过附加输出栅格参数进行创建。</para>
		/// </param>
		public GALayerToRasters(object InGeostatLayer, object OutRaster)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : GA 图层转栅格</para>
		/// </summary>
		public override string DisplayName() => "GA 图层转栅格";

		/// <summary>
		/// <para>Tool Name : GALayerToRasters</para>
		/// </summary>
		public override string ToolName() => "GALayerToRasters";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToRasters</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayerToRasters";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, OutRaster, OutputType!, QuantileProbabilityValue!, CellSize!, PointsPerBlockHorz!, PointsPerBlockVert!, AdditionalRasters!, OutAdditionalRasters!, OutElevation! };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>要创建的主要输出栅格。其他栅格可以通过附加输出栅格参数进行创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Surface Type</para>
		/// <para>输出栅格的表面类型。</para>
		/// <para>有关详细信息，请参阅插值模型可以生成何种类型的输出表面？</para>
		/// <para>预测—预测值的栅格。</para>
		/// <para>预测标准误差—预测标准误差的栅格。</para>
		/// <para>概率—用于预测超出阈值的概率的栅格。</para>
		/// <para>分位数—用于预测预测值分位数的栅格。</para>
		/// <para>标准误差指示图—指示器标准误差的栅格。</para>
		/// <para>条件数—用于显示局部多项式插值法中预测条件数的栅格。条件数表面表示在特定位置计算的稳定性。条件数越大，预测越不稳定，所以条件数较大的位置更容易出现伪影和不稳定的预测值。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile or probability value</para>
		/// <para>如果输出表面类型设置为分位数，则使用此参数输入请求的分位数。如果输出表面类型设置为概率，则使用此参数输入请求的阈值，然后即可计算超出此阈值的概率。</para>
		/// <para>如果输入地统计图层是通过未超出地图选项创建的指示器概率图或标准误差图，则将计算不超出阈值的概率。该功能适用于此工具的所有概率栅格输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		public object? QuantileProbabilityValue { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>输出栅格的像元大小。该值将由输出栅格和附加输出栅格参数共享。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Number of points in the cell (horizontal)</para>
		/// <para>针对水平方向上的各像元用于分块内插的预测数。 默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object? PointsPerBlockHorz { get; set; } = "1";

		/// <summary>
		/// <para>Number of points in the cell (vertical)</para>
		/// <para>针对垂直方向上的各像元用于分块内插的预测数。 默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object? PointsPerBlockVert { get; set; } = "1";

		/// <summary>
		/// <para>Additional output rasters</para>
		/// <para>用于为每一个附加输出栅格提供名称、输出类型及分位数或概率值。有关详细信息，请参阅上述参数的描述。这些附加栅格将与输出栅格保存在同一位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AdditionalRasters { get; set; }

		/// <summary>
		/// <para>Additional rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutAdditionalRasters { get; set; }

		/// <summary>
		/// <para>Output elevation</para>
		/// <para>对于 3D 插值模型，可以导出任何高程处的栅格。可以使用此参数来指定要导出的高程。如果留空，则将从输入图层继承高程。单位将默认为输入图层的相同单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? OutElevation { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToRasters SetEnviroment(object? cellSize = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Surface Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>预测—预测值的栅格。</para>
			/// </summary>
			[GPValue("PREDICTION")]
			[Description("预测")]
			Prediction,

			/// <summary>
			/// <para>预测标准误差—预测标准误差的栅格。</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("预测标准误差")]
			Prediction_standard_error,

			/// <summary>
			/// <para>概率—用于预测超出阈值的概率的栅格。</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("概率")]
			Probability,

			/// <summary>
			/// <para>分位数—用于预测预测值分位数的栅格。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

			/// <summary>
			/// <para>条件数—用于显示局部多项式插值法中预测条件数的栅格。条件数表面表示在特定位置计算的稳定性。条件数越大，预测越不稳定，所以条件数较大的位置更容易出现伪影和不稳定的预测值。</para>
			/// </summary>
			[GPValue("CONDITION_NUMBER")]
			[Description("条件数")]
			Condition_number,

			/// <summary>
			/// <para>标准误差指示图—指示器标准误差的栅格。</para>
			/// </summary>
			[GPValue("STANDARD_ERROR_INDICATORS")]
			[Description("标准误差指示图")]
			Standard_error_of_indicators,

		}

#endregion
	}
}
