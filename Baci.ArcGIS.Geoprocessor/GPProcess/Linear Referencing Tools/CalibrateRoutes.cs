using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LinearReferencingTools
{
	/// <summary>
	/// <para>Calibrate Routes</para>
	/// <para>校准路径</para>
	/// <para>使用点重新计算路径测量值。</para>
	/// </summary>
	public class CalibrateRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>要校准的路径要素。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。该字段可以是数值或字符。</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>用于校准路径的点要素。</para>
		/// </param>
		/// <param name="PointIdField">
		/// <para>Point Identifier Field</para>
		/// <para>标识包含每个校准点所在的路径的字段。该字段中的值与路径标识符字段中的值相匹配。该字段可以是数值或字符。</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>包含每个校准点的测量值的字段。该字段必须为数值型。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Route Feature Class</para>
		/// <para>待创建的要素类。它可以是 shapefile，也可以是地理数据库要素类。</para>
		/// </param>
		public CalibrateRoutes(object InRouteFeatures, object RouteIdField, object InPointFeatures, object PointIdField, object MeasureField, object OutFeatureClass)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.RouteIdField = RouteIdField;
			this.InPointFeatures = InPointFeatures;
			this.PointIdField = PointIdField;
			this.MeasureField = MeasureField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 校准路径</para>
		/// </summary>
		public override string DisplayName() => "校准路径";

		/// <summary>
		/// <para>Tool Name : CalibrateRoutes</para>
		/// </summary>
		public override string ToolName() => "CalibrateRoutes";

		/// <summary>
		/// <para>Tool Excute Name : lr.CalibrateRoutes</para>
		/// </summary>
		public override string ExcuteName() => "lr.CalibrateRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Linear Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Linear Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : lr</para>
		/// </summary>
		public override string ToolboxAlise() => "lr";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "ZDomain", "configKeyword", "extent", "outputCoordinateSystem", "outputZFlag", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, RouteIdField, InPointFeatures, PointIdField, MeasureField, OutFeatureClass, CalibrateMethod, SearchRadius, InterpolateBetween, ExtrapolateBefore, ExtrapolateAfter, IgnoreGaps, KeepAllRoutes, BuildIndex };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>要校准的路径要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。该字段可以是数值或字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>用于校准路径的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Point Identifier Field</para>
		/// <para>标识包含每个校准点所在的路径的字段。该字段中的值与路径标识符字段中的值相匹配。该字段可以是数值或字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object PointIdField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>包含每个校准点的测量值的字段。该字段必须为数值型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>Output Route Feature Class</para>
		/// <para>待创建的要素类。它可以是 shapefile，也可以是地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Measure Calculation Method</para>
		/// <para>指定如何重新计算路径测量值。</para>
		/// <para>距离—使用校准点之间的最短路径距离重新计算测量值。这是默认设置。</para>
		/// <para>测量值—使用校准点之间预先存在的测量距离重新计算测量值。</para>
		/// <para><see cref="CalibrateMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CalibrateMethod { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>通过指定距离及其测量单位来限制校准点与路径的最大距离。如果测量单位是“未知”，则使用路径要素类的坐标系单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchRadius { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Interpolate between calibration points</para>
		/// <para>指定是否在校准点之间内插测量值。</para>
		/// <para>选中 - 在校准点之间执行内插。这是默认设置。</para>
		/// <para>未选中 - 不在校准点之间执行内插。</para>
		/// <para><see cref="InterpolateBetweenEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InterpolateBetween { get; set; } = "true";

		/// <summary>
		/// <para>Extrapolate before calibration points</para>
		/// <para>指定是否在校准点之前外推测量值。</para>
		/// <para>选中 - 在校准点之前执行外推。这是默认设置。</para>
		/// <para>未选中 - 不在校准点之前执行外推。</para>
		/// <para><see cref="ExtrapolateBeforeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExtrapolateBefore { get; set; } = "true";

		/// <summary>
		/// <para>Extrapolate after calibration points</para>
		/// <para>指定是否在校准点之后外推测量值。</para>
		/// <para>选中 - 在校准点之后执行外推。这是默认设置。</para>
		/// <para>未选中 - 不在校准点之后执行外推。</para>
		/// <para><see cref="ExtrapolateAfterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExtrapolateAfter { get; set; } = "true";

		/// <summary>
		/// <para>Ignore spatial gaps</para>
		/// <para>指定在重新计算不相交路径上的测量值时是否忽略空间间距。</para>
		/// <para>选中 - 忽略空间间距。不相交路径的测量值将是连续的。这是默认设置。</para>
		/// <para>未选中 - 不忽略空间间距。不相交路径的测量值将有间距。将使用不相交部分的端点间的直线距离来计算间距。</para>
		/// <para><see cref="IgnoreGapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreGaps { get; set; } = "true";

		/// <summary>
		/// <para>Include all features in the output feature class</para>
		/// <para>指定是否在输出要素类中排除不含校准点的路径要素。</para>
		/// <para>选中 - 在输出要素类中保留所有路径要素。这是默认设置。</para>
		/// <para>未选中 - 在输出要素类中不保留所有路径要素。不含校准点的要素将被排除。</para>
		/// <para><see cref="KeepAllRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object KeepAllRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Build index</para>
		/// <para>指定是否为写入输出路径要素类的路径标识符字段创建属性索引。</para>
		/// <para>选中 - 创建属性索引。这是默认设置。</para>
		/// <para>未选中 - 不创建属性索引。</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalibrateRoutes SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object ZDomain = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object outputZFlag = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Measure Calculation Method</para>
		/// </summary>
		public enum CalibrateMethodEnum 
		{
			/// <summary>
			/// <para>距离—使用校准点之间的最短路径距离重新计算测量值。这是默认设置。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离")]
			Distance,

			/// <summary>
			/// <para>测量值—使用校准点之间预先存在的测量距离重新计算测量值。</para>
			/// </summary>
			[GPValue("MEASURES")]
			[Description("测量值")]
			Measures,

		}

		/// <summary>
		/// <para>Interpolate between calibration points</para>
		/// </summary>
		public enum InterpolateBetweenEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BETWEEN")]
			BETWEEN,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BETWEEN")]
			NO_BETWEEN,

		}

		/// <summary>
		/// <para>Extrapolate before calibration points</para>
		/// </summary>
		public enum ExtrapolateBeforeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BEFORE")]
			BEFORE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BEFORE")]
			NO_BEFORE,

		}

		/// <summary>
		/// <para>Extrapolate after calibration points</para>
		/// </summary>
		public enum ExtrapolateAfterEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AFTER")]
			AFTER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AFTER")]
			NO_AFTER,

		}

		/// <summary>
		/// <para>Ignore spatial gaps</para>
		/// </summary>
		public enum IgnoreGapsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE")]
			IGNORE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_IGNORE")]
			NO_IGNORE,

		}

		/// <summary>
		/// <para>Include all features in the output feature class</para>
		/// </summary>
		public enum KeepAllRoutesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP")]
			KEEP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

		}

		/// <summary>
		/// <para>Build index</para>
		/// </summary>
		public enum BuildIndexEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX")]
			INDEX,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX")]
			NO_INDEX,

		}

#endregion
	}
}
