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
	/// <para>Dissolve Boundaries</para>
	/// <para>Dissolve Boundaries</para>
	/// <para>Finds polygons that intersect or have the same field values and merges them to form a single polygon.</para>
	/// </summary>
	public class DissolveBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Features</para>
		/// <para>The layer containing the polygon features that will be dissolved.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		public DissolveBoundaries(object InputLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : Dissolve Boundaries</para>
		/// </summary>
		public override string DisplayName() => "Dissolve Boundaries";

		/// <summary>
		/// <para>Tool Name : DissolveBoundaries</para>
		/// </summary>
		public override string ToolName() => "DissolveBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.DissolveBoundaries</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.DissolveBoundaries";

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
		public override object[] Parameters() => new object[] { InputLayer, OutputName, Multipart!, DissolveFields!, Fields!, SummaryFields!, Output!, DataStore! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The layer containing the polygon features that will be dissolved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// <para>Specifies whether multipart features will be created in the output feature class.</para>
		/// <para>Checked—Multipart features will be created.</para>
		/// <para>Unchecked—Multipart features will not be created. Individual features will be created for each part instead. This is the default.</para>
		/// <para><see cref="MultipartEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Multipart { get; set; } = "false";

		/// <summary>
		/// <para>Dissolve by Field Value(s)</para>
		/// <para>Specifies whether features with the same field values will be dissolved.</para>
		/// <para>Unchecked—Polygons that share a common border (that is, they are adjacent) or polygons that overlap will be dissolved into one polygon. This is the default.</para>
		/// <para>Checked—Polygons that have the same field value or values will be dissolved.</para>
		/// <para><see cref="DissolveFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DissolveFields { get; set; }

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>The field or fields that will be used to dissolve like features. Features with the same value for each field will be dissolved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// <para>Count—The number of nonnull values. It can be used on numeric fields or strings. The count of [null, 0, 2] is 2.</para>
		/// <para>Sum—The sum of numeric values in a field. The sum of [null, null, 3] is 3.</para>
		/// <para>Mean—The mean of numeric values. The mean of [0, 2, null] is 1.</para>
		/// <para>Min—The minimum value of a numeric field. The minimum of [0, 2, null] is 0.</para>
		/// <para>Max—The maximum value of a numeric field. The maximum value of [0, 2, null] is 2.</para>
		/// <para>Standard Deviation—The standard deviation of a numeric field. The standard deviation of [1] is null. The standard deviation of [null, 1,1,1] is null.</para>
		/// <para>Variance—The variance of a numeric field in a track. The variance of [1] is null. The variance of [null, 1, 1, 1] is null.</para>
		/// <para>Range—The range of a numeric field. This is calculated as the minimum value subtracted from the maximum value. The range of [0, null, 1] is 1. The range of [null, 4] is 0.</para>
		/// <para>Any—A sample string from a field of type string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
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
		public DissolveBoundaries SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// </summary>
		public enum MultipartEnum 
		{
			/// <summary>
			/// <para>Checked—Multipart features will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_PART")]
			MULTI_PART,

			/// <summary>
			/// <para>Unchecked—Multipart features will not be created. Individual features will be created for each part instead. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_PART")]
			SINGLE_PART,

		}

		/// <summary>
		/// <para>Dissolve by Field Value(s)</para>
		/// </summary>
		public enum DissolveFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Polygons that have the same field value or values will be dissolved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISSOLVE_FIELDS")]
			DISSOLVE_FIELDS,

			/// <summary>
			/// <para>Unchecked—Polygons that share a common border (that is, they are adjacent) or polygons that overlap will be dissolved into one polygon. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISSOLVE_FIELDS")]
			NO_DISSOLVE_FIELDS,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
