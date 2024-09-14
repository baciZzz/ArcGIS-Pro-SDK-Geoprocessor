using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Compare Areas</para>
	/// <para>Compare Areas</para>
	/// <para>Compares movement point tracks across multiple known areas of interest.</para>
	/// </summary>
	public class CompareAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>The point features representing the movement track points. The layer can be time enabled.</para>
		/// </param>
		/// <param name="InAreaFeatures">
		/// <para>Input Area Features</para>
		/// <para>The area features representing the areas of interest that will be used to identify unique movement track point identifiers. The layer can be time enabled.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output area feature class. The output will contain a copy of the Input Area Features geometry and the unique identifiers from the Area Features Name Field and Point Features Name Field parameters.</para>
		/// <para>If both the Input Point Features and Input Area Features parameter values are time enabled and Relationship is set to Location and Time, only the features matching the geometry and the time span will be returned.</para>
		/// </param>
		/// <param name="PointIdField">
		/// <para>Point Features Name Field</para>
		/// <para>The field containing the unique identifiers for the movement track points. The field can be either a number or a string.</para>
		/// </param>
		/// <param name="AreaIdField">
		/// <para>Area Features Name Field</para>
		/// <para>The field containing the unique identifiers for the areas of interest. The field can be either a number or a string.</para>
		/// </param>
		/// <param name="Relationship">
		/// <para>Relationship</para>
		/// <para>Specifies the relationship between the inputs.</para>
		/// <para>Location Only— Points and area features will be evaluated based on spatial co-occurrence.</para>
		/// <para>Location and Time— Points and area features will be evaluated based on spatial and temporal co-occurrence.</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </param>
		public CompareAreas(object InPointFeatures, object InAreaFeatures, object OutFeatureclass, object PointIdField, object AreaIdField, object Relationship)
		{
			this.InPointFeatures = InPointFeatures;
			this.InAreaFeatures = InAreaFeatures;
			this.OutFeatureclass = OutFeatureclass;
			this.PointIdField = PointIdField;
			this.AreaIdField = AreaIdField;
			this.Relationship = Relationship;
		}

		/// <summary>
		/// <para>Tool Display Name : Compare Areas</para>
		/// </summary>
		public override string DisplayName() => "Compare Areas";

		/// <summary>
		/// <para>Tool Name : CompareAreas</para>
		/// </summary>
		public override string ToolName() => "CompareAreas";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.CompareAreas</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.CompareAreas";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, InAreaFeatures, OutFeatureclass, PointIdField, AreaIdField, Relationship, TimeDifference };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The point features representing the movement track points. The layer can be time enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Area Features</para>
		/// <para>The area features representing the areas of interest that will be used to identify unique movement track point identifiers. The layer can be time enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InAreaFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output area feature class. The output will contain a copy of the Input Area Features geometry and the unique identifiers from the Area Features Name Field and Point Features Name Field parameters.</para>
		/// <para>If both the Input Point Features and Input Area Features parameter values are time enabled and Relationship is set to Location and Time, only the features matching the geometry and the time span will be returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Point Features Name Field</para>
		/// <para>The field containing the unique identifiers for the movement track points. The field can be either a number or a string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object PointIdField { get; set; }

		/// <summary>
		/// <para>Area Features Name Field</para>
		/// <para>The field containing the unique identifiers for the areas of interest. The field can be either a number or a string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object AreaIdField { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>Specifies the relationship between the inputs.</para>
		/// <para>Location Only— Points and area features will be evaluated based on spatial co-occurrence.</para>
		/// <para>Location and Time— Points and area features will be evaluated based on spatial and temporal co-occurrence.</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Relationship { get; set; } = "LOCATION_ONLY";

		/// <summary>
		/// <para>Time Difference</para>
		/// <para>The time allowed between the Input Point Features and Input Area Features parameter values before a spatial relationship is considered invalid. This parameter is active when the Relationship parameter is set to Location and Time and both inputs are time enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object TimeDifference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CompareAreas SetEnviroment(object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Relationship</para>
		/// </summary>
		public enum RelationshipEnum 
		{
			/// <summary>
			/// <para>Location Only— Points and area features will be evaluated based on spatial co-occurrence.</para>
			/// </summary>
			[GPValue("LOCATION_ONLY")]
			[Description("Location Only")]
			Location_Only,

			/// <summary>
			/// <para>Location and Time— Points and area features will be evaluated based on spatial and temporal co-occurrence.</para>
			/// </summary>
			[GPValue("LOCATION_TIME")]
			[Description("Location and Time")]
			Location_and_Time,

		}

#endregion
	}
}
