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
	/// <para>Generate Blind Spot Areas</para>
	/// <para>生成盲区</para>
	/// <para>可基于开始和结束时间，为输入情报、监测、侦察 (ISR) 或巡逻可见缓冲区要素创建输出不可见区域或盲区。 输出盲点图层与时间滑块配合使用，以可视化并浏览在特定时间对 ISR 或巡逻资产不可见的区域。</para>
	/// </summary>
	public class GenerateBlindSpotAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入可见缓冲区要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Features</para>
		/// <para>输出盲点区域要素。</para>
		/// </param>
		public GenerateBlindSpotAreas(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成盲区</para>
		/// </summary>
		public override string DisplayName() => "生成盲区";

		/// <summary>
		/// <para>Tool Name : GenerateBlindSpotAreas</para>
		/// </summary>
		public override string ToolName() => "GenerateBlindSpotAreas";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateBlindSpotAreas</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateBlindSpotAreas";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, ClipFeatures, StartTimeField, EndTimeField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入可见缓冲区要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出盲点区域要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>要素用于定义输入边界。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object ClipFeatures { get; set; }

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>字段包含资产可用的起始日期和时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object StartTimeField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>字段包含资产不再可用的结束日期和时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object EndTimeField { get; set; }

	}
}
