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
	/// <para>Topo to Raster by File</para>
	/// <para>依据文件实现地形转栅格</para>
	/// <para>通过文件中指定的参数将点、线和面数据插值成符合真实地表的栅格表面。</para>
	/// </summary>
	public class TopoToRasterByFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParameterFile">
		/// <para>Input parameter file</para>
		/// <para>包含插值中所用输入和参数的待输入 ASCII 文本文件。</para>
		/// <para>通常，此文件在上次运行地形转栅格时创建，同时还将指定可选的输出参数文件。</para>
		/// <para>为了测试参数更改的结果，对此文件进行编辑并重新运行插值比每次正确地启用地形转栅格工具更容易。</para>
		/// </param>
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		public TopoToRasterByFile(object InParameterFile, object OutSurfaceRaster)
		{
			this.InParameterFile = InParameterFile;
			this.OutSurfaceRaster = OutSurfaceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 依据文件实现地形转栅格</para>
		/// </summary>
		public override string DisplayName() => "依据文件实现地形转栅格";

		/// <summary>
		/// <para>Tool Name : TopoToRasterByFile</para>
		/// </summary>
		public override string ToolName() => "TopoToRasterByFile";

		/// <summary>
		/// <para>Tool Excute Name : sa.TopoToRasterByFile</para>
		/// </summary>
		public override string ExcuteName() => "sa.TopoToRasterByFile";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "tileSize", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParameterFile, OutSurfaceRaster, OutStreamFeatures!, OutSinkFeatures!, OutResidualFeature!, OutStreamCliffErrorFeature!, OutContourErrorFeature! };

		/// <summary>
		/// <para>Input parameter file</para>
		/// <para>包含插值中所用输入和参数的待输入 ASCII 文本文件。</para>
		/// <para>通常，此文件在上次运行地形转栅格时创建，同时还将指定可选的输出参数文件。</para>
		/// <para>为了测试参数更改的结果，对此文件进行编辑并重新运行插值比每次正确地启用地形转栅格工具更容易。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InParameterFile { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output stream polyline features</para>
		/// <para>河流折线要素的输出要素类。</para>
		/// <para>折线要素按如下方式编码：</para>
		/// <para>1. 不在悬崖上的输入河流线。</para>
		/// <para>2. 在悬崖上的输入河流线（瀑布）。</para>
		/// <para>3. 清除伪汇的地形强化。</para>
		/// <para>4. 从等值线拐角确定的河流线。</para>
		/// <para>5. 从等值线拐角确定的山脊线。</para>
		/// <para>6. 未使用代码。</para>
		/// <para>7. 数据河流线边条件。</para>
		/// <para>8. 未使用代码。</para>
		/// <para>9. 表示大型高程数据间隙的线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutStreamFeatures { get; set; }

		/// <summary>
		/// <para>Output remaining sink point features</para>
		/// <para>遗留汇点要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutSinkFeatures { get; set; }

		/// <summary>
		/// <para>Output residual point features</para>
		/// <para>由局部离散误差进行衡量的所有大高程残差的输出点要素类。</para>
		/// <para>应对所有大于 10 的比例缩放残差进行检查，查看输入高程和河流数据是否存在错误。大比例缩放残差表示输入高程数据和河流线数据之间存在冲突。这可能也与不良的自动地形强化有关。这些冲突可以通过在首次检查和纠正现有输入数据中的错误后提供附加的流线和/或点高程数据来进行修复。未大比例缩放的残差通常表示存在输入高程误差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutResidualFeature { get; set; }

		/// <summary>
		/// <para>Output stream and cliff error point features</para>
		/// <para>可能出现河流和悬崖错误的位置的输出点要素类。</para>
		/// <para>可从点要素类来识别其河流有闭合环、支流和悬崖上河流的位置。还可识别相邻像元与悬崖高低边不一致的悬崖。这可以理想地指出方向错误的悬崖。</para>
		/// <para>点按如下方式编码：</para>
		/// <para>1. 数据河流线网络中的真回路。</para>
		/// <para>2. 以外栅格编码的河流网络中的回路。</para>
		/// <para>3. 通过连接湖泊的河流网络中的回路。</para>
		/// <para>4. 支流点。</para>
		/// <para>5. 悬崖上的河流（瀑布）。</para>
		/// <para>6. 表示从湖泊流出多条河流的点。</para>
		/// <para>7. 未使用代码。</para>
		/// <para>8. 悬崖旁高度与悬崖方向不一致的点。</para>
		/// <para>9. 未使用代码。</para>
		/// <para>10. 已移除圆形支流。</para>
		/// <para>11. 无流入河流的支流。</para>
		/// <para>12. 不同于出现数据河流线支流位置的输出像元中的栅格化支流。</para>
		/// <para>13. 处理边条件时出错 - 非常复杂的河流线数据的指示符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutStreamCliffErrorFeature { get; set; }

		/// <summary>
		/// <para>Output contour  error point features</para>
		/// <para>可能发生的与输入等值线数据相关的错误的输出点要素类。</para>
		/// <para>高度偏差达到输出栅格所示等值线值标准偏差五倍以上的等值线会报告至此要素类。与不同高程值的等值线相连接的等值线在此要素类中会使用代码 1 进行标记，这是等值线标注错误的明确标志。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutContourErrorFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TopoToRasterByFile SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, bool? maintainSpatialIndex = null, object? mask = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, bool? transferDomains = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
