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
	/// <para>TIN Edge</para>
	/// <para>TIN Edge</para>
	/// <para>Creates 3D line features using the triangle edges of a triangulated irregular network (TIN) dataset.</para>
	/// </summary>
	public class TinEdge : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public TinEdge(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Edge</para>
		/// </summary>
		public override string DisplayName() => "TIN Edge";

		/// <summary>
		/// <para>Tool Name : TinEdge</para>
		/// </summary>
		public override string ToolName() => "TinEdge";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinEdge</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinEdge";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutFeatureClass, EdgeType };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Edge Type</para>
		/// <para>The triangle edge that will be exported.</para>
		/// <para>Data Area—Edges representing the interpolation zone. This is the default.</para>
		/// <para>Soft Breaklines—Edges representing gradual breaks in slope.</para>
		/// <para>Hard Breaklines—Edges representing distinct breaks in slope.</para>
		/// <para>Enforced Edges—Edges that were not introduced by the TIN&apos;s triangulation.</para>
		/// <para>Regular Edges—Edges that were created by the TIN&apos;s triangulation.</para>
		/// <para>Excluded Edges—Edges that are excluded from the interpolation zone.</para>
		/// <para>All Edges—All edges, included those that were excluded from the interpolation zone.</para>
		/// <para><see cref="EdgeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeType { get; set; } = "DATA";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinEdge SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Edge Type</para>
		/// </summary>
		public enum EdgeTypeEnum 
		{
			/// <summary>
			/// <para>Data Area—Edges representing the interpolation zone. This is the default.</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("Data Area")]
			Data_Area,

			/// <summary>
			/// <para>Soft Breaklines—Edges representing gradual breaks in slope.</para>
			/// </summary>
			[GPValue("SOFT")]
			[Description("Soft Breaklines")]
			Soft_Breaklines,

			/// <summary>
			/// <para>Hard Breaklines—Edges representing distinct breaks in slope.</para>
			/// </summary>
			[GPValue("HARD")]
			[Description("Hard Breaklines")]
			Hard_Breaklines,

			/// <summary>
			/// <para>Enforced Edges—Edges that were not introduced by the TIN&apos;s triangulation.</para>
			/// </summary>
			[GPValue("ENFORCED")]
			[Description("Enforced Edges")]
			Enforced_Edges,

			/// <summary>
			/// <para>Regular Edges—Edges that were created by the TIN&apos;s triangulation.</para>
			/// </summary>
			[GPValue("REGULAR")]
			[Description("Regular Edges")]
			Regular_Edges,

			/// <summary>
			/// <para>Excluded Edges—Edges that are excluded from the interpolation zone.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Excluded Edges")]
			Excluded_Edges,

			/// <summary>
			/// <para>All Edges—All edges, included those that were excluded from the interpolation zone.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All Edges")]
			All_Edges,

		}

#endregion
	}
}
