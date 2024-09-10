using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Add Point Layer Based Suitability Criteria</para>
	/// <para>Adds criteria based on spatial relationships between the input layer and a given point layer.</para>
	/// </summary>
	public class AddPointLayerBasedSuitabilityCriteria : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAnalysisLayer">
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis layer that will be used in the analysis.</para>
		/// </param>
		/// <param name="SiteLayerIdField">
		/// <para>Site Layer ID Field</para>
		/// <para>A field containing unique values for each record within the Suitability Analysis layer.</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Point Features</para>
		/// <para>The layer containing point locations to be added as criteria based on spatial relationship to the Suitability Analysis layer.</para>
		/// </param>
		/// <param name="CriteriaType">
		/// <para>Criteria Type</para>
		/// <para>Defines the type of spatial relationship to be used as criteria.</para>
		/// <para>Count—A count of points that fall within each Suitability Analysis layer polygon. This is the default.</para>
		/// <para>Weight—Calculates field-weighted criteria of points that fall within each Suitability Analysis polygon based on the user-selected statistical type.</para>
		/// <para>Minimal Distance—Adds distance from the closest point to each of the Suitability Analysis layer centroids as criteria.</para>
		/// <para><see cref="CriteriaTypeEnum"/></para>
		/// </param>
		/// <param name="WeightField">
		/// <para>Weight Field</para>
		/// <para>Numeric fields that exist within a point layer that can be selected for weighting.</para>
		/// </param>
		public AddPointLayerBasedSuitabilityCriteria(object InAnalysisLayer, object SiteLayerIdField, object InPointFeatures, object CriteriaType, object WeightField)
		{
			this.InAnalysisLayer = InAnalysisLayer;
			this.SiteLayerIdField = SiteLayerIdField;
			this.InPointFeatures = InPointFeatures;
			this.CriteriaType = CriteriaType;
			this.WeightField = WeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Point Layer Based Suitability Criteria</para>
		/// </summary>
		public override string DisplayName() => "Add Point Layer Based Suitability Criteria";

		/// <summary>
		/// <para>Tool Name : AddPointLayerBasedSuitabilityCriteria</para>
		/// </summary>
		public override string ToolName() => "AddPointLayerBasedSuitabilityCriteria";

		/// <summary>
		/// <para>Tool Excute Name : ba.AddPointLayerBasedSuitabilityCriteria</para>
		/// </summary>
		public override string ExcuteName() => "ba.AddPointLayerBasedSuitabilityCriteria";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "baNetworkSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAnalysisLayer, SiteLayerIdField, InPointFeatures, CriteriaType, DistanceType, Units, InSiteCentersFeatures, SiteCentersIdField, WeightField, StatisticsType, OutAnalysisLayer, OutCriteriaName, CutoffDistance };

		/// <summary>
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Site Layer ID Field</para>
		/// <para>A field containing unique values for each record within the Suitability Analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object SiteLayerIdField { get; set; }

		/// <summary>
		/// <para>Point Features</para>
		/// <para>The layer containing point locations to be added as criteria based on spatial relationship to the Suitability Analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Criteria Type</para>
		/// <para>Defines the type of spatial relationship to be used as criteria.</para>
		/// <para>Count—A count of points that fall within each Suitability Analysis layer polygon. This is the default.</para>
		/// <para>Weight—Calculates field-weighted criteria of points that fall within each Suitability Analysis polygon based on the user-selected statistical type.</para>
		/// <para>Minimal Distance—Adds distance from the closest point to each of the Suitability Analysis layer centroids as criteria.</para>
		/// <para><see cref="CriteriaTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CriteriaType { get; set; } = "COUNT";

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>Defines how minimal distance is calculated based on method of travel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Measure Units</para>
		/// <para>Defines the type of distance measuring units to be used when calculating minimal distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Units { get; set; }

		/// <summary>
		/// <para>Site Centers Features</para>
		/// <para>The point layer that will be used as site centers. This point layer will replace default polygon centroids of the Suitability Analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InSiteCentersFeatures { get; set; }

		/// <summary>
		/// <para>Site Centers Layer ID Field</para>
		/// <para>A field existing within the Site Centers Features parameter that uniquely identifies each record.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object SiteCentersIdField { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>Numeric fields that exist within a point layer that can be selected for weighting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Float", "Long", "Short")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>The type of statistical operation to be applied to the weighted field.</para>
		/// <para>Sum—Calculates the total of the field values in each point feature.</para>
		/// <para>Average—Determines the average field value in each point feature.</para>
		/// <para>Standard Deviation—Calculates the standard deviation of the field values in each point feature.</para>
		/// <para>Minimum—Determines the smallest field value in each point feature.</para>
		/// <para>Maximum—Determines the largest field value in each point feature.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; }

		/// <summary>
		/// <para>Output Suitability Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output Criteria Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutCriteriaName { get; set; }

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>The distance beyond which points will not be considered in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object CutoffDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddPointLayerBasedSuitabilityCriteria SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Criteria Type</para>
		/// </summary>
		public enum CriteriaTypeEnum 
		{
			/// <summary>
			/// <para>Count—A count of points that fall within each Suitability Analysis layer polygon. This is the default.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count")]
			Count,

			/// <summary>
			/// <para>Weight—Calculates field-weighted criteria of points that fall within each Suitability Analysis polygon based on the user-selected statistical type.</para>
			/// </summary>
			[GPValue("WEIGHT")]
			[Description("Weight")]
			Weight,

			/// <summary>
			/// <para>Minimal Distance—Adds distance from the closest point to each of the Suitability Analysis layer centroids as criteria.</para>
			/// </summary>
			[GPValue("MINIMAL_DISTANCE")]
			[Description("Minimal Distance")]
			Minimal_Distance,

		}

		/// <summary>
		/// <para>Statistics Type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Sum—Calculates the total of the field values in each point feature.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Average—Determines the average field value in each point feature.</para>
			/// </summary>
			[GPValue("AVE")]
			[Description("Average")]
			Average,

			/// <summary>
			/// <para>Standard Deviation—Calculates the standard deviation of the field values in each point feature.</para>
			/// </summary>
			[GPValue("STD_DEV")]
			[Description("Standard Deviation")]
			Standard_Deviation,

			/// <summary>
			/// <para>Minimum—Determines the smallest field value in each point feature.</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—Determines the largest field value in each point feature.</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

		}

#endregion
	}
}
