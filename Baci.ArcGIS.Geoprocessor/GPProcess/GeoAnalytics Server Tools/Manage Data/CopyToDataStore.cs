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
	/// <para>复制到数据存储</para>
	/// <para>将要素从输入复制到门户中的新要素服务。</para>
	/// </summary>
	public class CopyToDataStore : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>要复制的要素。</para>
		/// <para>当 GeoAnalytics Server 工具运行时，GeoAnalytics Server 上的分析已完成。 要获得最佳性能，通过 ArcGIS Enterprise 门户上托管的要素图层或通过大数据文件共享，可以将数据用于 GeoAnalytics Server。 在分析开始之前，非 GeoAnalytics Server 本地数据将被转移到您的 GeoAnalytics Server。 这意味着运行工具需要更长时间，并且在某些情况下，从 ArcGIS Pro 到 GeoAnalytics Server 移动数据可能会失败。 失败的阈值取决于网络速度，以及数据的大小和复杂性。 建议您始终共享数据或创建大数据文件共享。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		public CopyToDataStore(object InputLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制到数据存储</para>
		/// </summary>
		public override string DisplayName() => "复制到数据存储";

		/// <summary>
		/// <para>Tool Name : CopyToDataStore</para>
		/// </summary>
		public override string ToolName() => "CopyToDataStore";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CopyToDataStore</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CopyToDataStore";

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
		public override object[] Parameters() => new object[] { InputLayer, OutputName, DataStore!, Output! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要复制的要素。</para>
		/// <para>当 GeoAnalytics Server 工具运行时，GeoAnalytics Server 上的分析已完成。 要获得最佳性能，通过 ArcGIS Enterprise 门户上托管的要素图层或通过大数据文件共享，可以将数据用于 GeoAnalytics Server。 在分析开始之前，非 GeoAnalytics Server 本地数据将被转移到您的 GeoAnalytics Server。 这意味着运行工具需要更长时间，并且在某些情况下，从 ArcGIS Pro 到 GeoAnalytics Server 移动数据可能会失败。 失败的阈值取决于网络速度，以及数据的大小和复杂性。 建议您始终共享数据或创建大数据文件共享。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。存储到时空大数据存储中的所有结果都将存储于 WGS84 中。存储在关系数据存储中的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
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
		public CopyToDataStore SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
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
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
