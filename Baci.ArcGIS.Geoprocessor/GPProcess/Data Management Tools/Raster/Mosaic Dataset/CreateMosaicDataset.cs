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
	/// <para>Create Mosaic Dataset</para>
	/// <para>Creates  an empty mosaic dataset in a geodatabase.</para>
	/// </summary>
	public class CreateMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Output Location</para>
		/// <para>The path to the geodatabase.</para>
		/// <para>Starting at ArcGIS Pro 1.4, mosaic datasets created in Oracle, PostgreSQL, or SQL Server geodatabases will be created with the new RASTER_STORAGE keyword called RASTERBLOB. The RASTERBLOB keyword implements an efficient transfer of the mosaic dataset catalog items to the DBMS.</para>
		/// <para>Mosaic datasets created with RASTERBLOB cannot be opened with earlier versions of the software. If you want to create mosaic datasets that are backward compatible with earlier versions, you will need to alter the configuration keyword for RASTER_STORAGE to one of the following compatible keywords:</para>
		/// <para>BINARY for PostgreSQL and SQL Server</para>
		/// <para>BLOB for Oracle.</para>
		/// </param>
		/// <param name="InMosaicdatasetName">
		/// <para>Mosaic Dataset Name</para>
		/// <para>The name of the mosaic dataset you are creating.</para>
		/// </param>
		/// <param name="CoordinateSystem">
		/// <para>Coordinate System</para>
		/// <para>The coordinate system for all of the items in the mosaic dataset.</para>
		/// </param>
		public CreateMosaicDataset(object InWorkspace, object InMosaicdatasetName, object CoordinateSystem)
		{
			this.InWorkspace = InWorkspace;
			this.InMosaicdatasetName = InMosaicdatasetName;
			this.CoordinateSystem = CoordinateSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName => "Create Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : CreateMosaicDataset</para>
		/// </summary>
		public override string ToolName => "CreateMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMosaicDataset</para>
		/// </summary>
		public override string ExcuteName => "management.CreateMosaicDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, InMosaicdatasetName, CoordinateSystem, NumBands, PixelType, ProductDefinition, ProductBandDefinitions, OutMosaicDataset };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The path to the geodatabase.</para>
		/// <para>Starting at ArcGIS Pro 1.4, mosaic datasets created in Oracle, PostgreSQL, or SQL Server geodatabases will be created with the new RASTER_STORAGE keyword called RASTERBLOB. The RASTERBLOB keyword implements an efficient transfer of the mosaic dataset catalog items to the DBMS.</para>
		/// <para>Mosaic datasets created with RASTERBLOB cannot be opened with earlier versions of the software. If you want to create mosaic datasets that are backward compatible with earlier versions, you will need to alter the configuration keyword for RASTER_STORAGE to one of the following compatible keywords:</para>
		/// <para>BINARY for PostgreSQL and SQL Server</para>
		/// <para>BLOB for Oracle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset Name</para>
		/// <para>The name of the mosaic dataset you are creating.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InMosaicdatasetName { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system for all of the items in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>The number of bands the raster datasets will have in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pixel Properties")]
		public object NumBands { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>Set the bit depth, or radiometric resolution, of the mosaic dataset. If not defined, it will be taken from the first raster dataset.</para>
		/// <para>1 bit—A 1-bit unsigned integer. The values can be 0 or 1.</para>
		/// <para>2 bit—A 2-bit unsigned integer. The values supported can be from 0 to 3.</para>
		/// <para>4 bit—A 4-bit unsigned integer. The values supported can be from 0 to 15.</para>
		/// <para>8-bit unsigned—An unsigned 8-bit data type. The values supported can be from 0 to 255.</para>
		/// <para>8-bit signed—A signed 8-bit data type. The values supported can be from -128 to 127.</para>
		/// <para>16-bit unsigned—A 16-bit unsigned data type. The values can range from 0 to 65,535.</para>
		/// <para>16-bit signed—A 16-bit signed data type. The values can range from -32,768 to 32,767.</para>
		/// <para>32-bit unsigned—A 32-bit unsigned data type. The values can range from 0 to 4,294,967,295.</para>
		/// <para>32-bit signed—A 32-bit signed data type. The values can range from -2,147,483,648 to 2,147,483,647.</para>
		/// <para>32-bit floating point—A 32-bit data type supporting decimals.</para>
		/// <para>64 bit—A 64-bit data type supporting decimals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pixel Properties")]
		public object PixelType { get; set; }

		/// <summary>
		/// <para>Product Definition</para>
		/// <para>Select a template that is either specific to the type of imagery you are working with or is generic. The generic options include the standard raster data types as follows:</para>
		/// <para>None—No band ordering is specified for the mosaic dataset. This is the default.</para>
		/// <para>Natural color—Create a 3-band mosaic dataset, with red, green, and blue wavelength ranges. This is designed for natural color imagery.</para>
		/// <para>Natural color and infrared—Create a 4-band mosaic dataset, with red, green, blue, and near infrared wavelength ranges.</para>
		/// <para>U and V—Create a mosaic dataset displaying two variables.</para>
		/// <para>Magnitude and Direction—Create a mosaic dataset displaying magnitude and direction.</para>
		/// <para>Color infrared—Create a 3-band mosaic dataset, with near infrared, red, and green wavelength ranges.</para>
		/// <para>DMCii—Create a 3-band mosaic dataset using the DMCii wavelength ranges.</para>
		/// <para>Deimos-2—Create a 4-band mosaic dataset using the Deimos-2 wavelength ranges.</para>
		/// <para>DubaiSat-2—Create a 4-band mosaic dataset using the DubaiSat-2 wavelength ranges.</para>
		/// <para>FORMOSAT-2—Create a 4-band mosaic dataset using the FORMOSAT-2 wavelength ranges.</para>
		/// <para>GeoEye-1—Create a 4-band mosaic dataset using the GeoEye-1 wavelength ranges.</para>
		/// <para>GF-1 Panchromatic/Multispectral (PMS)—Create a 4-band mosaic dataset using the Gaofen-1 Panchromatic Multispectral Sensor wavelength ranges.</para>
		/// <para>GF-1 Wide Field of View (WFV)—Create a 4-band mosaic dataset using the Gaofen-1 Wide Field of View Sensor wavelength ranges.</para>
		/// <para>GF-2 Panchromatic/Multispectral (PMS)—Create a 4-band mosaic dataset using the Gaofen-2 Panchromatic Multispectral Sensor wavelength ranges.</para>
		/// <para>GF-4 Panchromatic/Multispectral Imagery (PMI)—Create a 4-band mosaic dataset using the Gaofen-4 panchromatic and multispectral wavelength ranges.</para>
		/// <para>HJ 1A/1B Multispectral/Hyperspectral—Create a 4-band mosaic dataset using the Huan Jing-1 CCD Multispectral or Hyperspectral Sensor wavelength ranges.</para>
		/// <para>IKONOS—Create a 4-band mosaic dataset using the IKONOS wavelength ranges.</para>
		/// <para>Jilin-1—Create a 3-band mosaic dataset using the Jilin-1 wavelength ranges.</para>
		/// <para>KOMPSAT-2—Create a 4-band mosaic dataset using the KOMPSAT-2 wavelength ranges.</para>
		/// <para>KOMPSAT-3—Create a 4-band mosaic dataset using the KOMPSAT-3 wavelength ranges.</para>
		/// <para>Landsat TM and ETM+—Create a 6-band mosaic dataset using the Landsat 5 and 7 wavelength ranges from the TM and ETM+ sensors.</para>
		/// <para>Landsat OLI—Create an 8-band mosaic dataset using the LANDSAT 8 wavelength ranges.</para>
		/// <para>Landsat MSS—Create a 4-band mosaic dataset using the Landsat wavelength ranges from the MSS sensor.</para>
		/// <para>PlanetScope—Create a mosaic dataset using the PlanetScope wavelength ranges.</para>
		/// <para>Pleiades 1—Create a 4-band mosaic dataset using the PLEIADES-1 wavelength ranges.</para>
		/// <para>QuickBird—Create a 4-band mosaic dataset using the QuickBird wavelength ranges.</para>
		/// <para>RapidEye—Create a 5-band mosaic dataset using the RapidEye wavelength ranges.</para>
		/// <para>Sentinel 2 MSI—Create a 13-band mosaic dataset using the Sentinel 2 MSI wavelength ranges.</para>
		/// <para>SkySat-C—Create a 4-band mosaic dataset using the SkySat-C MSI wavelength ranges.</para>
		/// <para>Spot 5—Create a 4-band mosaic dataset using the SPOT-5 wavelength ranges.</para>
		/// <para>Spot 6—Create a 4-band mosaic dataset using the SPOT-6 wavelength ranges.</para>
		/// <para>Spot 7—Create a 4-band mosaic dataset using the SPOT-7 wavelength ranges.</para>
		/// <para>TH-01—Create a 4-band mosaic dataset using the Tian Hui-1 wavelength ranges.</para>
		/// <para>WorldView 2—Create an 8-band mosaic dataset using the WorldView-2 wavelength ranges.</para>
		/// <para>WorldView 3—Create an 8-band mosaic dataset using the WorldView-3 wavelength ranges.</para>
		/// <para>WorldView 4—Create a 4-band mosaic dataset using the WorldView-4 wavelength ranges.</para>
		/// <para>ZY-1 Panchromatic/Multispectral—Create a 3-band mosaic dataset using the ZiYuan-1 panchromatic/multispectral wavelength ranges.</para>
		/// <para>ZY-3 CRESDA—Create a 4-band mosaic dataset using the ZiYuan-3 CRESDA wavelength ranges.</para>
		/// <para>ZY3 SASMAC—Create a 4-band mosaic dataset using the ZiYuan-3 SASMAC wavelength ranges.</para>
		/// <para>Custom—Define the number of bands and the average wavelength for each band.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ProductDefinition { get; set; } = "NONE";

		/// <summary>
		/// <para>Product Band Definitions</para>
		/// <para>Edit Product Definition by adjusting the wavelength ranges, changing the band order, and adding new bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Product Properties")]
		public object ProductBandDefinitions { get; set; }

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEMosaicDataset()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateMosaicDataset SetEnviroment(object configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

	}
}
