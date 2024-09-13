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
	/// <para>Geodesic Viewshed</para>
	/// <para>测地线视域</para>
	/// <para>使用测地线方法，确定对一组观察点要素可见的栅格表面位置。</para>
	/// </summary>
	public class Viewshed2 : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入表面栅格。 它可以是整型栅格或浮点型栅格。</para>
		/// <para>可见性计算期间，输入栅格将转换为 3D 地心坐标系。 输入栅格上的 NoData 像元不会阻止可视性的确定。</para>
		/// </param>
		/// <param name="InObserverFeatures">
		/// <para>Input point or polyline observer features</para>
		/// <para>用于识别观察点位置的输入要素类。 它可以是点要素、多点要素或折线要素。</para>
		/// <para>可见性计算期间，输入要素类将转换为 3D 地心坐标系。 计算将忽略表面栅格范围之外或 NoData 像元上的观察点。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于频率分析类型，当垂直错误参数为 0 或未指定时，输出栅格将记录输入表面栅格中每个像元位置可被输入观察点看到的次数。 当垂直错误参数大于 0 时，输出栅格上的每个像元将记录该像元对所有观察点可见的可能性总和。 对于观察点分析类型，输出栅格将记录可见区域的唯一区域 ID，它们可通过输出观察点-区域关系表关联到观察点要素。</para>
		/// </param>
		public Viewshed2(object InRaster, object InObserverFeatures, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InObserverFeatures = InObserverFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 测地线视域</para>
		/// </summary>
		public override string DisplayName() => "测地线视域";

		/// <summary>
		/// <para>Tool Name : Viewshed2</para>
		/// </summary>
		public override string ToolName() => "Viewshed2";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Viewshed2</para>
		/// </summary>
		public override string ExcuteName() => "3d.Viewshed2";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InObserverFeatures, OutRaster, OutAglRaster, AnalysisType, VerticalError, OutObserverRegionRelationshipTable, RefractivityCoefficient, SurfaceOffset, ObserverElevation, ObserverOffset, InnerRadius, InnerRadiusIs3D, OuterRadius, OuterRadiusIs3D, HorizontalStartAngle, HorizontalEndAngle, VerticalUpperAngle, VerticalLowerAngle, AnalysisMethod };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入表面栅格。 它可以是整型栅格或浮点型栅格。</para>
		/// <para>可见性计算期间，输入栅格将转换为 3D 地心坐标系。 输入栅格上的 NoData 像元不会阻止可视性的确定。</para>
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
		/// <para>用于识别观察点位置的输入要素类。 它可以是点要素、多点要素或折线要素。</para>
		/// <para>可见性计算期间，输入要素类将转换为 3D 地心坐标系。 计算将忽略表面栅格范围之外或 NoData 像元上的观察点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Multipoint", "Polyline")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于频率分析类型，当垂直错误参数为 0 或未指定时，输出栅格将记录输入表面栅格中每个像元位置可被输入观察点看到的次数。 当垂直错误参数大于 0 时，输出栅格上的每个像元将记录该像元对所有观察点可见的可能性总和。 对于观察点分析类型，输出栅格将记录可见区域的唯一区域 ID，它们可通过输出观察点-区域关系表关联到观察点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output above ground level raster</para>
		/// <para>地面以上 (AGL) 输出栅格。</para>
		/// <para>AGL 结果是一个栅格，其中每个像元值都记录了为保证像元至少对一个观察点可见而需要向该像元添加的最小高度（若不添加此高度，像元不可见）。 在输出栅格中为已可见的像元分配 0。</para>
		/// <para>当垂直错误参数为 0 时，输出 AGL 栅格为单波段栅格。 当垂直错误参数大于 0 时，输出 AGL 栅格会被创建为三波段栅格以对输入栅格的随机效果作出解释。 第一波段表示 AGL 平均值，第二波段表示最小 AGL 值，第三波段表示最大 AGL 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Viewshed parameters")]
		public object OutAglRaster { get; set; }

		/// <summary>
		/// <para>Analysis type</para>
		/// <para>指定要执行的可见性分析类型，是确定每个像元对观察点的可见性，还是识别各表面位置上可见的观察点。</para>
		/// <para>频数—输出将记录输入表面栅格中每个像元位置对于输入观测位置（如点或观察折线要素的折点）可见的次数。 这是默认设置。</para>
		/// <para>观察点—输出将精确识别从各栅格表面位置进行观察时可见的观察点。 此分析类型所允许的最大输入观察点数为 32。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Viewshed parameters")]
		public object AnalysisType { get; set; } = "FREQUENCY";

		/// <summary>
		/// <para>Vertical error</para>
		/// <para>表面高程值中不确定项（均方根错误，或称 RMSE）的数量。 它是表示输入高程值预计误差的浮点值。 为此参数分配的值大于 0 时，输出可见性栅格将为浮点型。 此时，输出可见性栅格上的每个像元值将表示该像元对所有观察点可见的可能性总和。</para>
		/// <para>当分析类型为观察点或分析方法为周长视线时，此参数将处于禁用状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Viewshed parameters")]
		public object VerticalError { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Output observer-region relationship table</para>
		/// <para>用于识别对于每个观察点都可见的区域的输出表。 此表可关联到输入观察点要素类以及输出可见性栅格（用于识别对给定观察点可见的区域）。</para>
		/// <para>只有在分析类型为观察点时，才会创建此输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Viewshed parameters")]
		public object OutObserverRegionRelationshipTable { get; set; }

		/// <summary>
		/// <para>Refractivity coefficient</para>
		/// <para>空气中可见光的折射系数。</para>
		/// <para>默认值为 0.13。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		[Category("Viewshed parameters")]
		public object RefractivityCoefficient { get; set; } = "0.13";

		/// <summary>
		/// <para>Surface offset</para>
		/// <para>要添加到各像元 z 值的垂直距离，因为分析可见性时需要考虑该距离。 它必须为正整数值或浮点值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// <para>默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object SurfaceOffset { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Observer elevation</para>
		/// <para>观察点或折点的表面高程。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果未指定此参数，则会使用双线性插值法从表面栅格中获取观察点高程。 如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object ObserverElevation { get; set; }

		/// <summary>
		/// <para>Observer offset</para>
		/// <para>要添加到观察点高程的垂直距离。 它必须为正整数值或浮点值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// <para>默认值是 1 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object ObserverOffset { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Inner radius</para>
		/// <para>确定可见性的起始距离。 小于此距离的像元在输出中不可见，但仍会妨碍内半径和外半径之间像元的可见性。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// <para>默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object InnerRadius { get; set; }

		/// <summary>
		/// <para>Inner radius is 3D distance</para>
		/// <para>指定内半径参数的距离类型。</para>
		/// <para>未选中 - 内半径将被视为 2D 距离。 这是默认设置。</para>
		/// <para>选中 - 内半径将被视为 3D 距离。</para>
		/// <para><see cref="InnerRadiusIs3DEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object InnerRadiusIs3D { get; set; } = "false";

		/// <summary>
		/// <para>Outer radius</para>
		/// <para>确定可见性的最大距离。 超出此距离的像元将从分析中排除。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object OuterRadius { get; set; }

		/// <summary>
		/// <para>Outer radius is 3D distance</para>
		/// <para>指定外半径参数的距离类型。</para>
		/// <para>未选中 - 外半径将被视为 2D 距离。 这是默认设置。</para>
		/// <para>选中 - 外半径将被视为 3D 距离。</para>
		/// <para><see cref="OuterRadiusIs3DEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object OuterRadiusIs3D { get; set; } = "false";

		/// <summary>
		/// <para>Horizontal start angle</para>
		/// <para>水平扫描范围的起始角度。 该值应以度为单位，介于 0 至 360 之间，可为整数或浮点数，其中 0 指向北。 默认值为 0。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object HorizontalStartAngle { get; set; } = "0";

		/// <summary>
		/// <para>Horizontal end angle</para>
		/// <para>水平扫描范围的终止角度。 该值应以度为单位，介于 0 至 360 之间，可为整数或浮点数，其中 0 指向北。 默认值为 360。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object HorizontalEndAngle { get; set; } = "360";

		/// <summary>
		/// <para>Vertical upper angle</para>
		/// <para>扫描的（相对于水平面的）垂直角上限。 该值以度为单位，且可为整数或浮点数。 允许的范围为 -90 到（并包括） 90。</para>
		/// <para>此参数值必须大于垂直下角参数值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// <para>默认值为 90（垂直向上）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object VerticalUpperAngle { get; set; } = "90";

		/// <summary>
		/// <para>Vertical lower angle</para>
		/// <para>扫描的（位于水平面下的）垂直角上限。 该值以度为单位，且可为整数或浮点数。 允许的范围是从 -90 到（但不包括）90。</para>
		/// <para>此参数值必须小于垂直上角参数值。</para>
		/// <para>可以选择输入观察点数据集中的字段，也可以指定数值。</para>
		/// <para>如果为此参数设置了一个值，则该值将应用到所有观察点。 要为每个观察点指定不同的值，请将此参数设置为输入观察点要素数据集中的某个字段。</para>
		/// <para>默认值为 -90（垂直向下）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object VerticalLowerAngle { get; set; } = "-90";

		/// <summary>
		/// <para>Analysis method</para>
		/// <para>指定用于计算可见性的方法。 此选项允许您牺牲一些精度以获得更好的性能。</para>
		/// <para>所有视线—视线会运行到栅格上的每个像元以创建可见区域。 这是默认方法。</para>
		/// <para>周长视线—视线仅会运行到可见区域周边的像元以创建可见区域。 这种方法的性能比所有视线方法好，因为这种方法的计算中所运行的视线较少。</para>
		/// <para><see cref="AnalysisMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Viewshed parameters")]
		public object AnalysisMethod { get; set; } = "ALL_SIGHTLINES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Viewshed2 SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
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
			/// <para>观察点—输出将精确识别从各栅格表面位置进行观察时可见的观察点。 此分析类型所允许的最大输入观察点数为 32。</para>
			/// </summary>
			[GPValue("OBSERVERS")]
			[Description("观察点")]
			Observers,

		}

		/// <summary>
		/// <para>Inner radius is 3D distance</para>
		/// </summary>
		public enum InnerRadiusIs3DEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("3D")]
			_3D,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("GROUND")]
			GROUND,

		}

		/// <summary>
		/// <para>Outer radius is 3D distance</para>
		/// </summary>
		public enum OuterRadiusIs3DEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("3D")]
			_3D,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("GROUND")]
			GROUND,

		}

		/// <summary>
		/// <para>Analysis method</para>
		/// </summary>
		public enum AnalysisMethodEnum 
		{
			/// <summary>
			/// <para>所有视线—视线会运行到栅格上的每个像元以创建可见区域。 这是默认方法。</para>
			/// </summary>
			[GPValue("ALL_SIGHTLINES")]
			[Description("所有视线")]
			All_Sightlines,

			/// <summary>
			/// <para>周长视线—视线仅会运行到可见区域周边的像元以创建可见区域。 这种方法的性能比所有视线方法好，因为这种方法的计算中所运行的视线较少。</para>
			/// </summary>
			[GPValue("PERIMETER_SIGHTLINES")]
			[Description("周长视线")]
			Perimeter_Sightlines,

		}

#endregion
	}
}
