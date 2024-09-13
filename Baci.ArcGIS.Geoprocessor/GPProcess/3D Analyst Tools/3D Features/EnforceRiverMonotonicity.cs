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
	/// <para>Enforce River Monotonicity</para>
	/// <para>Enforce River Monotonicity</para>
	/// <para>Creates height adjusted breaklines from 3D polygons representing river banks.</para>
	/// </summary>
	public class EnforceRiverMonotonicity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRivers">
		/// <para>Input River Polygons</para>
		/// <para>The 3D polygons delineating the river banks that will be processed.</para>
		/// </param>
		/// <param name="InFlowDirection">
		/// <para>Input Flow Direction Lines</para>
		/// <para>The line features that indicate the flow direction of the river bank polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output River Boundary Lines</para>
		/// <para>The output river boundary lines.</para>
		/// </param>
		public EnforceRiverMonotonicity(object InRivers, object InFlowDirection, object OutFeatureClass)
		{
			this.InRivers = InRivers;
			this.InFlowDirection = InFlowDirection;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enforce River Monotonicity</para>
		/// </summary>
		public override string DisplayName() => "Enforce River Monotonicity";

		/// <summary>
		/// <para>Tool Name : EnforceRiverMonotonicity</para>
		/// </summary>
		public override string ToolName() => "EnforceRiverMonotonicity";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EnforceRiverMonotonicity</para>
		/// </summary>
		public override string ExcuteName() => "3d.EnforceRiverMonotonicity";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRivers, InFlowDirection, OutFeatureClass, MaxSampleDistance!, SimplificationTolerance! };

		/// <summary>
		/// <para>Input River Polygons</para>
		/// <para>The 3D polygons delineating the river banks that will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InRivers { get; set; }

		/// <summary>
		/// <para>Input Flow Direction Lines</para>
		/// <para>The line features that indicate the flow direction of the river bank polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFlowDirection { get; set; }

		/// <summary>
		/// <para>Output River Boundary Lines</para>
		/// <para>The output river boundary lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Sampling Distance</para>
		/// <para>The regular sampling distance of the polygon's boundary that will be used to establish monotonicity along the river banks.</para>
		/// <para><see cref="MaxSampleDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? MaxSampleDistance { get; set; } = "15 Meters";

		/// <summary>
		/// <para>3D Simplification Tolerance</para>
		/// <para>The z-range that will be used to simplify the resulting river boundary line.</para>
		/// <para><see cref="SimplificationToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? SimplificationTolerance { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnforceRiverMonotonicity SetEnviroment(object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Maximum Sampling Distance</para>
		/// </summary>
		public enum MaxSampleDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Unknown")]
			[Description("Unknown")]
			Unknown,

		}

		/// <summary>
		/// <para>3D Simplification Tolerance</para>
		/// </summary>
		public enum SimplificationToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Unknown")]
			[Description("Unknown")]
			Unknown,

		}

#endregion
	}
}
