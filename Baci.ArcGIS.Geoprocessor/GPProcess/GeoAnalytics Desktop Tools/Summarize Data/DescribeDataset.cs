using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
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
		/// <param name="Output">
		/// <para>Output Table</para>
		/// <para>包含汇总信息的新表。</para>
		/// </param>
		public DescribeDataset(object InputLayer, object Output)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
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
		/// <para>Tool Excute Name : gapro.DescribeDataset</para>
		/// </summary>
		public override string ExcuteName() => "gapro.DescribeDataset";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, Output, SampleFeatures!, SampleLayer!, ExtentLayer! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要描述的点、线、面或表格要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含汇总信息的新表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Number of Sample Features</para>
		/// <para>将包含在输出样本图层中的要素数量。如果选择 0 个要素或不提供数量，则不会返回任何样本。默认情况下，不返回任何样本图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SampleFeatures { get; set; }

		/// <summary>
		/// <para>Sample Layer</para>
		/// <para>包含输入数据样本的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? SampleLayer { get; set; }

		/// <summary>
		/// <para>Extent Layer</para>
		/// <para>包含输入数据的空间和时态范围的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? ExtentLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DescribeDataset SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
