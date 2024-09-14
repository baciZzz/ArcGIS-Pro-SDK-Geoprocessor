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
	/// <para>Stream to Feature</para>
	/// <para>栅格河网矢量化</para>
	/// <para>将表示线状网络的栅格转换为表示线状网络的要素。</para>
	/// </summary>
	public class StreamToFeature : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStreamRaster">
		/// <para>Input stream raster</para>
		/// <para>表示线性河流网络的输入栅格。</para>
		/// </param>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以使用流向 工具创建流向栅格。</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output polyline features</para>
		/// <para>将保存转换后的输出河流要素类。</para>
		/// </param>
		public StreamToFeature(object InStreamRaster, object InFlowDirectionRaster, object OutPolylineFeatures)
		{
			this.InStreamRaster = InStreamRaster;
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格河网矢量化</para>
		/// </summary>
		public override string DisplayName() => "栅格河网矢量化";

		/// <summary>
		/// <para>Tool Name : StreamToFeature</para>
		/// </summary>
		public override string ToolName() => "StreamToFeature";

		/// <summary>
		/// <para>Tool Excute Name : sa.StreamToFeature</para>
		/// </summary>
		public override string ExcuteName() => "sa.StreamToFeature";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InStreamRaster, InFlowDirectionRaster, OutPolylineFeatures, Simplify };

		/// <summary>
		/// <para>Input stream raster</para>
		/// <para>表示线性河流网络的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InStreamRaster { get; set; }

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以使用流向 工具创建流向栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>将保存转换后的输出河流要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Simplify polylines</para>
		/// <para>指定是否使用去点。</para>
		/// <para>选中 - 对要素进行去点操作以减少折点数。用于线概化的道格拉斯-普克 (Douglas-Puecker) 算法可与容差 sqrt(0.5) * cell size 结合使用。</para>
		/// <para>未选中 - 不使用去点功能。</para>
		/// <para>默认情况下，应用去点功能。</para>
		/// <para><see cref="SimplifyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Simplify { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StreamToFeature SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, bool? maintainSpatialIndex = null, object mask = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Simplify polylines</para>
		/// </summary>
		public enum SimplifyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SIMPLIFY")]
			SIMPLIFY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SIMPLIFY")]
			NO_SIMPLIFY,

		}

#endregion
	}
}
