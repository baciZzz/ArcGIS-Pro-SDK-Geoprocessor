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
	/// <para>Summarize Percent Change</para>
	/// <para>Calculates the percent change for features that correspond with point features representing two equal comparison time periods.</para>
	/// </summary>
	public class SummarizePercentChange : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input  Features</para>
		/// <para>The coincident features from which comparison time periods will be counted and compared.</para>
		/// </param>
		/// <param name="InCurrentFeatures">
		/// <para>Input Current Period Point Features</para>
		/// <para>The point features filtered to the most recent comparison time period.</para>
		/// <para>For example, crimes from the previous 14 days.</para>
		/// </param>
		/// <param name="InPreviousFeatures">
		/// <para>Input Previous Period Point Features</para>
		/// <para>The point features filtered to the time period immediately preceding the current period. This time period must beof equal length to the current period, to provide an accurate comparison.</para>
		/// <para>For example, if the current period contains features from January 15 to January 28, the previous period would contain features from January 1 to January 14.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing difference counts and percent change calculations for the time period comparison.</para>
		/// </param>
		public SummarizePercentChange(object InFeatures, object InCurrentFeatures, object InPreviousFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.InCurrentFeatures = InCurrentFeatures;
			this.InPreviousFeatures = InPreviousFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Percent Change</para>
		/// </summary>
		public override string DisplayName() => "Summarize Percent Change";

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
		/// <para>The coincident features from which comparison time periods will be counted and compared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Current Period Point Features</para>
		/// <para>The point features filtered to the most recent comparison time period.</para>
		/// <para>For example, crimes from the previous 14 days.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InCurrentFeatures { get; set; }

		/// <summary>
		/// <para>Input Previous Period Point Features</para>
		/// <para>The point features filtered to the time period immediately preceding the current period. This time period must beof equal length to the current period, to provide an accurate comparison.</para>
		/// <para>For example, if the current period contains features from January 15 to January 28, the previous period would contain features from January 1 to January 14.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InPreviousFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing difference counts and percent change calculations for the time period comparison.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The maximum distance from the line or point Input Features that a point feature will be considered coincident.</para>
		/// <para>This parameter is only active when point or line features are used as the input features.</para>
		/// <para><see cref="SearchRadiusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizePercentChange SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
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
