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
	/// <para>Describe Dataset</para>
	/// <para>描述数据集</para>
	/// <para>将要素汇总到所计算的字段统计信息、样本要素和范围边界中。</para>
	/// </summary>
	public class DescribeDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>要描述的点、线、面或表格要素。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		public DescribeDataset(object InputLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : 描述数据集</para>
		/// </summary>
		public override string DisplayName() => "描述数据集";

		/// <summary>
		/// <para>Tool Name : DescribeDataset</para>
		/// </summary>
		public override string ToolName() => "DescribeDataset";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.DescribeDataset</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.DescribeDataset";

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
		public override object[] Parameters() => new object[] { InputLayer, OutputName, SampleFeatures!, CreateExtentLayer!, DataStore!, Output!, ExtentLayer!, SampleLayer!, OutputJson! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要描述的点、线、面或表格要素。</para>
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
		/// <para>Number of Sample Features</para>
		/// <para>将包含在输出样本图层中的要素数量。如果选择 0 个要素或不提供数量，则不会返回任何样本。默认情况下，不返回任何样本图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SampleFeatures { get; set; }

		/// <summary>
		/// <para>Create Extent Layer</para>
		/// <para>指定是否将创建输出范围图层。范围是一个可表示输入要素的空间和时态范围的面。</para>
		/// <para>选中 - 将创建范围图层。</para>
		/// <para>未选中 - 将不会创建范围图层。</para>
		/// <para><see cref="CreateExtentLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateExtentLayer { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。 默认设置为时空大数据存储。 在时空大数据存储中存储的所有结果都将存储在 WGS84 中。 在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Extent Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? ExtentLayer { get; set; }

		/// <summary>
		/// <para>Sample Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? SampleLayer { get; set; }

		/// <summary>
		/// <para>Output JSON</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputJson { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DescribeDataset SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Extent Layer</para>
		/// </summary>
		public enum CreateExtentLayerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_EXTENT")]
			CREATE_EXTENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXTENT")]
			NO_EXTENT,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
