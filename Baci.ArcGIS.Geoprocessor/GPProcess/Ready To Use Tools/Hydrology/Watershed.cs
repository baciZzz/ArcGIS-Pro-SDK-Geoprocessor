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
	/// <para>Watershed</para>
	/// <para>Determines the contributing area above each input point. A watershed is the upslope area that contributes flow.</para>
	/// </summary>
	public class Watershed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpoints">
		/// <para>Input Points</para>
		/// <para>The point features used for calculating watersheds. These are referred to as pour points, because it is the location at which water pours out of the watershed.</para>
		/// </param>
		public Watershed(object Inputpoints)
		{
			this.Inputpoints = Inputpoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Watershed</para>
		/// </summary>
		public override string DisplayName() => "Watershed";

		/// <summary>
		/// <para>Tool Name : Watershed</para>
		/// </summary>
		public override string ToolName() => "Watershed";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.Watershed</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.Watershed";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpoints, Pointidfield, Snapdistance, Snapdistanceunits, Datasourceresolution, Generalize, Returnsnappedpoints, Watershedarea, Snappedpoints };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The point features used for calculating watersheds. These are referred to as pour points, because it is the location at which water pours out of the watershed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputpoints { get; set; }

		/// <summary>
		/// <para>Point Identification Field</para>
		/// <para>An integer or string field used to identify to the input points.</para>
		/// <para>The default is to use the unique ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Pointidfield { get; set; }

		/// <summary>
		/// <para>Snap Distance</para>
		/// <para>The maximum distance to move the location of an input point.</para>
		/// <para>Interactive input points and documented gage locations may not exactly align with the stream location in the DEM. This parameter allows the service to move the point to a nearby location with the largest contributing area.</para>
		/// <para>By default, the snapping distance is calculated as the resolution of the source data multiplied by 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Snapdistance { get; set; }

		/// <summary>
		/// <para>Snap Distance Units</para>
		/// <para>The linear units specified for the snap distance.</para>
		/// <para>Meters—The units are meters. This is the default.</para>
		/// <para>Kilometers—The units are kilometers.</para>
		/// <para>Feet—The units are feet.</para>
		/// <para>Yards—The units are yards.</para>
		/// <para>Miles—The units are miles.</para>
		/// <para><see cref="SnapdistanceunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Snapdistanceunits { get; set; } = "Meters";

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
		public object Datasourceresolution { get; set; } = " ";

		/// <summary>
		/// <para>Generalize</para>
		/// <para>Specifies whether the output watersheds will be smoothed into simpler shapes or conform to the cell edges of the original DEM.</para>
		/// <para>Unchecked—The edges of the polygons will conform to the cell edges of the original DEM. This is the default.</para>
		/// <para>Checked—The polygon boundaries will be smoothed into simpler shapes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object Generalize { get; set; } = "false";

		/// <summary>
		/// <para>Return Snapped Points</para>
		/// <para>Determines if a point feature at the watershed&apos;s pour point will be returned. If snapping is enabled, this might not be the same as the input point.</para>
		/// <para>Unchecked–No point features will be returned.</para>
		/// <para>Checked–A point feature will be returned. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object Returnsnappedpoints { get; set; } = "true";

		/// <summary>
		/// <para>Output Watershed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Watershedarea { get; set; }

		/// <summary>
		/// <para>Output Snapped Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Snappedpoints { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Snap Distance Units</para>
		/// </summary>
		public enum SnapdistanceunitsEnum 
		{
			/// <summary>
			/// <para>Meters—The units are meters. This is the default.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The units are kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The units are feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units are yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—The units are miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

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
