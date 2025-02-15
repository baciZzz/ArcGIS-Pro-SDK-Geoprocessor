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
	/// <para>Stack Profile</para>
	/// <para>Stack Profile</para>
	/// <para>Creates a table and optional graph denoting the  profile of line features over one or more multipatch, raster, TIN, or terrain surfaces.</para>
	/// </summary>
	public class StackProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line features that will be profiled over the surface inputs.</para>
		/// </param>
		/// <param name="ProfileTargets">
		/// <para>Profile Targets</para>
		/// <para>The data being profiled, which can be comprised from any combination of multipatch features, raster, and triangulated surface models.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table that will store the height interpolated for each profile target that intersects the input line.</para>
		/// </param>
		public StackProfile(object InLineFeatures, object ProfileTargets, object OutTable)
		{
			this.InLineFeatures = InLineFeatures;
			this.ProfileTargets = ProfileTargets;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Stack Profile</para>
		/// </summary>
		public override string DisplayName() => "Stack Profile";

		/// <summary>
		/// <para>Tool Name : StackProfile</para>
		/// </summary>
		public override string ToolName() => "StackProfile";

		/// <summary>
		/// <para>Tool Excute Name : 3d.StackProfile</para>
		/// </summary>
		public override string ExcuteName() => "3d.StackProfile";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, ProfileTargets, OutTable, OutGraph! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features that will be profiled over the surface inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Profile Targets</para>
		/// <para>The data being profiled, which can be comprised from any combination of multipatch features, raster, and triangulated surface models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object ProfileTargets { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table that will store the height interpolated for each profile target that intersects the input line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Graph Name</para>
		/// <para>The output graph is not supported in Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGraph()]
		public object? OutGraph { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StackProfile SetEnviroment(object? extent = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
