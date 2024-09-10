using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Intersect 3D Lines</para>
	/// <para>Computes the intersecting and overlapping segments of lines in 3D space.</para>
	/// </summary>
	public class Intersect3DLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLines">
		/// <para>Input Features</para>
		/// <para>The line features that will be evaluated for intersections. The input can consist of either one or two line feature layers or classes. If one input is specified, each feature will be compared with all other features in that feature class. No feature will be compared to itself.</para>
		/// </param>
		public Intersect3DLines(object InLines)
		{
			this.InLines = InLines;
		}

		/// <summary>
		/// <para>Tool Display Name : Intersect 3D Lines</para>
		/// </summary>
		public override string DisplayName() => "Intersect 3D Lines";

		/// <summary>
		/// <para>Tool Name : Intersect3DLines</para>
		/// </summary>
		public override string ToolName() => "Intersect3DLines";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3DLines</para>
		/// </summary>
		public override string ExcuteName() => "3d.Intersect3DLines";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLines, MaxZDiff, JoinAttributes, OutPointFc, OutLineFc, OutIntersectionCount };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line features that will be evaluated for intersections. The input can consist of either one or two line feature layers or classes. If one input is specified, each feature will be compared with all other features in that feature class. No feature will be compared to itself.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InLines { get; set; }

		/// <summary>
		/// <para>Maximum Z Difference</para>
		/// <para>The maximum vertical distance between line segments that intersect.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxZDiff { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>Specifies which attributes from the input features will be transferred to the output feature class.</para>
		/// <para>All attributes—All the attributes from the input features will be transferred to the output feature class. This is the default.</para>
		/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output feature class.</para>
		/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output feature class.</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// <para>The output points representing the locations where the input lines intersect, including locations where overlapping line segments begin and end.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutPointFc { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// <para>The output lines representing the overlapping sections that exist between the input lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutLineFc { get; set; }

		/// <summary>
		/// <para>Output Intersection Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object OutIntersectionCount { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3DLines SetEnviroment(object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("All attributes except feature IDs")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only feature IDs")]
			Only_feature_IDs,

			/// <summary>
			/// <para>All attributes—All the attributes from the input features will be transferred to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All attributes")]
			All_attributes,

		}

#endregion
	}
}
