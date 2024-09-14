using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Simplify By Straight Lines And Circular Arcs</para>
	/// <para>Simplify By Straight Lines And Circular Arcs</para>
	/// <para>Simplifies polygon and line features by replacing consecutive line segments  or edges with  fewer line segments or edges. Lines segments and polygon edges are simplified based on a specified maximum allowable offset.  Additionally, circular arcs can be created from consecutive  line segments or polygon edges.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SimplifyByStraightLinesAndCircularArcs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to be simplified. Features can be lines or polygons. If using multiple inputs, the features must have the same spatial reference.</para>
		/// </param>
		/// <param name="MaxOffset">
		/// <para>Maximum Allowable Offset</para>
		/// <para>The maximum distance the output feature edges can deviate from the input feature shapes. When the Fit to vertices option is chosen for the Fitting Type parameter, the distance is measured between the input vertices and the output feature edges. When the Fit to segments option is chosen, the distance is measured between the input feature edges and the output feature edges.</para>
		/// </param>
		public SimplifyByStraightLinesAndCircularArcs(object InFeatures, object MaxOffset)
		{
			this.InFeatures = InFeatures;
			this.MaxOffset = MaxOffset;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify By Straight Lines And Circular Arcs</para>
		/// </summary>
		public override string DisplayName() => "Simplify By Straight Lines And Circular Arcs";

		/// <summary>
		/// <para>Tool Name : SimplifyByStraightLinesAndCircularArcs</para>
		/// </summary>
		public override string ToolName() => "SimplifyByStraightLinesAndCircularArcs";

		/// <summary>
		/// <para>Tool Excute Name : edit.SimplifyByStraightLinesAndCircularArcs</para>
		/// </summary>
		public override string ExcuteName() => "edit.SimplifyByStraightLinesAndCircularArcs";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MaxOffset, FittingType!, CircularArcs!, MaxArcAngleStep!, MinVertexCount!, MinRadius!, MaxRadius!, MinArcAngle!, ClosedEnds!, OutFeatureClass!, AnchorPoints!, OutFeatureLayers! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to be simplified. Features can be lines or polygons. If using multiple inputs, the features must have the same spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Allowable Offset</para>
		/// <para>The maximum distance the output feature edges can deviate from the input feature shapes. When the Fit to vertices option is chosen for the Fitting Type parameter, the distance is measured between the input vertices and the output feature edges. When the Fit to segments option is chosen, the distance is measured between the input feature edges and the output feature edges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MaxOffset { get; set; }

		/// <summary>
		/// <para>Fitting Type</para>
		/// <para>Specifies how the output feature edges and circular arcs will be fitted to the input feature shapes.</para>
		/// <para>If Fit to segments is chosen, the Maximum Arc Angle Step and Minimum Number Of Vertices parameters are not available.</para>
		/// <para>Fit to vertices—The offset gap between the output feature edges and the input feature vertices will be minimized. Output feature edges and curves will be fitted approximately to the input feature vertex positions. This is the default.</para>
		/// <para>Fit to segments—The offset gap between the output feature edges and input feature edges will be minimized. Output edges and curves will be fitted approximately to the positions of the input feature shapes.</para>
		/// <para><see cref="FittingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FittingType { get; set; } = "FIT_TO_VERTICES";

		/// <summary>
		/// <para>Create circular arcs</para>
		/// <para>Specifies whether circular arcs will be created.</para>
		/// <para>Checked—Circular arcs will be created. This is the default.</para>
		/// <para>Unchecked—Circular arcs will not be created.</para>
		/// <para><see cref="CircularArcsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CircularArcs { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Arc Angle Step (decimal degrees)</para>
		/// <para>The maximum arc angle step (decimal degrees) that will be used to construct circular arcs. The arc angle defines how wide the visual field can be, for each step, when locating vertices to construct circular curves. The arc angle is the central angle of the candidate curve (the curve that is being constructed). If vertices are found within each maximum arc angle step, a circular arc is constructed. For example, if vertices and edges are sparse, use a large arc angle step. The valid value range is from 2 through 95 decimal degrees. The default is 20 decimal degrees. This parameter is not available if the Fit to segments option is chosen for the Fitting Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 2)]
		[High(Allow = true, Value = 95)]
		public object? MaxArcAngleStep { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Number Of Vertices</para>
		/// <para>The minimum number of vertices required for a circular arc to be created. The value must be greater than 3. The default is 4. This parameter is not available if the Fit to segments option is chosen for the Fitting Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = 3)]
		public object? MinVertexCount { get; set; } = "4";

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>The smallest allowable radius for output circular arcs. The value must be greater than 0 and smaller than the value specified for Maximum Radius. If no value is specified, the radius of the output circular arcs will not be checked (default).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinRadius { get; set; }

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>The largest allowable radius for output circular arcs. The value must be greater than the value specified for Minimum Radius. If no value is specified, the radius of the output circular arcs will not checked (default).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaxRadius { get; set; }

		/// <summary>
		/// <para>Minimum Arc Angle (decimal degrees)</para>
		/// <para>The minimum arc angle (decimal degrees) that will be used to construct circular arcs. The minimum arc angle is the smallest allowable central angle in the output circular arcs. If the central angle of any output circular arc is less than this value, it will not be created. The valid value range is from 2 through 360 decimal degrees. The default is 2 decimal degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 360)]
		public object? MinArcAngle { get; set; } = "2";

		/// <summary>
		/// <para>Preserve endpoints for closed line</para>
		/// <para>Specifies whether the endpoints of a closed line will be preserved. A closed line is a line that has coincident end points (loop).</para>
		/// <para>Checked—The endpoints of closed lines will be preserved. This is the default.</para>
		/// <para>Unchecked—The endpoints of closed lines will not be preserved; they can be moved or deleted.</para>
		/// <para><see cref="ClosedEndsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClosedEnds { get; set; } = "true";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Anchor Points</para>
		/// <para>The path and name of the feature class that contains anchor points. Anchor points overlay vertices on the input features and indicate that they should not be moved or deleted in the simplify process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object? AnchorPoints { get; set; }

		/// <summary>
		/// <para>Output Layer Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeatureLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyByStraightLinesAndCircularArcs SetEnviroment(object? extent = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fitting Type</para>
		/// </summary>
		public enum FittingTypeEnum 
		{
			/// <summary>
			/// <para>Fit to vertices—The offset gap between the output feature edges and the input feature vertices will be minimized. Output feature edges and curves will be fitted approximately to the input feature vertex positions. This is the default.</para>
			/// </summary>
			[GPValue("FIT_TO_VERTICES")]
			[Description("Fit to vertices")]
			Fit_to_vertices,

			/// <summary>
			/// <para>Fit to segments—The offset gap between the output feature edges and input feature edges will be minimized. Output edges and curves will be fitted approximately to the positions of the input feature shapes.</para>
			/// </summary>
			[GPValue("FIT_TO_SEGMENTS")]
			[Description("Fit to segments")]
			Fit_to_segments,

		}

		/// <summary>
		/// <para>Create circular arcs</para>
		/// </summary>
		public enum CircularArcsEnum 
		{
			/// <summary>
			/// <para>Checked—Circular arcs will be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE")]
			CREATE,

			/// <summary>
			/// <para>Unchecked—Circular arcs will not be created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_CREATE")]
			NOT_CREATE,

		}

		/// <summary>
		/// <para>Preserve endpoints for closed line</para>
		/// </summary>
		public enum ClosedEndsEnum 
		{
			/// <summary>
			/// <para>Checked—The endpoints of closed lines will be preserved. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE")]
			PRESERVE,

			/// <summary>
			/// <para>Unchecked—The endpoints of closed lines will not be preserved; they can be moved or deleted.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PRESERVE")]
			NOT_PRESERVE,

		}

#endregion
	}
}
