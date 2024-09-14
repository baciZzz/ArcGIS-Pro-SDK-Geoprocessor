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
	/// <para>Extract Power Lines From Point Cloud</para>
	/// <para>Extract Power Lines From Point Cloud</para>
	/// <para>Extracts 3D line features modeling power lines </para>
	/// <para>from classified point cloud data.</para>
	/// </summary>
	public class ExtractPowerLinesFromPointCloud : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Input Point Cloud</para>
		/// <para>The LAS dataset layer containing points classified as power lines.</para>
		/// </param>
		/// <param name="ClassCodes">
		/// <para>Power Line Class Codes</para>
		/// <para>The class code values for the points representing the power lines.</para>
		/// </param>
		/// <param name="Out3DLines">
		/// <para>Output 3D Lines</para>
		/// <para>The 3D lines modeling the power lines.</para>
		/// </param>
		public ExtractPowerLinesFromPointCloud(object InPointCloud, object ClassCodes, object Out3DLines)
		{
			this.InPointCloud = InPointCloud;
			this.ClassCodes = ClassCodes;
			this.Out3DLines = Out3DLines;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Power Lines From Point Cloud</para>
		/// </summary>
		public override string DisplayName() => "Extract Power Lines From Point Cloud";

		/// <summary>
		/// <para>Tool Name : ExtractPowerLinesFromPointCloud</para>
		/// </summary>
		public override string ToolName() => "ExtractPowerLinesFromPointCloud";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ExtractPowerLinesFromPointCloud</para>
		/// </summary>
		public override string ExcuteName() => "3d.ExtractPowerLinesFromPointCloud";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointCloud, ClassCodes, Out3DLines, PointTolerance!, SeparationDistance!, MaxSamplingGap!, LineTolerance!, WindCorrection!, MinWindSpan!, MaxWindDeviation!, EndPointSearchRadius!, MinLength!, EliminateWind! };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>The LAS dataset layer containing points classified as power lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Power Line Class Codes</para>
		/// <para>The class code values for the points representing the power lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPRangeDomain(Min = 0, Max = 255)]
		public object ClassCodes { get; set; }

		/// <summary>
		/// <para>Output 3D Lines</para>
		/// <para>The 3D lines modeling the power lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object Out3DLines { get; set; }

		/// <summary>
		/// <para>Point Tolerance</para>
		/// <para>The distance used to establish the points that belong to a given power line. The default is 80 centimeters.</para>
		/// <para><see cref="PointToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? PointTolerance { get; set; } = "80 Centimeters";

		/// <summary>
		/// <para>Wire Separation Distance</para>
		/// <para>The distance apart points must be to determine if they belong to different power lines. The default is 1 meter.</para>
		/// <para><see cref="SeparationDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? SeparationDistance { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Maximum Wire Sampling Gap</para>
		/// <para>The largest gap that can exist in a given span of a power line. The catenary curve being modeled from a set of power line points will be extended by this distance to find other points that fit the same power line. The default is 5 meters.</para>
		/// <para><see cref="MaxSamplingGapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? MaxSamplingGap { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Output Line Tolerance</para>
		/// <para>The distance used to establish the accuracy of the output power line. A larger distance will result in the creation of less vertices per line, yielding a more coarse representation of the power line when compared with a smaller distance. The default is 1 centimeter.</para>
		/// <para><see cref="LineToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? LineTolerance { get; set; } = "1 Centimeters";

		/// <summary>
		/// <para>Adjust for wind distortion</para>
		/// <para>Specifies whether the output power lines will be adjusted for the influence of wind. When wind correction is applied, it can be used to either improve the fitting of wind modified points or model the resting state of the power lines when no wind is acting on them. The type of wind correction is specified using the Eliminate wind parameter.</para>
		/// <para>Checked—The power lines will be adjusted for the influence of the wind. This is the default.</para>
		/// <para>Unchecked—The power lines will attempt to fit the points without making any additional adjustments for the wind.</para>
		/// <para><see cref="WindCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Wind Correction")]
		public object? WindCorrection { get; set; } = "true";

		/// <summary>
		/// <para>Minimum Span for Wind Correction</para>
		/// <para>The shortest distance a power line span can be to apply wind correction when generating the output power line. The default is 60 meters.</para>
		/// <para><see cref="MinWindSpanEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Wind Correction")]
		public object? MinWindSpan { get; set; } = "60 Meters";

		/// <summary>
		/// <para>Maximum Deviation Angle</para>
		/// <para>The maximum angle that the wind is expected to deviate a given power line. The default is 10 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.10000000000000001, Max = 89.999999000000003)]
		[Category("Wind Correction")]
		public object? MaxWindDeviation { get; set; } = "10";

		/// <summary>
		/// <para>End Point Search Radius</para>
		/// <para>The distance used to identify a common suspension point for power line segments connected to the same distribution pole or transmission tower. The default is 10 meters.</para>
		/// <para><see cref="EndPointSearchRadiusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("End Point Adjustment")]
		public object? EndPointSearchRadius { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Minimum Wire Length</para>
		/// <para>The shortest wire length that can be used to determine the presence of a common end point. The default is 5 meters.</para>
		/// <para><see cref="MinLengthEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("End Point Adjustment")]
		public object? MinLength { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Eliminate wind</para>
		/// <para>Specifies how wind correction will be applied to the output power lines. Wind correction will only be applied for catenary curves that span a distance longer than the value specified in the Minimum Span for Wind Correction parameter.</para>
		/// <para>Checked—The power lines will be adjusted to simulate the elimination of the impact of wind.</para>
		/// <para>Unchecked—The power lines will be adjusted to achieve a better fit for the impact of wind. This is the default.</para>
		/// <para><see cref="EliminateWindEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Wind Correction")]
		public object? EliminateWind { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractPowerLinesFromPointCloud SetEnviroment(object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Tolerance</para>
		/// </summary>
		public enum PointToleranceEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Wire Separation Distance</para>
		/// </summary>
		public enum SeparationDistanceEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Maximum Wire Sampling Gap</para>
		/// </summary>
		public enum MaxSamplingGapEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Output Line Tolerance</para>
		/// </summary>
		public enum LineToleranceEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Adjust for wind distortion</para>
		/// </summary>
		public enum WindCorrectionEnum 
		{
			/// <summary>
			/// <para>Checked—The power lines will be adjusted for the influence of the wind. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("WIND")]
			WIND,

			/// <summary>
			/// <para>Unchecked—The power lines will attempt to fit the points without making any additional adjustments for the wind.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_WIND")]
			NO_WIND,

		}

		/// <summary>
		/// <para>Minimum Span for Wind Correction</para>
		/// </summary>
		public enum MinWindSpanEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>End Point Search Radius</para>
		/// </summary>
		public enum EndPointSearchRadiusEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Minimum Wire Length</para>
		/// </summary>
		public enum MinLengthEnum 
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
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Eliminate wind</para>
		/// </summary>
		public enum EliminateWindEnum 
		{
			/// <summary>
			/// <para>Checked—The power lines will be adjusted to simulate the elimination of the impact of wind.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ELIMINATE_WIND")]
			ELIMINATE_WIND,

			/// <summary>
			/// <para>Unchecked—The power lines will be adjusted to achieve a better fit for the impact of wind. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_WIND")]
			KEEP_WIND,

		}

#endregion
	}
}
