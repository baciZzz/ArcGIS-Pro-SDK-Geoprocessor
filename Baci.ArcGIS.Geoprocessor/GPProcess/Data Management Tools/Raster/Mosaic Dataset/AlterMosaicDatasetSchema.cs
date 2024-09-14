using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Alter Mosaic Dataset Schema</para>
	/// <para>Alter Mosaic Dataset Schema</para>
	/// <para>Defines the editing operations that nonowners  have when editing a mosaic dataset in an enterprise geodatabase.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterMosaicDatasetSchema : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset on which the permitted operations will be changed.</para>
		/// </param>
		public AlterMosaicDatasetSchema(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Mosaic Dataset Schema</para>
		/// </summary>
		public override string DisplayName() => "Alter Mosaic Dataset Schema";

		/// <summary>
		/// <para>Tool Name : AlterMosaicDatasetSchema</para>
		/// </summary>
		public override string ToolName() => "AlterMosaicDatasetSchema";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterMosaicDatasetSchema</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterMosaicDatasetSchema";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, SideTables!, RasterTypeNames!, EditorTracking!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset on which the permitted operations will be changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Operations</para>
		/// <para>Specifies the operations that will be permissible for the mosaic dataset.</para>
		/// <para>Analysis—A nonowner will be allowed to run the Analyze Mosaic Dataset tool on the mosaic dataset.</para>
		/// <para>Boundary—A nonowner will be allowed to create or edit the boundary of the mosaic dataset. This is required if a nonowner will add raster datasets outside of the existing boundary.</para>
		/// <para>Cache—A nonowner will be allowed to create a cache for the mosaic dataset.</para>
		/// <para>Color correction—A nonowner will be allowed to color correct the mosaic dataset.</para>
		/// <para>Definition—A nonowner will be allowed to add multidimensional data or a processing template to the mosaic dataset.</para>
		/// <para>Levels— A nonowner will be allowed to calculate cell size ranges for the mosaic dataset.</para>
		/// <para>Log—A nonowner will be allowed to create a log table for the mosaic dataset.</para>
		/// <para>Overview— A nonowner will be allowed to create overviews for the mosaic dataset.</para>
		/// <para>Seamline—A nonowner will be allowed to create seamlines for the mosaic dataset.</para>
		/// <para>Stereo— A nonowner will be allowed to define stereo pairs for the mosaic dataset.</para>
		/// <para>View—A nonowner will be allowed to edit the image service. When selected, Enable Editor Tracking will automatically turn on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? SideTables { get; set; }

		/// <summary>
		/// <para>Raster Types</para>
		/// <para>Specifies the raster types that nonowners can add to the mosaic dataset.</para>
		/// <para>To select a custom raster type, provide the location of the custom raster type file.</para>
		/// <para>Airborne Digital Sensors— Leica ADS raster type</para>
		/// <para>Altum—Altum raster type</para>
		/// <para>ASTER—ASTER raster type</para>
		/// <para>CADRG/ECRG—CADRG/ECRG raster type</para>
		/// <para>CIB—CIB raster type</para>
		/// <para>Deimos-2— Deimos-2 raster type</para>
		/// <para>DTED—DTED raster type</para>
		/// <para>DMCii—DMCii raster type</para>
		/// <para>DubaiSat-2—DubaiSat-2 raster type</para>
		/// <para>FORMOSAT-2—FORMOSAT-2 raster type</para>
		/// <para>Frame Camera—Frame Camera raster type</para>
		/// <para>GeoEye—GeoEye-1 raster type</para>
		/// <para>GF-1 PMS—GF-1 PMS raster type</para>
		/// <para>GF-1 WFV—GF-1 WFV raster type</para>
		/// <para>GF-2 PMS—GF-2 PMS raster type</para>
		/// <para>GF-4 PMI—GF-4 PMI raster type</para>
		/// <para>GRIB—GRIB raster type</para>
		/// <para>HDF—HDF raster type</para>
		/// <para>HJ 1A/HJ 1B CCD—HJ 1A/HJ 1B CCD raster type</para>
		/// <para>HRE—HRE raster type</para>
		/// <para>IKONOS—IKONOS raster type</para>
		/// <para>Jilin-1—Jilin-1 raster type</para>
		/// <para>KOMPSAT-2—KOMPSAT-2 raster type</para>
		/// <para>KOMPSAT-3—KOMPSAT-3 raster type</para>
		/// <para>LAS— LAS raster type</para>
		/// <para>Landsat MSS—Landsat 1-5 MSS raster type</para>
		/// <para>Landsat TM—Landsat 4-5 TM raster type</para>
		/// <para>Landsat ETM+—Landsat 7 ETM+ raster type</para>
		/// <para>Landsat 8—Landsat 8 raster type</para>
		/// <para>Landsat 9—Landsat 9 raster type</para>
		/// <para>Maxar—Maxar</para>
		/// <para>NCDRD—NCDRD raster type</para>
		/// <para>NITF—NITF raster type</para>
		/// <para>NetCDF—NetCDF raster type</para>
		/// <para>PlanetScope—PlanetScope raster type</para>
		/// <para>Pleiades Neo—Pleiades Neo raster type</para>
		/// <para>Pleiades-1—Pleiades-1 raster type</para>
		/// <para>QuickBird—Quickbird raster type</para>
		/// <para>RADARSAT-2—RADARSAT-2 raster type</para>
		/// <para>RapidEye— RapidEye raster type</para>
		/// <para>Raster Process Definition—Raster Process Definition raster type</para>
		/// <para>RedEdge—RedEdge raster type</para>
		/// <para>Scanned aerial imagery—Scanned Aerial Imagery raster type</para>
		/// <para>Sentinel-1—Sentinel-1 raster type</para>
		/// <para>Sentinel-2—Sentinel-2 raster type</para>
		/// <para>Sentinel-3—Sentinel-3 raster type</para>
		/// <para>SkySat-C—SkySat-C raster type</para>
		/// <para>Spot 5—SPOT 5 raster type</para>
		/// <para>Spot 6—SPOT 6 raster type</para>
		/// <para>Spot 7—SPOT 7 raster type</para>
		/// <para>SuperView-1—SuperView-1 raster type</para>
		/// <para>TeLEOS-1—TelEOS-1 raster type</para>
		/// <para>TH-01—TH-01 raster type</para>
		/// <para>UAV/UAS—UAV/UAS raster type</para>
		/// <para>WorldView-1—WorldView-1 raster type</para>
		/// <para>WorldView-2— WorldView-2 raster type</para>
		/// <para>WorldView-3—WorldView-3 raster type</para>
		/// <para>WorldView-4—WorldView-4 raster type</para>
		/// <para>ZY1-02C HRC—ZY1-02C HRC raster type</para>
		/// <para>ZY1-02C PMS—ZY1-02C PMS raster type</para>
		/// <para>ZY3-CRESDA—ZY3-CRESDA raster type</para>
		/// <para>ZY3-SASMAC—ZY3-SASMAC raster type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? RasterTypeNames { get; set; }

		/// <summary>
		/// <para>Enable Editor Tracking</para>
		/// <para>Specifies whether enable editor tracking will be activated.</para>
		/// <para>Editor tracking can help you maintain accountability and enforce quality-control standards.</para>
		/// <para>Unchecked—Editor tracking will not be activated. This is the default.</para>
		/// <para>Checked—Editor tracking will be activated.</para>
		/// <para>If the View option is used for the Operations parameter, editor tracking will automatically be activated.</para>
		/// <para><see cref="EditorTrackingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EditorTracking { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Enable Editor Tracking</para>
		/// </summary>
		public enum EditorTrackingEnum 
		{
			/// <summary>
			/// <para>Checked—Editor tracking will be activated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EDITOR_TRACKING")]
			EDITOR_TRACKING,

			/// <summary>
			/// <para>Unchecked—Editor tracking will not be activated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EDITOR_TRACKING")]
			NO_EDITOR_TRACKING,

		}

#endregion
	}
}
