using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Extract Data By Feature</para>
	/// <para>Extracts features from multiple</para>
	/// <para>input feature classes into a target database.</para>
	/// </summary>
	public class ExtractDataByFeature : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDatasets">
		/// <para>Input Datasets</para>
		/// <para>A value table of rows that contain a dataset to extract and a filter option for that dataset. Specifying a filter option allows you to control how rows are replicated in each dataset. The following are filter options:</para>
		/// <para>Dataset—The schema of the dataset will be extracted to the child workspace</para>
		/// <para>Rows Option—Specifies whether all rows, only the schema, or features that match filter criteria will be extracted.</para>
		/// <para>All Rows—All rows of the dataset will be extracted to the child workspace.</para>
		/// <para>Schema Only—Only the schema of the dataset will be extracted to the child workspace.</para>
		/// <para>Use Filters—If a feature layer is specified for the Filter Feature Layer parameter, features that either intersect or are contained by features in the Filter Feature Layer parameter will be extracted.</para>
		/// </param>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The workspace into which data will be extracted.</para>
		/// </param>
		public ExtractDataByFeature(object InDatasets, object TargetGdb)
		{
			this.InDatasets = InDatasets;
			this.TargetGdb = TargetGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Data By Feature</para>
		/// </summary>
		public override string DisplayName() => "Extract Data By Feature";

		/// <summary>
		/// <para>Tool Name : ExtractDataByFeature</para>
		/// </summary>
		public override string ToolName() => "ExtractDataByFeature";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ExtractDataByFeature</para>
		/// </summary>
		public override string ExcuteName() => "topographic.ExtractDataByFeature";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDatasets, TargetGdb, ReuseSchema, FilterFeature, FilterType, CheckoutReplica, ReplicaName, UpdatedTargetGdb, ExpandFeatureClassesAndTables, GetRelatedData, ExcludedRelClasses, WhereClause };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>A value table of rows that contain a dataset to extract and a filter option for that dataset. Specifying a filter option allows you to control how rows are replicated in each dataset. The following are filter options:</para>
		/// <para>Dataset—The schema of the dataset will be extracted to the child workspace</para>
		/// <para>Rows Option—Specifies whether all rows, only the schema, or features that match filter criteria will be extracted.</para>
		/// <para>All Rows—All rows of the dataset will be extracted to the child workspace.</para>
		/// <para>Schema Only—Only the schema of the dataset will be extracted to the child workspace.</para>
		/// <para>Use Filters—If a feature layer is specified for the Filter Feature Layer parameter, features that either intersect or are contained by features in the Filter Feature Layer parameter will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The workspace into which data will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Re-use Schema</para>
		/// <para>Specifies whether a geodatabase that contains the schema of the data to extract will be reused. This reduces the amount of time required to extract the data. This option is only supported for file geodatabases.</para>
		/// <para>Checked—The schema will be reused.</para>
		/// <para>Unchecked—The schema will not be reused. This is the default.</para>
		/// <para><see cref="ReuseSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReuseSchema { get; set; } = "false";

		/// <summary>
		/// <para>Filter Feature Layer</para>
		/// <para>A feature layer with one selected feature used to limit the extent of the data that will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Polygon")]
		public object FilterFeature { get; set; }

		/// <summary>
		/// <para>Filter Spatial Relation</para>
		/// <para>Specifies the spatial relationship between the Filter Feature Layer and Input Datasets parameter values and how that relationship will be filtered. The spatial relationship is applied to data in an extent defined by the area of interest (AOI) specified in the Filter Feature Layer parameter.</para>
		/// <para>Intersects—Features in the Input Datasets parameter that intersect features in the Filter Feature Layer parameter will be extracted.</para>
		/// <para>Contains—Features in the Input Datasets parameter that are contained by the selected feature in the Filter Feature Layer parameter will be extracted.</para>
		/// <para>Clip—Features in the Input Datasets parameter that intersect features in the Filter Feature Layer parameter will be extracted, and the features will be split at the AOI boundary and only those within the AOI will be kept.</para>
		/// <para><see cref="FilterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FilterType { get; set; }

		/// <summary>
		/// <para>Checkout replica</para>
		/// <para>Specifies whether the data will be checked out, replicated, edited, and checked back in one time.</para>
		/// <para>Checked—The replica will be checked out.</para>
		/// <para>Unchecked—The replica will not be checked out. This is the default.</para>
		/// <para><see cref="CheckoutReplicaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CheckoutReplica { get; set; } = "false";

		/// <summary>
		/// <para>Replica Name</para>
		/// <para>The name of the replica to check out.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ReplicaName { get; set; }

		/// <summary>
		/// <para>Updated Target Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTargetGdb { get; set; }

		/// <summary>
		/// <para>Expand Feature Classes and Tables</para>
		/// <para>Specifies whether expanded feature classes and tables—such as those in networks, topologies, or relationship classes—will be added.</para>
		/// <para>Use defaults—The expanded feature classes and tables related to the feature classes and tables in the replica will be added. The default for feature classes is to replicate all features intersecting the spatial filter. If no spatial filter has been provided, all features are included. The default for tables is to replicate only the schema.</para>
		/// <para>Add with schema only—Only the schema for the expanded feature classes and tables will be added.</para>
		/// <para>All rows—All rows for expanded feature classes and tables will be added.</para>
		/// <para>Do not add—No expanded feature classes and tables will be added. This is the default.</para>
		/// <para><see cref="ExpandFeatureClassesAndTablesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExpandFeatureClassesAndTables { get; set; } = "DO_NOT_ADD";

		/// <summary>
		/// <para>Replicate Related Data</para>
		/// <para>Specifies whether rows related to existing rows in the replica will be replicated. For example, consider a feature (f1) inside the replication filter and a related feature (f2) from another class outside the filter. Feature f2 is included in the replica if you choose to replicate related data.</para>
		/// <para>Checked—Related data will be replicated.</para>
		/// <para>Unchecked—Related data will not be replicated. This is the default.</para>
		/// <para><see cref="GetRelatedDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GetRelatedData { get; set; } = "false";

		/// <summary>
		/// <para>Excluded Relationship Classes</para>
		/// <para>The relationship classes with the relationships to exclude from extraction. The relationship classes will still be included if both datasets that participate are present but the related objects are not extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object ExcludedRelClasses { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression that is used to further refine results from the AOI extraction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Re-use Schema</para>
		/// </summary>
		public enum ReuseSchemaEnum 
		{
			/// <summary>
			/// <para>Checked—The schema will be reused.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REUSE")]
			REUSE,

			/// <summary>
			/// <para>Unchecked—The schema will not be reused. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REUSE")]
			DO_NOT_REUSE,

		}

		/// <summary>
		/// <para>Filter Spatial Relation</para>
		/// </summary>
		public enum FilterTypeEnum 
		{
			/// <summary>
			/// <para>Intersects—Features in the Input Datasets parameter that intersect features in the Filter Feature Layer parameter will be extracted.</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("Intersects")]
			Intersects,

			/// <summary>
			/// <para>Contains—Features in the Input Datasets parameter that are contained by the selected feature in the Filter Feature Layer parameter will be extracted.</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("Contains")]
			Contains,

			/// <summary>
			/// <para>Clip—Features in the Input Datasets parameter that intersect features in the Filter Feature Layer parameter will be extracted, and the features will be split at the AOI boundary and only those within the AOI will be kept.</para>
			/// </summary>
			[GPValue("CLIP")]
			[Description("Clip")]
			Clip,

		}

		/// <summary>
		/// <para>Checkout replica</para>
		/// </summary>
		public enum CheckoutReplicaEnum 
		{
			/// <summary>
			/// <para>Checked—The replica will be checked out.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CHECKOUT_REPLICA")]
			CHECKOUT_REPLICA,

			/// <summary>
			/// <para>Unchecked—The replica will not be checked out. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CHECKOUT_REPLICA")]
			DO_NOT_CHECKOUT_REPLICA,

		}

		/// <summary>
		/// <para>Expand Feature Classes and Tables</para>
		/// </summary>
		public enum ExpandFeatureClassesAndTablesEnum 
		{
			/// <summary>
			/// <para>Use defaults—The expanded feature classes and tables related to the feature classes and tables in the replica will be added. The default for feature classes is to replicate all features intersecting the spatial filter. If no spatial filter has been provided, all features are included. The default for tables is to replicate only the schema.</para>
			/// </summary>
			[GPValue("USE_DEFAULTS")]
			[Description("Use defaults")]
			Use_defaults,

			/// <summary>
			/// <para>Add with schema only—Only the schema for the expanded feature classes and tables will be added.</para>
			/// </summary>
			[GPValue("ADD_WITH_SCHEMA_ONLY")]
			[Description("Add with schema only")]
			Add_with_schema_only,

			/// <summary>
			/// <para>All rows—All rows for expanded feature classes and tables will be added.</para>
			/// </summary>
			[GPValue("ALL_ROWS")]
			[Description("All rows")]
			All_rows,

			/// <summary>
			/// <para>Do not add—No expanded feature classes and tables will be added. This is the default.</para>
			/// </summary>
			[GPValue("DO_NOT_ADD")]
			[Description("Do not add")]
			Do_not_add,

		}

		/// <summary>
		/// <para>Replicate Related Data</para>
		/// </summary>
		public enum GetRelatedDataEnum 
		{
			/// <summary>
			/// <para>Checked—Related data will be replicated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GET_RELATED")]
			GET_RELATED,

			/// <summary>
			/// <para>Unchecked—Related data will not be replicated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_GET_RELATED")]
			DO_NOT_GET_RELATED,

		}

#endregion
	}
}
