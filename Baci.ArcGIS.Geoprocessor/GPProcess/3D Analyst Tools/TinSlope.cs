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
	/// <para>TIN Slope</para>
	/// <para>Extracts slope information from the input TIN surface into polygon features.</para>
	/// </summary>
	[Obsolete()]
	public class TinSlope : AbstractGPProcess
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
		public TinSlope(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Slope</para>
		/// </summary>
		public override string DisplayName => "TIN Slope";

		/// <summary>
		/// <para>Tool Name : TinSlope</para>
		/// </summary>
		public override string ToolName => "TinSlope";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinSlope</para>
		/// </summary>
		public override string ExcuteName => "3d.TinSlope";

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
		public override object[] Parameters => new object[] { InTin, OutFeatureClass, Units, ClassBreaksTable, SlopeField, ZFactor };

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
		/// <para>Slope Units</para>
		/// <para>The units of measure for the slope values. Units are honored when a class breaks table is used.</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Units { get; set; } = "PERCENT";

		/// <summary>
		/// <para>Class Breaks Table</para>
		/// <para>An input table containing the classification breaks that will be used to classify the output feature class. A comma-delimited text file is required for a class breaks table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object ClassBreaksTable { get; set; }

		/// <summary>
		/// <para>Slope Field</para>
		/// <para>The field containing slope values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SlopeField { get; set; } = "SlopeCode";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor applied to the slope calculation to convert the TIN's z units to x and y units. By default, the z-factor is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinSlope SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slope Units</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("PERCENT")]
			PERCENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DEGREE")]
			[Description("DEGREE")]
			DEGREE,

		}

#endregion
	}
}
