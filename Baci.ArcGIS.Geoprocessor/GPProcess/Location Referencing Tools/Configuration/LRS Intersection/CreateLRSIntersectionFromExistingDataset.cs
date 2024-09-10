using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Create LRS Intersection From Existing Dataset</para>
	/// <para>Registers an existing intersection feature class as an intersection.</para>
	/// </summary>
	public class CreateLRSIntersectionFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>The network to which the intersection will be registered.</para>
		/// </param>
		/// <param name="NetworkDescriptionField">
		/// <para>Network Description Field</para>
		/// <para>The field in the network layer that will be used to name the intersections with other intersecting layers.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Intersection Feature Class</para>
		/// <para>The input point feature class to be registered.</para>
		/// </param>
		/// <param name="IntersectionIdField">
		/// <para>Intersection ID Field</para>
		/// <para>The ID field in the Intersection Feature Class. The field must have a unique ID for each intersection for a time slice.</para>
		/// </param>
		/// <param name="IntersectionNameField">
		/// <para>Intersection Name Field</para>
		/// <para>The field in the Intersection Feature Class that is a concatenated field showing the descriptors for the route and the intersecting feature.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The field in the Intersection Feature Class that contains the route ID for the LRS Network.</para>
		/// </param>
		/// <param name="FeatureIdField">
		/// <para>Feature ID Field</para>
		/// <para>The field in the Intersection Feature Class that contains the ID for the intersecting feature.</para>
		/// </param>
		/// <param name="FeatureClassNameField">
		/// <para>Feature Class Name Field</para>
		/// <para>The field in the Intersection Feature Class that contains the name of the feature class that participated in the intersection.</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>The from date field in the Intersection Feature Class.</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>The to date field in the Intersection Feature Class.</para>
		/// </param>
		/// <param name="IntersectingLayers">
		/// <para>Intersecting Layers</para>
		/// <para>The feature class that intersects the LRS Network and contains the following information:</para>
		/// <para>Intersection Layer—The feature class that intersects the LRS Network.</para>
		/// <para>ID Field—The field in the intersecting layer used to uniquely identify the feature that intersects the network.</para>
		/// <para>Description Field—The field that provides the description, such as town or county name, of the intersecting feature.</para>
		/// <para>Name Separator—The name separator for the intersection, such as AND, INTERSECT, +, or |.</para>
		/// </param>
		public CreateLRSIntersectionFromExistingDataset(object ParentNetwork, object NetworkDescriptionField, object InFeatureClass, object IntersectionIdField, object IntersectionNameField, object RouteIdField, object FeatureIdField, object FeatureClassNameField, object FromDateField, object ToDateField, object IntersectingLayers)
		{
			this.ParentNetwork = ParentNetwork;
			this.NetworkDescriptionField = NetworkDescriptionField;
			this.InFeatureClass = InFeatureClass;
			this.IntersectionIdField = IntersectionIdField;
			this.IntersectionNameField = IntersectionNameField;
			this.RouteIdField = RouteIdField;
			this.FeatureIdField = FeatureIdField;
			this.FeatureClassNameField = FeatureClassNameField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.IntersectingLayers = IntersectingLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS Intersection From Existing Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create LRS Intersection From Existing Dataset";

		/// <summary>
		/// <para>Tool Name : CreateLRSIntersectionFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSIntersectionFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSIntersectionFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSIntersectionFromExistingDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ParentNetwork, NetworkDescriptionField, InFeatureClass, IntersectionIdField, IntersectionNameField, RouteIdField, FeatureIdField, FeatureClassNameField, FromDateField, ToDateField, IntersectingLayers, ConsiderZ, ZTolerance, MeasureField, OutFeatureClass };

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>The network to which the intersection will be registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>Network Description Field</para>
		/// <para>The field in the network layer that will be used to name the intersections with other intersecting layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object NetworkDescriptionField { get; set; }

		/// <summary>
		/// <para>Intersection Feature Class</para>
		/// <para>The input point feature class to be registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Intersection ID Field</para>
		/// <para>The ID field in the Intersection Feature Class. The field must have a unique ID for each intersection for a time slice.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID")]
		public object IntersectionIdField { get; set; }

		/// <summary>
		/// <para>Intersection Name Field</para>
		/// <para>The field in the Intersection Feature Class that is a concatenated field showing the descriptors for the route and the intersecting feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object IntersectionNameField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the Intersection Feature Class that contains the route ID for the LRS Network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Feature ID Field</para>
		/// <para>The field in the Intersection Feature Class that contains the ID for the intersecting feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FeatureIdField { get; set; }

		/// <summary>
		/// <para>Feature Class Name Field</para>
		/// <para>The field in the Intersection Feature Class that contains the name of the feature class that participated in the intersection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FeatureClassNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>The from date field in the Intersection Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>The to date field in the Intersection Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Intersecting Layers</para>
		/// <para>The feature class that intersects the LRS Network and contains the following information:</para>
		/// <para>Intersection Layer—The feature class that intersects the LRS Network.</para>
		/// <para>ID Field—The field in the intersecting layer used to uniquely identify the feature that intersects the network.</para>
		/// <para>Description Field—The field that provides the description, such as town or county name, of the intersecting feature.</para>
		/// <para>Name Separator—The name separator for the intersection, such as AND, INTERSECT, +, or |.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object IntersectingLayers { get; set; }

		/// <summary>
		/// <para>Consider z-values when generating intersections</para>
		/// <para>Specifies whether z-values will be used when generating intersections.</para>
		/// <para>Checked—Z-values will be used during generation of intersections.</para>
		/// <para>Unchecked—Z-values will not be used during generation of intersections. This is the default.</para>
		/// <para><see cref="ConsiderZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConsiderZ { get; set; } = "false";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The z-tolerance used to generate intersections.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZTolerance { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>The measure on the base route at the point of intersection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Consider z-values when generating intersections</para>
		/// </summary>
		public enum ConsiderZEnum 
		{
			/// <summary>
			/// <para>Unchecked—Z-values will not be used during generation of intersections. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CONSIDER_Z")]
			DO_NOT_CONSIDER_Z,

			/// <summary>
			/// <para>Checked—Z-values will be used during generation of intersections.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONSIDER_Z")]
			CONSIDER_Z,

		}

#endregion
	}
}
