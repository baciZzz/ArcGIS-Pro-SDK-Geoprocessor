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
	/// <para>Snap Tracks</para>
	/// <para>Snaps input track points to lines. The time-enabled point data must include features that represent an instant in time. Traversable lines with fields indicating the from and to nodes are required for analysis.</para>
	/// </summary>
	public class SnapTracks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPoints">
		/// <para>Input Point Layer</para>
		/// <para>The points that will be matched to lines. The input must be a time-enabled point layer that represents an instant in time, and must contain at least one field that identifies unique tracks.</para>
		/// </param>
		/// <param name="InputLines">
		/// <para>Input Line Layer</para>
		/// <para>The lines to which points will be matched. The input must contain fields with values indicating the from and to nodes of the line.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The maximum distance allowed between a point and any line to be considered a match. It is recommended that you use values less than or equal to 75 meters. Larger distances will result in a longer process time and less accurate results.</para>
		/// </param>
		/// <param name="ConnectivityFieldMatching">
		/// <para>Connectivity Field Matching</para>
		/// <para>The line layer fields that will be used to define the connectivity of the input line features.</para>
		/// <para>Unique ID—The line layer field that contains the unique ID value for each line feature</para>
		/// <para>From Node—The line layer field that contains the from node values</para>
		/// <para>To Node—The line layer field that contains the to node values</para>
		/// </param>
		public SnapTracks(object InputPoints, object InputLines, object OutputName, object TrackFields, object SearchDistance, object ConnectivityFieldMatching)
		{
			this.InputPoints = InputPoints;
			this.InputLines = InputLines;
			this.OutputName = OutputName;
			this.TrackFields = TrackFields;
			this.SearchDistance = SearchDistance;
			this.ConnectivityFieldMatching = ConnectivityFieldMatching;
		}

		/// <summary>
		/// <para>Tool Display Name : Snap Tracks</para>
		/// </summary>
		public override string DisplayName => "Snap Tracks";

		/// <summary>
		/// <para>Tool Name : SnapTracks</para>
		/// </summary>
		public override string ToolName => "SnapTracks";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.SnapTracks</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.SnapTracks";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputPoints, InputLines, OutputName, TrackFields, SearchDistance, ConnectivityFieldMatching, LineFieldsToInclude!, DistanceMethod!, DirectionValueMatching!, OutputMode!, DataStore!, Output! };

		/// <summary>
		/// <para>Input Point Layer</para>
		/// <para>The points that will be matched to lines. The input must be a time-enabled point layer that represents an instant in time, and must contain at least one field that identifies unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InputPoints { get; set; }

		/// <summary>
		/// <para>Input Line Layer</para>
		/// <para>The lines to which points will be matched. The input must contain fields with values indicating the from and to nodes of the line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InputLines { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance allowed between a point and any line to be considered a match. It is recommended that you use values less than or equal to 75 meters. Larger distances will result in a longer process time and less accurate results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Connectivity Field Matching</para>
		/// <para>The line layer fields that will be used to define the connectivity of the input line features.</para>
		/// <para>Unique ID—The line layer field that contains the unique ID value for each line feature</para>
		/// <para>From Node—The line layer field that contains the from node values</para>
		/// <para>To Node—The line layer field that contains the to node values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ConnectivityFieldMatching { get; set; }

		/// <summary>
		/// <para>Line Fields To Include</para>
		/// <para>One or more fields from the input line layer that will be included in the output result.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? LineFieldsToInclude { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies the method that will be used to calculate distances between points and lines.</para>
		/// <para>Geodesic— Geodesic distances will be calculated. This is the default.</para>
		/// <para>Planar—Planar distances will be calculated.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceMethod { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Direction Value Matching</para>
		/// <para>The line layer field and attribute values that will be used to define the direction of the input line features. For example, a line layer has a field named direction with values T (backward), F (forward), B (both), and &quot;&quot; (none). If no value is specified, the line is assumed to be bidirectional.</para>
		/// <para>Direction Field—The field from the line layer that describes the direction of travel.</para>
		/// <para>Forward Value—The value from the Direction Field that indicates the supported direction of travel is forward along a line.</para>
		/// <para>Backward Value—The value from the Direction Field that indicates the supported direction of travel is backward along a line.</para>
		/// <para>Both Value—The value from the Direction Field that indicates both forward and backward directions of travel are supported along a line.</para>
		/// <para>None Value—The value from the Direction Field that indicates there are no supported directions of travel along a line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? DirectionValueMatching { get; set; }

		/// <summary>
		/// <para>Output Mode</para>
		/// <para>Specifies whether all input features or only the input features that were matched to a line feature will be returned.</para>
		/// <para>All Features—All input point features will be returned whether or not they were matched to a line feature. This is the default.</para>
		/// <para>Matched Features—Only input point features that were matched to a line feature will be returned.</para>
		/// <para><see cref="OutputModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputMode { get; set; } = "ALL_FEATURES";

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
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SnapTracks SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Geodesic— Geodesic distances will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

			/// <summary>
			/// <para>Planar—Planar distances will be calculated.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

		}

		/// <summary>
		/// <para>Output Mode</para>
		/// </summary>
		public enum OutputModeEnum 
		{
			/// <summary>
			/// <para>All Features—All input point features will be returned whether or not they were matched to a line feature. This is the default.</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("All Features")]
			All_Features,

			/// <summary>
			/// <para>Matched Features—Only input point features that were matched to a line feature will be returned.</para>
			/// </summary>
			[GPValue("MATCHED_FEATURES")]
			[Description("Matched Features")]
			Matched_Features,

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
