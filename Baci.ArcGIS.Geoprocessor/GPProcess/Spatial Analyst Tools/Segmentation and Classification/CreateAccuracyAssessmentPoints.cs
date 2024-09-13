using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Create Accuracy Assessment Points</para>
	/// <para>Create Accuracy Assessment Points</para>
	/// <para>Creates randomly sampled points for post-classification accuracy assessment.</para>
	/// </summary>
	public class CreateAccuracyAssessmentPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InClassData">
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>The input classification image or other thematic GIS reference data. The input can be a raster or feature class.</para>
		/// <para>Typical data is a classification image of a single band, integer data type.</para>
		/// <para>If using polygons as input, only use those that are not used as training samples. They can also be GIS land-cover data in shapefile or feature class format.</para>
		/// </param>
		/// <param name="OutPoints">
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>The output point shapefile or feature class that contains the random points to be used for accuracy assessment.</para>
		/// </param>
		public CreateAccuracyAssessmentPoints(object InClassData, object OutPoints)
		{
			this.InClassData = InClassData;
			this.OutPoints = OutPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Accuracy Assessment Points</para>
		/// </summary>
		public override string DisplayName() => "Create Accuracy Assessment Points";

		/// <summary>
		/// <para>Tool Name : CreateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ToolName() => "CreateAccuracyAssessmentPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.CreateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ExcuteName() => "sa.CreateAccuracyAssessmentPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InClassData, OutPoints, TargetField!, NumRandomPoints!, Sampling!, PolygonDimensionField! };

		/// <summary>
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>The input classification image or other thematic GIS reference data. The input can be a raster or feature class.</para>
		/// <para>Typical data is a classification image of a single band, integer data type.</para>
		/// <para>If using polygons as input, only use those that are not used as training samples. They can also be GIS land-cover data in shapefile or feature class format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>The output point shapefile or feature class that contains the random points to be used for accuracy assessment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPoints { get; set; }

		/// <summary>
		/// <para>Target Field</para>
		/// <para>Specifies whether the input data is a classified image or ground truth data.</para>
		/// <para>Classified—The input is a classified image. This is the default.</para>
		/// <para>Ground truth—The input is reference data.</para>
		/// <para><see cref="TargetFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TargetField { get; set; } = "CLASSIFIED";

		/// <summary>
		/// <para>Number of Random Points</para>
		/// <para>The total number of random points that will be generated.</para>
		/// <para>The actual number may exceed but never fall below this number, depending on sampling strategy and number of classes. The default number of randomly generated points is 500.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumRandomPoints { get; set; } = "500";

		/// <summary>
		/// <para>Sampling Strategy</para>
		/// <para>Specifies the sampling scheme that will be used.</para>
		/// <para>Stratified random—Randomly distributed points will be created in each class, in which each class has a number of points proportional to its relative area. This is the default</para>
		/// <para>Equalized stratified random—Randomly distributed points will be created in each class, in which each class has the same number of points.</para>
		/// <para>Random—Randomly distributed points will be created throughout the image.</para>
		/// <para><see cref="SamplingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Sampling { get; set; } = "STRATIFIED_RANDOM";

		/// <summary>
		/// <para>Dimension Field for Feature Class</para>
		/// <para>A field that defines the dimension (time) of the features. This parameter is used only if the classification result is multidimensional raster and you want to generate assessment points from a feature class, such as land classification polygons for multiple years.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? PolygonDimensionField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateAccuracyAssessmentPoints SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Target Field</para>
		/// </summary>
		public enum TargetFieldEnum 
		{
			/// <summary>
			/// <para>Classified—The input is a classified image. This is the default.</para>
			/// </summary>
			[GPValue("CLASSIFIED")]
			[Description("Classified")]
			Classified,

			/// <summary>
			/// <para>Ground truth—The input is reference data.</para>
			/// </summary>
			[GPValue("GROUND_TRUTH")]
			[Description("Ground truth")]
			Ground_truth,

		}

		/// <summary>
		/// <para>Sampling Strategy</para>
		/// </summary>
		public enum SamplingEnum 
		{
			/// <summary>
			/// <para>Stratified random—Randomly distributed points will be created in each class, in which each class has a number of points proportional to its relative area. This is the default</para>
			/// </summary>
			[GPValue("STRATIFIED_RANDOM")]
			[Description("Stratified random")]
			Stratified_random,

			/// <summary>
			/// <para>Equalized stratified random—Randomly distributed points will be created in each class, in which each class has the same number of points.</para>
			/// </summary>
			[GPValue("EQUALIZED_STRATIFIED_RANDOM")]
			[Description("Equalized stratified random")]
			Equalized_stratified_random,

			/// <summary>
			/// <para>Random—Randomly distributed points will be created throughout the image.</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("Random")]
			Random,

		}

#endregion
	}
}
