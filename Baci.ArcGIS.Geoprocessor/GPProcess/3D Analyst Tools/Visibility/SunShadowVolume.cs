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
	/// <para>Sun Shadow Volume</para>
	/// <para>Creates closed volumes that model shadows cast by each feature using sunlight for a given date and time.</para>
	/// </summary>
	public class SunShadowVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The multipatch features that will be used to model shadows. Polygon and line features can also be used if they are added as an extruded 3D layer.</para>
		/// </param>
		/// <param name="StartDateAndTime">
		/// <para>Start Date and Time</para>
		/// <para>The date and time that the trajectory of sunlight will be calculated for modeling the shadows.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The multipatch feature class that will store the resulting shadow volumes.</para>
		/// </param>
		public SunShadowVolume(object InFeatures, object StartDateAndTime, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.StartDateAndTime = StartDateAndTime;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Sun Shadow Volume</para>
		/// </summary>
		public override string DisplayName() => "Sun Shadow Volume";

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
		/// <para>The multipatch features that will be used to model shadows. Polygon and line features can also be used if they are added as an extruded 3D layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Start Date and Time</para>
		/// <para>The date and time that the trajectory of sunlight will be calculated for modeling the shadows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object StartDateAndTime { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The multipatch feature class that will store the resulting shadow volumes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Adjusted for Daylight Savings Time</para>
		/// <para>Specifies if time value is adjusted for Daylight Savings Time (DST).</para>
		/// <para>Unchecked—DST is not observed. This is the default.</para>
		/// <para>Checked—DST is observed.</para>
		/// <para><see cref="AdjustedForDstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AdjustedForDst { get; set; } = "true";

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone in which the participating input is located. The default setting is the time zone to which the operating system is set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeZone { get; set; } = "Pacific_Standard_Time";

		/// <summary>
		/// <para>End Date and Time</para>
		/// <para>The final date and time for calculating sun position. If only a date is provided, the final time is presumed to be sunset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? EndDateAndTime { get; set; }

		/// <summary>
		/// <para>Iteration Interval</para>
		/// <para>The value used to define the iteration of time from the start date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? IterationInterval { get; set; } = "0";

		/// <summary>
		/// <para>Iteration Unit</para>
		/// <para>The unit that defines the iteration value applied to the Start Date and Time.</para>
		/// <para>Days—Iteration value will represent days. This is the default.</para>
		/// <para>Hours—Iteration value will represent one or more hours.</para>
		/// <para>Minutes—Iteration value will represent one or more minutes.</para>
		/// <para><see cref="IterationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IterationUnit { get; set; } = "DAYS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SunShadowVolume SetEnviroment(object? XYDomain = null , object? ZDomain = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
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
			/// <para>Checked—DST is observed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADJUSTED_FOR_DST")]
			ADJUSTED_FOR_DST,

			/// <summary>
			/// <para>Unchecked—DST is not observed. This is the default.</para>
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
			/// <para>Days—Iteration value will represent days. This is the default.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Hours—Iteration value will represent one or more hours.</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Minutes—Iteration value will represent one or more minutes.</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("Minutes")]
			Minutes,

		}

#endregion
	}
}
