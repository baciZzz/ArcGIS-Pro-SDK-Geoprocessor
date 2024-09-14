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
	/// <para>Derive Stream As Raster</para>
	/// <para>派生流作为栅格</para>
	/// <para>从输入表面栅格生成流栅格，无需预先填充汇或洼地。</para>
	/// </summary>
	public class DeriveStreamAsRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="OutStreamRaster">
		/// <para>Output stream raster</para>
		/// <para>表示流位置的输出栅格。</para>
		/// </param>
		public DeriveStreamAsRaster(object InSurfaceRaster, object OutStreamRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutStreamRaster = OutStreamRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 派生流作为栅格</para>
		/// </summary>
		public override string DisplayName() => "派生流作为栅格";

		/// <summary>
		/// <para>Tool Name : DeriveStreamAsRaster</para>
		/// </summary>
		public override string ToolName() => "DeriveStreamAsRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.DeriveStreamAsRaster</para>
		/// </summary>
		public override string ExcuteName() => "sa.DeriveStreamAsRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutStreamRaster, InDepressionsData!, InWeightRaster!, AccumulationThreshold!, StreamDesignationMethod!, ForceFlow! };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>输入表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output stream raster</para>
		/// <para>表示流位置的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutStreamRaster { get; set; }

		/// <summary>
		/// <para>Input raster or feature depressions data</para>
		/// <para>定义真实洼地的可选数据集。</para>
		/// <para>可以通过栅格或要素图层定义洼地。</para>
		/// <para>如果输入为栅格，则洼地像元必须采用有效值（包括零），并且不是洼地的区域必须为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InDepressionsData { get; set; }

		/// <summary>
		/// <para>Input accumulation weight raster</para>
		/// <para>可选的输入栅格数据集，用于定义有助于在每个像元处流量的流量比例。</para>
		/// <para>权重仅适用于流量的累积。</para>
		/// <para>如果未指定累积权重栅格，则将默认的权重值 1 应用于每个像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InWeightRaster { get; set; }

		/// <summary>
		/// <para>Accumulation threshold</para>
		/// <para>用于根据流入该单元的总面积来确定给定单元是否为流的构成部分的阈值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? AccumulationThreshold { get; set; }

		/// <summary>
		/// <para>Stream designation method</para>
		/// <para>指定输出中流的唯一值或级别。</para>
		/// <para>常量—输出像元值将全部等于 1。 这是默认设置。</para>
		/// <para>唯一—每个流在输出的交叉点之间都具有唯一 ID。</para>
		/// <para>放射状/发射状—将使用 Strahler 方法，在该方法中流级别仅在相同级别的流相交时增加。 一级连接线与二级连接线相交会保留二级连接线，而不会创建三级连接线。</para>
		/// <para>Shreve—将使用 Shreve 方法，该方法将按量级分配流级别。 所有没有支流的连接线的量级（分级）将被指定为一。 量级是指可相加的河流下坡坡度。 当两条连接线相交时，其量级相加并分配给下坡连接线。</para>
		/// <para>Hack—将使用 Hack 方法，其中为每个流段分配的级别大于其排放的流或河流。 例如，主河道的级别为 1，向其排放的所有流段的级别为 2，排放到 2 级流的所有流的级别为 3，依此类推。</para>
		/// <para><see cref="StreamDesignationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StreamDesignationMethod { get; set; } = "CONSTANT";

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// <para>指定边缘像元始终向外流还是遵循正常流动规则。</para>
		/// <para>未选中 - 如果边缘像元内部的最大降幅大于零，则将照常确定流向；否则流向将朝向边缘。 应从表面栅格的边缘向内流的像元也将执行此行为。 这是默认设置。</para>
		/// <para>选中 - 表面栅格边缘的所有像元将从表面栅格向外流。</para>
		/// <para><see cref="ForceFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ForceFlow { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeriveStreamAsRaster SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Stream designation method</para>
		/// </summary>
		public enum StreamDesignationMethodEnum 
		{
			/// <summary>
			/// <para>常量—输出像元值将全部等于 1。 这是默认设置。</para>
			/// </summary>
			[GPValue("CONSTANT")]
			[Description("常量")]
			Constant,

			/// <summary>
			/// <para>唯一—每个流在输出的交叉点之间都具有唯一 ID。</para>
			/// </summary>
			[GPValue("UNIQUE")]
			[Description("唯一")]
			Unique,

			/// <summary>
			/// <para>放射状/发射状—将使用 Strahler 方法，在该方法中流级别仅在相同级别的流相交时增加。 一级连接线与二级连接线相交会保留二级连接线，而不会创建三级连接线。</para>
			/// </summary>
			[GPValue("STRAHLER")]
			[Description("放射状/发射状")]
			Strahler,

			/// <summary>
			/// <para>Shreve—将使用 Shreve 方法，该方法将按量级分配流级别。 所有没有支流的连接线的量级（分级）将被指定为一。 量级是指可相加的河流下坡坡度。 当两条连接线相交时，其量级相加并分配给下坡连接线。</para>
			/// </summary>
			[GPValue("SHREVE")]
			[Description("Shreve")]
			Shreve,

			/// <summary>
			/// <para>Hack—将使用 Hack 方法，其中为每个流段分配的级别大于其排放的流或河流。 例如，主河道的级别为 1，向其排放的所有流段的级别为 2，排放到 2 级流的所有流的级别为 3，依此类推。</para>
			/// </summary>
			[GPValue("HACK")]
			[Description("Hack")]
			Hack,

		}

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// </summary>
		public enum ForceFlowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NORMAL")]
			NORMAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE")]
			FORCE,

		}

#endregion
	}
}
