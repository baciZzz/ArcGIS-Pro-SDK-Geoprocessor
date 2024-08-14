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
	/// <para>TIN Aspect</para>
	/// <para>Extracts the directional orientation  of input TIN to an output polygon feature class.</para>
	/// </summary>
	[Obsolete()]
	public class TinAspect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The input TIN.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		public TinAspect(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Aspect</para>
		/// </summary>
		public override string DisplayName => "TIN Aspect";

		/// <summary>
		/// <para>Tool Name : TinAspect</para>
		/// </summary>
		public override string ToolName => "TinAspect";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinAspect</para>
		/// </summary>
		public override string ExcuteName => "3d.TinAspect";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTin, OutFeatureClass, ClassBreaksTable, AspectField };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The input TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Class Breaks Table</para>
		/// <para>An input table containing the classification breaks that will be used to classify the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object ClassBreaksTable { get; set; }

		/// <summary>
		/// <para>Aspect Field</para>
		/// <para>The field containing aspect values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object AspectField { get; set; } = "AspectCode";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinAspect SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
