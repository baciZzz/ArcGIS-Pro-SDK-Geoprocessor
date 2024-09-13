using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Summarize Percent Change</para>
	/// <para>汇总百分比变化</para>
	/// <para>用于计算与点要素相对应的要素的变化，这些点要素表示两个相等的比较时间段。</para>
	/// </summary>
	public class SummarizePercentChange : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input  Features</para>
		/// <para>将对其中的比较时间段进行计数和比较的重合要素。</para>
		/// </param>
		/// <param name="InCurrentFeatures">
		/// <para>Input Current Period Point Features</para>
		/// <para>已过滤到最近比较时间段的点要素。</para>
		/// <para>例如，上一个 14 天的犯罪。</para>
		/// </param>
		/// <param name="InPreviousFeatures">
		/// <para>Input Previous Period Point Features</para>
		/// <para>已过滤到当前时间段的上一时间段的点要素。此时间段与当前时间段的长度必须相等，才能提供精确的比较。</para>
		/// <para>例如，如果当前时间段包含从 1 月 15 日到 1 月 28 日的要素，则上一个时间段应包含从 1 月 1 日到 1 月 14 日的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类，包含时间段比较的差异计数和百分比变化计算。</para>
		/// </param>
		public SummarizePercentChange(object InFeatures, object InCurrentFeatures, object InPreviousFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.InCurrentFeatures = InCurrentFeatures;
			this.InPreviousFeatures = InPreviousFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总百分比变化</para>
		/// </summary>
		public override string DisplayName() => "汇总百分比变化";

		/// <summary>
		/// <para>Tool Name : SummarizePercentChange</para>
		/// </summary>
		public override string ToolName() => "SummarizePercentChange";

		/// <summary>
		/// <para>Tool Excute Name : ca.SummarizePercentChange</para>
		/// </summary>
		public override string ExcuteName() => "ca.SummarizePercentChange";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InCurrentFeatures, InPreviousFeatures, OutFeatureClass, SearchRadius };

		/// <summary>
		/// <para>Input  Features</para>
		/// <para>将对其中的比较时间段进行计数和比较的重合要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Current Period Point Features</para>
		/// <para>已过滤到最近比较时间段的点要素。</para>
		/// <para>例如，上一个 14 天的犯罪。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InCurrentFeatures { get; set; }

		/// <summary>
		/// <para>Input Previous Period Point Features</para>
		/// <para>已过滤到当前时间段的上一时间段的点要素。此时间段与当前时间段的长度必须相等，才能提供精确的比较。</para>
		/// <para>例如，如果当前时间段包含从 1 月 15 日到 1 月 28 日的要素，则上一个时间段应包含从 1 月 1 日到 1 月 14 日的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InPreviousFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类，包含时间段比较的差异计数和百分比变化计算。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>将视为点要素重合的与线或点输入要素的最大距离。</para>
		/// <para>仅当点或线要素用作输入要素时，此参数才处于活动状态。</para>
		/// <para><see cref="SearchRadiusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizePercentChange SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Search Radius</para>
		/// </summary>
		public enum SearchRadiusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Points")]
			[Description("Points")]
			Points,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Millimeters")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

		}

#endregion
	}
}
