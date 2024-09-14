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
	/// <para>Particle Track</para>
	/// <para>粒子追踪</para>
	/// <para>通过速度场计算粒子的路径，以返回粒子追踪数据的 ASCII 文件和追踪信息的要素类（可选）。</para>
	/// </summary>
	public class ParticleTrack : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDirectionRaster">
		/// <para>Input direction raster</para>
		/// <para>每个像元值都表示渗流速度矢量（平均线速度）在像元中心的方向的输入栅格。</para>
		/// <para>方向以罗盘坐标（以北为基准方向按顺时针进行测量的度数）表示。这可通过达西流工具创建。</para>
		/// <para>方向值必须为浮点型。</para>
		/// </param>
		/// <param name="InMagnitudeRaster">
		/// <para>Input magnitude raster</para>
		/// <para>每个像元值都表示渗流速度矢量（平均线速度）在像元中心的模的输入栅格。</para>
		/// <para>单位为长度/时间。这可通过达西流工具创建。</para>
		/// </param>
		/// <param name="SourcePoint">
		/// <para>Source point</para>
		/// <para>开始粒子追踪的源点的位置。</para>
		/// <para>它被输入为标识该位置的 x,y 坐标的数字（地图单位）。</para>
		/// </param>
		/// <param name="OutTrackFile">
		/// <para>Output particle track file</para>
		/// <para>包含粒子追踪数据的输出 ASCII 文本文件。</para>
		/// </param>
		public ParticleTrack(object InDirectionRaster, object InMagnitudeRaster, object SourcePoint, object OutTrackFile)
		{
			this.InDirectionRaster = InDirectionRaster;
			this.InMagnitudeRaster = InMagnitudeRaster;
			this.SourcePoint = SourcePoint;
			this.OutTrackFile = OutTrackFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 粒子追踪</para>
		/// </summary>
		public override string DisplayName() => "粒子追踪";

		/// <summary>
		/// <para>Tool Name : ParticleTrack</para>
		/// </summary>
		public override string ToolName() => "ParticleTrack";

		/// <summary>
		/// <para>Tool Excute Name : sa.ParticleTrack</para>
		/// </summary>
		public override string ExcuteName() => "sa.ParticleTrack";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDirectionRaster, InMagnitudeRaster, SourcePoint, OutTrackFile, StepLength!, TrackingTime!, OutTrackPolylineFeatures! };

		/// <summary>
		/// <para>Input direction raster</para>
		/// <para>每个像元值都表示渗流速度矢量（平均线速度）在像元中心的方向的输入栅格。</para>
		/// <para>方向以罗盘坐标（以北为基准方向按顺时针进行测量的度数）表示。这可通过达西流工具创建。</para>
		/// <para>方向值必须为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDirectionRaster { get; set; }

		/// <summary>
		/// <para>Input magnitude raster</para>
		/// <para>每个像元值都表示渗流速度矢量（平均线速度）在像元中心的模的输入栅格。</para>
		/// <para>单位为长度/时间。这可通过达西流工具创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InMagnitudeRaster { get; set; }

		/// <summary>
		/// <para>Source point</para>
		/// <para>开始粒子追踪的源点的位置。</para>
		/// <para>它被输入为标识该位置的 x,y 坐标的数字（地图单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object SourcePoint { get; set; }

		/// <summary>
		/// <para>Output particle track file</para>
		/// <para>包含粒子追踪数据的输出 ASCII 文本文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutTrackFile { get; set; }

		/// <summary>
		/// <para>Step length</para>
		/// <para>用于计算粒子追踪的步长。</para>
		/// <para>默认值为像元大小的一半。单位是长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? StepLength { get; set; }

		/// <summary>
		/// <para>Tracking time</para>
		/// <para>进行粒子追踪所经历的最大时间。</para>
		/// <para>算法将沿着追踪轨迹执行，直到达到此时间或者粒子迁移出栅格或陷入洼地。</para>
		/// <para>默认值为无穷大。单位是时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? TrackingTime { get; set; }

		/// <summary>
		/// <para>Output track polyline features</para>
		/// <para>包含粒子追踪的可选输出线要素类。</para>
		/// <para>此要素类包含一系列弧，其属性表示沿路径移动的位置、局部速度方向和模以及累积长度和时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutTrackPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ParticleTrack SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, bool? maintainSpatialIndex = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
