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
	/// <para>Generate Geographies From Overlay</para>
	/// <para>Generates trade areas from the features of an input standard geography level that has a specified spatial relationship with the input.</para>
	/// </summary>
	public class GenerateGeographiesFromOverlay : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="GeographyLevel">
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the trade area.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features used to extract the standard geography level features by the specified spatial relationship. It can be either all features from the layer or only those selected once a selection is available.</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>The field used to identify the Input Features parameter—for example, the IDs of drive time polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature containing the trade area.</para>
		/// </param>
		public GenerateGeographiesFromOverlay(object GeographyLevel, object InFeatures, object IdField, object OutFeatureClass)
		{
			this.GeographyLevel = GeographyLevel;
			this.InFeatures = InFeatures;
			this.IdField = IdField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Geographies From Overlay</para>
		/// </summary>
		public override string DisplayName => "Generate Geographies From Overlay";

		/// <summary>
		/// <para>Tool Name : GenerateGeographiesFromOverlay</para>
		/// </summary>
		public override string ToolName => "GenerateGeographiesFromOverlay";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateGeographiesFromOverlay</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateGeographiesFromOverlay";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { GeographyLevel, InFeatures, IdField, OutFeatureClass, OverlapType, Ratios };

		/// <summary>
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeographyLevel { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features used to extract the standard geography level features by the specified spatial relationship. It can be either all features from the layer or only those selected once a selection is available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>The field used to identify the Input Features parameter—for example, the IDs of drive time polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature containing the trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>Specifies how the subgeography will be selected from the boundary layer.</para>
		/// <para>Intersect—If any of the subgeography features touch or intersect the boundary layer, they will be included in the output layer. This is the default.</para>
		/// <para>Have their center in—If the centroids of any of the subgeography features are contained within the boundary layer, they will be included in the output layer.</para>
		/// <para>Completely within—Only the features of the subgeography layer that are completely contained within the boundary layer will be included in the output layer.</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Ratios</para>
		/// <para>Specifies the ratios to be calculated.</para>
		/// <para>No ratios—No ratios will be implemented. This is the default.</para>
		/// <para>Area only—Only the ratios within the portion (area) of the standard geography level that intersects an input feature will be implemented.</para>
		/// <para>All ratios—All available ratios will be implemented. This option is not available when using online data.</para>
		/// <para><see cref="RatiosEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Ratios { get; set; } = "NO_RATIOS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateGeographiesFromOverlay SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Relationship</para>
		/// </summary>
		public enum OverlapTypeEnum 
		{
			/// <summary>
			/// <para>Intersect—If any of the subgeography features touch or intersect the boundary layer, they will be included in the output layer. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Have their center in—If the centroids of any of the subgeography features are contained within the boundary layer, they will be included in the output layer.</para>
			/// </summary>
			[GPValue("CENTROID_WITHIN")]
			[Description("Have their center in")]
			Have_their_center_in,

			/// <summary>
			/// <para>Completely within—Only the features of the subgeography layer that are completely contained within the boundary layer will be included in the output layer.</para>
			/// </summary>
			[GPValue("COMPLETELY_WITHIN")]
			[Description("Completely within")]
			Completely_within,

		}

		/// <summary>
		/// <para>Ratios</para>
		/// </summary>
		public enum RatiosEnum 
		{
			/// <summary>
			/// <para>No ratios—No ratios will be implemented. This is the default.</para>
			/// </summary>
			[GPValue("NO_RATIOS")]
			[Description("No ratios")]
			No_ratios,

			/// <summary>
			/// <para>Area only—Only the ratios within the portion (area) of the standard geography level that intersects an input feature will be implemented.</para>
			/// </summary>
			[GPValue("AREA_ONLY")]
			[Description("Area only")]
			Area_only,

			/// <summary>
			/// <para>All ratios—All available ratios will be implemented. This option is not available when using online data.</para>
			/// </summary>
			[GPValue("ALL_RATIOS")]
			[Description("All ratios")]
			All_ratios,

		}

#endregion
	}
}
