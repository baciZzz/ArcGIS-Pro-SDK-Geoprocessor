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
	/// <para>Create Point Cloud Scene Layer Package</para>
	/// <para>Creates a point cloud scene layer package (.slpk file) from LAS, zLAS, LAZ, or LAS dataset input.</para>
	/// </summary>
	public class CreatePointCloudSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The lidar data (LAS, zLAS, LAZ, or LAS dataset) that will be used to create a scene layer package. The lidar data can also be specified by selecting the parent folder that contains the desired files.</para>
		/// </param>
		/// <param name="OutSlpk">
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk).</para>
		/// </param>
		public CreatePointCloudSceneLayerPackage(object InDataset, object OutSlpk)
		{
			this.InDataset = InDataset;
			this.OutSlpk = OutSlpk;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Point Cloud Scene Layer Package</para>
		/// </summary>
		public override string DisplayName => "Create Point Cloud Scene Layer Package";

		/// <summary>
		/// <para>Tool Name : CreatePointCloudSceneLayerPackage</para>
		/// </summary>
		public override string ToolName => "CreatePointCloudSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreatePointCloudSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreatePointCloudSceneLayerPackage";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutSlpk, OutCoorSystem, TransformMethod, Attributes, PointSizeM, XyMaxErrorM, ZMaxErrorM, InCoorSystem, SceneLayerVersion };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The lidar data (LAS, zLAS, LAZ, or LAS dataset) that will be used to create a scene layer package. The lidar data can also be specified by selecting the parent folder that contains the desired files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("slpk")]
		public object OutSlpk { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system of the output scene layer package. It can be any projected or custom coordinate system. Supported geographic coordinate systems include WGS 1984 and China Geodetic Coordinate System 2000. WGS 1984 and EGM96 Geoid are the default horizontal and vertical coordinate systems, respectively. The coordinate system can be specified in any of the following ways:</para>
		/// <para>Specify the path to a .prj file.</para>
		/// <para>Reference a dataset with the desired coordinate system.</para>
		/// <para>Use an arcpy.SpatialReference object.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object OutCoorSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]],VERTCS[\"EGM96_Geoid\",VDATUM[\"EGM96_Geoid\"],PARAMETER[\"Vertical_Shift\",0.0],PARAMETER[\"Direction\",1.0],UNIT[\"Meter\",1.0]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>The datum transformation method that will be used when the input layer&apos;s coordinate system uses a datum that differs from the output coordinate system. All transformations are bidirectional, regardless of the direction implied by their names. For example, NAD_1927_to_WGS_1984_3 will work correctly even if the datum conversion is from WGS 1984 to NAD 1927.ArcGIS coordinate system data is required for vertical datum transformations between ellipsoidal and gravity-related and two gravity-related datums.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TransformMethod { get; set; }

		/// <summary>
		/// <para>Attributes to cache</para>
		/// <para>Specifies the source data attributes to be included in the scene layer package. These values will be accessible when the content is consumed in other viewers. Select attributes that are required for the desired rendering and filtering options (for example, intensity, returns, class codes, RGB). To reduce storage, exclude unneeded attributes.</para>
		/// <para>Intensity— The return strength of the laser pulse for each lidar point.</para>
		/// <para>RGB—RGB imagery information collected for each lidar point.</para>
		/// <para>LAS flags—Classification and scan direction flags.</para>
		/// <para>Classification code—Classification code values.</para>
		/// <para>Return value—Discrete return number from the lidar pulse.</para>
		/// <para>User data—A customizable attribute that can be any number in the range of 0 through 255.</para>
		/// <para>Point source ID—For aerial lidar, this value typically identifies the flight path that collected a given lidar point.</para>
		/// <para>GPS time— The GPS time stamp at which the laser point was emitted from the aircraft. The time is in GPS seconds of the week, where the time stamp is between 0 and 604800 and resets at midnight on a Sunday.</para>
		/// <para>Scan angle—The angular direction of the laser scanner for a given lidar point. The value range is from -90 through 90.</para>
		/// <para>Near infrared—Near infrared records collected for each lidar point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Attributes { get; set; }

		/// <summary>
		/// <para>Point Size (m)</para>
		/// <para>The point size of the lidar data. For airborne lidar data, the default of 0 or a value close to the average point spacing is usually best. For terrestrial lidar data, the point size should match the desired point spacing for the areas of interest. Values are expressed in meters. The default of 0 will automatically determine the best value for the input dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PointSizeM { get; set; } = "0";

		/// <summary>
		/// <para>XY Max Error (m)</para>
		/// <para>The maximum x,y error tolerated. A higher tolerance will result in better data compression and more efficient data transfer. Values are expressed in meters. The default is 0.01.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object XyMaxErrorM { get; set; } = "0.01";

		/// <summary>
		/// <para>Z Max Error (m)</para>
		/// <para>The maximum z-error tolerated. A higher tolerance will result in better data compression and more efficient data transfer. Values are expressed in meters. The default is 0.01.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZMaxErrorM { get; set; } = "0.01";

		/// <summary>
		/// <para>Input coordinate System</para>
		/// <para>The coordinate system of the input LAZ files. This parameter is only used for LAZ files that do not contain spatial reference information in their header or have a .prj file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InCoorSystem { get; set; }

		/// <summary>
		/// <para>Scene Layer Version</para>
		/// <para>The Indexed 3D Scene Layer (I3S) version of the resulting point cloud scene layer package. Specifying a version supports backward compatibility and allows scene layer packages to be shared with earlier versions of ArcGIS.</para>
		/// <para>1.x—Supported in all ArcGIS clients.</para>
		/// <para>2.x—Supported in ArcGIS Pro 2.1.2 or later and can be published to ArcGIS Online and ArcGIS 10.6.1 or later. This is the default.</para>
		/// <para><see cref="SceneLayerVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SceneLayerVersion { get; set; } = "2.x";

		#region InnerClass

		/// <summary>
		/// <para>Scene Layer Version</para>
		/// </summary>
		public enum SceneLayerVersionEnum 
		{
			/// <summary>
			/// <para>1.x—Supported in all ArcGIS clients.</para>
			/// </summary>
			[GPValue("1.X")]
			[Description("1.x")]
			_1x,

			/// <summary>
			/// <para>2.x—Supported in ArcGIS Pro 2.1.2 or later and can be published to ArcGIS Online and ArcGIS 10.6.1 or later. This is the default.</para>
			/// </summary>
			[GPValue("2.X")]
			[Description("2.x")]
			_2x,

		}

#endregion
	}
}
