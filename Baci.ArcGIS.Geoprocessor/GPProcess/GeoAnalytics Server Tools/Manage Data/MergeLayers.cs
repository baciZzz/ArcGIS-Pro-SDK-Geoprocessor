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
	/// <para>Merge Layers</para>
	/// <para>Combines feature layers to create a single output layer.</para>
	/// </summary>
	public class MergeLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features or table to merge with the merge layer.</para>
		/// </param>
		/// <param name="MergeLayer">
		/// <para>Merge Layer</para>
		/// <para>The point, line, or polygon features or table to merge with the input layer. The merge layer must contain the same feature type and time type as the input layer.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		public MergeLayers(object InputLayer, object MergeLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.MergeLayer = MergeLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Layers</para>
		/// </summary>
		public override string DisplayName() => "Merge Layers";

		/// <summary>
		/// <para>Tool Name : MergeLayers</para>
		/// </summary>
		public override string ToolName() => "MergeLayers";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.MergeLayers</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.MergeLayers";

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
		public override object[] Parameters() => new object[] { InputLayer, MergeLayer, OutputName, MergingAttributes, Output, DataStore };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features or table to merge with the merge layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Merge Layer</para>
		/// <para>The point, line, or polygon features or table to merge with the input layer. The merge layer must contain the same feature type and time type as the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object MergeLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Merging Attributes</para>
		/// <para>A list of values that describe how fields from the merge layer are to be modified and matched with fields in the input layer. All fields from the input layer will be written to the output layer. If no merging attributes are defined, all fields from the merge layer will be written to the output layer.</para>
		/// <para>If a field exists in one layer but not the other, the output layer will still contain two fields. The output field will contain null values for the input features that did not have the field. For example, if the input layer contains a field named TYPE but the merge layer does not contain TYPE, the output will contain TYPE, but its values will be null for all the features copied from the merge layer.</para>
		/// <para>You can control how fields in the merge layer are written to the output layer using the following merge types:</para>
		/// <para>Remove—The merge layer field will be removed from the output layer.</para>
		/// <para>Rename—The merge layer field will be renamed in the output. You cannot rename a field from the merge layer to a field from the input layer. To make field names equivalent, use the match option.</para>
		/// <para>Match—The merge layer field is renamed and matched to a field from the input layer. For example, the input layer has a field named CODE and the merge layer has a field named STATUS. You can match STATUS to CODE, and the output will contain the CODE field with values of the STATUS field used for features copied from the merge layer. Type casting is supported for numeric values. Matching numeric fields to string fields is not supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object MergingAttributes { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

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
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeLayers SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

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
