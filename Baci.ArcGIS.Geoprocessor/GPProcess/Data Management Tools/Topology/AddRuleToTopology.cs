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
	/// <para>Add Rule To Topology</para>
	/// <para>Adds a new rule to a topology.</para>
	/// </summary>
	public class AddRuleToTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The topology to which the new rule will be added.</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>The topology rule to be added. For a complete list of the rules and what they do, see the topology rules and fixes for point, line, or polygon features.</para>
		/// <para>Must Not Have Gaps (Area)— This rule requires that there are no voids within a single polygon or between adjacent polygons. All polygons must form a continuous surface. An error will always exist on the perimeter of the surface. You can either ignore this error or mark it as an exception. Use this rule on data that must completely cover an area. For example, soil polygons cannot include gaps or form voids-they must cover an entire area.</para>
		/// <para>Must Not Overlap (Area)— Requires that the interior of polygons not overlap. The polygons can share edges or vertices. This rule is used when an area cannot belong to two or more polygons. It is useful for modeling administrative boundaries, such as ZIP Codes or voting districts, and mutually exclusive area classifications, such as land cover or landform type.</para>
		/// <para>Must Be Covered By Feature Class Of (Area-Area)— Requires that a polygon in one feature class (or subtype) must share all of its area with polygons in another feature class (or subtype). An area in the first feature class that is not covered by polygons from the other feature class is an error. This rule is used when an area of one type, such as a state, should be completely covered by areas of another type, such as counties.</para>
		/// <para>Must Cover Each Other (Area-Area)— Requires that the polygons of one feature class (or subtype) must share all of their area with the polygons of another feature class (or subtype). Polygons may share edges or vertices. Any area defined in either feature class that is not shared with the other is an error. This rule is used when two systems of classification are used for the same geographic area, and any given point defined in one system must also be defined in the other. One such case occurs with nested hierarchical datasets, such as census blocks and block groups or small watersheds and large drainage basins. The rule can also be applied to nonhierarchically related polygon feature classes, such as soil type and slope class.</para>
		/// <para>Must Be Covered By (Area-Area)— Requires that polygons of one feature class (or subtype) must be contained within polygons of another feature class (or subtype). Polygons may share edges or vertices. Any area defined in the contained feature class must be covered by an area in the covering feature class. This rule is used when area features of a given type must be located within features of another type. This rule is useful when modeling areas that are subsets of a larger surrounding area, such as management units within forests or blocks within block groups.</para>
		/// <para>Must Not Overlap With (Area-Area)— Requires that the interior of polygons in one feature class (or subtype) must not overlap with the interior of polygons in another feature class (or subtype). Polygons of the two feature classes can share edges or vertices or be completely disjointed. This rule is used when an area cannot belong to two separate feature classes. It is useful for combining two mutually exclusive systems of area classification, such as zoning and water body type, where areas defined within the zoning class cannot also be defined in the water body class and vice versa.</para>
		/// <para>Must Be Covered By Boundary Of (Line-Area)— Requires that lines be covered by the boundaries of area features. This is useful for modeling lines, such as lot lines, that must coincide with the edge of polygon features, such as lots.</para>
		/// <para>Must Be Covered By Boundary Of (Point-Area)— Requires that points fall on the boundaries of area features. This is useful when the point features help support the boundary system, such as boundary markers, which must be found on the edges of certain areas.</para>
		/// <para>Must Be Properly Inside (Point-Area)— Requires that points fall within area features. This is useful when the point features are related to polygons, such as wells and well pads or address points and parcels.</para>
		/// <para>Must Not Overlap (Line)— Requires that lines not overlap with lines in the same feature class (or subtype). This rule is used where line segments should not be duplicated, for example, in a stream feature class. Lines can cross or intersect but cannot share segments.</para>
		/// <para>Must Not Intersect (Line)— Requires that line features from the same feature class (or subtype) not cross or overlap each other. Lines can share endpoints. This rule is used for contour lines that should never cross each other or in cases where the intersection of lines should only occur at endpoints, such as street segments and intersections.</para>
		/// <para>Must Not Have Dangles (Line)— Requires that a line feature must touch lines from the same feature class (or subtype) at both endpoints. An endpoint that is not connected to another line is called a dangle. This rule is used when line features must form closed loops, such as when they are defining the boundaries of polygon features. It may also be used in cases where lines typically connect to other lines, as with streets. In this case, exceptions can be used where the rule is occasionally violated, as with cul-de-sac or dead-end street segments.</para>
		/// <para>Must Not Have Pseudo-Nodes (Line)— Requires that a line connect to at least two other lines at each endpoint. Lines that connect to one other line (or to themselves) are said to have pseudo nodes. This rule is used where line features must form closed loops, such as when they define the boundaries of polygons or when line features logically must connect to two other line features at each end, as with segments in a stream network, with exceptions being marked for the originating ends of first-order streams.</para>
		/// <para>Must Be Covered By Feature Class Of (Line-Line)— Requires that lines from one feature class (or subtype) must be covered by the lines in another feature class (or subtype). This is useful for modeling logically different but spatially coincident lines, such as routes and streets. A bus route feature class must not depart from the streets defined in the street feature class.</para>
		/// <para>Must Not Overlap With (Line-Line)— Requires that a line from one feature class (or subtype) not overlap with line features in another feature class (or subtype). This rule is used when line features cannot share the same space. For example, roads must not overlap with railroads or depression subtypes of contour lines cannot overlap with other contour lines.</para>
		/// <para>Must Be Covered By (Point-Line)— Requires that points in one feature class be covered by lines in another feature class. It does not constrain the covering portion of the line to be an endpoint. This rule is useful for points that fall along a set of lines, such as highway signs along highways.</para>
		/// <para>Must Be Covered By Endpoint Of (Point-Line)— Requires that points in one feature class must be covered by the endpoints of lines in another feature class. This rule is similar to the line rule Endpoint Must Be Covered By except that, in cases where the rule is violated, it is the point feature that is marked as an error rather than the line. Boundary corner markers might be constrained to be covered by the endpoints of boundary lines.</para>
		/// <para>Boundary Must Be Covered By (Area-Line)— Requires that boundaries of polygon features must be covered by lines in another feature class. This rule is used when area features need to have line features that mark the boundaries of the areas. This is usually when the areas have one set of attributes and their boundaries have other attributes. For example, parcels might be stored in the geodatabase along with their boundaries. Each parcel might be defined by one or more line features that store information about their length or the date surveyed, and every parcel should exactly match its boundaries.</para>
		/// <para>Boundary Must Be Covered By Boundary Of (Area-Area)— Requires that boundaries of polygon features in one feature class (or subtype) be covered by boundaries of polygon features in another feature class (or subtype). This is useful when polygon features in one feature class, such as subdivisions, are composed of multiple polygons in another class, such as parcels, and the shared boundaries must be aligned.</para>
		/// <para>Must Not Self-Overlap (Line)— Requires that line features not overlap themselves. They can cross or touch themselves but must not have coincident segments. This rule is useful for features, such as streets, where segments might touch in a loop but where the same street should not follow the same course twice.</para>
		/// <para>Must Not Self-Intersect (Line)— Requires that line features not cross or overlap themselves. This rule is useful for lines, such as contour lines, that cannot cross themselves.</para>
		/// <para>Must Not Intersect Or Touch Interior (Line)— Requires that a line in one feature class (or subtype) must only touch other lines of the same feature class (or subtype) at endpoints. Any line segment in which features overlap or any intersection not at an endpoint is an error. This rule is useful where lines must only be connected at endpoints, such as in the case of lot lines, which must split (only connect to the endpoints of) back lot lines and cannot overlap each other.</para>
		/// <para>Endpoint Must Be Covered By (Line-Point)— Requires that the endpoints of line features must be covered by point features in another feature class. This is useful for modeling cases where a fitting must connect two pipes or a street intersection must be found at the junction of two streets.</para>
		/// <para>Contains Point (Area-Point)— Requires that a polygon in one feature class contain at least one point from another feature class. Points must be within the polygon, not on the boundary. This is useful when every polygon should have at least one associated point, such as when parcels must have an address point.</para>
		/// <para>Must Be Single Part (Line)— Requires that lines have only one part. This rule is useful where line features, such as highways, may not have multiple parts.</para>
		/// <para>Must Coincide With (Point-Point)— Requires that points in one feature class (or subtype) be coincident with points in another feature class (or subtype). This is useful for cases where points must be covered by other points, such as transformers must coincide with power poles in electric distribution networks and observation points must coincide with stations.</para>
		/// <para>Must Be Disjoint (Point)— Requires that points be separated spatially from other points in the same feature class (or subtype). Any points that overlap are errors. This is useful for ensuring that points are not coincident or duplicated within the same feature class, such as in layers of cities, parcel lot ID points, wells, or streetlamp poles.</para>
		/// <para>Must Not Intersect With (Line-Line)— Requires that line features from one feature class (or subtype) not cross or overlap lines from another feature class (or subtype). Lines can share endpoints. This rule is used when there are lines from two layers that should never cross each other or in cases where the intersection of lines should only occur at endpoints, such as streets and railroads.</para>
		/// <para>Must Not Intersect or Touch Interior With (Line-Line)— Requires that a line in one feature class (or subtype) must only touch other lines of another feature class (or subtype) at endpoints. Any line segment in which features overlap or any intersection not at an endpoint is an error. This rule is useful where lines from two layers must only be connected at endpoints.</para>
		/// <para>Must Be Inside (Line-Area)— Requires that a line is contained within the boundary of an area feature. This is useful for cases where lines may partially or totally coincide with area boundaries but cannot extend beyond polygons, such as state highways that must be inside state borders and rivers that must be within watersheds.</para>
		/// <para>Contains One Point (Area-Point)— Requires that each polygon contains one point feature and that each point feature falls within a single polygon. This is used when there must be a one-to-one correspondence between features of a polygon feature class and features of a point feature class, such as administrative boundaries and their capital cities. Each point must be properly inside exactly one polygon and each polygon must properly contain exactly one point. Points must be within the polygon, not on the boundary.</para>
		/// </param>
		/// <param name="InFeatureclass">
		/// <para>Input Feature class</para>
		/// <para>The input or origin feature class.</para>
		/// </param>
		public AddRuleToTopology(object InTopology, object RuleType, object InFeatureclass)
		{
			this.InTopology = InTopology;
			this.RuleType = RuleType;
			this.InFeatureclass = InFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Rule To Topology</para>
		/// </summary>
		public override string DisplayName => "Add Rule To Topology";

		/// <summary>
		/// <para>Tool Name : AddRuleToTopology</para>
		/// </summary>
		public override string ToolName => "AddRuleToTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRuleToTopology</para>
		/// </summary>
		public override string ExcuteName => "management.AddRuleToTopology";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTopology, RuleType, InFeatureclass, Subtype, InFeatureclass2, Subtype2, OutTopology };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>The topology to which the new rule will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>The topology rule to be added. For a complete list of the rules and what they do, see the topology rules and fixes for point, line, or polygon features.</para>
		/// <para>Must Not Have Gaps (Area)— This rule requires that there are no voids within a single polygon or between adjacent polygons. All polygons must form a continuous surface. An error will always exist on the perimeter of the surface. You can either ignore this error or mark it as an exception. Use this rule on data that must completely cover an area. For example, soil polygons cannot include gaps or form voids-they must cover an entire area.</para>
		/// <para>Must Not Overlap (Area)— Requires that the interior of polygons not overlap. The polygons can share edges or vertices. This rule is used when an area cannot belong to two or more polygons. It is useful for modeling administrative boundaries, such as ZIP Codes or voting districts, and mutually exclusive area classifications, such as land cover or landform type.</para>
		/// <para>Must Be Covered By Feature Class Of (Area-Area)— Requires that a polygon in one feature class (or subtype) must share all of its area with polygons in another feature class (or subtype). An area in the first feature class that is not covered by polygons from the other feature class is an error. This rule is used when an area of one type, such as a state, should be completely covered by areas of another type, such as counties.</para>
		/// <para>Must Cover Each Other (Area-Area)— Requires that the polygons of one feature class (or subtype) must share all of their area with the polygons of another feature class (or subtype). Polygons may share edges or vertices. Any area defined in either feature class that is not shared with the other is an error. This rule is used when two systems of classification are used for the same geographic area, and any given point defined in one system must also be defined in the other. One such case occurs with nested hierarchical datasets, such as census blocks and block groups or small watersheds and large drainage basins. The rule can also be applied to nonhierarchically related polygon feature classes, such as soil type and slope class.</para>
		/// <para>Must Be Covered By (Area-Area)— Requires that polygons of one feature class (or subtype) must be contained within polygons of another feature class (or subtype). Polygons may share edges or vertices. Any area defined in the contained feature class must be covered by an area in the covering feature class. This rule is used when area features of a given type must be located within features of another type. This rule is useful when modeling areas that are subsets of a larger surrounding area, such as management units within forests or blocks within block groups.</para>
		/// <para>Must Not Overlap With (Area-Area)— Requires that the interior of polygons in one feature class (or subtype) must not overlap with the interior of polygons in another feature class (or subtype). Polygons of the two feature classes can share edges or vertices or be completely disjointed. This rule is used when an area cannot belong to two separate feature classes. It is useful for combining two mutually exclusive systems of area classification, such as zoning and water body type, where areas defined within the zoning class cannot also be defined in the water body class and vice versa.</para>
		/// <para>Must Be Covered By Boundary Of (Line-Area)— Requires that lines be covered by the boundaries of area features. This is useful for modeling lines, such as lot lines, that must coincide with the edge of polygon features, such as lots.</para>
		/// <para>Must Be Covered By Boundary Of (Point-Area)— Requires that points fall on the boundaries of area features. This is useful when the point features help support the boundary system, such as boundary markers, which must be found on the edges of certain areas.</para>
		/// <para>Must Be Properly Inside (Point-Area)— Requires that points fall within area features. This is useful when the point features are related to polygons, such as wells and well pads or address points and parcels.</para>
		/// <para>Must Not Overlap (Line)— Requires that lines not overlap with lines in the same feature class (or subtype). This rule is used where line segments should not be duplicated, for example, in a stream feature class. Lines can cross or intersect but cannot share segments.</para>
		/// <para>Must Not Intersect (Line)— Requires that line features from the same feature class (or subtype) not cross or overlap each other. Lines can share endpoints. This rule is used for contour lines that should never cross each other or in cases where the intersection of lines should only occur at endpoints, such as street segments and intersections.</para>
		/// <para>Must Not Have Dangles (Line)— Requires that a line feature must touch lines from the same feature class (or subtype) at both endpoints. An endpoint that is not connected to another line is called a dangle. This rule is used when line features must form closed loops, such as when they are defining the boundaries of polygon features. It may also be used in cases where lines typically connect to other lines, as with streets. In this case, exceptions can be used where the rule is occasionally violated, as with cul-de-sac or dead-end street segments.</para>
		/// <para>Must Not Have Pseudo-Nodes (Line)— Requires that a line connect to at least two other lines at each endpoint. Lines that connect to one other line (or to themselves) are said to have pseudo nodes. This rule is used where line features must form closed loops, such as when they define the boundaries of polygons or when line features logically must connect to two other line features at each end, as with segments in a stream network, with exceptions being marked for the originating ends of first-order streams.</para>
		/// <para>Must Be Covered By Feature Class Of (Line-Line)— Requires that lines from one feature class (or subtype) must be covered by the lines in another feature class (or subtype). This is useful for modeling logically different but spatially coincident lines, such as routes and streets. A bus route feature class must not depart from the streets defined in the street feature class.</para>
		/// <para>Must Not Overlap With (Line-Line)— Requires that a line from one feature class (or subtype) not overlap with line features in another feature class (or subtype). This rule is used when line features cannot share the same space. For example, roads must not overlap with railroads or depression subtypes of contour lines cannot overlap with other contour lines.</para>
		/// <para>Must Be Covered By (Point-Line)— Requires that points in one feature class be covered by lines in another feature class. It does not constrain the covering portion of the line to be an endpoint. This rule is useful for points that fall along a set of lines, such as highway signs along highways.</para>
		/// <para>Must Be Covered By Endpoint Of (Point-Line)— Requires that points in one feature class must be covered by the endpoints of lines in another feature class. This rule is similar to the line rule Endpoint Must Be Covered By except that, in cases where the rule is violated, it is the point feature that is marked as an error rather than the line. Boundary corner markers might be constrained to be covered by the endpoints of boundary lines.</para>
		/// <para>Boundary Must Be Covered By (Area-Line)— Requires that boundaries of polygon features must be covered by lines in another feature class. This rule is used when area features need to have line features that mark the boundaries of the areas. This is usually when the areas have one set of attributes and their boundaries have other attributes. For example, parcels might be stored in the geodatabase along with their boundaries. Each parcel might be defined by one or more line features that store information about their length or the date surveyed, and every parcel should exactly match its boundaries.</para>
		/// <para>Boundary Must Be Covered By Boundary Of (Area-Area)— Requires that boundaries of polygon features in one feature class (or subtype) be covered by boundaries of polygon features in another feature class (or subtype). This is useful when polygon features in one feature class, such as subdivisions, are composed of multiple polygons in another class, such as parcels, and the shared boundaries must be aligned.</para>
		/// <para>Must Not Self-Overlap (Line)— Requires that line features not overlap themselves. They can cross or touch themselves but must not have coincident segments. This rule is useful for features, such as streets, where segments might touch in a loop but where the same street should not follow the same course twice.</para>
		/// <para>Must Not Self-Intersect (Line)— Requires that line features not cross or overlap themselves. This rule is useful for lines, such as contour lines, that cannot cross themselves.</para>
		/// <para>Must Not Intersect Or Touch Interior (Line)— Requires that a line in one feature class (or subtype) must only touch other lines of the same feature class (or subtype) at endpoints. Any line segment in which features overlap or any intersection not at an endpoint is an error. This rule is useful where lines must only be connected at endpoints, such as in the case of lot lines, which must split (only connect to the endpoints of) back lot lines and cannot overlap each other.</para>
		/// <para>Endpoint Must Be Covered By (Line-Point)— Requires that the endpoints of line features must be covered by point features in another feature class. This is useful for modeling cases where a fitting must connect two pipes or a street intersection must be found at the junction of two streets.</para>
		/// <para>Contains Point (Area-Point)— Requires that a polygon in one feature class contain at least one point from another feature class. Points must be within the polygon, not on the boundary. This is useful when every polygon should have at least one associated point, such as when parcels must have an address point.</para>
		/// <para>Must Be Single Part (Line)— Requires that lines have only one part. This rule is useful where line features, such as highways, may not have multiple parts.</para>
		/// <para>Must Coincide With (Point-Point)— Requires that points in one feature class (or subtype) be coincident with points in another feature class (or subtype). This is useful for cases where points must be covered by other points, such as transformers must coincide with power poles in electric distribution networks and observation points must coincide with stations.</para>
		/// <para>Must Be Disjoint (Point)— Requires that points be separated spatially from other points in the same feature class (or subtype). Any points that overlap are errors. This is useful for ensuring that points are not coincident or duplicated within the same feature class, such as in layers of cities, parcel lot ID points, wells, or streetlamp poles.</para>
		/// <para>Must Not Intersect With (Line-Line)— Requires that line features from one feature class (or subtype) not cross or overlap lines from another feature class (or subtype). Lines can share endpoints. This rule is used when there are lines from two layers that should never cross each other or in cases where the intersection of lines should only occur at endpoints, such as streets and railroads.</para>
		/// <para>Must Not Intersect or Touch Interior With (Line-Line)— Requires that a line in one feature class (or subtype) must only touch other lines of another feature class (or subtype) at endpoints. Any line segment in which features overlap or any intersection not at an endpoint is an error. This rule is useful where lines from two layers must only be connected at endpoints.</para>
		/// <para>Must Be Inside (Line-Area)— Requires that a line is contained within the boundary of an area feature. This is useful for cases where lines may partially or totally coincide with area boundaries but cannot extend beyond polygons, such as state highways that must be inside state borders and rivers that must be within watersheds.</para>
		/// <para>Contains One Point (Area-Point)— Requires that each polygon contains one point feature and that each point feature falls within a single polygon. This is used when there must be a one-to-one correspondence between features of a polygon feature class and features of a point feature class, such as administrative boundaries and their capital cities. Each point must be properly inside exactly one polygon and each polygon must properly contain exactly one point. Points must be within the polygon, not on the boundary.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; } = "Must Not Have Gaps (Area)";

		/// <summary>
		/// <para>Input Feature class</para>
		/// <para>The input or origin feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>Input Subtype</para>
		/// <para>The subtype for the input or origin feature class. Enter the subtype's description (not the code). If subtypes do not exist on the origin feature class, or you want the rule to be applied to all subtypes in the feature class, leave this blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Subtype { get; set; }

		/// <summary>
		/// <para>Input Feature class</para>
		/// <para>The destination feature class for the topology rule.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object InFeatureclass2 { get; set; }

		/// <summary>
		/// <para>Input Subtype</para>
		/// <para>The subtype for the destination feature class. Enter the subtype's description (not the code). If subtypes do not exist on the origin feature class, or you want the rule to be applied to all subtypes in the feature class, leave this blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Subtype2 { get; set; }

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object OutTopology { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRuleToTopology SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
