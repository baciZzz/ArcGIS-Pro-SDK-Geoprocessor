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
	/// <para>Copy Dataset From Multifile Feature Connection</para>
	/// <para>Copy Dataset From Multifile Feature Connection</para>
	/// <para>Copies a dataset from a multifile feature connection (MFC) to a feature class.</para>
	/// </summary>
	public class CopyDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Dataset</para>
		/// <para>The point, line, polygon, or table dataset to be copied.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>The output dataset to be copied from a multifile feature connection.</para>
		/// </param>
		public CopyDatasetFromBDC(object InputLayer, object Output)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Dataset From Multifile Feature Connection</para>
		/// </summary>
		public override string DisplayName() => "Copy Dataset From Multifile Feature Connection";

		/// <summary>
		/// <para>Tool Name : CopyDatasetFromBDC</para>
		/// </summary>
		public override string ToolName() => "CopyDatasetFromBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CopyDatasetFromBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.CopyDatasetFromBDC";

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
		public override object[] Parameters() => new object[] { InputLayer, Output };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The point, line, polygon, or table dataset to be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The output dataset to be copied from a multifile feature connection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyDatasetFromBDC SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
