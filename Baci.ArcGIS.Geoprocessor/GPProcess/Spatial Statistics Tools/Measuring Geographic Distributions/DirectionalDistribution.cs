using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Directional Distribution (Standard Deviational Ellipse)</para>
	/// <para>方向分布（标准差椭圆）</para>
	/// <para>创建标准差椭圆或椭圆体来汇总地理要素的空间特征：中心趋势、离散和方向趋势。</para>
	/// </summary>
	public class DirectionalDistribution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>要计算标准差椭圆或椭圆体的要素分布所在的要素类。</para>
		/// </param>
		/// <param name="OutputEllipseFeatureClass">
		/// <para>Output Ellipse Feature Class</para>
		/// <para>包含输出椭圆要素的面要素类。</para>
		/// </param>
		/// <param name="EllipseSize">
		/// <para>Ellipse Size</para>
		/// <para>标准差中输出椭圆的大小。默认椭圆大小为 1；可供选择的选项为 1、2 或 3 标准差。</para>
		/// <para>1 标准差—1 标准差</para>
		/// <para>2 标准差—2 标准差</para>
		/// <para>3 标准差—3 标准差</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </param>
		public DirectionalDistribution(object InputFeatureClass, object OutputEllipseFeatureClass, object EllipseSize)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputEllipseFeatureClass = OutputEllipseFeatureClass;
			this.EllipseSize = EllipseSize;
		}

		/// <summary>
		/// <para>Tool Display Name : 方向分布（标准差椭圆）</para>
		/// </summary>
		public override string DisplayName() => "方向分布（标准差椭圆）";

		/// <summary>
		/// <para>Tool Name : DirectionalDistribution</para>
		/// </summary>
		public override string ToolName() => "DirectionalDistribution";

		/// <summary>
		/// <para>Tool Excute Name : stats.DirectionalDistribution</para>
		/// </summary>
		public override string ExcuteName() => "stats.DirectionalDistribution";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputEllipseFeatureClass, EllipseSize, WeightField, CaseField };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>要计算标准差椭圆或椭圆体的要素分布所在的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Ellipse Feature Class</para>
		/// <para>包含输出椭圆要素的面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputEllipseFeatureClass { get; set; }

		/// <summary>
		/// <para>Ellipse Size</para>
		/// <para>标准差中输出椭圆的大小。默认椭圆大小为 1；可供选择的选项为 1、2 或 3 标准差。</para>
		/// <para>1 标准差—1 标准差</para>
		/// <para>2 标准差—2 标准差</para>
		/// <para>3 标准差—3 标准差</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EllipseSize { get; set; } = "1_STANDARD_DEVIATION";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>根据各位置的相对重要性对它们进行加权的数值型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Case Field</para>
		/// <para>对要素进行分组以分别计算方向分布的字段。案例分组字段可以为整型、日期型或字符串型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DirectionalDistribution SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ellipse Size</para>
		/// </summary>
		public enum EllipseSizeEnum 
		{
			/// <summary>
			/// <para>1 标准差—1 标准差</para>
			/// </summary>
			[GPValue("1_STANDARD_DEVIATION")]
			[Description("1 标准差")]
			_1_standard_deviation,

			/// <summary>
			/// <para>2 标准差—2 标准差</para>
			/// </summary>
			[GPValue("2_STANDARD_DEVIATIONS")]
			[Description("2 标准差")]
			_2_standard_deviations,

			/// <summary>
			/// <para>3 标准差—3 标准差</para>
			/// </summary>
			[GPValue("3_STANDARD_DEVIATIONS")]
			[Description("3 标准差")]
			_3_standard_deviations,

		}

#endregion
	}
}
