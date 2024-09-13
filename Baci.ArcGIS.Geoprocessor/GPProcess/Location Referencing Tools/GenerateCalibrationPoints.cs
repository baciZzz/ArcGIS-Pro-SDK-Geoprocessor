using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Generate Calibration Points</para>
	/// <para>生成校准点</para>
	/// <para>为所提供的任何路径形状生成校准点，包括自闭合、自相交和分支路径等复杂形状。</para>
	/// </summary>
	public class GenerateCalibrationPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolylineFeatures">
		/// <para>Input Polyline Features</para>
		/// <para>将用作计算校准点测量值的源的要素。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。 字段类型必须与校准点要素类中的 Route ID 字段匹配。</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>包含路径的开始日期值的字段。</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>包含路径的结束日期值的字段。</para>
		/// </param>
		/// <param name="InCalibrationPointFeatureClass">
		/// <para>Calibration Point Feature Class</para>
		/// <para>要添加新要素的现有校准点要素类。</para>
		/// </param>
		/// <param name="LrsNetwork">
		/// <para>LRS Network</para>
		/// <para>需要在校准点要素类中生成测量值的 LRS 网络。</para>
		/// </param>
		public GenerateCalibrationPoints(object InPolylineFeatures, object RouteIdField, object FromDateField, object ToDateField, object InCalibrationPointFeatureClass, object LrsNetwork)
		{
			this.InPolylineFeatures = InPolylineFeatures;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.InCalibrationPointFeatureClass = InCalibrationPointFeatureClass;
			this.LrsNetwork = LrsNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成校准点</para>
		/// </summary>
		public override string DisplayName() => "生成校准点";

		/// <summary>
		/// <para>Tool Name : GenerateCalibrationPoints</para>
		/// </summary>
		public override string ToolName() => "GenerateCalibrationPoints";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateCalibrationPoints</para>
		/// </summary>
		public override string ExcuteName() => "locref.GenerateCalibrationPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolylineFeatures, RouteIdField, FromDateField, ToDateField, InCalibrationPointFeatureClass, LrsNetwork, CalibrationDirection!, CalibrationMethod!, OutCalibrationPointFeatureClass!, OutDetailsFile!, FromMeasureField!, ToMeasureField! };

		/// <summary>
		/// <para>Input Polyline Features</para>
		/// <para>将用作计算校准点测量值的源的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。 字段类型必须与校准点要素类中的 Route ID 字段匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>包含路径的开始日期值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>包含路径的结束日期值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point Feature Class</para>
		/// <para>要添加新要素的现有校准点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InCalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>LRS Network</para>
		/// <para>需要在校准点要素类中生成测量值的 LRS 网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsNetwork { get; set; }

		/// <summary>
		/// <para>Calibration Direction</para>
		/// <para>指定创建校准点时在路径上增加校准的方向。</para>
		/// <para>数字化方向—输入折线要素参数值的数字化方向决定了路径的校准方向。 这是默认设置。</para>
		/// <para>测量方向—输入折线要素参数值的 m 值增加的方向决定了路径的校准方向。如果输入折线要素参数值不包括 m 值，则将使用数字化方向。</para>
		/// <para><see cref="CalibrationDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationDirection { get; set; } = "DIGITIZED_DIRECTION";

		/// <summary>
		/// <para>Calibration Method</para>
		/// <para>指定在创建校准点时用于确定路径上的测量值的方法。</para>
		/// <para>几何长度—输入路径要素的几何长度将用作校准方法。 这是默认设置。</para>
		/// <para>路径上的 M—输入路径要素上的测量值将用作校准方法。</para>
		/// <para>属性字段—存储在输入路径要素属性字段中的测量值将用作校准方法。</para>
		/// <para><see cref="CalibrationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationMethod { get; set; } = "GEOMETRY_LENGTH";

		/// <summary>
		/// <para>Updated Calibration Point Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutCalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>From Measure Field</para>
		/// <para>包含所选路径的测量始于值的字段。</para>
		/// <para>当将校准方法参数设置为属性字段时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? FromMeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>包含所选路径的测量止于值的字段。</para>
		/// <para>当将校准方法参数设置为属性字段时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCalibrationPoints SetEnviroment(object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibration Direction</para>
		/// </summary>
		public enum CalibrationDirectionEnum 
		{
			/// <summary>
			/// <para>数字化方向—输入折线要素参数值的数字化方向决定了路径的校准方向。 这是默认设置。</para>
			/// </summary>
			[GPValue("DIGITIZED_DIRECTION")]
			[Description("数字化方向")]
			Digitized_direction,

			/// <summary>
			/// <para>测量方向—输入折线要素参数值的 m 值增加的方向决定了路径的校准方向。如果输入折线要素参数值不包括 m 值，则将使用数字化方向。</para>
			/// </summary>
			[GPValue("MEASURE_DIRECTION")]
			[Description("测量方向")]
			Measure_direction,

		}

		/// <summary>
		/// <para>Calibration Method</para>
		/// </summary>
		public enum CalibrationMethodEnum 
		{
			/// <summary>
			/// <para>几何长度—输入路径要素的几何长度将用作校准方法。 这是默认设置。</para>
			/// </summary>
			[GPValue("GEOMETRY_LENGTH")]
			[Description("几何长度")]
			Geometry_length,

			/// <summary>
			/// <para>路径上的 M—输入路径要素上的测量值将用作校准方法。</para>
			/// </summary>
			[GPValue("M_ON_ROUTE")]
			[Description("路径上的 M")]
			M_on_route,

			/// <summary>
			/// <para>属性字段—存储在输入路径要素属性字段中的测量值将用作校准方法。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_FIELDS")]
			[Description("属性字段")]
			Attribute_fields,

		}

#endregion
	}
}
