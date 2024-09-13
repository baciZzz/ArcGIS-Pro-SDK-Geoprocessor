using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Calculate Field</para>
	/// <para>计算字段</para>
	/// <para>可使用计算的字段值创建图层。</para>
	/// </summary>
	public class CalculateField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将计算字段的输入要素。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>包含已计算字段的新数据集。</para>
		/// </param>
		/// <param name="FieldToCalculate">
		/// <para>Field to Calculate</para>
		/// <para>指定是否为新创建字段或现有字段计算值。</para>
		/// <para>新建字段—将为新创建字段计算值。</para>
		/// <para>现有字段—将为现有字段计算值。</para>
		/// <para><see cref="FieldToCalculateEnum"/></para>
		/// </param>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>计算字段中的值。以 Arcade 格式写入表达式，其中可包括 [+ - * / ] 运算符和多个字段。将应用经计算的值，且采用输入空间参考的单位，除非您所使用的是地理坐标系，在这种情况下，单位为米。</para>
		/// </param>
		public CalculateField(object InputLayer, object Output, object FieldToCalculate, object Expression)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
			this.FieldToCalculate = FieldToCalculate;
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算字段</para>
		/// </summary>
		public override string DisplayName() => "计算字段";

		/// <summary>
		/// <para>Tool Name : CalculateField</para>
		/// </summary>
		public override string ToolName() => "CalculateField";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CalculateField</para>
		/// </summary>
		public override string ExcuteName() => "gapro.CalculateField";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, Output, FieldToCalculate, FieldName, ExistingField, FieldType, Expression, TrackAware, TrackFields, TimeBoundarySplit, TimeBoundaryReference };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将计算字段的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>包含已计算字段的新数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Field to Calculate</para>
		/// <para>指定是否为新创建字段或现有字段计算值。</para>
		/// <para>新建字段—将为新创建字段计算值。</para>
		/// <para>现有字段—将为现有字段计算值。</para>
		/// <para><see cref="FieldToCalculateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldToCalculate { get; set; } = "NEW_FIELD";

		/// <summary>
		/// <para>New Field Name</para>
		/// <para>将计算值的新字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Existing Field</para>
		/// <para>将计算值的现有字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object ExistingField { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定已计算字段的字段类型。</para>
		/// <para>字符串—任何字符串</para>
		/// <para>整型—整数</para>
		/// <para>双精度型— 小数</para>
		/// <para>日期型— 日期型</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>计算字段中的值。以 Arcade 格式写入表达式，其中可包括 [+ - * / ] 运算符和多个字段。将应用经计算的值，且采用输入空间参考的单位，除非您所使用的是地理坐标系，在这种情况下，单位为米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Track Aware</para>
		/// <para>指定表达式是否会使用追踪感知型表达式。</para>
		/// <para>选中 - 表达式将使用追踪感知型表达式，且必须指定追踪字段。</para>
		/// <para>未选中 - 表达式不会使用追踪感知型表达式。这是默认设置。</para>
		/// <para><see cref="TrackAwareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TrackAware { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>用于分割输入数据以进行分析的时间跨度。您可通过时间界限分析定义的时间跨度内的值。例如，如果您使用 1 天的时间界限，并将时间界限参考设置为 1980 年 1 月 1 日，则轨迹将在每天开始时被分割。</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>用于分割输入数据以进行分析的参考时间。将为整个数据跨度创建时间界限，且不需要在开始时产生参考时间。如果未指定参考时间，则将使用 1970 年 1 月 1 日。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateField SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field to Calculate</para>
		/// </summary>
		public enum FieldToCalculateEnum 
		{
			/// <summary>
			/// <para>新建字段—将为新创建字段计算值。</para>
			/// </summary>
			[GPValue("NEW_FIELD")]
			[Description("新建字段")]
			New_field,

			/// <summary>
			/// <para>现有字段—将为现有字段计算值。</para>
			/// </summary>
			[GPValue("EXISTING_FIELD")]
			[Description("现有字段")]
			Existing_field,

		}

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>日期型— 日期型</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期型")]
			Date,

			/// <summary>
			/// <para>双精度型— 小数</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型")]
			Double,

			/// <summary>
			/// <para>整型—整数</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("整型")]
			Integer,

			/// <summary>
			/// <para>字符串—任何字符串</para>
			/// </summary>
			[GPValue("STRING")]
			[Description("字符串")]
			String,

		}

		/// <summary>
		/// <para>Track Aware</para>
		/// </summary>
		public enum TrackAwareEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACK_AWARE")]
			TRACK_AWARE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_TRACK_AWARE")]
			NOT_TRACK_AWARE,

		}

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// </summary>
		public enum TimeBoundarySplitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

#endregion
	}
}
