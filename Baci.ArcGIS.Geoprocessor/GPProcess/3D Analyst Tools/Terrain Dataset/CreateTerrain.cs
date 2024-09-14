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
	/// <para>Create Terrain</para>
	/// <para>Creates a terrain dataset.</para>
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
		/// <para>The average horizontal distance between the data points that will be used in modeling the terrain. Sensor based measurements—such as photogrammetric, lidar, and sonar surveys—typically have a known spacing that should be used. Use the horizontal units of the feature dataset's coordinate system for the spacing.</para>
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
		public override string DisplayName() => "Create Terrain";

		/// <summary>
		/// <para>Tool Name : CreateTerrain</para>
		/// </summary>
		public override string ToolName() => "CreateTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CreateTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.CreateTerrain";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureDataset, OutTerrainName, AveragePointSpacing, MaxOverviewSize!, ConfigKeyword!, PyramidType!, WindowsizeMethod!, SecondaryThinningMethod!, SecondaryThinningThreshold!, DerivedOutTerrain!, TriangulationMethod! };

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
		/// <para>The average horizontal distance between the data points that will be used in modeling the terrain. Sensor based measurements—such as photogrammetric, lidar, and sonar surveys—typically have a known spacing that should be used. Use the horizontal units of the feature dataset's coordinate system for the spacing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>Maximum Overview Size</para>
		/// <para>The terrain overview is similar to the image thumbnail concept. It is the coarsest representation of the terrain dataset, and the maximum size represents the upper limit of the number of measurement points that can be sampled to create the overview.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxOverviewSize { get; set; } = "50000";

		/// <summary>
		/// <para>Config Keyword</para>
		/// <para>The configuration keyword that will be used to optimize the terrain's storage in an enterprise database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Pyramid Type</para>
		/// <para>Specifies the point thinning method that will be used to construct the terrain pyramids.</para>
		/// <para>Window Size—Data points in the area defined by a given window size for each pyramid level will be selected using the Window Size Method parameter value. This is the default.</para>
		/// <para>Z Tolerance—The vertical accuracy of each pyramid level relative to the full resolution of the data points will be specified.</para>
		/// <para><see cref="PyramidTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PyramidType { get; set; } = "WINDOWSIZE";

		/// <summary>
		/// <para>Window Size Method</para>
		/// <para>Specifies how points in the area defined by the window size will be selected. This parameter is only applicable when Window Size is specified for the Pyramid Type parameter.</para>
		/// <para>Minimum Z—The point with the smallest elevation value will be selected. This is the default.</para>
		/// <para>Maximum Z—The point with the largest elevation value will be selected.</para>
		/// <para>Closest To Mean Z—The point with the elevation value closest to the average of all values will be selected.</para>
		/// <para>Minimum and Maximum Z—The points with the smallest and largest elevation values will be selected.</para>
		/// <para><see cref="WindowsizeMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? WindowsizeMethod { get; set; } = "ZMIN";

		/// <summary>
		/// <para>Secondary Thinning Method</para>
		/// <para>Specifies additional thinning that will be performed to reduce the number of points used over flat areas when window size pyramids are used. An area is considered flat if the heights of points in that area are within the Secondary Thinning Threshold parameter value. Its effect is more evident at higher-resolution pyramid levels, since smaller areas are more likely to be flat than larger areas.</para>
		/// <para>None—No secondary thinning will be performed. This is the default.</para>
		/// <para>Mild—Mild thinning will be performed to preserve linear discontinuities (for example, building sides and forest boundaries). This method is recommended for lidar that includes both ground and nonground points. It will thin the fewest points.</para>
		/// <para>Moderate—Moderate thinning will be performed, which provides a balance between performance and accuracy. This method does not preserve as much detail as mild thinning but comes close while eliminating more points overall.</para>
		/// <para>Strong—Strong thinning will be performed, which removes the most points but is less likely to preserve sharply delineated features. Limit its use to surfaces where slope tends to change gradually. For example, strong thinning is efficient for bare-earth lidar and bathymetry.</para>
		/// <para><see cref="SecondaryThinningMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SecondaryThinningMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Secondary Thinning Threshold</para>
		/// <para>The vertical threshold that will be used to activate secondary thinning when the Pyramid Type parameter is set to Window Size. Set the value equal to or larger than the vertical accuracy of the data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SecondaryThinningThreshold { get; set; } = "1";

		/// <summary>
		/// <para>Output Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETerrain()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Triangulation Method</para>
		/// <para>Specifies whether breakline features will be incorporated into the terrain surface by densifying their segments to conform to Delaunay triangulation rules for constructing a TIN surface.</para>
		/// <para>Delaunay triangulation will densify breakline features to accommodate the points surrounding them in a manner that avoids the creation of long, thin triangles that typically yield undesirable results when analyzing a TIN-based surface. Additionally, natural neighbor interpolation and Thiessen (Voronoi) polygon generation can only be performed on conforming Delaunay triangulations.</para>
		/// <para>A constrained Delaunay triangulation will avoid densifying breakline features, incorporating breakline segments as edges into the TIN surface. Consider this option when you need to explicitly define certain edges that are guaranteed not to be modified (that is, split into multiple edges) by the triangulator.</para>
		/// <para>Delaunay—Breaklines will be densified to construct Delaunay triangles that accommodate the points surrounding them. This is the default.</para>
		/// <para>Constrained Delaunay—Breaklines will not be densified.</para>
		/// <para><see cref="TriangulationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TriangulationMethod { get; set; } = "DELAUNAY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTerrain SetEnviroment(int? autoCommit = null, object? configKeyword = null, object? workspace = null)
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
			/// <para>Window Size—Data points in the area defined by a given window size for each pyramid level will be selected using the Window Size Method parameter value. This is the default.</para>
			/// </summary>
			[GPValue("WINDOWSIZE")]
			[Description("Window Size")]
			Window_Size,

			/// <summary>
			/// <para>Z Tolerance—The vertical accuracy of each pyramid level relative to the full resolution of the data points will be specified.</para>
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
			/// <para>Minimum Z—The point with the smallest elevation value will be selected. This is the default.</para>
			/// </summary>
			[GPValue("ZMIN")]
			[Description("Minimum Z")]
			Minimum_Z,

			/// <summary>
			/// <para>Maximum Z—The point with the largest elevation value will be selected.</para>
			/// </summary>
			[GPValue("ZMAX")]
			[Description("Maximum Z")]
			Maximum_Z,

			/// <summary>
			/// <para>Closest To Mean Z—The point with the elevation value closest to the average of all values will be selected.</para>
			/// </summary>
			[GPValue("ZMEAN")]
			[Description("Closest To Mean Z")]
			Closest_To_Mean_Z,

			/// <summary>
			/// <para>Minimum and Maximum Z—The points with the smallest and largest elevation values will be selected.</para>
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
			/// <para>Mild—Mild thinning will be performed to preserve linear discontinuities (for example, building sides and forest boundaries). This method is recommended for lidar that includes both ground and nonground points. It will thin the fewest points.</para>
			/// </summary>
			[GPValue("MILD")]
			[Description("Mild")]
			Mild,

			/// <summary>
			/// <para>Moderate—Moderate thinning will be performed, which provides a balance between performance and accuracy. This method does not preserve as much detail as mild thinning but comes close while eliminating more points overall.</para>
			/// </summary>
			[GPValue("MODERATE")]
			[Description("Moderate")]
			Moderate,

			/// <summary>
			/// <para>Strong—Strong thinning will be performed, which removes the most points but is less likely to preserve sharply delineated features. Limit its use to surfaces where slope tends to change gradually. For example, strong thinning is efficient for bare-earth lidar and bathymetry.</para>
			/// </summary>
			[GPValue("STRONG")]
			[Description("Strong")]
			Strong,

		}

		/// <summary>
		/// <para>Triangulation Method</para>
		/// </summary>
		public enum TriangulationMethodEnum 
		{
			/// <summary>
			/// <para>Delaunay triangulation will densify breakline features to accommodate the points surrounding them in a manner that avoids the creation of long, thin triangles that typically yield undesirable results when analyzing a TIN-based surface. Additionally, natural neighbor interpolation and Thiessen (Voronoi) polygon generation can only be performed on conforming Delaunay triangulations.</para>
			/// </summary>
			[GPValue("DELAUNAY")]
			[Description("Delaunay")]
			Delaunay,

			/// <summary>
			/// <para>Constrained Delaunay—Breaklines will not be densified.</para>
			/// </summary>
			[GPValue("CONSTRAINED_DELAUNAY")]
			[Description("Constrained Delaunay")]
			Constrained_Delaunay,

		}

#endregion
	}
}
