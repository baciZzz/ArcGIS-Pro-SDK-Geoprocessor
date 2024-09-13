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
	/// <para>Manage Feature Bin Cache</para>
	/// <para>Manage Feature Bin Cache</para>
	/// <para>Manages the feature binning cache for data with feature binning enabled.</para>
	/// </summary>
	public class ManageFeatureBinCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The binning-enabled feature class that will have its static cache updated.</para>
		/// </param>
		public ManageFeatureBinCache(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Feature Bin Cache</para>
		/// </summary>
		public override string DisplayName() => "Manage Feature Bin Cache";

		/// <summary>
		/// <para>Tool Name : ManageFeatureBinCache</para>
		/// </summary>
		public override string ToolName() => "ManageFeatureBinCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ManageFeatureBinCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ManageFeatureBinCache";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, BinType!, MaxLod!, AddCacheStatistics!, DeleteCacheStatistics!, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The binning-enabled feature class that will have its static cache updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>Specifies the type of binning that will be enabled.</para>
		/// <para>Flat hexagon—The flat hexagon binning scheme, also known as flat geohex or flat hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a flat edge of the hexagon on top. This is the default for Microsoft SQL Server, Oracle, and PostgreSQL data.</para>
		/// <para>Pointy hexagon—The pointy hexagon binning scheme, also known as pointy geohex or pointy hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a point of the hexagon on top.</para>
		/// <para>Square—The square binning scheme in which the tiles are a tessellation of squares, also known as geosquare or squarebinning, will be enabled. This is the default for Db2 data.</para>
		/// <para>Geohash—The geohash binning scheme in which the tiles are a tessellation of rectangles will be enabled. Because geohash bins always use the WGS84 geographic coordinate system (GCS WGS84, EPSG WKID 4326), you cannot specify a bin coordinate system for geohash bins.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; }

		/// <summary>
		/// <para>Level of Detail</para>
		/// <para>Specifies the maximum level of detail that will be used for the cache.</para>
		/// <para>Tiling schemes are a continuum of scale ranges. Depending on the map, you may want to forego caching of some of the extremely large or small scales in the tiling scheme. This tool examines the scale dependencies in the map and attempts to provide a maximum range of scale for caching. Choose a level of detail that most closely matches the intended use of the map in which the data will be shown.</para>
		/// <para>World—A world scale will be used as the maximum level of detail.</para>
		/// <para>Continents—Multiple continents scale will be used as the maximum level of detail.</para>
		/// <para>Continent—A single continent scale will be used as the maximum level of detail.</para>
		/// <para>Countries—Multiple countries scale will be used as the maximum level of detail.</para>
		/// <para>Country—A single country scale will be used as the maximum level of detail.</para>
		/// <para>States—Multiple states scale will be used as the maximum level of detail.</para>
		/// <para>State—A single state scale will be used as the maximum level of detail.</para>
		/// <para>Counties—Multiple counties scale will be used as the maximum level of detail.</para>
		/// <para>County—A single county scale will be used as the maximum level of detail.</para>
		/// <para>Cities—Multiple cities scale will be used as the maximum level of detail.</para>
		/// <para>City—A single city scale will be used as the maximum level of detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MaxLod { get; set; }

		/// <summary>
		/// <para>Add Statistic to Cache</para>
		/// <para>Specifies the statistics that will be summarized and stored in the bin cache. Statistics are used to symbolize bins and provide aggregate information for all the points in a bin. One summary statistic, shape_count (which is the total feature count), is always available.</para>
		/// <para>Field—The field on which the summary statistics will be calculated. Supported field types are short, long, float, and double.</para>
		/// <para>Statistic Type—The type of statistic that will be calculated for the specified field. Statistics are calculated for all features in the bin. Available statistics types are as follows:</para>
		/// <para>Mean (AVG)—Calculates the average for the specified field.</para>
		/// <para>Minimum (MIN)—Finds the smallest value for all records of the specified field.</para>
		/// <para>Maximum (MAX)—Finds the largest value for all records of the specified field.</para>
		/// <para>Standard deviation (STDDEV)—Calculates the standard deviation value for the field.</para>
		/// <para>Sum (SUM)—Adds the total value for the specified field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AddCacheStatistics { get; set; }

		/// <summary>
		/// <para>Delete Statistic from Cache</para>
		/// <para>The summary statistic that will be deleted from the cache. You cannot delete the default COUNT summary statistic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DeleteCacheStatistics { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageFeatureBinCache SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>Flat hexagon—The flat hexagon binning scheme, also known as flat geohex or flat hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a flat edge of the hexagon on top. This is the default for Microsoft SQL Server, Oracle, and PostgreSQL data.</para>
			/// </summary>
			[GPValue("FLAT_HEXAGON")]
			[Description("Flat hexagon")]
			Flat_hexagon,

			/// <summary>
			/// <para>Pointy hexagon—The pointy hexagon binning scheme, also known as pointy geohex or pointy hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a point of the hexagon on top.</para>
			/// </summary>
			[GPValue("POINTY_HEXAGON")]
			[Description("Pointy hexagon")]
			Pointy_hexagon,

			/// <summary>
			/// <para>Square—The square binning scheme in which the tiles are a tessellation of squares, also known as geosquare or squarebinning, will be enabled. This is the default for Db2 data.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Geohash—The geohash binning scheme in which the tiles are a tessellation of rectangles will be enabled. Because geohash bins always use the WGS84 geographic coordinate system (GCS WGS84, EPSG WKID 4326), you cannot specify a bin coordinate system for geohash bins.</para>
			/// </summary>
			[GPValue("GEOHASH")]
			[Description("Geohash")]
			Geohash,

		}

#endregion
	}
}
