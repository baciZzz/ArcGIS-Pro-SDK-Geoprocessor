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
	/// <para>Create Location File From Text File</para>
	/// <para>Create Location File From Text File</para>
	/// <para>Creates a location file for use in ArcGIS LocateXT from a text file from GeoNames, National Geospatial-Intelligence Agency Geonet Names Server, or U.S. Geological Survey Geographic Names Information Service.</para>
	/// </summary>
	public class CreateLocationFileFromTextFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPlacenamesFile">
		/// <para>Input Placenames File</para>
		/// <para>A place names text file obtained from GeoNames, NGA GNS, or USGS GNIS.</para>
		/// </param>
		/// <param name="DataSource">
		/// <para>Data Source</para>
		/// <para>Specifies the data source from which the input was created.</para>
		/// <para>GeoNames— The input file is from GeoNames.org.</para>
		/// <para>NGA GNS—The input file is from NGA GNS.</para>
		/// <para>USGS GNIS—The input file is from USGS GNIS.</para>
		/// <para>USGS Antarctic Names—The input file is from USGS GNIS Antarctic Names.</para>
		/// <para><see cref="DataSourceEnum"/></para>
		/// </param>
		/// <param name="OutLocationFile">
		/// <para>Output Location File</para>
		/// <para>The output location file.</para>
		/// </param>
		public CreateLocationFileFromTextFile(object InPlacenamesFile, object DataSource, object OutLocationFile)
		{
			this.InPlacenamesFile = InPlacenamesFile;
			this.DataSource = DataSource;
			this.OutLocationFile = OutLocationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Location File From Text File</para>
		/// </summary>
		public override string DisplayName() => "Create Location File From Text File";

		/// <summary>
		/// <para>Tool Name : CreateLocationFileFromTextFile</para>
		/// </summary>
		public override string ToolName() => "CreateLocationFileFromTextFile";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.CreateLocationFileFromTextFile</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.CreateLocationFileFromTextFile";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPlacenamesFile, DataSource, OutLocationFile, IncludeFeatures!, InRois! };

		/// <summary>
		/// <para>Input Placenames File</para>
		/// <para>A place names text file obtained from GeoNames, NGA GNS, or USGS GNIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InPlacenamesFile { get; set; }

		/// <summary>
		/// <para>Data Source</para>
		/// <para>Specifies the data source from which the input was created.</para>
		/// <para>GeoNames— The input file is from GeoNames.org.</para>
		/// <para>NGA GNS—The input file is from NGA GNS.</para>
		/// <para>USGS GNIS—The input file is from USGS GNIS.</para>
		/// <para>USGS Antarctic Names—The input file is from USGS GNIS Antarctic Names.</para>
		/// <para><see cref="DataSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataSource { get; set; } = "GEONAMES";

		/// <summary>
		/// <para>Output Location File</para>
		/// <para>The output location file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLocationFile { get; set; }

		/// <summary>
		/// <para>Include Features</para>
		/// <para>Specifies the feature class types from the input data source that will be included in the output.</para>
		/// <para>Administrative Features— Administrative features such as administrative boundaries, town, city, state, province, tribal, and country borders will be included.</para>
		/// <para>Hydrological Features—Features such as rivers, lakes, ponds, and other water features will be included.</para>
		/// <para>Locality Features—Features such as buildings, churches, hospitals, and other human-made points of interest will be included.</para>
		/// <para>Populated Places—Locations of named places such as towns, cities, villages, and other consolidated areas of people will be included.</para>
		/// <para>Transportation Features—Features such as roads, trails, railroads, and airports will be included.</para>
		/// <para>Spot Features—Hypsographic features such as mountain peaks and other natural points of interest will be included.</para>
		/// <para>Terrain Features—Features such as mountains, hills, cliffs, craters, and ridges will be included.</para>
		/// <para>Vegetation Features—Features such as forests, bushland, scrubland, and other areas of consistent vegetation will be included.</para>
		/// <para>Undersea Features—Undersea features such as reefs, bars, and shipwrecks will be included.</para>
		/// <para><see cref="IncludeFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? IncludeFeatures { get; set; }

		/// <summary>
		/// <para>Input Regions Of Interest</para>
		/// <para>The feature layer that will be used to create a subset of the input place names file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InRois { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Data Source</para>
		/// </summary>
		public enum DataSourceEnum 
		{
			/// <summary>
			/// <para>GeoNames— The input file is from GeoNames.org.</para>
			/// </summary>
			[GPValue("GEONAMES")]
			[Description("GeoNames")]
			GeoNames,

			/// <summary>
			/// <para>NGA GNS—The input file is from NGA GNS.</para>
			/// </summary>
			[GPValue("NGA_GNS")]
			[Description("NGA GNS")]
			NGA_GNS,

			/// <summary>
			/// <para>USGS GNIS—The input file is from USGS GNIS.</para>
			/// </summary>
			[GPValue("USGS_GNIS")]
			[Description("USGS GNIS")]
			USGS_GNIS,

			/// <summary>
			/// <para>USGS Antarctic Names—The input file is from USGS GNIS Antarctic Names.</para>
			/// </summary>
			[GPValue("USGS_ANTARCTIC_NAMES")]
			[Description("USGS Antarctic Names")]
			USGS_Antarctic_Names,

		}

		/// <summary>
		/// <para>Include Features</para>
		/// </summary>
		public enum IncludeFeaturesEnum 
		{
			/// <summary>
			/// <para>Administrative Features— Administrative features such as administrative boundaries, town, city, state, province, tribal, and country borders will be included.</para>
			/// </summary>
			[GPValue("ADMINISTRATIVE_FEATURES")]
			[Description("Administrative Features")]
			Administrative_Features,

			/// <summary>
			/// <para>Hydrological Features—Features such as rivers, lakes, ponds, and other water features will be included.</para>
			/// </summary>
			[GPValue("HYDROLOGICAL_FEATURES")]
			[Description("Hydrological Features")]
			Hydrological_Features,

			/// <summary>
			/// <para>Locality Features—Features such as buildings, churches, hospitals, and other human-made points of interest will be included.</para>
			/// </summary>
			[GPValue("LOCALITY_FEATURES")]
			[Description("Locality Features")]
			Locality_Features,

			/// <summary>
			/// <para>Populated Places—Locations of named places such as towns, cities, villages, and other consolidated areas of people will be included.</para>
			/// </summary>
			[GPValue("POPULATED_PLACES")]
			[Description("Populated Places")]
			Populated_Places,

			/// <summary>
			/// <para>Transportation Features—Features such as roads, trails, railroads, and airports will be included.</para>
			/// </summary>
			[GPValue("TRANSPORTATION_FEATURES")]
			[Description("Transportation Features")]
			Transportation_Features,

			/// <summary>
			/// <para>Spot Features—Hypsographic features such as mountain peaks and other natural points of interest will be included.</para>
			/// </summary>
			[GPValue("SPOT_FEATURES")]
			[Description("Spot Features")]
			Spot_Features,

			/// <summary>
			/// <para>Terrain Features—Features such as mountains, hills, cliffs, craters, and ridges will be included.</para>
			/// </summary>
			[GPValue("TERRAIN_FEATURES")]
			[Description("Terrain Features")]
			Terrain_Features,

			/// <summary>
			/// <para>Undersea Features—Undersea features such as reefs, bars, and shipwrecks will be included.</para>
			/// </summary>
			[GPValue("UNDERSEA_FEATURES")]
			[Description("Undersea Features")]
			Undersea_Features,

			/// <summary>
			/// <para>Vegetation Features—Features such as forests, bushland, scrubland, and other areas of consistent vegetation will be included.</para>
			/// </summary>
			[GPValue("VEGETATION_FEATURES")]
			[Description("Vegetation Features")]
			Vegetation_Features,

		}

#endregion
	}
}
