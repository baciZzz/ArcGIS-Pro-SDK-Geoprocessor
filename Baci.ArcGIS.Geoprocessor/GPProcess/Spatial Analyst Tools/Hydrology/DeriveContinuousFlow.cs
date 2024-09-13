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
	/// <para>Derive Continuous Flow</para>
	/// <para>派生连续流</para>
	/// <para>生成从输入表面栅格流入每个像元的累积流量栅格，无需预先填充汇或洼地。</para>
	/// </summary>
	public class DeriveContinuousFlow : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </param>
		/// <param name="OutAccumulationRaster">
		/// <para>Output flow accumulation raster</para>
		/// <para>表示流量的输出栅格（流入每个像元的上游像元数）。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </param>
		public DeriveContinuousFlow(object InSurfaceRaster, object OutAccumulationRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutAccumulationRaster = OutAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 派生连续流</para>
		/// </summary>
		public override string DisplayName() => "派生连续流";

		/// <summary>
		/// <para>Tool Name : DeriveContinuousFlow</para>
		/// </summary>
		public override string ToolName() => "DeriveContinuousFlow";

		/// <summary>
		/// <para>Tool Excute Name : sa.DeriveContinuousFlow</para>
		/// </summary>
		public override string ExcuteName() => "sa.DeriveContinuousFlow";

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
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutAccumulationRaster, InDepressionsData!, InWeightRaster!, OutFlowDirectionRaster!, FlowDirectionType!, ForceFlow! };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output flow accumulation raster</para>
		/// <para>表示流量的输出栅格（流入每个像元的上游像元数）。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutAccumulationRaster { get; set; }

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
		/// <para>Output flow direction raster</para>
		/// <para>使用 D8 或多流向 (MFD) 方法显示每个像元流向的输出栅格。</para>
		/// <para>输出为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Flow direction type</para>
		/// <para>指定计算流向时将使用的流向法的类型。</para>
		/// <para>D8—流向将由 D8 方法确定。 此方法会将流向分配至最陡的下坡相邻点。 这是默认设置。</para>
		/// <para>MFD—流向将基于 MFD 流量法。 流向将根据自适应分区指数跨下坡邻域进行分区。</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlowDirectionType { get; set; } = "D8";

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
		public DeriveContinuousFlow SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>D8—流向将由 D8 方法确定。 此方法会将流向分配至最陡的下坡相邻点。 这是默认设置。</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—流向将基于 MFD 流量法。 流向将根据自适应分区指数跨下坡邻域进行分区。</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

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
