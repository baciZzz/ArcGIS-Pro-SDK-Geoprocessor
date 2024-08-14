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
	/// <para>Copy TIN</para>
	/// <para>Creates a copy of a triangulated irregular network (TIN) dataset.</para>
	/// </summary>
	public class CopyTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN that will be copied.</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </param>
		public CopyTin(object InTin, object OutTin)
		{
			this.InTin = InTin;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy TIN</para>
		/// </summary>
		public override string DisplayName => "Copy TIN";

		/// <summary>
		/// <para>Tool Name : CopyTin</para>
		/// </summary>
		public override string ToolName => "CopyTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CopyTin</para>
		/// </summary>
		public override string ExcuteName => "3d.CopyTin";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTin, OutTin, Version };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN that will be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Version</para>
		/// <para>The version of the output TIN.</para>
		/// <para>Current—The current TIN version, which supports constrained Delaunay triangulation, enhanced spatial reference information, and storage of node source and edge tag values. The resulting TIN will not be backward compatible with versions of ArcGIS prior to 10.0. This is the default.</para>
		/// <para>Pre 10.0—The TIN will be backward compatible with versions of ArcGIS prior to 10.0, which only supports conforming Delaunay triangulation.</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyTin SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object tinSaveVersion = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>Pre 10.0—The TIN will be backward compatible with versions of ArcGIS prior to 10.0, which only supports conforming Delaunay triangulation.</para>
			/// </summary>
			[GPValue("PRE_10.0")]
			[Description("Pre 10.0")]
			Pre_100,

			/// <summary>
			/// <para>Current—The current TIN version, which supports constrained Delaunay triangulation, enhanced spatial reference information, and storage of node source and edge tag values. The resulting TIN will not be backward compatible with versions of ArcGIS prior to 10.0. This is the default.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current")]
			Current,

		}

#endregion
	}
}
