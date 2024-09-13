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
	/// <para>Cross Validation</para>
	/// <para>Cross Validation</para>
	/// <para>Removes one data location and predicts the associated data using the data at the rest of the locations. The primary use for this tool is to compare the predicted value to the observed value in order to obtain useful information about some of your model parameters.</para>
	/// </summary>
	public class CrossValidation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </param>
		public CrossValidation(object InGeostatLayer)
		{
			this.InGeostatLayer = InGeostatLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Cross Validation</para>
		/// </summary>
		public override string DisplayName() => "Cross Validation";

		/// <summary>
		/// <para>Tool Name : CrossValidation</para>
		/// </summary>
		public override string ToolName() => "CrossValidation";

		/// <summary>
		/// <para>Tool Excute Name : ga.CrossValidation</para>
		/// </summary>
		public override string ExcuteName() => "ga.CrossValidation";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, OutPointFeatureClass!, Count!, MeanError!, RootMeanSquare!, AverageStandard!, MeanStandardized!, RootMeanSquareStandardized!, PercentIn90Interval!, PercentIn95Interval!, AverageCrps! };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output point feature class</para>
		/// <para>Stores the cross-validation statistics at each location in the geostatistical layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? Count { get; set; } = "0";

		/// <summary>
		/// <para>Mean error</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? MeanError { get; set; } = "NaN";

		/// <summary>
		/// <para>Root mean square</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? RootMeanSquare { get; set; } = "NaN";

		/// <summary>
		/// <para>Average standard</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? AverageStandard { get; set; } = "NaN";

		/// <summary>
		/// <para>Mean standardized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? MeanStandardized { get; set; } = "NaN";

		/// <summary>
		/// <para>Root mean square standardized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? RootMeanSquareStandardized { get; set; } = "NaN";

		/// <summary>
		/// <para>Percent in 90% Interval</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? PercentIn90Interval { get; set; } = "NaN";

		/// <summary>
		/// <para>Percent in 95% Interval</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? PercentIn95Interval { get; set; } = "NaN";

		/// <summary>
		/// <para>Average CRPS</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? AverageCrps { get; set; } = "NaN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CrossValidation SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
