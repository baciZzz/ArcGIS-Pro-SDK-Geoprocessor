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
	/// <para>Darcy Flow</para>
	/// <para>Calculates the groundwater volume balance residual and other outputs for steady flow in an aquifer.</para>
	/// </summary>
	public class DarcyFlow : AbstractGPProcess
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
		/// <param name="OutVolumeRaster">
		/// <para>Output groundwater volume balance residual raster</para>
		/// <para>The output volume balance residual raster.</para>
		/// <para>Each cell value represents the groundwater volume balance residual for steady flow in an aquifer, as determined by Darcy&apos;s Law.</para>
		/// </param>
		public DarcyFlow(object InHeadRaster, object InPorosityRaster, object InThicknessRaster, object InTransmissivityRaster, object OutVolumeRaster)
		{
			this.InHeadRaster = InHeadRaster;
			this.InPorosityRaster = InPorosityRaster;
			this.InThicknessRaster = InThicknessRaster;
			this.InTransmissivityRaster = InTransmissivityRaster;
			this.OutVolumeRaster = OutVolumeRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Darcy Flow</para>
		/// </summary>
		public override string DisplayName => "Darcy Flow";

		/// <summary>
		/// <para>Tool Name : DarcyFlow</para>
		/// </summary>
		public override string ToolName => "DarcyFlow";

		/// <summary>
		/// <para>Tool Excute Name : sa.DarcyFlow</para>
		/// </summary>
		public override string ExcuteName => "sa.DarcyFlow";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InHeadRaster, InPorosityRaster, InThicknessRaster, InTransmissivityRaster, OutVolumeRaster, OutDirectionRaster, OutMagnitudeRaster };

		/// <summary>
		/// <para>Input groundwater head elevation raster</para>
		/// <para>The input raster where each cell value represents the groundwater head elevation at that location.</para>
		/// <para>The head is typically an elevation above some datum, such as mean sea level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InHeadRaster { get; set; }

		/// <summary>
		/// <para>Input effective formation porosity raster</para>
		/// <para>The input raster where each cell value represents the effective formation porosity at that location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InPorosityRaster { get; set; }

		/// <summary>
		/// <para>Input saturated thickness raster</para>
		/// <para>The input raster where each cell value represents the saturated thickness at that location.</para>
		/// <para>The value for the thickness is interpreted from geological properties of the aquifer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InThicknessRaster { get; set; }

		/// <summary>
		/// <para>Input formation transmissivity raster</para>
		/// <para>The input raster where each cell value represents the formation transmissivity at that location.</para>
		/// <para>The transmissivity of an aquifer is defined as the hydraulic conductivity K times the saturated aquifer thickness b, as units of length squared over time. This property is generally estimated from field experimental data such as pumping tests. Tables 1 and 2 in How Darcy Flow and Darcy Velocity work list ranges of hydraulic conductivities for some generalized geologic materials.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InTransmissivityRaster { get; set; }

		/// <summary>
		/// <para>Output groundwater volume balance residual raster</para>
		/// <para>The output volume balance residual raster.</para>
		/// <para>Each cell value represents the groundwater volume balance residual for steady flow in an aquifer, as determined by Darcy&apos;s Law.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutVolumeRaster { get; set; }

		/// <summary>
		/// <para>Output direction raster</para>
		/// <para>The output flow direction raster.</para>
		/// <para>Each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell, calculated as the average value of the seepage velocity through the four faces of the cell.</para>
		/// <para>It is used with the output magnitude raster to describe the flow vector.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output magnitude raster</para>
		/// <para>An optional output raster where each cell value represents the magnitude of the seepage velocity vector (average linear velocity) at the center of the cell, calculated as the average value of the seepage velocity through the four faces of the cell.</para>
		/// <para>It is used with the output direction raster to describe the flow vector.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutMagnitudeRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DarcyFlow SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
