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
	/// <para>Generate Intersections</para>
	/// <para>Generate Intersections</para>
	/// <para>Generates new intersections and updates existing intersections.</para>
	/// </summary>
	public class GenerateIntersections : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InIntersectionFeatureClass">
		/// <para>Intersection Feature Class</para>
		/// <para>The input LRS intersection feature class or layer.</para>
		/// </param>
		public GenerateIntersections(object InIntersectionFeatureClass)
		{
			this.InIntersectionFeatureClass = InIntersectionFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Intersections</para>
		/// </summary>
		public override string DisplayName() => "Generate Intersections";

		/// <summary>
		/// <para>Tool Name : GenerateIntersections</para>
		/// </summary>
		public override string ToolName() => "GenerateIntersections";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateIntersections</para>
		/// </summary>
		public override string ExcuteName() => "locref.GenerateIntersections";

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
		public override object[] Parameters() => new object[] { InIntersectionFeatureClass, InNetworkLayer!, StartDate!, EditedByCurrentUser!, OutIntersectionFeatureClass!, OutDetailsFile! };

		/// <summary>
		/// <para>Intersection Feature Class</para>
		/// <para>The input LRS intersection feature class or layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InIntersectionFeatureClass { get; set; }

		/// <summary>
		/// <para>Network Layer</para>
		/// <para>The input LRS Network feature class or layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object? InNetworkLayer { get; set; }

		/// <summary>
		/// <para>Start Date</para>
		/// <para>Filters routes that have been edited after a certain date so that intersections can be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? StartDate { get; set; }

		/// <summary>
		/// <para>Only use routes edited by current user</para>
		/// <para>Specifies whether intersections will be generated only for routes edited and locked by the current user.</para>
		/// <para>Checked—Intersections will be generated only for routes edited by the current user. This is the default.</para>
		/// <para>Unchecked—Intersections will be generated for all edited routes.</para>
		/// <para><see cref="EditedByCurrentUserEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EditedByCurrentUser { get; set; } = "true";

		/// <summary>
		/// <para>Updated Intersection Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutIntersectionFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Only use routes edited by current user</para>
		/// </summary>
		public enum EditedByCurrentUserEnum 
		{
			/// <summary>
			/// <para>Checked—Intersections will be generated only for routes edited by the current user. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CURRENT_USER")]
			CURRENT_USER,

			/// <summary>
			/// <para>Unchecked—Intersections will be generated for all edited routes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_USERS")]
			ALL_USERS,

		}

#endregion
	}
}
