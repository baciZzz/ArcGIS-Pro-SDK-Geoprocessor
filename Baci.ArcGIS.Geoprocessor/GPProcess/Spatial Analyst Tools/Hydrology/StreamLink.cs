using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
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
		/// <param name="InStreamRaster">
		/// <para>Input stream raster</para>
		/// <para>An input raster that represents a linear stream network.</para>
		/// </param>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool, run using the default flow direction type D8.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output stream link raster.</para>
		/// <para>This output is of integer type.</para>
		/// </param>
		public StreamLink(object InStreamRaster, object InFlowDirectionRaster, object OutRaster)
		{
			this.InStreamRaster = InStreamRaster;
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutRaster = OutRaster;
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
		/// <para>Tool Excute Name : sa.StreamLink</para>
		/// </summary>
		public override string ExcuteName => "sa.StreamLink";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InStreamRaster, InFlowDirectionRaster, OutRaster };

		/// <summary>
		/// <para>Input stream raster</para>
		/// <para>An input raster that represents a linear stream network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InStreamRaster { get; set; }

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool, run using the default flow direction type D8.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output stream link raster.</para>
		/// <para>This output is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StreamLink SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
