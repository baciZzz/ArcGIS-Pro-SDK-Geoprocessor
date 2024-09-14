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
	/// <para>Contour with Barriers</para>
	/// <para>含障碍的等值线</para>
	/// <para>根据栅格表面创建等值线。 如果包含障碍要素，则允许在障碍两侧独立生成等值线。</para>
	/// </summary>
	public class ContourWithBarriers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="OutContourFeatureClass">
		/// <para>Output Contour Features</para>
		/// <para>输出等值线要素。</para>
		/// </param>
		public ContourWithBarriers(object InRaster, object OutContourFeatureClass)
		{
			this.InRaster = InRaster;
			this.OutContourFeatureClass = OutContourFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 含障碍的等值线</para>
		/// </summary>
		public override string DisplayName() => "含障碍的等值线";

		/// <summary>
		/// <para>Tool Name : ContourWithBarriers</para>
		/// </summary>
		public override string ToolName() => "ContourWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : sa.ContourWithBarriers</para>
		/// </summary>
		public override string ExcuteName() => "sa.ContourWithBarriers";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutContourFeatureClass, InBarrierFeatures, InContourType, InContourValuesFile, ExplicitOnly, InBaseContour, InContourInterval, InIndexedContourInterval, InContourList, InZFactor };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Contour Features</para>
		/// <para>输出等值线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object OutContourFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Barrier Features</para>
		/// <para>输入障碍要素。</para>
		/// <para>要素可以是折线或面类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Type of Contours</para>
		/// <para>要创建的等值线的类型。</para>
		/// <para>折线— 用等值线或等值线图表示输入栅格。</para>
		/// <para>面— 用闭合面表示等值线。</para>
		/// <para>此工具的当前版本仅支持折线输出。如果使用面输出选项，则会将其忽略并会创建折线输出。</para>
		/// <para><see cref="InContourTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InContourType { get; set; } = "POLYLINES";

		/// <summary>
		/// <para>File Containing Contour Value Specifications</para>
		/// <para>也可通过文本文件指定起始等值线、等值线间距、计曲线间距和明确的等值线值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object InContourValuesFile { get; set; }

		/// <summary>
		/// <para>Enter Explicit Contour Values Only</para>
		/// <para>只使用明确的等值线值。未指定起始等值线、等值线间距和计曲线间距。</para>
		/// <para>取消选中 - 必须指定默认的等值线间距。</para>
		/// <para>选中 - 仅指定明确的等值线值。</para>
		/// <para><see cref="ExplicitOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExplicitOnly { get; set; } = "false";

		/// <summary>
		/// <para>Base Contour</para>
		/// <para>起始等值线值。</para>
		/// <para>根据需要生成高于和低于该值的等值线以覆盖输入栅格的整个值范围。 默认值为零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object InBaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>等值线间的间距或距离。</para>
		/// <para>该值可为任意正数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object InContourInterval { get; set; }

		/// <summary>
		/// <para>Indexed Contour Interval</para>
		/// <para>此外，也会在输出要素类中按此间距生成等值线并相应地进行标记。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object InIndexedContourInterval { get; set; } = "0";

		/// <summary>
		/// <para>Explicit Contour Values</para>
		/// <para>创建等值线的明确值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InContourList { get; set; }

		/// <summary>
		/// <para>Factor Applied to Raster Z-values</para>
		/// <para>在生成等值线时使用的单位转换因子。 默认值为 1。</para>
		/// <para>等值线是基于输入栅格中的 z 值生成的，所采用的测量单位通常为米或英尺。 如果使用默认值 1，等值线将采用与输入栅格中的 z 值相同的单位。 要以不同于 z 值的单位创建等值线，请为 z 因子设置适当的值。 对于此工具，没有必要使地面 x,y 单位与表面 z 单位保持一致。</para>
		/// <para>例如，如果输入栅格中的高程值单位为英尺，但您希望以米为单位来生成等值线，则可将 z 因子设置为 0.3048（因为 1 英尺 = 0.3048 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object InZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ContourWithBarriers SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, bool? maintainSpatialIndex = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type of Contours</para>
		/// </summary>
		public enum InContourTypeEnum 
		{
			/// <summary>
			/// <para>折线— 用等值线或等值线图表示输入栅格。</para>
			/// </summary>
			[GPValue("POLYLINES")]
			[Description("折线")]
			Polylines,

			/// <summary>
			/// <para>面— 用闭合面表示等值线。</para>
			/// </summary>
			[GPValue("POLYGONS")]
			[Description("面")]
			Polygons,

		}

		/// <summary>
		/// <para>Enter Explicit Contour Values Only</para>
		/// </summary>
		public enum ExplicitOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPLICIT_VALUES_ONLY")]
			EXPLICIT_VALUES_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXPLICIT_VALUES_ONLY")]
			NO_EXPLICIT_VALUES_ONLY,

		}

#endregion
	}
}
