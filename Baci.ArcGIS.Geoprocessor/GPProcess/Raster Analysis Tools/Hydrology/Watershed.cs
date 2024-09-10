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
	/// <para>Watershed</para>
	/// <para>Determines the contributing area above a set of cells in a raster.</para>
	/// </summary>
	public class Watershed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputflowdirectionraster">
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// </param>
		/// <param name="Inpourpointrasterorfeatures">
		/// <para>Input Pour Point Raster or Features</para>
		/// <para>The input pour point locations.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output watershed raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public Watershed(object Inputflowdirectionraster, object Inpourpointrasterorfeatures, object Outputname)
		{
			this.Inputflowdirectionraster = Inputflowdirectionraster;
			this.Inpourpointrasterorfeatures = Inpourpointrasterorfeatures;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Watershed</para>
		/// </summary>
		public override string DisplayName() => "Watershed";

		/// <summary>
		/// <para>Tool Name : Watershed</para>
		/// </summary>
		public override string ToolName() => "Watershed";

		/// <summary>
		/// <para>Tool Excute Name : ra.Watershed</para>
		/// </summary>
		public override string ExcuteName() => "ra.Watershed";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputflowdirectionraster, Inpourpointrasterorfeatures, Outputname, Pourpointfield, Outputraster };

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Input Pour Point Raster or Features</para>
		/// <para>The input pour point locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inpourpointrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output watershed raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Pour Point Field</para>
		/// <para>Field used to assign values to the pour point locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Pourpointfield { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Watershed SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

	}
}
