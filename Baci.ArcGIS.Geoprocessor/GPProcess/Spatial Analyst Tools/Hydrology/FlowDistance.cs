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
	/// <para>Flow Distance</para>
	/// <para>流动距离</para>
	/// <para>计算每个像元沿流动路径到它们所流入河流上像元的下坡距离的水平或垂直分量。 如果是多个流动路径，则需要计算最小或最大流动距离，以及流动距离的加权平均数。</para>
	/// </summary>
	public class FlowDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStreamRaster">
		/// <para>Input stream raster</para>
		/// <para>表示线性流网络的输入流栅格。</para>
		/// </param>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出流动距离栅格。</para>
		/// </param>
		public FlowDistance(object InStreamRaster, object InSurfaceRaster, object OutRaster)
		{
			this.InStreamRaster = InStreamRaster;
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 流动距离</para>
		/// </summary>
		public override string DisplayName() => "流动距离";

		/// <summary>
		/// <para>Tool Name : FlowDistance</para>
		/// </summary>
		public override string ToolName() => "FlowDistance";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowDistance</para>
		/// </summary>
		public override string ExcuteName() => "sa.FlowDistance";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InStreamRaster, InSurfaceRaster, OutRaster, InFlowDirectionRaster!, DistanceType!, FlowDirectionType!, StatisticsType! };

		/// <summary>
		/// <para>Input stream raster</para>
		/// <para>表示线性流网络的输入流栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InStreamRaster { get; set; }

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出流动距离栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>如果提供流向栅格，则下坡方向将限于由输入流向定义的方向。</para>
		/// <para>可以使用流向工具创建流向栅格。</para>
		/// <para>可使用 D8、多流向 (MFD) 或 D-Infinity 方法创建流向栅格。 可以使用输入流向类型参数来指定创建流向栅格时所使用的方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Distance type</para>
		/// <para>确定是否计算流动距离的垂直或水平分量。</para>
		/// <para>垂直—流动距离计算表示域中的每个像元到其沿流动路径流经的流上的某个像元的流动距离的垂直分量。这是默认设置。</para>
		/// <para>水平—流动距离计算表示域中的每个像元到其沿流动路径流经的流上的某个像元的流动距离的水平分量。</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceType { get; set; } = "VERTICAL";

		/// <summary>
		/// <para>Input flow direction type</para>
		/// <para>指定输入流向栅格类型。</para>
		/// <para>D8—输入流向栅格为 D8 类型。 这是默认设置。</para>
		/// <para>MFD—输入流向栅格为多流向 (MFD) 类型。</para>
		/// <para>DINF—输入流向栅格为 D-Infinity (DINF) 类型。</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlowDirectionType { get; set; } = "MFD";

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>确定用于计算多个流动路径上的流动距离的统计类型。如果从每个像元到流上的某个像元只存在单一流动路径，则所有统计类型都将产生相同的结果。</para>
		/// <para>最小值—如果存在多个流动路径，则需要计算最小流动距离。这是默认设置。</para>
		/// <para>加权平均数—如果存在多个流动路径，则需要计算流动距离的加权平均数。从某个像元到其下游相邻像元的流量比例可用作计算加权平均数的权重。</para>
		/// <para>最大值—如果存在多个流动路径，则需要计算最大流动距离。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MINIMUM";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDistance SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance type</para>
		/// </summary>
		public enum DistanceTypeEnum 
		{
			/// <summary>
			/// <para>垂直—流动距离计算表示域中的每个像元到其沿流动路径流经的流上的某个像元的流动距离的垂直分量。这是默认设置。</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("垂直")]
			Vertical,

			/// <summary>
			/// <para>水平—流动距离计算表示域中的每个像元到其沿流动路径流经的流上的某个像元的流动距离的水平分量。</para>
			/// </summary>
			[GPValue("HORIZONTAL")]
			[Description("水平")]
			Horizontal,

		}

		/// <summary>
		/// <para>Input flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>MFD—输入流向栅格为多流向 (MFD) 类型。</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

		}

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>最小值—如果存在多个流动路径，则需要计算最小流动距离。这是默认设置。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>加权平均数—如果存在多个流动路径，则需要计算流动距离的加权平均数。从某个像元到其下游相邻像元的流量比例可用作计算加权平均数的权重。</para>
			/// </summary>
			[GPValue("WEIGHTED_MEAN")]
			[Description("加权平均数")]
			Weighted_Mean,

			/// <summary>
			/// <para>最大值—如果存在多个流动路径，则需要计算最大流动距离。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

		}

#endregion
	}
}
