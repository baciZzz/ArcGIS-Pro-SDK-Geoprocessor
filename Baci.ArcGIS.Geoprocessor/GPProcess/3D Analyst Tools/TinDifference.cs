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
	/// <para>TIN Difference</para>
	/// <para>TIN Difference</para>
	/// <para>Calculates the volumetric difference between two TIN datasets.</para>
	/// </summary>
	[Obsolete()]
	public class TinDifference : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin1">
		/// <para>Input TIN</para>
		/// <para>The first input TIN.</para>
		/// </param>
		/// <param name="InTin2">
		/// <para>Input TIN</para>
		/// <para>The second input TIN.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </param>
		public TinDifference(object InTin1, object InTin2, object OutFeatureClass)
		{
			this.InTin1 = InTin1;
			this.InTin2 = InTin2;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Difference</para>
		/// </summary>
		public override string DisplayName() => "TIN Difference";

		/// <summary>
		/// <para>Tool Name : TinDifference</para>
		/// </summary>
		public override string ToolName() => "TinDifference";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinDifference</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinDifference";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin1, InTin2, OutFeatureClass };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The first input TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin1 { get; set; }

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The second input TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin2 { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinDifference SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
