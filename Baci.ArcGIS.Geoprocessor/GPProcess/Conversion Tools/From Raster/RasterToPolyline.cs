using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Raster to Polyline</para>
	/// <para>栅格转折线</para>
	/// <para>将栅格数据集转换为折线要素。</para>
	/// </summary>
	public class RasterToPolyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入栅格数据集。</para>
		/// <para>栅格数据必须是整型。</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output polyline features</para>
		/// <para>包含已转换折线的输出要素类。</para>
		/// </param>
		public RasterToPolyline(object InRaster, object OutPolylineFeatures)
		{
			this.InRaster = InRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转折线</para>
		/// </summary>
		public override string DisplayName() => "栅格转折线";

		/// <summary>
		/// <para>Tool Name : RasterToPolyline</para>
		/// </summary>
		public override string ToolName() => "RasterToPolyline";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToPolyline</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToPolyline";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutPolylineFeatures, BackgroundValue, MinimumDangleLength, Simplify, RasterField };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入栅格数据集。</para>
		/// <para>栅格数据必须是整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>包含已转换折线的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Background value</para>
		/// <para>可指定用于识别背景像元的值。栅格数据集可看作是一系列前景像元与背景像元的组合。线状要素将基于前景单元生成。</para>
		/// <para>零—背景由 zero 像元、less 像元或 NoData 像元组成。而所有值大于零的像元均将视为前景值。</para>
		/// <para>NoData—背景由 NoData 单元组成。所有具备有效值的单元均属于前景单元。</para>
		/// <para><see cref="BackgroundValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BackgroundValue { get; set; } = "ZERO";

		/// <summary>
		/// <para>Minimum dangle length</para>
		/// <para>将被保留的悬挂折线的最小长度值。默认值为零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MinimumDangleLength { get; set; } = "0";

		/// <summary>
		/// <para>Simplify polylines</para>
		/// <para>在保持线的基本形状不变的前提下，通过移除其中小的凹进和凸起或无关紧要的折弯来简化线。</para>
		/// <para>选中 - 这些折线将简化为简单的形状，因此每个形状拥有最少的线段数。这是默认设置。</para>
		/// <para>未选中 - 折线不会被简化。</para>
		/// <para><see cref="SimplifyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Simplify { get; set; } = "true";

		/// <summary>
		/// <para>Field</para>
		/// <para>此字段用于将输入栅格中像元值指定给输出数据集中的折线要素。</para>
		/// <para>栅格字段可为整型或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object RasterField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToPolyline SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, bool? maintainSpatialIndex = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Background value</para>
		/// </summary>
		public enum BackgroundValueEnum 
		{
			/// <summary>
			/// <para>零—背景由 zero 像元、less 像元或 NoData 像元组成。而所有值大于零的像元均将视为前景值。</para>
			/// </summary>
			[GPValue("ZERO")]
			[Description("零")]
			Zero,

			/// <summary>
			/// <para>NoData—背景由 NoData 单元组成。所有具备有效值的单元均属于前景单元。</para>
			/// </summary>
			[GPValue("NODATA")]
			[Description("NoData")]
			NoData,

		}

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
