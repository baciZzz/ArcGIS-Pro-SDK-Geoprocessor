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
	/// <para>Modify LRS Intersection</para>
	/// <para>Modify LRS Intersection</para>
	/// <para>Modifies the properties of an intersection feature class, such as fields and intersecting layers, that compose the intersection feature class and can be added or removed.</para>
	/// </summary>
	public class ModifyLRSIntersection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Intersection Feature Class</para>
		/// <para>The input LRS intersection feature layer. This feature class cannot be a service.</para>
		/// </param>
		public ModifyLRSIntersection(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify LRS Intersection</para>
		/// </summary>
		public override string DisplayName() => "Modify LRS Intersection";

		/// <summary>
		/// <para>Tool Name : ModifyLRSIntersection</para>
		/// </summary>
		public override string ToolName() => "ModifyLRSIntersection";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRSIntersection</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRSIntersection";

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
		public override object[] Parameters() => new object[] { InFeatureClass, IntersectionIdField, IntersectionNameField, RouteIdField, FeatureIdField, FeatureClassNameField, FromDateField, ToDateField, IntersectingLayers, MeasureField, OutFeatureClass };

		/// <summary>
		/// <para>Intersection Feature Class</para>
		/// <para>The input LRS intersection feature layer. This feature class cannot be a service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Intersection ID Field</para>
		/// <para>The field in the Intersection Feature Class to use as the intersection unique ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID")]
		public object IntersectionIdField { get; set; }

		/// <summary>
		/// <para>Intersection Name Field</para>
		/// <para>The concatenated field in the Intersection Feature Class that contains the descriptors for the route and the intersecting feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object IntersectionNameField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the Intersection Feature Class that contains the unique route ID.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Feature ID Field</para>
		/// <para>The field in the Intersection Feature Class that contains the ID of the intersecting feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FeatureIdField { get; set; }

		/// <summary>
		/// <para>Feature Class Name Field</para>
		/// <para>The field in the Intersection Feature Class that contains the name of the feature class that participated in the intersection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FeatureClassNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>The field in the Intersection Feature Class that contains the from date of the route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>The field in the Intersection Feature Class that contains the to date of the route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Intersecting Layers</para>
		/// <para>The Intersection Feature Class fields that compose the intersecting layer.</para>
		/// <para>Intersection Layer—The feature class that intersects the LRS Network.</para>
		/// <para>ID Field—The field in the intersecting layer used to uniquely identify the feature that intersects the network.</para>
		/// <para>Description Field—The field that provides the description, such as town or county name, of the intersecting feature.</para>
		/// <para>Name Separator—The name separator for the intersection, such as AND, INTERSECT, +, or |.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object IntersectingLayers { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>The field in the Intersection Feature Class that contains the measure on the base route at the point of intersection.</para>
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

	}
}
