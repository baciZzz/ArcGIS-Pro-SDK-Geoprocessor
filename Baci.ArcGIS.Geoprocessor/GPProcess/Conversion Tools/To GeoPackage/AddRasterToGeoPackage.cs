using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Add Raster to GeoPackage</para>
	/// <para>Loads raster datasets into an OGC GeoPackage raster pyramid.</para>
	/// </summary>
	public class AddRasterToGeoPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to load into the OGC GeoPackage raster pyramid.</para>
		/// </param>
		/// <param name="TargetGeopackage">
		/// <para>Target GeoPackage</para>
		/// <para>The GeoPackage into which the raster dataset will be loaded.</para>
		/// </param>
		/// <param name="RasterName">
		/// <para>Raster Name</para>
		/// <para>The name of the output GeoPackage raster pyramid.</para>
		/// </param>
		public AddRasterToGeoPackage(object InDataset, object TargetGeopackage, object RasterName)
		{
			this.InDataset = InDataset;
			this.TargetGeopackage = TargetGeopackage;
			this.RasterName = RasterName;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Raster to GeoPackage</para>
		/// </summary>
		public override string DisplayName() => "Add Raster to GeoPackage";

		/// <summary>
		/// <para>Tool Name : AddRasterToGeoPackage</para>
		/// </summary>
		public override string ToolName() => "AddRasterToGeoPackage";

		/// <summary>
		/// <para>Tool Excute Name : conversion.AddRasterToGeoPackage</para>
		/// </summary>
		public override string ExcuteName() => "conversion.AddRasterToGeoPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "pyramid" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, TargetGeopackage, RasterName, TilingScheme, TilingSchemeFile, OutGeopackageRaster, AreaOfInterest };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to load into the OGC GeoPackage raster pyramid.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Target GeoPackage</para>
		/// <para>The GeoPackage into which the raster dataset will be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_folders", "esri_browseDialogFilters_sqlite")]
		public object TargetGeopackage { get; set; }

		/// <summary>
		/// <para>Raster Name</para>
		/// <para>The name of the output GeoPackage raster pyramid.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RasterName { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para>Specifies the tiling scheme.</para>
		/// <para>Tiled—The spatial reference of the input raster will be maintained and tiles will be generated consistent with the GeoPackage standard. This is the default.</para>
		/// <para>ArcGIS Online— Raster tiles will be generated in a Web Mercator coordinate reference (the same scheme developed for the Army Geospatial Center).</para>
		/// <para>NSG Profile Scaled Transverse Mercator—A scaled transverse Mercator will be used.</para>
		/// <para>NSG Profile WGS84 Geographic—WGS84 Geographic will be used.</para>
		/// <para>Google Earth Web Mercator—Raster tiles will be created using the parameters in the Web Mercator coordinate reference.</para>
		/// <para>Custom tiling scheme file—A custom tiling scheme from a file with an XML schema definition created using the Generate Tile Cache Tiling Scheme tool will be used.</para>
		/// <para><see cref="TilingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingScheme { get; set; } = "TILED";

		/// <summary>
		/// <para>Tiling Scheme File</para>
		/// <para>A custom tiling scheme file that is required when Tiling Scheme is set to Custom tiling scheme file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object TilingSchemeFile { get; set; }

		/// <summary>
		/// <para>Output GeoPackage</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutGeopackageRaster { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>An area of interest used to limit the area of the raster to be loaded, rather than the entire dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRasterToGeoPackage SetEnviroment(object compression = null , object pyramid = null )
		{
			base.SetEnv(compression: compression, pyramid: pyramid);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeEnum 
		{
			/// <summary>
			/// <para>Tiled—The spatial reference of the input raster will be maintained and tiles will be generated consistent with the GeoPackage standard. This is the default.</para>
			/// </summary>
			[GPValue("TILED")]
			[Description("Tiled")]
			Tiled,

			/// <summary>
			/// <para>ArcGIS Online— Raster tiles will be generated in a Web Mercator coordinate reference (the same scheme developed for the Army Geospatial Center).</para>
			/// </summary>
			[GPValue("ARCGISONLINE_SCHEME")]
			[Description("ArcGIS Online")]
			ArcGIS_Online,

			/// <summary>
			/// <para>Google Earth Web Mercator—Raster tiles will be created using the parameters in the Web Mercator coordinate reference.</para>
			/// </summary>
			[GPValue("GOOGLE_EARTH_WEB_MERCATOR")]
			[Description("Google Earth Web Mercator")]
			Google_Earth_Web_Mercator,

			/// <summary>
			/// <para>NSG Profile Scaled Transverse Mercator—A scaled transverse Mercator will be used.</para>
			/// </summary>
			[GPValue("NSGPROFILE_SCALED_TRANSVERSE_MERCATOR")]
			[Description("NSG Profile Scaled Transverse Mercator")]
			NSG_Profile_Scaled_Transverse_Mercator,

			/// <summary>
			/// <para>NSG Profile WGS84 Geographic—WGS84 Geographic will be used.</para>
			/// </summary>
			[GPValue("NSGPROFILE_WGS84_GEOGRAPHIC")]
			[Description("NSG Profile WGS84 Geographic")]
			NSG_Profile_WGS84_Geographic,

			/// <summary>
			/// <para>Custom tiling scheme file—A custom tiling scheme from a file with an XML schema definition created using the Generate Tile Cache Tiling Scheme tool will be used.</para>
			/// </summary>
			[GPValue("FROM_FILE")]
			[Description("Custom tiling scheme file")]
			Custom_tiling_scheme_file,

		}

#endregion
	}
}
