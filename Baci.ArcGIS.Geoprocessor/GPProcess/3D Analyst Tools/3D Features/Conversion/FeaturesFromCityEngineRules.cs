using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Features From CityEngine Rules</para>
	/// <para>Generates 3D geometries  from existing 2D and 3D input features using rules authored in ArcGIS CityEngine.</para>
	/// </summary>
	public class FeaturesFromCityEngineRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>Input point, polygon, or multipatch features. Input features can be procedurally symbolized feature layers. Field mapping (attribute-driven symbol properties) will be honored.</para>
		/// </param>
		/// <param name="InRulePackage">
		/// <para>Rule Package</para>
		/// <para>The CityEngine rule package (*.rpk) file containing CGA rule information and assets. The rule annotated with @StartRule in the CityEngine rule package (.rpk) file should be annotated @InPoint for a rule package intended for point features, @InPolygon for a rule package intended for polygon features, or @InMesh for a rule package intended for multipatch features. If the @StartRule is not annotated with @InPoint, @InPolygon, or @InMesh, the feature type will be assumed to be polygon.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Features</para>
		/// <para>The output feature class containing multipatch features with CGA rules applied. A field named OriginalOID is added to the output feature class(es) to contain the ObjectID of the input feature from which each output feature has been generated.</para>
		/// </param>
		public FeaturesFromCityEngineRules(object InFeatures, object InRulePackage, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.InRulePackage = InRulePackage;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Features From CityEngine Rules</para>
		/// </summary>
		public override string DisplayName => "Features From CityEngine Rules";

		/// <summary>
		/// <para>Tool Name : FeaturesFromCityEngineRules</para>
		/// </summary>
		public override string ToolName => "FeaturesFromCityEngineRules";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FeaturesFromCityEngineRules</para>
		/// </summary>
		public override string ExcuteName => "3d.FeaturesFromCityEngineRules";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, InRulePackage, OutFeatureClass, InExistingFields, InIncludeReports, InLeafShapes, OutPoints, OutLines, OutMultipoints };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>Input point, polygon, or multipatch features. Input features can be procedurally symbolized feature layers. Field mapping (attribute-driven symbol properties) will be honored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "MultiPatch", "Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Rule Package</para>
		/// <para>The CityEngine rule package (*.rpk) file containing CGA rule information and assets. The rule annotated with @StartRule in the CityEngine rule package (.rpk) file should be annotated @InPoint for a rule package intended for point features, @InPolygon for a rule package intended for polygon features, or @InMesh for a rule package intended for multipatch features. If the @StartRule is not annotated with @InPoint, @InPolygon, or @InMesh, the feature type will be assumed to be polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rpk")]
		public object InRulePackage { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing multipatch features with CGA rules applied. A field named OriginalOID is added to the output feature class(es) to contain the ObjectID of the input feature from which each output feature has been generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Include Existing Fields</para>
		/// <para>Controls whether the output feature class inherits the attribute fields of the input feature class.</para>
		/// <para>Checked—The attribute fields of the input feature class will be included in the output feature class. This is the default.</para>
		/// <para>Unchecked—No attribute fields originating from the input feature class will be added to the output feature class. This option will be used automatically if the Export Leaf Shapes parameter is checked.</para>
		/// <para><see cref="InExistingFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InExistingFields { get; set; } = "true";

		/// <summary>
		/// <para>Include Reports</para>
		/// <para>Depending on how the rule package has been authored, it may contain logic that generates one or more reports as the models are created. These reports can hold a wide variety of information about the features. An example is a rule package that reports the number of windows generated for each building model. This parameter is ignored if the rule package does not contain logic to generate reports.</para>
		/// <para>Checked—New attribute fields are created on the output feature class to hold reported value for each feature as defined by the rule package report generation logic. A unique attribute is created for each reported value.</para>
		/// <para>Unchecked—Reports generated within the rule package are ignored, and no new attributes relating to these reports are generated. This is the default.</para>
		/// <para><see cref="InIncludeReportsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InIncludeReports { get; set; } = "false";

		/// <summary>
		/// <para>Export Leaf Shapes</para>
		/// <para>CityEngine rule packages construct content by generating component pieces and merging them together into a single 3D object. However, it is also possible to store these components, or leaf shapes, as separate features. This option can be especially important for running analytical operations against subelements of a 3D object, such as the windows of a building.</para>
		/// <para>This parameter determines whether each input feature is one of the following:</para>
		/// <para>Converted into a single, merged, multipatch feature</para>
		/// <para>Becomes a set of many features that can be points, lines, or multipatches</para>
		/// <para>For example, a rule may generate seamless building models from input polygon footprints, or alternatively, it could create separate features for each apartment face, including an outward-facing panel, a representative center point, and lines showing the borders. In this example, the apartment panels, center points, and outlines are all considered leaf shapes.</para>
		/// <para>Checked—Additional output feature classes are generated. This is the default. The attribute fields from the input feature class are not included in the output feature class. The output feature class contains a field named OriginalOID that references the ObjectID of the input feature from which the output was generated.</para>
		/// <para>Unchecked—Additional output feature classes are not generated, even if additional leaf shapes are defined in the logic of the rule. All of the geometry is contained within the output multipatch features.</para>
		/// <para><see cref="InLeafShapesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InLeafShapes { get; set; } = "false";

		/// <summary>
		/// <para>Output Point Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPoints { get; set; } = "output_feature_class_Point";

		/// <summary>
		/// <para>Output Line Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutLines { get; set; } = "output_feature_class_Line";

		/// <summary>
		/// <para>Output Multipoint Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutMultipoints { get; set; } = "output_feature_class_MPoint";

		#region InnerClass

		/// <summary>
		/// <para>Include Existing Fields</para>
		/// </summary>
		public enum InExistingFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—The attribute fields of the input feature class will be included in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_EXISTING_FIELDS")]
			INCLUDE_EXISTING_FIELDS,

			/// <summary>
			/// <para>Unchecked—No attribute fields originating from the input feature class will be added to the output feature class. This option will be used automatically if the Export Leaf Shapes parameter is checked.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DROP_EXISTING_FIELDS")]
			DROP_EXISTING_FIELDS,

		}

		/// <summary>
		/// <para>Include Reports</para>
		/// </summary>
		public enum InIncludeReportsEnum 
		{
			/// <summary>
			/// <para>Checked—New attribute fields are created on the output feature class to hold reported value for each feature as defined by the rule package report generation logic. A unique attribute is created for each reported value.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_REPORTS")]
			INCLUDE_REPORTS,

			/// <summary>
			/// <para>Unchecked—Reports generated within the rule package are ignored, and no new attributes relating to these reports are generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_REPORTS")]
			EXCLUDE_REPORTS,

		}

		/// <summary>
		/// <para>Export Leaf Shapes</para>
		/// </summary>
		public enum InLeafShapesEnum 
		{
			/// <summary>
			/// <para>Checked—Additional output feature classes are generated. This is the default. The attribute fields from the input feature class are not included in the output feature class. The output feature class contains a field named OriginalOID that references the ObjectID of the input feature from which the output was generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FEATURE_PER_LEAF_SHAPE")]
			FEATURE_PER_LEAF_SHAPE,

			/// <summary>
			/// <para>Unchecked—Additional output feature classes are not generated, even if additional leaf shapes are defined in the logic of the rule. All of the geometry is contained within the output multipatch features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FEATURE_PER_SHAPE")]
			FEATURE_PER_SHAPE,

		}

#endregion
	}
}
