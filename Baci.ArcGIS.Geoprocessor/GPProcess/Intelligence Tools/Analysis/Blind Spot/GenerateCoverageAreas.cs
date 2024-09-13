using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Generate Coverage Areas</para>
	/// <para>生成覆盖区</para>
	/// <para>可为输入情报、监测和侦察 (ISR) 或巡逻资产创建邻近缓冲区，以便在生成盲点区域工具中使用。</para>
	/// </summary>
	public class GenerateCoverageAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入资产要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Blind Spot Buffer</para>
		/// <para>输出盲点缓冲区要素。</para>
		/// </param>
		/// <param name="BufferType">
		/// <para>Buffer Type</para>
		/// <para>与要缓冲的输入要素之间的距离。该距离可以用表示线性距离的某个值来指定，也可以用输入要素中的某个字段（定义用来对每个要素进行缓冲的各个范围和单位）来指定。</para>
		/// </param>
		public GenerateCoverageAreas(object InFeatures, object OutFeatureClass, object BufferType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferType = BufferType;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成覆盖区</para>
		/// </summary>
		public override string DisplayName() => "生成覆盖区";

		/// <summary>
		/// <para>Tool Name : GenerateCoverageAreas</para>
		/// </summary>
		public override string ToolName() => "GenerateCoverageAreas";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateCoverageAreas</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateCoverageAreas";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferType, RangeUnit, StartTimeField, EndTimeField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入资产要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Blind Spot Buffer</para>
		/// <para>输出盲点缓冲区要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Buffer Type</para>
		/// <para>与要缓冲的输入要素之间的距离。该距离可以用表示线性距离的某个值来指定，也可以用输入要素中的某个字段（定义用来对每个要素进行缓冲的各个范围和单位）来指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferType { get; set; }

		/// <summary>
		/// <para>Range Unit</para>
		/// <para>用于在所选缓冲区类型参数值不包含距离单位时指定线性单位。</para>
		/// <para>米—距离单位将为米。</para>
		/// <para>千米—距离单位将为公里。</para>
		/// <para>英尺—距离单位将为英尺。</para>
		/// <para>英里—距离单位将为英里。</para>
		/// <para>海里—距离单位将为海里。</para>
		/// <para><see cref="RangeUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RangeUnit { get; set; }

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>包含资产可用的起始日期和时间的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object StartTimeField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>包含资产不再可用的结束日期和时间的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object EndTimeField { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Range Unit</para>
		/// </summary>
		public enum RangeUnitEnum 
		{
			/// <summary>
			/// <para>米—距离单位将为米。</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—距离单位将为公里。</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—距离单位将为英尺。</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>英里—距离单位将为英里。</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—距离单位将为海里。</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("海里")]
			Nautical_Miles,

		}

#endregion
	}
}
