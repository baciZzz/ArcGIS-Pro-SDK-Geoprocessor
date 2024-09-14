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
	/// <para>Subset Features</para>
	/// <para>Subset Features</para>
	/// <para>Divides the original dataset into two parts: one part to be used to model the spatial structure and produce a surface, the other to be used to compare and validate the output surface.</para>
	/// </summary>
	public class SubsetFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>Points, lines, polygon features, or table from which to create a subset.</para>
		/// </param>
		/// <param name="OutTrainingFeatureClass">
		/// <para>Output training feature class</para>
		/// <para>The subset of training features to be created.</para>
		/// </param>
		public SubsetFeatures(object InFeatures, object OutTrainingFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutTrainingFeatureClass = OutTrainingFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Subset Features</para>
		/// </summary>
		public override string DisplayName() => "Subset Features";

		/// <summary>
		/// <para>Tool Name : SubsetFeatures</para>
		/// </summary>
		public override string ToolName() => "SubsetFeatures";

		/// <summary>
		/// <para>Tool Excute Name : ga.SubsetFeatures</para>
		/// </summary>
		public override string ExcuteName() => "ga.SubsetFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutTrainingFeatureClass, OutTestFeatureClass!, SizeOfTrainingDataset!, SubsetSizeUnits! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>Points, lines, polygon features, or table from which to create a subset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output training feature class</para>
		/// <para>The subset of training features to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Output test feature class</para>
		/// <para>The subset of test features to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? OutTestFeatureClass { get; set; }

		/// <summary>
		/// <para>Size of training  feature subset</para>
		/// <para>The size of the output training feature class, entered either as a percentage of the input features or as an absolute number of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 100)]
		public object? SizeOfTrainingDataset { get; set; } = "50";

		/// <summary>
		/// <para>Subset size units</para>
		/// <para>Type of subset size.</para>
		/// <para>Percentage of input— The percentage of the input features that will be in the training dataset.</para>
		/// <para>Absolute value— The number of features that will be in the training dataset.</para>
		/// <para><see cref="SubsetSizeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SubsetSizeUnits { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubsetFeatures SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Subset size units</para>
		/// </summary>
		public enum SubsetSizeUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PERCENTAGE_OF_INPUT")]
			PERCENTAGE_OF_INPUT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE_VALUE")]
			ABSOLUTE_VALUE,

		}

#endregion
	}
}
