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
	/// <para>Surface Slope</para>
	/// <para>Creates polygon features that represent ranges of slope values for triangulated surfaces.</para>
	/// </summary>
	public class SurfaceSlope : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The TIN, terrain, or LAS dataset whose slope measurements will be written to the output polygon feature.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public SurfaceSlope(object InSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Surface Slope</para>
		/// </summary>
		public override string DisplayName => "Surface Slope";

		/// <summary>
		/// <para>Tool Name : SurfaceSlope</para>
		/// </summary>
		public override string ToolName => "SurfaceSlope";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceSlope</para>
		/// </summary>
		public override string ExcuteName => "3d.SurfaceSlope";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSurface, OutFeatureClass, Units!, ClassBreaksTable!, SlopeField!, ZFactor!, PyramidLevelResolution! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The TIN, terrain, or LAS dataset whose slope measurements will be written to the output polygon feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Slope Units</para>
		/// <para>The units of measure to be used in calculating slope.</para>
		/// <para>Percent—Slope is expressed as a percentage value. This is the default.</para>
		/// <para>Degree—Slope is expressed as the angle of inclination from a horizontal plane.</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Units { get; set; } = "PERCENT";

		/// <summary>
		/// <para>Class Breaks Table</para>
		/// <para>A table containing classification breaks that will be used to group the output features. The first column of this table will indicate the break point, whereas the second will provide the classification code.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? ClassBreaksTable { get; set; }

		/// <summary>
		/// <para>Slope Field</para>
		/// <para>The field containing slope values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SlopeField { get; set; } = "SlopeCode";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceSlope SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , bool? terrainMemoryUsage = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slope Units</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>Percent—Slope is expressed as a percentage value. This is the default.</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("Percent")]
			Percent,

			/// <summary>
			/// <para>Degree—Slope is expressed as the angle of inclination from a horizontal plane.</para>
			/// </summary>
			[GPValue("DEGREE")]
			[Description("Degree")]
			Degree,

		}

#endregion
	}
}
