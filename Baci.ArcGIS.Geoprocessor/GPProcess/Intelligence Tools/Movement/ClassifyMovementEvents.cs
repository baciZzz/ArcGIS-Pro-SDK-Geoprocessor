using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Classify Movement Events</para>
	/// <para>Identifies turn events, acceleration events, and speed from an input point track dataset.</para>
	/// </summary>
	public class ClassifyMovementEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>A time-enabled point feature layer with a field annotating the track with which each point is associated. The geometry, object identifier, track name, and time will be transferred to the output feature class. The input must be in a projected coordinate system.</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>A field from the input features that will be used to obtain the unique identifiers per point track. The field will be copied to the output feature class.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the calculated movement events.</para>
		/// </param>
		public ClassifyMovementEvents(object InFeatures, object IdField, object OutFeatureclass)
		{
			this.InFeatures = InFeatures;
			this.IdField = IdField;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Movement Events</para>
		/// </summary>
		public override string DisplayName => "Classify Movement Events";

		/// <summary>
		/// <para>Tool Name : ClassifyMovementEvents</para>
		/// </summary>
		public override string ToolName => "ClassifyMovementEvents";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.ClassifyMovementEvents</para>
		/// </summary>
		public override string ExcuteName => "intelligence.ClassifyMovementEvents";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, IdField, OutFeatureclass, Curvature, NumberOfPoints, RegionsOfInterest, RoiIdField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A time-enabled point feature layer with a field annotating the track with which each point is associated. The geometry, object identifier, track name, and time will be transferred to the output feature class. The input must be in a projected coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>A field from the input features that will be used to obtain the unique identifiers per point track. The field will be copied to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the calculated movement events.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Curvature</para>
		/// <para>The minimum value that is necessary for an event to be classified as a turn event. After the curvature is calculated, any calculated curvature greater than this value will cause the turn_event field to be populated with the relevant turn event, while values less than this will cause the turn_event field to be classified as Traveling.</para>
		/// <para>Turns are calculated using the Curvature and Number Of Points parameters. Each point is evaluated based on the bearing from the previous point in the track to the current point and from the current point to the next point in the track. If the value exceeds the value specified in the Curvature parameter, it is considered a turn. Otherwise, it is considered to be traveling. For tracks representing large objects, it is recommended that you increase the Number Of Points value to account for the longer amount of time to conduct a turn.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Curvature { get; set; } = "15";

		/// <summary>
		/// <para>Number Of Points</para>
		/// <para>The number of points that will be evaluated before and after a given point when calculating the bearing difference. When using data with a high sampling rate (subsecond), you may need to increase the Number Of Points parameter value to account for the decreased movement that is possible in that brief time period. A value of 1 is suitable for automobiles and pedestrians assuming a one-second sampling on the input data. Larger values are necessary for aircraft and ships, and a default value of 5 should be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfPoints { get; set; } = "1";

		/// <summary>
		/// <para>Regions Of Interest</para>
		/// <para>The regions of interest. This input feature layer must be a polygon feature class. If a value is provided, a roi field will be added to the Output Feature Class parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object RegionsOfInterest { get; set; }

		/// <summary>
		/// <para>Regions Of Interest ID Field</para>
		/// <para>A field from the Regions Of Interest parameter that contains the unique identifiers for each region of interest.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object RoiIdField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyMovementEvents SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
