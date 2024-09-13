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
	/// <para>Contour</para>
	/// <para>等值线</para>
	/// <para>根据栅格表面创建等值线的要素类。</para>
	/// </summary>
	public class Contour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output feature class</para>
		/// <para>输出等值线要素。</para>
		/// </param>
		/// <param name="ContourInterval">
		/// <para>Contour interval</para>
		/// <para>等值线间的间距或距离。</para>
		/// <para>该值可为任意正数。</para>
		/// </param>
		public Contour(object InRaster, object OutPolylineFeatures, object ContourInterval)
		{
			this.InRaster = InRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
			this.ContourInterval = ContourInterval;
		}

		/// <summary>
		/// <para>Tool Display Name : 等值线</para>
		/// </summary>
		public override string DisplayName() => "等值线";

		/// <summary>
		/// <para>Tool Name : 等值线</para>
		/// </summary>
		public override string ToolName() => "等值线";

		/// <summary>
		/// <para>Tool Excute Name : sa.Contour</para>
		/// </summary>
		public override string ExcuteName() => "sa.Contour";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutPolylineFeatures, ContourInterval, BaseContour, ZFactor, ContourType, MaxVerticesPerFeature };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>输出等值线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Contour interval</para>
		/// <para>等值线间的间距或距离。</para>
		/// <para>该值可为任意正数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ContourInterval { get; set; }

		/// <summary>
		/// <para>Base contour</para>
		/// <para>起始等值线值。</para>
		/// <para>根据需要生成高于和低于该值的等值线以覆盖输入栅格的整个值范围。 默认值为零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>在生成等值线时使用的单位转换因子。 默认值为 1。</para>
		/// <para>等值线是基于输入栅格中的 z 值生成的，所采用的测量单位通常为米或英尺。 如果使用默认值 1，等值线将采用与输入栅格中的 z 值相同的单位。 要以不同于 z 值的单位创建等值线，请为 z 因子设置适当的值。 对于此工具，没有必要使地面 x,y 单位与表面 z 单位保持一致。</para>
		/// <para>例如，如果输入栅格中的高程值单位为英尺，但您希望以米为单位来生成等值线，则可将 z 因子设置为 0.3048（因为 1 英尺 = 0.3048 米）。</para>
		/// <para>再如，考虑采用 WGS_84 地理坐标系且高程单位为米的输入栅格，您希望以 50 英尺为基础、100 英尺为间隔来生成等值线（即等值线将为 50 英尺、150 英尺、250 英尺，以此类推）。 为此，可将等值线间距设置为 100、起始等值线设置为 50，并将 Z 因子设置为 3.2808（因为 1 米 = 3.2808 英尺）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Contour type</para>
		/// <para>指定输出的类型。输出可以将等值线表示为线或面。面有多个选项。</para>
		/// <para>等值线—等值线（等高线）的折线要素类。这是默认设置。</para>
		/// <para>等值线面—填充等值线的面要素类。</para>
		/// <para>等值线壳—面要素类，其中面的上限按间隔值累积增加。下限在栅格最小值处保持不变。</para>
		/// <para>等值线上壳—面要素类，其中面的下限从栅格最小值开始按间隔值累积增加。上限在栅格最小值处保持不变。</para>
		/// <para><see cref="ContourTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourType { get; set; } = "CONTOUR";

		/// <summary>
		/// <para>Maximum vertices per feature</para>
		/// <para>细分要素时的折点限制。仅当输出要素包含大量（数百万）折点时，才能使用此参数。</para>
		/// <para>此参数旨在用于对以后在以下情况下可能会导致问题的极大要素进行细分，例如在存储、分析或绘制要素时。</para>
		/// <para>如果留空，则不会分割输出要素。默认值为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 4)]
		[High(Allow = true, Value = 2147483646)]
		public object MaxVerticesPerFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Contour SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contour type</para>
		/// </summary>
		public enum ContourTypeEnum 
		{
			/// <summary>
			/// <para>等值线—等值线（等高线）的折线要素类。这是默认设置。</para>
			/// </summary>
			[GPValue("CONTOUR")]
			[Description("等值线")]
			Contour,

			/// <summary>
			/// <para>等值线面—填充等值线的面要素类。</para>
			/// </summary>
			[GPValue("CONTOUR_POLYGON")]
			[Description("等值线面")]
			Contour_polygon,

			/// <summary>
			/// <para>等值线壳—面要素类，其中面的上限按间隔值累积增加。下限在栅格最小值处保持不变。</para>
			/// </summary>
			[GPValue("CONTOUR_SHELL")]
			[Description("等值线壳")]
			Contour_shell,

			/// <summary>
			/// <para>等值线上壳—面要素类，其中面的下限从栅格最小值开始按间隔值累积增加。上限在栅格最小值处保持不变。</para>
			/// </summary>
			[GPValue("CONTOUR_SHELL_UP")]
			[Description("等值线上壳")]
			Contour_shell_up,

		}

#endregion
	}
}
