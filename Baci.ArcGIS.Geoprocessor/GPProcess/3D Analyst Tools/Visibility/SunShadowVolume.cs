using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Sun Shadow Volume</para>
	/// <para>太阳阴影体</para>
	/// <para>利用每个要素在给定日期和时间的光照条件下所投射出的模型阴影来创建闭合体。</para>
	/// </summary>
	public class SunShadowVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>用于模拟阴影的多面体要素。如果面要素和线要素添加为一个拉伸 3D 图层，则也可使用它们。</para>
		/// </param>
		/// <param name="StartDateAndTime">
		/// <para>Start Date and Time</para>
		/// <para>将计算阳光轨线来对阴影进行建模的日期和时间。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>存储生成的阴影体的多面体要素类。</para>
		/// </param>
		public SunShadowVolume(object InFeatures, object StartDateAndTime, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.StartDateAndTime = StartDateAndTime;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 太阳阴影体</para>
		/// </summary>
		public override string DisplayName() => "太阳阴影体";

		/// <summary>
		/// <para>Tool Name : SunShadowVolume</para>
		/// </summary>
		public override string ToolName() => "SunShadowVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SunShadowVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.SunShadowVolume";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, StartDateAndTime, OutFeatureClass, AdjustedForDst!, TimeZone!, EndDateAndTime!, IterationInterval!, IterationUnit! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于模拟阴影的多面体要素。如果面要素和线要素添加为一个拉伸 3D 图层，则也可使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Start Date and Time</para>
		/// <para>将计算阳光轨线来对阴影进行建模的日期和时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object StartDateAndTime { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>存储生成的阴影体的多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Adjusted for Daylight Savings Time</para>
		/// <para>指定时间值是否调整为夏令时 (DST)。</para>
		/// <para>未选中 - 不遵守 DST。这是默认设置。</para>
		/// <para>选中 - 遵守 DST。</para>
		/// <para><see cref="AdjustedForDstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AdjustedForDst { get; set; } = "true";

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>参与输入所在的时区。默认设置是操作系统所设置的时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeZone { get; set; } = "Pacific_Standard_Time";

		/// <summary>
		/// <para>End Date and Time</para>
		/// <para>用于计算太阳位置的最终日期和时间。如果只提供一个日期，则假设最终时间为日落。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? EndDateAndTime { get; set; }

		/// <summary>
		/// <para>Iteration Interval</para>
		/// <para>用于定义从开始日期起的时间迭代的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? IterationInterval { get; set; } = "0";

		/// <summary>
		/// <para>Iteration Unit</para>
		/// <para>定义应用到起始日期和时间的迭代值的单位。</para>
		/// <para>天—迭代值将表示天数。这是默认设置。</para>
		/// <para>小时—迭代值将表示一个或几个小时。</para>
		/// <para>分—迭代值将表示一分钟或几分钟。</para>
		/// <para><see cref="IterationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IterationUnit { get; set; } = "DAYS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SunShadowVolume SetEnviroment(object? XYDomain = null, object? ZDomain = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Adjusted for Daylight Savings Time</para>
		/// </summary>
		public enum AdjustedForDstEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADJUSTED_FOR_DST")]
			ADJUSTED_FOR_DST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_ADJUSTED_FOR_DST")]
			NOT_ADJUSTED_FOR_DST,

		}

		/// <summary>
		/// <para>Iteration Unit</para>
		/// </summary>
		public enum IterationUnitEnum 
		{
			/// <summary>
			/// <para>天—迭代值将表示天数。这是默认设置。</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>小时—迭代值将表示一个或几个小时。</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>分—迭代值将表示一分钟或几分钟。</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("分")]
			Minutes,

		}

#endregion
	}
}
