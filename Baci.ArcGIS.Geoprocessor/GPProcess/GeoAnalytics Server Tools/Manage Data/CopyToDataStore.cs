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
	/// <para>Copy To Data Store</para>
	/// <para>Copies features from the input to a new feature service in your portal.</para>
	/// </summary>
	public class CopyToDataStore : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The feature to be copied.</para>
		/// <para>When running GeoAnalytics Server tools, the analysis is completed on the GeoAnalytics Server. For optimal performance, make data available to the GeoAnalytics Server through feature layers hosted on your ArcGIS Enterprise portal or through big data file shares. Data that is not local to your GeoAnalytics Server will be moved to your GeoAnalytics Server before analysis begins. This means that it will take longer to run a tool, and in some cases, moving the data from ArcGIS Pro to your GeoAnalytics Server may fail. The threshold for failure depends on your network speeds, as well as the size and complexity of the data. Therefore, it is recommended that you always share your data or create a big data file share.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>Name of output feature service.</para>
		/// </param>
		public CopyToDataStore(object InputLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy To Data Store</para>
		/// </summary>
		public override string DisplayName => "Copy To Data Store";

		/// <summary>
		/// <para>Tool Name : CopyToDataStore</para>
		/// </summary>
		public override string ToolName => "CopyToDataStore";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CopyToDataStore</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.CopyToDataStore";

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
		public override object[] Parameters => new object[] { InputLayer, OutputName, DataStore, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The feature to be copied.</para>
		/// <para>When running GeoAnalytics Server tools, the analysis is completed on the GeoAnalytics Server. For optimal performance, make data available to the GeoAnalytics Server through feature layers hosted on your ArcGIS Enterprise portal or through big data file shares. Data that is not local to your GeoAnalytics Server will be moved to your GeoAnalytics Server before analysis begins. This means that it will take longer to run a tool, and in some cases, moving the data from ArcGIS Pro to your GeoAnalytics Server may fail. The threshold for failure depends on your network speeds, as well as the size and complexity of the data. Therefore, it is recommended that you always share your data or create a big data file share.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>Name of output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>The ArcGIS Data Store to which the output will be saved. The default is Spatiotemporal big data store. All results stored to the Spatiotemporal big data store will be stored in WGS84. Results stored in a Relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in your spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in your relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyToDataStore SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
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
			/// <para>Relational data store—Output will be stored in your relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in your spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
