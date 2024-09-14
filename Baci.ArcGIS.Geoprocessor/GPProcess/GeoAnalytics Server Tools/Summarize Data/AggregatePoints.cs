using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Aggregate Points</para>
	/// <para>Aggregate Points</para>
	/// <para>Aggregates points into polygon features or bins. A polygon is returned with a count of points as well as optional statistics at all locations where points exist.</para>
	/// </summary>
	public class AggregatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>The point features to be aggregated into polygons or bins.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="PolygonOrBin">
		/// <para>Polygon or Bin</para>
		/// <para>Specifies how the Point Layer will be aggregated.</para>
		/// <para>Polygon—The point layer will be aggregated into a polygon dataset.</para>
		/// <para>Bin—The point layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </param>
		public AggregatePoints(object PointLayer, object OutputName, object PolygonOrBin)
		{
			this.PointLayer = PointLayer;
			this.OutputName = OutputName;
			this.PolygonOrBin = PolygonOrBin;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate Points</para>
		/// </summary>
		public override string DisplayName() => "Aggregate Points";

		/// <summary>
		/// <para>Tool Name : AggregatePoints</para>
		/// </summary>
		public override string ToolName() => "AggregatePoints";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.AggregatePoints</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.AggregatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { PointLayer, OutputName, PolygonOrBin, PolygonLayer!, BinType!, BinSize!, TimeStepInterval!, TimeStepRepeat!, TimeStepReference!, SummaryFields!, Output!, DataStore! };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>The point features to be aggregated into polygons or bins.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// <para>Specifies how the Point Layer will be aggregated.</para>
		/// <para>Polygon—The point layer will be aggregated into a polygon dataset.</para>
		/// <para>Bin—The point layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PolygonOrBin { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Polygon Layer</para>
		/// <para>The polygon features into which the input points will be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object? PolygonLayer { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>Specifies the bin shape that will be generated to hold the aggregated points.</para>
		/// <para>Square—Square bins will be generated, in which Bin Size represents the height of a square. This is the default.</para>
		/// <para>Hexagon—Hexagonal bins will be generated, in which Bin Size represents the height between two parallel sides.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; }

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>The distance interval that represents the bin size and units into which the Point Layer will be aggregated. The distance interval must be a linear unit.</para>
		/// <para>The distance interval that represents the Bin Size and units into which the Point Layer will be aggregated. The distance interval must be a linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? BinSize { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>A value that specifies the duration of the time step. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// <para>Time stepping can only be applied if time is enabled on the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// <para>A value that specifies how often the time-step interval occurs. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>A date that specifies the reference time with which to align the time steps. The default is January 1, 1970, at 12:00 a.m. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeStepReference { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePoints SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// </summary>
		public enum PolygonOrBinEnum 
		{
			/// <summary>
			/// <para>Polygon or Bin</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Bin—The point layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
			/// </summary>
			[GPValue("BIN")]
			[Description("Bin")]
			Bin,

		}

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>Square—Square bins will be generated, in which Bin Size represents the height of a square. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Hexagon—Hexagonal bins will be generated, in which Bin Size represents the height between two parallel sides.</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

#endregion
	}
}
