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
	/// <para>Create LRS Intersection</para>
	/// <para>Creates an intersection feature class for an existing LRS Network.</para>
	/// </summary>
	public class CreateLRSIntersection : AbstractGPProcess
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
		/// <param name="IntersectionFeatureClassName">
		/// <para>Intersection Feature Class</para>
		/// <para>The name of the new intersection point feature class.</para>
		/// </param>
		/// <param name="IntersectingLayers">
		/// <para>Intersecting Layers</para>
		/// <para>The feature class that intersects the LRS Network and contains the following information:</para>
		/// <para>Intersection Layer—The feature class that intersects the LRS Network.</para>
		/// <para>ID Field—The field in the intersecting layer used to uniquely identify the feature that intersects the network.</para>
		/// <para>Description Field—The field that provides the description, such as town or county name, of the intersecting feature.</para>
		/// <para>Name Separator—The name separator for the intersection, such as AND, INTERSECT, +, or |.</para>
		/// </param>
		public CreateLRSIntersection(object ParentNetwork, object NetworkDescriptionField, object IntersectionFeatureClassName, object IntersectingLayers)
		{
			this.ParentNetwork = ParentNetwork;
			this.NetworkDescriptionField = NetworkDescriptionField;
			this.IntersectionFeatureClassName = IntersectionFeatureClassName;
			this.IntersectingLayers = IntersectingLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS Intersection</para>
		/// </summary>
		public override string DisplayName() => "Create LRS Intersection";

		/// <summary>
		/// <para>Tool Name : CreateLRSIntersection</para>
		/// </summary>
		public override string ToolName() => "CreateLRSIntersection";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSIntersection</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSIntersection";

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
		public override object[] Parameters() => new object[] { ParentNetwork, NetworkDescriptionField, IntersectionFeatureClassName, IntersectingLayers, ConsiderZ, ZTolerance, OutFeatureClass };

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
		/// <para>The name of the new intersection point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IntersectionFeatureClassName { get; set; }

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
		/// <para>Output Feature Class</para>
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
