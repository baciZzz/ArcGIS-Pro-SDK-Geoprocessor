using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Repair Self Intersection</para>
	/// <para>Repairs self-intersecting line or polygon features. The portion between the feature and the intersection points are either deleted or split into a new feature.</para>
	/// </summary>
	public class RepairSelfIntersection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polyline or polygon feature class from which this tool will repair self-intersections.</para>
		/// </param>
		/// <param name="RepairType">
		/// <para>Repair Type</para>
		/// <para>Indicates whether the tool will delete or split self-intersections.</para>
		/// <para>Delete—Self-intersections will be deleted. This is the default.</para>
		/// <para>Split—Self-intersections will be split at the intersection point and retained.</para>
		/// <para><see cref="RepairTypeEnum"/></para>
		/// </param>
		public RepairSelfIntersection(object InFeatures, object RepairType)
		{
			this.InFeatures = InFeatures;
			this.RepairType = RepairType;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Self Intersection</para>
		/// </summary>
		public override string DisplayName => "Repair Self Intersection";

		/// <summary>
		/// <para>Tool Name : RepairSelfIntersection</para>
		/// </summary>
		public override string ToolName => "RepairSelfIntersection";

		/// <summary>
		/// <para>Tool Excute Name : topographic.RepairSelfIntersection</para>
		/// </summary>
		public override string ExcuteName => "topographic.RepairSelfIntersection";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, RepairType, MaxLength, RepairAtEndPoint, ModifiedInFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polyline or polygon feature class from which this tool will repair self-intersections.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Repair Type</para>
		/// <para>Indicates whether the tool will delete or split self-intersections.</para>
		/// <para>Delete—Self-intersections will be deleted. This is the default.</para>
		/// <para>Split—Self-intersections will be split at the intersection point and retained.</para>
		/// <para><see cref="RepairTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RepairType { get; set; } = "DELETE";

		/// <summary>
		/// <para>Maximum Removal Length</para>
		/// <para>The maximum length of the segment between the points of self-intersection. Only segments shorter than the specified maximum length are deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxLength { get; set; }

		/// <summary>
		/// <para>Remove Self Intersections at End Point</para>
		/// <para>Indicates whether this tool will remove, or avoid removing, any self-intersections whose end point is snapped on itself.</para>
		/// <para>Checked—Self-intersections will be removed.</para>
		/// <para>Unchecked—Any feature that has an end point that snaps to itself will not be removed. An example is a cul-de-sac. This is the default.</para>
		/// <para><see cref="RepairAtEndPointEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RepairAtEndPoint { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object ModifiedInFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Repair Type</para>
		/// </summary>
		public enum RepairTypeEnum 
		{
			/// <summary>
			/// <para>Delete—Self-intersections will be deleted. This is the default.</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("Delete")]
			Delete,

			/// <summary>
			/// <para>Split—Self-intersections will be split at the intersection point and retained.</para>
			/// </summary>
			[GPValue("SPLIT")]
			[Description("Split")]
			Split,

		}

		/// <summary>
		/// <para>Remove Self Intersections at End Point</para>
		/// </summary>
		public enum RepairAtEndPointEnum 
		{
			/// <summary>
			/// <para>Checked—Self-intersections will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REPAIR_ENDS")]
			REPAIR_ENDS,

			/// <summary>
			/// <para>Unchecked—Any feature that has an end point that snaps to itself will not be removed. An example is a cul-de-sac. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_ENDS")]
			IGNORE_ENDS,

		}

#endregion
	}
}
