using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Create Terrain</para>
	/// <para>Creates a new terrain dataset.</para>
	/// </summary>
	public class CreateTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset that will contain the terrain dataset.</para>
		/// </param>
		/// <param name="OutTerrainName">
		/// <para>Output Terrain</para>
		/// <para>The name of the terrain dataset.</para>
		/// </param>
		/// <param name="AveragePointSpacing">
		/// <para>Average Point Spacing</para>
		/// <para>The average horizontal distance between the data points that will be used in modeling the terrain. Sensor based measurements, like photogrammetric, lidar, and sonar surveys, typically have a known spacing that should be used. The spacing should be expressed in the horizontal units of the feature dataset's coordinate system.</para>
		/// </param>
		public CreateTerrain(object InFeatureDataset, object OutTerrainName, object AveragePointSpacing)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.OutTerrainName = OutTerrainName;
			this.AveragePointSpacing = AveragePointSpacing;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Terrain</para>
		/// </summary>
		public override string DisplayName => "Create Terrain";

		/// <summary>
		/// <para>Tool Name : CreateTerrain</para>
		/// </summary>
		public override string ToolName => "CreateTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CreateTerrain</para>
		/// </summary>
		public override string ExcuteName => "3d.CreateTerrain";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureDataset, OutTerrainName, AveragePointSpacing, MaxOverviewSize, ConfigKeyword, PyramidType, WindowsizeMethod, SecondaryThinningMethod, SecondaryThinningThreshold, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset that will contain the terrain dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Terrain</para>
		/// <para>The name of the terrain dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutTerrainName { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>The average horizontal distance between the data points that will be used in modeling the terrain. Sensor based measurements, like photogrammetric, lidar, and sonar surveys, typically have a known spacing that should be used. The spacing should be expressed in the horizontal units of the feature dataset's coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>Maximum Overview Size</para>
		/// <para>The terrain overview is akin to the image thumbnail concept. It is the coarsest representation of the terrain dataset, and the maximum size represents the upper limit of the number of measurement points that can be sampled to create the overview.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxOverviewSize { get; set; } = "50000";

		/// <summary>
		/// <para>Config Keyword</para>
		/// <para>The configuration keyword for optimizing the terrain's storage in an enterprise database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Pyramid Type</para>
		/// <para>The point thinning method used to construct the terrain pyramids.</para>
		/// <para>Window Size—Thinning is performed by selecting data points in the area defined by a given window size for each pyramid level using the criterion specified in the Window Size Method parameter.</para>
		/// <para>Z Tolerance—Thinning is performed by specifying the vertical accuracy of each pyramid level relative to the full resolution of the data points.</para>
		/// <para><see cref="PyramidTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PyramidType { get; set; } = "WINDOWSIZE";

		/// <summary>
		/// <para>Window Size Method</para>
		/// <para>The criterion used for selecting points in the area defined by the window size. This parameter is only applicable when Window Size is specified in the Pyramid Type parameter.</para>
		/// <para>Minimum Z—The point with the smallest elevation value.</para>
		/// <para>Maximum Z—The point with the largest elevation value.</para>
		/// <para>Closest To Mean Z—The point with the elevation value closest to the average of all values.</para>
		/// <para>Minimum and Maximum Z—The points with the smallest and largest elevation values.</para>
		/// <para><see cref="WindowsizeMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WindowsizeMethod { get; set; } = "ZMIN";

		/// <summary>
		/// <para>Secondary Thinning Method</para>
		/// <para>Specifies additional thinning options to reduce the number of points used over flat areas when Window Size pyramids are being used. An area is considered flat if the heights of points in an area are within the value supplied for the Secondary Thinning Threshold parameter. Its effect is more evident at higher-resolution pyramid levels, since smaller areas are more likely to be flat than larger areas.</para>
		/// <para>None—No secondary thinning will be performed. This is the default.</para>
		/// <para>Mild—Works best to preserve linear discontinuities (for example, building sides and forest boundaries). It is recommended for lidar that includes both ground and nonground points. It will thin the fewest points.</para>
		/// <para>Moderate—Provides a good trade-off between performance and accuracy. It does not preserve as much detail as mild thinning but comes nearly as close while eliminating more points overall.</para>
		/// <para>Strong—Removes the most points but is less likely to preserve sharply delineated features. Its use should be limited to surfaces where slope tends to change gradually. For example, strong thinning would be efficient for bare-earth lidar and bathymetry.</para>
		/// <para><see cref="SecondaryThinningMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SecondaryThinningMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Secondary Thinning Threshold</para>
		/// <para>The vertical threshold used to activate secondary thinning with the Window Size filter. The value should be set equal to or larger than the vertical accuracy of the data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SecondaryThinningThreshold { get; set; } = "1";

		/// <summary>
		/// <para>Output Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETerrain()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTerrain SetEnviroment(int? autoCommit = null , object configKeyword = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Pyramid Type</para>
		/// </summary>
		public enum PyramidTypeEnum 
		{
			/// <summary>
			/// <para>Window Size—Thinning is performed by selecting data points in the area defined by a given window size for each pyramid level using the criterion specified in the Window Size Method parameter.</para>
			/// </summary>
			[GPValue("WINDOWSIZE")]
			[Description("Window Size")]
			Window_Size,

			/// <summary>
			/// <para>Z Tolerance—Thinning is performed by specifying the vertical accuracy of each pyramid level relative to the full resolution of the data points.</para>
			/// </summary>
			[GPValue("ZTOLERANCE")]
			[Description("Z Tolerance")]
			Z_Tolerance,

		}

		/// <summary>
		/// <para>Window Size Method</para>
		/// </summary>
		public enum WindowsizeMethodEnum 
		{
			/// <summary>
			/// <para>Minimum Z—The point with the smallest elevation value.</para>
			/// </summary>
			[GPValue("ZMIN")]
			[Description("Minimum Z")]
			Minimum_Z,

			/// <summary>
			/// <para>Maximum Z—The point with the largest elevation value.</para>
			/// </summary>
			[GPValue("ZMAX")]
			[Description("Maximum Z")]
			Maximum_Z,

			/// <summary>
			/// <para>Closest To Mean Z—The point with the elevation value closest to the average of all values.</para>
			/// </summary>
			[GPValue("ZMEAN")]
			[Description("Closest To Mean Z")]
			Closest_To_Mean_Z,

			/// <summary>
			/// <para>Minimum and Maximum Z—The points with the smallest and largest elevation values.</para>
			/// </summary>
			[GPValue("ZMINMAX")]
			[Description("Minimum and Maximum Z")]
			Minimum_and_Maximum_Z,

		}

		/// <summary>
		/// <para>Secondary Thinning Method</para>
		/// </summary>
		public enum SecondaryThinningMethodEnum 
		{
			/// <summary>
			/// <para>None—No secondary thinning will be performed. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Mild—Works best to preserve linear discontinuities (for example, building sides and forest boundaries). It is recommended for lidar that includes both ground and nonground points. It will thin the fewest points.</para>
			/// </summary>
			[GPValue("MILD")]
			[Description("Mild")]
			Mild,

			/// <summary>
			/// <para>Moderate—Provides a good trade-off between performance and accuracy. It does not preserve as much detail as mild thinning but comes nearly as close while eliminating more points overall.</para>
			/// </summary>
			[GPValue("MODERATE")]
			[Description("Moderate")]
			Moderate,

			/// <summary>
			/// <para>Strong—Removes the most points but is less likely to preserve sharply delineated features. Its use should be limited to surfaces where slope tends to change gradually. For example, strong thinning would be efficient for bare-earth lidar and bathymetry.</para>
			/// </summary>
			[GPValue("STRONG")]
			[Description("Strong")]
			Strong,

		}

#endregion
	}
}
