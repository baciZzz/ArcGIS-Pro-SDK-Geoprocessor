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
	/// <para>Densify Sampling Network</para>
	/// <para>Uses a predefined geostatistical kriging layer to determine where new monitoring stations should be built.  It can also be used to determine which monitoring stations should be removed from an existing network.</para>
	/// </summary>
	public class DensifySamplingNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>Input a geostatistical layer resulting from a Kriging model.</para>
		/// </param>
		/// <param name="NumberOutputPoints">
		/// <para>Number of  output points</para>
		/// <para>Specify how many sample locations to generate.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output point feature class</para>
		/// <para>The name of the output feature class.</para>
		/// </param>
		public DensifySamplingNetwork(object InGeostatLayer, object NumberOutputPoints, object OutFeatureClass)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.NumberOutputPoints = NumberOutputPoints;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Densify Sampling Network</para>
		/// </summary>
		public override string DisplayName() => "Densify Sampling Network";

		/// <summary>
		/// <para>Tool Name : DensifySamplingNetwork</para>
		/// </summary>
		public override string ToolName() => "DensifySamplingNetwork";

		/// <summary>
		/// <para>Tool Excute Name : ga.DensifySamplingNetwork</para>
		/// </summary>
		public override string ExcuteName() => "ga.DensifySamplingNetwork";

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
		public override object[] Parameters() => new object[] { InGeostatLayer, NumberOutputPoints, OutFeatureClass, SelectionCriteria, Threshold, InWeightRaster, InCandidatePointFeatures, InhibitionDistance };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>Input a geostatistical layer resulting from a Kriging model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Number of  output points</para>
		/// <para>Specify how many sample locations to generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		public object NumberOutputPoints { get; set; }

		/// <summary>
		/// <para>Output point feature class</para>
		/// <para>The name of the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Selection criteria</para>
		/// <para>Methods to densify a sampling network.</para>
		/// <para>Standard error of prediction—Standard error of prediction criteria</para>
		/// <para>Standard error threshold—Standard error threshold criteria</para>
		/// <para>Lower quartile threshold— Lower quartile threshold criteria</para>
		/// <para>Upper quartile threshold— Upper quartile threshold criteria</para>
		/// <para>The Standard error of prediction option will give extra weight to locations where the standard error of prediction is large. The Standard error threshold, Lower quartile threshold, and Upper quartile threshold options are useful when there is a critical threshold value for the variable under study (such as the highest admissible ozone level). The Standard error threshold option will give extra weight to locations whose values are close to the threshold. The Lower quartile threshold option will give extra weight to locations that are least likely to exceed the critical threshold. The Upper quartile threshold option will give extra weight to locations that are most likely to exceed the critical threshold.</para>
		/// <para>When the Selection criteria is set to Standard error threshold, Lower quartile threshold, or Upper quartile threshold, the Threshold value parameter will become available, allowing you specify your threshold of interest.</para>
		/// <para>The equations for each option are:&lt;code&gt;Standard error of prediction = stderr Standard error threshold = stderr(s)(1 - 2 · abs(prob[Z(s) &gt; threshold] - 0.5)) Lower quartile threshold = (Z0.75(s) - Z0.25(s)) · (prob[Z(s) &lt; threshold]) Upper quartile threshold = (Z0.75(s) - Z0.25(s)) · (prob[Z(s) &gt; threshold])&lt;/code&gt;</para>
		/// <para><see cref="SelectionCriteriaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCriteria { get; set; } = "STDERR";

		/// <summary>
		/// <para>Threshold value</para>
		/// <para>The threshold value used to densify the sampling network.</para>
		/// <para>This parameter is only applicable when Standard error threshold, Lower quartile threshold, or Upper quartile threshold selection criteria is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 1.7976931348623157e+308)]
		public object Threshold { get; set; }

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>A raster used to determine which locations to weight for preference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Input candidate point features</para>
		/// <para>Sample locations to pick from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InCandidatePointFeatures { get; set; }

		/// <summary>
		/// <para>Inhibition distance</para>
		/// <para>Used to prevent any samples being placed within this distance from each other.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object InhibitionDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DensifySamplingNetwork SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Selection criteria</para>
		/// </summary>
		public enum SelectionCriteriaEnum 
		{
			/// <summary>
			/// <para>Standard error of prediction—Standard error of prediction criteria</para>
			/// </summary>
			[GPValue("STDERR")]
			[Description("Standard error of prediction")]
			Standard_error_of_prediction,

			/// <summary>
			/// <para>Standard error threshold—Standard error threshold criteria</para>
			/// </summary>
			[GPValue("STDERR_THRESHOLD")]
			[Description("Standard error threshold")]
			Standard_error_threshold,

			/// <summary>
			/// <para>Lower quartile threshold— Lower quartile threshold criteria</para>
			/// </summary>
			[GPValue("QUARTILE_THRESHOLD")]
			[Description("Lower quartile threshold")]
			Lower_quartile_threshold,

			/// <summary>
			/// <para>Upper quartile threshold— Upper quartile threshold criteria</para>
			/// </summary>
			[GPValue("QUARTILE_THRESHOLD_UPPER")]
			[Description("Upper quartile threshold")]
			Upper_quartile_threshold,

		}

#endregion
	}
}
