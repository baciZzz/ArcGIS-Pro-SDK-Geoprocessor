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
	/// <para>Porous Puff</para>
	/// <para>Calculates the time-dependent, two-dimensional concentration distribution in mass per volume of a solute introduced instantaneously and at a discrete point into a vertically mixed aquifer.</para>
	/// </summary>
	public class PorousPuff : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTrackFile">
		/// <para>Input particle track file</para>
		/// <para>The input particle track path file.</para>
		/// <para>This is an ASCII text file containing information about the position, the local velocity vector, and the cumulative length and time of travel along the path.</para>
		/// <para>This file is generated using the Particle Track tool.</para>
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
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster of the concentration distribution.</para>
		/// <para>Each cell value represents the concentration at that location.</para>
		/// </param>
		/// <param name="Mass">
		/// <para>Mass</para>
		/// <para>A value for the amount of mass released instantaneously at the source point, in units of mass.</para>
		/// </param>
		public PorousPuff(object InTrackFile, object InPorosityRaster, object InThicknessRaster, object OutRaster, object Mass)
		{
			this.InTrackFile = InTrackFile;
			this.InPorosityRaster = InPorosityRaster;
			this.InThicknessRaster = InThicknessRaster;
			this.OutRaster = OutRaster;
			this.Mass = Mass;
		}

		/// <summary>
		/// <para>Tool Display Name : Porous Puff</para>
		/// </summary>
		public override string DisplayName() => "Porous Puff";

		/// <summary>
		/// <para>Tool Name : PorousPuff</para>
		/// </summary>
		public override string ToolName() => "PorousPuff";

		/// <summary>
		/// <para>Tool Excute Name : sa.PorousPuff</para>
		/// </summary>
		public override string ExcuteName() => "sa.PorousPuff";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTrackFile, InPorosityRaster, InThicknessRaster, OutRaster, Mass, DispersionTime, LongitudinalDispersivity, DispersivityRatio, RetardationFactor, DecayCoefficient };

		/// <summary>
		/// <para>Input particle track file</para>
		/// <para>The input particle track path file.</para>
		/// <para>This is an ASCII text file containing information about the position, the local velocity vector, and the cumulative length and time of travel along the path.</para>
		/// <para>This file is generated using the Particle Track tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InTrackFile { get; set; }

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
		/// <para>Output raster</para>
		/// <para>The output raster of the concentration distribution.</para>
		/// <para>Each cell value represents the concentration at that location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Mass</para>
		/// <para>A value for the amount of mass released instantaneously at the source point, in units of mass.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Mass { get; set; }

		/// <summary>
		/// <para>Dispersion time</para>
		/// <para>A value representing the time horizon for dispersion of the solute, in units of time.</para>
		/// <para>The time must be less than or equal to the maximum time in the track file. If the requested time exceeds the available time from the track file, the tool is aborted. The default time is the latest time (corresponding to the terminal point) in the track file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object DispersionTime { get; set; }

		/// <summary>
		/// <para>Longitudinal dispersivity</para>
		/// <para>A value representing the dispersivity parallel to the flow direction.</para>
		/// <para>For details on how the default value is determined, and how it relates to the scale of the study, see the How Porous Puff works section in the documentation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object LongitudinalDispersivity { get; set; }

		/// <summary>
		/// <para>Dispersivity ratio</para>
		/// <para>A value representing the ratio of longitudinal dispersivity over transverse dispersivity.</para>
		/// <para>Transverse dispersivity is perpendicular to the flow direction in the same horizontal plane. The default value is three.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object DispersivityRatio { get; set; } = "3";

		/// <summary>
		/// <para>Retardation factor</para>
		/// <para>A dimensionless value representing the retardation of the solute in the aquifer.</para>
		/// <para>Retardation varies between one and infinity, with one corresponding to no retardation. The default value is one.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object RetardationFactor { get; set; } = "1";

		/// <summary>
		/// <para>Decay coefficient</para>
		/// <para>Decay coefficient for solutes undergoing first-order exponential decay (for example, radionuclides) in units of inverse time.</para>
		/// <para>The default is zero, corresponding to no decay.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object DecayCoefficient { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PorousPuff SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
