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
	/// <para>Median Center</para>
	/// <para>中位数中心</para>
	/// <para>识别使数据集中要素之间的总欧氏距离达到最小的位置点。</para>
	/// </summary>
	public class MedianCenter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将计算其中位数中心的要素类。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含用于表示输入要素类的中位数中心的要素的点要素类。</para>
		/// </param>
		public MedianCenter(object InputFeatureClass, object OutputFeatureClass)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 中位数中心</para>
		/// </summary>
		public override string DisplayName() => "中位数中心";

		/// <summary>
		/// <para>Tool Name : MedianCenter</para>
		/// </summary>
		public override string ToolName() => "MedianCenter";

		/// <summary>
		/// <para>Tool Excute Name : stats.MedianCenter</para>
		/// </summary>
		public override string ExcuteName() => "stats.MedianCenter";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputFeatureClass, WeightField!, CaseField!, AttributeField! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将计算其中位数中心的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含用于表示输入要素类的中位数中心的要素的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>用于创建加权中位数中心的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Case Field</para>
		/// <para>用于对要素进行分组以独立计算中位数中心的字段。案例分组字段可以为整型、日期型或字符串型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object? CaseField { get; set; }

		/// <summary>
		/// <para>Attribute Field</para>
		/// <para>将对其计算数据中值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? AttributeField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MedianCenter SetEnviroment(double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
