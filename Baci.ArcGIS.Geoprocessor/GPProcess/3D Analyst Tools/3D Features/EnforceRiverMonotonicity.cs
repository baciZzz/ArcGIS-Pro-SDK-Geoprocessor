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
	/// <para>强制河流单调性</para>
	/// <para>从表示河岸的 3D 面创建已调整高度的隔断线。</para>
	/// </summary>
	public class EnforceRiverMonotonicity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRivers">
		/// <para>Input River Polygons</para>
		/// <para>描绘待处理河岸的 3D 面。</para>
		/// </param>
		/// <param name="InFlowDirection">
		/// <para>Input Flow Direction Lines</para>
		/// <para>表示河岸面流向的线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output River Boundary Lines</para>
		/// <para>输出河流边界线。</para>
		/// </param>
		public EnforceRiverMonotonicity(object InRivers, object InFlowDirection, object OutFeatureClass)
		{
			this.InRivers = InRivers;
			this.InFlowDirection = InFlowDirection;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 强制河流单调性</para>
		/// </summary>
		public override string DisplayName() => "强制河流单调性";

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
		/// <para>描绘待处理河岸的 3D 面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InRivers { get; set; }

		/// <summary>
		/// <para>Input Flow Direction Lines</para>
		/// <para>表示河岸面流向的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFlowDirection { get; set; }

		/// <summary>
		/// <para>Output River Boundary Lines</para>
		/// <para>输出河流边界线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Sampling Distance</para>
		/// <para>面边界的固定采样距离，将用于沿河岸建立单调性。</para>
		/// <para><see cref="MaxSampleDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? MaxSampleDistance { get; set; } = "15 Meters";

		/// <summary>
		/// <para>3D Simplification Tolerance</para>
		/// <para>用于简化生成的河流边界线的 z 范围。</para>
		/// <para><see cref="SimplificationToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? SimplificationTolerance { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnforceRiverMonotonicity SetEnviroment(object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
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
