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
	/// <para>Describe Dataset</para>
	/// <para>Summarizes features into calculated field statistics,  sample features, and extent boundaries.</para>
	/// </summary>
	public class DescribeDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, polygon, or tabular features to be described.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Table</para>
		/// <para>A new table with the summary information.</para>
		/// </param>
		public DescribeDataset(object InputLayer, object Output)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : Describe Dataset</para>
		/// </summary>
		public override string DisplayName() => "Describe Dataset";

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
		/// <para>The point, line, polygon, or tabular features to be described.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>A new table with the summary information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Number of Sample Features</para>
		/// <para>The number of features that will be included in the output sample layer. No sample is returned if you select 0 features or don't provide a number. By default, no sample layer is returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SampleFeatures { get; set; }

		/// <summary>
		/// <para>Sample Layer</para>
		/// <para>A new feature class with a sample of the input data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? SampleLayer { get; set; }

		/// <summary>
		/// <para>Extent Layer</para>
		/// <para>A new feature class with the spatial and temporal extent of the input data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? ExtentLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DescribeDataset SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
