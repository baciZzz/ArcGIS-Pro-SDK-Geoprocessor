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
	/// <para>Features To GTFS Stops</para>
	/// <para>Features To GTFS Stops</para>
	/// <para>Converts a feature class to a GTFS stops.txt file for a GTFS public transit dataset.</para>
	/// </summary>
	public class FeaturesToGTFSStops : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>A point feature class containing transit stop geometries and at least the minimum required GTFS stops.txt file fields except stop_lat and stop_lon.</para>
		/// </param>
		/// <param name="OutGtfsStopsFile">
		/// <para>Output GTFS Stops File</para>
		/// <para>The output stops.txt file.</para>
		/// </param>
		public FeaturesToGTFSStops(object InFeatures, object OutGtfsStopsFile)
		{
			this.InFeatures = InFeatures;
			this.OutGtfsStopsFile = OutGtfsStopsFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Features To GTFS Stops</para>
		/// </summary>
		public override string DisplayName() => "Features To GTFS Stops";

		/// <summary>
		/// <para>Tool Name : FeaturesToGTFSStops</para>
		/// </summary>
		public override string ToolName() => "FeaturesToGTFSStops";

		/// <summary>
		/// <para>Tool Excute Name : transit.FeaturesToGTFSStops</para>
		/// </summary>
		public override string ExcuteName() => "transit.FeaturesToGTFSStops";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutGtfsStopsFile };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A point feature class containing transit stop geometries and at least the minimum required GTFS stops.txt file fields except stop_lat and stop_lon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output GTFS Stops File</para>
		/// <para>The output stops.txt file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsStopsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGTFSStops SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
