using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Generate Range Rings From Lookup Table</para>
	/// <para>根据查找表生成范围环</para>
	/// <para>通过基于在查找表中存储的值的中心创建一组同心圆。</para>
	/// </summary>
	public class GenerateRangeRingsFromTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features (Center Points)</para>
		/// <para>点要素集用于标识范围环的中心点。输入必须至少具有一个点。</para>
		/// </param>
		/// <param name="InTable">
		/// <para>Input Lookup Table</para>
		/// <para>输入表包含用于创建环的值。</para>
		/// </param>
		/// <param name="OutFeatureClassRings">
		/// <para>Output Feature Class (Rings)</para>
		/// <para>包含环要素的输出要素类。</para>
		/// </param>
		/// <param name="LookupName">
		/// <para>Selected Name</para>
		/// <para>输入查找表中包含最小和最大值或环的数量和间隔的输入值的行。</para>
		/// </param>
		/// <param name="RangeRingsType">
		/// <para>Range Ring Type</para>
		/// <para>指定用于创建范围环的方法。</para>
		/// <para>间隔—将根据环的数量以及环之间的距离来生成范围环。这是默认设置。</para>
		/// <para>最小值和最大值—将基于最小距离和最大距离生成范围环。</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </param>
		public GenerateRangeRingsFromTable(object InFeatures, object InTable, object OutFeatureClassRings, object LookupName, object RangeRingsType)
		{
			this.InFeatures = InFeatures;
			this.InTable = InTable;
			this.OutFeatureClassRings = OutFeatureClassRings;
			this.LookupName = LookupName;
			this.RangeRingsType = RangeRingsType;
		}

		/// <summary>
		/// <para>Tool Display Name : 根据查找表生成范围环</para>
		/// </summary>
		public override string DisplayName() => "根据查找表生成范围环";

		/// <summary>
		/// <para>Tool Name : GenerateRangeRingsFromTable</para>
		/// </summary>
		public override string ToolName() => "GenerateRangeRingsFromTable";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeRingsFromTable</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateRangeRingsFromTable";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InTable, OutFeatureClassRings, LookupName, RangeRingsType, OutFeatureClassRadials, NumberOfRadials, DistanceUnits, LookupNameField, MinRangeField, MaxRangeField, NumberOfRingsField, RingIntervalField };

		/// <summary>
		/// <para>Input Features (Center Points)</para>
		/// <para>点要素集用于标识范围环的中心点。输入必须至少具有一个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Lookup Table</para>
		/// <para>输入表包含用于创建环的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class (Rings)</para>
		/// <para>包含环要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClassRings { get; set; }

		/// <summary>
		/// <para>Selected Name</para>
		/// <para>输入查找表中包含最小和最大值或环的数量和间隔的输入值的行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LookupName { get; set; }

		/// <summary>
		/// <para>Range Ring Type</para>
		/// <para>指定用于创建范围环的方法。</para>
		/// <para>间隔—将根据环的数量以及环之间的距离来生成范围环。这是默认设置。</para>
		/// <para>最小值和最大值—将基于最小距离和最大距离生成范围环。</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RangeRingsType { get; set; } = "INTERVAL";

		/// <summary>
		/// <para>Output Feature Class (Radials)</para>
		/// <para>包含输出射线要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatureClassRadials { get; set; }

		/// <summary>
		/// <para>Number of Radials</para>
		/// <para>要创建的射线数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfRadials { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>指定环间隔字段参数或输入表最小范围和输入表最大范围参数的线性测量单位。</para>
		/// <para>米—单位将为米。这是默认设置。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>美国测量英尺—单位将为美国测量英尺。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Input Table Selected Name Field</para>
		/// <para>输入表中包含所选名称值的字段。默认字段名称为 Name。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[Category("Input Table Options")]
		public object LookupNameField { get; set; } = "Name";

		/// <summary>
		/// <para>Input Table Minimum Range</para>
		/// <para>输入表中包含最小范围值的字段。默认字段名称为 Min。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		[Category("Input Table Options")]
		public object MinRangeField { get; set; } = "Min";

		/// <summary>
		/// <para>Input Table Maximum Range</para>
		/// <para>输入表中包含最大范围值的字段。默认字段名称为 Max。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		[Category("Input Table Options")]
		public object MaxRangeField { get; set; } = "Max";

		/// <summary>
		/// <para>Number of Rings Field</para>
		/// <para>输入表中包含环数值的字段。默认字段名称为 Rings。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		[Category("Input Table Options")]
		public object NumberOfRingsField { get; set; } = "Rings";

		/// <summary>
		/// <para>Ring Interval Field</para>
		/// <para>输入表中包含环间隔值的字段。默认字段名称为 Interval。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		[Category("Input Table Options")]
		public object RingIntervalField { get; set; } = "Intervals";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeRingsFromTable SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Range Ring Type</para>
		/// </summary>
		public enum RangeRingsTypeEnum 
		{
			/// <summary>
			/// <para>间隔—将根据环的数量以及环之间的距离来生成范围环。这是默认设置。</para>
			/// </summary>
			[GPValue("INTERVAL")]
			[Description("间隔")]
			Interval,

			/// <summary>
			/// <para>最小值和最大值—将基于最小距离和最大距离生成范围环。</para>
			/// </summary>
			[GPValue("MIN_MAX")]
			[Description("最小值和最大值")]
			Minimum_and_maximum,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>米—单位将为米。这是默认设置。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—单位将为公里。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英里—单位将为英里。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—单位将为海里。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("海里")]
			Nautical_miles,

			/// <summary>
			/// <para>英尺—单位将为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>美国测量英尺—单位将为美国测量英尺。</para>
			/// </summary>
			[GPValue("US_SURVEY_FEET")]
			[Description("美国测量英尺")]
			US_survey_feet,

		}

#endregion
	}
}
