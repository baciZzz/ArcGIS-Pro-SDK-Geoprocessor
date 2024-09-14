using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>GTFS Stops To Features</para>
	/// <para>GTFS 停靠点转要素</para>
	/// <para>用于将 GTFS 公共交通数据集中的 GTFS stops.txt 文件转换为公共交通停靠点的要素类。</para>
	/// </summary>
	[Obsolete()]
	public class GTFSStopsToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsStopsFile">
		/// <para>Input GTFS Stops File</para>
		/// <para>来自 GTFS 数据集的有效 stops.txt 文件。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </param>
		public GTFSStopsToFeatures(object InGtfsStopsFile, object OutFeatureClass)
		{
			this.InGtfsStopsFile = InGtfsStopsFile;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GTFS 停靠点转要素</para>
		/// </summary>
		public override string DisplayName() => "GTFS 停靠点转要素";

		/// <summary>
		/// <para>Tool Name : GTFSStopsToFeatures</para>
		/// </summary>
		public override string ToolName() => "GTFSStopsToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GTFSStopsToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GTFSStopsToFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGtfsStopsFile, OutFeatureClass };

		/// <summary>
		/// <para>Input GTFS Stops File</para>
		/// <para>来自 GTFS 数据集的有效 stops.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsStopsFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GTFSStopsToFeatures SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
