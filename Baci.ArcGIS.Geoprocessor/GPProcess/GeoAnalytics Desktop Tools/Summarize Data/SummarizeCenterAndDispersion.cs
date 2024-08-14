using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Summarize Center And Dispersion</para>
	/// <para>Finds central features and directional distributions and calculates mean and median locations from the input.</para>
	/// </summary>
	public class SummarizeCenterAndDispersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon layer to be summarized.</para>
		/// </param>
		public SummarizeCenterAndDispersion(object InputLayer)
		{
			this.InputLayer = InputLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Center And Dispersion</para>
		/// </summary>
		public override string DisplayName => "Summarize Center And Dispersion";

		/// <summary>
		/// <para>Tool Name : SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ToolName => "SummarizeCenterAndDispersion";

		/// <summary>
		/// <para>Tool Excute Name : gapro.SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ExcuteName => "gapro.SummarizeCenterAndDispersion";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, OutCentralFeature!, OutMeanCenter!, OutMedianCenter!, OutEllipse!, EllipseSize!, WeightField!, GroupByField! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon layer to be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Central Feature</para>
		/// <para>The output feature class that will contain the most centrally located feature in the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutCentralFeature { get; set; }

		/// <summary>
		/// <para>Output Mean Center</para>
		/// <para>The output point feature class that will contain features representing the mean centers of the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutMeanCenter { get; set; }

		/// <summary>
		/// <para>Output Median Center</para>
		/// <para>The output point feature class that will contain features representing the median centers of the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutMedianCenter { get; set; }

		/// <summary>
		/// <para>Output Ellipse</para>
		/// <para>The output polygon feature class that will contain the directional ellipse representation of the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutEllipse { get; set; }

		/// <summary>
		/// <para>Ellipse Size</para>
		/// <para>Specifies the size of output ellipses in standard deviations.</para>
		/// <para>One standard deviation—Output ellipses will cover one standard deviation of the input features. This is the default.</para>
		/// <para>Two standard deviations—Output ellipses will cover two standard deviations of the input features.</para>
		/// <para>Three standard deviations—Output ellipses will cover three standard deviations of the input features.</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EllipseSize { get; set; } = "1_STANDARD_DEVIATION";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>A numeric field used to weight locations according to their relative importance. This applies to all summary types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>The field used to group similar features. This applies to all summary types. For example, if you choose a field named PlantType that contains values of tree, bush, and grass, all of the features with the value tree will be analyzed for their own center or dispersion. This example will result in three features, one for each group of tree, bush, and grass.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? GroupByField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeCenterAndDispersion SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ellipse Size</para>
		/// </summary>
		public enum EllipseSizeEnum 
		{
			/// <summary>
			/// <para>One standard deviation—Output ellipses will cover one standard deviation of the input features. This is the default.</para>
			/// </summary>
			[GPValue("1_STANDARD_DEVIATION")]
			[Description("One standard deviation")]
			One_standard_deviation,

			/// <summary>
			/// <para>Two standard deviations—Output ellipses will cover two standard deviations of the input features.</para>
			/// </summary>
			[GPValue("2_STANDARD_DEVIATIONS")]
			[Description("Two standard deviations")]
			Two_standard_deviations,

			/// <summary>
			/// <para>Three standard deviations—Output ellipses will cover three standard deviations of the input features.</para>
			/// </summary>
			[GPValue("3_STANDARD_DEVIATIONS")]
			[Description("Three standard deviations")]
			Three_standard_deviations,

		}

#endregion
	}
}
