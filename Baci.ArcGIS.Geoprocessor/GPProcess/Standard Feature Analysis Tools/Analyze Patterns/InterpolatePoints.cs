using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Interpolate Points</para>
	/// <para>Predicts values at new locations based on measurements from a collection of points. The tool uses point data with values at each point as input and makes areas classified by predicted values.</para>
	/// </summary>
	public class InterpolatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Features</para>
		/// <para>The point features that will be interpolated to a continuous surface layer.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public InterpolatePoints(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Interpolate Points</para>
		/// </summary>
		public override string DisplayName => "Interpolate Points";

		/// <summary>
		/// <para>Tool Name : InterpolatePoints</para>
		/// </summary>
		public override string ToolName => "InterpolatePoints";

		/// <summary>
		/// <para>Tool Excute Name : sfa.InterpolatePoints</para>
		/// </summary>
		public override string ExcuteName => "sfa.InterpolatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputlayer, Outputname, Field, Interpolateoption, Outputpredictionerror, Classificationtype, Numclasses, Classbreaks, Boundingpolygonlayer, Predictatpointlayer, Outputlayer, Outputpredictionerrorlayer, Outputpredictedpointslayer };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features that will be interpolated to a continuous surface layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Interpolation Field</para>
		/// <para>The numeric field containing the values you want to interpolate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Interpolate Option</para>
		/// <para>Controls your preference for speed versus accuracy, from fastest to most accurate. More accurate predictions take longer to calculate.</para>
		/// <para>Speed—Speed.</para>
		/// <para>Balanced—Balanced. This is the default.</para>
		/// <para>Accuracy—Accuracy.</para>
		/// <para><see cref="InterpolateoptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Interpolateoption { get; set; } = "5";

		/// <summary>
		/// <para>Output prediction error</para>
		/// <para>If checked, a polygon layer of standard errors for the interpolation predictions will be output.</para>
		/// <para>Standard errors are useful because they provide information about the reliability of the predicted values. A simple rule of thumb is that the true value will fall within two standard errors of the predicted value 95 percent of the time. For example, suppose a new location gets a predicted value of 50 with a standard error of 5. This means that this task&apos;s best guess is that the true value at that location is 50, but it reasonably could be as low as 40 or as high as 60. To calculate this range of reasonable values, multiply the standard error by 2, add this value to the predicted value to get the upper end of the range, and subtract it from the predicted value to get the lower end of the range.</para>
		/// <para>Unchecked—Do not create a prediction error output layer. This is the default.</para>
		/// <para>Checked—Create a prediction error output layer.</para>
		/// <para><see cref="OutputpredictionerrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Outputpredictionerror { get; set; } = "false";

		/// <summary>
		/// <para>Classification Type</para>
		/// <para>Determines how predicted values will be classified into polygons.</para>
		/// <para>Equal interval— Polygons are created such that the range of density values is equal for each area.</para>
		/// <para>Geometric interval— Polygons are based on class intervals that have a geometric series. This method ensures that each class range has approximately the same number of values within each class and that the change between intervals is consistent. This is the default.</para>
		/// <para>Equal area— Polygons are created such that the size of each area is equal. For example, if the result has more high-density values than low-density values, more polygons will be created for high densities.</para>
		/// <para>Enter class breaks manually—You define your own range of values for areas. These values will be entered as class breaks.</para>
		/// <para><see cref="ClassificationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object Classificationtype { get; set; } = "GEOMETRICINTERVAL";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>This value is used to divide the range of predicted values into distinct classes. The range of values in each class is determined by the classification type. Each class defines the boundaries of the result polygons.</para>
		/// <para>The default is 10 and the maximum is 32.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 32)]
		[Category("Additional Options")]
		public object Numclasses { get; set; } = "10";

		/// <summary>
		/// <para>Class Breaks</para>
		/// <para>To do a manual classification, supply the desired class break values. These values define the upper limit of each class, so the number of classes will equal the number of entered values. Areas will not be created for any locations with predicted values above the largest entered break value. You must enter at least 2 values and no more than 32.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Additional Options")]
		public object Classbreaks { get; set; }

		/// <summary>
		/// <para>Bounding Polygons</para>
		/// <para>A layer specifying the polygons where you want values to be interpolated. For example, if you are interpolating densities of fish within a lake, you can use the boundary of the lake in this parameter and the output will only contain polygons within the boundary of the lake.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Additional Options")]
		public object Boundingpolygonlayer { get; set; }

		/// <summary>
		/// <para>Predict At Point Layer</para>
		/// <para>An optional layer specifying point locations to calculate prediction values. This allows you to make predictions at specific locations of interest. For example, if the input layer represents measurements of pollution levels, you can use this parameter to predict the pollution levels of locations with large at-risk populations, such as schools or hospitals. You can then use this information to give recommendations to health officials in those locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Additional Options")]
		public object Predictatpointlayer { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputlayer { get; set; }

		/// <summary>
		/// <para>Output Prediction Error Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputpredictionerrorlayer { get; set; }

		/// <summary>
		/// <para>Output Predicted Points Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputpredictedpointslayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolatePoints SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolate Option</para>
		/// </summary>
		public enum InterpolateoptionEnum 
		{
			/// <summary>
			/// <para>Speed—Speed.</para>
			/// </summary>
			[GPValue("1")]
			[Description("Speed")]
			Speed,

			/// <summary>
			/// <para>Balanced—Balanced. This is the default.</para>
			/// </summary>
			[GPValue("5")]
			[Description("Balanced")]
			Balanced,

			/// <summary>
			/// <para>Accuracy—Accuracy.</para>
			/// </summary>
			[GPValue("9")]
			[Description("Accuracy")]
			Accuracy,

		}

		/// <summary>
		/// <para>Output prediction error</para>
		/// </summary>
		public enum OutputpredictionerrorEnum 
		{
			/// <summary>
			/// <para>Checked—Create a prediction error output layer.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_ERROR")]
			OUTPUT_ERROR,

			/// <summary>
			/// <para>Unchecked—Do not create a prediction error output layer. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ERROR")]
			NO_ERROR,

		}

		/// <summary>
		/// <para>Classification Type</para>
		/// </summary>
		public enum ClassificationtypeEnum 
		{
			/// <summary>
			/// <para>Equal area— Polygons are created such that the size of each area is equal. For example, if the result has more high-density values than low-density values, more polygons will be created for high densities.</para>
			/// </summary>
			[GPValue("EQUALAREA")]
			[Description("Equal area")]
			Equal_area,

			/// <summary>
			/// <para>Equal interval— Polygons are created such that the range of density values is equal for each area.</para>
			/// </summary>
			[GPValue("EQUALINTERVAL")]
			[Description("Equal interval")]
			Equal_interval,

			/// <summary>
			/// <para>Geometric interval— Polygons are based on class intervals that have a geometric series. This method ensures that each class range has approximately the same number of values within each class and that the change between intervals is consistent. This is the default.</para>
			/// </summary>
			[GPValue("GEOMETRICINTERVAL")]
			[Description("Geometric interval")]
			Geometric_interval,

			/// <summary>
			/// <para>Enter class breaks manually—You define your own range of values for areas. These values will be entered as class breaks.</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("Enter class breaks manually")]
			Enter_class_breaks_manually,

		}

#endregion
	}
}
