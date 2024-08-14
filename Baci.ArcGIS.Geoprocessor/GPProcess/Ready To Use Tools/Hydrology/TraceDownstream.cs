using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Trace Downstream</para>
	/// <para>Determines the path water will take from a particular location to its furthest downhill path.</para>
	/// </summary>
	public class TraceDownstream : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpoints">
		/// <para>Input Points</para>
		/// <para>The point features used for calculating downstream trace.</para>
		/// </param>
		public TraceDownstream(object Inputpoints)
		{
			this.Inputpoints = Inputpoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Trace Downstream</para>
		/// </summary>
		public override string DisplayName => "Trace Downstream";

		/// <summary>
		/// <para>Tool Name : TraceDownstream</para>
		/// </summary>
		public override string ToolName => "TraceDownstream";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.TraceDownstream</para>
		/// </summary>
		public override string ExcuteName => "agolservices.TraceDownstream";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputpoints, Pointidfield!, Datasourceresolution!, Generalize!, Outputtraceline! };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The point features used for calculating downstream trace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputpoints { get; set; }

		/// <summary>
		/// <para>Point ID Field</para>
		/// <para>An integer or string field used to identify the input points.</para>
		/// <para>The default is to use the unique ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Pointidfield { get; set; }

		/// <summary>
		/// <para>Data Source Resolution</para>
		/// <para>Specifies the source data resolution that will be used in the analysis. The values are an approximation of the spatial resolution of the digital elevation model used to build the foundation hydrologic database. Since many elevation sources are distributed in units of arc seconds, an approximation is provided in meters for easier understanding.</para>
		/// <para>Blank—The hydrologic source, built from a 3-arc second data source, which is approximately 90-meter resolution elevation data, will be used. This is the default.</para>
		/// <para>Finest—The finest resolution available at each location from all possible data sources will be used.</para>
		/// <para>10 meters—The hydrologic source, built from a 1/3 arc second data source, which is approximately 10-meter resolution elevation data, will be used.</para>
		/// <para>30 meters—The hydrologic source, built from a 1-arc second data source, which is approximately 30-meter resolution elevation data, will be used.</para>
		/// <para>90 meters—The hydrologic source, built from a 3-arc second data source, which is approximately 90-meter resolution elevation data, will be used.</para>
		/// <para><see cref="DatasourceresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Datasourceresolution { get; set; } = " ";

		/// <summary>
		/// <para>Generalize</para>
		/// <para>Specifies whether the output downstream trace lines will be smoothed into simpler lines or conform to the cell centers of the original DEM.</para>
		/// <para>Unchecked—The lines will not be smoothed. Each trace line of output downstream trace have more vertices since they conform to the original DEM cell centers. This is the default.</para>
		/// <para>Checked—The lines will be smoothed into simpler lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? Generalize { get; set; } = "false";

		/// <summary>
		/// <para>Output Trace Line</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputtraceline { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Data Source Resolution</para>
		/// </summary>
		public enum DatasourceresolutionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue(" ")]
			[Description(" ")]
			_,

			/// <summary>
			/// <para>Finest—The finest resolution available at each location from all possible data sources will be used.</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("Finest")]
			Finest,

			/// <summary>
			/// <para>10 meters—The hydrologic source, built from a 1/3 arc second data source, which is approximately 10-meter resolution elevation data, will be used.</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 meters")]
			_10_meters,

			/// <summary>
			/// <para>30 meters—The hydrologic source, built from a 1-arc second data source, which is approximately 30-meter resolution elevation data, will be used.</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 meters")]
			_30_meters,

			/// <summary>
			/// <para>90 meters—The hydrologic source, built from a 3-arc second data source, which is approximately 90-meter resolution elevation data, will be used.</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 meters")]
			_90_meters,

		}

#endregion
	}
}
