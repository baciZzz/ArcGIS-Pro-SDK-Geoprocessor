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
	/// <para>Get Features By Job AOI</para>
	/// <para>Get Features By Job AOI</para>
	/// <para>Extracts features from a source geodatabase to a target geodatabase based on the Filter Feature Layer parameter value (or job AOI).</para>
	/// </summary>
	public class GetFeaturesByJobAOI : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the Workflow Manager (Classic) job that will be updated. The default area over which features will be extracted or replicated is also determined.</para>
		/// </param>
		/// <param name="SourceDatabase">
		/// <para>Source Database</para>
		/// <para>The path to the source database containing features to extract.</para>
		/// </param>
		/// <param name="TargetDatabase">
		/// <para>Target Database</para>
		/// <para>The database from which features will be extracted.</para>
		/// </param>
		/// <param name="ExtractOperation">
		/// <para>Extract Operation</para>
		/// <para>Specifies whether the data will be copied to the target database or replicated to the target database.</para>
		/// <para>Extract Data—A copy of the features will be extracted to the target database. This is the default.</para>
		/// <para>Replicate Data—The features will be extracted as a replica.</para>
		/// <para><see cref="ExtractOperationEnum"/></para>
		/// </param>
		public GetFeaturesByJobAOI(object JobId, object SourceDatabase, object TargetDatabase, object ExtractOperation)
		{
			this.JobId = JobId;
			this.SourceDatabase = SourceDatabase;
			this.TargetDatabase = TargetDatabase;
			this.ExtractOperation = ExtractOperation;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Features By Job AOI</para>
		/// </summary>
		public override string DisplayName() => "Get Features By Job AOI";

		/// <summary>
		/// <para>Tool Name : GetFeaturesByJobAOI</para>
		/// </summary>
		public override string ToolName() => "GetFeaturesByJobAOI";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GetFeaturesByJobAOI</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GetFeaturesByJobAOI";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { JobId, SourceDatabase, TargetDatabase, ExtractOperation, FilterFeature, FilterType, ReplicaType, DatabasePath, UpdatedDatabase };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the Workflow Manager (Classic) job that will be updated. The default area over which features will be extracted or replicated is also determined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Source Database</para>
		/// <para>The path to the source database containing features to extract.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object SourceDatabase { get; set; }

		/// <summary>
		/// <para>Target Database</para>
		/// <para>The database from which features will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetDatabase { get; set; }

		/// <summary>
		/// <para>Extract Operation</para>
		/// <para>Specifies whether the data will be copied to the target database or replicated to the target database.</para>
		/// <para>Extract Data—A copy of the features will be extracted to the target database. This is the default.</para>
		/// <para>Replicate Data—The features will be extracted as a replica.</para>
		/// <para><see cref="ExtractOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExtractOperation { get; set; } = "EXTRACT_DATA";

		/// <summary>
		/// <para>Filter Feature Layer</para>
		/// <para>A feature layer with one selected feature that will be used to limit the extent of the data that will be extracted. If no filter feature is specified, the job AOI will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object FilterFeature { get; set; }

		/// <summary>
		/// <para>Filter Spatial Relation</para>
		/// <para>Specifies the spatial relationship between Source Database and Filter Feature Layer. This parameter is only used if the Extract Operation parameter is set to Extract Data.</para>
		/// <para>Intersects—Features from the Source Database parameter that intersect features in the Filter Feature Layer parameter will be extracted. This is the default.</para>
		/// <para>Contains—Features from the Source Database parameter that are contained in the selected feature in the Filter Feature Layer parameter will be extracted.</para>
		/// <para>Clip—Features from the Source Database parameter that intersect features in the Filter Feature Layer parameter will be extracted. Features are then split at the AOI boundary and only those in the AOI boundary will be kept.</para>
		/// <para><see cref="FilterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FilterType { get; set; } = "INTERSECTS";

		/// <summary>
		/// <para>Replica Type</para>
		/// <para>Specifies the type of replica that will be created. This parameter is only used if the Extract Operation parameter is set to Replicate Data.</para>
		/// <para>Two-way Replica—Changes can be sent between child and parent replicas in both directions.</para>
		/// <para>One-way Replica—Changes will be sent from the parent replica to the child replica only.</para>
		/// <para>Check Out—Data will be replicated, edited, and checked back in one time. This is the default.</para>
		/// <para>One-way Child To Parent Replica—Changes will be sent from the child replica to the parent replica only.</para>
		/// <para><see cref="ReplicaTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReplicaType { get; set; } = "CHECK_OUT";

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Database</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedDatabase { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Extract Operation</para>
		/// </summary>
		public enum ExtractOperationEnum 
		{
			/// <summary>
			/// <para>Extract Data—A copy of the features will be extracted to the target database. This is the default.</para>
			/// </summary>
			[GPValue("EXTRACT_DATA")]
			[Description("Extract Data")]
			Extract_Data,

			/// <summary>
			/// <para>Replicate Data—The features will be extracted as a replica.</para>
			/// </summary>
			[GPValue("REPLICATE_DATA")]
			[Description("Replicate Data")]
			Replicate_Data,

		}

		/// <summary>
		/// <para>Filter Spatial Relation</para>
		/// </summary>
		public enum FilterTypeEnum 
		{
			/// <summary>
			/// <para>Intersects—Features from the Source Database parameter that intersect features in the Filter Feature Layer parameter will be extracted. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("Intersects")]
			Intersects,

			/// <summary>
			/// <para>Contains—Features from the Source Database parameter that are contained in the selected feature in the Filter Feature Layer parameter will be extracted.</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("Contains")]
			Contains,

			/// <summary>
			/// <para>Clip—Features from the Source Database parameter that intersect features in the Filter Feature Layer parameter will be extracted. Features are then split at the AOI boundary and only those in the AOI boundary will be kept.</para>
			/// </summary>
			[GPValue("CLIP")]
			[Description("Clip")]
			Clip,

		}

		/// <summary>
		/// <para>Replica Type</para>
		/// </summary>
		public enum ReplicaTypeEnum 
		{
			/// <summary>
			/// <para>Two-way Replica—Changes can be sent between child and parent replicas in both directions.</para>
			/// </summary>
			[GPValue("TWO_WAY_REPLICA")]
			[Description("Two-way Replica")]
			TWO_WAY_REPLICA,

			/// <summary>
			/// <para>One-way Replica—Changes will be sent from the parent replica to the child replica only.</para>
			/// </summary>
			[GPValue("ONE_WAY_REPLICA")]
			[Description("One-way Replica")]
			ONE_WAY_REPLICA,

			/// <summary>
			/// <para>Check Out—Data will be replicated, edited, and checked back in one time. This is the default.</para>
			/// </summary>
			[GPValue("CHECK_OUT")]
			[Description("Check Out")]
			Check_Out,

			/// <summary>
			/// <para>One-way Child To Parent Replica—Changes will be sent from the child replica to the parent replica only.</para>
			/// </summary>
			[GPValue("ONE_WAY_CHILD_TO_PARENT_REPLICA")]
			[Description("One-way Child To Parent Replica")]
			ONE_WAY_CHILD_TO_PARENT_REPLICA,

		}

#endregion
	}
}
