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
	/// <para>Create Routes</para>
	/// <para>创建路径</para>
	/// <para>根据现有的线创建路径。 合并共享通用标识符的输入线要素以创建单个路径。</para>
	/// </summary>
	public class CreateRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>将创建路径的要素。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Route Feature Class</para>
		/// <para>待创建的要素类。 可以是 shapefile 或地理数据库要素类。</para>
		/// </param>
		/// <param name="MeasureSource">
		/// <para>Measure Source</para>
		/// <para>指定如何获取路径测量值。</para>
		/// <para>要素的长度—使用输入要素的几何长度累积测量值。 这是默认设置。</para>
		/// <para>值来自单个字段—使用单个字段中存储的值累积测量值。</para>
		/// <para>值来自两个字段—使用“测量始于字段”和“测量止于字段”中存储的值设置测量值。</para>
		/// <para><see cref="MeasureSourceEnum"/></para>
		/// </param>
		public CreateRoutes(object InLineFeatures, object RouteIdField, object OutFeatureClass, object MeasureSource)
		{
			this.InLineFeatures = InLineFeatures;
			this.RouteIdField = RouteIdField;
			this.OutFeatureClass = OutFeatureClass;
			this.MeasureSource = MeasureSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建路径</para>
		/// </summary>
		public override string DisplayName() => "创建路径";

		/// <summary>
		/// <para>Tool Name : CreateRoutes</para>
		/// </summary>
		public override string ToolName() => "CreateRoutes";

		/// <summary>
		/// <para>Tool Excute Name : lr.CreateRoutes</para>
		/// </summary>
		public override string ExcuteName() => "lr.CreateRoutes";

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
		public override object[] Parameters() => new object[] { InLineFeatures, RouteIdField, OutFeatureClass, MeasureSource, FromMeasureField!, ToMeasureField!, CoordinatePriority!, MeasureFactor!, MeasureOffset!, IgnoreGaps!, BuildIndex! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>将创建路径的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Output Route Feature Class</para>
		/// <para>待创建的要素类。 可以是 shapefile 或地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Measure Source</para>
		/// <para>指定如何获取路径测量值。</para>
		/// <para>要素的长度—使用输入要素的几何长度累积测量值。 这是默认设置。</para>
		/// <para>值来自单个字段—使用单个字段中存储的值累积测量值。</para>
		/// <para>值来自两个字段—使用“测量始于字段”和“测量止于字段”中存储的值设置测量值。</para>
		/// <para><see cref="MeasureSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MeasureSource { get; set; } = "LENGTH";

		/// <summary>
		/// <para>From-Measure Field</para>
		/// <para>包含测量值的字段。 此字段必须为数值，并且当测量源为来自单个字段的值或来自两个字段的值时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object? FromMeasureField { get; set; }

		/// <summary>
		/// <para>To-Measure Field</para>
		/// <para>包含测量值的字段。 此字段必须为数值，并且当测量源为来自两个字段的值时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Coordinate Priority</para>
		/// <para>用于为每条输出路径累积测量值的位置。 当测量源为来自两个字段的值时，将忽略此参数。</para>
		/// <para>左上角—从最接近最小外接矩形左上角的点累积测量值。 这是默认设置。</para>
		/// <para>左下角—从最接近最小外接矩形左下角的点累积测量值。</para>
		/// <para>右上角—从最接近最小外接矩形右上角的点累积测量值。</para>
		/// <para>右下角—从最接近最小外接矩形右下角的点累积测量值。</para>
		/// <para><see cref="CoordinatePriorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CoordinatePriority { get; set; } = "UPPER_LEFT";

		/// <summary>
		/// <para>Measure Factor</para>
		/// <para>合并输入线创建路径测量值之前，每条输入线的测量长度乘以的值。 默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MeasureFactor { get; set; } = "1";

		/// <summary>
		/// <para>Measure Offset</para>
		/// <para>合并输入线创建路径后，加到路径测量值的值。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MeasureOffset { get; set; } = "0";

		/// <summary>
		/// <para>Ignore spatial gaps</para>
		/// <para>指定在计算不相交路径上的测量值时是否忽略空间间距。 此参数适用于测量源是要素长度或值来自单个字段的情况。</para>
		/// <para>选中 - 忽略空间间距。 不相交路径的测量值将是连续的。 这是默认设置。</para>
		/// <para>未选中 - 不忽略空间间距。 不相交路径的测量值将有间距。 间距距离通过不相交部分端点之间的直线距离进行计算。</para>
		/// <para><see cref="IgnoreGapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreGaps { get; set; } = "true";

		/// <summary>
		/// <para>Build index</para>
		/// <para>指定是否为写入输出路径要素类的路径标识符字段创建属性索引。</para>
		/// <para>选中 - 创建属性索引。 这是默认设置。</para>
		/// <para>未选中 - 不创建属性索引。</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRoutes SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? ZDomain = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputZFlag = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Measure Source</para>
		/// </summary>
		public enum MeasureSourceEnum 
		{
			/// <summary>
			/// <para>要素的长度—使用输入要素的几何长度累积测量值。 这是默认设置。</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("要素的长度")]
			Length_of_features,

			/// <summary>
			/// <para>值来自单个字段—使用单个字段中存储的值累积测量值。</para>
			/// </summary>
			[GPValue("ONE_FIELD")]
			[Description("值来自单个字段")]
			Values_from_a_single_field,

			/// <summary>
			/// <para>值来自两个字段—使用“测量始于字段”和“测量止于字段”中存储的值设置测量值。</para>
			/// </summary>
			[GPValue("TWO_FIELDS")]
			[Description("值来自两个字段")]
			Values_from_two_fields,

		}

		/// <summary>
		/// <para>Coordinate Priority</para>
		/// </summary>
		public enum CoordinatePriorityEnum 
		{
			/// <summary>
			/// <para>左上角—从最接近最小外接矩形左上角的点累积测量值。 这是默认设置。</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("左上角")]
			Upper_left_corner,

			/// <summary>
			/// <para>左下角—从最接近最小外接矩形左下角的点累积测量值。</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("左下角")]
			Lower_left_corner,

			/// <summary>
			/// <para>右上角—从最接近最小外接矩形右上角的点累积测量值。</para>
			/// </summary>
			[GPValue("UPPER_RIGHT")]
			[Description("右上角")]
			Upper_right_corner,

			/// <summary>
			/// <para>右下角—从最接近最小外接矩形右下角的点累积测量值。</para>
			/// </summary>
			[GPValue("LOWER_RIGHT")]
			[Description("右下角")]
			Lower_right_corner,

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
