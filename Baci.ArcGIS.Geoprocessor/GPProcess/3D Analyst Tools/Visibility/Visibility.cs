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
	/// <para>Visibility</para>
	/// <para>可见性</para>
	/// <para>确定对一组观察点要素可见的栅格表面位置，或识别从各栅格表面位置进行观察时可见的观察点。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.Analyst3DTools.Viewshed2"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.Analyst3DTools.Viewshed2))]
	public class Visibility : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="InObserverFeatures">
		/// <para>Input point or polyline observer features</para>
		/// <para>用于识别观察点位置的要素类。</para>
		/// <para>输入可以是点要素或折线 (polyline) 要素。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出将记录输入表面栅格中每个像元位置对于输入观测位置可见的次数（频数分析类型），或记录栅格表面中每个像元可见的观察点位置（观察点类型选项）。</para>
		/// </param>
		public Visibility(object InRaster, object InObserverFeatures, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InObserverFeatures = InObserverFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 可见性</para>
		/// </summary>
		public override string DisplayName() => "可见性";

		/// <summary>
		/// <para>Tool Name : 可见性</para>
		/// </summary>
		public override string ToolName() => "可见性";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Visibility</para>
		/// </summary>
		public override string ExcuteName() => "3d.Visibility";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InObserverFeatures, OutRaster, OutAglRaster!, AnalysisType!, NonvisibleCellValue!, ZFactor!, CurvatureCorrection!, RefractivityCoefficient!, SurfaceOffset!, ObserverElevation!, ObserverOffset!, InnerRadius!, OuterRadius!, HorizontalStartAngle!, HorizontalEndAngle!, VerticalUpperAngle!, VerticalLowerAngle! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input point or polyline observer features</para>
		/// <para>用于识别观察点位置的要素类。</para>
		/// <para>输入可以是点要素或折线 (polyline) 要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Multipoint", "Polyline")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出将记录输入表面栅格中每个像元位置对于输入观测位置可见的次数（频数分析类型），或记录栅格表面中每个像元可见的观察点位置（观察点类型选项）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output above ground level raster</para>
		/// <para>地表以上 (AGL) 输出栅格。</para>
		/// <para>AGL 结果是一个栅格，其中每个像元值都记录了为保证像元至少对一个观察点可见而需要向该像元添加的最小高度（若不添加此高度，像元不可见）。</para>
		/// <para>在输出栅格中已可见像元的值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutAglRaster { get; set; }

		/// <summary>
		/// <para>Analysis type</para>
		/// <para>可见性分析类型。</para>
		/// <para>频数—输出将记录输入表面栅格中每个像元位置对于输入观测位置（如点或观察折线要素的折点）可见的次数。 这是默认设置。</para>
		/// <para>观察点—输出将精确识别从各栅格表面位置进行观察时可见的观察点。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AnalysisType { get; set; } = "FREQUENCY";

		/// <summary>
		/// <para>Use NoData for non-visible cells</para>
		/// <para>分配到不可见像元的值。</para>
		/// <para>未选中 - 将 0 分配到不可见像元。 这是默认设置。</para>
		/// <para>选中 - 将 NoData 分配到不可见像元。</para>
		/// <para><see cref="NonvisibleCellValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NonvisibleCellValue { get; set; } = "false";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>一个表面 z 单位中地面 x,y 单位的数量。</para>
		/// <para>z 单位与输入表面的 x,y 单位不同时，可使用 z 因子调整 z 单位的测量单位。 计算最终输出表面时，将用 z 因子乘以输入表面的 z 值。</para>
		/// <para>如果 x,y 单位和 z 单位采用相同的测量单位，则 z 因子为 1。 这是默认设置。</para>
		/// <para>如果 x,y 单位和 z 单位采用不同的测量单位，则必须将 z 因子设置为适当的因子，否则会得到错误的结果。 例如，如果 z 单位是英尺而 x,y 单位是米，则应使用 z 因子 0.3048 将 z 单位从英尺转换为米（1 英尺 = 0.3048 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// <para>指定是否将应用地球曲率校正。</para>
		/// <para>未选中 - 不应用任何曲率校正。 这是默认设置。</para>
		/// <para>选中 - 应用曲率校正。</para>
		/// <para><see cref="CurvatureCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CurvatureCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Refractivity coefficient</para>
		/// <para>空气中可见光的折射系数。</para>
		/// <para>默认值为 0.13。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? RefractivityCoefficient { get; set; } = "0.13";

		/// <summary>
		/// <para>Surface offset</para>
		/// <para>要添加到各像元 z 值的垂直距离，因为分析可见性时需要考虑该距离。 它必须为正整数值或浮点值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 OFFSETB 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? SurfaceOffset { get; set; }

		/// <summary>
		/// <para>Observer elevation</para>
		/// <para>观察点或折点的表面高程。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 SPOT 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则可通过双线性插值法使用观察点位置相邻像元的表面高程值对其进行估算。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? ObserverElevation { get; set; }

		/// <summary>
		/// <para>Observer offset</para>
		/// <para>要添加到观察点高程的垂直距离。 它必须为正整数值或浮点值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 OFFSETA 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? ObserverOffset { get; set; }

		/// <summary>
		/// <para>Inner radius</para>
		/// <para>确定可见性的起始距离。 小于此距离的像元在输出中不可见，但仍会妨碍内半径和外半径之间像元的可见性。</para>
		/// <para>它应为正/负整数值或浮点值。 若为正值，则将解释为三维视线距离。 若为负值，则将解释为二维平面距离。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 RADIUS1 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? InnerRadius { get; set; }

		/// <summary>
		/// <para>Outer radius</para>
		/// <para>确定可见性的最大距离。 超出此距离的像元将从分析中排除。</para>
		/// <para>它应为正/负整数值或浮点值。 若为正值，则将解释为三维视线距离。 若为负值，则将解释为二维平面距离。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 RADIUS2 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为无穷大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? OuterRadius { get; set; }

		/// <summary>
		/// <para>Horizontal start angle</para>
		/// <para>水平扫描范围的起始角度。 该值应以度为单位，介于 0 至 360 之间，可为整数或浮点数，其中 0 指向北。 默认值为 0。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 AZIMUTH1 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? HorizontalStartAngle { get; set; }

		/// <summary>
		/// <para>Horizontal end angle</para>
		/// <para>水平扫描范围的终止角度。 该值应以度为单位，介于 0 至 360 之间，可为整数或浮点数，其中 0 指向北。 默认值为 360。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 AZIMUTH2 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 360。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? HorizontalEndAngle { get; set; }

		/// <summary>
		/// <para>Vertical upper angle</para>
		/// <para>扫描的（相对于水平面的）垂直角上限。 该值以度为单位，且可为整数或浮点数。 允许的范围为 -90 到（并包括） 90。</para>
		/// <para>此参数值必须大于垂直下角参数值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 VERT1 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 90。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? VerticalUpperAngle { get; set; }

		/// <summary>
		/// <para>Vertical lower angle</para>
		/// <para>扫描的（位于水平面下的）垂直角上限。 该值以度为单位，且可为整数或浮点数。 允许的范围是从 -90 到（但不包括）90。</para>
		/// <para>此参数值必须小于垂直上角参数值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>默认情况下，若输入观察点要素属性表中存在 VERT2 数值字段，将使用该字段。 可通过指定其他数值字段或值将其覆盖。</para>
		/// <para>若未指定此参数且输入观察点要素属性表中不存在默认字段，则其默认为 -90。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? VerticalLowerAngle { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Visibility SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Analysis type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>频数—输出将记录输入表面栅格中每个像元位置对于输入观测位置（如点或观察折线要素的折点）可见的次数。 这是默认设置。</para>
			/// </summary>
			[GPValue("FREQUENCY")]
			[Description("频数")]
			Frequency,

			/// <summary>
			/// <para>观察点—输出将精确识别从各栅格表面位置进行观察时可见的观察点。</para>
			/// </summary>
			[GPValue("OBSERVERS")]
			[Description("观察点")]
			Observers,

		}

		/// <summary>
		/// <para>Use NoData for non-visible cells</para>
		/// </summary>
		public enum NonvisibleCellValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ZERO")]
			ZERO,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// </summary>
		public enum CurvatureCorrectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FLAT_EARTH")]
			FLAT_EARTH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVED_EARTH")]
			CURVED_EARTH,

		}

#endregion
	}
}
