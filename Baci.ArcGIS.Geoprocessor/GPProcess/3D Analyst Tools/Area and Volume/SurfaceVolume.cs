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
	/// <para>Surface Volume</para>
	/// <para>Calculates the area and volume of the region between a surface and a reference plane.</para>
	/// </summary>
	public class SurfaceVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The raster, TIN, or terrain surface to process.</para>
		/// </param>
		public SurfaceVolume(object InSurface)
		{
			this.InSurface = InSurface;
		}

		/// <summary>
		/// <para>Tool Display Name : Surface Volume</para>
		/// </summary>
		public override string DisplayName => "Surface Volume";

		/// <summary>
		/// <para>Tool Name : SurfaceVolume</para>
		/// </summary>
		public override string ToolName => "SurfaceVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceVolume</para>
		/// </summary>
		public override string ExcuteName => "3d.SurfaceVolume";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSurface, OutTextFile!, ReferencePlane!, BaseZ!, ZFactor!, PyramidLevelResolution! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The raster, TIN, or terrain surface to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Text File</para>
		/// <para>A comma-delimited ASCII text file containing the area and volume calculations. If the file already exists, the new results will be appended to the file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutTextFile { get; set; }

		/// <summary>
		/// <para>Reference Plane</para>
		/// <para>The direction from the reference plane for which to calculate the results.</para>
		/// <para>Above the Plane—Volume and area calculations will represent the region of space between the specified plane height and the portions of the surface that are above the plane. This is the default.</para>
		/// <para>Below the Plane—Volume and area calculations will represent the region of space between the specified plane height and portions of the surface that are below the plane.</para>
		/// <para><see cref="ReferencePlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReferencePlane { get; set; } = "ABOVE";

		/// <summary>
		/// <para>Plane Height</para>
		/// <para>The Z value of the plane that will be used to calculate area and volume.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BaseZ { get; set; }

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
		public SurfaceVolume SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reference Plane</para>
		/// </summary>
		public enum ReferencePlaneEnum 
		{
			/// <summary>
			/// <para>Above the Plane—Volume and area calculations will represent the region of space between the specified plane height and the portions of the surface that are above the plane. This is the default.</para>
			/// </summary>
			[GPValue("ABOVE")]
			[Description("Above the Plane")]
			Above_the_Plane,

			/// <summary>
			/// <para>Below the Plane—Volume and area calculations will represent the region of space between the specified plane height and portions of the surface that are below the plane.</para>
			/// </summary>
			[GPValue("BELOW")]
			[Description("Below the Plane")]
			Below_the_Plane,

		}

#endregion
	}
}
