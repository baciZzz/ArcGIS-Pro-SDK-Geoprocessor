using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.PublicTransitTools
{
	/// <summary>
	/// <para>Features To GTFS Shapes</para>
	/// <para>Features To GTFS Shapes</para>
	/// <para>Creates a  shapes.txt file for a GTFS public transit dataset based on route line representations created by the Generate Shapes Features From GTFS tool.</para>
	/// </summary>
	public class FeaturesToGTFSShapes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InShapeLines">
		/// <para>Input Shape Lines</para>
		/// <para>A line feature class representing the GTFS shapes created by running the Generate Shapes Features From GTFS tool. The feature class must contain a shape_id field with values corresponding to the shape_id field values in the other tool inputs.</para>
		/// </param>
		/// <param name="InShapeStops">
		/// <para>Input Shape Stops</para>
		/// <para>A point feature class representing the GTFS stops associated with each shape created by running the Generate Shapes Features From GTFS tool. If a transit stop is used by multiple shapes, the stop should be duplicated in this feature class for each shape that uses it.</para>
		/// <para>The feature class must contain a shape_id field with values corresponding to the shape_id field values in the other tool inputs. It must also contain a stop_id field with values corresponding to those in the shape_id column of the input GTFS stop_times.txt file.</para>
		/// </param>
		/// <param name="InGtfsTrips">
		/// <para>Input Updated GTFS Trips</para>
		/// <para>The updated GTFS trips.txt file created by running the Generate Shapes Features From GTFS tool. This file must have the shape_id column with values corresponding to those in the shape_id fields in the other tool inputs.</para>
		/// </param>
		/// <param name="InGtfsStopTimes">
		/// <para>Input GTFS Stop Times</para>
		/// <para>The original stop_times.txt file from the GTFS dataset that was used when running the Generate Shapes Features From GTFS tool.</para>
		/// </param>
		/// <param name="OutGtfsShapes">
		/// <para>Output GTFS Shapes</para>
		/// <para>The output GTFS shapes.txt file.</para>
		/// </param>
		/// <param name="OutGtfsStopTimes">
		/// <para>Output GTFS Stop Times</para>
		/// <para>The output GTFS stop_times.txt file This file will contain the shape_dist_traveled field with values derived from the new shapes.</para>
		/// </param>
		public FeaturesToGTFSShapes(object InShapeLines, object InShapeStops, object InGtfsTrips, object InGtfsStopTimes, object OutGtfsShapes, object OutGtfsStopTimes)
		{
			this.InShapeLines = InShapeLines;
			this.InShapeStops = InShapeStops;
			this.InGtfsTrips = InGtfsTrips;
			this.InGtfsStopTimes = InGtfsStopTimes;
			this.OutGtfsShapes = OutGtfsShapes;
			this.OutGtfsStopTimes = OutGtfsStopTimes;
		}

		/// <summary>
		/// <para>Tool Display Name : Features To GTFS Shapes</para>
		/// </summary>
		public override string DisplayName() => "Features To GTFS Shapes";

		/// <summary>
		/// <para>Tool Name : FeaturesToGTFSShapes</para>
		/// </summary>
		public override string ToolName() => "FeaturesToGTFSShapes";

		/// <summary>
		/// <para>Tool Excute Name : transit.FeaturesToGTFSShapes</para>
		/// </summary>
		public override string ExcuteName() => "transit.FeaturesToGTFSShapes";

		/// <summary>
		/// <para>Toolbox Display Name : Public Transit Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Public Transit Tools";

		/// <summary>
		/// <para>Toolbox Alise : transit</para>
		/// </summary>
		public override string ToolboxAlise() => "transit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InShapeLines, InShapeStops, InGtfsTrips, InGtfsStopTimes, OutGtfsShapes, OutGtfsStopTimes, DistanceUnits! };

		/// <summary>
		/// <para>Input Shape Lines</para>
		/// <para>A line feature class representing the GTFS shapes created by running the Generate Shapes Features From GTFS tool. The feature class must contain a shape_id field with values corresponding to the shape_id field values in the other tool inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InShapeLines { get; set; }

		/// <summary>
		/// <para>Input Shape Stops</para>
		/// <para>A point feature class representing the GTFS stops associated with each shape created by running the Generate Shapes Features From GTFS tool. If a transit stop is used by multiple shapes, the stop should be duplicated in this feature class for each shape that uses it.</para>
		/// <para>The feature class must contain a shape_id field with values corresponding to the shape_id field values in the other tool inputs. It must also contain a stop_id field with values corresponding to those in the shape_id column of the input GTFS stop_times.txt file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InShapeStops { get; set; }

		/// <summary>
		/// <para>Input Updated GTFS Trips</para>
		/// <para>The updated GTFS trips.txt file created by running the Generate Shapes Features From GTFS tool. This file must have the shape_id column with values corresponding to those in the shape_id fields in the other tool inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsTrips { get; set; }

		/// <summary>
		/// <para>Input GTFS Stop Times</para>
		/// <para>The original stop_times.txt file from the GTFS dataset that was used when running the Generate Shapes Features From GTFS tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsStopTimes { get; set; }

		/// <summary>
		/// <para>Output GTFS Shapes</para>
		/// <para>The output GTFS shapes.txt file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsShapes { get; set; }

		/// <summary>
		/// <para>Output GTFS Stop Times</para>
		/// <para>The output GTFS stop_times.txt file This file will contain the shape_dist_traveled field with values derived from the new shapes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsStopTimes { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the distance units to use when populating the shape_dist_traveled field in the output GTFS files.</para>
		/// <para>Miles—The unit is miles. This is the default.</para>
		/// <para>Meters—The unit is meters</para>
		/// <para>Kilometers—The unit is kilometers</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnits { get; set; } = "MILES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGTFSShapes SetEnviroment(object? randomGenerator = null )
		{
			base.SetEnv(randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Miles—The unit is miles. This is the default.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Meters—The unit is meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The unit is kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

		}

#endregion
	}
}
