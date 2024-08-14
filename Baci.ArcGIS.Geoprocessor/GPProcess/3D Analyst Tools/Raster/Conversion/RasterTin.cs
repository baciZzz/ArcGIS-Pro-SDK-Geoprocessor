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
	/// <para>Raster To TIN</para>
	/// <para>Converts a raster to a triangulated  irregular network (TIN) dataset.</para>
	/// </summary>
	public class RasterTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster to process.</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </param>
		public RasterTin(object InRaster, object OutTin)
		{
			this.InRaster = InRaster;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster To TIN</para>
		/// </summary>
		public override string DisplayName => "Raster To TIN";

		/// <summary>
		/// <para>Tool Name : RasterTin</para>
		/// </summary>
		public override string ToolName => "RasterTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RasterTin</para>
		/// </summary>
		public override string ExcuteName => "3d.RasterTin";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutTin, ZTolerance!, MaxPoints!, ZFactor! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The maximum allowable difference in (z units) between the height of the input raster and the height of the output TIN. By default, the z tolerance is 1/10 of the z range of the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; }

		/// <summary>
		/// <para>Maximum Number of Points</para>
		/// <para>The maximum number of points that will be added to the TIN before the process is terminated. By default, the process will continue until all the points are added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxPoints { get; set; } = "1500000";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor that the height values of the raster will be multiplied by in the resulting TIN dataset. This is typically used to convert Z units to match XY units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterTin SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? tinSaveVersion = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

	}
}
