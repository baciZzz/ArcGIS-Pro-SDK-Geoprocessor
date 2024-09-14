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
	/// <para>Locate Outliers</para>
	/// <para>Locate Outliers</para>
	/// <para>Identifies anomalous elevation measurements from terrain, TIN, or LAS datasets that exceed a defined range of elevation values or have slope characteristics that are inconsistent with the surrounding surface.</para>
	/// </summary>
	public class LocateOutliers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input  Surface</para>
		/// <para>The terrain, TIN, or LAS dataset that will be analyzed.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public LocateOutliers(object InSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Locate Outliers</para>
		/// </summary>
		public override string DisplayName() => "Locate Outliers";

		/// <summary>
		/// <para>Tool Name : LocateOutliers</para>
		/// </summary>
		public override string ToolName() => "LocateOutliers";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LocateOutliers</para>
		/// </summary>
		public override string ExcuteName() => "3d.LocateOutliers";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, ApplyHardLimit, AbsoluteZMin, AbsoluteZMax, ApplyComparisonFilter, ZTolerance, SlopeTolerance, ExceedToleranceRatio, OutlierCap };

		/// <summary>
		/// <para>Input  Surface</para>
		/// <para>The terrain, TIN, or LAS dataset that will be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Apply Hard Limit</para>
		/// <para>Specifies use of absolute z minimum and maximum to find outliers.</para>
		/// <para>Unchecked—Do not use the absolute z minimum and maximum to find outliers. This is the default.</para>
		/// <para>Checked—Use the absolute z minimum and maximum to find outliers.</para>
		/// <para><see cref="ApplyHardLimitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyHardLimit { get; set; } = "false";

		/// <summary>
		/// <para>Absolute Z Minimum</para>
		/// <para>If hard limits are applied, any point with an elevation below this value will be considered an outlier. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AbsoluteZMin { get; set; } = "0";

		/// <summary>
		/// <para>Absolute Z Maximum</para>
		/// <para>If hard limits are applied, any point with an elevation above this value will be considered an outlier. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AbsoluteZMax { get; set; } = "0";

		/// <summary>
		/// <para>Apply Comparison Filter</para>
		/// <para>The comparison filter consists of three parameters for determining outliers: Z Tolerance, Slope Tolerance, and Exceed Tolerance Ratio.</para>
		/// <para>Unchecked—Do not use the three comparison parameters (Z Tolerance, Slope Tolerance, and Exceed Tolerance Ratio) in assessing points.</para>
		/// <para>Checked—Use the three comparison parameters (Z Tolerance, Slope Tolerance, and Exceed Tolerance Ratio) in assessing points. This is the default.</para>
		/// <para><see cref="ApplyComparisonFilterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyComparisonFilter { get; set; } = "true";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>Compares z-values of neighboring points if the comparison filter is applied. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Slope Tolerance</para>
		/// <para>The threshold of slope variance between consecutive points that will be used to identify outlier points. Slope is expressed as a percentage, with the default being 150.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SlopeTolerance { get; set; } = "150";

		/// <summary>
		/// <para>Exceed Tolerance Ratio</para>
		/// <para>Defines the criteria for determining each outlier point as a function of the ratio of points in its natural neighborhood that must exceed the specified comparison filters. For example, the default value of 0.5 means at least half of the points surrounding the query point must exceed the comparison filters for the query point to be considered an outlier. A value of 0.7 means at least 70 percent of the neighbor points must exceed the tolerances.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ExceedToleranceRatio { get; set; } = "0.5";

		/// <summary>
		/// <para>Outlier Cap</para>
		/// <para>The maximum number of outlier points that can be written to the output. Once this value is reached, no further outliers are sought. The default is 2,500.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object OutlierCap { get; set; } = "2500";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateOutliers SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Apply Hard Limit</para>
		/// </summary>
		public enum ApplyHardLimitEnum 
		{
			/// <summary>
			/// <para>Checked—Use the absolute z minimum and maximum to find outliers.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_HARD_LIMIT")]
			APPLY_HARD_LIMIT,

			/// <summary>
			/// <para>Unchecked—Do not use the absolute z minimum and maximum to find outliers. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPLY_HARD_LIMIT")]
			NO_APPLY_HARD_LIMIT,

		}

		/// <summary>
		/// <para>Apply Comparison Filter</para>
		/// </summary>
		public enum ApplyComparisonFilterEnum 
		{
			/// <summary>
			/// <para>Checked—Use the three comparison parameters (Z Tolerance, Slope Tolerance, and Exceed Tolerance Ratio) in assessing points. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_COMPARISON_FILTER")]
			APPLY_COMPARISON_FILTER,

			/// <summary>
			/// <para>Unchecked—Do not use the three comparison parameters (Z Tolerance, Slope Tolerance, and Exceed Tolerance Ratio) in assessing points.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPLY_COMPARISON_FILTER")]
			NO_APPLY_COMPARISON_FILTER,

		}

#endregion
	}
}
