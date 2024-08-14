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
	/// <para>Darcy Velocity</para>
	/// <para>Calculates the groundwater seepage velocity vector (direction and magnitude) for steady flow in an aquifer.</para>
	/// </summary>
	public class DarcyVelocity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InHeadRaster">
		/// <para>Input groundwater head elevation raster</para>
		/// <para>The input raster where each cell value represents the groundwater head elevation at that location.</para>
		/// <para>The head is typically an elevation above some datum, such as mean sea level.</para>
		/// </param>
		/// <param name="InPorosityRaster">
		/// <para>Input effective formation porosity raster</para>
		/// <para>The input raster where each cell value represents the effective formation porosity at that location.</para>
		/// </param>
		/// <param name="InThicknessRaster">
		/// <para>Input saturated thickness raster</para>
		/// <para>The input raster where each cell value represents the saturated thickness at that location.</para>
		/// <para>The value for the thickness is interpreted from geological properties of the aquifer.</para>
		/// </param>
		/// <param name="InTransmissivityRaster">
		/// <para>Input formation transmissivity raster</para>
		/// <para>The input raster where each cell value represents the formation transmissivity at that location.</para>
		/// <para>The transmissivity of an aquifer is defined as the hydraulic conductivity K times the saturated aquifer thickness b, as units of length squared over time. This property is generally estimated from field experimental data such as pumping tests. Tables 1 and 2 in How Darcy Flow and Darcy Velocity work list ranges of hydraulic conductivities for some generalized geologic materials.</para>
		/// </param>
		/// <param name="OutDirectionRaster">
		/// <para>Output direction raster</para>
		/// <para>The output flow direction raster.</para>
		/// <para>Each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell, calculated as the average value of the seepage velocity through the four faces of the cell.</para>
		/// <para>It is used with the output magnitude raster to describe the flow vector.</para>
		/// </param>
		/// <param name="OutMagnitudeRaster">
		/// <para>Output magnitude raster</para>
		/// <para>The output flow direction raster.</para>
		/// <para>Each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell, calculated as the average value of the seepage velocity through the four faces of the cell.</para>
		/// <para>It is used with the output magnitude raster to describe the flow vector.</para>
		/// </param>
		public DarcyVelocity(object InHeadRaster, object InPorosityRaster, object InThicknessRaster, object InTransmissivityRaster, object OutDirectionRaster, object OutMagnitudeRaster)
		{
			this.InHeadRaster = InHeadRaster;
			this.InPorosityRaster = InPorosityRaster;
			this.InThicknessRaster = InThicknessRaster;
			this.InTransmissivityRaster = InTransmissivityRaster;
			this.OutDirectionRaster = OutDirectionRaster;
			this.OutMagnitudeRaster = OutMagnitudeRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Darcy Velocity</para>
		/// </summary>
		public override string DisplayName => "Darcy Velocity";

		/// <summary>
		/// <para>Tool Name : DarcyVelocity</para>
		/// </summary>
		public override string ToolName => "DarcyVelocity";

		/// <summary>
		/// <para>Tool Excute Name : sa.DarcyVelocity</para>
		/// </summary>
		public override string ExcuteName => "sa.DarcyVelocity";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InHeadRaster, InPorosityRaster, InThicknessRaster, InTransmissivityRaster, OutDirectionRaster, OutMagnitudeRaster };

		/// <summary>
		/// <para>Input groundwater head elevation raster</para>
		/// <para>The input raster where each cell value represents the groundwater head elevation at that location.</para>
		/// <para>The head is typically an elevation above some datum, such as mean sea level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InHeadRaster { get; set; }

		/// <summary>
		/// <para>Input effective formation porosity raster</para>
		/// <para>The input raster where each cell value represents the effective formation porosity at that location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InPorosityRaster { get; set; }

		/// <summary>
		/// <para>Input saturated thickness raster</para>
		/// <para>The input raster where each cell value represents the saturated thickness at that location.</para>
		/// <para>The value for the thickness is interpreted from geological properties of the aquifer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InThicknessRaster { get; set; }

		/// <summary>
		/// <para>Input formation transmissivity raster</para>
		/// <para>The input raster where each cell value represents the formation transmissivity at that location.</para>
		/// <para>The transmissivity of an aquifer is defined as the hydraulic conductivity K times the saturated aquifer thickness b, as units of length squared over time. This property is generally estimated from field experimental data such as pumping tests. Tables 1 and 2 in How Darcy Flow and Darcy Velocity work list ranges of hydraulic conductivities for some generalized geologic materials.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InTransmissivityRaster { get; set; }

		/// <summary>
		/// <para>Output direction raster</para>
		/// <para>The output flow direction raster.</para>
		/// <para>Each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell, calculated as the average value of the seepage velocity through the four faces of the cell.</para>
		/// <para>It is used with the output magnitude raster to describe the flow vector.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output magnitude raster</para>
		/// <para>The output flow direction raster.</para>
		/// <para>Each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell, calculated as the average value of the seepage velocity through the four faces of the cell.</para>
		/// <para>It is used with the output magnitude raster to describe the flow vector.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMagnitudeRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DarcyVelocity SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
