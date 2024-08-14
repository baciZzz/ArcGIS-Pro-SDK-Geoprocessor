using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Stream Link</para>
	/// <para>Assigns unique values to sections of a raster linear network between intersections.</para>
	/// </summary>
	public class StreamLink : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputstreamraster">
		/// <para>Input Stream Raster</para>
		/// <para>An input raster that represents a linear stream network.</para>
		/// </param>
		/// <param name="Inputflowdirectionraster">
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output stream link raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public StreamLink(object Inputstreamraster, object Inputflowdirectionraster, object Outputname)
		{
			this.Inputstreamraster = Inputstreamraster;
			this.Inputflowdirectionraster = Inputflowdirectionraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Stream Link</para>
		/// </summary>
		public override string DisplayName => "Stream Link";

		/// <summary>
		/// <para>Tool Name : StreamLink</para>
		/// </summary>
		public override string ToolName => "StreamLink";

		/// <summary>
		/// <para>Tool Excute Name : ra.StreamLink</para>
		/// </summary>
		public override string ExcuteName => "ra.StreamLink";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputstreamraster, Inputflowdirectionraster, Outputname, Outputraster! };

		/// <summary>
		/// <para>Input Stream Raster</para>
		/// <para>An input raster that represents a linear stream network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputstreamraster { get; set; }

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output stream link raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StreamLink SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

	}
}
