using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>GA Layer To Contour</para>
	/// <para>Creates a feature class of contours from a geostatistical layer. The output feature class can be either a line feature class of contour lines or a polygon feature class of filled contours.</para>
	/// </summary>
	public class GALayerToContour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </param>
		/// <param name="ContourType">
		/// <para>Contour type</para>
		/// <para>Type of contour to represent the geostatistical layer.</para>
		/// <para>Contour— The contour or isoline representation of the geostatistical layer. Displays the lines in either draft or presentation quality.</para>
		/// <para>Filled contour—The polygon representation of the geostatistical layer. It assumes for the graphical display that the values between contour lines are the same for all locations within the polygon. Displays the lines in either draft or presentation quality.</para>
		/// <para>Same as layer—Use the current renderer of the input geostatistical layer.</para>
		/// <para><see cref="ContourTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>The output feature class will either be a polyline or a polygon, depending on the selected contour type.</para>
		/// </param>
		public GALayerToContour(object InGeostatLayer, object ContourType, object OutFeatureClass)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.ContourType = ContourType;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GA Layer To Contour</para>
		/// </summary>
		public override string DisplayName() => "GA Layer To Contour";

		/// <summary>
		/// <para>Tool Name : GALayerToContour</para>
		/// </summary>
		public override string ToolName() => "GALayerToContour";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToContour</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayerToContour";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, ContourType, OutFeatureClass, ContourQuality, ClassificationType, ClassesCount, ClassesBreaks, OutElevation };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Contour type</para>
		/// <para>Type of contour to represent the geostatistical layer.</para>
		/// <para>Contour— The contour or isoline representation of the geostatistical layer. Displays the lines in either draft or presentation quality.</para>
		/// <para>Filled contour—The polygon representation of the geostatistical layer. It assumes for the graphical display that the values between contour lines are the same for all locations within the polygon. Displays the lines in either draft or presentation quality.</para>
		/// <para>Same as layer—Use the current renderer of the input geostatistical layer.</para>
		/// <para><see cref="ContourTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourType { get; set; } = "SAME_AS_LAYER";

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>The output feature class will either be a polyline or a polygon, depending on the selected contour type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Contour quality</para>
		/// <para>Determines the smoothness of contour line representation.</para>
		/// <para>Draft— The default Draft quality presents a generalized version of isolines for faster display.</para>
		/// <para>Presentation—The Presentation option ensures more detailed isolines for the output feature class.</para>
		/// <para><see cref="ContourQualityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourQuality { get; set; } = "DRAFT";

		/// <summary>
		/// <para>Classification type</para>
		/// <para>Specifies how the contour breaks will be calculated.</para>
		/// <para>Geometric interval—Contour breaks are calculated based on geometric intervals.</para>
		/// <para>Equal interval—Contour breaks are calculated based on equal intervals.</para>
		/// <para>Quantile—Contour breaks are calculated from quantiles of the input data.</para>
		/// <para>Manual—Specify your own break values.</para>
		/// <para><see cref="ClassificationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Classification")]
		public object ClassificationType { get; set; } = "GEOMETRIC_INTERVAL";

		/// <summary>
		/// <para>Number of classes</para>
		/// <para>Specify the number of classes in the output feature class.</para>
		/// <para>If Contour type is set to output filled contour polygons, the number of polygons created will equal the value specified in this parameter. If it is set to output contour polylines, the number of polylines will be one less than the value specified in this parameter (because N class intervals define N-1 contour break values).</para>
		/// <para>This parameter does not apply if the Classification type is set to Manual.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 256)]
		[Category("Classification")]
		public object ClassesCount { get; set; } = "10";

		/// <summary>
		/// <para>Class breaks</para>
		/// <para>The list of break values if the Classification type is set to Manual.</para>
		/// <para>For contour output, these are the values of the contour lines.</para>
		/// <para>For filled contour, these are the upper limits of each class interval. Note that if the largest break value is less than the maximum of the geostatistical layer, the output feature class will not fill up the entire rectangular extent; all locations with predicted values above the largest break will not receive filled contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Classification")]
		public object ClassesBreaks { get; set; }

		/// <summary>
		/// <para>Output elevation</para>
		/// <para>For 3D interpolation models, you can export contours at any elevation. Use this parameter to specify the elevation that you want to export. If left empty, the elevation will be inherited from the input layer. The units will default to the same units of the input layer.</para>
		/// <para><see cref="OutElevationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object OutElevation { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToContour SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contour type</para>
		/// </summary>
		public enum ContourTypeEnum 
		{
			/// <summary>
			/// <para>Same as layer—Use the current renderer of the input geostatistical layer.</para>
			/// </summary>
			[GPValue("SAME_AS_LAYER")]
			[Description("Same as layer")]
			Same_as_layer,

			/// <summary>
			/// <para>Contour type</para>
			/// </summary>
			[GPValue("CONTOUR")]
			[Description("Contour")]
			Contour,

			/// <summary>
			/// <para>Filled contour—The polygon representation of the geostatistical layer. It assumes for the graphical display that the values between contour lines are the same for all locations within the polygon. Displays the lines in either draft or presentation quality.</para>
			/// </summary>
			[GPValue("FILLED_CONTOUR")]
			[Description("Filled contour")]
			Filled_contour,

		}

		/// <summary>
		/// <para>Contour quality</para>
		/// </summary>
		public enum ContourQualityEnum 
		{
			/// <summary>
			/// <para>Draft— The default Draft quality presents a generalized version of isolines for faster display.</para>
			/// </summary>
			[GPValue("DRAFT")]
			[Description("Draft")]
			Draft,

			/// <summary>
			/// <para>Presentation—The Presentation option ensures more detailed isolines for the output feature class.</para>
			/// </summary>
			[GPValue("PRESENTATION")]
			[Description("Presentation")]
			Presentation,

		}

		/// <summary>
		/// <para>Classification type</para>
		/// </summary>
		public enum ClassificationTypeEnum 
		{
			/// <summary>
			/// <para>Geometric interval—Contour breaks are calculated based on geometric intervals.</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("Geometric interval")]
			Geometric_interval,

			/// <summary>
			/// <para>Equal interval—Contour breaks are calculated based on equal intervals.</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("Equal interval")]
			Equal_interval,

			/// <summary>
			/// <para>Quantile—Contour breaks are calculated from quantiles of the input data.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para>Manual—Specify your own break values.</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("Manual")]
			Manual,

		}

		/// <summary>
		/// <para>Output elevation</para>
		/// </summary>
		public enum OutElevationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

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
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

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

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

#endregion
	}
}
