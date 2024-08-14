using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Feature Compare</para>
	/// <para>Compares two feature classes or layers and returns the comparison results.</para>
	/// </summary>
	public class FeatureCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseFeatures">
		/// <para>Input Base Features</para>
		/// <para>The Input Base Features are compared with the Input Test Features. Input Base Features refers to data that you have declared valid. This base data has the correct geometry definitions, field definitions, and spatial reference.</para>
		/// </param>
		/// <param name="InTestFeatures">
		/// <para>Input Test Features</para>
		/// <para>The Input Test Features are compared against the Input Base Features. Input Test Features refers to data that you have made changes to by editing or compiling new features.</para>
		/// </param>
		/// <param name="SortField">
		/// <para>Sort Field</para>
		/// <para>The field or fields used to sort records in the Input Base Features and the Input Test Features. The records are sorted in ascending order. Sorting by a common field in both the Input Base Features and the Input Test Features ensures that you are comparing the same row from each input dataset.</para>
		/// </param>
		public FeatureCompare(object InBaseFeatures, object InTestFeatures, object SortField)
		{
			this.InBaseFeatures = InBaseFeatures;
			this.InTestFeatures = InTestFeatures;
			this.SortField = SortField;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature Compare</para>
		/// </summary>
		public override string DisplayName => "Feature Compare";

		/// <summary>
		/// <para>Tool Name : FeatureCompare</para>
		/// </summary>
		public override string ToolName => "FeatureCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureCompare</para>
		/// </summary>
		public override string ExcuteName => "management.FeatureCompare";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InBaseFeatures, InTestFeatures, SortField, CompareType!, IgnoreOptions!, XyTolerance!, MTolerance!, ZTolerance!, AttributeTolerances!, OmitField!, ContinueCompare!, OutCompareFile!, CompareStatus! };

		/// <summary>
		/// <para>Input Base Features</para>
		/// <para>The Input Base Features are compared with the Input Test Features. Input Base Features refers to data that you have declared valid. This base data has the correct geometry definitions, field definitions, and spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InBaseFeatures { get; set; }

		/// <summary>
		/// <para>Input Test Features</para>
		/// <para>The Input Test Features are compared against the Input Base Features. Input Test Features refers to data that you have made changes to by editing or compiling new features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InTestFeatures { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>The field or fields used to sort records in the Input Base Features and the Input Test Features. The records are sorted in ascending order. Sorting by a common field in both the Input Base Features and the Input Test Features ensures that you are comparing the same row from each input dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>The comparison type. The default is All, which will compare all properties of the features being compared.</para>
		/// <para>All—All properties of the feature classes will be compared. This is the default.</para>
		/// <para>Geometry only—Only the geometries of the feature classes will be compared.</para>
		/// <para>Attributes only—Only the attributes and their values will be compared.</para>
		/// <para>Schema only—Only the schema of the feature classes will be compared.</para>
		/// <para>Spatial Reference only—Only the spatial references of the two feature classes will be compared.</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CompareType { get; set; } = "ALL";

		/// <summary>
		/// <para>Ignore Options</para>
		/// <para>These properties will not be compared.</para>
		/// <para>Ignore Ms—Do not compare measure properties.</para>
		/// <para>Ignore Zs—Do not compare elevation properties.</para>
		/// <para>Ignore PointIDs—Do not compare point ID properties.</para>
		/// <para>Ignore extension properties—Do not compare extension properties.</para>
		/// <para>Ignore subtypes—Do not compare subtypes.</para>
		/// <para>Ignore relationship classes—Do not compare relationship classes.</para>
		/// <para>Ignore representation classes—Do not compare representation classes.</para>
		/// <para>Ignore field alias—Do not compare field aliases.</para>
		/// <para><see cref="IgnoreOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? IgnoreOptions { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The distance that determines the range in which features are considered equal. To minimize error, the value you choose for the compare tolerance should be as small as possible. By default, the compare tolerance is the XY tolerance of the input base features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>M Tolerance</para>
		/// <para>The measure tolerance is the minimum distance between measures before they are considered equal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The Z Tolerance is the minimum distance between z coordinates before they are considered equal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Attribute Tolerance</para>
		/// <para>The numeric value that determines the range in which attribute values are considered equal. This only applies to numeric field types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AttributeTolerances { get; set; }

		/// <summary>
		/// <para>Omit Fields</para>
		/// <para>The field or fields that will be omitted during comparison. The field definitions and the tabular values for these fields will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OmitField { get; set; }

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>Indicates whether to compare all properties after encountering the first mismatch.</para>
		/// <para>Unchecked—Stops after encountering the first mismatch. This is the default.</para>
		/// <para>Checked—Compares other properties after encountering the first mismatch.</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>This file will contain all similarities and differences between the Input Base Features and the Input Test Features. This file is a comma-delimited text file that can be viewed and used as a table in ArcGIS.</para>
		/// <para>This file will contain all similarities and differences between the in_base_features and the in_test_features. This file is a comma-delimited text file that can be viewed and used as a table in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompareStatus { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>All—All properties of the feature classes will be compared. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Geometry only—Only the geometries of the feature classes will be compared.</para>
			/// </summary>
			[GPValue("GEOMETRY_ONLY")]
			[Description("Geometry only")]
			Geometry_only,

			/// <summary>
			/// <para>Attributes only—Only the attributes and their values will be compared.</para>
			/// </summary>
			[GPValue("ATTRIBUTES_ONLY")]
			[Description("Attributes only")]
			Attributes_only,

			/// <summary>
			/// <para>Schema only—Only the schema of the feature classes will be compared.</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("Schema only")]
			Schema_only,

			/// <summary>
			/// <para>Spatial Reference only—Only the spatial references of the two feature classes will be compared.</para>
			/// </summary>
			[GPValue("SPATIAL_REFERENCE_ONLY")]
			[Description("Spatial Reference only")]
			Spatial_Reference_only,

		}

		/// <summary>
		/// <para>Ignore Options</para>
		/// </summary>
		public enum IgnoreOptionsEnum 
		{
			/// <summary>
			/// <para>Ignore Ms—Do not compare measure properties.</para>
			/// </summary>
			[GPValue("IGNORE_M")]
			[Description("Ignore Ms")]
			Ignore_Ms,

			/// <summary>
			/// <para>Ignore Zs—Do not compare elevation properties.</para>
			/// </summary>
			[GPValue("IGNORE_Z")]
			[Description("Ignore Zs")]
			Ignore_Zs,

			/// <summary>
			/// <para>Ignore PointIDs—Do not compare point ID properties.</para>
			/// </summary>
			[GPValue("IGNORE_POINTID")]
			[Description("Ignore PointIDs")]
			Ignore_PointIDs,

			/// <summary>
			/// <para>Ignore extension properties—Do not compare extension properties.</para>
			/// </summary>
			[GPValue("IGNORE_EXTENSION_PROPERTIES")]
			[Description("Ignore extension properties")]
			Ignore_extension_properties,

			/// <summary>
			/// <para>Ignore subtypes—Do not compare subtypes.</para>
			/// </summary>
			[GPValue("IGNORE_SUBTYPES")]
			[Description("Ignore subtypes")]
			Ignore_subtypes,

			/// <summary>
			/// <para>Ignore relationship classes—Do not compare relationship classes.</para>
			/// </summary>
			[GPValue("IGNORE_RELATIONSHIPCLASSES")]
			[Description("Ignore relationship classes")]
			Ignore_relationship_classes,

			/// <summary>
			/// <para>Ignore representation classes—Do not compare representation classes.</para>
			/// </summary>
			[GPValue("IGNORE_REPRESENTATIONCLASSES")]
			[Description("Ignore representation classes")]
			Ignore_representation_classes,

			/// <summary>
			/// <para>Ignore field alias—Do not compare field aliases.</para>
			/// </summary>
			[GPValue("IGNORE_FIELDALIAS")]
			[Description("Ignore field alias")]
			Ignore_field_alias,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para>Checked—Compares other properties after encountering the first mismatch.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para>Unchecked—Stops after encountering the first mismatch. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
