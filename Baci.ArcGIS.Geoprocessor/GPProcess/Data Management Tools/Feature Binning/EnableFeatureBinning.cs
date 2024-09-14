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
	/// <para>Enable Feature Binning</para>
	/// <para>Enable Feature Binning</para>
	/// <para>Enables feature binning on a feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableFeatureBinning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class for which feature binning will be enabled. Only point and multipoint feature classes stored in an enterprise geodatabase, database, or cloud data warehouse are supported. The data cannot be versioned or archive enabled.</para>
		/// </param>
		public EnableFeatureBinning(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Feature Binning</para>
		/// </summary>
		public override string DisplayName() => "Enable Feature Binning";

		/// <summary>
		/// <para>Tool Name : EnableFeatureBinning</para>
		/// </summary>
		public override string ToolName() => "EnableFeatureBinning";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableFeatureBinning</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableFeatureBinning";

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
		public override object[] Parameters() => new object[] { InFeatures, BinType!, BinCoordSys!, SummaryStats!, GenerateStaticCache!, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class for which feature binning will be enabled. Only point and multipoint feature classes stored in an enterprise geodatabase, database, or cloud data warehouse are supported. The data cannot be versioned or archive enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>Specifies the type of binning that will be enabled. If you are using SAP HANA data, only the Square, Flat hexagon, and Pointy hexagon options are supported. If you are using Snowflake or Redshift data, only the Geohash option is supported.</para>
		/// <para>Flat hexagon—The flat hexagon binning scheme, also known as flat geohex or flat hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a flat edge of the hexagon on top. This is the default for Microsoft SQL Server, Oracle, PostgreSQL, and BigQuery data.</para>
		/// <para>Pointy hexagon—The pointy hexagon binning scheme, also known as pointy geohex or pointy hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a point of the hexagon on top.</para>
		/// <para>Square—The square binning scheme, also known as geosquare or squarebinning, will be enabled. The tiles are a tessellation of squares This is the default for Db2 and SAP HANA data.</para>
		/// <para>Geohash—The geohash binning scheme—in which the tiles are a tessellation of rectangles—will be enabled. Because geohash bins always use the WGS 1984 geographic coordinate system (GCS WGS 1984, EPSG WKID 4326), you cannot specify a bin coordinate system for geohash bins. This is the default and only option for data in Snowflake or Redshift.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; }

		/// <summary>
		/// <para>Bin Coordinate Systems</para>
		/// <para>The coordinate systems that will be used to visualize the aggregated output feature layer. You can choose up to two coordinate systems to visualize the output layer. By default, the coordinate system of the input feature class is used. Custom coordinate systems are not supported.</para>
		/// <para>This parameter does not apply to BigQuery, Redshift, or Snowflake. For those platforms, the coordinate system of the input feature class is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? BinCoordSys { get; set; }

		/// <summary>
		/// <para>Summary Statistics</para>
		/// <para>Specifies the statistics that will be summarized and stored in the bin cache. Statistics are used to symbolize bins and provide aggregate information for all the points in a bin. One summary statistic, the total feature count (shape_count), is always available. You can define up to five additional summary statistics.</para>
		/// <para>Field—The field on which the summary statistics will be calculated. Supported field types are short integer, long integer, float, and double.</para>
		/// <para>Statistic Type—The type of statistic that will be calculated for the specified field. Statistics are calculated for all features in the bin. Available statistics types are as follows:</para>
		/// <para>Mean (AVG)—Calculates the average for the specified field</para>
		/// <para>Minimum (MIN)—Finds the smallest value for all records of the specified field</para>
		/// <para>Maximum (MAX)—Finds the largest value for all records of the specified field</para>
		/// <para>Standard deviation (STDDEV)—Calculates the standard deviation value for the field</para>
		/// <para>Sum (SUM)—Adds the total value for the specified field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryStats { get; set; }

		/// <summary>
		/// <para>Generate Binning Cache</para>
		/// <para>Specifies whether a static cache of the aggregated results will be generated or visualizations will be aggregated on the fly. The cache is not necessarily created for all levels of detail.</para>
		/// <para>Checked—A static cache of the aggregated results will be generated. It is recommended that you use this option for better performance. However, changes to the underlying data will not be updated in the cache unless the Manage Feature Bin Cache tool is run.</para>
		/// <para>A static cache is generated by default for data in IBM Db2, Microsoft SQL Server, Oracle, and PostgreSQL.</para>
		/// <para>To generate a static cache for feature classes in PostgreSQL that use PostGIS spatial types, GDAL libraries must be installed in the database.</para>
		/// <para>A static cache is always generated for data in BigQuery, Redshift, and Snowflake.</para>
		/// <para>Unchecked—A static cache of the aggregated results will not be generated, and visualizations will be aggregated on the fly. This is the only option for SAP HANA data.</para>
		/// <para><see cref="GenerateStaticCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateStaticCache { get; set; } = "true";

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>Flat hexagon—The flat hexagon binning scheme, also known as flat geohex or flat hexbinning, will be enabled. The tiles are a tessellation of hexagons in which the orientation of the hexagons has a flat edge of the hexagon on top. This is the default for Microsoft SQL Server, Oracle, PostgreSQL, and BigQuery data.</para>
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
			/// <para>Square—The square binning scheme, also known as geosquare or squarebinning, will be enabled. The tiles are a tessellation of squares This is the default for Db2 and SAP HANA data.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Geohash—The geohash binning scheme—in which the tiles are a tessellation of rectangles—will be enabled. Because geohash bins always use the WGS 1984 geographic coordinate system (GCS WGS 1984, EPSG WKID 4326), you cannot specify a bin coordinate system for geohash bins. This is the default and only option for data in Snowflake or Redshift.</para>
			/// </summary>
			[GPValue("GEOHASH")]
			[Description("Geohash")]
			Geohash,

		}

		/// <summary>
		/// <para>Generate Binning Cache</para>
		/// </summary>
		public enum GenerateStaticCacheEnum 
		{
			/// <summary>
			/// <para>Checked—A static cache of the aggregated results will be generated. It is recommended that you use this option for better performance. However, changes to the underlying data will not be updated in the cache unless the Manage Feature Bin Cache tool is run.</para>
			/// </summary>
			[GPValue("true")]
			[Description("STATIC_CACHE")]
			STATIC_CACHE,

			/// <summary>
			/// <para>Unchecked—A static cache of the aggregated results will not be generated, and visualizations will be aggregated on the fly. This is the only option for SAP HANA data.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DYNAMIC")]
			DYNAMIC,

		}

#endregion
	}
}
