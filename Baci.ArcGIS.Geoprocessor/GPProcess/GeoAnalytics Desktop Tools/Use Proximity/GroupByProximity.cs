using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Group By Proximity</para>
	/// <para>Groups features that are within spatial or spatiotemporal proximity to each other.</para>
	/// </summary>
	public class GroupByProximity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be grouped.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output</para>
		/// <para>The output feature class with grouped features represented by a new field named group_id.</para>
		/// </param>
		/// <param name="SpatialRelationship">
		/// <para>Spatial Relationship</para>
		/// <para>Specifies the type of relationship that features will be grouped by.</para>
		/// <para>Intersects—Features will be grouped when features or portions of features overlap. This is the default.</para>
		/// <para>Touches—Features will be grouped with another feature if they have an intersecting vertex, but the features do not overlap.</para>
		/// <para>Planar Near—Features will be grouped when a vertex or edge is within a given planar distance of another feature.</para>
		/// <para>Geodesic Near—Features will be grouped when a vertex or edge is within a given geodesic distance of another feature.</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </param>
		public GroupByProximity(object InputLayer, object Output, object SpatialRelationship)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
			this.SpatialRelationship = SpatialRelationship;
		}

		/// <summary>
		/// <para>Tool Display Name : Group By Proximity</para>
		/// </summary>
		public override string DisplayName => "Group By Proximity";

		/// <summary>
		/// <para>Tool Name : GroupByProximity</para>
		/// </summary>
		public override string ToolName => "GroupByProximity";

		/// <summary>
		/// <para>Tool Excute Name : gapro.GroupByProximity</para>
		/// </summary>
		public override string ExcuteName => "gapro.GroupByProximity";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, Output, SpatialRelationship, SpatialNearDistance!, TemporalRelationship!, TemporalNearDistance!, AttributeRelationship! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be grouped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// <para>The output feature class with grouped features represented by a new field named group_id.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>Specifies the type of relationship that features will be grouped by.</para>
		/// <para>Intersects—Features will be grouped when features or portions of features overlap. This is the default.</para>
		/// <para>Touches—Features will be grouped with another feature if they have an intersecting vertex, but the features do not overlap.</para>
		/// <para>Planar Near—Features will be grouped when a vertex or edge is within a given planar distance of another feature.</para>
		/// <para>Geodesic Near—Features will be grouped when a vertex or edge is within a given geodesic distance of another feature.</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialRelationship { get; set; } = "INTERSECTS";

		/// <summary>
		/// <para>Spatial Near Distance</para>
		/// <para>The distance that will be used to group near features. This parameter is only used when the Spatial Relationship parameter value is Planar Near or Geodesic Near.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SpatialNearDistance { get; set; }

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// <para>Specifies the time criteria that will be used to match features. When the parameter is set to Intersects or Near, features are grouped when both the spatial and time criteria are met. Time must be enabled on the input to support this option.</para>
		/// <para>Intersects—Features will be grouped when any part of a feature&apos;s time overlaps another feature. This is the default.</para>
		/// <para>Near—Features will be grouped when the feature&apos;s time is within a range of time of another feature.</para>
		/// <para>None—Time will not be used to group features.</para>
		/// <para><see cref="TemporalRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TemporalRelationship { get; set; } = "NONE";

		/// <summary>
		/// <para>Temporal Near Distance</para>
		/// <para>The temporal distance that will be used to group near features. This parameter is only used when the Temporal Relationship parameter value is Near.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TemporalNearDistance { get; set; }

		/// <summary>
		/// <para>Attribute Relationship</para>
		/// <para>An ArcGIS Arcade expression that will be used to group features by. For example, $a["Amount"] == $b["Amount"] groups features when the Amount field has the same value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AttributeRelationship { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GroupByProximity SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>Planar Near—Features will be grouped when a vertex or edge is within a given planar distance of another feature.</para>
			/// </summary>
			[GPValue("NEAR_PLANAR")]
			[Description("Planar Near")]
			Planar_Near,

			/// <summary>
			/// <para>Geodesic Near—Features will be grouped when a vertex or edge is within a given geodesic distance of another feature.</para>
			/// </summary>
			[GPValue("NEAR_GEODESIC")]
			[Description("Geodesic Near")]
			Geodesic_Near,

			/// <summary>
			/// <para>Touches—Features will be grouped with another feature if they have an intersecting vertex, but the features do not overlap.</para>
			/// </summary>
			[GPValue("TOUCHES")]
			[Description("Touches")]
			Touches,

			/// <summary>
			/// <para>Intersects—Features will be grouped when features or portions of features overlap. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("Intersects")]
			Intersects,

		}

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// </summary>
		public enum TemporalRelationshipEnum 
		{
			/// <summary>
			/// <para>Near—Features will be grouped when the feature&apos;s time is within a range of time of another feature.</para>
			/// </summary>
			[GPValue("NEAR")]
			[Description("Near")]
			Near,

			/// <summary>
			/// <para>Intersects—Features will be grouped when any part of a feature&apos;s time overlaps another feature. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("Intersects")]
			Intersects,

			/// <summary>
			/// <para>None—Time will not be used to group features.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

#endregion
	}
}
