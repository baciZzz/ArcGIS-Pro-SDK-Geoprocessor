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
	/// <para>Create Scene Layer Package</para>
	/// <para>Creates a scene layer package (.slpk file) from 3D points, multipatch features, or LAS  data.</para>
	/// </summary>
	[Obsolete()]
	public class CreateSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>The 3D points, multipatch feature layers, or LAS data (LAS, ZLAS, or LAZ) that will be used to create a scene layer package. LAS data can also be specified by selecting the parent folder that contains the desired files.</para>
		/// </param>
		/// <param name="OutSlpk">
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk file).</para>
		/// </param>
		public CreateSceneLayerPackage(object InLayer, object OutSlpk)
		{
			this.InLayer = InLayer;
			this.OutSlpk = OutSlpk;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Scene Layer Package</para>
		/// </summary>
		public override string DisplayName => "Create Scene Layer Package";

		/// <summary>
		/// <para>Tool Name : CreateSceneLayerPackage</para>
		/// </summary>
		public override string ToolName => "CreateSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreateSceneLayerPackage";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLayer, OutSlpk, Attributes!, SpatialReference!, PointSizeM!, XyMaxErrorM!, ZMaxErrorM!, TransformMethod!, InCoordinateSystem!, SceneLayerVersion! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The 3D points, multipatch feature layers, or LAS data (LAS, ZLAS, or LAZ) that will be used to create a scene layer package. LAS data can also be specified by selecting the parent folder that contains the desired files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutSlpk { get; set; }

		/// <summary>
		/// <para>Attributes to Cache</para>
		/// <para>The source data attributes to be included in the scene layer package. These values will be accessible when the content is consumed in other viewers. Select attributes are required for the desired rendering and filtering option (for example, intensity, returns, class codes, and RGB). To reduce storage, unneeded attributes should be excluded.</para>
		/// <para>Intensity— The return strength of the laser pulse for each lidar point.</para>
		/// <para>RGB—RGB imagery information collected for each lidar point.</para>
		/// <para>LAS flags—Classification and scan direction flags.</para>
		/// <para>Classification code—Classification code values.</para>
		/// <para>Return value—Discrete return number from the lidar pulse.</para>
		/// <para>User data—A customizable attribute that can be any number in the range from 0 through 255.</para>
		/// <para>Point source ID—For aerial lidar, this value typically identifies the flight path that collected a given lidar point.</para>
		/// <para>GPS time— The GPS time stamp at which the laser point was emitted from the aircraft. The time is in GPS seconds of the week.</para>
		/// <para>Scan angle—The angular direction of the laser scanner for a given lidar point. This value can range from -90 through 90.</para>
		/// <para>Near infrared—Near infrared records collected for each lidar point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Attributes { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The spatial reference of the output scene layer package. It can be any projected coordinate system or GCS_WGS_1984 but not a custom coordinate system. If a z-datum is defined, the linear unit must match that of the horizontal coordinate system. If the horizontal coordinate system is expressed in geographic coordinates, the z-datum must use meters.</para>
		/// <para>A custom coordinate system is not supported for scene layers composed of points or 3D objects.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Point Size (m)</para>
		/// <para>The point size of the lidar data. For airborne lidar data, the default of 0 or a value close to the average point spacing is usually best. For terrestrial lidar data, the point size should match the desired point spacing for the areas of interest. The default of 0 will automatically determine the best value for the input dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Point Cloud Parameters")]
		public object? PointSizeM { get; set; } = "0";

		/// <summary>
		/// <para>XY Max Error_(m)</para>
		/// <para>The maximum x,y error tolerated. A higher tolerance will result in better data compression and more efficient data transfer. The default is 0.1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Point Cloud Parameters")]
		public object? XyMaxErrorM { get; set; } = "0.01";

		/// <summary>
		/// <para>Z Max Error (m)</para>
		/// <para>The maximum z-error tolerated. A higher tolerance will result in better data compression and more efficient data transfer. The default is 0.1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Point Cloud Parameters")]
		public object? ZMaxErrorM { get; set; } = "0.01";

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>The datum transformation method that will be used when the input layer's spatial reference uses a datum that differs from the output coordinate system. All transformations are bidirectional, regardless of the direction implied by their names. For example, NAD_1927_to_WGS_1984_3 will work correctly even if the datum conversion is from WGS 1984 to NAD 1927.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TransformMethod { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system of the input LAZ files. This parameter is only used for LAZ files that do not contain spatial reference information in their header or have a PRJ file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Scene Layer Version</para>
		/// <para>The Indexed 3D Scene Layer (I3S) version of the resulting point cloud scene layer package. Specifying a version provides support for backward compatibility and allows scene layer packages to be shared with earlier versions of ArcGIS.</para>
		/// <para>1.x—Supported in all ArcGIS clients. This is the default.</para>
		/// <para>2.x—Supported in ArcGIS Pro 2.1.2 or later and can be published to ArcGIS Online and ArcGIS Enterprise 10.6.1 or later.</para>
		/// <para><see cref="SceneLayerVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SceneLayerVersion { get; set; } = "1.x";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSceneLayerPackage SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Scene Layer Version</para>
		/// </summary>
		public enum SceneLayerVersionEnum 
		{
			/// <summary>
			/// <para>1.x—Supported in all ArcGIS clients. This is the default.</para>
			/// </summary>
			[GPValue("1.X")]
			[Description("1.x")]
			_1x,

			/// <summary>
			/// <para>2.x—Supported in ArcGIS Pro 2.1.2 or later and can be published to ArcGIS Online and ArcGIS Enterprise 10.6.1 or later.</para>
			/// </summary>
			[GPValue("2.X")]
			[Description("2.x")]
			_2x,

		}

#endregion
	}
}
