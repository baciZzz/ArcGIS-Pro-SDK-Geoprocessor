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
	/// <para>Optimal Path As Line</para>
	/// <para>最佳路径为线</para>
	/// <para>计算从源到目的地的最佳路径作为线。</para>
	/// </summary>
	public class OptimalPathAsLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDestinationData">
		/// <para>Input raster or feature destination data</para>
		/// <para>整型栅格或要素（点、线或面），用于标识确定通向最小成本源的最佳路径时基于的位置。</para>
		/// <para>如果输入是栅格，则它必须由具有有效目标值的像元组成，并且必须为其余的像元指定 NoData。 零是有效值。</para>
		/// </param>
		/// <param name="InDistanceAccumulationRaster">
		/// <para>Input distance accumulation raster</para>
		/// <para>距离累积栅格用于确定从源到目的地的最佳路径。</para>
		/// <para>距离累积栅格通常使用距离累积或距离分配工具进行创建。 距离累积栅格中的每个像元表示表面上从每个像元到源像元集的最小累积成本距离。</para>
		/// </param>
		/// <param name="InBackDirectionRaster">
		/// <para>Input back direction or flow direction raster</para>
		/// <para>反向栅格包含以度为单位的计算方向。 该方向用于标识沿最佳路径返回最小累积成本源同时避开障碍的下一个像元。</para>
		/// <para>值的范围是 0 度到 360 度，并为源像元保留 0 度。 正东（右侧）是 90 度，且值以顺时针方向增加（180 是南方、270 是西方、360 是北方）。</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output optimal path as feature</para>
		/// <para>作为最佳路径的输出要素类。</para>
		/// </param>
		public OptimalPathAsLine(object InDestinationData, object InDistanceAccumulationRaster, object InBackDirectionRaster, object OutPolylineFeatures)
		{
			this.InDestinationData = InDestinationData;
			this.InDistanceAccumulationRaster = InDistanceAccumulationRaster;
			this.InBackDirectionRaster = InBackDirectionRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 最佳路径为线</para>
		/// </summary>
		public override string DisplayName() => "最佳路径为线";

		/// <summary>
		/// <para>Tool Name : OptimalPathAsLine</para>
		/// </summary>
		public override string ToolName() => "OptimalPathAsLine";

		/// <summary>
		/// <para>Tool Excute Name : sa.OptimalPathAsLine</para>
		/// </summary>
		public override string ExcuteName() => "sa.OptimalPathAsLine";

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
		public override object[] Parameters() => new object[] { InDestinationData, InDistanceAccumulationRaster, InBackDirectionRaster, OutPolylineFeatures, DestinationField!, PathType!, CreateNetworkPaths! };

		/// <summary>
		/// <para>Input raster or feature destination data</para>
		/// <para>整型栅格或要素（点、线或面），用于标识确定通向最小成本源的最佳路径时基于的位置。</para>
		/// <para>如果输入是栅格，则它必须由具有有效目标值的像元组成，并且必须为其余的像元指定 NoData。 零是有效值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDestinationData { get; set; }

		/// <summary>
		/// <para>Input distance accumulation raster</para>
		/// <para>距离累积栅格用于确定从源到目的地的最佳路径。</para>
		/// <para>距离累积栅格通常使用距离累积或距离分配工具进行创建。 距离累积栅格中的每个像元表示表面上从每个像元到源像元集的最小累积成本距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDistanceAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input back direction or flow direction raster</para>
		/// <para>反向栅格包含以度为单位的计算方向。 该方向用于标识沿最佳路径返回最小累积成本源同时避开障碍的下一个像元。</para>
		/// <para>值的范围是 0 度到 360 度，并为源像元保留 0 度。 正东（右侧）是 90 度，且值以顺时针方向增加（180 是南方、270 是西方、360 是北方）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InBackDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output optimal path as feature</para>
		/// <para>作为最佳路径的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Destination field</para>
		/// <para>要用于获得目标位置的值的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object? DestinationField { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>用于指定对输入目标数据上的值和区域在成本路径计算中的解释方式进行定义的关键字。</para>
		/// <para>每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。 利用此选项，每个区域的最低成本路径起点将位于区域内成本距离权重最低的像元处。</para>
		/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
		/// <para>每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。 利用该选项，系统会分别处理输入目标数据中的每个像元，并确定每个像元的最小成本路径。</para>
		/// <para><see cref="PathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PathType { get; set; } = "EACH_ZONE";

		/// <summary>
		/// <para>Create network paths</para>
		/// <para>指定是计算从目的地到源的完整路径（可能重叠），还是创建不重叠的网络路径。</para>
		/// <para>未选中 - 计算从目的地到源的完整路径，这些路径可以重叠。 这是默认设置。</para>
		/// <para>选中 - 计算不重叠的网络路径。</para>
		/// <para><see cref="CreateNetworkPathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateNetworkPaths { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OptimalPathAsLine SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? geographicTransformations = null, bool? maintainSpatialIndex = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
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
			/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("最佳单一")]
			Best_single,

			/// <summary>
			/// <para>每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。 利用该选项，系统会分别处理输入目标数据中的每个像元，并确定每个像元的最小成本路径。</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("每个像元")]
			Each_cell,

			/// <summary>
			/// <para>每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。 利用此选项，每个区域的最低成本路径起点将位于区域内成本距离权重最低的像元处。</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("每个区域")]
			Each_zone,

		}

		/// <summary>
		/// <para>Create network paths</para>
		/// </summary>
		public enum CreateNetworkPathsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DESTINATIONS_TO_SOURCES")]
			DESTINATIONS_TO_SOURCES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NETWORK_PATHS")]
			NETWORK_PATHS,

		}

#endregion
	}
}
