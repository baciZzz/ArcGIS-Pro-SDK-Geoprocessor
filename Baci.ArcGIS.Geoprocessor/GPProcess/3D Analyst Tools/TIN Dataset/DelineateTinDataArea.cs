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
	/// <para>Delineate TIN Data Area</para>
	/// <para>Delineate TIN Data Area</para>
	/// <para>Redefines the data area, or interpolation zone, of a triangulated irregular network (TIN) based on its triangle edge length.</para>
	/// </summary>
	public class DelineateTinDataArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </param>
		/// <param name="MaxEdgeLength">
		/// <para>Maximum Edge Length</para>
		/// <para>The two-dimensional distance that defines the maximum length of a TIN triangle edge in the TIN's data area. Triangles with one or more edges that exceed this value will be considered outside the TIN's interpolation zone and will not be rendered in maps or used in surface analysis.</para>
		/// </param>
		public DelineateTinDataArea(object InTin, object MaxEdgeLength)
		{
			this.InTin = InTin;
			this.MaxEdgeLength = MaxEdgeLength;
		}

		/// <summary>
		/// <para>Tool Display Name : Delineate TIN Data Area</para>
		/// </summary>
		public override string DisplayName() => "Delineate TIN Data Area";

		/// <summary>
		/// <para>Tool Name : DelineateTinDataArea</para>
		/// </summary>
		public override string ToolName() => "DelineateTinDataArea";

		/// <summary>
		/// <para>Tool Excute Name : 3d.DelineateTinDataArea</para>
		/// </summary>
		public override string ExcuteName() => "3d.DelineateTinDataArea";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, MaxEdgeLength, Method!, DerivedOutTin! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Maximum Edge Length</para>
		/// <para>The two-dimensional distance that defines the maximum length of a TIN triangle edge in the TIN's data area. Triangles with one or more edges that exceed this value will be considered outside the TIN's interpolation zone and will not be rendered in maps or used in surface analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MaxEdgeLength { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>The TIN edges that will be evaluated when delineating the TIN&apos;s data area.</para>
		/// <para>Perimeter Edges—Iterates through triangles from the TIN&apos;s outer extent inward and will stop when the current iteration of boundary triangle edges does not exceed the Maximum Edge Length. This is the default.</para>
		/// <para>All Edges—Classifies the entire collection of TIN triangles by edge length.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PERIMETER_ONLY";

		/// <summary>
		/// <para>Updated TIN</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTinLayer()]
		public object? DerivedOutTin { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DelineateTinDataArea SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Perimeter Edges—Iterates through triangles from the TIN&apos;s outer extent inward and will stop when the current iteration of boundary triangle edges does not exceed the Maximum Edge Length. This is the default.</para>
			/// </summary>
			[GPValue("PERIMETER_ONLY")]
			[Description("Perimeter Edges")]
			Perimeter_Edges,

			/// <summary>
			/// <para>All Edges—Classifies the entire collection of TIN triangles by edge length.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All Edges")]
			All_Edges,

		}

#endregion
	}
}
