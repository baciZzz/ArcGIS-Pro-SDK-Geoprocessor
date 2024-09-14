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
	/// <para>Mean Center</para>
	/// <para>平均中心</para>
	/// <para>识别一组要素的地理中心（或密度中心）。</para>
	/// </summary>
	public class MeanCenter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将对其计算平均中心的要素类。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含用于表示输入要素类的平均中心的要素的点要素类。</para>
		/// </param>
		public MeanCenter(object InputFeatureClass, object OutputFeatureClass)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 平均中心</para>
		/// </summary>
		public override string DisplayName() => "平均中心";

		/// <summary>
		/// <para>Tool Name : MeanCenter</para>
		/// </summary>
		public override string ToolName() => "MeanCenter";

		/// <summary>
		/// <para>Tool Excute Name : stats.MeanCenter</para>
		/// </summary>
		public override string ExcuteName() => "stats.MeanCenter";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputFeatureClass, WeightField, CaseField, DimensionField };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将对其计算平均中心的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含用于表示输入要素类的平均中心的要素的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>用于创建加权平均中心的数字字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Case Field</para>
		/// <para>用于对要素进行分组以独立计算平均中心的字段。案例分组字段可以为整型、日期型或字符串型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object CaseField { get; set; }

		/// <summary>
		/// <para>Dimension Field</para>
		/// <para>此数值字段包含一些用于计算平均值的属性值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DimensionField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MeanCenter SetEnviroment(object MResolution = null, object MTolerance = null, object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
