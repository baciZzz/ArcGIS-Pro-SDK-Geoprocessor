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
	/// <para>GTFS Stops To Features</para>
	/// <para>GTFS Stops To Features</para>
	/// <para>Converts a GTFS stops.txt file from a GTFS public transit dataset  to a feature class of public transit stops.</para>
	/// </summary>
	public class GTFSStopsToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsStopsFile">
		/// <para>Input GTFS Stops File</para>
		/// <para>A valid stops.txt file from a GTFS dataset.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		public GTFSStopsToFeatures(object InGtfsStopsFile, object OutFeatureClass)
		{
			this.InGtfsStopsFile = InGtfsStopsFile;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GTFS Stops To Features</para>
		/// </summary>
		public override string DisplayName() => "GTFS Stops To Features";

		/// <summary>
		/// <para>Tool Name : GTFSStopsToFeatures</para>
		/// </summary>
		public override string ToolName() => "GTFSStopsToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : transit.GTFSStopsToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "transit.GTFSStopsToFeatures";

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
		public override object[] Parameters() => new object[] { InGtfsStopsFile, OutFeatureClass };

		/// <summary>
		/// <para>Input GTFS Stops File</para>
		/// <para>A valid stops.txt file from a GTFS dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsStopsFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GTFSStopsToFeatures SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
