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
	/// <para>Particle Track</para>
	/// <para>Particle Track</para>
	/// <para>Calculates the path of a particle through a velocity field, returning an ASCII file of particle tracking data and, optionally, a feature class of track information.</para>
	/// </summary>
	public class ParticleTrack : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDirectionRaster">
		/// <para>Input direction raster</para>
		/// <para>An input raster where each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell.</para>
		/// <para>Directions are expressed in compass coordinates, in degrees clockwise from north. This can be created by the Darcy Flow tool.</para>
		/// <para>Direction values must be floating point.</para>
		/// </param>
		/// <param name="InMagnitudeRaster">
		/// <para>Input magnitude raster</para>
		/// <para>An input raster where each cell value represents the magnitude of the seepage velocity vector (average linear velocity) at the center of the cell.</para>
		/// <para>Units are length/time. This can be created by the Darcy Flow tool.</para>
		/// </param>
		/// <param name="SourcePoint">
		/// <para>Source point</para>
		/// <para>The location of the source point from which to begin the particle tracking.</para>
		/// <para>This is entered as numbers identifying the x,y coordinates of the position in map units.</para>
		/// </param>
		/// <param name="OutTrackFile">
		/// <para>Output particle track file</para>
		/// <para>The output ASCII text file that contains the particle tracking data.</para>
		/// </param>
		public ParticleTrack(object InDirectionRaster, object InMagnitudeRaster, object SourcePoint, object OutTrackFile)
		{
			this.InDirectionRaster = InDirectionRaster;
			this.InMagnitudeRaster = InMagnitudeRaster;
			this.SourcePoint = SourcePoint;
			this.OutTrackFile = OutTrackFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Particle Track</para>
		/// </summary>
		public override string DisplayName() => "Particle Track";

		/// <summary>
		/// <para>Tool Name : ParticleTrack</para>
		/// </summary>
		public override string ToolName() => "ParticleTrack";

		/// <summary>
		/// <para>Tool Excute Name : sa.ParticleTrack</para>
		/// </summary>
		public override string ExcuteName() => "sa.ParticleTrack";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDirectionRaster, InMagnitudeRaster, SourcePoint, OutTrackFile, StepLength!, TrackingTime!, OutTrackPolylineFeatures! };

		/// <summary>
		/// <para>Input direction raster</para>
		/// <para>An input raster where each cell value represents the direction of the seepage velocity vector (average linear velocity) at the center of the cell.</para>
		/// <para>Directions are expressed in compass coordinates, in degrees clockwise from north. This can be created by the Darcy Flow tool.</para>
		/// <para>Direction values must be floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDirectionRaster { get; set; }

		/// <summary>
		/// <para>Input magnitude raster</para>
		/// <para>An input raster where each cell value represents the magnitude of the seepage velocity vector (average linear velocity) at the center of the cell.</para>
		/// <para>Units are length/time. This can be created by the Darcy Flow tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InMagnitudeRaster { get; set; }

		/// <summary>
		/// <para>Source point</para>
		/// <para>The location of the source point from which to begin the particle tracking.</para>
		/// <para>This is entered as numbers identifying the x,y coordinates of the position in map units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object SourcePoint { get; set; }

		/// <summary>
		/// <para>Output particle track file</para>
		/// <para>The output ASCII text file that contains the particle tracking data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutTrackFile { get; set; }

		/// <summary>
		/// <para>Step length</para>
		/// <para>The step length to be used for calculating the particle track.</para>
		/// <para>The default is one-half the cell size. Units are length.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? StepLength { get; set; }

		/// <summary>
		/// <para>Tracking time</para>
		/// <para>Maximum elapsed time for particle tracking.</para>
		/// <para>The algorithm will follow the track until either this time is met or the particle migrates off the raster or into a depression.</para>
		/// <para>The default value is infinity. Units are time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? TrackingTime { get; set; }

		/// <summary>
		/// <para>Output track polyline features</para>
		/// <para>The optional output line feature class containing the particle track.</para>
		/// <para>This feature class contains a series of arcs with attributes for position, local velocity direction and magnitude, and cumulative length and time of travel along the path.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutTrackPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ParticleTrack SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
