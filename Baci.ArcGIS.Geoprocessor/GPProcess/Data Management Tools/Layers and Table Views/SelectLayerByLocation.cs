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
	/// <para>Select Layer By Location</para>
	/// <para>Selects features  based on a spatial relationship to features in another dataset.</para>
	/// </summary>
	public class SelectLayerByLocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Features</para>
		/// <para>The features that will be evaluated against the Selecting Features parameter values. The selection will be applied to these features.</para>
		/// </param>
		public SelectLayerByLocation(object InLayer)
		{
			this.InLayer = InLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Select Layer By Location</para>
		/// </summary>
		public override string DisplayName => "Select Layer By Location";

		/// <summary>
		/// <para>Tool Name : SelectLayerByLocation</para>
		/// </summary>
		public override string ToolName => "SelectLayerByLocation";

		/// <summary>
		/// <para>Tool Excute Name : management.SelectLayerByLocation</para>
		/// </summary>
		public override string ExcuteName => "management.SelectLayerByLocation";

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
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLayer, OverlapType!, SelectFeatures!, SearchDistance!, SelectionType!, OutLayerOrView!, InvertSpatialRelationship!, OutLayersOrViews!, Count! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features that will be evaluated against the Selecting Features parameter values. The selection will be applied to these features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>Specifies the spatial relationship to be evaluated.</para>
		/// <para>Intersect—The features in the input layer will be selected if they intersect a selecting feature. This is the default.</para>
		/// <para>Intersect 3D—The features in the input layer will be selected if they intersect a selecting feature in three-dimensional space (x, y, and z).</para>
		/// <para>Intersect (DBMS)—The features in the input layer will be selected if they intersect a selecting feature. This option applies to enterprise geodatabases only. The selection will be processed in the enterprise geodatabase DBMS rather than on the client when all requirements are met (see more information in the usage notes). This option may provide better performance than performing the selection on the client.</para>
		/// <para>Within a distance—The features in the input layer will be selected if they are within the specified distance (using Euclidean distance) of a selecting feature. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Within a distance 3D—The features in the input layer will be selected if they are within a specified distance of a selecting feature in three-dimensional space. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Within a distance geodesic—The features in the input layer will be selected if they are within a specified distance of a selecting feature. Distance between features will be calculated using a geodesic formula that takes into account the curvature of the spheroid and correctly handles data near and across the dateline and poles. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Contains—The features in the input layer will be selected if they contain a selecting feature.</para>
		/// <para>Completely contains—The features in the input layer will be selected if they completely contain a selecting feature.</para>
		/// <para>Contains Clementini—This spatial relationship yields the same results as Contains with the exception that if the selecting feature is entirely on the boundary of the input feature (no part is properly inside or outside), the feature will not be selected. Clementini defines the boundary polygon as the line separating inside and outside, the boundary of a line is defined as its end points, and the boundary of a point is always empty.</para>
		/// <para>Within—The features in the input layer will be selected if they are within a selecting feature.</para>
		/// <para>Completely within—The features in the input layer will be selected if they are completely within or contained by a selecting feature.</para>
		/// <para>Within Clementini—The result will be identical to Within with the exception that if the entirety of the feature in the input layer is on the boundary of the feature in the selecting layer, the feature will not be selected. Clementini defines the boundary polygon as the line separating inside and outside, the boundary of a line is defined as its end points, and the boundary of a point is always empty.</para>
		/// <para>Are identical to—The features in the input layer will be selected if they are identical (in geometry) to a selecting feature.</para>
		/// <para>Boundary touches—The features in the input layer will be selected if they have a boundary that touches a selecting feature. When the input features are lines or polygons, the boundary of the input feature can only touch the boundary of the selecting feature, and no part of the input feature can cross the boundary of the selecting feature.</para>
		/// <para>Share a line segment with—The features in the input layer will be selected if they share a line segment with a selecting feature. The input and selecting features must be line or polygon.</para>
		/// <para>Crossed by the outline of—The features in the input layer will be selected if they are crossed by the outline of a selecting feature. The input and selecting features must be lines or polygons. If polygons are used for the input or selecting layer, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be selected; lines that share a line segment will not be selected.</para>
		/// <para>Have their center in—The features in the input layer will be selected if their center falls within a selecting feature. The center of the feature is calculated as follows: for polygon and multipoint, the geometry&apos;s centroid is used; for line input, the geometry&apos;s midpoint is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Selecting Features</para>
		/// <para>The features in the Input Features parameter will be selected based on their relationship to the features from this layer or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? SelectFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance that will be searched. This parameter is only valid if the Relationship parameter is set to Within a distance, Within a distance geodesic, Within a distance 3D, Intersect, Intersect 3D, Have their center in, or Contains.</para>
		/// <para>If the Within a distance geodesic option is selected, use a linear unit such as kilometers or miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>Specifies how the selection will be applied to the input and how it will be combined with an existing selection. This tool does not include an option to clear an existing selection; use the Clear the current selection option on the Select Layer By Attribute tool to do that.</para>
		/// <para>New selection—The resulting selection will replace any existing selection. This is the default.</para>
		/// <para>Add to the current selection—The resulting selection will be added to an existing selection. If no selection exists, this is the same as the New selection option.</para>
		/// <para>Remove from the current selection—The resulting selection will be removed from an existing selection. If no selection exists, the operation will have no effect.</para>
		/// <para>Select subset from the current selection—The resulting selection will be combined with the existing selection. Only records that are common to both remain selected.</para>
		/// <para>Switch the current selection—The selection will be switched. All records that were selected will be removed from the selection, and all records that were not selected will be added to the selection. The Selecting Features and Relationship parameters are ignored when this option is selected.</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Layer With Selection</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Invert Spatial Relationship</para>
		/// <para>Specifies whether the spatial relationship evaluation result or the opposite result will be used. For example, this parameter can be used to get a list of features that do not intersect or are not within a given distance of features in another dataset.</para>
		/// <para>Unchecked—The query result will be used. This is the default.</para>
		/// <para>Checked—The opposite of the query result will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
		/// <para><see cref="InvertSpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InvertSpatialRelationship { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutLayersOrViews { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? Count { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SelectLayerByLocation SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Selection Type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>New selection—The resulting selection will replace any existing selection. This is the default.</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("New selection")]
			New_selection,

			/// <summary>
			/// <para>Add to the current selection—The resulting selection will be added to an existing selection. If no selection exists, this is the same as the New selection option.</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("Add to the current selection")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>Remove from the current selection—The resulting selection will be removed from an existing selection. If no selection exists, the operation will have no effect.</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("Remove from the current selection")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>Select subset from the current selection—The resulting selection will be combined with the existing selection. Only records that are common to both remain selected.</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("Select subset from the current selection")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>Switch the current selection—The selection will be switched. All records that were selected will be removed from the selection, and all records that were not selected will be added to the selection. The Selecting Features and Relationship parameters are ignored when this option is selected.</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("Switch the current selection")]
			Switch_the_current_selection,

		}

		/// <summary>
		/// <para>Invert Spatial Relationship</para>
		/// </summary>
		public enum InvertSpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>Checked—The opposite of the query result will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para>Unchecked—The query result will be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INVERT")]
			NOT_INVERT,

		}

#endregion
	}
}
