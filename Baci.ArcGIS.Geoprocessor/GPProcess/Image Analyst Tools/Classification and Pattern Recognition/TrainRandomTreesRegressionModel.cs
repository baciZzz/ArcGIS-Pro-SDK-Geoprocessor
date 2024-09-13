using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Train Random Trees Regression Model</para>
	/// <para>Train Random Trees Regression Model</para>
	/// <para>Models the relationship between explanatory variables (independent variables) and a target dataset (dependent variable).</para>
	/// </summary>
	public class TrainRandomTreesRegressionModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>The single-band, multidimensional, or multiband raster datasets, or mosaic datasets containing explanatory variables.</para>
		/// </param>
		/// <param name="InTargetData">
		/// <para>Target Raster or Points</para>
		/// <para>The raster or point feature class containing the target variable (dependant variable) data.</para>
		/// </param>
		/// <param name="OutRegressionDefinition">
		/// <para>Output Regression Definition File</para>
		/// <para>A JSON format file with an .ecd extension that contains attribute information, statistics, or other information for the classifier.</para>
		/// </param>
		public TrainRandomTreesRegressionModel(object InRasters, object InTargetData, object OutRegressionDefinition)
		{
			this.InRasters = InRasters;
			this.InTargetData = InTargetData;
			this.OutRegressionDefinition = OutRegressionDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Random Trees Regression Model</para>
		/// </summary>
		public override string DisplayName() => "Train Random Trees Regression Model";

		/// <summary>
		/// <para>Tool Name : TrainRandomTreesRegressionModel</para>
		/// </summary>
		public override string ToolName() => "TrainRandomTreesRegressionModel";

		/// <summary>
		/// <para>Tool Excute Name : ia.TrainRandomTreesRegressionModel</para>
		/// </summary>
		public override string ExcuteName() => "ia.TrainRandomTreesRegressionModel";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, InTargetData, OutRegressionDefinition, TargetValueField!, TargetDimensionField!, RasterDimension!, OutImportanceTable!, MaxNumTrees!, MaxTreeDepth!, MaxSamples!, AveragePointsPerCell!, PercentTesting!, OutScatterplots!, OutSampleFeatures! };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The single-band, multidimensional, or multiband raster datasets, or mosaic datasets containing explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Target Raster or Points</para>
		/// <para>The raster or point feature class containing the target variable (dependant variable) data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTargetData { get; set; }

		/// <summary>
		/// <para>Output Regression Definition File</para>
		/// <para>A JSON format file with an .ecd extension that contains attribute information, statistics, or other information for the classifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutRegressionDefinition { get; set; }

		/// <summary>
		/// <para>Target Value Field</para>
		/// <para>The field name of the information to model in the target point feature class or raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? TargetValueField { get; set; }

		/// <summary>
		/// <para>Target Dimension Field</para>
		/// <para>A date field or numeric field in the input point feature class that defines the dimension values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? TargetDimensionField { get; set; }

		/// <summary>
		/// <para>Raster Dimension</para>
		/// <para>The dimension name of the input multidimensional raster (explanatory variables) that links to the dimension in the target data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RasterDimension { get; set; }

		/// <summary>
		/// <para>Output Importance Table</para>
		/// <para>A table containing information describing the importance of each explanatory variable used in the model. A larger number indicates the corresponding variable is more correlated to the predicted variable and will contribute more in prediction. Values range between 0 and 1, and the sum of all the values equals 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object? OutImportanceTable { get; set; }

		/// <summary>
		/// <para>Max Number of Trees</para>
		/// <para>The maximum number of trees in the forest. Increasing the number of trees will lead to higher accuracy rates, although this improvement will level off. The number of trees increases the processing time linearly. The default is 50.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Training Options")]
		public object? MaxNumTrees { get; set; } = "50";

		/// <summary>
		/// <para>Max Tree Depth</para>
		/// <para>The maximum depth of each tree in the forest. Depth determines the number of rules each tree can create, resulting in a decision. Trees will not grow any deeper than this setting. The default is 30.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Training Options")]
		public object? MaxTreeDepth { get; set; } = "30";

		/// <summary>
		/// <para>Max Number of Samples</para>
		/// <para>The maximum number of samples that will be used for the regression analysis. A value that is less than or equal to 0 means that the system will use all the samples from the input target raster or point feature class to train the regression model. The default value is 10,000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Training Options")]
		public object? MaxSamples { get; set; } = "100000";

		/// <summary>
		/// <para>Average Points Per Cell</para>
		/// <para>Specifies whether the average will be calculated when multiple training points fall into one cell. This parameter is applicable only when the input target is a point feature class.</para>
		/// <para>Unchecked—All points will be used when multiple training points fall into a single cell. This is the default.</para>
		/// <para>Checked—The average value of the training points in a cell will be calculated.</para>
		/// <para>Keep all points—All points will be used when multiple training points fall into a single cell. This is the default.</para>
		/// <para>Average points per cell—The average value of the training points in a cell will be calculated.</para>
		/// <para><see cref="AveragePointsPerCellEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AveragePointsPerCell { get; set; } = "false";

		/// <summary>
		/// <para>Percent of Samples for Testing</para>
		/// <para>The percentage of test points that will be used for error checking. The tool checks for three types of errors: errors on training points, errors on test points, and errors on test location points. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Training Options")]
		public object? PercentTesting { get; set; } = "10";

		/// <summary>
		/// <para>Output Scatter Plots (pdf or html)</para>
		/// <para>The output scatter plots in PDF or HTML format. The output will include scatter plots of training data, test data, and location test data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPCompositeDomain()]
		[Category("Additional Outputs")]
		public object? OutScatterplots { get; set; }

		/// <summary>
		/// <para>Output Sample Features</para>
		/// <para>The output feature class that will contain target values and predicted values for training points, test points, and location test points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object? OutSampleFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainRandomTreesRegressionModel SetEnviroment(object? cellSize = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Average Points Per Cell</para>
		/// </summary>
		public enum AveragePointsPerCellEnum 
		{
			/// <summary>
			/// <para>Checked—The average value of the training points in a cell will be calculated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AVERAGE_POINTS_PER_CELL")]
			AVERAGE_POINTS_PER_CELL,

			/// <summary>
			/// <para>Unchecked—All points will be used when multiple training points fall into a single cell. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_POINTS")]
			KEEP_ALL_POINTS,

		}

#endregion
	}
}
