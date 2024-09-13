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
	/// <para>Standard Distance</para>
	/// <para>标准距离</para>
	/// <para>测量要素在几何平均中心周围的集中或分散程度。</para>
	/// </summary>
	public class StandardDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>要计算标准距离的要素分布所在的要素类。</para>
		/// </param>
		/// <param name="OutputStandardDistanceFeatureClass">
		/// <para>Output Standard Distance Feature Class</para>
		/// <para>将包含每个输入中心的圆面的面要素类。这些圆面是以图形的方式描绘到每个中心点的标准距离。</para>
		/// </param>
		/// <param name="CircleSize">
		/// <para>Circle Size</para>
		/// <para>标准差中输出圆的大小。默认圆大小为 1；可供选择的选项为 1、2 或 3 标准差。</para>
		/// <para>1 标准差—1 标准差</para>
		/// <para>2 标准差—2 标准差</para>
		/// <para>3 标准差—3 标准差</para>
		/// <para><see cref="CircleSizeEnum"/></para>
		/// </param>
		public StandardDistance(object InputFeatureClass, object OutputStandardDistanceFeatureClass, object CircleSize)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputStandardDistanceFeatureClass = OutputStandardDistanceFeatureClass;
			this.CircleSize = CircleSize;
		}

		/// <summary>
		/// <para>Tool Display Name : 标准距离</para>
		/// </summary>
		public override string DisplayName() => "标准距离";

		/// <summary>
		/// <para>Tool Name : StandardDistance</para>
		/// </summary>
		public override string ToolName() => "StandardDistance";

		/// <summary>
		/// <para>Tool Excute Name : stats.StandardDistance</para>
		/// </summary>
		public override string ExcuteName() => "stats.StandardDistance";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputStandardDistanceFeatureClass, CircleSize, WeightField, CaseField };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>要计算标准距离的要素分布所在的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Standard Distance Feature Class</para>
		/// <para>将包含每个输入中心的圆面的面要素类。这些圆面是以图形的方式描绘到每个中心点的标准距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputStandardDistanceFeatureClass { get; set; }

		/// <summary>
		/// <para>Circle Size</para>
		/// <para>标准差中输出圆的大小。默认圆大小为 1；可供选择的选项为 1、2 或 3 标准差。</para>
		/// <para>1 标准差—1 标准差</para>
		/// <para>2 标准差—2 标准差</para>
		/// <para>3 标准差—3 标准差</para>
		/// <para><see cref="CircleSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CircleSize { get; set; } = "1_STANDARD_DEVIATION";

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
		/// <para>用于对要素进行分组以独立计算各个标准距离的字段。案例分组字段可以为整型、日期型或字符串型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StandardDistance SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Circle Size</para>
		/// </summary>
		public enum CircleSizeEnum 
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
