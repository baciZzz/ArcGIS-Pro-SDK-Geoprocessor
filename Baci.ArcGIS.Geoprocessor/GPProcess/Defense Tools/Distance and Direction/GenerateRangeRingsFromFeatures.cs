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
	/// <para>Generate Range Rings From Features</para>
	/// <para>根据要素生成范围环</para>
	/// <para>将使用从点要素类中的字段派生的属性来创建范围环。</para>
	/// </summary>
	public class GenerateRangeRingsFromFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>点要素集用于标识范围环的中心点。输入必须至少具有一个点。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Range Ring Feature Class</para>
		/// <para>将含有输出环要素的要素类。</para>
		/// </param>
		/// <param name="RangeRingsType">
		/// <para>Range Ring Type</para>
		/// <para>指定将生成范围环的方式。</para>
		/// <para>间隔—将根据环的数量以及环之间的距离来生成范围环。这是默认设置。</para>
		/// <para>最小值和最大值—将基于最小距离和最大距离生成范围环。</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </param>
		public GenerateRangeRingsFromFeatures(object InFeatures, object OutputFeatureClass, object RangeRingsType)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.RangeRingsType = RangeRingsType;
		}

		/// <summary>
		/// <para>Tool Display Name : 根据要素生成范围环</para>
		/// </summary>
		public override string DisplayName() => "根据要素生成范围环";

		/// <summary>
		/// <para>Tool Name : GenerateRangeRingsFromFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateRangeRingsFromFeatures";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeRingsFromFeatures</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateRangeRingsFromFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatureClass, RangeRingsType, OutFeatureClassRadials, RadialCountField, MinRangeField, MaxRangeField, RingCountField, RingIntervalField, DistanceUnits };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>点要素集用于标识范围环的中心点。输入必须至少具有一个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Range Ring Feature Class</para>
		/// <para>将含有输出环要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Range Ring Type</para>
		/// <para>指定将生成范围环的方式。</para>
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
		/// <para>将包含输出径向要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatureClassRadials { get; set; }

		/// <summary>
		/// <para>Radial Count Field</para>
		/// <para>包含要创建的径向数的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object RadialCountField { get; set; }

		/// <summary>
		/// <para>Minimum Range Field</para>
		/// <para>包含从原点到内部环的距离值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		public object MinRangeField { get; set; }

		/// <summary>
		/// <para>Maximum Range Field</para>
		/// <para>包含从原点到外部环的距离值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		public object MaxRangeField { get; set; }

		/// <summary>
		/// <para>Ring Count Field</para>
		/// <para>包含要生成的环数的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object RingCountField { get; set; }

		/// <summary>
		/// <para>Ring Interval Field</para>
		/// <para>包含环之间的间隔值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		public object RingIntervalField { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>针对环间隔字段参数中的值或者最小范围字段和最大范围字段参数中的值，指定线性测量单位。</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeRingsFromFeatures SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
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
