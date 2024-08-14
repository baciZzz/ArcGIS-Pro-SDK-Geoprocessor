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
	/// <para>Find Meeting Locations</para>
	/// <para>Identifies  locations where multiple unique movement tracks have dwelled for a defined time period.</para>
	/// </summary>
	public class FindMeetingLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input movement track points that will be analyzed for possible meeting locations. This layer must be time enabled.</para>
		/// </param>
		/// <param name="OutAreaFeatures">
		/// <para>Output Area Features</para>
		/// <para>The output area features that represent the extent of the identified meeting location.</para>
		/// </param>
		/// <param name="OutPointFeatures">
		/// <para>Output Point Features</para>
		/// <para>The output point features that represent the centroid of the area of the individual meeting. Multiple meetings can occur at a given meeting location. This feature class contains all of the details regarding the individual meetings including participants, duration, and start and end times.</para>
		/// </param>
		/// <param name="UniqueNameField">
		/// <para>In Features Name Field</para>
		/// <para>The field containing the unique identifiers for movement track points.</para>
		/// </param>
		public FindMeetingLocations(object InFeatures, object OutAreaFeatures, object OutPointFeatures, object UniqueNameField)
		{
			this.InFeatures = InFeatures;
			this.OutAreaFeatures = OutAreaFeatures;
			this.OutPointFeatures = OutPointFeatures;
			this.UniqueNameField = UniqueNameField;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Meeting Locations</para>
		/// </summary>
		public override string DisplayName => "Find Meeting Locations";

		/// <summary>
		/// <para>Tool Name : FindMeetingLocations</para>
		/// </summary>
		public override string ToolName => "FindMeetingLocations";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindMeetingLocations</para>
		/// </summary>
		public override string ExcuteName => "intelligence.FindMeetingLocations";

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
		public override object[] Parameters => new object[] { InFeatures, OutAreaFeatures, OutPointFeatures, UniqueNameField, SearchDistance, MinimumLoiterTime };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input movement track points that will be analyzed for possible meeting locations. This layer must be time enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Area Features</para>
		/// <para>The output area features that represent the extent of the identified meeting location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutAreaFeatures { get; set; }

		/// <summary>
		/// <para>Output Point Features</para>
		/// <para>The output point features that represent the centroid of the area of the individual meeting. Multiple meetings can occur at a given meeting location. This feature class contains all of the details regarding the individual meetings including participants, duration, and start and end times.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPointFeatures { get; set; }

		/// <summary>
		/// <para>In Features Name Field</para>
		/// <para>The field containing the unique identifiers for movement track points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object UniqueNameField { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance a movement track can loiter before it is no longer considered part of a meeting. The default is 100 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Minimum Loiter Time</para>
		/// <para>The minimum amount of time a movement track point can loiter in an area before it is considered to be dwelling. This helps identify possible meeting locations where multiple unique movement tracks are dwelling in the same time and space. The default is 10 minutes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object MinimumLoiterTime { get; set; } = "10 Minutes";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindMeetingLocations SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
