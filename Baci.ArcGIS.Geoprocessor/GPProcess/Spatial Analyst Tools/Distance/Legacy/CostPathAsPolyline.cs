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
	/// <para>Cost Path As Polyline</para>
	/// <para>成本路径折线</para>
	/// <para>将从源到目标的的最小成本路径计算为线要素。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalPathAsLine"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalPathAsLine))]
	public class CostPathAsPolyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDestinationData">
		/// <para>Input raster or feature destination data</para>
		/// <para>用于识别这些像元的栅格或要素数据集（将确定的最小成本路径为这些像元与成本最低的源之间的路径）。</para>
		/// <para>如果输入是栅格，则它必须由具有有效目标值的像元组成，并且必须为其余的像元指定 NoData。零是有效值。</para>
		/// </param>
		/// <param name="InCostDistanceRaster">
		/// <para>Input cost distance or euclidean distance raster</para>
		/// <para>要用于确定从源到目的地的最小成本路径的成本距离栅格。</para>
		/// <para>成本距离栅格通常通过成本距离、成本分配或成本回溯链接工具进行创建。对于每个像元，成本距离栅格存储从每个像元到一组源像元的成本面上的最小累积成本距离。</para>
		/// </param>
		/// <param name="InCostBacklinkRaster">
		/// <para>Input cost backlink, back direction or flow direction raster</para>
		/// <para>成本回溯链接栅格，用于确定通过最小成本路径或最短路径返回到源的路径。</para>
		/// <para>对于回溯链接栅格、反向栅格或流向栅格中的每个像元，该值可识别在从该像元到源像元的路径上作为下一像元的邻近像元。</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output polyline features</para>
		/// <para>将保存最小成本路径的输出要素类。</para>
		/// </param>
		public CostPathAsPolyline(object InDestinationData, object InCostDistanceRaster, object InCostBacklinkRaster, object OutPolylineFeatures)
		{
			this.InDestinationData = InDestinationData;
			this.InCostDistanceRaster = InCostDistanceRaster;
			this.InCostBacklinkRaster = InCostBacklinkRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 成本路径折线</para>
		/// </summary>
		public override string DisplayName() => "成本路径折线";

		/// <summary>
		/// <para>Tool Name : CostPathAsPolyline</para>
		/// </summary>
		public override string ToolName() => "CostPathAsPolyline";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostPathAsPolyline</para>
		/// </summary>
		public override string ExcuteName() => "sa.CostPathAsPolyline";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDestinationData, InCostDistanceRaster, InCostBacklinkRaster, OutPolylineFeatures, PathType, DestinationField, ForceFlowDirectionConvention };

		/// <summary>
		/// <para>Input raster or feature destination data</para>
		/// <para>用于识别这些像元的栅格或要素数据集（将确定的最小成本路径为这些像元与成本最低的源之间的路径）。</para>
		/// <para>如果输入是栅格，则它必须由具有有效目标值的像元组成，并且必须为其余的像元指定 NoData。零是有效值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDestinationData { get; set; }

		/// <summary>
		/// <para>Input cost distance or euclidean distance raster</para>
		/// <para>要用于确定从源到目的地的最小成本路径的成本距离栅格。</para>
		/// <para>成本距离栅格通常通过成本距离、成本分配或成本回溯链接工具进行创建。对于每个像元，成本距离栅格存储从每个像元到一组源像元的成本面上的最小累积成本距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostDistanceRaster { get; set; }

		/// <summary>
		/// <para>Input cost backlink, back direction or flow direction raster</para>
		/// <para>成本回溯链接栅格，用于确定通过最小成本路径或最短路径返回到源的路径。</para>
		/// <para>对于回溯链接栅格、反向栅格或流向栅格中的每个像元，该值可识别在从该像元到源像元的路径上作为下一像元的邻近像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostBacklinkRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>将保存最小成本路径的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>用于指定对输入目标数据上的值和区域在成本路径计算中的解释方式进行定义的关键字。</para>
		/// <para>最佳单一— 对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
		/// <para>每个区域— 对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的像元。</para>
		/// <para>每个像元— 对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会分别处理输入目标数据中的每个像元，并确定每个像元的最小成本路径。</para>
		/// <para><see cref="PathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PathType { get; set; } = "BEST_SINGLE";

		/// <summary>
		/// <para>Destination field</para>
		/// <para>要用于获得目标位置的值的字段。</para>
		/// <para>输入要素数据必须至少包含一个有效字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object DestinationField { get; set; }

		/// <summary>
		/// <para>Force flow direction convention for backlink raster</para>
		/// <para>强制命令工具将输入回溯链接栅格视为流向栅格。流向栅格可以使用 0 和 255 之间的整数值。</para>
		/// <para>未选中 - 输入成本回溯链接栅格会根据值的范围（以及该值是整数值还是浮点值）以不同方式解释。对于 0-8 的值范围，输入成本回溯链接栅格将被视为回溯链接栅格。对于值 0-255 和整数值，输入成本回溯链接栅格将被视为流向栅格。对于 0-360 的值范围和浮点值，输入成本回溯链接栅格将被视为反向栅格。</para>
		/// <para>选中 - 为输入成本回溯链接栅格提供的栅格将被视为流向栅格。如果流向栅格的最大值不超过 8，则该操作是必需的。</para>
		/// <para><see cref="ForceFlowDirectionConventionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ForceFlowDirectionConvention { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostPathAsPolyline SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathTypeEnum 
		{
			/// <summary>
			/// <para>最佳单一— 对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("最佳单一")]
			Best_single,

			/// <summary>
			/// <para>每个像元— 对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会分别处理输入目标数据中的每个像元，并确定每个像元的最小成本路径。</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("每个像元")]
			Each_cell,

			/// <summary>
			/// <para>每个区域— 对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的像元。</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("每个区域")]
			Each_zone,

		}

		/// <summary>
		/// <para>Force flow direction convention for backlink raster</para>
		/// </summary>
		public enum ForceFlowDirectionConventionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INPUT_RANGE")]
			INPUT_RANGE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FLOW_DIRECTION")]
			FLOW_DIRECTION,

		}

#endregion
	}
}
